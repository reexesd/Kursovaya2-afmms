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
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.DeleteSelectedButton = new System.Windows.Forms.PictureBox();
            this.SelectAllCB = new System.Windows.Forms.CheckBox();
            this.DeleteButton = new System.Windows.Forms.PictureBox();
            this.BackButton = new System.Windows.Forms.PictureBox();
            this.ControlLabel = new System.Windows.Forms.Label();
            this.UserPicture = new System.Windows.Forms.PictureBox();
            this.OpenMainMenuAnim = new System.Windows.Forms.Timer(this.components);
            this.CloseMainMenuAnim = new System.Windows.Forms.Timer(this.components);
            this.UpdateMessagesTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu = new Client.Panel();
            this.DraftMessagesLabel = new System.Windows.Forms.Label();
            this.WriteMsgLabel = new System.Windows.Forms.Label();
            this.DraftMessagesButton = new System.Windows.Forms.PictureBox();
            this.MainMenuButton = new System.Windows.Forms.PictureBox();
            this.SentMessagesLabel = new System.Windows.Forms.Label();
            this.MainMenuLabel = new System.Windows.Forms.Label();
            this.SentMessagesButton = new System.Windows.Forms.PictureBox();
            this.WriteMsgButton = new System.Windows.Forms.PictureBox();
            this.ReceivedMessageLabel = new System.Windows.Forms.Label();
            this.ReceivedMessagesButton = new System.Windows.Forms.PictureBox();
            this.UserPanel = new Client.UserPanel();
            this.SignOutLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteSelectedButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).BeginInit();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DraftMessagesButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenuButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SentMessagesButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WriteMsgButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedMessagesButton)).BeginInit();
            this.UserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(237)))), ((int)(((byte)(67)))));
            this.ControlPanel.Controls.Add(this.DeleteSelectedButton);
            this.ControlPanel.Controls.Add(this.SelectAllCB);
            this.ControlPanel.Controls.Add(this.DeleteButton);
            this.ControlPanel.Controls.Add(this.BackButton);
            this.ControlPanel.Controls.Add(this.ControlLabel);
            this.ControlPanel.Controls.Add(this.UserPicture);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlPanel.Location = new System.Drawing.Point(140, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(799, 39);
            this.ControlPanel.TabIndex = 1;
            // 
            // DeleteSelectedButton
            // 
            this.DeleteSelectedButton.BackColor = System.Drawing.Color.White;
            this.DeleteSelectedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteSelectedButton.Image = global::Client.Properties.Resources.Trash;
            this.DeleteSelectedButton.Location = new System.Drawing.Point(105, 3);
            this.DeleteSelectedButton.Name = "DeleteSelectedButton";
            this.DeleteSelectedButton.Size = new System.Drawing.Size(29, 29);
            this.DeleteSelectedButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DeleteSelectedButton.TabIndex = 5;
            this.DeleteSelectedButton.TabStop = false;
            this.DeleteSelectedButton.Visible = false;
            this.DeleteSelectedButton.Click += new System.EventHandler(this.DeleteSelectedButton_Click);
            this.DeleteSelectedButton.MouseEnter += new System.EventHandler(this.DeleteSelectedButton_MouseEnter);
            this.DeleteSelectedButton.MouseLeave += new System.EventHandler(this.DeleteSelectedButton_MouseLeave);
            // 
            // SelectAllCB
            // 
            this.SelectAllCB.AutoSize = true;
            this.SelectAllCB.BackColor = System.Drawing.Color.White;
            this.SelectAllCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectAllCB.Location = new System.Drawing.Point(8, 10);
            this.SelectAllCB.Name = "SelectAllCB";
            this.SelectAllCB.Size = new System.Drawing.Size(91, 17);
            this.SelectAllCB.TabIndex = 4;
            this.SelectAllCB.Text = "Выбрать все";
            this.SelectAllCB.UseVisualStyleBackColor = false;
            this.SelectAllCB.Visible = false;
            this.SelectAllCB.CheckedChanged += new System.EventHandler(this.SelectAllCB_CheckedChanged);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteButton.Image = global::Client.Properties.Resources.Trash;
            this.DeleteButton.Location = new System.Drawing.Point(45, 5);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(29, 29);
            this.DeleteButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.TabStop = false;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            this.DeleteButton.MouseEnter += new System.EventHandler(this.DeleteButton_MouseEnter);
            this.DeleteButton.MouseLeave += new System.EventHandler(this.DeleteButton_MouseLeave);
            // 
            // BackButton
            // 
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = global::Client.Properties.Resources.GrayArrow;
            this.BackButton.Location = new System.Drawing.Point(8, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(32, 32);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackButton.TabIndex = 2;
            this.BackButton.TabStop = false;
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            this.BackButton.MouseEnter += new System.EventHandler(this.BackButton_MouseEnter);
            this.BackButton.MouseLeave += new System.EventHandler(this.BackButton_MouseLeave);
            // 
            // ControlLabel
            // 
            this.ControlLabel.BackColor = System.Drawing.Color.White;
            this.ControlLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ControlLabel.Location = new System.Drawing.Point(0, 0);
            this.ControlLabel.Name = "ControlLabel";
            this.ControlLabel.Size = new System.Drawing.Size(760, 32);
            this.ControlLabel.TabIndex = 1;
            this.ControlLabel.Text = "Полученные";
            this.ControlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserPicture
            // 
            this.UserPicture.BackColor = System.Drawing.Color.White;
            this.UserPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserPicture.Dock = System.Windows.Forms.DockStyle.Right;
            this.UserPicture.Image = ((System.Drawing.Image)(resources.GetObject("UserPicture.Image")));
            this.UserPicture.Location = new System.Drawing.Point(760, 0);
            this.UserPicture.Name = "UserPicture";
            this.UserPicture.Size = new System.Drawing.Size(39, 39);
            this.UserPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPicture.TabIndex = 0;
            this.UserPicture.TabStop = false;
            this.UserPicture.Click += new System.EventHandler(this.UserPicture_Click);
            // 
            // OpenMainMenuAnim
            // 
            this.OpenMainMenuAnim.Interval = 2;
            this.OpenMainMenuAnim.Tick += new System.EventHandler(this.OpenMainMenuAnim_Tick);
            // 
            // CloseMainMenuAnim
            // 
            this.CloseMainMenuAnim.Interval = 2;
            this.CloseMainMenuAnim.Tick += new System.EventHandler(this.CloseMainMenuAnim_Tick);
            // 
            // UpdateMessagesTimer
            // 
            this.UpdateMessagesTimer.Interval = 6000;
            this.UpdateMessagesTimer.Tick += new System.EventHandler(this.UpdateMessagesTimer_Tick);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainMenu.Controls.Add(this.DraftMessagesLabel);
            this.MainMenu.Controls.Add(this.WriteMsgLabel);
            this.MainMenu.Controls.Add(this.DraftMessagesButton);
            this.MainMenu.Controls.Add(this.MainMenuButton);
            this.MainMenu.Controls.Add(this.SentMessagesLabel);
            this.MainMenu.Controls.Add(this.MainMenuLabel);
            this.MainMenu.Controls.Add(this.SentMessagesButton);
            this.MainMenu.Controls.Add(this.WriteMsgButton);
            this.MainMenu.Controls.Add(this.ReceivedMessageLabel);
            this.MainMenu.Controls.Add(this.ReceivedMessagesButton);
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(140, 583);
            this.MainMenu.TabIndex = 2;
            // 
            // DraftMessagesLabel
            // 
            this.DraftMessagesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DraftMessagesLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DraftMessagesLabel.Location = new System.Drawing.Point(39, 173);
            this.DraftMessagesLabel.Name = "DraftMessagesLabel";
            this.DraftMessagesLabel.Size = new System.Drawing.Size(100, 20);
            this.DraftMessagesLabel.TabIndex = 9;
            this.DraftMessagesLabel.Text = "Черновики";
            this.DraftMessagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DraftMessagesLabel.Click += new System.EventHandler(this.DraftMessagesButton_Click);
            this.DraftMessagesLabel.MouseEnter += new System.EventHandler(this.DraftMessagesButton_MouseEnter);
            this.DraftMessagesLabel.MouseLeave += new System.EventHandler(this.DraftMessagesButton_MouseLeave);
            // 
            // WriteMsgLabel
            // 
            this.WriteMsgLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WriteMsgLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WriteMsgLabel.Location = new System.Drawing.Point(39, 43);
            this.WriteMsgLabel.Name = "WriteMsgLabel";
            this.WriteMsgLabel.Size = new System.Drawing.Size(98, 34);
            this.WriteMsgLabel.TabIndex = 3;
            this.WriteMsgLabel.Text = "Написать сообщение";
            this.WriteMsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WriteMsgLabel.Click += new System.EventHandler(this.WriteMsgButton_Click);
            this.WriteMsgLabel.MouseEnter += new System.EventHandler(this.WriteMsgButton_MouseEnter);
            this.WriteMsgLabel.MouseLeave += new System.EventHandler(this.WriteMsgButton_MouseLeave);
            // 
            // DraftMessagesButton
            // 
            this.DraftMessagesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DraftMessagesButton.Image = global::Client.Properties.Resources.DraftMessagesImg;
            this.DraftMessagesButton.Location = new System.Drawing.Point(10, 173);
            this.DraftMessagesButton.Name = "DraftMessagesButton";
            this.DraftMessagesButton.Size = new System.Drawing.Size(20, 20);
            this.DraftMessagesButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DraftMessagesButton.TabIndex = 8;
            this.DraftMessagesButton.TabStop = false;
            this.DraftMessagesButton.Click += new System.EventHandler(this.DraftMessagesButton_Click);
            this.DraftMessagesButton.MouseEnter += new System.EventHandler(this.DraftMessagesButton_MouseEnter);
            this.DraftMessagesButton.MouseLeave += new System.EventHandler(this.DraftMessagesButton_MouseLeave);
            // 
            // MainMenuButton
            // 
            this.MainMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("MainMenuButton.Image")));
            this.MainMenuButton.Location = new System.Drawing.Point(10, 9);
            this.MainMenuButton.Name = "MainMenuButton";
            this.MainMenuButton.Size = new System.Drawing.Size(20, 20);
            this.MainMenuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainMenuButton.TabIndex = 0;
            this.MainMenuButton.TabStop = false;
            this.MainMenuButton.Click += new System.EventHandler(this.MainMenuButton_Click);
            this.MainMenuButton.MouseEnter += new System.EventHandler(this.MainMenuButton_MouseEnter);
            this.MainMenuButton.MouseLeave += new System.EventHandler(this.MainMenuButton_MouseLeave);
            // 
            // SentMessagesLabel
            // 
            this.SentMessagesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SentMessagesLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SentMessagesLabel.Location = new System.Drawing.Point(39, 132);
            this.SentMessagesLabel.Name = "SentMessagesLabel";
            this.SentMessagesLabel.Size = new System.Drawing.Size(100, 20);
            this.SentMessagesLabel.TabIndex = 7;
            this.SentMessagesLabel.Text = "Отправленные";
            this.SentMessagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SentMessagesLabel.Click += new System.EventHandler(this.SentMessagesButton_Click);
            this.SentMessagesLabel.MouseEnter += new System.EventHandler(this.SentMessagesButton_MouseEnter);
            this.SentMessagesLabel.MouseLeave += new System.EventHandler(this.SentMessagesButton_MouseLeave);
            // 
            // MainMenuLabel
            // 
            this.MainMenuLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainMenuLabel.Location = new System.Drawing.Point(39, 9);
            this.MainMenuLabel.Name = "MainMenuLabel";
            this.MainMenuLabel.Size = new System.Drawing.Size(95, 20);
            this.MainMenuLabel.TabIndex = 1;
            this.MainMenuLabel.Text = "Главное меню";
            this.MainMenuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainMenuLabel.Click += new System.EventHandler(this.MainMenuButton_Click);
            this.MainMenuLabel.MouseEnter += new System.EventHandler(this.MainMenuButton_MouseEnter);
            this.MainMenuLabel.MouseLeave += new System.EventHandler(this.MainMenuButton_MouseLeave);
            // 
            // SentMessagesButton
            // 
            this.SentMessagesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SentMessagesButton.Image = global::Client.Properties.Resources.SentMessagesImg;
            this.SentMessagesButton.Location = new System.Drawing.Point(10, 132);
            this.SentMessagesButton.Name = "SentMessagesButton";
            this.SentMessagesButton.Size = new System.Drawing.Size(20, 20);
            this.SentMessagesButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SentMessagesButton.TabIndex = 6;
            this.SentMessagesButton.TabStop = false;
            this.SentMessagesButton.Click += new System.EventHandler(this.SentMessagesButton_Click);
            this.SentMessagesButton.MouseEnter += new System.EventHandler(this.SentMessagesButton_MouseEnter);
            this.SentMessagesButton.MouseLeave += new System.EventHandler(this.SentMessagesButton_MouseLeave);
            // 
            // WriteMsgButton
            // 
            this.WriteMsgButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WriteMsgButton.Image = ((System.Drawing.Image)(resources.GetObject("WriteMsgButton.Image")));
            this.WriteMsgButton.Location = new System.Drawing.Point(10, 50);
            this.WriteMsgButton.Name = "WriteMsgButton";
            this.WriteMsgButton.Size = new System.Drawing.Size(20, 20);
            this.WriteMsgButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WriteMsgButton.TabIndex = 2;
            this.WriteMsgButton.TabStop = false;
            this.WriteMsgButton.Click += new System.EventHandler(this.WriteMsgButton_Click);
            this.WriteMsgButton.MouseEnter += new System.EventHandler(this.WriteMsgButton_MouseEnter);
            this.WriteMsgButton.MouseLeave += new System.EventHandler(this.WriteMsgButton_MouseLeave);
            // 
            // ReceivedMessageLabel
            // 
            this.ReceivedMessageLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReceivedMessageLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReceivedMessageLabel.Location = new System.Drawing.Point(39, 91);
            this.ReceivedMessageLabel.Name = "ReceivedMessageLabel";
            this.ReceivedMessageLabel.Size = new System.Drawing.Size(100, 20);
            this.ReceivedMessageLabel.TabIndex = 5;
            this.ReceivedMessageLabel.Text = "Полученные";
            this.ReceivedMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReceivedMessageLabel.Click += new System.EventHandler(this.ReceivedMessagesButton_Click);
            this.ReceivedMessageLabel.MouseEnter += new System.EventHandler(this.ReceivedMessagesButton_MouseEnter);
            this.ReceivedMessageLabel.MouseLeave += new System.EventHandler(this.ReceivedMessagesButton_MouseLeave);
            // 
            // ReceivedMessagesButton
            // 
            this.ReceivedMessagesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReceivedMessagesButton.Image = global::Client.Properties.Resources.ReceivedMessagesImg;
            this.ReceivedMessagesButton.Location = new System.Drawing.Point(10, 91);
            this.ReceivedMessagesButton.Name = "ReceivedMessagesButton";
            this.ReceivedMessagesButton.Size = new System.Drawing.Size(20, 20);
            this.ReceivedMessagesButton.TabIndex = 4;
            this.ReceivedMessagesButton.TabStop = false;
            this.ReceivedMessagesButton.Click += new System.EventHandler(this.ReceivedMessagesButton_Click);
            this.ReceivedMessagesButton.MouseEnter += new System.EventHandler(this.ReceivedMessagesButton_MouseEnter);
            this.ReceivedMessagesButton.MouseLeave += new System.EventHandler(this.ReceivedMessagesButton_MouseLeave);
            // 
            // UserPanel
            // 
            this.UserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserPanel.BackColor = System.Drawing.Color.Silver;
            this.UserPanel.Controls.Add(this.SignOutLabel);
            this.UserPanel.Controls.Add(this.UsernameLabel);
            this.UserPanel.CornerRadius = 13;
            this.UserPanel.Location = new System.Drawing.Point(782, 40);
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
            this.SignOutLabel.Size = new System.Drawing.Size(39, 13);
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
            // ClientApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 583);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.UserPanel);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ClientApp";
            this.Text = "ClientApp";
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteSelectedButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).EndInit();
            this.MainMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DraftMessagesButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenuButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SentMessagesButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WriteMsgButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedMessagesButton)).EndInit();
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ControlPanel;
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
        private System.Windows.Forms.Label ReceivedMessageLabel;
        private System.Windows.Forms.PictureBox ReceivedMessagesButton;
        private System.Windows.Forms.Label SentMessagesLabel;
        private System.Windows.Forms.PictureBox SentMessagesButton;
        private System.Windows.Forms.Label DraftMessagesLabel;
        private System.Windows.Forms.PictureBox DraftMessagesButton;
        private System.Windows.Forms.Label ControlLabel;
        private System.Windows.Forms.PictureBox BackButton;
        private System.Windows.Forms.PictureBox DeleteButton;
        private System.Windows.Forms.Timer UpdateMessagesTimer;
        private Panel MainMenu;
        private System.Windows.Forms.PictureBox DeleteSelectedButton;
        private System.Windows.Forms.CheckBox SelectAllCB;
    }
}

