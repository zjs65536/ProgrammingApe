namespace Sprint5
{
    public interface IEnemyActionState
    {
        IEnemyActionState PreviousState { get; }

        void Enter(IEnemyActionState previousState);

        void DieTransition();
        void IdleTransition();
        void RunningTransition();
        void FireTransition();
        void FaceLeftTransition();
        void FaceRightTransition();

    }
}
