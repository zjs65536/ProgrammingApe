namespace Sprint_4
{
    public class MarioCrouchingState : MarioState
    {
        public MarioCrouchingState(MarioEntity marioEntity)
            : base(marioEntity)
        {
        }

        public override void Enter(IMarioActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            MarioEntity.MarioActionState_Enum = MarioActionState_enum.Crouching;
            MarioEntity.VelocityY = 0f;
            MarioEntity.gravity = 0f;
            MarioEntity.xAccelaration = 0f;
            MarioEntity.yAccelaration = 0f;
        }

        public override void IdleTransition()
        {
            CurrentState.Exit();
            CurrentState = previousState;
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
