using Client.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using System.Reflection;

namespace Client
{
    public partial class ClientApp : Form
    {
        public string _username;

        private readonly Image _userPictureNotClicked = Resources.UserIco;
        private readonly Image _userPictureClicked = Resources.UserIco_Clicked;
        private readonly Image _mainMenuPicture = Resources.MainMenu;
        private readonly Image _mainMenuClickedPicture = Resources.MainMenuClicked;
        private readonly Image _writeMsgPicture = Resources.WriteMsg;
        private readonly Image _writeMsgClickedPicture = Resources.WriteMsgClicked;
        private readonly Image _receivedMessagesPicture = Resources.ReceivedMessagesImg;
        private readonly Image _receivedMessagesClickedPicture = Resources.ReceivedMessagesImgClicked;
        private readonly Image _sentMessagesPicture = Resources.SentMessagesImg;
        private readonly Image _sentMessagesClickedPicture = Resources.SentMessagesImgClicked;
        private readonly Image _draftMessagesPicture = Resources.DraftMessagesImg;
        private readonly Image _draftMessagesClickedPicture = Resources.DraftMessagesImgClicked;

        private readonly int _mainMenuClosedWidth = 40;
        private readonly int _mainMenuOpenedWidth = 140;
        private bool _mainMenuOpened = false;

        public string Username { get { return _username; } }

        public ClientApp()
        {
            InitializeComponent();
            MainMenu.Width = _mainMenuClosedWidth;
            Tabs.Appearance = TabAppearance.FlatButtons;
            Tabs.ItemSize = new Size(0, 1);
            Tabs.SizeMode = TabSizeMode.Fixed;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!Settings.Default.AutoLogin)
            {
                ShowAuth();
            }
            _username = Settings.Default.Login;
            UsernameLabel.Text = _username;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            await CheckConnection(true);
        }

        private async Task CheckConnection(bool isFormLoading = false, bool closeIfException = false)
        {
            try
            {
                await ServerController.TryConnect();
            }
            catch
            {
                MessageBox.Show("Сервер не отвечает, попробуйте позже", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (isFormLoading)
                    MessageBox.Show("Сообщения не были обновлены, так как сервер не отвечает", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (closeIfException)
                    Close();
            }
        }

        private void UserPicture_Click(object sender, EventArgs e)
        {
            if (UserPanel.Visible)
            {
                UserPanel.Visible = false;
                UserPicture.Image = _userPictureNotClicked;
            }
            else
            {
                UserPanel.Visible = true;
                UserPanel.BringToFront();
                UserPicture.Image = _userPictureClicked;
            }
        }

        private void SignOutLabel_MouseEnter(object sender, EventArgs e)
        {
            SignOutLabel.ForeColor = Color.Blue;
        }

        private void SignOutLabel_MouseLeave(object sender, EventArgs e)
        {
            SignOutLabel.ForeColor = Color.Black;
        }

        private void ShowAuth()
        {
            Hide();
            Auth auth = new Auth();
            DialogResult = auth.ShowDialog();
            if (DialogResult == DialogResult.No)
                Close();
            else
                UsernameLabel.Text = Settings.Default.Login;
        }

        private void SignOutLabel_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            ShowAuth();
        }

        private async void UsernameLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(UsernameLabel.Text);
            string username = UsernameLabel.Text;
            UsernameLabel.Text = "Скопировано!";
            await Task.Delay(500);
            UsernameLabel.Text = username;
        }

        private void UsernameLabel_MouseLeave(object sender, EventArgs e)
        {
            UsernameLabel.ForeColor = Color.Black;
        }

        private void UsernameLabel_MouseEnter(object sender, EventArgs e)
        {
            UsernameLabel.ForeColor = Color.Gray;
        }

        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            if (_mainMenuOpened && !CloseMainMenuAnim.Enabled && !OpenMainMenuAnim.Enabled)
            {
                CloseMainMenuAnim.Start();
                _mainMenuOpened = false;
            }
            else if (!_mainMenuOpened && !OpenMainMenuAnim.Enabled && !CloseMainMenuAnim.Enabled)
            {
                OpenMainMenuAnim.Start();
                _mainMenuOpened = true;
            }
        }

        private void OpenMainMenuAnim_Tick(object sender, EventArgs e)
        {
            MainMenu.Width += 10;
            if (MainMenu.Width == _mainMenuOpenedWidth)
                OpenMainMenuAnim.Stop();
        }

        private void CloseMainMenuAnim_Tick(object sender, EventArgs e)
        {
            MainMenu.Width -= 10;
            if (MainMenu.Width == _mainMenuClosedWidth)
                CloseMainMenuAnim.Stop();
        }

        private void MainMenuButton_MouseEnter(object sender, EventArgs e)
        {
            MainMenuButton.Image = _mainMenuClickedPicture;
        }

        private void MainMenuButton_MouseLeave(object sender, EventArgs e)
        {
            MainMenuButton.Image = _mainMenuPicture;
        }

        private void WriteMsgButton_MouseEnter(object sender, EventArgs e)
        {
            WriteMsgButton.Image = _writeMsgClickedPicture;
        }

        private void WriteMsgButton_MouseLeave(object sender, EventArgs e)
        {
            WriteMsgButton.Image = _writeMsgPicture;
        }

        private void WriteMsgButton_Click(object sender, EventArgs e)
        {
            MessageWriter mw = new MessageWriter(_username)
            {
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(Width - 100, Height - 100)
            };
            mw.ShowDialog(this);
        }

        private void ReceivedMessagesButton_MouseEnter(object sender, EventArgs e)
        {
            ReceivedMessagesButton.Image = _receivedMessagesClickedPicture;
        }

        private void ReceivedMessagesButton_MouseLeave(object sender, EventArgs e)
        {
            ReceivedMessagesButton.Image = _receivedMessagesPicture;
        }

        private void SentMessagesButton_MouseEnter(object sender, EventArgs e)
        {
            SentMessagesButton.Image = _sentMessagesClickedPicture;
        }

        private void SentMessagesButton_MouseLeave(object sender, EventArgs e)
        {
            SentMessagesButton.Image = _sentMessagesPicture;
        }

        private void DraftMessagesButton_MouseEnter(object sender, EventArgs e)
        {
            DraftMessagesButton.Image = _draftMessagesClickedPicture;
        }

        private void DraftMessagesButton_MouseLeave(object sender, EventArgs e)
        {
            DraftMessagesButton.Image = _draftMessagesPicture;
        }
    }
}
