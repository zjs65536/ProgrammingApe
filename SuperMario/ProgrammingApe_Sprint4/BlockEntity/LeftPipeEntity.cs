using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public class LeftPipeEntity : BlockEntity
    {

        public LeftPipeEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            SpriteFactory = spriteFactory;
            _position = Position;

            blockState_Enum = BlockState_enum.LeftPipe;
            Sprite = spriteFactory.createBlock(SpriteFactory.sprites.leftPipe);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }

    }
}