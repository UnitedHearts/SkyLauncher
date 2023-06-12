using Microsoft.VisualBasic.Logging;
using SkyLauncher.Models;
using SkyLauncher.Properties;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SkyLauncher.Pages;

public partial class LoginFrame : Form
{
    [DllImport("UnityPlayer")]
    static extern int UnityMain(IntPtr hinstance, IntPtr hPrevInstance, [MarshalAs(UnmanagedType.LPTStr)] string lpCmdline, int nShowCmd);
    readonly PanelManager panelManager;
    public LoginFrame()
    {
        InitializeComponent();
        SetDraggable();
        SetBtnAnim();

        panelManager = new PanelManager(new List<Panel>() { MainPanel, RegisterPanel, LoginPanel });

        AccountManager.OnLogOut += () => { panelManager.ActivePanel = LoginPanel; };
        AccountManager.OnLogOut += async () => { await AutoLoginer.Clear(); };
        AccountManager.OnLogOut += () => { this.LogOutBtn.Visible = false; };

        AccountManager.OnLogIn += (account) => { panelManager.ActivePanel = MainPanel; };
        AccountManager.OnLogIn += async (account) => { await AutoLoginer.SetAutoLogin(new() { Email = account.Email, Password = account.Password }); };
        AccountManager.OnLogIn += (account) => { this.LogOutBtn.Visible = true; };

        AccountManager.AccountChanged += UpdateAccountInfoLabels;


        var frame = AsyncHelper.RunSync(() => TryAutoLogin());
        panelManager.ActivePanel = InitializePanel(frame);
    }

    void SetBtnAnim()
    {
        this.ExitButton.MouseEnter += (s, e) => { this.ExitButton.BackgroundImage = Resources.exit_active; };
        this.ExitButton.MouseLeave += (s, e) => { this.ExitButton.BackgroundImage = Resources.exit_inactive; };

        this.DashButton.MouseEnter += (s, e) => { this.DashButton.BackgroundImage = Resources.dash_active; };
        this.DashButton.MouseLeave += (s, e) => { this.DashButton.BackgroundImage = Resources.dash_inactive; };

        this.LogOutBtn.MouseEnter += (s, e) => { this.LogOutBtn.BackgroundImage = Resources.logout_step_2; };
        this.LogOutBtn.MouseLeave += (s, e) => { this.LogOutBtn.BackgroundImage = Resources.logout_step_1; };

        this.StartClientButton.MouseEnter += (s, e) => { this.StartClientButton.BackgroundImage = Resources.start_game_active; };
        this.StartClientButton.MouseLeave += (s, e) => { this.StartClientButton.BackgroundImage = Resources.start_game_inactive; };
    }
    Panel InitializePanel(RenderPanel frame)
    {
        return frame switch
        {
            RenderPanel.MAIN => MainPanel,
            RenderPanel.LOGIN => LoginPanel,
            RenderPanel.REGISTER => RegisterPanel,
            _ => LoginPanel
        };
    }
    void UpdateAccountInfoLabels(Account acc)
    {
        UserNameLabel.Text = acc.Name ?? "";
        ExpirienceLabel.Text = $"({acc?.Statistic?.Exp.ToString() ?? 0.ToString()} exp)";
        CoinsLabel.Text = acc?.Cash?.Current.ToString() ?? "0";
        TotalGamesLabel.Text = acc?.Statistic?.Plays.ToString() ?? "0";
        WinRateLabel.Text = ((acc?.Statistic?.Plays ?? -1) > 0 ? Math.Round(((double)acc.Statistic.Wins / acc.Statistic.Plays * 100), 2).ToString() : "0") + "%";
    }
    void UpdateRegisterInputs(string name, string email, string pass)
    {
        RegisterNameTextBox.Text = name;
        RegisterEmailTextBox.Text = email;
        RegisterPasswordTextBox.Text = pass;
        RegisterPasswordConfirmTextBox.Text = pass;
    }
    void UpdateLoginInputs(string email, string pass)
    {
        LoginEmailTextBox.Text = email;
        LoginPasswordTextBox.Text = pass;
    }

    async Task<RenderPanel> TryAutoLogin()
    {
        if (!AutoLoginer.FileExist)
            return RenderPanel.REGISTER;
        var login = await AutoLoginer.GetAutoLogin();
        if (!login.IsValid)
            return RenderPanel.LOGIN;
        var result = await Api.LogIn(login);
        if (!result.IsValid)
            return RenderPanel.LOGIN;
        var account = (await Api.AccountInfo(result.Data)).Data;
        await AccountManager.LogInLauncher(account, result.Data);
        return RenderPanel.MAIN;
    }

    #region For Draggable

    public const int WN_NCLBUTTONDOWN = 0xA1;
    public const int HTCAPTION = 0x2;
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    static extern int SendMessage(IntPtr hand, int msg, int wParam, int lParam);
    void OnMouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, WN_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }

    void SetDraggable()
    {
        SetStyle(ControlStyles.ResizeRedraw, true);
        Header.MouseDown += OnMouseDown;
        DoubleBuffered = true;
    }
    #endregion

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    private void RegisterRedirectTologinLabel_Click(object sender, EventArgs e)
    {
        panelManager.ActivePanel = LoginPanel;
    }
    private void LoginRedirectToRegisterLabel_Click(object sender, EventArgs e)
    {
        panelManager.ActivePanel = RegisterPanel;
    }
    private async void RegisterBtn_Click(object sender, EventArgs e)
    {
        // Проверка на совпадение паролей
        if (this.RegisterPasswordTextBox.Text != this.RegisterPasswordConfirmTextBox.Text)
        {
            this.RegisterErrorMsgLabel.Text = "Пароли не совпадают";
            return;
        };
        // Проверка на пустые поля
        var registerData = new RegisterRequest()
        {
            Name = this.RegisterNameTextBox.Text,
            Email = this.RegisterEmailTextBox.Text,
            Password = this.RegisterPasswordTextBox.Text
        };
        if (!registerData.IsValid)
        {
            this.RegisterErrorMsgLabel.Text = "Все поля должны быть заполнены";
            return;
        }
        // Отправка запроса на регистрацию аккаунта
        var result = await Api.CreateAccount(registerData);
        // Проверка валидности ответа запроса
        if (!result.IsValid)
        {
            this.RegisterErrorMsgLabel.Text = result.GetError().Message;
            return;
        }
        panelManager.ActivePanel = LoginPanel;
        this.loginErrorMsgLabel.Text = "На указанный адрес отправено письмо с подтверждением регистрации";
        UpdateRegisterInputs("", "", "");
    }
    private void LogOutBtn_Click(object sender, EventArgs e)
    {
        AccountManager.LogOut();
    }
    private async void LoginButton_Click(object sender, EventArgs e)
    {
        var login = new LoginModel()
        {
            Email = this.LoginEmailTextBox.Text,
            Password = this.LoginPasswordTextBox.Text
        };
        if (!login.IsValid)
        {
            this.loginErrorMsgLabel.Text = "Все поля должны быть заполнены";
            return;
        }
        var result = await Api.LogIn(login);
        if (!result.IsValid)
        {
            this.loginErrorMsgLabel.Text = result.GetError().Message;
            return;
        }
        var account = (await Api.AccountInfo(result.Data)).Data;
        await AccountManager.LogInLauncher(account, result.Data);
        UpdateLoginInputs("", "");
    }
    private async void PlayBtn_Click(object sender, EventArgs e)
    {
        try
        {
            var account = (await Api.AccountInfo(AccountManager.Token));
            if (!account.IsValid)
            {
                throw new Exception("Сервис на данный момент недоступен");
            }
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            if (!File.Exists(path + "/UnityPlayer.dll") || !Directory.Exists(path + "/SkyLauncher_Data") || !Directory.Exists(path + "/MonoBleedingEdge"))
                throw new Exception("Не найдены файлы игры");
            var commandArgs = $"-mode client -token {AccountManager.Token}";
            UnityMain(Process.GetCurrentProcess().Handle, IntPtr.Zero, commandArgs, 1);
        }
        catch (Exception ex)
        {
            MainErrorMsgLabel.Text = ex.Message;
        }
    }

    private void DashButton_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private async void StartClientButton_Click(object sender, EventArgs e)
    {
        try
        {
            var account = (await Api.AccountInfo(AccountManager.Token));
            if (!account.IsValid)
            {
                throw new Exception("Сервис на данный момент недоступен");
            }
            CheckFiles();
            var commandArgs = $"-mode client -token {AccountManager.Token}";
            UnityMain(Process.GetCurrentProcess().Handle, IntPtr.Zero, commandArgs, 1);
        }
        catch (Exception ex)
        {
            MainErrorMsgLabel.Text = ex.Message;
        }
    }

    void CheckFiles()
    {
        var path = Path.GetDirectoryName(Application.ExecutablePath);
        if (!File.Exists(path + "/UnityPlayer.dll") || !Directory.Exists(path + "/SkyLauncher_Data") || !Directory.Exists(path + "/MonoBleedingEdge"))
            throw new Exception("Не найдены файлы игры");
    }
}
