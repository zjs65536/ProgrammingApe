using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5
{
    class EnemyRunState : EnemyActionState
    {
        public EnemyRunState(EnemyEntity enemy) : base(enemy)
        {
        }

        public override void Enter(IEnemyActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            EnemyEntity.EnemyState = EnemyState.Run;
            if(EnemyEntity.EnemyFacing == EnemyFacing.Left)
                EnemyEntity.Velocity = new Vector2(-50f, 0);
            else
                EnemyEntity.Velocity = new Vector2(50f, 0);
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
