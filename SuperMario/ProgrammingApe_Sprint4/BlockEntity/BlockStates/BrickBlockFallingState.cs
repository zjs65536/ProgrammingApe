using Microsoft.Xna.Framework;
using System;

namespace Sprint_4
{
    public class BrickBlockFallingState : BlockState
    {


        public BrickBlockFallingState(BlockEntity blockEntity)
            : base(blockEntity)
        {
        }

        public override void Enter(IBlockState previousState)
        {           
            CurrentState = this;
            this.previousState = previousState;
          

            BlockEntity.blockState_Enum = BlockState_enum.ExplodedBlock;
        

        
            BlockEntity.Velocity = new Vector2(0, 5);
        }


      
    }
}
