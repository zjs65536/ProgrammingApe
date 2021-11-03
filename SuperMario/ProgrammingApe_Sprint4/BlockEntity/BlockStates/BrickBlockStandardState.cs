using Microsoft.Xna.Framework;

namespace Sprint_4
{
    public class BrickBlockStandardState : BlockState
    {
        public BrickBlockStandardState(BlockEntity blockEntity)
            : base(blockEntity)
        {
        }

        public override void Enter(IBlockState previousState)
        {           
            CurrentState = this;
            this.previousState = previousState;

            BlockEntity.blockState_Enum = BlockState_enum.BrickBlock;
     //       BlockEntity.Velocity = new Vector2(0, 0);
        }

        public override void BumpTransition()
        {
            CurrentState.Exit();
            //CurrentState = this.previousState;
            // CurrentState = new UsedBlockStandardState(BlockEntity);
            CurrentState = new BrickBlockBumpState(BlockEntity);
            CurrentState.Enter(this);
        }

        public override void UsedTransition()
        {
            CurrentState.Exit();
            //CurrentState = this.previousState;
            CurrentState = new UsedBlockStandardState(BlockEntity);
          //  CurrentState = new BrickBlockBumpState(BlockEntity);
            CurrentState.Enter(this);
        }

        public override void FallingTransition()
        {
            CurrentState.Exit();
            //CurrentState = this.previousState;
            // CurrentState = new UsedBlockStandardState(BlockEntity);
            CurrentState = new BrickBlockFallingState(BlockEntity);
            CurrentState.Enter(this);
        }
    }
}
