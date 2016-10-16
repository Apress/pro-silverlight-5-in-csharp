using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Graphics;

namespace Silverlight3D
{
    public class Floor3D
    {
        private VertexBuffer vertexBuffer;
        private BasicEffect effect;

        public Matrix World
        {
            get { return effect.World; }
            set { effect.World = value; }
        }
        public Matrix View
        {
            get { return effect.View; }
            set { effect.View = value; }
        }
        public Matrix Projection
        {
            get { return effect.Projection; }
            set { effect.Projection = value; }
        }
         public Floor3D(GraphicsDevice device, float aspectRatio) :
            this(device, aspectRatio, Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up))
        {}
                
        public Floor3D(GraphicsDevice device, float aspectRatio, Matrix view)
        {
            // Create a large flat floor square, consisting of two triangles.

            Vector3 frontLeft = new Vector3(-100, -1, 100);
            Vector3 frontRight = new Vector3(100, -1, 100);
            Vector3 leftBack = new Vector3(-100, -1, -100);
            Vector3 rightBack = new Vector3(100, -1, -100);
                        
            Color grayColor = new Color(119, 136, 153);
            VertexPositionColor[] vertices = new VertexPositionColor[6];

            vertices[0] = new VertexPositionColor(leftBack, grayColor);
            vertices[1] = new VertexPositionColor(frontRight, grayColor);
            vertices[2] = new VertexPositionColor(frontLeft, grayColor);
            vertices[3] = new VertexPositionColor(frontRight, grayColor);
            vertices[4] = new VertexPositionColor(leftBack, grayColor);
            vertices[5] = new VertexPositionColor(rightBack, grayColor);
            
            // Set up the vertex buffer.            
            vertexBuffer = new VertexBuffer(device, typeof(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0);

            // Configure the camera.            
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1, 100);
            
            // Set up the effect.
            effect = new BasicEffect(device);
            effect.World = Matrix.Identity;
            effect.View = view;
            effect.Projection = view * projection;

            effect.VertexColorEnabled = true;
        }

        public void Draw(GraphicsDevice device)
        {   
            device.SetVertexBuffer(vertexBuffer);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3);
            }
        }
    }
}
