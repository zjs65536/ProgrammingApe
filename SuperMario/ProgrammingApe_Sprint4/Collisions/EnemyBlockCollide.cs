using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    class EnemyBlockCollide
    {
        public EnemyBlockCollide()
        {
        }

        public void EnemyCollideBlockCommand(EnemyEntity enemyEntity, BlockEntity blockEntity)
        {
            enemyEntity.Sprite.BoxColor = Color.Red;
            blockEntity.Sprite.BoxColor = Color.Red;
            Rectangle enemyRectangle = enemyEntity.getBoundingBox();
            Rectangle blockRectangle = blockEntity.Sprite.BoundaryBox(blockEntity._position);
            Rectangle Intersect = Rectangle.Intersect(enemyRectangle, blockRectangle);
            if (Intersect.Width > Intersect.Height && enemyEntity.EnemyState_Enum != EnemyState_enum.Piranha)
            {
                if (enemyRectangle.Center.Y > blockRectangle.Center.Y)
                {
                    enemyEntity._position.Y += Intersect.Height;
                }
                if (enemyRectangle.Center.Y < blockRectangle.Center.Y)
                {
                    enemyEntity._position.Y -= Intersect.Height;
                }
                enemyEntity.isOnGround = true;
                enemyEntity.VelocityY = 0;
            }
            else if (Intersect.Height >= Intersect.Width && blockEntity._position.Y < enemyEntity.getBoundingBox().Bottom && enemyEntity.EnemyState_Enum != EnemyState_enum.Piranha)
            {
                if (enemyRectangle.Center.X > blockRectangle.Center.X)
                {
                    enemyEntity._position.X += Intersect.Width;
                }
                if (enemyRectangle.Center.X < blockRectangle.Center.X)
                {
                    enemyEntity._position.X -= Intersect.Width;
                }
                enemyEntity.ChangeDirection();
            }
        }
    }
}
