using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Riftbuddy
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            // Prevent showing in Taskbar
            this.ShowInTaskbar = false;

            // Hide this splash
            this.Hide();

            // Center splash in screen
            Rectangle wArea = Screen.FromControl(this).WorkingArea;

            this.Location = new Point()
            {
                X = Math.Max(wArea.X, wArea.X + (wArea.Width - this.Width) / 2),
                Y = Math.Max(wArea.Y, wArea.Y + (wArea.Height - this.Height) / 2)
            };

            NotificationHandler.Initialise();
            NotificationHandler.Notify("RiftBuddy", "RiftBuddy is running in the background! Right click my icon for more options.", 1000);

            HotkeyForm hotkeyForm = new HotkeyForm();
        }
    }
}
