using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5
{
    public class WarriorStandState : WarriorActionState
    {
        public WarriorStandState(WarriorEntity warriorEntity)
            :base(warriorEntity)
        {
        }

        public override void Enter(IWarriorActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            WarriorEntity.WarriorState = WarriorState.Stand;
            WarriorEntity.VelocityX = 0;
            WarriorEntity.VelocityY = 0;
            WarriorEntity.AccelarationY = 0;
            WarriorEntity.AccelarationX = 0;
            WarriorEntity.HaveGravity = false;
        }

        public override void CrunchingTransition()
        {
            CurrentState = new WarriorCrunchState(WarriorEntity);
            CurrentState.Enter(this);
        }

        public override void JumpingTransition()
        {
            CurrentState = new WarriorJumpState(WarriorEntity);
            CurrentState.Enter(this);
        }

        public override void RunningTransition()
        {
            CurrentState = new WarriorRunState(WarriorEntity);
            CurrentState.Enter(this);
        }

        public override void DieTransition()
        {
            CurrentState = new WarriorDeadState(WarriorEntity);
            CurrentState.Enter(this);
        }

        public override void FaceLeftTransition()
        {
            WarriorEntity.WarriorFacing = WarriorFacing.Left;
        }

        public override void FaceRightTransition()
        {
            WarriorEntity.WarriorFacing = WarriorFacing.Right;
        }
    }
}
