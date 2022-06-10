namespace Password_Bank
{
    partial class ucLoginSign
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLoginSign));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lnkForgetPass = new System.Windows.Forms.LinkLabel();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.pbPassEye = new System.Windows.Forms.PictureBox();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPassEye)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome back! Please log in.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(65, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pass:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(141, 73);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(120, 29);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxedit);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.btnLogIn.FlatAppearance.BorderSize = 0;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(127, 162);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(107, 43);
            this.btnLogIn.TabIndex = 7;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // lnkForgetPass
            // 
            this.lnkForgetPass.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(133)))), ((int)(((byte)(150)))));
            this.lnkForgetPass.BackColor = System.Drawing.Color.Transparent;
            this.lnkForgetPass.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(133)))), ((int)(((byte)(250)))));
            this.lnkForgetPass.Location = new System.Drawing.Point(3, 118);
            this.lnkForgetPass.Name = "lnkForgetPass";
            this.lnkForgetPass.Size = new System.Drawing.Size(354, 27);
            this.lnkForgetPass.TabIndex = 8;
            this.lnkForgetPass.TabStop = true;
            this.lnkForgetPass.Text = "Forget your password?";
            this.lnkForgetPass.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkForgetPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgetPass_LinkClicked);
            // 
            // tmr
            // 
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // pbPassEye
            // 
            this.pbPassEye.BackColor = System.Drawing.Color.Transparent;
            this.pbPassEye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPassEye.Location = new System.Drawing.Point(267, 73);
            this.pbPassEye.Name = "pbPassEye";
            this.pbPassEye.Size = new System.Drawing.Size(29, 29);
            this.pbPassEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPassEye.TabIndex = 9;
            this.pbPassEye.TabStop = false;
            this.pbPassEye.Click += new System.EventHandler(this.pbPassEye_Click);
            this.pbPassEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPassEye_MouseDown);
            this.pbPassEye.MouseEnter += new System.EventHandler(this.pbPassEye_MouseEnter);
            this.pbPassEye.MouseLeave += new System.EventHandler(this.pbPassEye_MouseLeave);
            this.pbPassEye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPassEye_MouseUp);
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist.Images.SetKeyName(0, "code.png");
            this.imglist.Images.SetKeyName(1, "password.png");
            // 
            // ucLoginSign
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbPassEye);
            this.Controls.Add(this.lnkForgetPass);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucLoginSign";
            this.Size = new System.Drawing.Size(360, 230);
            this.Load += new System.EventHandler(this.ucLoginSign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPassEye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.LinkLabel lnkForgetPass;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.PictureBox pbPassEye;
        private System.Windows.Forms.ImageList imglist;
    }
}
