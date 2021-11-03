using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public class LongPipeEntity : BlockEntity
    {

        public LongPipeEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            SpriteFactory = spriteFactory;
            _position = Position;

            Sprite = spriteFactory.createBlock(SpriteFactory.sprites.longPipe);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }

    }
}