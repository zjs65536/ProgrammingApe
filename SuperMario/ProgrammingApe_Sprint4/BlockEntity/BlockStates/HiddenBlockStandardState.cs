using Microsoft.Xna.Framework;

namespace Sprint_4
{
    public class HiddenBlockStandardState : BlockState
    {
        public HiddenBlockStandardState(BlockEntity blockEntity)
            : base(blockEntity)
        {
        }

        public override void Enter(IBlockState previousState)
        {           
            CurrentState = this;
            this.previousState = previousState;

            BlockEntity.blockState_Enum = BlockState_enum.HiddenBlock;
         //   BlockEntity.Velocity = new Vector2(0, 0);
        }

        public override void StandardTransition()
        {
            CurrentState.Exit();
            //CurrentState = this.previousState;
            // CurrentState = new UsedBlockStandardState(BlockEntity);
            CurrentState = new BrickBlockStandardState(BlockEntity);
            CurrentState.Enter(this);
        }
    }
}
