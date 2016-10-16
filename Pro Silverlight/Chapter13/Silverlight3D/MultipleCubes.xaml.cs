using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Silverlight3D
{
    public partial class MultipleCubes : UserControl
    {
        private Cube3D cube;
        private Cube3D cube2;
        private Cube3D cube3;

        public MultipleCubes()
        {
            InitializeComponent();

            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            string uri = "Silverlight3D;component/mayablur.jpg";

            // Create a view that all three cubes will share.
            Matrix view = Matrix.CreateLookAt(new Vector3(1, 1, 3), Vector3.Zero,
              Vector3.Up);

            // Create the three cubes.
            cube = new Cube3D(device, new Vector3(-1, -1, -1), 2, uri, 1.33f, view);
            cube2 = new Cube3D(device, new Vector3(-2, -2, 1), 1.5f, uri, 1.33f, view);
            cube3 = new Cube3D(device, new Vector3(-5, -2, -2.5f), 2, uri, 1.33f, view);
        }

        
        private void drawingSurface_Draw(object sender, DrawEventArgs e)
        {
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            device.Clear(new Color(0, 0, 0));

            cube.Draw(device);
            cube2.Draw(device);
            cube3.Draw(device);
        }
    }
}
