using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    class OneupMushroomEntity : ItemEntity
    {
        public OneupMushroomEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            ItemType = "OUMushroom";
            VelocityX = 50f;
            Sprite = spriteFactory.createItem(SpriteFactory.sprites.greenMushroom, Position);
        }
    }
}
