

namespace Sprint_4
{
    public class MarioRunningState : MarioState
    {
        public MarioRunningState(MarioEntity marioEntity)
            : base(marioEntity)
        {
        }

        public override void Enter(IMarioActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            MarioEntity.gravityExit = true;

            MarioEntity.MarioActionState_Enum = MarioActionState_enum.Running;
            if(MarioEntity.SpriteFacing == SpriteFacing_enum.Left)
            {
                MarioEntity.VelocityX = -30f;
                MarioEntity.xAccelaration = -150f;
            }
            else
            {
                MarioEntity.VelocityX = 30f;
                MarioEntity.xAccelaration = 150f;
            }
            
        }
        // All kind of Crounching, need to delete the wrong one. 
        public override void CrouchingTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioCrouchingState(MarioEntity);
            CurrentState.Enter(this);
        }

        public override void IdleTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioIdleState(MarioEntity);
            CurrentState.Enter(this);
        }
        public override void JumpingTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioJumpingState(MarioEntity);
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
