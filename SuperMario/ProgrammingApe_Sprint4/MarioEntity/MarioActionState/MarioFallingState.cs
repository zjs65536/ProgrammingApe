namespace Sprint_4
{
    public class MarioFallingState : MarioState
    {
        public MarioFallingState(MarioEntity marioEntity)
            : base(marioEntity)
        {
        }

        public override void Enter(IMarioActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            MarioEntity.MarioActionState_Enum = MarioActionState_enum.Falling;
        }

        public override void IdleTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioIdleState(MarioEntity);
            CurrentState.Enter(this);
        }

        public override void DieTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioDeadState(MarioEntity);
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
        public override void FlagTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioFlagState(MarioEntity);
            CurrentState.Enter(this);
        }
    }
}
