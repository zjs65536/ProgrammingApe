using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    class StarEntity : ItemEntity
    {
        public StarEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            ItemType = "Star";
            VelocityX = 50f;
            VelocityY = -100f;
            Sprite = spriteFactory.createItem(SpriteFactory.sprites.star, Position);
        }
    }
}
