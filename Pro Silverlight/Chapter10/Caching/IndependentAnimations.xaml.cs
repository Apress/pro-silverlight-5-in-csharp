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

namespace Caching
{
    public partial class IndependentAnimations : UserControl
    {
        public IndependentAnimations()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            storyboard.Begin();
        }

        private void chkCache_Click(object sender, RoutedEventArgs e)
        {
            if (chkCache.IsChecked == true)
            {
                BitmapCache bitmapCache = new BitmapCache();
                bitmapCache.RenderAtScale = 5;
                cmd.CacheMode = bitmapCache;                
            }
            else
            {
                cmd.CacheMode = null;                
            }
        }
    }
}
