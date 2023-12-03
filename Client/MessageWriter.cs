using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MessageWriter : Form
    {
        private string _username;

        public MessageWriter(string username)
        {
            InitializeComponent();
            RegisterValidSymbols();
            _username = username;
        }

        private void SetFontStyle(FontStyle style)
        {
            int selectionStart = MsgContentTB.SelectionStart;
            int selectionLength = MsgContentTB.SelectionLength;

            Font currentFont = MsgContentTB.SelectionFont;
            FontStyle newStyle = currentFont.Style ^ style; 

            MsgContentTB.SelectionFont = new Font(currentFont, newStyle);


            MsgContentTB.Select(selectionStart, selectionLength);
        }

        private void AlignLeft_Click(object sender, EventArgs e)
        {
            MsgContentTB.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void AlignCenter_Click(object sender, EventArgs e)
        {
            MsgContentTB.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void AlignRight_Click(object sender, EventArgs e)
        {
            MsgContentTB.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void ItalicStyle_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Italic);
        }

        private void BoldStyle_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Bold);
        }

        private void UnderlineStyle_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Underline);
        }

        private bool IsEmptyField(TextBox textBox, Label errorOutputLabel)
        {
            if (!(textBox.Text == string.Empty))
            {
                errorOutputLabel.Text = string.Empty;
                return false;
            }
            else 
                errorOutputLabel.Text = "Поле не может быть пустым";
            return true;
        }

        private bool IsValidUsername(string username)
        {
            const string url = "@afmms.ru";
            int index = username.Length - url.Length;
            if (index >= 0 && username.Substring(index) == url)
            {
                for (int i = 0; i < index; i++)
                    if (username[i] == '@') return false;
                if(HasInvalidSymbol(username)) return false;
                return true;
            }
            return false;
        }

        private List<char> _validSymbols;
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

        private bool HasInvalidSymbol(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!_validSymbols.Contains(text[i])) return true;
            }
            return false;
        }

        private List<string> _recipientsList = new List<string>();
        private void ParseUsernames(string usernames)
        {
            _recipientsList.Clear();
            string[] _recipientsArray = usernames.Split(',');
            for(int i = 0;i < _recipientsArray.Length; i++)
            {
                if (_recipientsArray[i] == string.Empty)
                    continue;
                _recipientsArray[i] = _recipientsArray[i].Trim(' ');
                if (_recipientsArray[i] == string.Empty)
                    continue;
                if (!IsValidUsername(_recipientsArray[i]))
                {
                    ToInputErrorLabel.Text = "Содержатся адреса, введенные в неверном формате, они не будут учтены при отправке сообщения!";
                    continue;
                }
                if (_recipientsList.Contains(_recipientsArray[i]))
                    continue;
                _recipientsList.Add(_recipientsArray[i]); 
            }
        }

        private bool _sendButtonClicked = false;
        private async void SendButton_Click(object sender, EventArgs e)
        {
            if (IsEmptyField(ToTB, ToInputErrorLabel) || IsEmptyField(ThemeTB, ThemeInputErrorLabel))
                return;
            ParseUsernames(ToTB.Text);
            if(_recipientsList.Count == 0)
            {
                ToInputErrorLabel.Text = "Не введено ни одного адреса в верном формате!";
                return;
            }
            Server.Message message = new Server.Message(_username, _recipientsList, MsgContentTB.Rtf, Server.Message.MessageType.Sent);
            try
            {
                await UsersController.TryConnect();
            }
            catch 
            {
                MessageBox.Show("Сервер не отвечает, попробуйте отправить сообщение позже", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await UsersController.SendMessage(message);
            _sendButtonClicked = true;
            Close();
        }
    }
}
