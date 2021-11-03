

namespace Sprint5
{
    public class WarriorCrunchState : WarriorActionState
    {
        public WarriorCrunchState(WarriorEntity warriorEntity)
            : base(warriorEntity)
        {
        }

        public override void Enter(IWarriorActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            WarriorEntity.WarriorState = WarriorState.Crounch;
            WarriorEntity.VelocityX = 0;
            WarriorEntity.VelocityY = 0;
            WarriorEntity.AccelarationY = 0;

        }

        public override void DieTransition()
        {
            CurrentState = new WarriorDeadState(WarriorEntity);
            CurrentState.Enter(this);
        }

        public override void StandingTransition()
        {
            CurrentState = previousState;
            CurrentState.Enter(this);
        }
    }
}
