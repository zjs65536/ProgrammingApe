using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    class CoinEntity : ItemEntity
    {
        public CoinEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            ItemType = "Coin";
            Sprite = spriteFactory.createItem(SpriteFactory.sprites.coin, Position);
        }
    }
}
