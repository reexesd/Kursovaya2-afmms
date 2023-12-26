using Client.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using NamedPipeLib;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections.Generic;
using Client;
using System.IO;

namespace Client
{
    public partial class ClientApp : Form
    {
        private readonly string _serverAdress;

        private NamedPipeClient _client;

        private string _username;

        private Color _colorOfControlPanel;

        private List<Message> _sentMessagesList = new List<Message>();
        private readonly Panel _sentMessagesPanel = new Panel() { BackColor = Color.White, Location = new Point(200, 200) };

        private List<Message> _receivedMessagesList = new List<Message>();
        private readonly Panel _receivedMessagesPanel = new Panel() { BackColor = Color.White, Location = new Point(200, 200) };

        private List<Message> _draftMessagesList = new List<Message>();
        private readonly Panel _draftMessagesPanel = new Panel() { BackColor = Color.White, Location = new Point(200, 200) };

        private readonly List<MailControl> _selectedMessages = new List<MailControl>();

        private MailControl _openedMail;

        private readonly Image _userPictureNotClicked = Resources.UserIco;
        private readonly Image _userPictureClicked = Resources.UserIco_Clicked;
        private readonly Image _mainMenuPicture = Resources.MainMenu;
        private readonly Image _mainMenuClickedPicture = Resources.MainMenuClicked;
        private readonly Image _writeMsgPicture = Resources.WriteMsg;
        private readonly Image _writeMsgClickedPicture = Resources.WriteMsgClicked;

        private bool _receivedMessagesIsOpen = true;
        private readonly Image _receivedMessagesPicture = Resources.ReceivedMessagesImg;
        private readonly Image _receivedMessagesClickedPicture = Resources.ReceivedMessagesImgClicked;

        private bool _sentMessagesIsOpen = false;
        private readonly Image _sentMessagesPicture = Resources.SentMessagesImg;
        private readonly Image _sentMessagesClickedPicture = Resources.SentMessagesImgClicked;

        private bool _draftMessagesIsOpen = false;
        private readonly Image _draftMessagesPicture = Resources.DraftMessagesImg;
        private readonly Image _draftMessagesClickedPicture = Resources.DraftMessagesImgClicked;

        private readonly Image _backArrow = Resources.GrayArrow;
        private readonly Image _backArrowClicked = Resources.BackArrow;

        private readonly Image _deleteButtonImg = Resources.Trash;
        private readonly Image _deleteButtonClickedImg = Resources.TrashClicked;

        private readonly int _mainMenuClosedWidth = 40;
        private readonly int _mainMenuOpenedWidth = 140;
        private bool _mainMenuOpened = false;

        public string Username { get { return _username; } }

        public ClientApp()
        {
            InitializeComponent();

            if (!File.Exists(@"ServerData.txt"))
            {
                File.Create(@"ServerData.txt").Dispose();
                File.WriteAllText(@"ServerData.txt", ".");
            }

            _serverAdress = File.ReadAllText(@"ServerData.txt");

            if (!Settings.Default.AutoLogin)
            {
                ShowAuth();
            }
            else
                Auth_LogInSuccessed(null, null);

            MainMenu.Width = _mainMenuClosedWidth;
        }

        private void InitMessagePages()
        {
            _sentMessagesPanel.Dock = DockStyle.Fill;
            Controls.Add(_sentMessagesPanel);
            _sentMessagesPanel.Hide();

            _draftMessagesPanel.Dock = DockStyle.Fill;
            Controls.Add(_draftMessagesPanel);
            _draftMessagesPanel.Hide();

            _receivedMessagesPanel.Dock = DockStyle.Fill;
            Controls.Add(_receivedMessagesPanel);
            _receivedMessagesPanel.BringToFront();

            if (_client.IsConnected)
            {
                _sentMessagesList = JsonConvert.DeserializeObject<List<Message>>(_client.SendRequest($"Get Sent Messages:{_username}"));

                _receivedMessagesList = JsonConvert.DeserializeObject<List<Message>>(_client.SendRequest($"Get Received Messages:{_username}"));

                _draftMessagesList = JsonConvert.DeserializeObject<List<Message>>(_client.SendRequest($"Get Draft Messages:{_username}"));
            }

            foreach (Message msg in _sentMessagesList)
            {
                MailControl mail = new MailControl(msg) { Dock = DockStyle.Top };
                mail.MailOpened += OnMailOpened;
                mail.MailClosed += OnMailClosed;
                mail.MailSelected += OnMailSelected;
                _sentMessagesPanel.Controls.Add(mail);
            }

            foreach (Message msg in _receivedMessagesList)
            {
                MailControl mail = new MailControl(msg) { Dock = DockStyle.Top };
                mail.MailOpened += OnMailOpened;
                mail.MailClosed += OnMailClosed;
                mail.MailSelected += OnMailSelected;
                _receivedMessagesPanel.Controls.Add(mail);
            }

            foreach (Message msg in _draftMessagesList)
            {
                MailControl mail = new MailControl(msg) { Dock = DockStyle.Top };
                mail.MailOpened += OnDraftMailOpened;
                mail.MailClosed += OnMailClosed;
                mail.MailSelected += OnMailSelected;
                _draftMessagesPanel.Controls.Add(mail);
            }

            UpdateMessagesTimer.Start();
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

        private void OnDraftMailOpened(object sender, MailControl mail)
        {
            OnMailOpened(sender, mail);
            MessageWriter mw = new MessageWriter(mail.Message, _username, _client);
            mw.Show();
        }

        private void OnMailOpened(object sender, MailControl mail)
        {
            _openedMail = mail;
            _colorOfControlPanel = ControlPanel.BackColor;
            ControlPanel.BackColor = Color.White;
            ControlLabel.Visible = false;
            BackButton.Visible = true;
            DeleteButton.Visible = true;
            UpdateMessagesTimer.Stop();
            SelectAllCB.Hide();
            DeleteSelectedButton.Hide();

            if (!mail.IsWatched)
                MarkMessageAsRead(mail.Message);
        }

        private void OnMailClosed(object sender, MailControl mail)
        {
            _openedMail = null;
            ControlLabel.Visible = true;
            BackButton.Visible = false;
            DeleteButton.Visible = false;
            ControlPanel.BackColor = _colorOfControlPanel;
            UpdateMessagesTimer.Start();
        }

        private void OnMailSelected(object sender, MailControl mail)
        {
            if (mail.IsSelected)
                _selectedMessages.Add(mail);
            else
                _selectedMessages.Remove(mail);

            if(_selectedMessages.Count > 0)
            {
                if(!SelectAllCB.Visible)
                    SelectAllCB.Show();

                if(!DeleteSelectedButton.Visible)
                    DeleteSelectedButton.Show();
            }
            else
            {
                SelectAllCB.Hide();
                DeleteSelectedButton.Hide();
            }
        }

        private async Task TryConnect(bool isFormLoading = false, bool closeIfException = false, bool showMsgBox = true)
        {
            try
            {
                await _client.ConnectAsync(3000);
            }
            catch
            {
                if (showMsgBox)
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
            _client = new NamedPipeClient(_serverAdress, "Mail Service", 1);
            Auth auth = new Auth(_client);
            auth.LogInSuccessed += Auth_LogInSuccessed;
            DialogResult = auth.ShowDialog();
            if (DialogResult == DialogResult.No)
                Close();
            else
                Show();
        }

        private async void Auth_LogInSuccessed(object sender, string username)
        {
            if (username == null)
                username = Settings.Default.Login;

            _username = username.ToLower();
            UsernameLabel.Text = _username;

            if (_client == null)
                _client = new NamedPipeClient(_serverAdress, "Mail Service", 1);

            if (!_client.IsConnected)
                await TryConnect(true);

            InitMessagePages();
            OpenMessages(Message.MessageType.Received);
            UpdateMessagesTimer.Start();
        }

        private void DeleteAllMsg()
        {
            _receivedMessagesList = new List<Message>();
            _sentMessagesList = new List<Message>();
            _draftMessagesList = new List<Message>();

            _sentMessagesPanel.Controls.Clear();
            _receivedMessagesPanel.Controls.Clear();
            _draftMessagesPanel.Controls.Clear();
        }

        private void SignOutLabel_Click(object sender, EventArgs e)
        {
            UserPicture_Click(null, null);
            UpdateMessagesTimer.Stop();
            Settings.Default.Reset();
            DeleteAllMsg();
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
            MessageWriter mw = new MessageWriter(_username, _client)
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
            if (!_receivedMessagesIsOpen)
                ReceivedMessagesButton.Image = _receivedMessagesPicture;
        }

        private void SentMessagesButton_MouseEnter(object sender, EventArgs e)
        {
            SentMessagesButton.Image = _sentMessagesClickedPicture;
        }

        private void SentMessagesButton_MouseLeave(object sender, EventArgs e)
        {
            if (!_sentMessagesIsOpen)
                SentMessagesButton.Image = _sentMessagesPicture;
        }

        private void DraftMessagesButton_MouseEnter(object sender, EventArgs e)
        {
            DraftMessagesButton.Image = _draftMessagesClickedPicture;
        }

        private void DraftMessagesButton_MouseLeave(object sender, EventArgs e)
        {
            if (!_draftMessagesIsOpen)
                DraftMessagesButton.Image = _draftMessagesPicture;
        }

        private void OpenMessages(Message.MessageType type)
        {
            _openedMail?.CloseTheMessage();

            foreach(MailControl mail in MessagePage.Controls)
                mail.IsSelected = false;

            switch (type)
            {
                case Message.MessageType.Sent:

                    SentMessagesButton.Image = _sentMessagesClickedPicture;
                    ReceivedMessagesButton.Image = _receivedMessagesPicture;
                    DraftMessagesButton.Image = _draftMessagesPicture;

                    _sentMessagesIsOpen = true;
                    _receivedMessagesIsOpen = false;
                    _draftMessagesIsOpen = false;

                    _sentMessagesPanel.Show();
                    _receivedMessagesPanel.Hide();
                    _draftMessagesPanel.Hide();
                    _sentMessagesPanel.BringToFront();

                    ControlLabel.Text = "Отправленные";

                    ControlPanel.BackColor = Color.FromArgb(205, 72, 72);

                    break;

                case Message.MessageType.Received:

                    ReceivedMessagesButton.Image = _receivedMessagesClickedPicture;
                    SentMessagesButton.Image = _sentMessagesPicture;
                    DraftMessagesButton.Image = _draftMessagesPicture;

                    _sentMessagesIsOpen = false;
                    _receivedMessagesIsOpen = true;
                    _draftMessagesIsOpen = false;

                    _sentMessagesPanel.Hide();
                    _receivedMessagesPanel.Show();
                    _receivedMessagesPanel.BringToFront();
                    _draftMessagesPanel.Hide();

                    ControlLabel.Text = "Полученные";

                    ControlPanel.BackColor = Color.FromArgb(0, 237, 67);

                    break;

                case Message.MessageType.Draft:

                    DraftMessagesButton.Image = _draftMessagesClickedPicture;
                    SentMessagesButton.Image = _sentMessagesPicture;
                    ReceivedMessagesButton.Image = _receivedMessagesPicture;

                    _sentMessagesIsOpen = false;
                    _receivedMessagesIsOpen = false;
                    _draftMessagesIsOpen = true;

                    _sentMessagesPanel.Hide();
                    _receivedMessagesPanel.Hide();
                    _draftMessagesPanel.Show();
                    _draftMessagesPanel.BringToFront();

                    ControlLabel.Text = "Черновики";

                    ControlPanel.BackColor = Color.FromArgb(65, 105, 225);

                    break;
            }
        }

        private void ReceivedMessagesButton_Click(object sender, EventArgs e)
        {
            OpenMessages(Message.MessageType.Received);
        }

        private void SentMessagesButton_Click(object sender, EventArgs e)
        {
            OpenMessages(Message.MessageType.Sent);
        }

        private void DraftMessagesButton_Click(object sender, EventArgs e)
        {
            OpenMessages(Message.MessageType.Draft);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _openedMail.CloseTheMessage();
        }

        private void BackButton_MouseEnter(object sender, EventArgs e)
        {
            BackButton.Image = _backArrowClicked;
        }

        private void BackButton_MouseLeave(object sender, EventArgs e)
        {
            BackButton.Image = _backArrow;
        }

        private void DeleteButton_MouseEnter(object sender, EventArgs e)
        {
            DeleteButton.Image = _deleteButtonClickedImg;
        }

        private void DeleteButton_MouseLeave(object sender, EventArgs e)
        {
            DeleteButton.Image = _deleteButtonImg;
        }

        private async void UpdateMessagesTimer_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => { UpdateMsgList(Message.MessageType.Sent); });
            await Task.Run(() => { UpdateMsgList(Message.MessageType.Received); });
            await Task.Run(() => { UpdateMsgList(Message.MessageType.Draft); });
        }

        private async void UpdateMsgList(Message.MessageType type, bool updateAllList = false)
        {
            if (_client.IsConnected)
            {
                switch (type)
                {
                    case Message.MessageType.Sent:
                        {
                            List<Message> updatedSentMessages;
                            try
                            {
                                updatedSentMessages = JsonConvert.DeserializeObject<List<Message>>(_client.SendRequest($"Get Sent Messages:{_username}"));
                            }
                            catch
                            {
                                await TryConnect(showMsgBox: false);
                                return;
                            }

                            bool isListChanged = false;

                            if (!updateAllList)
                            {
                                foreach (Message message in updatedSentMessages)
                                {
                                    if (!_sentMessagesList.Contains(message))
                                    {
                                        _sentMessagesList.Add(message);
                                        isListChanged = true;
                                    }
                                }
                            }
                            else
                                _sentMessagesList = updatedSentMessages;

                            if (isListChanged || updateAllList)
                                await RebuildMessagePage(Message.MessageType.Sent, _sentMessagesPanel);
                        }
                        break;

                    case Message.MessageType.Received:
                        {
                            List<Message> updatedReceivedMessages;
                            try
                            {
                                updatedReceivedMessages = JsonConvert.DeserializeObject<List<Message>>(_client.SendRequest($"Get Received Messages:{_username}"));
                            }
                            catch
                            {
                                await TryConnect(showMsgBox: false);
                                return;
                            }

                            bool isListChanged = false;

                            if (!updateAllList)
                            {
                                foreach (Message message in updatedReceivedMessages)
                                {
                                    if (!_receivedMessagesList.Contains(message))
                                    {
                                        _receivedMessagesList.Add(message);
                                        isListChanged = true;
                                    }
                                }
                            }
                            else
                                _receivedMessagesList = updatedReceivedMessages;

                            if (isListChanged || updateAllList)
                                await RebuildMessagePage(Message.MessageType.Received, _receivedMessagesPanel);
                        }
                        break;

                    case Message.MessageType.Draft:
                        {
                            List<Message> updatedDraftMessages;
                            try
                            {
                                updatedDraftMessages = JsonConvert.DeserializeObject<List<Message>>(_client.SendRequest($"Get Draft Messages:{_username}"));
                            }
                            catch
                            {
                                await TryConnect(showMsgBox: false);
                                return;
                            }

                            bool isListChanged = false;

                            if (!updateAllList)
                            {
                                foreach (Message message in updatedDraftMessages)
                                {
                                    if (!_draftMessagesList.Contains(message))
                                    {
                                        _draftMessagesList.Add(message);
                                        isListChanged = true;
                                    }
                                }
                            }
                            else
                            {
                                _draftMessagesList = updatedDraftMessages;
                            }

                            if (isListChanged || updateAllList)
                                await RebuildMessagePage(Message.MessageType.Draft, _draftMessagesPanel);
                        }
                        break;
                }
            }
            else
            {
                await TryConnect(showMsgBox: false);
            }
        }

        private async Task RebuildMessagePage(Message.MessageType type, Panel messagePanel)
        {
            await Task.Run(() =>
            {
                messagePanel.Invoke(new Action(() =>
                {
                    messagePanel.Controls.Clear();
                    if (type == Message.MessageType.Sent)
                        foreach (Message msg in _sentMessagesList)
                        {
                            MailControl mail = new MailControl(msg) { Dock = DockStyle.Top };
                            mail.MailOpened += OnMailOpened;
                            mail.MailClosed += OnMailClosed;
                            mail.MailSelected += OnMailSelected;
                            messagePanel.Controls.Add(mail);
                        }
                    else if (type == Message.MessageType.Received)
                        foreach (Message msg in _receivedMessagesList)
                        {
                            MailControl mail = new MailControl(msg) { Dock = DockStyle.Top };
                            mail.MailOpened += OnMailOpened;
                            mail.MailClosed += OnMailClosed;
                            mail.MailSelected += OnMailSelected;
                            messagePanel.Controls.Add(mail);
                        }
                    else
                        foreach (Message msg in _draftMessagesList)
                        {
                            MailControl mail = new MailControl(msg) { Dock = DockStyle.Top };
                            mail.MailOpened += OnDraftMailOpened;
                            mail.MailClosed += OnMailClosed;
                            mail.MailSelected += OnMailSelected;
                            messagePanel.Controls.Add(mail);
                        }
                }));
            });
        }

        private async void MarkMessageAsRead(Message message)
        {
            try
            {
                _client.SendRequest($"Set Message Read:{_username}:{message.Id}:{(int)message.Type}");
            }
            catch
            {
                await TryConnect(showMsgBox: false);
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            List<Message> updatedMessages = new List<Message>();
            Message.MessageType type = _openedMail.Message.Type;

            try
            {
                _client.SendRequest($"Delete Message:{_username}:{_openedMail.Message.Id}:{_openedMail.Message.Type}");
                _openedMail.CloseTheMessage();

                await Task.Run(() => UpdateMsgList(type, true));
            }
            catch
            {
                await TryConnect(showMsgBox: false);
            }
        }

        private void DeleteSelectedButton_MouseEnter(object sender, EventArgs e)
        {
            DeleteSelectedButton.Image = _deleteButtonClickedImg;
        }

        private void DeleteSelectedButton_MouseLeave(object sender, EventArgs e)
        {
            DeleteSelectedButton.Image = _deleteButtonImg;
        }

        private void SelectAllCB_CheckedChanged(object sender, EventArgs e)
        {
            if(SelectAllCB.Checked)
            {
                foreach(MailControl mail in MessagePage.Controls)
                    mail.IsSelected = true;
            }
            else
            {
                foreach (MailControl mail in MessagePage.Controls)
                    mail.IsSelected = false;
            }
        }

        private Panel MessagePage
        {
            get 
            {
                if (_sentMessagesPanel.Visible)
                    return _sentMessagesPanel;
                else if (_receivedMessagesPanel.Visible)
                    return _receivedMessagesPanel;
                else
                    return _draftMessagesPanel;
            }
        }


        private Message.MessageType MessagePageType
        {
            get
            {
                if (MessagePage == _sentMessagesPanel)
                    return Message.MessageType.Sent;
                else if (MessagePage == _receivedMessagesPanel)
                    return Message.MessageType.Received;
                else
                    return Message.MessageType.Draft;
            }
        }

        private async void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            foreach(MailControl mail in _selectedMessages)
            {
                try
                {
                    _client.SendRequest($"Delete Message:{_username}:{mail.Message.Id}:{mail.Message.Type}");
                }
                catch
                {
                    await TryConnect(showMsgBox: false);
                }
            }
            await Task.Run(() => UpdateMsgList(MessagePageType,true));
            _selectedMessages.Clear();
            SelectAllCB.Hide();
            DeleteSelectedButton.Hide();
        }
    }
}
