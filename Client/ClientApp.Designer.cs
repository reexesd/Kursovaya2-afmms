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
            this.WriteMsgLabel = new System.Windows.Forms.Label();
            this.WriteMsgButton = new System.Windows.Forms.PictureBox();
            this.MainMenuLabel = new System.Windows.Forms.Label();
            this.MainMenuButton = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UserPicture = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OpenMainMenuAnim = new System.Windows.Forms.Timer(this.components);
            this.CloseMainMenuAnim = new System.Windows.Forms.Timer(this.components);
            this.mailControl2 = new Client.MailControl();
            this.mailControl1 = new Client.MailControl();
            this.UserPanel = new Client.UserPanel();
            this.SignOutLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WriteMsgButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenuButton)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).BeginInit();
            this.panel3.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainMenu.Controls.Add(this.WriteMsgLabel);
            this.MainMenu.Controls.Add(this.WriteMsgButton);
            this.MainMenu.Controls.Add(this.MainMenuLabel);
            this.MainMenu.Controls.Add(this.MainMenuButton);
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(140, 573);
            this.MainMenu.TabIndex = 0;
            // 
            // WriteMsgLabel
            // 
            this.WriteMsgLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WriteMsgLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WriteMsgLabel.Location = new System.Drawing.Point(35, 44);
            this.WriteMsgLabel.Name = "WriteMsgLabel";
            this.WriteMsgLabel.Size = new System.Drawing.Size(104, 34);
            this.WriteMsgLabel.TabIndex = 3;
            this.WriteMsgLabel.Text = "Написать сообщение";
            this.WriteMsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WriteMsgLabel.Click += new System.EventHandler(this.WriteMsgButton_Click);
            // 
            // WriteMsgButton
            // 
            this.WriteMsgButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WriteMsgButton.Image = global::Client.Properties.Resources.WriteMsg;
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
            // MainMenuLabel
            // 
            this.MainMenuLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuLabel.Location = new System.Drawing.Point(35, 9);
            this.MainMenuLabel.Name = "MainMenuLabel";
            this.MainMenuLabel.Size = new System.Drawing.Size(103, 20);
            this.MainMenuLabel.TabIndex = 1;
            this.MainMenuLabel.Text = "Главное меню";
            this.MainMenuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MainMenuLabel.DoubleClick += new System.EventHandler(this.MainMenuButton_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.UserPicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(140, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(761, 39);
            this.panel2.TabIndex = 1;
            // 
            // UserPicture
            // 
            this.UserPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserPicture.Image = ((System.Drawing.Image)(resources.GetObject("UserPicture.Image")));
            this.UserPicture.Location = new System.Drawing.Point(722, 0);
            this.UserPicture.Name = "UserPicture";
            this.UserPicture.Size = new System.Drawing.Size(39, 39);
            this.UserPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPicture.TabIndex = 0;
            this.UserPicture.TabStop = false;
            this.UserPicture.Click += new System.EventHandler(this.UserPicture_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.mailControl2);
            this.panel3.Controls.Add(this.mailControl1);
            this.panel3.Controls.Add(this.UserPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel3.Location = new System.Drawing.Point(140, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(761, 534);
            this.panel3.TabIndex = 2;
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
            // mailControl2
            // 
            this.mailControl2.BorderColor = System.Drawing.Color.LightGray;
            this.mailControl2.BorderWidth = 1;
            this.mailControl2.Content = "Content";
            this.mailControl2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mailControl2.Date = new System.DateTime(2023, 12, 22, 0, 0, 0, 0);
            this.mailControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.mailControl2.From = "Admin";
            this.mailControl2.IsBorderCreate = true;
            this.mailControl2.Location = new System.Drawing.Point(0, 30);
            this.mailControl2.MinimumSize = new System.Drawing.Size(15, 14);
            this.mailControl2.Name = "mailControl2";
            this.mailControl2.Opacity = 255;
            this.mailControl2.Size = new System.Drawing.Size(759, 30);
            this.mailControl2.TabIndex = 3;
            this.mailControl2.Text = "mailControl2";
            this.mailControl2.Theme = "Theme";
            // 
            // mailControl1
            // 
            this.mailControl1.BorderColor = System.Drawing.Color.LightGray;
            this.mailControl1.BorderWidth = 1;
            this.mailControl1.Content = "Content";
            this.mailControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mailControl1.Date = new System.DateTime(2023, 12, 11, 0, 0, 0, 0);
            this.mailControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mailControl1.From = "Admin";
            this.mailControl1.IsBorderCreate = true;
            this.mailControl1.Location = new System.Drawing.Point(0, 0);
            this.mailControl1.MinimumSize = new System.Drawing.Size(15, 14);
            this.mailControl1.Name = "mailControl1";
            this.mailControl1.Opacity = 255;
            this.mailControl1.Size = new System.Drawing.Size(759, 30);
            this.mailControl1.TabIndex = 2;
            this.mailControl1.Text = "mailControl1";
            this.mailControl1.Theme = "Theme";
            // 
            // UserPanel
            // 
            this.UserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserPanel.BackColor = System.Drawing.Color.Silver;
            this.UserPanel.Controls.Add(this.SignOutLabel);
            this.UserPanel.Controls.Add(this.UsernameLabel);
            this.UserPanel.CornerRadius = 13;
            this.UserPanel.Location = new System.Drawing.Point(602, 0);
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
            // ClientApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 573);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MainMenu);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ClientApp";
            this.Text = "ClientApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WriteMsgButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenuButton)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).EndInit();
            this.panel3.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
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
        private MailControl mailControl1;
        private MailControl mailControl2;
    }
}

