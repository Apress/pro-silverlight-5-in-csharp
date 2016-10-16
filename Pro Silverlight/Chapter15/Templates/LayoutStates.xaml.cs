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

namespace Templates
{
    public partial class LayoutStates : UserControl
    {
        public LayoutStates()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, RoutedEventArgs e)
        {
            lst.Items.Add("New Item (added " + DateTime.Now.ToLongTimeString() + ")");
        }

        private void cmdRemove_Click(object sender, RoutedEventArgs e)
        {
            lst.Items.RemoveAt(lst.Items.Count - 1);
        }
    }
}
