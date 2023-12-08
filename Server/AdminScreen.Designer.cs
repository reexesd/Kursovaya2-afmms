namespace Server
{
    partial class AdminScreen
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.RegistredUsersPanel = new System.Windows.Forms.Panel();
            this.RegistredUsersLabelPanel = new System.Windows.Forms.Panel();
            this.RegistredUsersLabel = new System.Windows.Forms.Label();
            this.ServerStatusPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProcessingMessages = new System.Windows.Forms.DataGridView();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ServerStatusLabelPanel = new System.Windows.Forms.Panel();
            this.ElapsedTimeLabel = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.PictureBox();
            this.PauseButton = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.PictureBox();
            this.ServerStatus = new System.Windows.Forms.Label();
            this.UpdateElapsedTime = new System.Windows.Forms.Timer(this.components);
            this.ServerMemoryProgressBar = new Server.CustomizedProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.RegistredUsersLabelPanel.SuspendLayout();
            this.ServerStatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.ServerStatusLabelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StopButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartButton)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.IsSplitterFixed = true;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.RegistredUsersPanel);
            this.SplitContainer.Panel1.Controls.Add(this.RegistredUsersLabelPanel);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.ServerStatusPanel);
            this.SplitContainer.Panel2.Controls.Add(this.ServerStatusLabelPanel);
            this.SplitContainer.Size = new System.Drawing.Size(1186, 504);
            this.SplitContainer.SplitterDistance = 276;
            this.SplitContainer.TabIndex = 0;
            this.SplitContainer.TabStop = false;
            // 
            // RegistredUsersPanel
            // 
            this.RegistredUsersPanel.AutoScroll = true;
            this.RegistredUsersPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RegistredUsersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistredUsersPanel.Location = new System.Drawing.Point(0, 24);
            this.RegistredUsersPanel.Name = "RegistredUsersPanel";
            this.RegistredUsersPanel.Size = new System.Drawing.Size(274, 478);
            this.RegistredUsersPanel.TabIndex = 2;
            // 
            // RegistredUsersLabelPanel
            // 
            this.RegistredUsersLabelPanel.BackColor = System.Drawing.SystemColors.Control;
            this.RegistredUsersLabelPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RegistredUsersLabelPanel.Controls.Add(this.RegistredUsersLabel);
            this.RegistredUsersLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RegistredUsersLabelPanel.Location = new System.Drawing.Point(0, 0);
            this.RegistredUsersLabelPanel.Name = "RegistredUsersLabelPanel";
            this.RegistredUsersLabelPanel.Size = new System.Drawing.Size(274, 24);
            this.RegistredUsersLabelPanel.TabIndex = 1;
            // 
            // RegistredUsersLabel
            // 
            this.RegistredUsersLabel.AutoSize = true;
            this.RegistredUsersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistredUsersLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistredUsersLabel.Location = new System.Drawing.Point(0, 0);
            this.RegistredUsersLabel.Name = "RegistredUsersLabel";
            this.RegistredUsersLabel.Size = new System.Drawing.Size(264, 19);
            this.RegistredUsersLabel.TabIndex = 0;
            this.RegistredUsersLabel.Text = "Зарегистрированные пользователи";
            // 
            // ServerStatusPanel
            // 
            this.ServerStatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ServerStatusPanel.Controls.Add(this.ServerMemoryProgressBar);
            this.ServerStatusPanel.Controls.Add(this.label4);
            this.ServerStatusPanel.Controls.Add(this.label3);
            this.ServerStatusPanel.Controls.Add(this.label2);
            this.ServerStatusPanel.Controls.Add(this.label1);
            this.ServerStatusPanel.Controls.Add(this.ProcessingMessages);
            this.ServerStatusPanel.Controls.Add(this.Chart);
            this.ServerStatusPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ServerStatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerStatusPanel.Location = new System.Drawing.Point(0, 24);
            this.ServerStatusPanel.Name = "ServerStatusPanel";
            this.ServerStatusPanel.Size = new System.Drawing.Size(904, 478);
            this.ServerStatusPanel.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Память сервера:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Обрабатываемые сообщения:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "График загруженности сервера:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Адрес сервера: afmms.ru";
            // 
            // ProcessingMessages
            // 
            this.ProcessingMessages.AllowUserToAddRows = false;
            this.ProcessingMessages.AllowUserToDeleteRows = false;
            this.ProcessingMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessingMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProcessingMessages.BackgroundColor = System.Drawing.Color.White;
            this.ProcessingMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessingMessages.GridColor = System.Drawing.Color.Black;
            this.ProcessingMessages.Location = new System.Drawing.Point(6, 321);
            this.ProcessingMessages.Name = "ProcessingMessages";
            this.ProcessingMessages.ReadOnly = true;
            this.ProcessingMessages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ProcessingMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProcessingMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ProcessingMessages.ShowCellErrors = false;
            this.ProcessingMessages.ShowCellToolTips = false;
            this.ProcessingMessages.ShowEditingIcon = false;
            this.ProcessingMessages.ShowRowErrors = false;
            this.ProcessingMessages.Size = new System.Drawing.Size(891, 150);
            this.ProcessingMessages.TabIndex = 1;
            this.ProcessingMessages.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ProcessingMessages_RowsAdded);
            this.ProcessingMessages.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.ProcessingMessages_RowsRemoved);
            // 
            // Chart
            // 
            this.Chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart.BackColor = System.Drawing.Color.Transparent;
            this.Chart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.None;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.HeaderSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
            legend1.Name = "Legend1";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(6, 45);
            this.Chart.Name = "Chart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Legend = "Legend1";
            series1.MarkerBorderWidth = 20;
            series1.Name = "Series1";
            this.Chart.Series.Add(series1);
            this.Chart.Size = new System.Drawing.Size(891, 197);
            this.Chart.TabIndex = 0;
            this.Chart.TabStop = false;
            this.Chart.Text = "chart1";
            // 
            // ServerStatusLabelPanel
            // 
            this.ServerStatusLabelPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ServerStatusLabelPanel.Controls.Add(this.ElapsedTimeLabel);
            this.ServerStatusLabelPanel.Controls.Add(this.StopButton);
            this.ServerStatusLabelPanel.Controls.Add(this.PauseButton);
            this.ServerStatusLabelPanel.Controls.Add(this.StartButton);
            this.ServerStatusLabelPanel.Controls.Add(this.ServerStatus);
            this.ServerStatusLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ServerStatusLabelPanel.Location = new System.Drawing.Point(0, 0);
            this.ServerStatusLabelPanel.Name = "ServerStatusLabelPanel";
            this.ServerStatusLabelPanel.Size = new System.Drawing.Size(904, 24);
            this.ServerStatusLabelPanel.TabIndex = 1;
            // 
            // ElapsedTimeLabel
            // 
            this.ElapsedTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ElapsedTimeLabel.AutoSize = true;
            this.ElapsedTimeLabel.Location = new System.Drawing.Point(674, 4);
            this.ElapsedTimeLabel.Name = "ElapsedTimeLabel";
            this.ElapsedTimeLabel.Size = new System.Drawing.Size(131, 13);
            this.ElapsedTimeLabel.TabIndex = 4;
            this.ElapsedTimeLabel.Text = "Время работы сервера: ";
            // 
            // StopButton
            // 
            this.StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopButton.Enabled = false;
            this.StopButton.Image = global::Server.Properties.Resources.InactiveStopButton;
            this.StopButton.Location = new System.Drawing.Point(195, 4);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(15, 15);
            this.StopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StopButton.TabIndex = 3;
            this.StopButton.TabStop = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PauseButton.Enabled = false;
            this.PauseButton.Image = global::Server.Properties.Resources.InactivePauseButton;
            this.PauseButton.Location = new System.Drawing.Point(174, 4);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(15, 15);
            this.PauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PauseButton.TabIndex = 2;
            this.PauseButton.TabStop = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.Image = global::Server.Properties.Resources.ActiveStartButton;
            this.StartButton.Location = new System.Drawing.Point(153, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(15, 15);
            this.StartButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StartButton.TabIndex = 1;
            this.StartButton.TabStop = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ServerStatus
            // 
            this.ServerStatus.AutoSize = true;
            this.ServerStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.ServerStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerStatus.Location = new System.Drawing.Point(0, 0);
            this.ServerStatus.Name = "ServerStatus";
            this.ServerStatus.Size = new System.Drawing.Size(146, 19);
            this.ServerStatus.TabIndex = 0;
            this.ServerStatus.Text = "Состояние сервера";
            // 
            // UpdateElapsedTime
            // 
            this.UpdateElapsedTime.Interval = 1000;
            this.UpdateElapsedTime.Tick += new System.EventHandler(this.UpdateElapsedTime_Tick);
            // 
            // ServerMemoryProgressBar
            // 
            this.ServerMemoryProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerMemoryProgressBar.CustomText = "Использовано ГБ";
            this.ServerMemoryProgressBar.Location = new System.Drawing.Point(128, 264);
            this.ServerMemoryProgressBar.Maximum = 1024;
            this.ServerMemoryProgressBar.Name = "ServerMemoryProgressBar";
            this.ServerMemoryProgressBar.ProgressColor = System.Drawing.Color.Aqua;
            this.ServerMemoryProgressBar.Size = new System.Drawing.Size(769, 23);
            this.ServerMemoryProgressBar.TabIndex = 6;
            this.ServerMemoryProgressBar.TextColor = System.Drawing.Color.Black;
            this.ServerMemoryProgressBar.TextFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // AdminScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 504);
            this.Controls.Add(this.SplitContainer);
            this.MinimumSize = new System.Drawing.Size(1202, 543);
            this.Name = "AdminScreen";
            this.Text = "Мониторинг сервера";
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.RegistredUsersLabelPanel.ResumeLayout(false);
            this.RegistredUsersLabelPanel.PerformLayout();
            this.ServerStatusPanel.ResumeLayout(false);
            this.ServerStatusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ServerStatusLabelPanel.ResumeLayout(false);
            this.ServerStatusLabelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StopButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.Panel RegistredUsersLabelPanel;
        private System.Windows.Forms.Label RegistredUsersLabel;
        private System.Windows.Forms.Panel ServerStatusLabelPanel;
        private System.Windows.Forms.Label ServerStatus;
        private System.Windows.Forms.Panel ServerStatusPanel;
        private System.Windows.Forms.Panel RegistredUsersPanel;
        private System.Windows.Forms.PictureBox StartButton;
        private System.Windows.Forms.PictureBox StopButton;
        private System.Windows.Forms.PictureBox PauseButton;
        private System.Windows.Forms.Label ElapsedTimeLabel;
        private System.Windows.Forms.Timer UpdateElapsedTime;
        private System.Windows.Forms.DataGridView ProcessingMessages;
        private System.Windows.Forms.Label label1;
        private CustomizedProgressBar ServerMemoryProgressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

