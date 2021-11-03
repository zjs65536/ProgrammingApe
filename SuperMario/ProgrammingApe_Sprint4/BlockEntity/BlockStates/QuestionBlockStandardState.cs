using Microsoft.Xna.Framework;

namespace Sprint_4
{
    public class QuestionBlockStandardState : BlockState
    {
        public QuestionBlockStandardState(BlockEntity blockEntity)
            : base(blockEntity)
        {
        }

        public override void Enter(IBlockState previousState)
        {           
            CurrentState = this;
            this.previousState = previousState;

            BlockEntity.blockState_Enum = BlockState_enum.QuestionBlock;
         //   BlockEntity.Velocity = new Vector2(0, -1);
        }

        public override void BumpTransition()
        {
            CurrentState.Exit();
            //CurrentState = this.previousState;
            // CurrentState = new UsedBlockStandardState(BlockEntity);
            CurrentState = new QuestionBlockBumpState(BlockEntity);
            CurrentState.Enter(this);
        }
        public override void FallingTransition()
        {
            CurrentState.Exit();
            //CurrentState = this.previousState;
            // CurrentState = new UsedBlockStandardState(BlockEntity);
            CurrentState = new QuestionBlockBumpState(BlockEntity);
            CurrentState.Enter(this);
        }
    }
}
