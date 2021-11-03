using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class BulletBlockCollide
    {
        private Game1 Game;

        public BulletBlockCollide(Game1 game)
        {
            Game = game;
        }

        public void BulletBlockCollideResponse(BulletEntity bullet, BlockEntity block)
        {
            bullet.isDestroyed = true;
            if(block.BlockEnum == BlockEnum.WoodenBox)
            {
                block.BreakPoint -= bullet.Damage;
                if (block.BreakPoint <= 0)
                    block.isDestroyed = true;
            }
        }
    }
}
