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
using System.Windows.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using System.Windows.Media.Imaging;

namespace Silverlight3D
{
    public partial class Lighting : UserControl
    {
        public Lighting()
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

            Vector3 topLeftFront = new Vector3(-1, 1, 1);
            Vector3 bottomLeftFront = new Vector3(-1, -1, 1);
            Vector3 topRightFront = new Vector3(1, 1, 1);
            Vector3 bottomRightFront = new Vector3(1, -1, 1);
            Vector3 topLeftBack = new Vector3(-1, 1, -1);
            Vector3 topRightBack = new Vector3(1, 1, -1);
            Vector3 bottomLeftBack = new Vector3(-1, -1, -1);
            Vector3 bottomRightBack = new Vector3(1, -1, -1);
            VertexPositionNormalTexture[] vertices = new VertexPositionNormalTexture[36];

            Vector3 frontNormal = new Vector3(0, 0, 1);
            Vector3 backNormal = new Vector3(0, 0, -1);
            Vector3 topNormal = new Vector3(0, 1, 0);
            Vector3 bottomNormal = new Vector3(0, -1, 0);
            Vector3 leftNormal = new Vector3(-1, 0, 0);
            Vector3 rightNormal = new Vector3(1, 0, 0);
            // Front face
            vertices[0] = new VertexPositionNormalTexture(topRightFront, frontNormal, textureTopRight);
            vertices[1] = new VertexPositionNormalTexture(bottomLeftFront, frontNormal, textureBottomLeft);
            vertices[2] = new VertexPositionNormalTexture(topLeftFront, frontNormal, textureTopLeft);
            vertices[3] = new VertexPositionNormalTexture(topRightFront, frontNormal, textureTopRight);
            vertices[4] = new VertexPositionNormalTexture(bottomRightFront, frontNormal, textureBottomRight);
            vertices[5] = new VertexPositionNormalTexture(bottomLeftFront, frontNormal, textureBottomLeft);
            // Back face
            vertices[6] = new VertexPositionNormalTexture(bottomLeftBack, backNormal, textureBottomRight);
            vertices[7] = new VertexPositionNormalTexture(topRightBack, backNormal, textureTopLeft);
            vertices[8] = new VertexPositionNormalTexture(topLeftBack, backNormal, textureTopRight);
            vertices[9] = new VertexPositionNormalTexture(bottomRightBack, backNormal, textureBottomLeft);
            vertices[10] = new VertexPositionNormalTexture(topRightBack, backNormal, textureTopLeft);
            vertices[11] = new VertexPositionNormalTexture(bottomLeftBack, backNormal, textureBottomRight);
            // Top face
            vertices[12] = new VertexPositionNormalTexture(topLeftBack, topNormal, textureTopLeft);
            vertices[13] = new VertexPositionNormalTexture(topRightBack, topNormal, textureTopRight);
            vertices[14] = new VertexPositionNormalTexture(topLeftFront, topNormal, textureBottomLeft);
            vertices[15] = new VertexPositionNormalTexture(topRightBack, topNormal, textureTopRight);
            vertices[16] = new VertexPositionNormalTexture(topRightFront, topNormal, textureBottomRight);
            vertices[17] = new VertexPositionNormalTexture(topLeftFront, topNormal, textureBottomLeft);
            // Bottom face
            vertices[18] = new VertexPositionNormalTexture(bottomRightBack, bottomNormal, textureTopLeft);
            vertices[19] = new VertexPositionNormalTexture(bottomLeftBack, bottomNormal, textureTopRight);
            vertices[20] = new VertexPositionNormalTexture(bottomLeftFront, bottomNormal, textureBottomRight);
            vertices[21] = new VertexPositionNormalTexture(bottomRightFront, bottomNormal, textureBottomLeft);
            vertices[22] = new VertexPositionNormalTexture(bottomRightBack, bottomNormal, textureTopLeft);
            vertices[23] = new VertexPositionNormalTexture(bottomLeftFront, bottomNormal, textureBottomRight);
            // Left face
            vertices[24] = new VertexPositionNormalTexture(bottomLeftFront, leftNormal, textureBottomRight);
            vertices[25] = new VertexPositionNormalTexture(bottomLeftBack, leftNormal, textureBottomLeft);
            vertices[26] = new VertexPositionNormalTexture(topLeftFront, leftNormal, textureTopRight);
            vertices[27] = new VertexPositionNormalTexture(topLeftFront, leftNormal, textureTopRight);
            vertices[28] = new VertexPositionNormalTexture(bottomLeftBack, leftNormal, textureBottomLeft);
            vertices[29] = new VertexPositionNormalTexture(topLeftBack, leftNormal, textureTopLeft);
            // Right face
            vertices[30] = new VertexPositionNormalTexture(bottomRightBack, rightNormal, textureBottomRight);
            vertices[31] = new VertexPositionNormalTexture(bottomRightFront, rightNormal, textureBottomLeft);
            vertices[32] = new VertexPositionNormalTexture(topRightFront, rightNormal, textureTopLeft);
            vertices[33] = new VertexPositionNormalTexture(bottomRightBack, rightNormal, textureBottomRight);
            vertices[34] = new VertexPositionNormalTexture(topRightFront, rightNormal, textureTopLeft);
            vertices[35] = new VertexPositionNormalTexture(topRightBack, rightNormal, textureTopRight);

            // Set up the vertex buffer.
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            vertexBuffer = new VertexBuffer(device, typeof(VertexPositionNormalTexture), vertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(0, vertices, 0, vertices.Length, 0);

            // Configure the camera.
            Matrix view = Matrix.CreateLookAt(new Vector3(0.5f, 0.5f, 2f), Vector3.Zero, Vector3.Up);
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

            //effect.AmbientLightColor = new Vector3(1.0f, 0.0f, 0.0f);
            //effect.LightingEnabled = true;

            effect.EnableDefaultLighting();
        }

        private void drawingSurface_Draw(object sender, DrawEventArgs e)
        {
            GraphicsDevice device = GraphicsDeviceManager.Current.GraphicsDevice;
            device.Clear(new Color(0, 0, 0));
            device.SetVertexBuffer(vertexBuffer);
            device.SamplerStates[0] = SamplerState.LinearClamp;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3);
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            effect.World = Matrix.Identity;
            Matrix rotation = Matrix.CreateRotationY(MathHelper.Pi * (float)slider.Value/100);
            effect.World *= rotation;

            
            drawingSurface.Invalidate();
        }
    }
}
