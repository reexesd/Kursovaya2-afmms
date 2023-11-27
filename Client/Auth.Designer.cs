namespace Client
{
    partial class Auth
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
            this.components = new System.ComponentModel.Container();
            this.HelloLabel = new System.Windows.Forms.Label();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.RepeatPasswordLabel = new System.Windows.Forms.Label();
            this.PasswordRepeatTB = new System.Windows.Forms.TextBox();
            this.HaveAccLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.RegistrationLabel = new System.Windows.Forms.Label();
            this.RiseAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.UsernameInputError = new System.Windows.Forms.Label();
            this.PasswordInputError = new System.Windows.Forms.Label();
            this.PasswordRepeatInputError = new System.Windows.Forms.Label();
            this.RememberMe = new System.Windows.Forms.CheckBox();
            this.DisappearanceAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.HidePassword = new System.Windows.Forms.PictureBox();
            this.BackButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HidePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            this.SuspendLayout();
            // 
            // HelloLabel
            // 
            this.HelloLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelloLabel.ForeColor = System.Drawing.Color.Black;
            this.HelloLabel.Location = new System.Drawing.Point(12, 9);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(310, 81);
            this.HelloLabel.TabIndex = 0;
            this.HelloLabel.Text = "Для использования\r\nприложения необходимо\r\nзарегистрироваться";
            this.HelloLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameTB
            // 
            this.UsernameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsernameTB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameTB.ForeColor = System.Drawing.Color.Gray;
            this.UsernameTB.Location = new System.Drawing.Point(66, 132);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(203, 21);
            this.UsernameTB.TabIndex = 1;
            this.UsernameTB.TabStop = false;
            this.UsernameTB.Text = "username@afmms.ru";
            this.UsernameTB.TextChanged += new System.EventHandler(this.UsernameTB_TextChanged);
            this.UsernameTB.Enter += new System.EventHandler(this.UsernameTB_Enter);
            this.UsernameTB.Leave += new System.EventHandler(this.UsernameTB_Leave);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.Black;
            this.UsernameLabel.Location = new System.Drawing.Point(12, 103);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(310, 26);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Имя почтового ящика";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.Black;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 184);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(310, 19);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Придумайте пароль";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordTB
            // 
            this.PasswordTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTB.Location = new System.Drawing.Point(66, 206);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '•';
            this.PasswordTB.Size = new System.Drawing.Size(203, 21);
            this.PasswordTB.TabIndex = 3;
            this.PasswordTB.TabStop = false;
            this.PasswordTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged);
            // 
            // RepeatPasswordLabel
            // 
            this.RepeatPasswordLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RepeatPasswordLabel.ForeColor = System.Drawing.Color.Black;
            this.RepeatPasswordLabel.Location = new System.Drawing.Point(12, 258);
            this.RepeatPasswordLabel.Name = "RepeatPasswordLabel";
            this.RepeatPasswordLabel.Size = new System.Drawing.Size(310, 19);
            this.RepeatPasswordLabel.TabIndex = 6;
            this.RepeatPasswordLabel.Text = "Повторите пароль";
            this.RepeatPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordRepeatTB
            // 
            this.PasswordRepeatTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordRepeatTB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordRepeatTB.Location = new System.Drawing.Point(66, 280);
            this.PasswordRepeatTB.Name = "PasswordRepeatTB";
            this.PasswordRepeatTB.PasswordChar = '•';
            this.PasswordRepeatTB.Size = new System.Drawing.Size(203, 21);
            this.PasswordRepeatTB.TabIndex = 5;
            this.PasswordRepeatTB.TabStop = false;
            this.PasswordRepeatTB.TextChanged += new System.EventHandler(this.PasswordRepeatTB_TextChanged);
            // 
            // HaveAccLabel
            // 
            this.HaveAccLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HaveAccLabel.ForeColor = System.Drawing.Color.Black;
            this.HaveAccLabel.Location = new System.Drawing.Point(65, 376);
            this.HaveAccLabel.Name = "HaveAccLabel";
            this.HaveAccLabel.Size = new System.Drawing.Size(153, 26);
            this.HaveAccLabel.TabIndex = 7;
            this.HaveAccLabel.Text = "Уже есть аккаунт?";
            this.HaveAccLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginLabel
            // 
            this.LoginLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginLabel.ForeColor = System.Drawing.Color.Black;
            this.LoginLabel.Location = new System.Drawing.Point(214, 376);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(55, 26);
            this.LoginLabel.TabIndex = 8;
            this.LoginLabel.Text = "Войти";
            this.LoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoginLabel.Click += new System.EventHandler(this.LoginLabel_Click);
            this.LoginLabel.MouseEnter += new System.EventHandler(this.LoginLabel_MouseEnter);
            this.LoginLabel.MouseLeave += new System.EventHandler(this.LoginLabel_MouseLeave);
            // 
            // RegistrationLabel
            // 
            this.RegistrationLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistrationLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationLabel.ForeColor = System.Drawing.Color.Black;
            this.RegistrationLabel.Location = new System.Drawing.Point(86, 324);
            this.RegistrationLabel.Name = "RegistrationLabel";
            this.RegistrationLabel.Size = new System.Drawing.Size(166, 26);
            this.RegistrationLabel.TabIndex = 9;
            this.RegistrationLabel.Text = "Зарегистрироваться";
            this.RegistrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RegistrationLabel.Click += new System.EventHandler(this.RegistrationLabel_Click);
            this.RegistrationLabel.MouseEnter += new System.EventHandler(this.RegistrationLabel_MouseEnter);
            this.RegistrationLabel.MouseLeave += new System.EventHandler(this.RegistrationLabel_MouseLeave);
            // 
            // RiseAnimationTimer
            // 
            this.RiseAnimationTimer.Interval = 10;
            this.RiseAnimationTimer.Tick += new System.EventHandler(this.RiseAnimationTimer_Tick);
            // 
            // UsernameInputError
            // 
            this.UsernameInputError.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameInputError.ForeColor = System.Drawing.Color.DarkRed;
            this.UsernameInputError.Location = new System.Drawing.Point(66, 156);
            this.UsernameInputError.Name = "UsernameInputError";
            this.UsernameInputError.Size = new System.Drawing.Size(203, 28);
            this.UsernameInputError.TabIndex = 11;
            // 
            // PasswordInputError
            // 
            this.PasswordInputError.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordInputError.ForeColor = System.Drawing.Color.DarkRed;
            this.PasswordInputError.Location = new System.Drawing.Point(66, 231);
            this.PasswordInputError.Name = "PasswordInputError";
            this.PasswordInputError.Size = new System.Drawing.Size(203, 27);
            this.PasswordInputError.TabIndex = 12;
            // 
            // PasswordRepeatInputError
            // 
            this.PasswordRepeatInputError.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordRepeatInputError.ForeColor = System.Drawing.Color.DarkRed;
            this.PasswordRepeatInputError.Location = new System.Drawing.Point(66, 305);
            this.PasswordRepeatInputError.Name = "PasswordRepeatInputError";
            this.PasswordRepeatInputError.Size = new System.Drawing.Size(203, 27);
            this.PasswordRepeatInputError.TabIndex = 13;
            // 
            // RememberMe
            // 
            this.RememberMe.AutoSize = true;
            this.RememberMe.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RememberMe.Location = new System.Drawing.Point(109, 355);
            this.RememberMe.Name = "RememberMe";
            this.RememberMe.Size = new System.Drawing.Size(122, 19);
            this.RememberMe.TabIndex = 14;
            this.RememberMe.Text = "Запомнить меня";
            this.RememberMe.UseVisualStyleBackColor = true;
            this.RememberMe.CheckedChanged += new System.EventHandler(this.RememberMe_CheckedChanged);
            // 
            // DisappearanceAnimationTimer
            // 
            this.DisappearanceAnimationTimer.Interval = 10;
            this.DisappearanceAnimationTimer.Tick += new System.EventHandler(this.DisappearanceAnimationTimer_Tick);
            // 
            // HidePassword
            // 
            this.HidePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HidePassword.Image = global::Client.Properties.Resources.hiden;
            this.HidePassword.Location = new System.Drawing.Point(275, 206);
            this.HidePassword.Name = "HidePassword";
            this.HidePassword.Size = new System.Drawing.Size(22, 22);
            this.HidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HidePassword.TabIndex = 10;
            this.HidePassword.TabStop = false;
            this.HidePassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HidePassword_MouseClick);
            // 
            // BackButton
            // 
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = global::Client.Properties.Resources.BackArrow;
            this.BackButton.Location = new System.Drawing.Point(12, 33);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(35, 35);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackButton.TabIndex = 15;
            this.BackButton.TabStop = false;
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.RegistrationLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameInputError);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.HidePassword);
            this.Controls.Add(this.PasswordInputError);
            this.Controls.Add(this.RepeatPasswordLabel);
            this.Controls.Add(this.PasswordRepeatTB);
            this.Controls.Add(this.PasswordRepeatInputError);
            this.Controls.Add(this.RememberMe);
            this.Controls.Add(this.HaveAccLabel);
            this.Controls.Add(this.HelloLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Auth";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auth";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Auth_FormClosing);
            this.Shown += new System.EventHandler(this.Auth_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.HidePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HelloLabel;
        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label RepeatPasswordLabel;
        private System.Windows.Forms.TextBox PasswordRepeatTB;
        private System.Windows.Forms.Label HaveAccLabel;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label RegistrationLabel;
        private System.Windows.Forms.Timer RiseAnimationTimer;
        private System.Windows.Forms.PictureBox HidePassword;
        private System.Windows.Forms.Label UsernameInputError;
        private System.Windows.Forms.Label PasswordInputError;
        private System.Windows.Forms.Label PasswordRepeatInputError;
        private System.Windows.Forms.CheckBox RememberMe;
        private System.Windows.Forms.Timer DisappearanceAnimationTimer;
        private System.Windows.Forms.PictureBox BackButton;
    }
}