using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
 
    public enum BlockState_enum
    {
        QuestionBlock,
        UsedBlock,

        BrickBlock,
        HiddenBlock,
        Pipe,
        LeftPipe,
        LongPipe,

        ExplodedBlock,
        Flagpole
    }


    public abstract class BlockEntity
    {
        
        public IBlock Sprite { get; set; }
        public Vector2 _position;
        public BlockState_enum blockState_Enum { get; set; }
        public IBlockState BlockState { get; set; }
        //private BlockChanging blockChanging;
        public Vector2 Velocity { get; set; }
        //private float speedControl;
        public SpriteFactory SpriteFactory { get; set; }
        public EnemyEntity piranha;

        //Method begin.
        protected BlockEntity(SpriteFactory spriteFactory, Vector2 Position)
        {
            _position = Position;
            SpriteFactory = spriteFactory;
        }


        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            _position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds; //* speedControl;
            //blockChanging.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, _position);
        }
        public virtual void Bump(IList<ItemEntity> items, MarioEntity marioEntity)
        {

           // items.Add(SpriteFactory.createItem(SpriteFactory.sprites.star, new Vector2(_position.X, _position.Y - 16)));

            BlockState?.BumpTransition();
        }

    }
}
