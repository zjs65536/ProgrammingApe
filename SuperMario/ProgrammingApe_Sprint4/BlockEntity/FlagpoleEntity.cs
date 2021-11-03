using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_4
{
    public class FlagpoleEntity : BlockEntity
    {
        //Method begin.
        public FlagpoleEntity(SpriteFactory spriteFactory, Vector2 Position) : base(spriteFactory, Position)
        {
            SpriteFactory = spriteFactory;
            _position = Position;
            Sprite = spriteFactory.createBlock(SpriteFactory.sprites.flagpole);
            blockState_Enum = BlockState_enum.Flagpole;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }
    }
}
