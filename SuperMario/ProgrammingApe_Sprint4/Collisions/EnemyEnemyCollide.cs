using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class EnemyEnemyCollide
    {
        private Game1 Game;
        public EnemyEnemyCollide(Game1 game)
        {
            Game = game;
        }

        public void EnemyCollideEnemyCommand(EnemyEntity enemy1, EnemyEntity enemy2)
        {
            enemy1.Sprite.BoxColor = Color.Red;
            enemy2.Sprite.BoxColor = Color.Red;
            if (!enemy1.EnemyType.Equals("deadGoomba") && !enemy2.EnemyType.Equals("deadGoomba"))
            {
                if ((!enemy1.EnemyType.Equals("koopaShell") && !enemy2.EnemyType.Equals("koopaShell")) 
                    || (enemy1.EnemyType.Equals("koopaShell") && enemy2.EnemyType.Equals("koopaShell")))
                {
                    if (enemy1._position.X < enemy2._position.X)
                    {
                        enemy1.VelocityX = -1f;
                        enemy2.VelocityX = 1f;
                    }
                    else
                    {
                        enemy1.VelocityX = 1f;
                        enemy2.VelocityX = -1f;
                    }
                }
                else if (enemy1.EnemyType.Equals("koopaShell") && !enemy2.EnemyType.Equals("koopaShell"))
                {
                    if(enemy1.VelocityX == 0)
                    {
                        if (enemy1._position.X < enemy2._position.X)
                            enemy2.VelocityX = 1f;
                        else
                            enemy2.VelocityX = -1f;
                    }
                    else
                    {
                        if (enemy2.EnemyType.Equals("goomba"))
                        {
                            Game.gameHUD.Points += 100;
                            enemy2.EnemyState.DieTransition();
                        }
                        else if (enemy2.EnemyType.Equals("koopaStandard"))
                            enemy2.EnemyState.ShellTransition();
                    }
                }
                else if (!enemy1.EnemyType.Equals("koopaShell") && enemy2.EnemyType.Equals("koopaShell"))
                {
                    if (enemy2.VelocityX == 0)
                    {
                        if (enemy2._position.X < enemy1._position.X)
                            enemy1.VelocityX = 1f;
                        else
                            enemy1.VelocityX = -1f;
                    }
                    else
                    {
                        if (enemy2.EnemyType.Equals("goomba"))
                        {
                            Game.gameHUD.Points += 100;
                            enemy2.EnemyState.DieTransition();
                        }
                        else if (enemy1.EnemyType.Equals("koopaStandard"))
                            enemy1.EnemyState.ShellTransition();
                    }
                }
            }
        }
    }
}
