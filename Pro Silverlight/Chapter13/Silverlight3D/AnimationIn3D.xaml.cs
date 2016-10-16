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
    public partial class AnimationIn3D : UserControl
    {
        private Cube3D cube;
        private Floor3D floor;

        // The position of the camera.        
        private Vector3 cameraPosition = new Vector3(0, 0, 0.01f);
                
        // The direction the camera is looking at, *from the origin*.
        private Vector3 cameraLook = new Vector3(0,0,-1);

        // The combination of the camera's position and its look direction.
        private Vector3 cameraTarget;

        public AnimationIn3D()
        {
            InitializeComponent();

            // Create the cube and floor.
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            Matrix view = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);            
            cube = new Cube3D(device, new Vector3(-1, -1, -1), 2, "Silverlight3D;component/mayablur.jpg", 1.33f, view);            
            floor = new Floor3D(device, 1.33f, view);
            
            // Walk the camera back so the scene is visible.
            // (The camera starts at the origin, so the rotations work around the origin.)
            cameraPosition -= cameraLook * 6;

            // Displace it before rotating it, to get an orbiting effect.
            //Matrix translation = Matrix.CreateTranslation(-2, 0, 0);
            //cube.World = cube.World * translation;
        }

        // Keep track of whether the cube is rotating.
        private bool rotate = true;

        private void drawingSurface_Draw(object sender, DrawEventArgs e)
        {
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            device.Clear(new Color(0, 0, 0));

            // This allows you to see the inside of the cube when you pass into it.
            device.RasterizerState = new RasterizerState()
            {
                CullMode = CullMode.None
            };
            
            // Spin the cube.
            if (rotate)
            {
                Matrix rotation = Matrix.CreateRotationY(MathHelper.PiOver4 * (float)e.DeltaTime.TotalMilliseconds / 2000f);
                cube.World = cube.World * rotation;                
            }

            // Create the view for the current camera position and direction.
            cameraTarget = cameraPosition + cameraLook;
            Matrix view = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);                         
            cube.View = view;
            floor.View = view;

            // Draw the shapes.
            floor.Draw(device);
            cube.Draw(device);
            
            // Keep the drawing surface updated.
            e.InvalidateSurface();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            Matrix rotation = Matrix.Identity;
            switch (e.Key)
            {
                case Key.Left:                                       
                    rotation = Matrix.CreateRotationY(MathHelper.PiOver4 * 0.08f);
                    cameraLook = Vector3.Transform(cameraLook, rotation);
                    break;
                case Key.Right:
                    rotation = Matrix.CreateRotationY(MathHelper.PiOver4 * -0.08f);
                    cameraLook = Vector3.Transform(cameraLook, rotation);
                    break;
                case Key.Up:
                    cameraPosition += cameraLook * 0.08f;
                    break;
                case Key.Down:
                    cameraPosition -= cameraLook * 0.08f;
                    break;                
            }
            cube.View *= rotation;
        }

        private void cmdToggleRotate_Click(object sender, RoutedEventArgs e)
        {
            rotate = !rotate;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // This makes sure this part of the page receives the key events
            // (not the page-selection list box).
            cmdToggleRotate.Focus();
        }
    }
}
