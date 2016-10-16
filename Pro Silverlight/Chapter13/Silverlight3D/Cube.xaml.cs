using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Windows.Graphics;
using System.Windows.Media.Imaging;
using System.IO;

namespace Silverlight3D
{    
    public partial class Cube : UserControl
    {
        public Cube()
        {
            InitializeComponent();

            PrepareDrawing();
        }

        private VertexBuffer vertexBuffer;
        private BasicEffect effect;

        private void PrepareDrawing()
        {
            // The colors to use for coloring triangles.
            Color colorRed = new Color(255, 0, 0, 0);
            Color colorBlue = new Color(0, 255, 0, 0);
            Color colorGreen = new Color(0, 0, 255, 0);
            Color colorWhite = new Color(255, 255, 255, 255);

            // The points to use for the vertices.            
            Vector3 topLeftFront = new Vector3(-1, 1, 1);
            Vector3 bottomLeftFront = new Vector3(-1, -1, 1);
            Vector3 topRightFront = new Vector3(1, 1, 1);
            Vector3 bottomRightFront = new Vector3(1, -1, 1);
            Vector3 topLeftBack = new Vector3(-1, 1, -1);
            Vector3 topRightBack = new Vector3(1, 1, -1);
            Vector3 bottomLeftBack = new Vector3(-1, -1, -1);
            Vector3 bottomRightBack = new Vector3(1, -1, -1);

            // The vertex data.
            VertexPositionColor[] vertices = new VertexPositionColor[36];

            // Shaded example.
            // Front face
            vertices[0] = new VertexPositionColor(topRightFront, colorBlue);
            vertices[1] = new VertexPositionColor(bottomLeftFront, colorGreen);
            vertices[2] = new VertexPositionColor(topLeftFront, colorRed);
            vertices[3] = new VertexPositionColor(topRightFront, colorBlue);
            vertices[4] = new VertexPositionColor(bottomRightFront, colorWhite);
            vertices[5] = new VertexPositionColor(bottomLeftFront, colorGreen);
            // Back face
            vertices[6] = new VertexPositionColor(bottomLeftBack, colorWhite);
            vertices[7] = new VertexPositionColor(topRightBack, colorRed);
            vertices[8] = new VertexPositionColor(topLeftBack, colorBlue);
            vertices[9] = new VertexPositionColor(bottomRightBack, colorGreen);
            vertices[10] = new VertexPositionColor(topRightBack, colorRed);
            vertices[11] = new VertexPositionColor(bottomLeftBack, colorWhite);
            // Top face
            vertices[12] = new VertexPositionColor(topLeftBack, colorRed);
            vertices[13] = new VertexPositionColor(topRightBack, colorBlue);
            vertices[14] = new VertexPositionColor(topLeftFront, colorRed);
            vertices[15] = new VertexPositionColor(topRightBack, colorBlue);
            vertices[16] = new VertexPositionColor(topRightFront, colorBlue);
            vertices[17] = new VertexPositionColor(topLeftFront, colorRed);
            // Bottom face
            vertices[18] = new VertexPositionColor(bottomRightBack, colorRed);
            vertices[19] = new VertexPositionColor(bottomLeftBack, colorBlue);
            vertices[20] = new VertexPositionColor(bottomLeftFront, colorWhite);
            vertices[21] = new VertexPositionColor(bottomRightFront, colorGreen);
            vertices[22] = new VertexPositionColor(bottomRightBack, colorRed);
            vertices[23] = new VertexPositionColor(bottomLeftFront, colorWhite);
            // Left face
            vertices[24] = new VertexPositionColor(bottomLeftFront, colorWhite);
            vertices[25] = new VertexPositionColor(bottomLeftBack, colorGreen);
            vertices[26] = new VertexPositionColor(topLeftFront, colorRed);
            vertices[27] = new VertexPositionColor(topLeftFront, colorRed);
            vertices[28] = new VertexPositionColor(bottomLeftBack, colorGreen);
            vertices[29] = new VertexPositionColor(topLeftBack, colorRed);
            // Right face
            vertices[30] = new VertexPositionColor(bottomRightBack, colorWhite);
            vertices[31] = new VertexPositionColor(bottomRightFront, colorGreen);
            vertices[32] = new VertexPositionColor(topRightFront, colorRed);
            vertices[33] = new VertexPositionColor(bottomRightBack, colorWhite);
            vertices[34] = new VertexPositionColor(topRightFront, colorRed);
            vertices[35] = new VertexPositionColor(topRightBack, colorBlue);

            // Solid coloring example.
            //// Front face
            //vertices[0] = new VertexPositionColor(topRightFront, colorBlue);
            //vertices[1] = new VertexPositionColor(bottomLeftFront, colorBlue);
            //vertices[2] = new VertexPositionColor(topLeftFront, colorBlue);
            //vertices[3] = new VertexPositionColor(topRightFront, colorGreen);
            //vertices[4] = new VertexPositionColor(bottomRightFront, colorGreen);
            //vertices[5] = new VertexPositionColor(bottomLeftFront, colorGreen);
            //// Back face
            //vertices[6] = new VertexPositionColor(bottomLeftBack, colorRed);
            //vertices[7] = new VertexPositionColor(topRightBack, colorRed);
            //vertices[8] = new VertexPositionColor(topLeftBack, colorRed);
            //vertices[9] = new VertexPositionColor(bottomRightBack, colorWhite);
            //vertices[10] = new VertexPositionColor(topRightBack, colorWhite);
            //vertices[11] = new VertexPositionColor(bottomLeftBack, colorWhite);
            //// Top face
            //vertices[12] = new VertexPositionColor(topLeftBack, colorRed);
            //vertices[13] = new VertexPositionColor(topRightBack, colorRed);
            //vertices[14] = new VertexPositionColor(topLeftFront, colorRed);
            //vertices[15] = new VertexPositionColor(topRightBack, colorWhite);
            //vertices[16] = new VertexPositionColor(topRightFront, colorWhite);
            //vertices[17] = new VertexPositionColor(topLeftFront, colorWhite);
            //// Bottom face
            //vertices[18] = new VertexPositionColor(bottomRightBack, colorWhite);
            //vertices[19] = new VertexPositionColor(bottomLeftBack, colorWhite);
            //vertices[20] = new VertexPositionColor(bottomLeftFront, colorWhite);
            //vertices[21] = new VertexPositionColor(bottomRightFront, colorGreen);
            //vertices[22] = new VertexPositionColor(bottomRightBack, colorGreen);
            //vertices[23] = new VertexPositionColor(bottomLeftFront, colorGreen);
            //// Left face
            //vertices[24] = new VertexPositionColor(bottomLeftFront, colorGreen);
            //vertices[25] = new VertexPositionColor(bottomLeftBack, colorGreen);
            //vertices[26] = new VertexPositionColor(topLeftFront, colorGreen);
            //vertices[27] = new VertexPositionColor(topLeftFront, colorRed);
            //vertices[28] = new VertexPositionColor(bottomLeftBack, colorRed);
            //vertices[29] = new VertexPositionColor(topLeftBack, colorRed);
            //// Right face
            //vertices[30] = new VertexPositionColor(bottomRightBack, colorRed);
            //vertices[31] = new VertexPositionColor(bottomRightFront, colorRed);
            //vertices[32] = new VertexPositionColor(topRightFront, colorRed);
            //vertices[33] = new VertexPositionColor(bottomRightBack, colorBlue);
            //vertices[34] = new VertexPositionColor(topRightFront, colorBlue);
            //vertices[35] = new VertexPositionColor(topRightBack, colorBlue);
            
            // Set up the vertex buffer.
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            vertexBuffer = new VertexBuffer(device, typeof(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0);

            // Configure the camera.
            Matrix view = Matrix.CreateLookAt(new Vector3(1, 1, 3), Vector3.Zero, Vector3.Up);
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 1.33f, 1, 100);
            
            // Set up the effect.
            effect = new BasicEffect(device);
            effect.World = Matrix.Identity;
            effect.View = view;
            effect.Projection = view * projection;
            effect.VertexColorEnabled = true;
        }

        private void drawingSurface_Draw(object sender, DrawEventArgs e)
        {
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;

            device.Clear(new Color(0, 0, 0, 0));
            device.SetVertexBuffer(vertexBuffer);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3);
            }
        }
    }
}
