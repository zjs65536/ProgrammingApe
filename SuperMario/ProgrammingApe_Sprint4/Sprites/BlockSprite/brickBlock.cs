using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class brickBlock : IBlock
    {
        public Texture2D Texture { get; set; }
        private GraphicsDevice GraphicsDevice { get; set; }
        private Texture2D pixel;
        private Texture2D Pixel
        {
            get { return pixel; }
            set { pixel = value; }
        }
        public Color BoxColor { get; set; }
        public bool ShowBoundary { get; set; }
        public brickBlock(GraphicsDevice graphicsDevice, Texture2D texture, bool showBox)
        {
            GraphicsDevice = graphicsDevice;
            Texture = texture;
            BoxColor = Color.White;
            ShowBoundary = showBox;
        }
        public Rectangle BoundaryBox(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, Texture.Width, Texture.Height);
        }
        public void Update(GameTime gameTime)
        {
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
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(Texture, location, Color.White);
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
        public String BlockType()
        {
            return "brickBlock";
        }
    }
}
