using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public enum EnemyState_enum
    {
        GoombaAlive,
        GoombaDead,

        KoopaAlive,
        KoopaShell,

        Piranha,
        PiranhaHide
    }


    public abstract class EnemyEntity
    {
        #region Properties
        public IEnemy Sprite { get; set; }
        public EnemyState_enum EnemyState_Enum { get; set; }
        public IEnemyState EnemyState { get; set; }
        public EnemyChanging EnemyChanging { get; set; }
        public Vector2 _position;
        public String EnemyType { get; set; }
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public Vector2 Anchor;
        public float speedControl;
        public float gravityControl;
        public float gravity;
        public int deleteTime;
        public bool isOnGround;
        public bool showBox;
        public bool startMoving;
        public bool toBeDeleted;

        public EnemyState_enum previousEnemyState { get; set; }

        public SpriteFactory SpriteFactory { get; set; }
        #endregion

        //Method begin.
        protected EnemyEntity(SpriteFactory spriteFactory, Vector2 Position)
        {
            startMoving = false;
            toBeDeleted = false;

            speedControl = 25f;
            gravityControl = 35f;
            _position = Position;
            SpriteFactory = spriteFactory;
            VelocityX = -1f;
            deleteTime = 150;
        }
        public virtual Rectangle getBoundingBox()
        {
            return Sprite.BoundaryBox(_position);
        }

        public virtual void ChangeDirection()
        {
            VelocityX *= -1;
        }

        public virtual void Update(GameTime gameTime, List<BlockEntity> blockEntities)
        {
            Sprite.Update(gameTime);
            groundCheck(blockEntities);

            showBox = SpriteFactory.Game.showBox;
            Sprite.ShowBoundary = showBox;

            VelocityY += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position.X += VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds * speedControl;
            _position.Y += VelocityY * (float)gameTime.ElapsedGameTime.TotalSeconds * gravityControl;

            if (previousEnemyState != EnemyState_Enum)
            {
                EnemyChanging.Update();
                previousEnemyState = EnemyState_Enum;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }
        public void groundCheck(List<BlockEntity> blockEntities)
        {
            bool enemyNotOnGround = true;
            Rectangle enemyRectangle = Sprite.BoundaryBox(_position);
            foreach (BlockEntity blockEntity in blockEntities)
            {
                Rectangle thisRectangle = blockEntity.Sprite.BoundaryBox(blockEntity._position);
                if (enemyRectangle.Intersects(thisRectangle))
                {
                    enemyNotOnGround = false;
                }
                else
                {
                    if ((enemyRectangle.X <= thisRectangle.X + thisRectangle.Width - 3) && (enemyRectangle.X >= thisRectangle.X - enemyRectangle.Width + 3))
                    {
                        if (enemyRectangle.Y < thisRectangle.Y)
                        {
                            if (EnemyType.Equals("goomba") && (enemyRectangle.Y + 33) > thisRectangle.Y)
                            {
                                enemyNotOnGround = false;
                            }
                            else if ((enemyRectangle.Y + 65) > thisRectangle.Y)
                            {
                                enemyNotOnGround = false;
                            }
                        }
                    }
                }
            }
            if (enemyNotOnGround)
            {
                gravity = 5f;
            }
            else
            {
                gravity = 0;
            }

        }
    }
}
