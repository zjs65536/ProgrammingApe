using Microsoft.Xna.Framework;

namespace Sprint_4
{
    public class UsedBlockStandardState : BlockState
    {
        public UsedBlockStandardState(BlockEntity blockEntity)
            : base(blockEntity)
        {
        }

        public override void Enter(IBlockState previousState)
        {           
            CurrentState = this;
            this.previousState = previousState;

            BlockEntity.blockState_Enum = BlockState_enum.UsedBlock;
          //  MarioEntity.Velocity = new Vector2(0, -1);
        }

     
    }
}
