using System;
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

namespace Server
{
    internal class UserInfo : Panel
    {
        private Label _name;
        private Label _countOfMessages;
        private CustomizedProgressBar _progressBar;
        private int _countOfMessagesInt = 0;

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

            _name = new Label
            {
                AutoSize = true,
                Text = string.Format("Имя: {0}", UsersController.GetNewUserInfo()),
                Location = new Point(0, 0),
                Font = new Font("Times New Roman", 12, FontStyle.Bold)
            };

            _countOfMessages = new Label
            {
                AutoSize = true,
                Text = string.Format("Количество сообщений: {0}",_countOfMessagesInt.ToString()),
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

        public void UpdateProgressBar()
        {

        }
    }
}
