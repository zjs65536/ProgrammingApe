using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Threading.Tasks;
using Controller_Command;

namespace Sprint_4
{
    class MarioBlockEntityCollide
    {
        Game1 Game;
        public MarioBlockEntityCollide(Game1 game)
        {
            Game = game;
        }

        public void MarioCollideBlockEntityCommand(MarioEntity marioEntity, BlockEntity blockEntity, List<ItemEntity> items)
        {
            marioEntity.Sprite.BoxColor = Color.Red;
            blockEntity.Sprite.BoxColor = Color.Red;
            Rectangle marioRectangle = marioEntity.Sprite.BoundaryBox(marioEntity._position);
            Rectangle blockRectangle = blockEntity.Sprite.BoundaryBox(blockEntity._position);
            Rectangle Intersect = Rectangle.Intersect(marioRectangle, blockRectangle);
            if(blockEntity.blockState_Enum != BlockState_enum.ExplodedBlock && blockEntity.blockState_Enum != BlockState_enum.Flagpole && marioEntity.MarioStatus_Enum != MarioStatus_enum.Dead)
            {
                if (Intersect.Width >= Intersect.Height)
                {
                    if (marioRectangle.Center.Y > blockRectangle.Center.Y)
                    {
                        marioEntity._position.Y += Intersect.Height;
                        marioEntity.MarioState.FallingTransition();
                        marioEntity.VelocityY = 50f;
                        if (blockEntity.blockState_Enum == BlockState_enum.QuestionBlock)
                        {
                            //  blockEntity.BlockState.BumpTransition();
                            blockEntity.Bump(items, marioEntity);
                            marioEntity.SoundManager.PlayBirckBump();
                        }
                        else if (blockEntity.blockState_Enum == BlockState_enum.BrickBlock)
                        {
                            if (marioEntity.MarioStatus_Enum == MarioStatus_enum.Standard)
                            {
                                // blockEntity.BlockState.BumpTransition();
                                blockEntity.Bump(items, marioEntity);
                                marioEntity.SoundManager.PlayBirckBump();
                            }
                            else if (marioEntity.MarioStatus_Enum == MarioStatus_enum.Super || marioEntity.MarioStatus_Enum == MarioStatus_enum.Fire)
                            {
                                blockEntity.BlockState.FallingTransition();
                                marioEntity.SoundManager.PlayBrickBreaks();
                            }
                        }
                        else if (blockEntity.blockState_Enum == BlockState_enum.HiddenBlock)
                        {
                            blockEntity.BlockState.StandardTransition();
                            marioEntity.SoundManager.PlayBirckBump();
                        }
                        
                    }
                    if (marioRectangle.Center.Y < blockRectangle.Center.Y)
                    {
                        marioEntity._position.Y -= Intersect.Height;
                        marioEntity.MarioState.IdleTransition();
                        if(marioEntity.MarioActionState_Enum == MarioActionState_enum.Flag)
                        {
                            Game.gameState_Enum = GameState_Enum.Win;
                        }
                        if (blockEntity.blockState_Enum == BlockState_enum.Pipe && marioEntity.MarioActionState_Enum == MarioActionState_enum.Idle)
                        {
                            
                            marioEntity._position = new Vector2(90, 510);
                            marioEntity.SoundManager.PlayPipeTravel();
                            Game.inHiddenRoom = true;
                        }
                    }
                }
                else if (Intersect.Height > Intersect.Width)
                {
                    if (marioRectangle.Center.X > blockRectangle.Center.X)
                    {
                        marioEntity._position.X += Intersect.Width;
                        marioEntity.VelocityX = 0f;
                        if (blockEntity.blockState_Enum == BlockState_enum.Pipe)
                        {
                            //  blockEntity.BlockState.BumpTransition();
                            blockEntity.piranha.EnemyState.PiranhaHideTransition();
                        }
                    }
                    if (marioRectangle.Center.X < blockRectangle.Center.X)
                    {
                        marioEntity._position.X -= Intersect.Width;
                        marioEntity.VelocityX = 0f;
                        if (blockEntity.blockState_Enum == BlockState_enum.Pipe)
                        {
                            //  blockEntity.BlockState.BumpTransition();
                            blockEntity.piranha.EnemyState.PiranhaHideTransition();
                        }
                        if (blockEntity.blockState_Enum == BlockState_enum.LeftPipe)
                        {

                            marioEntity._position = new Vector2(3136, 384);
                            marioEntity.SoundManager.PlayPipeTravel();
                            Game.inHiddenRoom = false;
                        }
                    }
                }
            }
            else if(blockEntity.blockState_Enum == BlockState_enum.Flagpole && !Game.FlagCounted)
            {
                int FlagpoleBottom = blockEntity.Sprite.BoundaryBox(blockEntity._position).Bottom;
                if (marioEntity._position.Y < FlagpoleBottom && marioEntity._position.Y <= (FlagpoleBottom - 34))
                    Game.gameHUD.Points += 100;
                else if (marioEntity._position.Y < (FlagpoleBottom - 34) && marioEntity._position.Y >= (FlagpoleBottom - 114))
                    Game.gameHUD.Points += 400;
                else if (marioEntity._position.Y < (FlagpoleBottom - 114) && marioEntity._position.Y >= (FlagpoleBottom - 162))
                    Game.gameHUD.Points += 800;
                else if (marioEntity._position.Y < (FlagpoleBottom - 162) && marioEntity._position.Y >= (FlagpoleBottom - 254))
                    Game.gameHUD.Points += 2000;
                else if (marioEntity._position.Y < (FlagpoleBottom - 254) && marioEntity._position.Y >= (FlagpoleBottom - 298))
                    Game.gameHUD.Points += 4000;
                else if (marioEntity._position.Y < (FlagpoleBottom - 298))
                    Game.marioEntity.marioLife++;
                marioEntity._position.X = blockEntity._position.X;
                marioEntity.MarioState.FlagTransition();
                Game.FlagCounted = true;
            }
        }
    }
}
