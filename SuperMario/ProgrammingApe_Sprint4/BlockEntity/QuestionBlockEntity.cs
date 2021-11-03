using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public enum QuestionState
    {
         coinQues, emptyQues, redQues, flowerQues
    }


    public class QuestionBlockEntity: BlockEntity
    {



      //  public IBlockState CurrentState { get; set; }
        private BlockChanging blockChanging;
        private QuestionState _state;
        private float speedControl;
   
               
        //Method begin.
        public QuestionBlockEntity(SpriteFactory spriteFactory, Vector2 Position, QuestionState State) : base (spriteFactory, Position)
        {
            SpriteFactory = spriteFactory;
            speedControl = 15f;

            _position = Position;
            _state = State;

            BlockState = new QuestionBlockStandardState(this);
            blockChanging = new BlockChanging(this);
            Sprite = spriteFactory.createBlock(SpriteFactory.sprites.questionBlock);
            BlockState.Enter(null);
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            _position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds * speedControl;
            blockChanging.Update();

            BlockState?.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }

        public override void Bump(IList<ItemEntity> items, MarioEntity marioEntity)
        {
            if (_state == QuestionState.coinQues)
            {
                items.Add(new CoinEntity(SpriteFactory, new Vector2(_position.X + 10, _position.Y - 16)));
            }
            else if (_state == QuestionState.redQues)
            {
                items.Add(new PowerupMushroomEntity(SpriteFactory, new Vector2(_position.X, _position.Y - 32)));
            }
            else if (_state == QuestionState.flowerQues)
            {
                items.Add(new FlowerEntity(SpriteFactory, new Vector2(_position.X, _position.Y - 32)));
            }
            BlockState?.BumpTransition();
        }

    }
}
