

namespace Sprint5
{
    public class WarriorDeadState : WarriorActionState
    {
        public WarriorDeadState(WarriorEntity warriorEntity)
            : base(warriorEntity)
        {
        }

        public override void Enter(IWarriorActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            WarriorEntity.WarriorState = WarriorState.Dead;
            WarriorEntity.VelocityX = 0;
            WarriorEntity.VelocityY = 0;
            WarriorEntity.AccelarationY = 0;
            WarriorEntity.AccelarationX = 0;
            WarriorEntity.Game.SoundManager.PlayGeneralDie();
        }

        public override void StandingTransition()
        {
            CurrentState = previousState;
            CurrentState.Enter(this);
        }
    }
}
