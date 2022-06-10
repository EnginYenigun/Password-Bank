using Password_Bank.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace Password_Bank
{
    public partial class ucLoginSign : UserControl
    {
        public ucLoginSign()
        {
            InitializeComponent();
            pbPassEye.Image = images.openeye; //Application.StartupPath + "\\images\\openeye.png";
            label3.Image = imglist.Images[1];
            CheckForIllegalCrossThreadCalls = false;
            btnLogIn.BackColor = Settings.Default.color;

            if (Settings.Default.darkmode == true)
            {
                label1.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                txtPassword.BackColor = Color.FromArgb(34, 38, 43);
                txtPassword.ForeColor = Color.White;
            }
            else
            {
                label1.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                txtPassword.BackColor = Color.White;
                txtPassword.ForeColor = Color.Black;
            }
        }

        dbcodes db = new dbcodes();
        int code, second = 120;
        frmMain frmain = new frmMain();

        void mail()
        {
            Cursor = Cursors.WaitCursor;
            Random r = new Random();
            code = r.Next(1000, 9999);
            try
            {
                StreamReader reader = new StreamReader(Application.StartupPath + "\\mail.html");
                string readfile = reader.ReadToEnd();
                
                try
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 587;
                    smtp.Host = "smtp.yandex.com";
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("", "");
                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.To.Add(db.email());
                    mail.From = new MailAddress("");
                    mail.Subject = Localization.ucLoginSign_MailSubject;
                    mail.Body = readfile.Replace("%RECOVERYCODE%", code.ToString()).Replace("%FORGET%", Localization.ucLoginSign_MailBody1).Replace("%FORGET2%", Localization.ucLoginSign_MailBody2).Replace("%HELLO%", Localization.ucLoginSign_MailBody3);
                    smtp.Send(mail);
                }
                catch (Exception)
                {
                    MessageBox.Show(Localization.ucLoginSignCode_ErrorMail_Main, Localization.ucLoginSignCode_ErrorMail_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                try
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 587;
                    smtp.Host = "smtp.yandex.com";
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("", "");
                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.To.Add(db.email());
                    mail.From = new MailAddress("");
                    mail.Subject = Localization.ucLoginSign_MailSubject;
                    mail.Body = string.Format(Localization.ucLoginSign_MailBody3, code.ToString());
                    smtp.Send(mail);
                }
                catch (Exception)
                {
                    MessageBox.Show(Localization.ucLoginSignCode_ErrorMail_Main, Localization.ucLoginSignCode_ErrorMail_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            Cursor = Cursors.Default;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text.Replace(" ", "");
            Cursor = Cursors.WaitCursor;
            if (btnLogIn.Text == Localization.btnRegister_ucLoginSign_Next)
            {
                if (txtPassword.Text == code.ToString())
                {
                    tmr.Stop();
                    lnkForgetPass.Visible = false;
                    pbPassEye.Visible = true;
                    btnLogIn.Text = Localization.btnRegister_ucLoginSign_RenewLog;
                    label3.Text = Localization.label3_ucLoginSign;
                    label3.Image = imglist.Images[1];
                    label1.Text = Localization.label1_ucLoginSign_NewPass;
                    txtPassword.Clear();
                }
                else
                {
                    MessageBox.Show(Localization.ucLoginSignCode_InvalidCode_Main, Localization.ucLoginSignCode_InvalidCode_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnLogIn.Text == Localization.btnRegister_ucLoginSign_RenewLog)
            {
                if (txtPassword.Text == "" || txtPassword.Text == null || txtPassword.Text == " ")
                {
                    MessageBox.Show(Localization.ucLoginSignCode_InvalidNewPass_Main, Localization.ucLoginSignCode_InvalidNewPass_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    DialogResult renewpass = MessageBox.Show(string.Format(Localization.ucLoginSignCode_SetNewPassword_Main, txtPassword.Text), Localization.ucLoginSignCode_SetNewPassword_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (renewpass == DialogResult.Yes)
                    {
                        db.renewpassword(txtPassword.Text.ToString());
                        frmain.Show();
                        ((Form)TopLevelControl).Hide();
                    }
                }
            }
            else
            {
                if (db.login(txtPassword.Text) == true)
                {
                    frmain.Show();
                    ((Form)TopLevelControl).Hide();
                }
                else
                {
                    MessageBox.Show(Localization.ucLoginSignCode_WrongPass_Main, Localization.ucLoginSignCode_WrongPass_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Cursor = Cursors.Default;
        }

        private void textboxedit(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void pbPassEye_MouseEnter(object sender, EventArgs e)
        {
            pbPassEye.Width = 35;
            pbPassEye.Height = 35;
            pbPassEye.Location = new Point(267, 70);
        }

        private void pbPassEye_MouseLeave(object sender, EventArgs e)
        {
            pbPassEye.Width = 29;
            pbPassEye.Height = 29;
            pbPassEye.Location = new Point(267, 73);
        }

        private void pbPassEye_MouseDown(object sender, MouseEventArgs e)
        {
            pbPassEye.Width = 33;
            pbPassEye.Height = 33;
        }

        private void pbPassEye_MouseUp(object sender, MouseEventArgs e)
        {
            pbPassEye.Width = 35;
            pbPassEye.Height = 35;
        }

        private void pbPassEye_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                pbPassEye.Image = images.closedeye;//Application.StartupPath + "\\images\\closedeye.png";
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                pbPassEye.Image = images.openeye;//Application.StartupPath + "\\images\\openeye.png";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void lnkForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult sendcode = MessageBox.Show(Localization.ucLoginSignCode_SendCode_Main, Localization.ucLoginSignCode_SendCode_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sendcode == DialogResult.Yes)
            {
                Thread thmail = new Thread(mail);
                thmail.Start();
                label3.Image = imglist.Images[0];
                label1.Text = Localization.ucLoginSignCode_label1_SendCode;
                txtPassword.Clear();
                label3.Text = Localization.ucLoginSignCode_label3_Code;
                btnLogIn.Text = Localization.btnRegister_ucLoginSign_Next;
                txtPassword.UseSystemPasswordChar = false;
                pbPassEye.Visible = false;
                pbPassEye.Image = images.closedeye;//Application.StartupPath + "\\images\\closedeye.png";
                tmr.Start();
                lnkForgetPass.Enabled = false;
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            second--;
            lnkForgetPass.Text = string.Format(Localization.ucLoginSignCode_lnkForgetPassSecond, second);
            if (second <= 0)
            {
                tmr.Stop();
                second = 120;
                lnkForgetPass.Text = Localization.lnkForgetPass_ucLoginSign;
                lnkForgetPass.Enabled = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text.Replace(" ", "");
        }

        private void ucLoginSign_Load(object sender, EventArgs e)
        {
            label1.Text = Localization.label1_ucLoginSign;
            label3.Text = Localization.label3_ucLoginSign;
            btnLogIn.Text = Localization.btnLogIn_ucLoginSign;
            lnkForgetPass.Text = Localization.lnkForgetPass_ucLoginSign;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Text = txtPassword.Text.Replace(" ", "");
                btnLogIn.PerformClick();
            }
        }
    }
}