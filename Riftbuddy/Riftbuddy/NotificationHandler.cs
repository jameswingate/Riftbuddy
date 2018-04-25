using System;
using System.Windows.Forms;

namespace Riftbuddy
{
    public static class NotificationHandler
    {
        private static NotifyIcon rbNotifyIcon;
        private static ContextMenu rbNotifyIconContextMenu;
        private static Config configForm;

        public static void Initialise()
        {
            rbNotifyIcon = new NotifyIcon();
            rbNotifyIconContextMenu = new ContextMenu();

            rbNotifyIcon.Icon = Properties.Resources.smallicon;
            rbNotifyIcon.Visible = true;

            var miConfigure = rbNotifyIconContextMenu.MenuItems.Add("Configure");
            var miExit = rbNotifyIconContextMenu.MenuItems.Add("Exit");

            miConfigure.Click += new EventHandler(miConfigure_Click);
            miExit.Click += new EventHandler(miExit_Click);

            rbNotifyIcon.ContextMenu = rbNotifyIconContextMenu;
        }

        public static void Notify(string title, string text, int timeout)
        { 
            rbNotifyIcon.BalloonTipTitle = title;
            rbNotifyIcon.BalloonTipText = text;

            rbNotifyIcon.ShowBalloonTip(timeout);
        }

        public static void HandleProgramExit()
        {
            rbNotifyIcon.Visible = false;
            Application.Exit();
        }

        private static void miConfigure_Click(object sender, EventArgs e)
        {
            if (configForm == null)
            {
                configForm = new Config();
                configForm.Show();
            }
            else
            {
                configForm.Show();
            }
        }

        private static void miExit_Click(object sender, EventArgs e)
        {
            HandleProgramExit();
        }
    }
}
