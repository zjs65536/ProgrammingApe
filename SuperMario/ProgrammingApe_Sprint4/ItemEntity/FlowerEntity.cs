using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    class FlowerEntity : ItemEntity
    {
        public FlowerEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            ItemType = "Flower";
            Sprite = spriteFactory.createItem(SpriteFactory.sprites.flower, Position);
        }
    }
}
