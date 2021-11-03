using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class EnemyBulletCollide
    {
        private Game1 Game;

        public EnemyBulletCollide(Game1 game)
        {
            Game = game;
        }

        public void EnemyBulletCollideResponse(EnemyEntity enemy, BulletEntity bullet)
        {
            if ((bullet.BulletSource == BulletSource.Marco || bullet.BulletSource == BulletSource.Tarma) && !enemy.isDead)
            {
                bullet.isDestroyed = true;
                enemy.LifePoints -= bullet.Damage;
                if (enemy.LifePoints <= 0)
                {
                    if (enemy.EnemyType == EnemyType.Boss)
                    {
                        Game.SoundManager.PlayBossDie();
                        Game.GameState = GameState.Win;
                    }
                    else if (enemy.EnemyType == EnemyType.Bunker)
                        Game.SoundManager.PlayBunkerDie();
                    else
                        Game.SoundManager.PlayGeneralDie();
                    enemy.isDead = true;
                    enemy.EnemyActionState.DieTransition();
                }

                if (bullet.BulletSource == BulletSource.Marco)
                    Game.GameHUD.MarcoPoint += enemy.DestroyPoint;
                else
                    Game.GameHUD.TarmaPoint += enemy.DestroyPoint;
            }
        }
    }
}
