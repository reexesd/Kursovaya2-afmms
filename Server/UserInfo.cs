using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;
using Server;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.ComponentModel;
using System.Runtime.Remoting.Channels;

namespace Server
{
    internal class UserInfo : Panel
    {
        private Label _name;
        private Label _countOfMessages;
        private CustomizedProgressBar _progressBar;
        private int _countOfMessagesInt = 0;

        public new string Name
        {
            get 
            { 
                string name = _name.Text;
                name = name.Remove(0, 5);
                return name;
            }
        }

        public UserInfo()
        {
            InitNewUser();
        }

        public UserInfo(string name, int countOfMessages)
        {
            Init(name, countOfMessages);
        }

        private void Init(string name, int countOfMessages)
        {
            string path = Path.Combine("DB", name);
            _countOfMessagesInt = countOfMessages;
            BackColor = Color.LightGray;
            Dock = DockStyle.Top;
            Height = 80;
            BorderStyle = BorderStyle.FixedSingle;
            int width = Width;
            int offset = 10;

            _name = new Label
            {
                AutoSize = true,
                Text = string.Format("Имя: {0}", name),
                Location = new Point(0, 0),
                Font = new Font("Times New Roman", 12, FontStyle.Bold)
            };

            _countOfMessages = new Label
            {
                AutoSize = true,
                Text = string.Format("Количество сообщений: {0}", _countOfMessagesInt.ToString()),
                Location = new Point(0, 15),
                Font = new Font("Times New Roman", 12, FontStyle.Bold)
            };

            _progressBar = new CustomizedProgressBar
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(offset, 50),
                Size = new Size(width - offset * 2, 20),
                Maximum = 4096,
                Value = GetFolderSize(path),
                CustomText = "Использовано МБ",
                ProgressColor = Color.Aqua,
            };

            Controls.Add(_name);
            Controls.Add(_countOfMessages);
            Controls.Add(_progressBar);
        }

        private void InitNewUser()
        {
            BackColor = Color.LightGray;
            Dock = DockStyle.Top;
            Height = 80;
            BorderStyle = BorderStyle.FixedSingle;
            int width = Width;
            int offset = 10;

            List<User> users = ServerWorker.GetUsersList();
            string name = users[users.Count - 1].Username;

            _name = new Label
            {
                AutoSize = true,
                Text = string.Format("Имя: {0}", name),
                Location = new Point(0, 0),
                Font = new Font("Times New Roman", 12, FontStyle.Bold)
            };

            _countOfMessages = new Label
            {
                AutoSize = true,
                Text = string.Format("Количество сообщений: {0}", _countOfMessagesInt.ToString()),
                Location = new Point(0, 15),
                Font = new Font("Times New Roman", 12, FontStyle.Bold)
            };

            _progressBar = new CustomizedProgressBar
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(offset, 50),
                Size = new Size(width - offset * 2, 20),
                Maximum = 4096,
                CustomText = "Использовано МБ",
                ProgressColor = Color.Aqua,
            };

            Controls.Add(_name);
            Controls.Add(_countOfMessages);
            Controls.Add(_progressBar);
        }

        private int GetFolderSize(string folderPath)
        {
            long size = 0;

            string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
                size += new FileInfo(file).Length;

            return (int)(size / 1024f);
        }


        public void UpdateUserInfo()
        {
            string username = _name.Text.Remove(0, 5);
            User user = ServerWorker.GetUser(username);
            _countOfMessages.Text = string.Format("Количество сообщений: {0}", user.MessageCount.ToString());
            _progressBar.Value = GetFolderSize(Path.Combine("DB", username));
            this.Update();
        }
    }
}
