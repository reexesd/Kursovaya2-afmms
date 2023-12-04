using Server.Properties;
using System;
using Newtonsoft.Json;
using System.IO.Pipes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Concurrent;

namespace Server
{
    public partial class AdminScreen : Form
    {
        private List<UserInfo> _users = new List<UserInfo>();
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private Queue<Message> _processingMessages = new Queue<Message>();

        public AdminScreen()
        {
            InitializeComponent();
            UpdateAllUsers();
            InitDataGridView();
            ServerController.NewUserAdded += AddNewUser;
            ServerController.MessageSent += MessageSent;
            ServerController.NeedToUpdate += UpdateRequired;
            ServerController.ProcessingStarted += StartProcessing;
            ServerController.ProcessingCompleted += CompleteProcessing;
            ServerController.ProcessingEnded += DeleteFirstRow;
        }

        private void InitDataGridView()
        {
            ProcessingMessages.TopLeftHeaderCell.Value = "Номер в очереди";
            ProcessingMessages.ColumnCount = 6;
            ProcessingMessages.Columns[0].HeaderCell.Value = "Протокол";
            ProcessingMessages.Columns[1].HeaderCell.Value = "Отправитель";
            ProcessingMessages.Columns[2].HeaderCell.Value = "Получатель";
            ProcessingMessages.Columns[3].HeaderCell.Value = "Статус";
            ProcessingMessages.Columns[4].HeaderCell.Value = "Дата отправки";
            ProcessingMessages.Columns[5].HeaderCell.Value = "Дата получения";
            foreach (DataGridViewColumn column in ProcessingMessages.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            ProcessingMessages.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ProcessingMessages.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ProcessingMessages.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ProcessingMessages.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        private void AddNewUser(object sender, EventArgs e)
        {
            if (RegistredUsersPanel.InvokeRequired)
            {
                RegistredUsersPanel.Invoke(new Action<object, EventArgs>(AddNewUser), sender, e);
            }
            else
            {
                UserInfo newUser = new UserInfo();
                _users.Add(newUser);
                RegistredUsersPanel.Controls.Add(newUser);
            }
        }
        private void MessageSent(object sender, Message msg)
        {
            ProcessingMessages.Invoke(new Action<Message>(EnqueueToProcessing), msg);
        }
        
        private void UpdateRequired(object sender, User user)
         {
            _users.Find(x => x.Name == user.Username).Invoke((MethodInvoker)delegate
            {
                _users.Find(x => x.Name == user.Username).UpdateUserInfo();
            });
        }

        private void StartProcessing(object sender, Message message)
        {
            if(ProcessingMessages.InvokeRequired)
                ProcessingMessages.Invoke(new Action<object, Message>(StartProcessing), sender, message);
            ProcessingMessages.Rows[0].Cells[0].Value = "SMTP";
            ProcessingMessages.Rows[0].Cells[3].Value = "Отправлено";
        }

        private void CompleteProcessing(object sender, Message message)
        {
            ProcessingMessages.Rows[0].Cells[0].Value = "POP3";
            ProcessingMessages.Rows[0].Cells[3].Value = "Получено";
            ProcessingMessages.Rows[0].Cells[5].Value = message.ReceiveTime.ToString();
        }

        private void DeleteFirstRow(object sender, EventArgs e)
        {
            ProcessingMessages.Invoke(new Action(() => ProcessingMessages.Rows.RemoveAt(0)));
        }

        private void EnqueueToProcessing(Message message)
        {
            for(int i = 0; i < message.To.Count; i++)
            {
                ProcessingMessages.Rows.Add("----", message.From, message.To[i], "В очереди", message.SendTime.ToString());
            }
        }

        private void ApplyStyleForRunnedServer()
        {
            StartButton.Image = Resources.InactiveStartButton;
            StartButton.Enabled = false;
            PauseButton.Image = Resources.ActivePauseButton;
            PauseButton.Enabled = true;
            StopButton.Image = Resources.ActiveStopButton;
            StopButton.Enabled = true;
        }

        private void ApplyStyleForPausedServer()
        {
            StartButton.Image = Resources.ActiveStartButton;
            StartButton.Enabled = true;
            PauseButton.Image = Resources.InactivePauseButton;
            PauseButton.Enabled = false;
            StopButton.Image = Resources.ActiveStopButton;
            StopButton.Enabled = true;
        }

        private void ApplyStyleForStoppedServer()
        {
            StartButton.Image = Resources.ActiveStartButton;
            StartButton.Enabled = true;
            PauseButton.Image = Resources.InactivePauseButton;
            PauseButton.Enabled = false;
            StopButton.Image = Resources.InactiveStopButton;
            StopButton.Enabled = false;
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            _stopwatch.Start();
            ApplyStyleForRunnedServer();
            UpdateElapsedTime.Start();
            await Task.Run(() => ServerController.StartServerAsync());
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            _stopwatch.Stop();
            UpdateElapsedTime.Stop();
            ServerController.StopServer();
            ApplyStyleForPausedServer();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _stopwatch.Stop();
            _stopwatch.Reset();
            UpdateElapsedTime_Tick(sender, e);
            ApplyStyleForStoppedServer();
            ServerController.StopServer();
        }

        private void UpdateAllUsers()
        {
            ServerController.GetUsersList()?.ForEach(user =>
            {
                UserInfo userInfo = new UserInfo(user.Username, user.MessageCount);
                _users.Add(userInfo);
                RegistredUsersPanel.Controls.Add(userInfo);
            });
        }

        private void UpdateElapsedTime_Tick(object sender, EventArgs e)
        {
            ElapsedTimeLabel.Text = $"Время работы: {_stopwatch.Elapsed:hh\\:mm\\:ss}";
        }

        private void ProcessingMessages_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ProcessingMessages.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }

        private void ProcessingMessages_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = 0; i < ProcessingMessages.Rows.Count; i++)
            {
                ProcessingMessages.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
    }
}
