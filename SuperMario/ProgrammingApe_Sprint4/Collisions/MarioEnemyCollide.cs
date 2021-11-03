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
    class MarioEnemyCollide
    {
        private Game1 Game { get; set; }
        public MarioEnemyCollide(Game1 game)
        {
            Game = game;
        }

        public void MarioCollideEnemyCommand(MarioEntity marioEntity, EnemyEntity enemy)
        {
            marioEntity.Sprite.BoxColor = Color.Red;
            enemy.Sprite.BoxColor = Color.Red;
            Rectangle marioRectangle = marioEntity.Sprite.BoundaryBox(marioEntity._position);
            Rectangle enemyRectangle = enemy.getBoundingBox();
            Rectangle Intersect = Rectangle.Intersect(marioRectangle, enemyRectangle);
            if (!enemy.EnemyType.Equals("deadGoomba") && marioEntity.MarioStatus_Enum != MarioStatus_enum.Dead)
            {
                if (Intersect.Width >= Intersect.Height)
                {
                    if (marioRectangle.Center.Y > enemyRectangle.Center.Y)
                    {
                        marioEntity._position.Y += Intersect.Height;
                        marioEntity.TakeDamage();
                        marioEntity.VelocityY = 0;
                    }
                    if (marioRectangle.Center.Y < enemyRectangle.Center.Y)
                    {
                        marioEntity._position.Y -= Intersect.Height;
                        marioEntity.SoundManager.PlayMarioStomp();
                        marioEntity.MarioState.LandingTransition();
                        if (enemy.EnemyType.Equals("goomba"))
                        {
                            Game.gameHUD.Points += 100;
                            enemy.EnemyState.DieTransition();
                        }
                        if (enemy.EnemyType.Equals("koopaStandard"))
                        {
                            Game.gameHUD.Points += 100;
                            enemy.EnemyState.ShellTransition();
                        }
                        if (enemy.EnemyType.Equals("koopaShell"))
                        {
                            if(enemy.VelocityX == 0)
                            {
                                if (marioEntity._position.X <= enemy._position.X)
                                    enemy.VelocityX = 5f;
                                else
                                    enemy.VelocityX = -5f;
                            }
                            else
                            {
                                enemy.VelocityX = 0;
                            }
                            Game.gameHUD.Points += 100;
                        }
                        marioEntity.VelocityY = -125f;
                    }
                }
                else if (Intersect.Height > Intersect.Width)
                {
                    if (marioRectangle.Center.X > enemyRectangle.Center.X)
                    {
                        marioEntity._position.X += Intersect.Width;
                        if (enemy.EnemyType.Equals("koopaShell") && enemy.VelocityX == 0)
                            enemy.VelocityX = -5f;
                        else
                        {
                            marioEntity.MarioState.IdleTransition();
                            marioEntity.TakeDamage();
                        }
                    }
                    if (marioRectangle.Center.X < enemyRectangle.Center.X)
                    {
                        marioEntity._position.X -= Intersect.Width;
                        if (enemy.EnemyType.Equals("koopaShell") && enemy.VelocityX == 0)
                            enemy.VelocityX = 5f;
                        else
                        {
                            marioEntity.MarioState.IdleTransition();
                            marioEntity.TakeDamage();
                        }
                    }
                }
            }
        }
    }
}
