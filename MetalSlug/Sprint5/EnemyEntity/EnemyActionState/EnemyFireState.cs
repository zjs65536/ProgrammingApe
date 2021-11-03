using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    class EnemyFireState : EnemyActionState
    {
        public EnemyFireState(EnemyEntity enemy) : base(enemy)
        {
        }

        public override void Enter(IEnemyActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            EnemyEntity.EnemyState = EnemyState.Fire;
            EnemyEntity.Velocity = new Vector2(0, 0);
        }

        public override void DieTransition()
        {
            CurrentState = new EnemyDeadState(EnemyEntity);
            CurrentState.Enter(this);
        }

        public override void IdleTransition()
        {
            CurrentState = new EnemyIdleState(EnemyEntity);
            CurrentState.Enter(this);
        }

        public override void RunningTransition()
        {
            CurrentState = new EnemyRunState(EnemyEntity);
            CurrentState.Enter(this);
        }

        public override void FaceLeftTransition()
        {
            EnemyEntity.EnemyFacing = EnemyFacing.Left;
        }

        public override void FaceRightTransition()
        {
            EnemyEntity.EnemyFacing = EnemyFacing.Right;
        }
    }
}
