using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class EnemyBlockCollide
    {
        private Game1 Game;

        public EnemyBlockCollide(Game1 game)
        {
            Game = game;
        }

        public void EnemyBlockCollideResponse(EnemyEntity enemy, BlockEntity block)
        {
            Rectangle EnemyRectangle = enemy.GetBoundaryBox();
            Rectangle BlockRectangle = block.GetBoundaryBox();
            Rectangle Intersect = Rectangle.Intersect(EnemyRectangle, BlockRectangle);

            if (Intersect.Width > Intersect.Height) 
            {
                if (EnemyRectangle.Center.Y > BlockRectangle.Center.Y) // From Bottom
                {
                    enemy.Position += new Vector2(0, Intersect.Height);
                }
                if (EnemyRectangle.Center.Y < BlockRectangle.Center.Y) // From Top
                {
                    enemy.Position -= new Vector2(0, Intersect.Height);
                }
            }
            else if (Intersect.Height >= Intersect.Width)
            {
                if (EnemyRectangle.Center.X > BlockRectangle.Center.X) // From Right
                {
                    enemy.Position += new Vector2(Intersect.Width, 0);
                }
                if (EnemyRectangle.Center.X < BlockRectangle.Center.X) // From Left
                {
                    enemy.Position -= new Vector2(Intersect.Width, 0);
                }
                enemy.ChangeFacing();
            }
        }
    }
}
