using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace ElevatedTrust
{
    public partial class PInvoke : UserControl
    {
        public PInvoke()
        {
            InitializeComponent();
        }

        // This is the API function for exiting Windows.
        [DllImport("user32.dll")]        
        static extern bool ExitWindowsEx(ExitWindowsFlags uFlags, long dwReason);

        enum ExitWindowsFlags
        {
            // Use this constant to log the user off without a reboot.
            Logoff = 0,

            // Use this constant to cause a system reboot.
            Restart = 2,

            // Use this constant to cause a system shutdown
            // (and turn off the computer, if the hardware supports it).
            Shutdown = 1,

            // Add this constant to any of the other three to force the
            // shutdown or reboot even if the user tries to cancel it.
            Force = 4
        }

        private void cmdShutdown_Click(object sender, RoutedEventArgs e)
        {
            ExitWindowsEx(ExitWindowsFlags.Logoff, 0);
        }
    }
}
