﻿using Server.Properties;
using System;
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

namespace Server
{
    public partial class AdminScreen : Form
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public AdminScreen()
        {
            InitializeComponent();
            UpdateRegistredUsers();
            UsersController.NewUserAdded += AddNewUser;
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
                RegistredUsersPanel.Controls.Add(newUser);
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
            await Task.Run(()=>UsersController.StartServerAsync());
            //await StartServerAsync();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            _stopwatch.Stop();
            UpdateElapsedTime.Stop();
            UsersController.StopServer();
            ApplyStyleForPausedServer();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _stopwatch.Stop();
            _stopwatch.Reset();
            UpdateElapsedTime_Tick(sender, e);
            ApplyStyleForStoppedServer();
            UsersController.StopServer();

        }

        private void UpdateRegistredUsers()
        {
            UsersController.GetUsersList()?.ForEach(user => 
            { 
                UserInfo userInfo = new UserInfo(user.Username, user.MessageCount); 
                RegistredUsersPanel.Controls.Add(userInfo); 
            });
        }

        private void UpdateElapsedTime_Tick(object sender, EventArgs e)
        {
            ElapsedTimeLabel.Text = $"Время работы: {_stopwatch.Elapsed:hh\\:mm\\:ss}";
        }
    }
}
