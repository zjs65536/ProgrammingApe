using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint_4
{


    public class FireballEntity
    {
        public IFireball Sprite { get; set; }
        public Vector2 _position;
        public bool isDestroyed;
        private int LifeSpan;
        public float VelocityX;
        public float VelocityY;
        public float gravity;
        //private float speedControl;
        public SpriteFactory SpriteFactory { get; set; }


        //Method begin.
        public FireballEntity(SpriteFactory spriteFactory, Vector2 Position, SpriteFacing_enum direction)
        {
            isDestroyed = false;
            _position = Position;
            LifeSpan = 250;
            Sprite = spriteFactory.createFireball(SpriteFactory.sprites.fireball);
            SpriteFactory = spriteFactory;
            gravity = 400f;
            VelocityY = 100f;
            if (direction == SpriteFacing_enum.Left)
            {
                _position.X -= 16;
                VelocityX = -200f;
            }
            else
            {
                _position.X += 16;
                VelocityX = 200f;
            }
        }

        public void Update(GameTime gameTime, List<BlockEntity> blockEntities)
        {
            if (LifeSpan != 0)
                LifeSpan--;
            else
                isDestroyed = true;
            Sprite.Update(gameTime);
            VelocityY += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position.X += VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds; //* speedControl;
            _position.Y += VelocityY * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }

        public bool Destroyed()
        {
            return isDestroyed;
        }

    }
}
