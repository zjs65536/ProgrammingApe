using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    class GoomabaStandardState : EnemyState
    {
        public GoomabaStandardState(EnemyEntity enemyEntity)
            :base(enemyEntity)
        {
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            EnemyEntity.EnemyState_Enum = EnemyState_enum.GoombaAlive;
        }

        public override void DieTransition()
        {
            CurrentState.Exit();
            CurrentState = new GoombaDeadState(EnemyEntity);
            CurrentState.Enter(this);
        }
    }
}
