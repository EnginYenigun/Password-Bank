using Password_Bank.Properties;
using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Password_Bank
{
    public partial class frmLogin : Form
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

        dbcodes db = new dbcodes();
        bool drag;
        Point point;

        public frmLogin()
        {
            m_aeroEnabled = true;
            InitializeComponent();

            if (Settings.Default.language == "tr")
            {
                Localization.Culture = new CultureInfo("tr-TR");
            }

            else
            {
                Localization.Culture = new CultureInfo("");
            }
        }

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

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblLogo.Text = Localization.lblLogo_Login;
            pnlTopBar.BackColor = Settings.Default.color;
            if (db.logexist() == true)
            {
                ucLoginSign1.Visible = true;
            }
            else
            {
                ucLoginLog1.Visible = true;
            }

            if (Settings.Default.darkmode == true)
            {
                BackColor = Color.FromArgb(34, 38, 43);
            }
            else
            {
                BackColor = Color.White;
            }
        }
    }
}