using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    class HUDAvatar : ISprite
    {
        public Texture2D Texture { get; set; }
        public HUDAvatar(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(Texture, location, Color.White);
        }
    }
}
