using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint_4
{
    public enum SpriteFacing_enum
    {
        Left,
        Right
    }

    public enum MarioActionState_enum
    {
        Idle, Crouching, Jumping, Falling, Running, Dead, Flag
    }

    public enum MarioStatus_enum
    {
        Standard, Super, Fire, Dead
    }

    public class MarioEntity
    {
        #region Properties
        public IMario Sprite { get; set; }
        public Game1 Game;

        // Position and movement
        public int YMax;
        public Vector2 startPoint;
        public Vector2 _position;
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public float gravity;
        public float xAccelaration;
        public float yAccelaration;
        public bool gravityExit;

        //MarioState
        public int marioLife;
        public float ResetTime;
        public float WinProcessTime;
        public bool levelReset;
        bool DoReset;


        public SoundManager SoundManager { get; set; }
        public MarioActionState_enum MarioActionState_Enum { get; set; }
        public MarioStatus_enum MarioStatus_Enum { get; set; }
        public SpriteFacing_enum SpriteFacing { get; set; }
        public IMarioActionState MarioState { get; set; }
        private MarioChanging marioChanging;
        private MarioActionState_enum previousMarioState;
        private MarioStatus_enum previousMarioStatus;
        private SpriteFacing_enum previousSpriteFacing;

        // Graph
        public SpriteFactory SpriteFactory { get; set; }
        private Camera Camera;
        private bool showBox;
        #endregion

        //Method begin.
        public MarioEntity(Game1 game)
        {
            Game = game;
            YMax = Game.GraphicsDevice.Viewport.Height;
            marioLife = 3;
            startPoint = new Vector2(160, 384);
        }

        public void Load(SpriteFactory spriteFactory, Camera camera, SoundManager soundManager)
        {
            Camera = camera;
            SoundManager = soundManager;
            gravityExit = false;
            _position = startPoint;
            gravity = 0;
            xAccelaration = 0f;
            yAccelaration = 0f;
            levelReset = false;
            ResetTime = 4f;
            DoReset = false;
            SpriteFactory = spriteFactory;
            showBox = spriteFactory.Game.showBox;
            SpriteFacing = SpriteFacing_enum.Right;
            MarioActionState_Enum = MarioActionState_enum.Idle;
            MarioStatus_Enum = MarioStatus_enum.Standard;

            previousMarioState = MarioActionState_Enum;
            previousMarioStatus = MarioStatus_Enum;
            previousSpriteFacing = SpriteFacing;

            MarioState = new MarioIdleState(this);
            marioChanging = new MarioChanging(this);
            Sprite = SpriteFactory.createSprite(SpriteFactory.sprites.marioIdleRight);
        }

        public void TakeDamage()
        {
            if (MarioStatus_Enum == MarioStatus_enum.Fire || MarioStatus_Enum == MarioStatus_enum.Super)
            {
                MarioStatus_Enum = MarioStatus_enum.Standard;
                _position.Y += 16;
            }
            else
            {
                SoundManager.PlayMarioDie();
                levelReset = true;
            }
        }

        public void Update(GameTime gameTime, List<BlockEntity> blockEntities)
        {
            showBox = SpriteFactory.Game.showBox;
            Sprite.ShowBoundary = showBox;

            MarioDeadCheck();
            BoundaryCheck();
            MarioStateAndStatusCheck();
            if(MarioStatus_Enum != MarioStatus_enum.Dead)
                groundCheck(blockEntities);
            if (DoReset)
                ResetTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (VelocityX <= 200f && VelocityX >= -200f)
            {
                VelocityX += xAccelaration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            VelocityY += (gravity + yAccelaration) * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position.X += VelocityX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position.Y += VelocityY * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }

        public void MarioStateAndStatusCheck()
        {
            if (VelocityY > 0)
            {
                MarioState.FallingTransition();
            }

            if (previousMarioState != MarioActionState_Enum || previousMarioStatus != MarioStatus_Enum || previousSpriteFacing != SpriteFacing)
            {
                marioChanging.Update();
                if (previousMarioStatus != MarioStatus_Enum && previousMarioStatus == MarioStatus_enum.Standard && MarioActionState_Enum != MarioActionState_enum.Dead)
                {
                    SoundManager.PlayGainPowerUp();
                }
                previousMarioState = MarioActionState_Enum;
                previousMarioStatus = MarioStatus_Enum;
                previousSpriteFacing = SpriteFacing;
            }
        }

        public void MarioDeadCheck()
        {
            if(levelReset)
            {
                MarioState.DieTransition();
                DoReset = true;
                if (ResetTime <= 0f)
                {
                    
                    marioLife--;
                    if (marioLife > 0)
                    {
                        levelReset = false;

                        if (_position.X > 800 && _position.X < 2112)
                        {
                            startPoint.X = 768;
                        }
                        else if (_position.X >= 2112)
                        {
                            startPoint.X = 2144;
                        }
                        Game.Reset();
                    }
                    else
                    {
                        startPoint = new Vector2(160, 384);
                        Game.gameState_Enum = GameState_Enum.Lose;
                    }
                }
            }
        }
        public void BoundaryCheck()
        {
            if (Sprite.BoundaryBox(_position).Bottom >= YMax)
            {
                if(MarioStatus_Enum != MarioStatus_enum.Dead)
                {
                    this.SoundManager.PlayMarioDie();
                    MarioState.DieTransition();
                    marioLife--;
                    levelReset = true;
                }
            }
            if (_position.X < 0)
            {
                MarioState.IdleTransition();
                _position.X += 2;
            }
        }

        public void groundCheck(List<BlockEntity> blockEntities)
        {
            bool marioNotOnGround = true;
            Rectangle marioRectangle = Sprite.BoundaryBox(_position);
            foreach (BlockEntity blockEntity in blockEntities)
            {
                Rectangle thisRectangle = blockEntity.Sprite.BoundaryBox(blockEntity._position);
                if (marioRectangle.Intersects(thisRectangle))
                {
                    marioNotOnGround = false;
                }
                else
                {
                    if ((marioRectangle.X <= thisRectangle.X + thisRectangle.Width-3) && (marioRectangle.X >= thisRectangle.X - marioRectangle.Width+3))
                    {
                        if (marioRectangle.Y < thisRectangle.Y)
                        {
                            if ((MarioStatus_Enum == MarioStatus_enum.Super || MarioStatus_Enum == MarioStatus_enum.Fire) && (marioRectangle.Y + 65) > thisRectangle.Y)
                            {
                                marioNotOnGround = false;
                            }
                            else if ((marioRectangle.Y + 33) > thisRectangle.Y)
                            {
                                marioNotOnGround = false;
                            }
                        }
                    }
                }
            }
            if (marioNotOnGround)
            {
                gravity = 800f;
            }
            else
            {
                gravity = 0;
            }
                
        }

    }
}
