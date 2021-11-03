using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public abstract class BlockEntity
    {
        private Game1 Game;
        public ISprite Sprite;
        public Vector2 Position;

        public int BreakPoint;
        public bool isDestroyed;
        public BlockEnum BlockEnum;
        protected BlockEntity(Game1 game, Vector2 position)
        {
            Game = game;
            Position = position;
            isDestroyed = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public virtual Rectangle GetBoundaryBox()
        {
            return Sprite.BoundaryBox(Position);
        }
    }
}
