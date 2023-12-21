using Client.Properties;
using System.IO.Pipes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using NamedPipeLib;

namespace Client
{
    public partial class Auth : Form
    {
        private const string USERNAME_EXMPL = "username@afmms.ru";

        private readonly NamedPipeClient _client;

        private readonly Image _loadingImg = Resources.Loading;

        private readonly Image _hidenPassword = Resources.hiden;

        private readonly Image _notHidenPassword = Resources.not_hiden;

        private List<char> _validSymbols;
        private bool _rememberMe = false;

        public event EventHandler<string> LogInSuccessed;

        public Auth(NamedPipeClient client)
        {
            _client = client;
            InitializeComponent();
            RegisterValidSymbols();
            SetOpacityOfControls(255);
            _ = Connect();
        }

        private async Task Connect(bool showMsg = true)
        {
            try
            {
                await _client.ConnectAsync(1);
            }
            catch 
            {
                if(showMsg)
                    MessageBox.Show("Сервер не отвечает, попробуйте позже", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterValidSymbols()
        {
            _validSymbols = new List<char>();
            for (int i = 48; i <= 57; i++)
                _validSymbols.Add((char)i);
            for (int i = 64; i <= 90; i++)
                _validSymbols.Add((char)i);
            for (int i = 97; i <= 122; i++)
                _validSymbols.Add((char)i);
            _validSymbols.Add('.');
            _validSymbols.Add('_');
            _validSymbols.Add('-');
        }

        private void LoginLabel_MouseEnter(object sender, EventArgs e)
        {
            LoginLabel.ForeColor = Color.RoyalBlue;
        }

        private void LoginLabel_MouseLeave(object sender, EventArgs e)
        {
            LoginLabel.ForeColor = Color.Black;
        }

        private void SetExmpl()
        {
            if (UsernameTB.Text == string.Empty)
            {
                UsernameTB.ForeColor = Color.Gray;
                UsernameTB.Text = USERNAME_EXMPL;
            }
        }

        private void UsernameTB_Leave(object sender, EventArgs e)
        {
            SetExmpl();
        }

        private void UsernameTB_Enter(object sender, EventArgs e)
        {
            if (UsernameTB.Text == USERNAME_EXMPL)
            {
                UsernameTB.ForeColor = Color.Black;
                UsernameTB.Text = "";
            }
        }

        private void RegistrationLabel_MouseEnter(object sender, EventArgs e)
        {
            RegistrationLabel.ForeColor = Color.RoyalBlue;
        }

        private void RegistrationLabel_MouseLeave(object sender, EventArgs e)
        {
            RegistrationLabel.ForeColor = Color.Black;
        }

        private void Auth_Shown(object sender, EventArgs e)
        {
            RiseAnimationTimer.Start();
        }

        private int _opacity = 255;

        private void EmptyFieldsCheck()
        {
            if (PasswordTB.Text == string.Empty || PasswordTB.Text.Length < 4)
            {
                PasswordInputError.Text = "Пароль должен содержать хотя бы 4 символа";
                return;
            }

            if (UsernameTB.Text == string.Empty || UsernameTB.Text == USERNAME_EXMPL)
            {
                UsernameInputError.Text = "Поле не может быть пустым!";
                return;
            }

            if (PasswordRepeatTB.Text == string.Empty)
            {
                PasswordRepeatInputError.Text = "Поле не может быть пустым!";
                return;
            }
        }

        private bool _registrationButtonClicked = false;
        private async void RegistrationLabel_Click(object sender, EventArgs e)
        {
            if (!_client.IsConnected)
                await Connect(false);

            UsernameTB_TextChanged(null, new EventArgs());

            EmptyFieldsCheck();

            if (UsernameInputError.Text != string.Empty || PasswordInputError.Text != string.Empty || PasswordRepeatInputError.Text != string.Empty)
                return;

            string username = UsernameTB.Text.ToLower();
            string password = PasswordTB.Text;
            RegisterNewUser(username, password);
        }

        private PictureBox _loading;
        private void SetLoadingScreen()
        {
            _loading = new PictureBox();
            Controls.Add(_loading);
            _loading.BringToFront();
            _loading.SizeMode = PictureBoxSizeMode.StretchImage;
            _loading.Dock = DockStyle.Fill;
            _loading.Image = _loadingImg;
        }

        private async void RegisterNewUser(string username, string password)
        {
            SetLoadingScreen();

            try
            {
                _client.SendRequest($"Register New User:{username}:{password}");
            }
            catch 
            {
                await Task.Delay(3000);
                await Connect(true);
                return;
            }
            finally { _loading.Dispose(); }
            Settings.Default.AutoLogin = _rememberMe;
            Settings.Default.Login = username;
            Settings.Default.Password = password;
            Settings.Default.Save(); 
            
            _registrationButtonClicked = true;
            Close();    
        }

        private bool _passwordIsHiden = true;
        private void HidePassword_MouseClick(object sender, MouseEventArgs e)
        {
            _passwordIsHiden = !_passwordIsHiden;
            if (_passwordIsHiden)
            {
                HidePassword.Image = _hidenPassword;
                PasswordTB.PasswordChar = '•';
            }
            else
            {
                HidePassword.Image = _notHidenPassword;
                PasswordTB.PasswordChar = '\0';
            }
        }

        private bool IsValidFirstSymbol(char symbol)
        {
            return (symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z');
        }

        private bool IsValidUsername(string username)
        {
            const string url = "@afmms.ru";
            int index = username.Length - url.Length;
            if (index >= 0 && username.Substring(index).ToLower() == url)
            {
                for (int i = 0; i < index; i++)
                    if (username[i] == '@') return false;
                return true;
            }
            return false;
        }

        private bool HasInvalidSymbol(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!_validSymbols.Contains(text[i])) return true;
            }
            return false;
        }

        private void UsernameTB_TextChanged(object sender, EventArgs e)
        {
            char firstSymbol;
            if (UsernameTB.Text != string.Empty)
            {
                firstSymbol = UsernameTB.Text[0];

                if (!IsValidFirstSymbol(firstSymbol))
                {
                    UsernameInputError.Text = "Имя пользователя должно начинаться с латинской буквы";
                    return;
                }

                if (HasInvalidSymbol(UsernameTB.Text))
                {
                    UsernameInputError.Text = "Введен некорректный символ. Допускаются (A-Z), (a-z), ., -, _.";
                    return;
                }

                if (!IsValidUsername(UsernameTB.Text))
                {
                    UsernameInputError.Text = "Адрес почтового ящика введен в неверном формате";
                    return;
                }

                bool isUserExists = false;

                try
                {
                    if(_client.IsConnected && _client.SendRequest($"Is User Exists:{UsernameTB.Text}") == "T")
                        isUserExists = true;
                }
                catch
                {
                    UsernameInputError.Text = string.Empty;
                    return;
                }


                if (_isRegistrationField && isUserExists)
                {
                    UsernameInputError.Text = "Такой пользователь уже существует";
                    return;
                }
                UsernameInputError.Text = string.Empty;
            }
        }

        private void PasswordTB_TextChanged(object sender, EventArgs e)
        {
            if (HasInvalidSymbol(PasswordTB.Text))
            {
                PasswordInputError.Text = "Введен некорректный символ. Допускаются (A-Z), (a-z), ., -, _.";
                return;
            }
            PasswordInputError.Text = string.Empty;
        }

        private void PasswordRepeatTB_TextChanged(object sender, EventArgs e)
        {
            if (PasswordTB.Text != PasswordRepeatTB.Text)
            {
                PasswordRepeatInputError.Text = "Пароли не совпадают";
                return;
            }
            PasswordRepeatInputError.Text = string.Empty;
        }

        private void RememberMe_CheckedChanged(object sender, EventArgs e)
        {
            _rememberMe = RememberMe.Checked;
        }

        private bool _isRegistrationField = true;
        private bool _loginButtonClicked = false;
        private async void LoginLabel_Click(object sender, EventArgs e)
        {
            if (_isRegistrationField)
            {
                SwitchToLoginScreen();
                return;
            }

            string username = UsernameTB.Text.ToLower();
            string password = PasswordTB.Text;

            SetLoadingScreen();

            if (!_client.IsConnected)
                await Connect(false);

            bool isLoginAccess;

            try
            {
                isLoginAccess = _client.SendRequest($"Try Login:{username}:{password}") == "T";
            }
            catch
            {
                await Task.Delay(3000);

                isLoginAccess = false;

                await Connect(true);

                return;
            }
            finally { _loading?.Dispose(); }

            if (isLoginAccess)
            {
                Settings.Default.AutoLogin = _rememberMe;
                Settings.Default.Login = username;
                Settings.Default.Password = password;
                Settings.Default.Save();
                _loginButtonClicked = true;
                Close();
            }
            else
                UsernameInputError.Text = "Неверное имя пользователя или пароль";
        }

        private async void SwitchToLoginScreen()
        {
            this.ActiveControl = null;
            UsernameInputError.Text = string.Empty;
            PasswordInputError.Text = string.Empty;
            PasswordRepeatInputError.Text = string.Empty;
            UsernameTB.Text = string.Empty;
            _isRegistrationField = false;
            PasswordTB.Text = string.Empty;
            PasswordRepeatTB.Text = string.Empty;
            DisappearanceAnimationTimer.Start();
            SetExmpl();
            BackButton.Enabled = false;

            await Task.Delay(500);

            HelloLabel.Text = "Войдите в аккаунт";
            PasswordLabel.Text = "Пароль";
            RepeatPasswordLabel.Visible = false;
            PasswordRepeatTB.Visible = false;
            RegistrationLabel.Visible = false;
            HaveAccLabel.Visible = false;
            BackButton.Visible = true;
            LoginLabel.Location = new Point(140, 324);
            RiseAnimationTimer.Start();

            await Task.Delay(400);

            BackButton.Enabled = true;
        }

        private async void SwitchToRegistrationScreen()
        {
            this.ActiveControl = null;
            UsernameInputError.Text = string.Empty;
            PasswordInputError.Text = string.Empty;
            PasswordRepeatInputError.Text = string.Empty;
            UsernameTB.Text = string.Empty;
            _isRegistrationField = true;
            LoginLabel.Enabled = false;
            PasswordTB.Text = string.Empty;
            PasswordRepeatTB.Text = string.Empty;
            SetExmpl();
            DisappearanceAnimationTimer.Start();

            await Task.Delay(500);

            HelloLabel.Text = "Для использования\r\nприложения необходимо\r\nзарегистрироваться";
            PasswordLabel.Text = "Придумайте пароль";
            RepeatPasswordLabel.Visible = true;
            PasswordRepeatTB.Visible = true;
            RegistrationLabel.Visible = true;
            HaveAccLabel.Visible = true;
            BackButton.Visible = false;
            LoginLabel.Location = new Point(214, 376);
            RiseAnimationTimer.Start();

            await Task.Delay(400);

            LoginLabel.Enabled = true;
        }

        private void DisappearanceAnimationTimer_Tick(object sender, EventArgs e)
        {
            _opacity += 10;
            if (_opacity > 255)
            {
                DisappearanceAnimationTimer.Stop();
                _opacity = 255;
                return;
            }
            SetOpacityOfControls(_opacity);
        }
        private void RiseAnimationTimer_Tick(object sender, EventArgs e)
        {
            _opacity -= 10;
            if (_opacity < 0)
            {
                RiseAnimationTimer.Stop();
                _opacity = 0;
                return;
            }
            SetOpacityOfControls(_opacity);
        }

        private void SetOpacityOfControls(int opacity) 
        {
            HelloLabel.ForeColor = Color.FromArgb(opacity, opacity, opacity);
            HaveAccLabel.ForeColor = Color.FromArgb(opacity, opacity, opacity);
            LoginLabel.ForeColor = Color.FromArgb(opacity, opacity, opacity);
            RegistrationLabel.ForeColor = Color.FromArgb(opacity, opacity, opacity);
            RememberMe.ForeColor = Color.FromArgb(opacity, opacity, opacity);
            UsernameLabel.ForeColor = Color.FromArgb(opacity, opacity, opacity);
            PasswordLabel.ForeColor = Color.FromArgb(opacity, opacity, opacity);
            RepeatPasswordLabel.ForeColor = Color.FromArgb(opacity, opacity, opacity);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            SwitchToRegistrationScreen();
        }

        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_registrationButtonClicked || _loginButtonClicked)
            {
                DialogResult = DialogResult.Yes;
                LogInSuccessed?.Invoke(null, UsernameTB.Text);
            }
            else
                DialogResult = DialogResult.No;
        }
    }
}
