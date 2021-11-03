using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public enum BrickState
    {
        coinBrick, emptyBrick, redBrick, greenBrick, flowerBrick, starBrick
    }


    public class BrickBlockEntity: BlockEntity
    {



      //  public IBlockState CurrentState { get; set; }
        private BlockChanging blockChanging;
        private BrickState _state;
        private float speedControl;
   
               
        //Method begin.
        public BrickBlockEntity(SpriteFactory spriteFactory, Vector2 Position, BrickState State) : base (spriteFactory, Position)
        {
            SpriteFactory = spriteFactory;
            speedControl = 15f;

            _position = Position;

            _state = State;

            BlockState = new BrickBlockStandardState(this);
            blockChanging = new BlockChanging(this);
            Sprite = spriteFactory.createBlock(SpriteFactory.sprites.brickBlock);
            BlockState.Enter(null);
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            _position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds * speedControl;
            blockChanging.Update();

            BlockState.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position );
        }

        public override void Bump(IList<ItemEntity> items, MarioEntity marioEntity)
        {
            BlockState?.BumpTransition();
            if (_state == BrickState.coinBrick)
            {
                items.Add(new CoinEntity(SpriteFactory, new Vector2(_position.X + 10, _position.Y - 32)));
                BlockState?.UsedTransition();
            }
            else if (_state == BrickState.redBrick)
            {

                items.Add(new PowerupMushroomEntity(SpriteFactory, new Vector2(_position.X, _position.Y - 32)));
                BlockState?.UsedTransition();
            }
            else if (_state == BrickState.flowerBrick)
            {
                items.Add(new FlowerEntity(SpriteFactory, new Vector2(_position.X, _position.Y - 32)));
                BlockState?.UsedTransition();
            }
            else if (_state == BrickState.greenBrick)
            {

                items.Add(new OneupMushroomEntity(SpriteFactory, new Vector2(_position.X, _position.Y - 32)));
                BlockState?.UsedTransition();
            }
            else if (_state == BrickState.starBrick)
            {
                items.Add(new StarEntity(SpriteFactory, new Vector2(_position.X, _position.Y - 32)));
                BlockState?.UsedTransition();
            }
            
        }

    }
}
