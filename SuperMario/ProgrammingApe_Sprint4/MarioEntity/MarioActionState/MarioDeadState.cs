namespace Sprint_4
{
    public class MarioDeadState : MarioState
    {
        public MarioDeadState(MarioEntity marioEntity)
            : base(marioEntity)
        {
        }

        public override void Enter(IMarioActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            MarioEntity.MarioActionState_Enum = MarioActionState_enum.Dead;
            MarioEntity.MarioStatus_Enum = MarioStatus_enum.Dead;
            MarioEntity.VelocityX = 0f;
            MarioEntity.VelocityY = -100f;
            MarioEntity.gravity = 150f;
            MarioEntity.xAccelaration = 0f;
            MarioEntity.yAccelaration = 0f;
        }

        public override void IdleTransition()
        {
            CurrentState.Exit();
            CurrentState = previousState;
            CurrentState.Enter(this);
        }
    }
}
