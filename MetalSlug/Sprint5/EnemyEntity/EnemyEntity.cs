using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public abstract class EnemyEntity
    {
        public Game1 Game;
        public ISprite Sprite;
        public List<BulletEntity> Bullets;
        public EnemyChanging EnemyChanging;
        public Vector2 Position;
        public Vector2 StartPosition;
        public Vector2 Velocity;

        public EnemyFacing EnemyFacing;
        public EnemyState EnemyState;
        public EnemyType EnemyType;

        public EnemyFacing PreviousEnemyFacing;
        public EnemyState PreviousEnemyState;

        public IEnemyActionState EnemyActionState;
        public WarriorWeaponState EnemyWeapon;
        public int LifePoints;
        public int FireCD;
        public int DestroyPoint;
        public int ClearTime;
        public bool isDead;
        protected EnemyEntity(Game1 game, Vector2 position, List<BulletEntity> bullets)
        {
            Game = game;
            Bullets = bullets;
            EnemyChanging = new EnemyChanging(this);
            Position = position;
            StartPosition = position;
            FireCD = 0;
            ClearTime = 100;
            isDead = false;

            EnemyFacing = EnemyFacing.Left;
            PreviousEnemyFacing = EnemyFacing.Left;
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);

            Position.X += Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.Y += Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (PreviousEnemyFacing != EnemyFacing || PreviousEnemyState != EnemyState)
            {
                EnemyChanging.Update();

                PreviousEnemyFacing = EnemyFacing;
                PreviousEnemyState = EnemyState;
            }

            if (FireCD != 0)
                FireCD--;
            if (isDead)
                ClearTime--;

            PositionCheck();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public virtual Rectangle GetBoundaryBox()
        {
            return Sprite.BoundaryBox(Position);
        }

        public virtual void ChangeFacing()
        {
            if (EnemyFacing == EnemyFacing.Left)
                EnemyActionState.FaceRightTransition();
            else
                EnemyActionState.FaceLeftTransition();
        }

        public virtual void Fire()
        {
            
        }

        public virtual void PositionCheck()
        {
            if(Position.X > StartPosition.X + 60)
            {
                EnemyActionState.FaceLeftTransition();
                Velocity = new Vector2(-50f, 0);
            }
            
            if(Position.X < StartPosition.X - 60)
            {
                EnemyActionState.FaceRightTransition();
                Velocity = new Vector2(50f, 0);
            }
        }
    }
}
