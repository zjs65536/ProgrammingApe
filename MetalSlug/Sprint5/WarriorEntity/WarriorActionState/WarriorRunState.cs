using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5
{
    public class WarriorRunState : WarriorActionState
    {
        public WarriorRunState(WarriorEntity warriorEntity)
            : base(warriorEntity)
        {
        }

        public override void Enter(IWarriorActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            WarriorEntity.WarriorState = WarriorState.Run;
            WarriorEntity.HaveGravity = false;

            if(WarriorEntity.WarriorFacing == WarriorFacing.Left)
            {
                WarriorEntity.VelocityX = -120f;
            }
            else
            {
                WarriorEntity.VelocityX = 120f;
            }
        }

        public override void DieTransition()
        {
            CurrentState = new WarriorDeadState(WarriorEntity);
            CurrentState.Enter(this);
        }

        public override void StandingTransition()
        {
            CurrentState = new WarriorStandState(WarriorEntity);
            CurrentState.Enter(this);
        }

        public override void JumpingTransition()
        {
            CurrentState = new WarriorJumpState(WarriorEntity);
            CurrentState.Enter(this);
        }

        public override void CrunchingTransition()
        {
            CurrentState = new WarriorCrunchState(WarriorEntity);
            CurrentState.Enter(this);
        }
    }
}
