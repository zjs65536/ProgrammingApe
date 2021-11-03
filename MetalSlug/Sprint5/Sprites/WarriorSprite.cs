using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{
    class WarriorSprite : ISprite
    {
        private Texture2D Texture;

        private int TotalFrame;
        private int Rows;
        private int Columns;
        private int CurrentFrame;
        private int FrameTime;
        private int FrameWidth;
        private int FrameHeight;

        public bool isAnimated { get; set; }
        public WarriorSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            FrameTime = 0;
            TotalFrame = Rows * Columns;
            FrameWidth = Texture.Width / Columns;
            FrameHeight = Texture.Height / Rows;

            if (TotalFrame == 1)
                isAnimated = false;
            else
                isAnimated = true;
        }
        public void Update(GameTime gameTime)
        {
            if (isAnimated)
            {
                FrameTime += 1;
                if (FrameTime == 5)
                {
                    FrameTime = 0;
                    CurrentFrame++;
                    if (CurrentFrame == TotalFrame)
                        CurrentFrame = 0;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (isAnimated)
            {
                int x = CurrentFrame % Columns;
                int y = (int)((float)CurrentFrame / (float)Columns);

                Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, FrameWidth, FrameHeight);
                Rectangle sourceRectangle = new Rectangle(FrameWidth * x, FrameHeight * y, FrameWidth, FrameHeight);

                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else
                spriteBatch.Draw(Texture, location, Color.White);
        }

        public Rectangle BoundaryBox(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, FrameWidth, FrameHeight);
        }
    }
}