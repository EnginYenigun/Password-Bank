using Password_Bank.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Password_Bank
{
    public partial class frmMain : Form
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

        public frmMain()
        {
            m_aeroEnabled = true;
            InitializeComponent();
        }

        dbcodes db = new dbcodes();
        frmAbout frmabout = new frmAbout();
        frmRecycle frmrecyle = new frmRecycle();
        frmSettings frmsettings = new frmSettings();

        int Mx, My, Sw, Sh;
        bool mov, drag;
        Point point;

        private void maindrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag == true)
            {
                Point csp = PointToScreen(e.Location);
                Location = new Point(csp.X - point.X, csp.Y - point.Y);
            }
        }

        private void maindrag_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            point = e.Location;
        }

        private void maindrag_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Localization.Code_ExitQuest_Main, Localization.Code_ExitQuest_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblLogo.Text = Localization.lblLogo_Main;
            label1.Text = Localization.label1_Main;
            label2.Text = Localization.label2_Main;
            label3.Text = Localization.label3_Main;
            label4.Text = Localization.label4_Main;
            label5.Text = Localization.label5_Main;
            gbExtra.Text = Localization.gbExtra_Main;
            gbEdit.Text = Localization.gbEdit_Main;
            gbSearch.Text = Localization.gbSearch_Main;
            gbTools.Text = Localization.gbTools_Main;
            btnAbout.Text = Localization.btnAbout_Main;
            btnAdd.Text = Localization.btnAdd_Main;
            btnDelete.Text = Localization.btnDelete_Main;
            btnRecyclebin.Text = Localization.btnRecycle_Main;
            btnSearch.Text = Localization.btnSearch_Main;
            btnSettings.Text = Localization.btnSettings_Main;
            btnUpdate.Text = Localization.btnUpdate_Main;

            Thread listing = new Thread(list);
            listing.Start();

            pnlTopBar.BackColor = Settings.Default.color;
            btnAbout.BackColor = Settings.Default.color;
            btnAdd.BackColor = Settings.Default.color;
            btnDelete.BackColor = Settings.Default.color;
            btnRecyclebin.BackColor = Settings.Default.color;
            btnRefresh.BackColor = Settings.Default.color;
            btnSearch.BackColor = Settings.Default.color;
            btnSettings.BackColor = Settings.Default.color;
            btnUpdate.BackColor = Settings.Default.color;

            if (Settings.Default.darkmode == true)
            {
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(35, 40, 50);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 96, 168);
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Settings.Default.color;
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
                dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 96, 168);
                BackColor = Color.FromArgb(34, 38, 43);
                dgv.BackgroundColor = Color.FromArgb(34, 38, 43);
                dgv.GridColor = Color.FromArgb(34, 38, 43);
                dgv.ForeColor = Color.FromArgb(34, 38, 43);
                gbEdit.ForeColor = Color.White;
                gbSearch.ForeColor = Color.White;
                gbTools.ForeColor = Color.White;
                gbExtra.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                txtDescription.BackColor = Color.FromArgb(34, 38, 43);
                txtDescription.ForeColor = Color.White;
                txtID.BackColor = Color.FromArgb(34, 38, 43);
                txtID.ForeColor = Color.White;
                txtEMail.BackColor = Color.FromArgb(34, 38, 43);
                txtEMail.ForeColor = Color.White;
                txtPassword.BackColor = Color.FromArgb(34, 38, 43);
                txtPassword.ForeColor = Color.White;
                txtSearch.BackColor = Color.FromArgb(34, 38, 43);
                txtSearch.ForeColor = Color.White;
            }
            else
            {
                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor = Color.Black;
                dgv.DefaultCellStyle.SelectionBackColor = Settings.Default.color;
                dgv.AlternatingRowsDefaultCellStyle.BackColor =Color.WhiteSmoke;
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Settings.Default.color;
                BackColor = Color.White;
                dgv.BackgroundColor = Color.White;
                dgv.GridColor = Color.Black;
                dgv.ForeColor = Color.Black;
                gbEdit.ForeColor = Color.Black;
                gbSearch.ForeColor = Color.Black;
                gbTools.ForeColor = Color.Black;
                gbExtra.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                txtDescription.BackColor = Color.White;
                txtDescription.ForeColor = Color.Black;
                txtID.BackColor = Color.White;
                txtID.ForeColor = Color.Black;
                txtEMail.BackColor = Color.White;
                txtEMail.ForeColor = Color.Black;
                txtPassword.BackColor = Color.White;
                txtPassword.ForeColor = Color.Black;
                txtSearch.BackColor = Color.White;
                txtSearch.ForeColor = Color.Black;
            }
        }

        void list()
        {
            db.listing(dgv);
            dgv.Columns[0].HeaderText = Localization.frmRecycleCode_Listing_ID;
            dgv.Columns[1].HeaderText = Localization.frmRecycleCode_Listing_EMail;
            dgv.Columns[2].HeaderText = Localization.frmRecycleCode_Listing_Password;
            dgv.Columns[3].HeaderText = Localization.frmRecycleCode_Listing_Description;
            lblCount.Text = string.Format(Localization.lblCount_Main, dgv.Rows.Count);

            if (dgv.Rows.Count == 0)
            {
                dgv.Visible = false;
                pbNoData.Visible = true;
            }
            else
            {
                dgv.Visible = true;
                pbNoData.Visible = false;
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtEMail.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txtDescription.Text = dgv.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" || txtSearch.Text == null || txtSearch.Text == " ")
            {
                MessageBox.Show(Localization.frmMainCode_NoSearchWord_Main, Localization.frmMainCode_NoSearchWord_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                db.search(dgv, txtSearch.Text);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            list();
            txtSearch.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEMail.Text == "" || txtPassword.Text == "" || txtDescription.Text == "")
            {
                MessageBox.Show(Localization.frmMainCode_NoInfo_Main, Localization.frmMainCode_NoInfo_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                db.add(txtEMail.Text, txtPassword.Text, txtDescription.Text);
                list();
                txtID.Clear();
                txtPassword.Clear();
                txtEMail.Clear();
                txtDescription.Clear();
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtspacecontrol((TextBox)sender, e);
        }

        void txtspacecontrol(TextBox txt, KeyPressEventArgs e)
        {
            if (txt.Text == "" || txt.Text == null)
                e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void txtEMail_Leave(object sender, EventArgs e)
        {
            txttrimcontrol((TextBox)sender, e);
        }

        void txttrimcontrol(TextBox txt, EventArgs e)
        {
            txt.Text = txt.Text.Trim();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show(Localization.frmMainCode_NoSuchData_Main, Localization.frmMainCode_NoSuchData_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                db.update(int.Parse(txtID.Text), txtEMail.Text, txtPassword.Text, txtDescription.Text);
                list();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show(Localization.frmMainCode_NoSuchData_Main, Localization.frmMainCode_NoSuchData_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                db.tempdelete(int.Parse(txtID.Text));
                list();
                txtID.Clear();
                txtPassword.Clear();
                txtEMail.Clear();
                txtDescription.Clear();

                if (dgv.Rows.Count == 0)
                {
                    dgv.Visible = false;
                    pbNoData.Visible = true;
                }
                else
                {
                    dgv.Visible = true;
                    pbNoData.Visible = false;
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Opacity = 0.50;
            frmabout.ShowDialog();
            Opacity = 1;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Opacity = 0.50;
            frmsettings.ShowDialog();
            Opacity = 1;

            pnlTopBar.BackColor = Settings.Default.color;
            btnAbout.BackColor = Settings.Default.color;
            btnAdd.BackColor = Settings.Default.color;
            btnDelete.BackColor = Settings.Default.color;
            btnRecyclebin.BackColor = Settings.Default.color;
            btnRefresh.BackColor = Settings.Default.color;
            btnSearch.BackColor = Settings.Default.color;
            btnSettings.BackColor = Settings.Default.color;
            btnUpdate.BackColor = Settings.Default.color;

            if (Settings.Default.darkmode == true)
            {
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(35, 40, 50);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 96, 168);
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Settings.Default.color;
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
                dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 96, 168);
                BackColor = Color.FromArgb(34, 38, 43);
                dgv.BackgroundColor = Color.FromArgb(34, 38, 43);
                dgv.GridColor = Color.FromArgb(34, 38, 43);
                dgv.ForeColor = Color.FromArgb(34, 38, 43);
                gbEdit.ForeColor = Color.White;
                gbSearch.ForeColor = Color.White;
                gbTools.ForeColor = Color.White;
                gbExtra.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                txtDescription.BackColor = Color.FromArgb(34, 38, 43);
                txtDescription.ForeColor = Color.White;
                txtID.BackColor = Color.FromArgb(34, 38, 43);
                txtID.ForeColor = Color.White;
                txtEMail.BackColor = Color.FromArgb(34, 38, 43);
                txtEMail.ForeColor = Color.White;
                txtPassword.BackColor = Color.FromArgb(34, 38, 43);
                txtPassword.ForeColor = Color.White;
                txtSearch.BackColor = Color.FromArgb(34, 38, 43);
                txtSearch.ForeColor = Color.White;
            }
            else
            {
                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor = Color.Black;
                dgv.DefaultCellStyle.SelectionBackColor = Settings.Default.color;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Settings.Default.color;
                BackColor = Color.White;
                dgv.BackgroundColor = Color.White;
                dgv.GridColor = Color.Black;
                dgv.ForeColor = Color.Black;
                gbEdit.ForeColor = Color.Black;
                gbSearch.ForeColor = Color.Black;
                gbTools.ForeColor = Color.Black;
                gbExtra.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                txtDescription.BackColor = Color.White;
                txtDescription.ForeColor = Color.Black;
                txtID.BackColor = Color.White;
                txtID.ForeColor = Color.Black;
                txtEMail.BackColor = Color.White;
                txtEMail.ForeColor = Color.Black;
                txtPassword.BackColor = Color.White;
                txtPassword.ForeColor = Color.Black;
                txtSearch.BackColor = Color.White;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void btnRecyclebin_Click(object sender, EventArgs e)
        {
            Opacity = 0.50;
            frmrecyle.ShowDialog();
            Opacity = 1;
            list();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        void SizerMouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
        }

        void SizerMouseMove(object sender, MouseEventArgs e)
        {
            if (mov == true)
            {
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        void SizerMouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }
    }
}