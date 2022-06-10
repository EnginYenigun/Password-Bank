using Password_Bank.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Password_Bank
{
    public partial class frmSettings : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        public frmSettings()
        {
            m_aeroEnabled = true;
            InitializeComponent();
        }

        dbcodes db = new dbcodes();
        string email, password;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbPassEye_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                pbPassEye.ImageLocation = Application.StartupPath + "\\images\\closedeye.png";
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                pbPassEye.ImageLocation = Application.StartupPath + "\\images\\openeye.png";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void pbPassEye_MouseEnter(object sender, EventArgs e)
        {
            pbPassEye.Width = 28;
            pbPassEye.Height = 28;
            pbPassEye.Location = new Point(317, 53);
        }

        private void pbPassEye_MouseLeave(object sender, EventArgs e)
        {
            pbPassEye.Width = 25;
            pbPassEye.Height = 25;
            pbPassEye.Location = new Point(317, 56);
        }

        private void pbPassEye_MouseDown(object sender, MouseEventArgs e)
        {
            pbPassEye.Width = 29;
            pbPassEye.Height = 29;
        }

        private void pbPassEye_MouseUp(object sender, MouseEventArgs e)
        {
            pbPassEye.Width = 28;
            pbPassEye.Height = 28;
        }

        private void txtEMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void txtEMail_Leave(object sender, EventArgs e)
        {
            txtEMail.Text = txtEMail.Text.Replace(" ", "");
            txtPassword.Text = txtPassword.Text.Replace(" ", "");
        }

        private void btnUpdateLoginInfo_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text.Replace(" ", "");
            txtEMail.Text = txtEMail.Text.Replace(" ", "");
            Cursor = Cursors.WaitCursor;
            if (txtEMail.Text.Contains("@") == true && txtEMail.Text.Substring(txtEMail.TextLength - 4, 4) == ".com" && txtPassword.Text != "" && txtEMail.Text != "")
            {
                if (txtEMail.Text == email && txtPassword.Text == password)
                {
                    MessageBox.Show(Localization.frmSettingsCode_NotChangeInfo_Main, Localization.frmSettingsCode_NotChangeInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult updatequest = MessageBox.Show(string.Format(Localization.frmSettingeCode_UpdateRequest_Main, txtEMail.Text, txtPassword.Text), Localization.frmSettingsCode_UpdateRequest_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (updatequest == DialogResult.Yes)
                    {
                        db.updateinfo(txtEMail.Text, txtPassword.Text);
                        email = txtEMail.Text;
                        password = txtPassword.Text;
                    }
                }
            }
            else
            {
                MessageBox.Show(Localization.frmSettingsCode_InvalidInfo_Main, Localization.frmSettingsCode_InvalidInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }

        private void rbDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDarkMode.Checked)
            {
                Settings.Default.darkmode = true;
                Settings.Default.Save();
                BackColor = Color.FromArgb(34, 38, 43);
                gbTheme.ForeColor = Color.White;
                gbLoginInfo.ForeColor = Color.White;
                gbCustomize.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                rbDarkMode.ForeColor = Color.White;
                rbLightMode.ForeColor = Color.White;
                rbTR.ForeColor = Color.White;
                rbEN.ForeColor = Color.White;
            }
        }

        private void rbLightMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLightMode.Checked)
            {
                Settings.Default.darkmode = false;
                Settings.Default.Save();
                rbDarkMode.Checked = false;
                rbLightMode.Checked = true;
                BackColor = Color.White;
                gbTheme.ForeColor = Color.Black;
                gbLoginInfo.ForeColor = Color.Black;
                gbCustomize.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                rbDarkMode.ForeColor = Color.Black;
                rbLightMode.ForeColor = Color.Black;
                rbTR.ForeColor = Color.Black;
                rbEN.ForeColor = Color.Black;
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            label1.Text = Localization.label1_Settings;
            label2.Text = Localization.label2_Settings;
            label3.Text = Localization.label3_Settings;
            label4.Text = Localization.label4_Settings;
            rbDarkMode.Text = Localization.rbDarkMode_Settings;
            rbLightMode.Text = Localization.rbLightMode_Settings;
            btnUpdateLoginInfo.Text = Localization.btnUpdateLoginInfo_Settings;
            lblLogo.Text = Localization.lblLogo_Settings;
            gbTheme.Text = Localization.gbTheme_Settings;
            gbLoginInfo.Text = Localization.gbLoginInfo;
            gbCustomize.Text = Localization.gbCustomize_Settings;

            if (Settings.Default.darkmode == true)
            {
                rbDarkMode.Checked = true;
                rbLightMode.Checked = false;
                BackColor = Color.FromArgb(34, 38, 43);
                gbTheme.ForeColor = Color.White;
                gbLoginInfo.ForeColor = Color.White;
                gbCustomize.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                rbDarkMode.ForeColor = Color.White;
                rbLightMode.ForeColor = Color.White;
                rbTR.ForeColor = Color.White;
                rbEN.ForeColor = Color.White;
            }
            else
            {
                rbDarkMode.Checked = false;
                rbLightMode.Checked = true;
                BackColor = Color.White;
                gbTheme.ForeColor = Color.Black;
                gbLoginInfo.ForeColor = Color.Black;
                gbCustomize.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                rbDarkMode.ForeColor = Color.Black;
                rbLightMode.ForeColor = Color.Black;
                rbTR.ForeColor = Color.Black;
                rbEN.ForeColor = Color.Black;
            }

            if (Settings.Default.language == "en")
            {
                rbEN.Checked = true;
                rbTR.Checked = false;
            }

            else
            {
                rbEN.Checked = false;
                rbTR.Checked = true;
            }
            pbPassEye.ImageLocation = Application.StartupPath + "\\images\\openeye.png";
            pbPicker.BackColor = Settings.Default.color;
            btnUpdateLoginInfo.BackColor = Settings.Default.color;
            pnlTopBar.BackColor = Settings.Default.color;
            Cursor = Cursors.WaitCursor;
            txtEMail.Text = db.email();
            txtPassword.Text = db.password();
            Cursor = Cursors.Default;
            email = txtEMail.Text;
            password = txtPassword.Text;
        }

        private void rbTR_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTR.Checked && Settings.Default.language == "en")
            {
                DialogResult languagechange = MessageBox.Show("Diliniz Türkçe TR olarak değişecektir. Yazılım otomatik olarak yeniden başlayacaktır. Onaylıyor musunuz?", "DİL DEĞİŞİMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (languagechange == DialogResult.Yes)
                {
                    Settings.Default.language = "tr";
                    Settings.Default.Save();
                    Application.Restart();
                }
                else
                {
                    rbTR.Checked = false;
                    rbEN.Checked = true;
                }
            }
        }

        private void rbEN_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEN.Checked && Settings.Default.language == "tr")
            {
                DialogResult languagechange = MessageBox.Show("Your language will change to English EN. The software will automatically reboot. Do you confirm?", "CHANGE LANGUAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (languagechange == DialogResult.Yes)
                {
                    Settings.Default.language = "en";
                    Settings.Default.Save();
                    Application.Restart();
                }
                else
                {
                    rbTR.Checked = true;
                    rbEN.Checked = false;
                }
            }
        }

        private void pbPicker_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            pbPicker.BackColor = cd.Color;
            Settings.Default.color = cd.Color;
            Settings.Default.Save();
            pnlTopBar.BackColor = Settings.Default.color;
            btnUpdateLoginInfo.BackColor = Settings.Default.color;
        }
    }
}