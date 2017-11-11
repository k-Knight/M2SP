namespace m2sp {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.showStatsBtn = new System.Windows.Forms.Button();
            this.resetStatsBtn = new System.Windows.Forms.Button();
            this.spellEnterLabel = new System.Windows.Forms.Label();
            this.spellDisplayLabel = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.separator = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.listMagicksButton = new System.Windows.Forms.Button();
            this.spellBoxPanel = new System.Windows.Forms.Panel();
            this.magickPicture = new m2sp.ElemPictureBox();
            this.elemSlotPic5 = new m2sp.ElemPictureBox();
            this.elemSlotPic4 = new m2sp.ElemPictureBox();
            this.elemSlotPic3 = new m2sp.ElemPictureBox();
            this.elemSlotPic2 = new m2sp.ElemPictureBox();
            this.elemSlotPic1 = new m2sp.ElemPictureBox();
            this.spellTextBox = new m2sp.SpellTextBox();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.magickPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic1)).BeginInit();
            this.SuspendLayout();
            // 
            // showStatsBtn
            // 
            this.showStatsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showStatsBtn.Font = new System.Drawing.Font("Ubuntu Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showStatsBtn.Location = new System.Drawing.Point(210, 296);
            this.showStatsBtn.Name = "showStatsBtn";
            this.showStatsBtn.Size = new System.Drawing.Size(120, 35);
            this.showStatsBtn.TabIndex = 0;
            this.showStatsBtn.TabStop = false;
            this.showStatsBtn.Text = "show stats";
            this.showStatsBtn.UseVisualStyleBackColor = true;
            this.showStatsBtn.Click += new System.EventHandler(this.showStatsBtn_Click);
            // 
            // resetStatsBtn
            // 
            this.resetStatsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetStatsBtn.Font = new System.Drawing.Font("Ubuntu Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetStatsBtn.Location = new System.Drawing.Point(22, 296);
            this.resetStatsBtn.Name = "resetStatsBtn";
            this.resetStatsBtn.Size = new System.Drawing.Size(120, 35);
            this.resetStatsBtn.TabIndex = 1;
            this.resetStatsBtn.TabStop = false;
            this.resetStatsBtn.Text = "reset stats";
            this.resetStatsBtn.UseVisualStyleBackColor = true;
            this.resetStatsBtn.Click += new System.EventHandler(this.resetStatsBtn_Click);
            // 
            // spellEnterLabel
            // 
            this.spellEnterLabel.AutoSize = true;
            this.spellEnterLabel.Font = new System.Drawing.Font("Ubuntu Mono", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spellEnterLabel.Location = new System.Drawing.Point(48, 194);
            this.spellEnterLabel.Name = "spellEnterLabel";
            this.spellEnterLabel.Size = new System.Drawing.Size(207, 33);
            this.spellEnterLabel.TabIndex = 2;
            this.spellEnterLabel.Text = "Enter spell:";
            // 
            // spellDisplayLabel
            // 
            this.spellDisplayLabel.AutoSize = true;
            this.spellDisplayLabel.BackColor = System.Drawing.Color.Transparent;
            this.spellDisplayLabel.Font = new System.Drawing.Font("Ubuntu Mono", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spellDisplayLabel.Location = new System.Drawing.Point(16, 44);
            this.spellDisplayLabel.Name = "spellDisplayLabel";
            this.spellDisplayLabel.Size = new System.Drawing.Size(271, 33);
            this.spellDisplayLabel.TabIndex = 4;
            this.spellDisplayLabel.Text = "Resulting spell:";
            // 
            // minimizeButton
            // 
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minimizeButton.Location = new System.Drawing.Point(286, 8);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(24, 23);
            this.minimizeButton.TabIndex = 10;
            this.minimizeButton.TabStop = false;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(316, 8);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(24, 23);
            this.closeButton.TabIndex = 11;
            this.closeButton.TabStop = false;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // separator
            // 
            this.separator.Location = new System.Drawing.Point(4, 38);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(343, 2);
            this.separator.TabIndex = 12;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel.Controls.Add(this.listMagicksButton);
            this.menuPanel.Controls.Add(this.closeButton);
            this.menuPanel.Controls.Add(this.minimizeButton);
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(350, 40);
            this.menuPanel.TabIndex = 13;
            // 
            // listMagicksButton
            // 
            this.listMagicksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listMagicksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listMagicksButton.Location = new System.Drawing.Point(12, 6);
            this.listMagicksButton.Name = "listMagicksButton";
            this.listMagicksButton.Size = new System.Drawing.Size(120, 31);
            this.listMagicksButton.TabIndex = 12;
            this.listMagicksButton.TabStop = false;
            this.listMagicksButton.Text = "list magicks";
            this.listMagicksButton.UseVisualStyleBackColor = true;
            this.listMagicksButton.Click += new System.EventHandler(this.listMagicksButton_Click);
            // 
            // spellBoxPanel
            // 
            this.spellBoxPanel.Location = new System.Drawing.Point(40, 245);
            this.spellBoxPanel.Name = "spellBoxPanel";
            this.spellBoxPanel.Size = new System.Drawing.Size(277, 35);
            this.spellBoxPanel.TabIndex = 14;
            // 
            // magickPicture
            // 
            this.magickPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(150)))));
            this.magickPicture.Location = new System.Drawing.Point(198, 147);
            this.magickPicture.MaximumSize = new System.Drawing.Size(90, 90);
            this.magickPicture.MinimumSize = new System.Drawing.Size(90, 90);
            this.magickPicture.Name = "magickPicture";
            this.magickPicture.Padding = new System.Windows.Forms.Padding(3);
            this.magickPicture.Size = new System.Drawing.Size(90, 90);
            this.magickPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.magickPicture.TabIndex = 15;
            this.magickPicture.TabStop = false;
            // 
            // elemSlotPic5
            // 
            this.elemSlotPic5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(150)))));
            this.elemSlotPic5.Location = new System.Drawing.Point(279, 80);
            this.elemSlotPic5.MaximumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic5.MinimumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic5.Name = "elemSlotPic5";
            this.elemSlotPic5.Padding = new System.Windows.Forms.Padding(3);
            this.elemSlotPic5.Size = new System.Drawing.Size(54, 54);
            this.elemSlotPic5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.elemSlotPic5.TabIndex = 9;
            this.elemSlotPic5.TabStop = false;
            // 
            // elemSlotPic4
            // 
            this.elemSlotPic4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(150)))));
            this.elemSlotPic4.Location = new System.Drawing.Point(214, 80);
            this.elemSlotPic4.MaximumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic4.MinimumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic4.Name = "elemSlotPic4";
            this.elemSlotPic4.Padding = new System.Windows.Forms.Padding(3);
            this.elemSlotPic4.Size = new System.Drawing.Size(54, 54);
            this.elemSlotPic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.elemSlotPic4.TabIndex = 8;
            this.elemSlotPic4.TabStop = false;
            // 
            // elemSlotPic3
            // 
            this.elemSlotPic3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(150)))));
            this.elemSlotPic3.Location = new System.Drawing.Point(149, 80);
            this.elemSlotPic3.MaximumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic3.MinimumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic3.Name = "elemSlotPic3";
            this.elemSlotPic3.Padding = new System.Windows.Forms.Padding(3);
            this.elemSlotPic3.Size = new System.Drawing.Size(54, 54);
            this.elemSlotPic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.elemSlotPic3.TabIndex = 7;
            this.elemSlotPic3.TabStop = false;
            // 
            // elemSlotPic2
            // 
            this.elemSlotPic2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(150)))));
            this.elemSlotPic2.Location = new System.Drawing.Point(84, 80);
            this.elemSlotPic2.MaximumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic2.MinimumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic2.Name = "elemSlotPic2";
            this.elemSlotPic2.Padding = new System.Windows.Forms.Padding(3);
            this.elemSlotPic2.Size = new System.Drawing.Size(54, 54);
            this.elemSlotPic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.elemSlotPic2.TabIndex = 6;
            this.elemSlotPic2.TabStop = false;
            // 
            // elemSlotPic1
            // 
            this.elemSlotPic1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(150)))));
            this.elemSlotPic1.ImageLocation = "";
            this.elemSlotPic1.Location = new System.Drawing.Point(19, 80);
            this.elemSlotPic1.MaximumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic1.MinimumSize = new System.Drawing.Size(54, 54);
            this.elemSlotPic1.Name = "elemSlotPic1";
            this.elemSlotPic1.Padding = new System.Windows.Forms.Padding(3);
            this.elemSlotPic1.Size = new System.Drawing.Size(54, 54);
            this.elemSlotPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.elemSlotPic1.TabIndex = 5;
            this.elemSlotPic1.TabStop = false;
            // 
            // spellTextBox
            // 
            this.spellTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.spellTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spellTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.spellTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.spellTextBox.Location = new System.Drawing.Point(45, 250);
            this.spellTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.spellTextBox.Name = "spellTextBox";
            this.spellTextBox.Size = new System.Drawing.Size(267, 25);
            this.spellTextBox.TabIndex = 3;
            this.spellTextBox.TabStop = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.ControlBox = false;
            this.Controls.Add(this.magickPicture);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.elemSlotPic5);
            this.Controls.Add(this.elemSlotPic4);
            this.Controls.Add(this.elemSlotPic3);
            this.Controls.Add(this.elemSlotPic2);
            this.Controls.Add(this.elemSlotPic1);
            this.Controls.Add(this.spellDisplayLabel);
            this.Controls.Add(this.spellTextBox);
            this.Controls.Add(this.spellEnterLabel);
            this.Controls.Add(this.resetStatsBtn);
            this.Controls.Add(this.showStatsBtn);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.spellBoxPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 350);
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "mainForm";
            this.Text = "Magicka 2 Spellcasting Practice";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.magickPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elemSlotPic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showStatsBtn;
        private System.Windows.Forms.Button resetStatsBtn;
        private System.Windows.Forms.Label spellEnterLabel;
        private SpellTextBox spellTextBox;
        private System.Windows.Forms.Label spellDisplayLabel;
        private ElemPictureBox elemSlotPic1;
        private ElemPictureBox elemSlotPic2;
        private ElemPictureBox elemSlotPic3;
        private ElemPictureBox elemSlotPic4;
        private ElemPictureBox elemSlotPic5;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel spellBoxPanel;
        private ElemPictureBox magickPicture;
        private System.Windows.Forms.Button listMagicksButton;
    }
}

