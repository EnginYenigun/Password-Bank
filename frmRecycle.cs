using Password_Bank.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Password_Bank
{
    public partial class frmRecycle : Form
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

        public frmRecycle()
        {
            m_aeroEnabled = false;
            InitializeComponent();
        }

        dbcodes db = new dbcodes();

        void listing()
        {
            Cursor = Cursors.WaitCursor;
            db.listingrecycle(dgv);
            dgv.Columns[0].HeaderText = Localization.frmRecycleCode_Listing_ID;
            dgv.Columns[1].HeaderText = Localization.frmRecycleCode_Listing_EMail;
            dgv.Columns[2].HeaderText = Localization.frmRecycleCode_Listing_Password;
            dgv.Columns[3].HeaderText = Localization.frmRecycleCode_Listing_Description;
            Cursor = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnDelete.Enabled = true;
            btnRestore.Enabled = true;
            txtID.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtEMail.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txtDescription.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            Cursor = Cursors.Default;
        }

        private void frmRecycle_Load(object sender, EventArgs e)
        {
            lblLogo.Text = Localization.lblLogo_Recycle;
            label1.Text = Localization.label1_Recycle;
            label2.Text = Localization.label2_Recycle;
            label3.Text = Localization.label3_Recycle;
            label4.Text = Localization.label4_Recycle;
            btnDelete.Text = Localization.btnDelete_Recycle;
            btnRestore.Text = Localization.btnRestore_Recycle;

            listing();

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
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                txtID.BackColor = Color.FromArgb(34, 38, 43);
                txtID.ForeColor = Color.White;
                txtEMail.BackColor = Color.FromArgb(34, 38, 43);
                txtEMail.ForeColor = Color.White;
                txtPassword.BackColor = Color.FromArgb(34, 38, 43);
                txtPassword.ForeColor = Color.White;
                txtDescription.BackColor = Color.FromArgb(34, 38, 43);
                txtDescription.ForeColor = Color.White;
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
                dgv.ForeColor = Color.Black;
                dgv.GridColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                txtID.BackColor = Color.White;
                txtID.ForeColor = Color.Black;
                txtEMail.BackColor = Color.White;
                txtEMail.ForeColor = Color.Black;
                txtPassword.BackColor = Color.White;
                txtPassword.ForeColor = Color.Black;
                txtDescription.BackColor = Color.White;
                txtDescription.ForeColor = Color.Black;
            }
            btnDelete.BackColor = Settings.Default.color;
            btnRestore.BackColor = Settings.Default.color;
            pnlTopBar.BackColor = Settings.Default.color;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            DialogResult restore = MessageBox.Show(Localization.frmRecycleCode_RestoreQuest_Main, Localization.frmRecycleCode_RestoreQuest_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Cursor = Cursors.WaitCursor;
            if (restore == DialogResult.Yes)
            {
                db.restore(int.Parse(txtID.Text));
                listing();
                txtID.Clear();
                txtPassword.Clear();
                txtEMail.Clear();
                txtDescription.Clear();
                btnDelete.Enabled = false;
                btnRestore.Enabled = false;
            }
            Cursor = Cursors.Default;

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show(Localization.frmRecycleCode_DeleteQuest_Main, Localization.frmRecycleCode_DeleteQuest_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Cursor = Cursors.WaitCursor;
            if (delete == DialogResult.Yes)
            {
                db.permdelete(int.Parse(txtID.Text));
                listing();
                txtID.Clear();
                txtPassword.Clear();
                txtEMail.Clear();
                txtDescription.Clear();
                btnDelete.Enabled = false;
                btnRestore.Enabled = false;
            }
            Cursor = Cursors.Default;

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
}