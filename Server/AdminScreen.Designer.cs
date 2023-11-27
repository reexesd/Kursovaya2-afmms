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
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ServerStatusLabelPanel = new System.Windows.Forms.Panel();
            this.ElapsedTimeLabel = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.PictureBox();
            this.PauseButton = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.PictureBox();
            this.ServerStatus = new System.Windows.Forms.Label();
            this.UpdateElapsedTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.RegistredUsersLabelPanel.SuspendLayout();
            this.ServerStatusPanel.SuspendLayout();
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
            this.ServerStatusPanel.Controls.Add(this.Chart);
            this.ServerStatusPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ServerStatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerStatusPanel.Location = new System.Drawing.Point(0, 24);
            this.ServerStatusPanel.Name = "ServerStatusPanel";
            this.ServerStatusPanel.Size = new System.Drawing.Size(904, 478);
            this.ServerStatusPanel.TabIndex = 2;
            // 
            // Chart
            // 
            this.Chart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Chart.Location = new System.Drawing.Point(-2, 127);
            this.Chart.Name = "Chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Chart.Series.Add(series1);
            this.Chart.Size = new System.Drawing.Size(905, 217);
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
    }
}

