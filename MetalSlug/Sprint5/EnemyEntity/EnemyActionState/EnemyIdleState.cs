using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5
{
    class EnemyIdleState : EnemyActionState
    {
        public EnemyIdleState(EnemyEntity enemy) : base(enemy)
        {
        }

        public override void Enter(IEnemyActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            EnemyEntity.EnemyState = EnemyState.Idle;
            EnemyEntity.Velocity = new Vector2(0, 0);
        }

        public override void DieTransition()
        {
            CurrentState = new EnemyDeadState(EnemyEntity);
            CurrentState.Enter(this);
        }

        public override void FireTransition()
        {
            CurrentState = new EnemyFireState(EnemyEntity);
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
