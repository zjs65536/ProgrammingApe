using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_4
{
    public abstract class ItemEntity
    {
        #region Properties
        public IItem Sprite { get; set; }
        public SpriteFactory SpriteFactory { get; set; }
        public Vector2 _position;
        public String ItemType;
        public float VelocityX;
        public float VelocityY;
        public float gravity;

        public bool showBox;
        #endregion

        //Method begin.
        protected ItemEntity(SpriteFactory spriteFactory, Vector2 position)
        {
            SpriteFactory = spriteFactory;
            _position = position;
            VelocityX = 0f;
            VelocityY = 0f;
        }

        public virtual void ChangeDirection()
        {
            VelocityX *= -1;
        }
        public virtual Rectangle getBoundingBox()
        {
            return Sprite.BoundaryBox(_position);
        }

        public virtual void Update(GameTime gameTime, List<BlockEntity> blockEntities)
        {
            Sprite.Update(gameTime);
            if(!ItemType.Equals("Coin"))
                groundCheck(blockEntities);

            showBox = SpriteFactory.Game.showBox;
            Sprite.ShowBoundary = showBox;

            VelocityY += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position.X += VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position.Y += VelocityY * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }

        public virtual void groundCheck(List<BlockEntity> blockEntities)
        {
            bool itemNotOnGround = true;
            Rectangle itemRectangle = Sprite.BoundaryBox(_position);
            foreach (BlockEntity blockEntity in blockEntities)
            {
                Rectangle thisRectangle = blockEntity.Sprite.BoundaryBox(blockEntity._position);
                if (itemRectangle.Intersects(thisRectangle))
                {
                    itemNotOnGround = false;
                }
                else
                    if ((itemRectangle.X <= thisRectangle.X + thisRectangle.Width - 3) && (itemRectangle.X >= thisRectangle.X - itemRectangle.Width + 3))
                        if (itemRectangle.Y < thisRectangle.Y)
                            if ((itemRectangle.Y + 33) > thisRectangle.Y)
                                itemNotOnGround = false;
            }
            if (itemNotOnGround)
            {
                gravity = 250f;
            }
            else
            {
                gravity = 0;
            }

        }
    }
}
