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
using System.Windows.Graphics;

namespace Silverlight3D
{
    public partial class App : Application
    {

        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
                GraphicsDeviceManager gdm = GraphicsDeviceManager.Current;
                if (gdm.RenderMode == RenderMode.Unavailable)
                {
                    switch (gdm.RenderModeReason)
                    {
                        case RenderModeReason.SecurityBlocked:
                            MessageBox.Show("3D support is currently disabled to enforce " +
                              " security. You can enable it by following these steps ...");
                            break;
                        case RenderModeReason.GPUAccelerationDisabled:
                            MessageBox.Show("Developer error! Use the enableGPUAcceleration " +
                              "parameter in the test page to enable 3D rendering.");
                            break;
                        case RenderModeReason.Not3DCapable:
                            MessageBox.Show(
                              "Your computer doesn't appear to supprot 3D rendering.");
                            break;
                        case RenderModeReason.TemporarilyUnavailable:
                            MessageBox.Show(
                              "There was a problem accessing the video card driver.");
                            break;
                    }
                }
                else
                {
                    // Run the application as normal.
                    this.RootVisual = new MenuPage();
                }
        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}
