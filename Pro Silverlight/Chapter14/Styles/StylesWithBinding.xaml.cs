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

namespace Styles
{
    public partial class StylesWithBinding : UserControl
    {
        public StylesWithBinding()
        {
            InitializeComponent();
        }
    }

    public class FontInfo
    {
        public FontFamily FontFamily { get; set; }        
        public double FontSize { get; set; }
        public FontWeight FontWeight { get; set; }
    }
}
