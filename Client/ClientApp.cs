﻿using Client.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientApp : Form
    {
        private readonly Image _userPictureNotClicked = Resources.UserIco;
        private readonly Image _userPictureClicked = Resources.UserIco_Clicked;
        private readonly Image _mainMenuPicture = Resources.MainMenu;
        private readonly Image _mainMenuClickedPicture = Resources.MainMenuClicked;
        private readonly Image _writeMsgPicture = Resources.WriteMsg;
        private readonly Image _writeMsgClickedPicture = Resources.WriteMsgClicked;
        private readonly int _mainMenuClosedWidth = 40;
        private readonly int _mainMenuOpenedWidth = 140;
        private bool _mainMenuOpened = false;

        public ClientApp()
        {
            InitializeComponent();
            MainMenu.Width = _mainMenuClosedWidth;
            UsernameLabel.Text = Settings.Default.Login;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Settings.Default.AutoLogin)
            {
                ShowAuth();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
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
            MainMenu.Width += 5;
            if (MainMenu.Width == _mainMenuOpenedWidth)
                OpenMainMenuAnim.Stop();
        }

        private void CloseMainMenuAnim_Tick(object sender, EventArgs e)
        {
            MainMenu.Width -= 5;
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
            MessageWriter mw = new MessageWriter
            {
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(Width - 100, Height - 100)
            };
            mw.ShowDialog(this);
        }
    }
}
