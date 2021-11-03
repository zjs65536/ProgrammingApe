using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
 


    public class HiddenBlockEntity: BlockEntity
    {



      //  public IBlockState CurrentState { get; set; }
        private BlockChanging blockChanging;
        private float speedControl;
   
               
        //Method begin.
        public HiddenBlockEntity(SpriteFactory spriteFactory, Vector2 Position) : base (spriteFactory, Position)
        {
            SpriteFactory = spriteFactory;
            speedControl = 15f;
    
            _position = Position;

            BlockState = new HiddenBlockStandardState(this);
            blockChanging = new BlockChanging(this);
            Sprite = spriteFactory.createBlock(SpriteFactory.sprites.hiddenBlock);
            BlockState.Enter(null);
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            _position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds * speedControl;
            blockChanging.Update();

        //    BlockState?.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }

    }
}
