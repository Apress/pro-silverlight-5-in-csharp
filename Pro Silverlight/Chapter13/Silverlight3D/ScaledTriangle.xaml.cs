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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Windows.Graphics;

namespace Silverlight3D
{
    public partial class ScaledTriangle : UserControl
    {
        public ScaledTriangle()
        {
            InitializeComponent();

            PrepareDrawing();
        }

         // Stores the corners of all your triangles.
        private VertexBuffer vertexBuffer;

        // Stores various drawing details.
        private BasicEffect effect;

        private void PrepareDrawing()
        {
            // Define the triangle's vertices.
            Vector3 topCenter = new Vector3(0, 1, 0);
            Vector3 bottomLeft = new Vector3(-1, 0, 0);
            Vector3 bottomRight = new Vector3(1, 0, 0);

            // White:
            Color color1 = new Color(255, 255, 255);
            // Red:
            Color color2 = new Color(255, 0, 0);
            // Green:
            Color color3 = new Color(0, 255, 0);

            // Combine the color and vertex information.
            VertexPositionColor[] vertices = new VertexPositionColor[3];
            vertices[0] = new VertexPositionColor(bottomLeft, color1);
            vertices[1] = new VertexPositionColor(topCenter, color3);
            vertices[2] = new VertexPositionColor(bottomRight, color2);

            // Set up the vertex buffer.
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            vertexBuffer = new VertexBuffer(device, typeof(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0);
            
            // Configure the camera.
            Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 1.33f, 1, 10);
            Matrix viewProjection = view * projection;
                        
            // Set up the effect.
            effect = new BasicEffect(device);            
            effect.World = Matrix.Identity;
            effect.View = view;
            effect.Projection = viewProjection;
            effect.VertexColorEnabled = true;            
        }

        private void drawingSurface_Draw(object sender, DrawEventArgs e)
        {                        
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            
            device.Clear(new Color(0, 0, 0));

            device.SetVertexBuffer(vertexBuffer);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3);
            }

            e.InvalidateSurface();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {            
            // Apply new scale.
            float aspectRatio = (float)e.NewSize.Width / (float)e.NewSize.Height;
            Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1, 10);            
            
            effect.Projection = view * projection;

            // Redraw.
            // surface.Invalidate();        
        }
    }
}
