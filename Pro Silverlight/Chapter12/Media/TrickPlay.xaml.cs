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

namespace Media
{
    public partial class TrickPlay : UserControl
    {
        public TrickPlay()
        {
            InitializeComponent();
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = TimeSpan.FromSeconds(0);
            media.Play();
        }
    }
}
