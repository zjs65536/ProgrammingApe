using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class WarriorBulletCollide
    {
        private Game1 Game;

        public WarriorBulletCollide(Game1 game)
        {
            Game = game;
        }

        public void WarriorBulletCollideResponse(WarriorEntity warrior, BulletEntity bullet)
        {
            if (bullet.BulletSource == BulletSource.Enemy && warrior.HealthPoint > 0 && Game.GameState == GameState.Playing)
            {
                bullet.isDestroyed = true;
                warrior.HealthPoint -= bullet.Damage;
                if (warrior.HealthPoint < 0)
                    warrior.HealthPoint = 0;
            }
        }
    }
}
