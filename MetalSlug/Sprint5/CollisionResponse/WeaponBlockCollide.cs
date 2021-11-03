using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class WeaponBlockCollide
    {
        private Game1 Game;

        public WeaponBlockCollide(Game1 game)
        {
            Game = game;
        }

        public void WeaponBlockCollideResponse(WeaponEntity weapon, BlockEntity block)
        {
            Rectangle WeaponRectangle = weapon.GetBoundaryBox();
            Rectangle BlockRectangle = block.GetBoundaryBox();
            Rectangle Intersect = Rectangle.Intersect(WeaponRectangle, BlockRectangle);

            if (Intersect.Width > Intersect.Height)
            {
                if (WeaponRectangle.Center.Y > BlockRectangle.Center.Y) // From Bottom
                {
                    weapon.Position += new Vector2(0, Intersect.Height);
                }
                if (WeaponRectangle.Center.Y < BlockRectangle.Center.Y) // From Top
                {
                    weapon.Position -= new Vector2(0, Intersect.Height);
                }
            }
            else if (Intersect.Height >= Intersect.Width)
            {
                if (WeaponRectangle.Center.X > BlockRectangle.Center.X) // From Right
                {
                    weapon.Position += new Vector2(0, Intersect.Width);
                }
                if (WeaponRectangle.Center.X < BlockRectangle.Center.X) // From Left
                {
                    weapon.Position -= new Vector2(0, Intersect.Width);
                }
            }
        }
    }
}
