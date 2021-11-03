using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class WarriorEnemyCollide
    {
        private Game1 Game;

        public WarriorEnemyCollide(Game1 game)
        {
            Game = game;
        }

        public void WarriorEnemyCollideResponse(WarriorEntity warrior, EnemyEntity enemy)
        {
            Rectangle WarriorRectangle = warrior.GetBoundaryBox();
            Rectangle EnemyRectangle = enemy.GetBoundaryBox();
            Rectangle Intersect = Rectangle.Intersect(WarriorRectangle, EnemyRectangle);

            if (Intersect.Width > Intersect.Height)
            {
                if (WarriorRectangle.Center.Y > EnemyRectangle.Center.Y)
                {
                    //
                }
                if (WarriorRectangle.Center.Y < EnemyRectangle.Center.Y)
                {
                    //
                }
            }
            else if (Intersect.Height >= Intersect.Width)
            {
                if (WarriorRectangle.Center.X > EnemyRectangle.Center.X)
                {
                    //
                }
                if (WarriorRectangle.Center.X < EnemyRectangle.Center.X)
                {
                    //
                }
            }
        }
    }
}
