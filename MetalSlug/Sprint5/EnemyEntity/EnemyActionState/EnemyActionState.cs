namespace Sprint5
{
    public abstract class EnemyActionState :IEnemyActionState
    {
        protected IEnemyActionState previousState;
        public EnemyEntity EnemyEntity { get; protected set; }

        protected IEnemyActionState CurrentState
        {
            get { return EnemyEntity.EnemyActionState; }
            set { EnemyEntity.EnemyActionState = value; }
        }

        IEnemyActionState IEnemyActionState.PreviousState
        {
            get { return previousState; }
        }

        protected EnemyActionState(EnemyEntity enemyEntity)
        {
            EnemyEntity = enemyEntity;
        }

        public virtual void Enter(IEnemyActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }

        public virtual void DieTransition() { }
        public virtual void IdleTransition() { }
        public virtual void RunningTransition() { }
        public virtual void FireTransition() { }
        public virtual void FaceLeftTransition() { }
        public virtual void FaceRightTransition() { }

    }
}
