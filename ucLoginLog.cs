using Password_Bank.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Password_Bank
{
    public partial class ucLoginLog : UserControl
    {
        public ucLoginLog()
        {
            InitializeComponent();

            btnRegister.BackColor = Settings.Default.color;
            if (Settings.Default.darkmode == true)
            {
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                txtEMail.ForeColor = Color.White;
                txtPassword.ForeColor = Color.White;
                txtEMail.BackColor = Color.FromArgb(34, 38, 43);
                txtPassword.BackColor = Color.FromArgb(34, 38, 43);
            }
            else
            {
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                txtEMail.ForeColor = Color.Black;
                txtPassword.ForeColor = Color.Black;
                txtEMail.BackColor = Color.White;
                txtPassword.BackColor = Color.White;
            }
        }

        dbcodes db = new dbcodes();
        frmMain frmain = new frmMain();

        private void txtEMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void txtEMail_Leave(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text.Replace(" ", "");
            txtEMail.Text = txtEMail.Text.Replace(" ", "");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.PerformClick();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text.Replace(" ", "");
            txtEMail.Text = txtEMail.Text.Replace(" ", "");
            Cursor = Cursors.WaitCursor;
            if (txtEMail.Text.Contains("@") == true && txtEMail.Text.Substring(txtEMail.TextLength - 4, 4) == ".com" && txtPassword.Text != "" && txtEMail.Text != "")
            {
                DialogResult registerquest = MessageBox.Show(string.Format(Localization.ucLoginLogCode_Register_Main, txtEMail.Text, txtPassword.Text), Localization.ucLoginLogCode_Register_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (registerquest == DialogResult.Yes)
                {
                    db.register(txtEMail.Text, txtPassword.Text);
                    frmain.Show();
                    ((Form)TopLevelControl).Hide();
                }
            }
            else
            {
                MessageBox.Show(Localization.ucLoginLogCode_InvalidInfo_Main, Localization.ucLoginLogCode_InvalidInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }

        private void ucLoginLog_Load(object sender, EventArgs e)
        {
            label1.Text = Localization.label1_ucLoginLog;
            label2.Text = Localization.label2_ucLoginLog;
            label3.Text = Localization.label3_ucLoginLog;
            btnRegister.Text = Localization.btnRegister_ucLoginLog;
        }
    }
}