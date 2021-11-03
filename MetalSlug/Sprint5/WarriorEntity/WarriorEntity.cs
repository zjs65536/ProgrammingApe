using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint5
{
    public abstract class WarriorEntity
    {
        #region Properties
        public Game1 Game;
        public WarriorChanging WarriorChanging;
        public IWarriorActionState WarriorActionState { get; set; }
        public ISprite Sprite { get; set; }

        //Position Releted.
        public Vector2 StartPosition;
        public Vector2 Position;
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public float AccelarationY { get; set; }
        public float AccelarationX { set; get; }
        public float Gravity { get; set; }

        // Warrior Status related
        public int WarriorLife { get; set; }
        public int HealthPoint { get; set; }
        public WarriorFacing WarriorFacing { get; set; }
        public WarriorWeaponState WarriorWeaponState { get; set; }
        public WarriorState WarriorState { get; set; }
        public bool HaveGravity { get; set; }
        public int WeaponAmmo;
        public int FireCD;
        public WarriorName WarriorName;

        public WarriorFacing previousWarriorFacing;
        public WarriorWeaponState previosWarriorWeaponState;
        public WarriorState previousWarriorState;

        private bool waitForRevival;
        private float timerRevival;

        #endregion

        protected WarriorEntity(Game1 game)
        {
            Game = game;
            WarriorChanging = new WarriorChanging(this);
        }

        public virtual void Load()
        {
            Position = StartPosition;
            VelocityX = 0;
            VelocityY = 0;
            AccelarationY = 0;
            AccelarationX = 0;

            HealthPoint = 100;
            WarriorLife = 2;
            WeaponAmmo = -1;
            FireCD = 0;

            WarriorActionState = new WarriorStandState(this);
        }

        public virtual void Update(GameTime gameTime, List<BlockEntity> blockEntities)
        {
            Sprite.Update(gameTime);
            VelocityY += (AccelarationY + Gravity) * (float)gameTime.ElapsedGameTime.TotalSeconds;
            VelocityX += AccelarationX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.X += VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.Y += VelocityY * (float)gameTime.ElapsedGameTime.TotalSeconds;

            SpriteUpdate();
            HealthSystem(gameTime);
            BoundaryCheck();
            GroundCheck(blockEntities);
            MovementControl();

            if(FireCD > 0)
                FireCD--;
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

        public virtual void ChangeToPistol()
        {
            WarriorWeaponState = WarriorWeaponState.Pistal;
            WeaponAmmo = -1;
        }

        #region Update Related Method.
        public virtual void SpriteUpdate() 
        {
            if(previosWarriorWeaponState != WarriorWeaponState || previousWarriorFacing != WarriorFacing || previousWarriorState != WarriorState)
            {
                WarriorChanging.Update();

                previosWarriorWeaponState = WarriorWeaponState;
                previousWarriorFacing = WarriorFacing;
                previousWarriorState = WarriorState;
            }
        }
        public virtual void HealthSystem(GameTime gameTime)
        {
            if (HealthPoint <= 0 && !waitForRevival)
            {
                WarriorActionState.DieTransition();
                if (WarriorLife >= 1)
                {
                    WarriorLife--;
                    waitForRevival = true;
                    timerRevival = 3;
                }
            }

            if (timerRevival >= 0)
            {
                timerRevival -= 1 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (waitForRevival && timerRevival <= 0)
            {
                waitForRevival = false;
                HealthPoint = 100;
                WarriorActionState.StandingTransition();
            }
        }
        public virtual void BoundaryCheck()
        {
            if(HealthPoint != 0)
            {
                if (Position.X < 0)
                {
                    WarriorActionState.StandingTransition();
                    Position.X += 2;
                }

                if (Position.X < Game.CameraPosition.X - Game.GraphicsDevice.Viewport.Width / 2 + 15)
                {
                    WarriorActionState.StandingTransition();
                    Position.X += 2;
                }

                if (Position.X > Game.CameraPosition.X + Game.GraphicsDevice.Viewport.Width / 2 - 15)
                {
                    WarriorActionState.StandingTransition();
                    Position.X -= 2;
                }
            }
        }
        public virtual void GroundCheck(List<BlockEntity> blockEntities)
        {
            bool notOnGround = true;
            Rectangle warriorRectangle = Sprite.BoundaryBox(Position);
            foreach (BlockEntity blockEntity in blockEntities)
            {
                Rectangle thisRectangle = blockEntity.Sprite.BoundaryBox(blockEntity.Position);
                if (warriorRectangle.Intersects(thisRectangle))
                {
                    notOnGround = false;
                }
                else
                {
                    if ((warriorRectangle.X <= thisRectangle.X + thisRectangle.Width) && (warriorRectangle.X >= thisRectangle.X - warriorRectangle.Width))
                    {
                        if (warriorRectangle.Y < thisRectangle.Y)
                        {
                            if ((warriorRectangle.Y + warriorRectangle.Height + 5) > thisRectangle.Y)
                            {
                                notOnGround = false;
                            }
                        }
                    }
                }
            }
            if (notOnGround)
            {
                HaveGravity = true;
            }
        }

        public virtual void MovementControl()
        {
            // Gravity
            if (HaveGravity)
                Gravity = 800f;
            else
                Gravity = 0f;


            //Spead
            if(VelocityX > 120f)
            {
                AccelarationX = 0;
                VelocityX = 120f;
            }
            else if(VelocityX < -120f)
            {
                AccelarationX = 0;
                VelocityX = -120f;
            }

        }
        #endregion
    }
}
