using Microsoft.VisualBasic.Logging;
using SkyLauncher.Properties;
using System.Runtime.InteropServices;

namespace SkyLauncher.Pages
{
    public partial class LoginFrame : Form
    {
        readonly PanelManager panelManager;
        public LoginFrame()
        {
            InitializeComponent();
            SetDtaggable();
            DoubleBuffered = true;
            SetBtnAnim();

            panelManager = new PanelManager(new List<Panel>() { MainPanel, RegisterPanel, LoginPanel });

            AccountManager.OnLogOut += () => { panelManager.ActivePanel = LoginPanel; };
            AccountManager.OnLogOut += async () => { await AutoLoginer.Clear(); };

            AccountManager.OnLogIn += (account) => { panelManager.ActivePanel = MainPanel; };
            AccountManager.OnLogIn += async (account) => { await AutoLoginer.SetAutoLogin(new() { Email = account.Email, Password = account.Password }); };

            AccountManager.AccountChanged += UpdateAccountInfoLabels;


            var frame = AsyncHelper.RunSync(() => TryAutoLogin());
            InitializePanels(frame);
        }

        void SetBtnAnim()
        {
            this.ExitButton.MouseEnter += (s, e) => { this.ExitButton.BackgroundImage = Resources.exit_active; };
            this.ExitButton.MouseLeave += (s, e) => { this.ExitButton.BackgroundImage = Resources.exit_inactive; };

            this.LogOutBtn.MouseEnter += (s, e) => { this.LogOutBtn.BackgroundImage = Resources.logout_step_2; };
            this.LogOutBtn.MouseLeave += (s, e) => { this.LogOutBtn.BackgroundImage = Resources.logout_step_1; };
        }
        void InitializePanels(int frame)
        {
            switch (frame)
            {
                case 0:
                    panelManager.ActivePanel = MainPanel;
                    break;
                case 1:
                    panelManager.ActivePanel = LoginPanel;
                    break;
                case 2:
                    panelManager.ActivePanel = RegisterPanel;
                    break;
            }
        }
        void UpdateAccountInfoLabels(Account acc)
        {
            UserNameLabel.Text = acc.Name ?? "";
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

        async Task<int> TryAutoLogin()
        {
            if (!AutoLoginer.FileExist)
                return 2;
            var login = await AutoLoginer.GetAutoLogin();
            if (!login.IsValid)
                return 1;
            var result = await Api.LogIn(login);
            if (!result.IsValid)
                return 1;
            AccountManager.LogIn(result.Data);
            return 0;
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

        void SetDtaggable()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            Header.MouseDown += OnMouseDown;
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
            AccountManager.LogIn(result.Data);
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
            AccountManager.LogIn(result.Data);
            UpdateLoginInputs("", "");
        }
        private void PlayBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
