using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public abstract class BulletEntity
    {
        #region Properties
        private Game1 Game;
        public ISprite Sprite;
        public Vector2 Position;
        public Vector2 Velocity;
        public bool IsFacingLeft;

        public int Damage;
        public int LifeSpan;
        public bool isDestroyed;
        public BulletSource BulletSource;
        public BulletEnum BulletEnum;
        #endregion
        protected BulletEntity(Game1 game, Vector2 position, bool isFacingLeft, BulletSource bulletSource)
        {
            Game = game;
            Position = position;
            IsFacingLeft = isFacingLeft;
            BulletSource = bulletSource;

            isDestroyed = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (LifeSpan > 0)
                LifeSpan--;
            if (LifeSpan == 0)
                isDestroyed = true;
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
