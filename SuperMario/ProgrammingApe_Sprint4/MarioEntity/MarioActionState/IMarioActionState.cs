

namespace Sprint_4
{
    public interface IMarioActionState
    {
        IMarioActionState PreviouseState { get; }

        void Enter(IMarioActionState previousState);
        void Exit();

        void DieTransition();
        void LandingTransition();
        void IdleTransition();
        void CrouchingTransition();
        void StandingTransition();
        void RunningTransition();
        void JumpingTransition();
        void FallingTransition();
        void FaceLeftTransition();
        void FaceRightTransition();
        void FlagTransition();
    }
}
