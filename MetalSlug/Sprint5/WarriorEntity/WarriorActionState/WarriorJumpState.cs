using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5
{
    public class WarriorJumpState : WarriorActionState
    {
        public WarriorJumpState(WarriorEntity warriorEntity)
            : base(warriorEntity)
        {
        }

        public override void Enter(IWarriorActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            WarriorEntity.WarriorState = WarriorState.Jump;
            WarriorEntity.VelocityY = -300f;
            WarriorEntity.HaveGravity = true;

        }

        public override void StandingTransition()
        {
            CurrentState = new WarriorStandState(WarriorEntity);
            CurrentState.Enter(this);
        }

        public override void LandingTransition()
        {
            CurrentState = previousState;
            CurrentState.Enter(this);
        }

        public override void DieTransition()
        {
            CurrentState = new WarriorDeadState(WarriorEntity);
            CurrentState.Enter(this);
        }
    }
}
