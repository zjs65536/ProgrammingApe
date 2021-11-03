namespace Sprint_4
{
    public class MarioFlagState : MarioState
    {
        public MarioFlagState(MarioEntity marioEntity)
            : base(marioEntity)
        {
        }

        public override void Enter(IMarioActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            MarioEntity.MarioActionState_Enum = MarioActionState_enum.Flag;
            MarioEntity.VelocityX = 0f;
            MarioEntity.VelocityY = 80f;
            MarioEntity.gravity = 0f;
            MarioEntity.xAccelaration = 0f;
            MarioEntity.yAccelaration = 0f;
        }
    }
}
