using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class Background
    {
        private Game1 Game;
        public ISprite Sprite;
        public Background(Game1 game)
        {
            Game = game;
            Sprite = Game.SpriteFactory.CreateSprite(SpriteFactory.Sprites.Background);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, new Vector2(0, 0));
        }
    }
}
