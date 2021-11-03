using Microsoft.Xna.Framework;

namespace Sprint_4
{
    public class MarioJumpingState : MarioState
    {
        public MarioJumpingState(MarioEntity marioEntity)
            : base(marioEntity)
        {
        }

        public override void Enter(IMarioActionState previousState)
        {           
            CurrentState = this;
            this.previousState = previousState;
            MarioEntity.gravityExit = false;

            MarioEntity.MarioActionState_Enum = MarioActionState_enum.Jumping;
            MarioEntity.VelocityY = -300f;
        }

        public override void FallingTransition()
        {
            CurrentState.Exit();
            CurrentState = new MarioFallingState(MarioEntity);
            CurrentState.Enter(previousState);
        }

        public override void LandingTransition()
        {
            CurrentState = previousState;
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
