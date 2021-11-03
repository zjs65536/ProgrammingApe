using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public abstract class WeaponEntity
    {
        private Game1 Game;
        public ISprite Sprite;
        public Vector2 Position;

        public bool isDestroyed;
        public WarriorWeaponState WeaponType;
        public int AmmoNum;
        protected WeaponEntity(Game1 game, Vector2 position)
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

        public virtual WarriorWeaponState GetWeaponType()
        {
            return WeaponType;
        }
    }
}
