

namespace Sprint5
{
    public interface IWarriorActionState
    {
        IWarriorActionState PreviousState { get; }

        void Enter(IWarriorActionState previousState);

        void DieTransition();
        void StandingTransition();
        void RunningTransition();
        void CrunchingTransition();
        void JumpingTransition();
        void LandingTransition();
        void FaceLeftTransition();
        void FaceRightTransition();
        
    }
}
