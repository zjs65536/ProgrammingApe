﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class MarioAnimatedSprite : IMario
    {
        public Texture2D Texture { get; set; }
        public Texture2D Boundary { get; set; }
        public Color BoxColor { get; set; }
        private GraphicsDevice GraphicsDevice { get; set; }
        private Texture2D pixel;
        private Texture2D Pixel
        {
            get { return pixel; }
            set { pixel = value; }
        }

        private int totalFrame;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;
        private int Columns;
        private int Rows;
        private int frameTime;
        private int changeFrameTime;

        public bool ShowBoundary { get; set; }

        public MarioAnimatedSprite(GraphicsDevice graphicsDevice, Texture2D texture, int rows, int columns, bool showBox)
        {
            Texture = texture;
            Columns = columns;
            Rows = rows;
            frameWidth = Texture.Width / Columns;
            frameHeight = Texture.Height / Rows;
            currentFrame = 0;
            frameTime = 0;
            changeFrameTime = 10;
            totalFrame = rows * columns;
            BoxColor = Color.Yellow;
            GraphicsDevice = graphicsDevice;

            ShowBoundary = showBox;
        }

        public Rectangle BoundaryBox(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, frameWidth, frameHeight);
        }

        public void DrawBorder(SpriteBatch spriteBatch, Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            spriteBatch.Draw(Pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), null,
            borderColor, 0f, Vector2.Zero, SpriteEffects.None, -.005f);
            // Draw left line
            spriteBatch.Draw(Pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), null,
           borderColor, 0f, Vector2.Zero, SpriteEffects.None, -.005f);
            // Draw right line
            spriteBatch.Draw(Pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
            rectangleToDraw.Y,
            thicknessOfBorder,
            rectangleToDraw.Height), null, borderColor, 0f, Vector2.Zero, SpriteEffects.None, -
            .005f);
            // Draw bottom line
            spriteBatch.Draw(Pixel, new Rectangle(rectangleToDraw.X,
            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
            rectangleToDraw.Width,
            thicknessOfBorder), null, borderColor, 0f, Vector2.Zero, SpriteEffects.None, -.005f);
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

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int x = currentFrame % Columns;
            int y = (int)((float)currentFrame / (float)Columns);

            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, frameWidth, frameHeight);
            Rectangle sourceRectangle = new Rectangle(frameWidth * x, frameHeight * y, frameWidth, frameHeight);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            if (ShowBoundary)
            {
                if (pixel == null)
                {
                    pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                    Pixel.SetData(new[] { Color.White });
                }
                DrawBorder(spriteBatch, BoundaryBox(location), 1, BoxColor);
            }
        }
    }
}
