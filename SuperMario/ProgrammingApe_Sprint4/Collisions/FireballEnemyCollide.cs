using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_4
{
    class FireballEnemyCollide
    {
        private Game1 Game;
        public FireballEnemyCollide(Game1 game)
        {
            Game = game;
        }

        public void FireballEnemyCollideCommand(EnemyEntity enemy)
        {
            if(enemy.EnemyType.Equals("piranha"))
                Game.gameHUD.Points += 200;
            else
                Game.gameHUD.Points += 100;
        }
    }
}
