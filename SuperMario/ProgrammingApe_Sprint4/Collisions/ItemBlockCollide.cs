using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    class ItemBlockCollide
    {
        public ItemBlockCollide()
        {
        }

        public void ItemCollideBlockCommand(ItemEntity itemEntity, BlockEntity blockEntity)
        {
            itemEntity.Sprite.BoxColor = Color.Red;
            blockEntity.Sprite.BoxColor = Color.Red;
            Rectangle itemRectangle = itemEntity.getBoundingBox();
            Rectangle blockRectangle = blockEntity.Sprite.BoundaryBox(blockEntity._position);
            Rectangle Intersect = Rectangle.Intersect(itemRectangle, blockRectangle);
            if (Intersect.Width > Intersect.Height)
            {
                if (itemRectangle.Center.Y > blockRectangle.Center.Y)
                {
                    itemEntity._position.Y += Intersect.Height;
                    if (itemEntity.ItemType.Equals("Star"))
                    {
                        itemEntity.VelocityY = 150f;
                        itemEntity.gravity = 250f;
                    }
                    else
                        itemEntity.VelocityY = 0f;
                }
                if (itemRectangle.Center.Y < blockRectangle.Center.Y)
                {
                    itemEntity._position.Y -= Intersect.Height;
                    if (itemEntity.ItemType.Equals("Star"))
                    {
                        itemEntity.VelocityY = -150f;
                        itemEntity.gravity = 250f;
                    }
                    else
                        itemEntity.VelocityY = 0f;
                }
                
            }
            else if (Intersect.Height >= Intersect.Width && blockEntity._position.Y < itemEntity.getBoundingBox().Bottom)
            {
                if (itemRectangle.Center.X > blockRectangle.Center.X)
                {
                    itemEntity._position.X += Intersect.Width;
                }
                if (itemRectangle.Center.X < blockRectangle.Center.X)
                {
                    itemEntity._position.X -= Intersect.Width;
                }
                itemEntity.ChangeDirection();
            }
        }
    }
}
