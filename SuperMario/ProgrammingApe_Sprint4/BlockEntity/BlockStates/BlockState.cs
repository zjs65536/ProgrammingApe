using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    

    
    public abstract class BlockState : IBlockState
    {
        #region The variables
        protected IBlockState previousState;

        // MarioEntity is the one we call in the MarioState.
        public BlockEntity BlockEntity{ get; protected set;}

        protected IBlockState CurrentState 
        {
            get { return BlockEntity.BlockState; }
            set { BlockEntity.BlockState = value; }
        }

        IBlockState IBlockState.PreviouseState { get { return previousState; } }          
        #endregion



        // Method
        protected BlockState(BlockEntity entity) 
        {
            BlockEntity = entity;
        }

        public virtual void Enter(IBlockState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }

        public virtual void Exit() { }
        public virtual void StandardTransition() { }
        public virtual void UsedTransition() { }
        public virtual void BumpTransition() { }
        public virtual void FallingTransition() { }

        public virtual void Update(GameTime gameTime) { }
    }
}
