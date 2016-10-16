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
using System.Windows.Media.Imaging;

namespace BehaviorTest
{
    public partial class FluidMoveTest : UserControl
    {
        public FluidMoveTest()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AddImage("arch.jpg");
            AddImage("birdinrain.jpg");
            AddImage("boatinstorm.jpg");
            AddImage("cactus.jpg");
            AddImage("dunes.jpg");
            AddImage("egyptsea.jpg");
            AddImage("gloomylightpost.jpg");
            AddImage("graybluesky.jpg");
            AddImage("greydesert.jpg");
            AddImage("greylighthouse.jpg");
        }

        private void AddImage(string imageFileName)
        {            
            Image img = new Image();         
            img.Margin = new Thickness(3);
            img.Source = new BitmapImage(new Uri("Backgrounds/" + imageFileName, UriKind.Relative));
            panel.Children.Add(img);
        }
    }
}
