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
    public partial class TexturedCube : UserControl
    {
        public TexturedCube()
        {
            InitializeComponent();

            PrepareDrawing();
        }

        private VertexBuffer vertexBuffer;
        private BasicEffect effect;

        private void PrepareDrawing()
        {
            Vector2 textureTopLeft = new Vector2(0, 0);
            Vector2 textureTopRight = new Vector2(1, 0);
            Vector2 textureBottomLeft = new Vector2(0, 1);
            Vector2 textureBottomRight = new Vector2(1, 1);


            textureTopLeft = new Vector2(0, 0);
            textureTopRight = new Vector2(1, 0);
            textureBottomLeft = new Vector2(0, 1);
            textureBottomRight = new Vector2(1, 1);
          
            Vector3 topLeftFront = new Vector3(-1, 1, 1);
            Vector3 bottomLeftFront = new Vector3(-1, -1, 1);
            Vector3 topRightFront = new Vector3(1, 1, 1);
            Vector3 bottomRightFront = new Vector3(1, -1, 1);
            Vector3 topLeftBack = new Vector3(-1, 1, -1);
            Vector3 topRightBack = new Vector3(1, 1, -1);
            Vector3 bottomLeftBack = new Vector3(-1, -1, -1);
            Vector3 bottomRightBack = new Vector3(1, -1, -1);
            VertexPositionTexture[] vertices = new VertexPositionTexture[36];
            // Front face
            vertices[0] = new VertexPositionTexture(topRightFront, textureTopRight);
            vertices[1] = new VertexPositionTexture(bottomLeftFront, textureBottomLeft);
            vertices[2] = new VertexPositionTexture(topLeftFront, textureTopLeft);
            vertices[3] = new VertexPositionTexture(topRightFront, textureTopRight);
            vertices[4] = new VertexPositionTexture(bottomRightFront, textureBottomRight);
            vertices[5] = new VertexPositionTexture(bottomLeftFront, textureBottomLeft);
            // Back face
            vertices[6] = new VertexPositionTexture(bottomLeftBack, textureBottomRight);
            vertices[7] = new VertexPositionTexture(topRightBack, textureTopLeft);
            vertices[8] = new VertexPositionTexture(topLeftBack, textureTopRight);
            vertices[9] = new VertexPositionTexture(bottomRightBack, textureBottomLeft);
            vertices[10] = new VertexPositionTexture(topRightBack, textureTopLeft);
            vertices[11] = new VertexPositionTexture(bottomLeftBack, textureBottomRight);
            // Top face
            vertices[12] = new VertexPositionTexture(topLeftBack, textureTopLeft);
            vertices[13] = new VertexPositionTexture(topRightBack, textureTopRight);
            vertices[14] = new VertexPositionTexture(topLeftFront, textureBottomLeft);
            vertices[15] = new VertexPositionTexture(topRightBack, textureTopRight);
            vertices[16] = new VertexPositionTexture(topRightFront, textureBottomRight);
            vertices[17] = new VertexPositionTexture(topLeftFront, textureBottomLeft);
            // Bottom face
            vertices[18] = new VertexPositionTexture(bottomRightBack, textureTopLeft);
            vertices[19] = new VertexPositionTexture(bottomLeftBack, textureTopRight);
            vertices[20] = new VertexPositionTexture(bottomLeftFront, textureBottomRight);
            vertices[21] = new VertexPositionTexture(bottomRightFront, textureBottomLeft);
            vertices[22] = new VertexPositionTexture(bottomRightBack, textureTopLeft);
            vertices[23] = new VertexPositionTexture(bottomLeftFront, textureBottomRight);
            // Left face
            vertices[24] = new VertexPositionTexture(bottomLeftFront, textureBottomRight);
            vertices[25] = new VertexPositionTexture(bottomLeftBack, textureBottomLeft);
            vertices[26] = new VertexPositionTexture(topLeftFront, textureTopRight);
            vertices[27] = new VertexPositionTexture(topLeftFront, textureTopRight);
            vertices[28] = new VertexPositionTexture(bottomLeftBack, textureBottomLeft);
            vertices[29] = new VertexPositionTexture(topLeftBack, textureTopLeft);
            // Right face
            vertices[30] = new VertexPositionTexture(bottomRightBack, textureBottomRight);
            vertices[31] = new VertexPositionTexture(bottomRightFront, textureBottomLeft);
            vertices[32] = new VertexPositionTexture(topRightFront, textureTopLeft);
            vertices[33] = new VertexPositionTexture(bottomRightBack, textureBottomRight);
            vertices[34] = new VertexPositionTexture(topRightFront, textureTopLeft);
            vertices[35] = new VertexPositionTexture(topRightBack, textureTopRight);

            // Set up the vertex buffer.
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            vertexBuffer = new VertexBuffer(device, typeof(VertexPositionTexture), vertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0);

            // Configure the camera.
            Matrix view = Matrix.CreateLookAt(new Vector3(1, 1, 3), Vector3.Zero, Vector3.Up);
            Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 1.33f, 1, 100);
            
            // Set up the effect.
            effect = new BasicEffect(device);
            effect.World = Matrix.Identity;
            effect.View = view;
            effect.Projection = view * projection;

            // Load the texture from a resoure, and place it in a BitmapImage
            string uri = "Silverlight3D;component/mayablur.jpg";
            Stream s = Application.GetResourceStream(new Uri(uri, UriKind.Relative)).Stream;
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(s);

            // Copy the BitmapImage data into a Texture2D object.
            Texture2D texture;
            texture = new Texture2D(device, bmp.PixelWidth, bmp.PixelHeight);
            bmp.CopyTo(texture);

            // Configure the BasicEffect to use a texture instead of vertex shading.
            //effect.VertexColorEnabled = true;            
            effect.TextureEnabled = true;            
            effect.Texture = texture;
        }

        private void drawingSurface_Draw(object sender, DrawEventArgs e)
        {
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            device.SamplerStates[0] = SamplerState.LinearClamp;

            device.Clear(new Color(0, 0, 0));
            device.SetVertexBuffer(vertexBuffer);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3);
            }
        }
              
    }
}
