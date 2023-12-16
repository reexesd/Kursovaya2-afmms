namespace Client
{
    partial class ClientApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientApp));
            this.MainMenu = new System.Windows.Forms.Panel();
            this.SentMessagesLabel = new System.Windows.Forms.Label();
            this.ReceivedMessageLabel = new System.Windows.Forms.Label();
            this.WriteMsgLabel = new System.Windows.Forms.Label();
            this.MainMenuLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.SentMessages = new System.Windows.Forms.TabPage();
            this.ReceivedMessages = new System.Windows.Forms.TabPage();
            this.DraftMessages = new System.Windows.Forms.TabPage();
            this.OpenMainMenuAnim = new System.Windows.Forms.Timer(this.components);
            this.CloseMainMenuAnim = new System.Windows.Forms.Timer(this.components);
            this.UserPanel = new Client.UserPanel();
            this.SignOutLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.DraftMessagesLabel = new System.Windows.Forms.Label();
            this.UserPicture = new System.Windows.Forms.PictureBox();
            this.DraftMessagesButton = new System.Windows.Forms.PictureBox();
            this.SentMessagesButton = new System.Windows.Forms.PictureBox();
            this.ReceivedMessagesButton = new System.Windows.Forms.PictureBox();
            this.WriteMsgButton = new System.Windows.Forms.PictureBox();
            this.MainMenuButton = new System.Windows.Forms.PictureBox();
            this.MainMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftMessagesButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SentMessagesButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedMessagesButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WriteMsgButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenuButton)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainMenu.Controls.Add(this.DraftMessagesLabel);
            this.MainMenu.Controls.Add(this.DraftMessagesButton);
            this.MainMenu.Controls.Add(this.SentMessagesLabel);
            this.MainMenu.Controls.Add(this.SentMessagesButton);
            this.MainMenu.Controls.Add(this.ReceivedMessageLabel);
            this.MainMenu.Controls.Add(this.ReceivedMessagesButton);
            this.MainMenu.Controls.Add(this.WriteMsgLabel);
            this.MainMenu.Controls.Add(this.WriteMsgButton);
            this.MainMenu.Controls.Add(this.MainMenuLabel);
            this.MainMenu.Controls.Add(this.MainMenuButton);
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(140, 583);
            this.MainMenu.TabIndex = 0;
            // 
            // SentMessagesLabel
            // 
            this.SentMessagesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SentMessagesLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SentMessagesLabel.Location = new System.Drawing.Point(38, 132);
            this.SentMessagesLabel.Name = "SentMessagesLabel";
            this.SentMessagesLabel.Size = new System.Drawing.Size(100, 20);
            this.SentMessagesLabel.TabIndex = 7;
            this.SentMessagesLabel.Text = "Отправленные";
            this.SentMessagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SentMessagesLabel.MouseEnter += new System.EventHandler(this.SentMessagesButton_MouseEnter);
            this.SentMessagesLabel.MouseLeave += new System.EventHandler(this.SentMessagesButton_MouseLeave);
            // 
            // ReceivedMessageLabel
            // 
            this.ReceivedMessageLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReceivedMessageLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReceivedMessageLabel.Location = new System.Drawing.Point(38, 91);
            this.ReceivedMessageLabel.Name = "ReceivedMessageLabel";
            this.ReceivedMessageLabel.Size = new System.Drawing.Size(100, 20);
            this.ReceivedMessageLabel.TabIndex = 5;
            this.ReceivedMessageLabel.Text = "Полученные";
            this.ReceivedMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReceivedMessageLabel.MouseEnter += new System.EventHandler(this.ReceivedMessagesButton_MouseEnter);
            this.ReceivedMessageLabel.MouseLeave += new System.EventHandler(this.ReceivedMessagesButton_MouseLeave);
            // 
            // WriteMsgLabel
            // 
            this.WriteMsgLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WriteMsgLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WriteMsgLabel.Location = new System.Drawing.Point(38, 43);
            this.WriteMsgLabel.Name = "WriteMsgLabel";
            this.WriteMsgLabel.Size = new System.Drawing.Size(104, 34);
            this.WriteMsgLabel.TabIndex = 3;
            this.WriteMsgLabel.Text = "Написать сообщение";
            this.WriteMsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WriteMsgLabel.Click += new System.EventHandler(this.WriteMsgButton_Click);
            this.WriteMsgLabel.MouseEnter += new System.EventHandler(this.WriteMsgButton_MouseEnter);
            this.WriteMsgLabel.MouseLeave += new System.EventHandler(this.WriteMsgButton_MouseLeave);
            // 
            // MainMenuLabel
            // 
            this.MainMenuLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainMenuLabel.Location = new System.Drawing.Point(38, 9);
            this.MainMenuLabel.Name = "MainMenuLabel";
            this.MainMenuLabel.Size = new System.Drawing.Size(103, 20);
            this.MainMenuLabel.TabIndex = 1;
            this.MainMenuLabel.Text = "Главное меню";
            this.MainMenuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainMenuLabel.Click += new System.EventHandler(this.MainMenuButton_Click);
            this.MainMenuLabel.MouseEnter += new System.EventHandler(this.MainMenuButton_MouseEnter);
            this.MainMenuLabel.MouseLeave += new System.EventHandler(this.MainMenuButton_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.UserPicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(140, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 39);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Tabs);
            this.panel3.Controls.Add(this.UserPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel3.Location = new System.Drawing.Point(140, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(799, 544);
            this.panel3.TabIndex = 2;
            // 
            // Tabs
            // 
            this.Tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.Tabs.Controls.Add(this.SentMessages);
            this.Tabs.Controls.Add(this.ReceivedMessages);
            this.Tabs.Controls.Add(this.DraftMessages);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.Padding = new System.Drawing.Point(0, 0);
            this.Tabs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(797, 542);
            this.Tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Tabs.TabIndex = 2;
            this.Tabs.TabStop = false;
            // 
            // SentMessages
            // 
            this.SentMessages.AutoScroll = true;
            this.SentMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SentMessages.Location = new System.Drawing.Point(4, 26);
            this.SentMessages.Margin = new System.Windows.Forms.Padding(0);
            this.SentMessages.Name = "SentMessages";
            this.SentMessages.Size = new System.Drawing.Size(789, 512);
            this.SentMessages.TabIndex = 0;
            // 
            // ReceivedMessages
            // 
            this.ReceivedMessages.AutoScroll = true;
            this.ReceivedMessages.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ReceivedMessages.Location = new System.Drawing.Point(4, 26);
            this.ReceivedMessages.Name = "ReceivedMessages";
            this.ReceivedMessages.Padding = new System.Windows.Forms.Padding(3);
            this.ReceivedMessages.Size = new System.Drawing.Size(789, 512);
            this.ReceivedMessages.TabIndex = 1;
            // 
            // DraftMessages
            // 
            this.DraftMessages.AutoScroll = true;
            this.DraftMessages.BackColor = System.Drawing.SystemColors.HotTrack;
            this.DraftMessages.Location = new System.Drawing.Point(4, 26);
            this.DraftMessages.Name = "DraftMessages";
            this.DraftMessages.Padding = new System.Windows.Forms.Padding(3);
            this.DraftMessages.Size = new System.Drawing.Size(789, 512);
            this.DraftMessages.TabIndex = 2;
            // 
            // OpenMainMenuAnim
            // 
            this.OpenMainMenuAnim.Interval = 5;
            this.OpenMainMenuAnim.Tick += new System.EventHandler(this.OpenMainMenuAnim_Tick);
            // 
            // CloseMainMenuAnim
            // 
            this.CloseMainMenuAnim.Interval = 5;
            this.CloseMainMenuAnim.Tick += new System.EventHandler(this.CloseMainMenuAnim_Tick);
            // 
            // UserPanel
            // 
            this.UserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserPanel.BackColor = System.Drawing.Color.Silver;
            this.UserPanel.Controls.Add(this.SignOutLabel);
            this.UserPanel.Controls.Add(this.UsernameLabel);
            this.UserPanel.CornerRadius = 13;
            this.UserPanel.Location = new System.Drawing.Point(641, 0);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.PaddingP = 10;
            this.UserPanel.Size = new System.Drawing.Size(157, 87);
            this.UserPanel.TabIndex = 1;
            this.UserPanel.Visible = false;
            // 
            // SignOutLabel
            // 
            this.SignOutLabel.AutoSize = true;
            this.SignOutLabel.BackColor = System.Drawing.Color.Transparent;
            this.SignOutLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignOutLabel.Location = new System.Drawing.Point(60, 60);
            this.SignOutLabel.Name = "SignOutLabel";
            this.SignOutLabel.Size = new System.Drawing.Size(40, 14);
            this.SignOutLabel.TabIndex = 1;
            this.SignOutLabel.Text = "Выйти";
            this.SignOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SignOutLabel.Click += new System.EventHandler(this.SignOutLabel_Click);
            this.SignOutLabel.MouseEnter += new System.EventHandler(this.SignOutLabel_MouseEnter);
            this.SignOutLabel.MouseLeave += new System.EventHandler(this.SignOutLabel_MouseLeave);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameLabel.Location = new System.Drawing.Point(11, 12);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(134, 48);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UsernameLabel.Click += new System.EventHandler(this.UsernameLabel_Click);
            this.UsernameLabel.MouseEnter += new System.EventHandler(this.UsernameLabel_MouseEnter);
            this.UsernameLabel.MouseLeave += new System.EventHandler(this.UsernameLabel_MouseLeave);
            // 
            // DraftMessagesLabel
            // 
            this.DraftMessagesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DraftMessagesLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DraftMessagesLabel.Location = new System.Drawing.Point(38, 173);
            this.DraftMessagesLabel.Name = "DraftMessagesLabel";
            this.DraftMessagesLabel.Size = new System.Drawing.Size(100, 20);
            this.DraftMessagesLabel.TabIndex = 9;
            this.DraftMessagesLabel.Text = "Черновики";
            this.DraftMessagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DraftMessagesLabel.MouseEnter += new System.EventHandler(this.DraftMessagesButton_MouseEnter);
            this.DraftMessagesLabel.MouseLeave += new System.EventHandler(this.DraftMessagesButton_MouseLeave);
            // 
            // UserPicture
            // 
            this.UserPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserPicture.Image = ((System.Drawing.Image)(resources.GetObject("UserPicture.Image")));
            this.UserPicture.Location = new System.Drawing.Point(760, 0);
            this.UserPicture.Name = "UserPicture";
            this.UserPicture.Size = new System.Drawing.Size(39, 39);
            this.UserPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPicture.TabIndex = 0;
            this.UserPicture.TabStop = false;
            this.UserPicture.Click += new System.EventHandler(this.UserPicture_Click);
            // 
            // DraftMessagesButton
            // 
            this.DraftMessagesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DraftMessagesButton.Image = global::Client.Properties.Resources.DraftMessagesImg;
            this.DraftMessagesButton.Location = new System.Drawing.Point(9, 173);
            this.DraftMessagesButton.Name = "DraftMessagesButton";
            this.DraftMessagesButton.Size = new System.Drawing.Size(20, 20);
            this.DraftMessagesButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DraftMessagesButton.TabIndex = 8;
            this.DraftMessagesButton.TabStop = false;
            this.DraftMessagesButton.MouseEnter += new System.EventHandler(this.DraftMessagesButton_MouseEnter);
            this.DraftMessagesButton.MouseLeave += new System.EventHandler(this.DraftMessagesButton_MouseLeave);
            // 
            // SentMessagesButton
            // 
            this.SentMessagesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SentMessagesButton.Image = global::Client.Properties.Resources.SentMessagesImg;
            this.SentMessagesButton.Location = new System.Drawing.Point(9, 132);
            this.SentMessagesButton.Name = "SentMessagesButton";
            this.SentMessagesButton.Size = new System.Drawing.Size(20, 20);
            this.SentMessagesButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SentMessagesButton.TabIndex = 6;
            this.SentMessagesButton.TabStop = false;
            this.SentMessagesButton.MouseEnter += new System.EventHandler(this.SentMessagesButton_MouseEnter);
            this.SentMessagesButton.MouseLeave += new System.EventHandler(this.SentMessagesButton_MouseLeave);
            // 
            // ReceivedMessagesButton
            // 
            this.ReceivedMessagesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReceivedMessagesButton.Image = global::Client.Properties.Resources.ReceivedMessagesImg;
            this.ReceivedMessagesButton.Location = new System.Drawing.Point(9, 91);
            this.ReceivedMessagesButton.Name = "ReceivedMessagesButton";
            this.ReceivedMessagesButton.Size = new System.Drawing.Size(20, 20);
            this.ReceivedMessagesButton.TabIndex = 4;
            this.ReceivedMessagesButton.TabStop = false;
            this.ReceivedMessagesButton.MouseEnter += new System.EventHandler(this.ReceivedMessagesButton_MouseEnter);
            this.ReceivedMessagesButton.MouseLeave += new System.EventHandler(this.ReceivedMessagesButton_MouseLeave);
            // 
            // WriteMsgButton
            // 
            this.WriteMsgButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WriteMsgButton.Image = ((System.Drawing.Image)(resources.GetObject("WriteMsgButton.Image")));
            this.WriteMsgButton.Location = new System.Drawing.Point(9, 50);
            this.WriteMsgButton.Name = "WriteMsgButton";
            this.WriteMsgButton.Size = new System.Drawing.Size(20, 20);
            this.WriteMsgButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WriteMsgButton.TabIndex = 2;
            this.WriteMsgButton.TabStop = false;
            this.WriteMsgButton.Click += new System.EventHandler(this.WriteMsgButton_Click);
            this.WriteMsgButton.MouseEnter += new System.EventHandler(this.WriteMsgButton_MouseEnter);
            this.WriteMsgButton.MouseLeave += new System.EventHandler(this.WriteMsgButton_MouseLeave);
            // 
            // MainMenuButton
            // 
            this.MainMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("MainMenuButton.Image")));
            this.MainMenuButton.Location = new System.Drawing.Point(9, 9);
            this.MainMenuButton.Name = "MainMenuButton";
            this.MainMenuButton.Size = new System.Drawing.Size(20, 20);
            this.MainMenuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainMenuButton.TabIndex = 0;
            this.MainMenuButton.TabStop = false;
            this.MainMenuButton.Click += new System.EventHandler(this.MainMenuButton_Click);
            this.MainMenuButton.MouseEnter += new System.EventHandler(this.MainMenuButton_MouseEnter);
            this.MainMenuButton.MouseLeave += new System.EventHandler(this.MainMenuButton_MouseLeave);
            // 
            // ClientApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 583);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MainMenu);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ClientApp";
            this.Text = "ClientApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftMessagesButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SentMessagesButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedMessagesButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WriteMsgButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenuButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox UserPicture;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label SignOutLabel;
        private UserPanel UserPanel;
        private System.Windows.Forms.PictureBox MainMenuButton;
        private System.Windows.Forms.Timer OpenMainMenuAnim;
        private System.Windows.Forms.Timer CloseMainMenuAnim;
        private System.Windows.Forms.Label MainMenuLabel;
        private System.Windows.Forms.PictureBox WriteMsgButton;
        private System.Windows.Forms.Label WriteMsgLabel;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage SentMessages;
        private System.Windows.Forms.TabPage ReceivedMessages;
        private System.Windows.Forms.TabPage DraftMessages;
        private System.Windows.Forms.Label ReceivedMessageLabel;
        private System.Windows.Forms.PictureBox ReceivedMessagesButton;
        private System.Windows.Forms.Label SentMessagesLabel;
        private System.Windows.Forms.PictureBox SentMessagesButton;
        private System.Windows.Forms.Label DraftMessagesLabel;
        private System.Windows.Forms.PictureBox DraftMessagesButton;
    }
}

