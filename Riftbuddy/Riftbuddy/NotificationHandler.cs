using System;
using System.Windows.Forms;

namespace Riftbuddy
{
    public static class NotificationHandler
    {
        // Declare global static variables.
        private static NotifyIcon rbNotifyIcon;
        private static ContextMenu rbNotifyIconContextMenu;
        private static Config configForm;

        // Initialise.
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

        // Create and display a notification.
        public static void Notify(string title, string text, int timeout)
        { 
            rbNotifyIcon.BalloonTipTitle = title;
            rbNotifyIcon.BalloonTipText = text;

            rbNotifyIcon.ShowBalloonTip(timeout);
        }

        // Handle exiting of the program.
        public static void HandleProgramExit()
        {
            rbNotifyIcon.Visible = false;
            Application.Exit();
        }

        // Event handler for docked icon's context menu.
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

        // Event handler for docked icon's context menu.
        private static void miExit_Click(object sender, EventArgs e)
        {
            HandleProgramExit();
        }
    }
}
