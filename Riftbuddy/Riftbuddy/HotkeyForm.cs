using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Riftbuddy
{
    public partial class HotkeyForm : Form
    {
        const int mActionHotKeyID = 1;

        // Import DLLs
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public HotkeyForm()
        {
            InitializeComponent();

            RegisterHotKey(this.Handle, mActionHotKeyID, 4, (int)Keys.B);
        }

        private void HotkeyForm_Load(object sender, EventArgs e)
        {

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == mActionHotKeyID)
            {
                DeviceHandler.StartRecording();
            }

            base.WndProc(ref m);
        }
    }
}
