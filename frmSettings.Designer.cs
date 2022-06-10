namespace Password_Bank
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.rbDarkMode = new System.Windows.Forms.RadioButton();
            this.rbLightMode = new System.Windows.Forms.RadioButton();
            this.gbTheme = new System.Windows.Forms.GroupBox();
            this.gbLoginInfo = new System.Windows.Forms.GroupBox();
            this.pbPassEye = new System.Windows.Forms.PictureBox();
            this.btnUpdateLoginInfo = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCustomize = new System.Windows.Forms.GroupBox();
            this.rbEN = new System.Windows.Forms.RadioButton();
            this.rbTR = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pbPicker = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cd = new System.Windows.Forms.ColorDialog();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbTheme.SuspendLayout();
            this.gbLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassEye)).BeginInit();
            this.gbCustomize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.pnlTopBar.Controls.Add(this.lblLogo);
            this.pnlTopBar.Controls.Add(this.pictureBox1);
            this.pnlTopBar.Controls.Add(this.btnExit);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(379, 35);
            this.pnlTopBar.TabIndex = 2;
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(35, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(180, 35);
            this.lblLogo.TabIndex = 20;
            this.lblLogo.Text = "PASSWORD BANK";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(326, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 35);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rbDarkMode
            // 
            this.rbDarkMode.BackColor = System.Drawing.Color.Transparent;
            this.rbDarkMode.Image = ((System.Drawing.Image)(resources.GetObject("rbDarkMode.Image")));
            this.rbDarkMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbDarkMode.Location = new System.Drawing.Point(13, 24);
            this.rbDarkMode.Name = "rbDarkMode";
            this.rbDarkMode.Size = new System.Drawing.Size(127, 27);
            this.rbDarkMode.TabIndex = 4;
            this.rbDarkMode.TabStop = true;
            this.rbDarkMode.Text = "Dark Mode";
            this.rbDarkMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbDarkMode.UseVisualStyleBackColor = false;
            this.rbDarkMode.CheckedChanged += new System.EventHandler(this.rbDarkMode_CheckedChanged);
            // 
            // rbLightMode
            // 
            this.rbLightMode.BackColor = System.Drawing.Color.Transparent;
            this.rbLightMode.Image = ((System.Drawing.Image)(resources.GetObject("rbLightMode.Image")));
            this.rbLightMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbLightMode.Location = new System.Drawing.Point(13, 57);
            this.rbLightMode.Name = "rbLightMode";
            this.rbLightMode.Size = new System.Drawing.Size(127, 27);
            this.rbLightMode.TabIndex = 5;
            this.rbLightMode.TabStop = true;
            this.rbLightMode.Text = "Light Mode";
            this.rbLightMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbLightMode.UseVisualStyleBackColor = false;
            this.rbLightMode.CheckedChanged += new System.EventHandler(this.rbLightMode_CheckedChanged);
            // 
            // gbTheme
            // 
            this.gbTheme.BackColor = System.Drawing.Color.Transparent;
            this.gbTheme.Controls.Add(this.rbDarkMode);
            this.gbTheme.Controls.Add(this.rbLightMode);
            this.gbTheme.Location = new System.Drawing.Point(12, 41);
            this.gbTheme.Name = "gbTheme";
            this.gbTheme.Size = new System.Drawing.Size(140, 100);
            this.gbTheme.TabIndex = 6;
            this.gbTheme.TabStop = false;
            this.gbTheme.Text = "Theme";
            // 
            // gbLoginInfo
            // 
            this.gbLoginInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbLoginInfo.Controls.Add(this.pbPassEye);
            this.gbLoginInfo.Controls.Add(this.btnUpdateLoginInfo);
            this.gbLoginInfo.Controls.Add(this.txtPassword);
            this.gbLoginInfo.Controls.Add(this.txtEMail);
            this.gbLoginInfo.Controls.Add(this.label2);
            this.gbLoginInfo.Controls.Add(this.label1);
            this.gbLoginInfo.Location = new System.Drawing.Point(12, 147);
            this.gbLoginInfo.Name = "gbLoginInfo";
            this.gbLoginInfo.Size = new System.Drawing.Size(354, 148);
            this.gbLoginInfo.TabIndex = 7;
            this.gbLoginInfo.TabStop = false;
            this.gbLoginInfo.Text = "Login Details";
            // 
            // pbPassEye
            // 
            this.pbPassEye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPassEye.BackColor = System.Drawing.Color.Transparent;
            this.pbPassEye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPassEye.Location = new System.Drawing.Point(317, 56);
            this.pbPassEye.Name = "pbPassEye";
            this.pbPassEye.Size = new System.Drawing.Size(25, 25);
            this.pbPassEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPassEye.TabIndex = 10;
            this.pbPassEye.TabStop = false;
            this.pbPassEye.Click += new System.EventHandler(this.pbPassEye_Click);
            this.pbPassEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPassEye_MouseDown);
            this.pbPassEye.MouseEnter += new System.EventHandler(this.pbPassEye_MouseEnter);
            this.pbPassEye.MouseLeave += new System.EventHandler(this.pbPassEye_MouseLeave);
            this.pbPassEye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPassEye_MouseUp);
            // 
            // btnUpdateLoginInfo
            // 
            this.btnUpdateLoginInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.btnUpdateLoginInfo.FlatAppearance.BorderSize = 0;
            this.btnUpdateLoginInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateLoginInfo.ForeColor = System.Drawing.Color.White;
            this.btnUpdateLoginInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateLoginInfo.Image")));
            this.btnUpdateLoginInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateLoginInfo.Location = new System.Drawing.Point(95, 94);
            this.btnUpdateLoginInfo.Name = "btnUpdateLoginInfo";
            this.btnUpdateLoginInfo.Size = new System.Drawing.Size(165, 40);
            this.btnUpdateLoginInfo.TabIndex = 4;
            this.btnUpdateLoginInfo.Text = "Update Login Info";
            this.btnUpdateLoginInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateLoginInfo.UseVisualStyleBackColor = false;
            this.btnUpdateLoginInfo.Click += new System.EventHandler(this.btnUpdateLoginInfo_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(127, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(184, 25);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEMail
            // 
            this.txtEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEMail.BackColor = System.Drawing.Color.White;
            this.txtEMail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEMail.ForeColor = System.Drawing.Color.Black;
            this.txtEMail.Location = new System.Drawing.Point(127, 25);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(215, 25);
            this.txtEMail.TabIndex = 2;
            this.txtEMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEMail_KeyPress);
            this.txtEMail.Leave += new System.EventHandler(this.txtEMail_Leave);
            // 
            // label2
            // 
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-Mail:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbCustomize
            // 
            this.gbCustomize.BackColor = System.Drawing.Color.Transparent;
            this.gbCustomize.Controls.Add(this.rbEN);
            this.gbCustomize.Controls.Add(this.rbTR);
            this.gbCustomize.Controls.Add(this.label4);
            this.gbCustomize.Controls.Add(this.pbPicker);
            this.gbCustomize.Controls.Add(this.label3);
            this.gbCustomize.Location = new System.Drawing.Point(158, 41);
            this.gbCustomize.Name = "gbCustomize";
            this.gbCustomize.Size = new System.Drawing.Size(208, 100);
            this.gbCustomize.TabIndex = 8;
            this.gbCustomize.TabStop = false;
            this.gbCustomize.Text = "Customize";
            // 
            // rbEN
            // 
            this.rbEN.AutoSize = true;
            this.rbEN.Location = new System.Drawing.Point(108, 60);
            this.rbEN.Name = "rbEN";
            this.rbEN.Size = new System.Drawing.Size(43, 21);
            this.rbEN.TabIndex = 4;
            this.rbEN.TabStop = true;
            this.rbEN.Text = "EN";
            this.rbEN.UseVisualStyleBackColor = true;
            this.rbEN.CheckedChanged += new System.EventHandler(this.rbEN_CheckedChanged);
            // 
            // rbTR
            // 
            this.rbTR.AutoSize = true;
            this.rbTR.Location = new System.Drawing.Point(157, 60);
            this.rbTR.Name = "rbTR";
            this.rbTR.Size = new System.Drawing.Size(41, 21);
            this.rbTR.TabIndex = 3;
            this.rbTR.TabStop = true;
            this.rbTR.Text = "TR";
            this.rbTR.UseVisualStyleBackColor = true;
            this.rbTR.CheckedChanged += new System.EventHandler(this.rbTR_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "Language:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbPicker
            // 
            this.pbPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.pbPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPicker.Location = new System.Drawing.Point(137, 24);
            this.pbPicker.Name = "pbPicker";
            this.pbPicker.Size = new System.Drawing.Size(27, 27);
            this.pbPicker.TabIndex = 1;
            this.pbPicker.TabStop = false;
            this.pbPicker.Click += new System.EventHandler(this.pbPicker_Click);
            // 
            // label3
            // 
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Color Scheme:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd
            // 
            this.cd.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.cd.FullOpen = true;
            // 
            // frmSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 305);
            this.Controls.Add(this.gbCustomize);
            this.Controls.Add(this.gbLoginInfo);
            this.Controls.Add(this.gbTheme);
            this.Controls.Add(this.pnlTopBar);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Bank";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.pnlTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbTheme.ResumeLayout(false);
            this.gbLoginInfo.ResumeLayout(false);
            this.gbLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassEye)).EndInit();
            this.gbCustomize.ResumeLayout(false);
            this.gbCustomize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rbDarkMode;
        private System.Windows.Forms.RadioButton rbLightMode;
        private System.Windows.Forms.GroupBox gbTheme;
        private System.Windows.Forms.GroupBox gbLoginInfo;
        private System.Windows.Forms.Button btnUpdateLoginInfo;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbPassEye;
        private System.Windows.Forms.GroupBox gbCustomize;
        private System.Windows.Forms.RadioButton rbEN;
        private System.Windows.Forms.RadioButton rbTR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog cd;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}