using Microsoft.Xna.Framework;
using System;

namespace Sprint_4
{
    public class QuestionBlockBumpState : BlockState
    {
        Vector2 Anchor;

        public QuestionBlockBumpState(BlockEntity blockEntity)
            : base(blockEntity)
        {
        }

        public override void Enter(IBlockState previousState)
        {           
            CurrentState = this;
            this.previousState = previousState;
            Anchor = BlockEntity._position;

            BlockEntity.blockState_Enum = BlockState_enum.UsedBlock;
            BlockEntity._position = Anchor;

        
            BlockEntity.Velocity = new Vector2(0, -3);
        }

        public override void Exit()
        {
            BlockEntity._position = Anchor;
            BlockEntity.Velocity = new Vector2(0, 0);
        }
    

        public override void StandardTransition()
        {
            CurrentState.Exit();
            CurrentState = new UsedBlockStandardState(BlockEntity);
            CurrentState.Enter(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (Math.Abs(BlockEntity._position.Y - Anchor.Y) > 10)
                BlockEntity.Velocity = new Vector2(0, BlockEntity.Velocity.Y * -1);
            else
            if (Math.Abs(BlockEntity._position.Y - Anchor.Y) == 0)
                StandardTransition();
        }
    }
}
