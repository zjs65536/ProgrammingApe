using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class WarriorBlockCollide
    {
        private Game1 Game;

        public WarriorBlockCollide(Game1 game)
        {
            Game = game;
        }

        public void WarriorBlockCollideResponse(WarriorEntity warrior, BlockEntity block)
        {
            Rectangle WarriorRectangle = warrior.GetBoundaryBox();
            Rectangle BlockRectangle = block.GetBoundaryBox();
            Rectangle Intersect = Rectangle.Intersect(WarriorRectangle, BlockRectangle);

            if (Intersect.Width > Intersect.Height)
            {
                if (WarriorRectangle.Center.Y > BlockRectangle.Center.Y) // From Bottom
                {
                    warrior.Position += new Vector2(0, Intersect.Height);
                }
                if (WarriorRectangle.Center.Y < BlockRectangle.Center.Y) // From Top
                {
                    warrior.Position -= new Vector2(0, Intersect.Height);
                    warrior.WarriorActionState.StandingTransition();
                }
                warrior.VelocityY = 0;
            }
            else if (Intersect.Height >= Intersect.Width)
            {
                if (WarriorRectangle.Center.X > BlockRectangle.Center.X) // From Right
                {
                    warrior.Position += new Vector2(Intersect.Width, 0);
                }
                if (WarriorRectangle.Center.X < BlockRectangle.Center.X) // From Left
                {
                    warrior.Position -= new Vector2(Intersect.Width, 0);
                }
            }
        }
    }
}
