using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class fireBall : IFireball
    {
        public Texture2D Texture { get; set; }
        public Texture2D Boundary { get; set; }
        public Color BoxColor { get; set; }
        public bool ShowBoundary { get; set; }

        private int totalFrame = 3;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;
        private int Columns = 3;
        private int Rows = 1;
        private int frameTime;
        private int changeFrameTime;

        public fireBall(GraphicsDevice graphicsDevice, Texture2D texture, bool showBox)
        {
            Texture = texture;
            frameWidth = Texture.Width / Columns;
            frameHeight = Texture.Height / Rows;
            currentFrame = 0;
            frameTime = 0;
            changeFrameTime = 10;
            BoxColor = Color.Green;

            ShowBoundary = showBox;
            setBoundary(graphicsDevice, frameWidth, frameHeight);
        }

        public Rectangle BoundaryBox(Vector2 Location)
        {
            return new Rectangle((int)Location.X, (int)Location.Y, frameWidth, frameHeight);
        }

        public void setBoundary(GraphicsDevice graphicsDevice, int FrameWidth, int FrameHeight)
        {
            List<Color> Colors = new List<Color>();
            for (int x = 0; x < FrameWidth; x++)
            {
                for (int y = 0; y < FrameHeight; y++)
                {
                    if (x == 0 || y == 0 || x == FrameWidth - 1 || y == FrameHeight - 1)
                        Colors.Add(new Color(255, 255, 255, 255));
                    else
                        Colors.Add(new Color(0, 0, 0, 0));
                }
            }
            Boundary = new Texture2D(graphicsDevice, FrameWidth, FrameHeight);
            Boundary.SetData<Color>(Colors.ToArray());
        }

        public void Update(GameTime gameTime)
        {
            frameTime += 1;
            if (frameTime >= changeFrameTime)
            {
                frameTime = 0;
                currentFrame++;
                if (currentFrame == totalFrame)
                    currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int x = currentFrame % Columns;
            int y = (int)((float)currentFrame / (float)Columns);

            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight);
            Rectangle sourceRectangle = new Rectangle(frameWidth * x, frameHeight * y, frameWidth, frameHeight);

            //spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            if (ShowBoundary)
                if (Boundary != null)
                    spriteBatch.Draw(Boundary, position, BoxColor);
            //spriteBatch.End();
        }

        public String ItemType()
        {
            return "fireBall";
        }
    }
}

