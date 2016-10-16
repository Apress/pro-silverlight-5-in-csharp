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
    public partial class CustomWindow : UserControl
    {
        public CustomWindow()
        {
            InitializeComponent();
        }

        private Window currentWindow;
        public Window CurrentWindow
        {
            get
            {                
                if (currentWindow != null)
                {
                    // This is being used as a secondary (child) window.
                    return currentWindow;
                }
                else
                {
                    // This is being used as a main window (or as a child window, incorrectly).
                    return Application.Current.MainWindow;
                }
            }
            set
            {
                currentWindow = value;
            }
               
        }

        private void titleBar_MouseLeftButtonDown(object sender,
          System.Windows.Input.MouseButtonEventArgs e)
        {
            CurrentWindow.DragMove();
        }

        private void cmdMinimize_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CurrentWindow.WindowState = WindowState.Minimized;
        }

        private void cmdMaximize_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CurrentWindow.WindowState == WindowState.Normal)
            {
                CurrentWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                CurrentWindow.WindowState = WindowState.Normal;
            }
        }

        private void cmdClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CurrentWindow.Close();
        }

        private void rect_Resize(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender == rect_TopLeftCorner)
            {
                CurrentWindow.DragResize(WindowResizeEdge.TopLeft);
            }
            else if (sender == rect_TopEdge)
            {
                CurrentWindow.DragResize(WindowResizeEdge.Top);
            }
            else if (sender == rect_TopRightCorner)
            {
                CurrentWindow.DragResize(WindowResizeEdge.TopRight);
            }
            else if (sender == rect_LeftEdge)
            {
                CurrentWindow.DragResize(WindowResizeEdge.Left);
            }
            else if (sender == rect_RightEdge)
            {
                CurrentWindow.DragResize(WindowResizeEdge.Right);
            }
            else if (sender == rect_BottomLeftCorner)
            {
                CurrentWindow.DragResize(WindowResizeEdge.BottomLeft);
            }
            else if (sender == rect_BottomEdge)
            {
                CurrentWindow.DragResize(WindowResizeEdge.Bottom);
            }
            else if (sender == rect_BottomRightCorner)
            {
                CurrentWindow.DragResize(WindowResizeEdge.BottomRight);
            }
        }

    }

}
