

namespace Sprint_4
{
    public class MarioIdleState : MarioState
    {
        // MarioEntity
        public MarioIdleState(MarioEntity marioEntity)
            : base(marioEntity)
        {
        }

        public override void Enter(IMarioActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            MarioEntity.gravityExit = true;

            MarioEntity.MarioActionState_Enum = MarioActionState_enum.Idle;
            MarioEntity.VelocityX = 0;
            MarioEntity.VelocityY = 0;
            MarioEntity.xAccelaration = 0f;
            MarioEntity.yAccelaration = 0f;
        }
        // All kind of Crounching, need to delete the wrong one. 
        public override void CrouchingTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioCrouchingState(MarioEntity);
            CurrentState.Enter(this);
        }
        public override void RunningTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioRunningState(MarioEntity);
            CurrentState.Enter(this);
        }
        public override void JumpingTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioJumpingState(MarioEntity);
            CurrentState.Enter(this);
        }
        public override void FaceLeftTransition()
        {
            CurrentState.Exit();
            MarioEntity.SpriteFacing = SpriteFacing_enum.Left;
            CurrentState.Enter(this);
        }
        public override void FaceRightTransition()
        {
            CurrentState.Exit();
            MarioEntity.SpriteFacing = SpriteFacing_enum.Right;
            CurrentState.Enter(this);
        }
        public override void FallingTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioFallingState(MarioEntity);
            CurrentState.Enter(this);
        }

        public override void DieTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioDeadState(MarioEntity);
            CurrentState.Enter(this);
        }
        public override void FlagTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioFlagState(MarioEntity);
            CurrentState.Enter(this);
        }

    }
}
