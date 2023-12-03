namespace Client
{
    partial class MessageWriter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageWriter));
            this.ToTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ThemeTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MsgContentTB = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.PictureBox();
            this.ItalicStyle = new System.Windows.Forms.Button();
            this.BoldStyle = new System.Windows.Forms.Button();
            this.UnderlineStyle = new System.Windows.Forms.Button();
            this.AlignLeft = new System.Windows.Forms.Button();
            this.AlignCenter = new System.Windows.Forms.Button();
            this.AlignRight = new System.Windows.Forms.Button();
            this.ToInputErrorLabel = new System.Windows.Forms.Label();
            this.ThemeInputErrorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SendButton)).BeginInit();
            this.SuspendLayout();
            // 
            // ToTB
            // 
            this.ToTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToTB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToTB.Location = new System.Drawing.Point(62, 11);
            this.ToTB.Name = "ToTB";
            this.ToTB.Size = new System.Drawing.Size(451, 21);
            this.ToTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Кому:";
            // 
            // ThemeTB
            // 
            this.ThemeTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThemeTB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThemeTB.Location = new System.Drawing.Point(62, 49);
            this.ThemeTB.Name = "ThemeTB";
            this.ThemeTB.Size = new System.Drawing.Size(451, 21);
            this.ThemeTB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тема:";
            // 
            // MsgContentTB
            // 
            this.MsgContentTB.AcceptsTab = true;
            this.MsgContentTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgContentTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MsgContentTB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MsgContentTB.HideSelection = false;
            this.MsgContentTB.Location = new System.Drawing.Point(13, 90);
            this.MsgContentTB.Name = "MsgContentTB";
            this.MsgContentTB.Size = new System.Drawing.Size(500, 211);
            this.MsgContentTB.TabIndex = 4;
            this.MsgContentTB.Text = "";
            // 
            // SendButton
            // 
            this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendButton.Image = ((System.Drawing.Image)(resources.GetObject("SendButton.Image")));
            this.SendButton.Location = new System.Drawing.Point(415, 307);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(98, 42);
            this.SendButton.TabIndex = 11;
            this.SendButton.TabStop = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ItalicStyle
            // 
            this.ItalicStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ItalicStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ItalicStyle.Image = global::Client.Properties.Resources.ItalicStyle;
            this.ItalicStyle.Location = new System.Drawing.Point(108, 307);
            this.ItalicStyle.Name = "ItalicStyle";
            this.ItalicStyle.Size = new System.Drawing.Size(42, 42);
            this.ItalicStyle.TabIndex = 10;
            this.ItalicStyle.UseVisualStyleBackColor = true;
            this.ItalicStyle.Click += new System.EventHandler(this.ItalicStyle_Click);
            // 
            // BoldStyle
            // 
            this.BoldStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BoldStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BoldStyle.Image = global::Client.Properties.Resources.BoldStyle;
            this.BoldStyle.Location = new System.Drawing.Point(12, 307);
            this.BoldStyle.Name = "BoldStyle";
            this.BoldStyle.Size = new System.Drawing.Size(42, 42);
            this.BoldStyle.TabIndex = 9;
            this.BoldStyle.UseVisualStyleBackColor = true;
            this.BoldStyle.Click += new System.EventHandler(this.BoldStyle_Click);
            // 
            // UnderlineStyle
            // 
            this.UnderlineStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UnderlineStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UnderlineStyle.Image = global::Client.Properties.Resources.UnderlineStyle;
            this.UnderlineStyle.Location = new System.Drawing.Point(60, 307);
            this.UnderlineStyle.Name = "UnderlineStyle";
            this.UnderlineStyle.Size = new System.Drawing.Size(42, 42);
            this.UnderlineStyle.TabIndex = 8;
            this.UnderlineStyle.UseVisualStyleBackColor = true;
            this.UnderlineStyle.Click += new System.EventHandler(this.UnderlineStyle_Click);
            // 
            // AlignLeft
            // 
            this.AlignLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AlignLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("AlignLeft.Image")));
            this.AlignLeft.Location = new System.Drawing.Point(156, 307);
            this.AlignLeft.Name = "AlignLeft";
            this.AlignLeft.Size = new System.Drawing.Size(42, 42);
            this.AlignLeft.TabIndex = 7;
            this.AlignLeft.UseVisualStyleBackColor = true;
            this.AlignLeft.Click += new System.EventHandler(this.AlignLeft_Click);
            // 
            // AlignCenter
            // 
            this.AlignCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AlignCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("AlignCenter.Image")));
            this.AlignCenter.Location = new System.Drawing.Point(204, 307);
            this.AlignCenter.Name = "AlignCenter";
            this.AlignCenter.Size = new System.Drawing.Size(42, 42);
            this.AlignCenter.TabIndex = 6;
            this.AlignCenter.UseVisualStyleBackColor = true;
            this.AlignCenter.Click += new System.EventHandler(this.AlignCenter_Click);
            // 
            // AlignRight
            // 
            this.AlignRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AlignRight.BackColor = System.Drawing.Color.Transparent;
            this.AlignRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AlignRight.Image = ((System.Drawing.Image)(resources.GetObject("AlignRight.Image")));
            this.AlignRight.Location = new System.Drawing.Point(252, 307);
            this.AlignRight.Name = "AlignRight";
            this.AlignRight.Size = new System.Drawing.Size(42, 42);
            this.AlignRight.TabIndex = 5;
            this.AlignRight.UseVisualStyleBackColor = false;
            this.AlignRight.Click += new System.EventHandler(this.AlignRight_Click);
            // 
            // ToInputErrorLabel
            // 
            this.ToInputErrorLabel.AutoSize = true;
            this.ToInputErrorLabel.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToInputErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ToInputErrorLabel.Location = new System.Drawing.Point(59, 31);
            this.ToInputErrorLabel.Name = "ToInputErrorLabel";
            this.ToInputErrorLabel.Size = new System.Drawing.Size(0, 15);
            this.ToInputErrorLabel.TabIndex = 12;
            // 
            // ThemeInputErrorLabel
            // 
            this.ThemeInputErrorLabel.AutoSize = true;
            this.ThemeInputErrorLabel.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThemeInputErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ThemeInputErrorLabel.Location = new System.Drawing.Point(59, 73);
            this.ThemeInputErrorLabel.Name = "ThemeInputErrorLabel";
            this.ThemeInputErrorLabel.Size = new System.Drawing.Size(0, 15);
            this.ThemeInputErrorLabel.TabIndex = 13;
            // 
            // MessageWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(525, 359);
            this.Controls.Add(this.ThemeInputErrorLabel);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ItalicStyle);
            this.Controls.Add(this.BoldStyle);
            this.Controls.Add(this.UnderlineStyle);
            this.Controls.Add(this.AlignLeft);
            this.Controls.Add(this.AlignCenter);
            this.Controls.Add(this.AlignRight);
            this.Controls.Add(this.MsgContentTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ThemeTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToTB);
            this.Controls.Add(this.ToInputErrorLabel);
            this.MinimumSize = new System.Drawing.Size(427, 267);
            this.Name = "MessageWriter";
            this.ShowIcon = false;
            this.Text = "Новое письмо";
            ((System.ComponentModel.ISupportInitialize)(this.SendButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ToTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ThemeTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox MsgContentTB;
        private System.Windows.Forms.Button AlignRight;
        private System.Windows.Forms.Button AlignCenter;
        private System.Windows.Forms.Button AlignLeft;
        private System.Windows.Forms.Button UnderlineStyle;
        private System.Windows.Forms.Button BoldStyle;
        private System.Windows.Forms.Button ItalicStyle;
        private System.Windows.Forms.PictureBox SendButton;
        private System.Windows.Forms.Label ToInputErrorLabel;
        private System.Windows.Forms.Label ThemeInputErrorLabel;
    }
}