
namespace Sprint5
{
    public abstract class WarriorActionState : IWarriorActionState
    {
        protected IWarriorActionState previousState;
        public WarriorEntity WarriorEntity { get; protected set; }

        protected IWarriorActionState CurrentState
        {
            get { return WarriorEntity.WarriorActionState; }
            set { WarriorEntity.WarriorActionState = value; }
        }

        IWarriorActionState IWarriorActionState.PreviousState
        {
            get { return previousState; }
        }

        protected WarriorActionState(WarriorEntity warriorEntity)
        {
            WarriorEntity = warriorEntity;
        }

        public virtual void Enter(IWarriorActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }

        public virtual void DieTransition() { }
        public virtual void StandingTransition() { }
        public virtual void RunningTransition() { }
        public virtual void CrunchingTransition() { }
        public virtual void JumpingTransition() { }
        public virtual void LandingTransition() { }
        public virtual void FaceLeftTransition() { }
        public virtual void FaceRightTransition() { }

    }
}
