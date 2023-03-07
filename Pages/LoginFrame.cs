using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyLauncher.Pages
{
    public partial class LoginFrame : Form
    {
        public LoginFrame()
        {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            Header.MouseDown += OnMouseDown;
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #region For Draggable

        public const int WN_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hand, int msg, int wParam, int lParam);
        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WN_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion

        private void LoginPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
