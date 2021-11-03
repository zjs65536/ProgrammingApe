using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class FireballBlockCollide
    {
        public FireballBlockCollide()
        {
        }

        public void FireballBlockCollideCommand(FireballEntity fireball, BlockEntity blockEntity)
        {
            Rectangle fireballRectangle = fireball.Sprite.BoundaryBox(fireball._position);
            Rectangle blockRectangle = blockEntity.Sprite.BoundaryBox(blockEntity._position);
            Rectangle Intersect = Rectangle.Intersect(blockRectangle, fireballRectangle);
            if (Intersect.Width > Intersect.Height)
            {
                fireball._position.Y -= Intersect.Height;
                fireball.VelocityY = -125f;
            }
            else if (Intersect.Height >= Intersect.Width)
            {
                fireball.isDestroyed = true;
            }
        }
    }
}
