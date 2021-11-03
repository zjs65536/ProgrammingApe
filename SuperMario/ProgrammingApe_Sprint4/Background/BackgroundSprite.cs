using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    class BackgroundSprite : IBackground
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        public BackgroundSprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
