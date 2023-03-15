namespace SkyLauncher.Pages
{
    partial class LoginFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label2;
            Label label1;
            Label label4;
            Label label7;
            UserNameLabel = new Label();
            Header = new Panel();
            ExitButton = new PictureBox();
            LoginPanel = new Panel();
            LoginRedirectToRegisterLabel = new Label();
            loginErrorMsgLabel = new Label();
            LoginButton = new Button();
            LoginPasswordTextBox = new TextBox();
            LoginEmailTextBox = new TextBox();
            RegisterPanel = new Panel();
            RegisterRedirectTologinLabel = new Label();
            RegisterPasswordConfirmTextBox = new TextBox();
            RegisterNameTextBox = new TextBox();
            RegisterErrorMsgLabel = new Label();
            RegisterBtn = new Button();
            RegisterPasswordTextBox = new TextBox();
            RegisterEmailTextBox = new TextBox();
            MainPanel = new Panel();
            MainErrorMsgLabel = new Label();
            PlayBtn = new Button();
            LogOutBtn = new PictureBox();
            SideImage = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            label7 = new Label();
            Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ExitButton).BeginInit();
            LoginPanel.SuspendLayout();
            RegisterPanel.SuspendLayout();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogOutBtn).BeginInit();
            SideImage.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(50, 73);
            label2.Name = "label2";
            label2.Size = new Size(500, 60);
            label2.TabIndex = 2;
            label2.Text = "Представьтесь, пожалуйста";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Black", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(50, 25);
            label1.Name = "label1";
            label1.Size = new Size(500, 60);
            label1.TabIndex = 1;
            label1.Text = "Добро пожаловать!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial Black", 26F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(50, 25);
            label4.Name = "label4";
            label4.Size = new Size(500, 60);
            label4.TabIndex = 1;
            label4.Text = "Пройдите регистрацию";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.UseCompatibleTextRendering = true;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Arial Black", 26F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(50, 25);
            label7.Name = "label7";
            label7.Size = new Size(500, 60);
            label7.TabIndex = 1;
            label7.Text = "С возвращением!";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.UseCompatibleTextRendering = true;
            // 
            // UserNameLabel
            // 
            UserNameLabel.BackColor = Color.Transparent;
            UserNameLabel.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            UserNameLabel.ForeColor = Color.Black;
            UserNameLabel.Location = new Point(10, 100);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(350, 60);
            UserNameLabel.TabIndex = 3;
            UserNameLabel.Text = "UserName";
            UserNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            UserNameLabel.UseCompatibleTextRendering = true;
            // 
            // Header
            // 
            Header.BackColor = Color.Transparent;
            Header.Controls.Add(ExitButton);
            Header.Location = new Point(-1, 0);
            Header.Name = "Header";
            Header.Size = new Size(1200, 60);
            Header.TabIndex = 0;
            // 
            // ExitButton
            // 
            ExitButton.BackgroundImage = Properties.Resources.exit_inactive;
            ExitButton.BackgroundImageLayout = ImageLayout.Zoom;
            ExitButton.Cursor = Cursors.Hand;
            ExitButton.Location = new Point(13, 12);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(45, 45);
            ExitButton.TabIndex = 0;
            ExitButton.TabStop = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // LoginPanel
            // 
            LoginPanel.BackColor = Color.Transparent;
            LoginPanel.Controls.Add(LoginRedirectToRegisterLabel);
            LoginPanel.Controls.Add(loginErrorMsgLabel);
            LoginPanel.Controls.Add(LoginButton);
            LoginPanel.Controls.Add(LoginPasswordTextBox);
            LoginPanel.Controls.Add(label1);
            LoginPanel.Controls.Add(LoginEmailTextBox);
            LoginPanel.Controls.Add(label2);
            LoginPanel.Location = new Point(15, 70);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(600, 450);
            LoginPanel.TabIndex = 3;
            LoginPanel.Visible = false;
            // 
            // LoginRedirectToRegisterLabel
            // 
            LoginRedirectToRegisterLabel.BackColor = Color.Transparent;
            LoginRedirectToRegisterLabel.Cursor = Cursors.Hand;
            LoginRedirectToRegisterLabel.Font = new Font("Arial Black", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LoginRedirectToRegisterLabel.ForeColor = Color.PowderBlue;
            LoginRedirectToRegisterLabel.Location = new Point(125, 430);
            LoginRedirectToRegisterLabel.Name = "LoginRedirectToRegisterLabel";
            LoginRedirectToRegisterLabel.Size = new Size(350, 20);
            LoginRedirectToRegisterLabel.TabIndex = 9;
            LoginRedirectToRegisterLabel.Text = "Еще нет аккаунта? Зарегистрироваться";
            LoginRedirectToRegisterLabel.TextAlign = ContentAlignment.MiddleCenter;
            LoginRedirectToRegisterLabel.UseCompatibleTextRendering = true;
            LoginRedirectToRegisterLabel.Click += LoginRedirectToRegisterLabel_Click;
            // 
            // loginErrorMsgLabel
            // 
            loginErrorMsgLabel.BackColor = Color.Transparent;
            loginErrorMsgLabel.Font = new Font("Arial Black", 10F, FontStyle.Regular, GraphicsUnit.Point);
            loginErrorMsgLabel.ForeColor = Color.Red;
            loginErrorMsgLabel.Location = new Point(50, 395);
            loginErrorMsgLabel.Name = "loginErrorMsgLabel";
            loginErrorMsgLabel.Size = new Size(500, 40);
            loginErrorMsgLabel.TabIndex = 4;
            loginErrorMsgLabel.Tag = "ErrorMsgLabel";
            loginErrorMsgLabel.Text = "ErrorMsgLabel";
            loginErrorMsgLabel.TextAlign = ContentAlignment.MiddleCenter;
            loginErrorMsgLabel.UseCompatibleTextRendering = true;
            // 
            // LoginButton
            // 
            LoginButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LoginButton.BackColor = Color.Transparent;
            LoginButton.BackgroundImageLayout = ImageLayout.Zoom;
            LoginButton.Cursor = Cursors.Hand;
            LoginButton.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            LoginButton.Location = new Point(200, 340);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(200, 50);
            LoginButton.TabIndex = 3;
            LoginButton.TabStop = false;
            LoginButton.Text = "Узнаешь?";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // LoginPasswordTextBox
            // 
            LoginPasswordTextBox.BackColor = Color.AntiqueWhite;
            LoginPasswordTextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            LoginPasswordTextBox.Location = new Point(125, 255);
            LoginPasswordTextBox.Name = "LoginPasswordTextBox";
            LoginPasswordTextBox.PasswordChar = '☆';
            LoginPasswordTextBox.PlaceholderText = "Пароль";
            LoginPasswordTextBox.Size = new Size(350, 34);
            LoginPasswordTextBox.TabIndex = 2;
            LoginPasswordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // LoginEmailTextBox
            // 
            LoginEmailTextBox.BackColor = Color.AntiqueWhite;
            LoginEmailTextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            LoginEmailTextBox.Location = new Point(125, 200);
            LoginEmailTextBox.Name = "LoginEmailTextBox";
            LoginEmailTextBox.PlaceholderText = "Логин";
            LoginEmailTextBox.Size = new Size(350, 34);
            LoginEmailTextBox.TabIndex = 1;
            LoginEmailTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // RegisterPanel
            // 
            RegisterPanel.BackColor = Color.Transparent;
            RegisterPanel.Controls.Add(RegisterRedirectTologinLabel);
            RegisterPanel.Controls.Add(RegisterPasswordConfirmTextBox);
            RegisterPanel.Controls.Add(RegisterNameTextBox);
            RegisterPanel.Controls.Add(RegisterErrorMsgLabel);
            RegisterPanel.Controls.Add(RegisterBtn);
            RegisterPanel.Controls.Add(RegisterPasswordTextBox);
            RegisterPanel.Controls.Add(label4);
            RegisterPanel.Controls.Add(RegisterEmailTextBox);
            RegisterPanel.Location = new Point(15, 70);
            RegisterPanel.Name = "RegisterPanel";
            RegisterPanel.Size = new Size(600, 450);
            RegisterPanel.TabIndex = 4;
            RegisterPanel.Visible = false;
            // 
            // RegisterRedirectTologinLabel
            // 
            RegisterRedirectTologinLabel.BackColor = Color.Transparent;
            RegisterRedirectTologinLabel.Cursor = Cursors.Hand;
            RegisterRedirectTologinLabel.Font = new Font("Arial Black", 10F, FontStyle.Underline, GraphicsUnit.Point);
            RegisterRedirectTologinLabel.ForeColor = Color.PowderBlue;
            RegisterRedirectTologinLabel.Location = new Point(175, 430);
            RegisterRedirectTologinLabel.Name = "RegisterRedirectTologinLabel";
            RegisterRedirectTologinLabel.Size = new Size(250, 20);
            RegisterRedirectTologinLabel.TabIndex = 8;
            RegisterRedirectTologinLabel.Text = "Уже есть аккаунт? Войти";
            RegisterRedirectTologinLabel.TextAlign = ContentAlignment.MiddleCenter;
            RegisterRedirectTologinLabel.UseCompatibleTextRendering = true;
            RegisterRedirectTologinLabel.Click += RegisterRedirectTologinLabel_Click;
            // 
            // RegisterPasswordConfirmTextBox
            // 
            RegisterPasswordConfirmTextBox.BackColor = Color.AntiqueWhite;
            RegisterPasswordConfirmTextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            RegisterPasswordConfirmTextBox.Location = new Point(125, 261);
            RegisterPasswordConfirmTextBox.Name = "RegisterPasswordConfirmTextBox";
            RegisterPasswordConfirmTextBox.PasswordChar = '☆';
            RegisterPasswordConfirmTextBox.PlaceholderText = "Повтор пароля";
            RegisterPasswordConfirmTextBox.Size = new Size(350, 34);
            RegisterPasswordConfirmTextBox.TabIndex = 4;
            RegisterPasswordConfirmTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // RegisterNameTextBox
            // 
            RegisterNameTextBox.BackColor = Color.AntiqueWhite;
            RegisterNameTextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            RegisterNameTextBox.Location = new Point(125, 111);
            RegisterNameTextBox.Name = "RegisterNameTextBox";
            RegisterNameTextBox.PlaceholderText = "Имя";
            RegisterNameTextBox.Size = new Size(350, 34);
            RegisterNameTextBox.TabIndex = 1;
            RegisterNameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // RegisterErrorMsgLabel
            // 
            RegisterErrorMsgLabel.BackColor = Color.Transparent;
            RegisterErrorMsgLabel.Font = new Font("Arial Black", 10F, FontStyle.Regular, GraphicsUnit.Point);
            RegisterErrorMsgLabel.ForeColor = Color.Red;
            RegisterErrorMsgLabel.Location = new Point(50, 395);
            RegisterErrorMsgLabel.Name = "RegisterErrorMsgLabel";
            RegisterErrorMsgLabel.Size = new Size(500, 40);
            RegisterErrorMsgLabel.TabIndex = 5;
            RegisterErrorMsgLabel.Tag = "ErrorMsgLabel";
            RegisterErrorMsgLabel.Text = "ErrorMsgLabel";
            RegisterErrorMsgLabel.TextAlign = ContentAlignment.MiddleCenter;
            RegisterErrorMsgLabel.UseCompatibleTextRendering = true;
            // 
            // RegisterBtn
            // 
            RegisterBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            RegisterBtn.BackColor = Color.Transparent;
            RegisterBtn.BackgroundImageLayout = ImageLayout.Zoom;
            RegisterBtn.Cursor = Cursors.Hand;
            RegisterBtn.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            RegisterBtn.Location = new Point(200, 340);
            RegisterBtn.Name = "RegisterBtn";
            RegisterBtn.Size = new Size(200, 50);
            RegisterBtn.TabIndex = 5;
            RegisterBtn.TabStop = false;
            RegisterBtn.Text = "Регнем!";
            RegisterBtn.UseVisualStyleBackColor = false;
            RegisterBtn.Click += RegisterBtn_Click;
            // 
            // RegisterPasswordTextBox
            // 
            RegisterPasswordTextBox.BackColor = Color.AntiqueWhite;
            RegisterPasswordTextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            RegisterPasswordTextBox.Location = new Point(125, 211);
            RegisterPasswordTextBox.Name = "RegisterPasswordTextBox";
            RegisterPasswordTextBox.PasswordChar = '☆';
            RegisterPasswordTextBox.PlaceholderText = "Пароль";
            RegisterPasswordTextBox.Size = new Size(350, 34);
            RegisterPasswordTextBox.TabIndex = 3;
            RegisterPasswordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // RegisterEmailTextBox
            // 
            RegisterEmailTextBox.BackColor = Color.AntiqueWhite;
            RegisterEmailTextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            RegisterEmailTextBox.Location = new Point(125, 161);
            RegisterEmailTextBox.Name = "RegisterEmailTextBox";
            RegisterEmailTextBox.PlaceholderText = "Адрес электронной почты";
            RegisterEmailTextBox.Size = new Size(350, 34);
            RegisterEmailTextBox.TabIndex = 2;
            RegisterEmailTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.Transparent;
            MainPanel.Controls.Add(MainErrorMsgLabel);
            MainPanel.Controls.Add(PlayBtn);
            MainPanel.Controls.Add(UserNameLabel);
            MainPanel.Controls.Add(LogOutBtn);
            MainPanel.Controls.Add(label7);
            MainPanel.Location = new Point(15, 70);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(600, 450);
            MainPanel.TabIndex = 9;
            MainPanel.Visible = false;
            // 
            // MainErrorMsgLabel
            // 
            MainErrorMsgLabel.BackColor = Color.Transparent;
            MainErrorMsgLabel.Font = new Font("Arial Black", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MainErrorMsgLabel.ForeColor = Color.Red;
            MainErrorMsgLabel.Location = new Point(66, 395);
            MainErrorMsgLabel.Name = "MainErrorMsgLabel";
            MainErrorMsgLabel.Size = new Size(325, 40);
            MainErrorMsgLabel.TabIndex = 6;
            MainErrorMsgLabel.Tag = "ErrorMsgLabel";
            MainErrorMsgLabel.Text = "ErrorMsgLabel";
            MainErrorMsgLabel.TextAlign = ContentAlignment.MiddleCenter;
            MainErrorMsgLabel.UseCompatibleTextRendering = true;
            // 
            // PlayBtn
            // 
            PlayBtn.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            PlayBtn.Location = new Point(397, 385);
            PlayBtn.Name = "PlayBtn";
            PlayBtn.Size = new Size(200, 60);
            PlayBtn.TabIndex = 4;
            PlayBtn.Text = "К игре";
            PlayBtn.UseVisualStyleBackColor = true;
            PlayBtn.Click += PlayBtn_Click;
            // 
            // LogOutBtn
            // 
            LogOutBtn.BackgroundImage = Properties.Resources.logout_step_1;
            LogOutBtn.BackgroundImageLayout = ImageLayout.Zoom;
            LogOutBtn.Cursor = Cursors.Hand;
            LogOutBtn.Location = new Point(0, 387);
            LogOutBtn.Name = "LogOutBtn";
            LogOutBtn.Size = new Size(60, 60);
            LogOutBtn.TabIndex = 2;
            LogOutBtn.TabStop = false;
            LogOutBtn.Click += LogOutBtn_Click;
            // 
            // SideImage
            // 
            SideImage.BackColor = Color.Transparent;
            SideImage.BackgroundImage = Properties.Resources.Maksim;
            SideImage.BackgroundImageLayout = ImageLayout.Zoom;
            SideImage.Controls.Add(label3);
            SideImage.Location = new Point(700, 0);
            SideImage.Name = "SideImage";
            SideImage.Size = new Size(300, 540);
            SideImage.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 403);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 0;
            label3.Text = "label3";
            // 
            // LoginFrame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            BackgroundImage = Properties.Resources.BackgroundImage;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(960, 540);
            Controls.Add(SideImage);
            Controls.Add(Header);
            Controls.Add(MainPanel);
            Controls.Add(RegisterPanel);
            Controls.Add(LoginPanel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginFrame";
            Text = "LemonSky";
            Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ExitButton).EndInit();
            LoginPanel.ResumeLayout(false);
            LoginPanel.PerformLayout();
            RegisterPanel.ResumeLayout(false);
            RegisterPanel.PerformLayout();
            MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogOutBtn).EndInit();
            SideImage.ResumeLayout(false);
            SideImage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Header;
        private PictureBox ExitButton;
        private Panel LoginPanel;
        private TextBox LoginEmailTextBox;
        private Label label1;
        private Panel SideImage;
        private Label label2;
        private Button LoginButton;
        private TextBox LoginPasswordTextBox;
        private Panel RegisterPanel;
        private Button RegisterBtn;
        private TextBox RegisterPasswordTextBox;
        private TextBox RegisterEmailTextBox;
        private Label loginErrorMsgLabel;
        private Label RegisterErrorMsgLabel;
        private TextBox RegisterNameTextBox;
        private TextBox RegisterPasswordConfirmTextBox;
        private Label RegisterRedirectTologinLabel;
        private Label label3;
        private Label LoginRedirectToRegisterLabel;
        private Panel MainPanel;
        private PictureBox LogOutBtn;
        private Label UserNameLabel;
        private Button PlayBtn;
        private Label MainErrorMsgLabel;
    }
}