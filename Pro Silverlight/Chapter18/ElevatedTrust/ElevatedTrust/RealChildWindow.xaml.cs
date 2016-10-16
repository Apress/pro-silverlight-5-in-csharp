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

namespace ElevatedTrust
{
    public partial class RealChildWindow : UserControl
    {
        public RealChildWindow()
        {
            InitializeComponent();
        }

        private Window winSimple;
        private Window winFancy;

        private void cmdCreateBasic_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.IsRunningOutOfBrowser || !Application.Current.HasElevatedPermissions)
            {
                MessageBox.Show("This feature is only available out-of-browser with elevated trust.");
                //return;
            }

            if (winSimple == null)
            {
                winSimple = new Window();                
                TextBlock textContent = new TextBlock();
                textContent.Text = "Here's some content!";
                Grid grid = new Grid();
                grid.Background = new SolidColorBrush(Colors.White);
                grid.Children.Add(textContent);
                winSimple.Content = grid;
                winSimple.Width = 300;
                winSimple.Height = 100;
                winSimple.Title = "Simple Window";
                winSimple.Closing += simpleWindow_Closing;
                winSimple.Visibility = Visibility.Visible;                                
            }
            else
            {
               winSimple.Activate();               
            }
        }

        private void simpleWindow_Closing(object sender, System.ComponentModel.ClosingEventArgs e)
        {
            winSimple = null;
        }

        private void cmdCreateFancy_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.IsRunningOutOfBrowser || !Application.Current.HasElevatedPermissions)
            {
                MessageBox.Show("This feature is only available out-of-browser with elevated trust.");
                return;
            }
            
            if (winFancy == null)
            {
                winFancy = new Window();
                winFancy.WindowStyle = WindowStyle.None;
                CustomWindow windowContent = new CustomWindow();
                windowContent.CurrentWindow = winFancy;
                winFancy.Content = windowContent;
                winFancy.Width = 300;
                winFancy.Height = 200;
                winFancy.Title = "Fancy Window";
                winFancy.Closing += fancyWindow_Closing;
                winFancy.Visibility = Visibility.Visible;
            }
            else
            {
                winFancy.Activate();                
            }
        }

        private void fancyWindow_Closing(object sender, System.ComponentModel.ClosingEventArgs e)
        {
            winFancy = null;
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            if (winSimple != null) winSimple.Close();
            if (winFancy != null) winFancy.Close();
        }
    }
}
