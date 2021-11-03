using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class GoombaDeadState : EnemyState
    {
        public GoombaDeadState(EnemyEntity enemyEntity)
            : base(enemyEntity)
        {
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            EnemyEntity.EnemyState_Enum = EnemyState_enum.GoombaDead;
            EnemyEntity.EnemyType = "deadGoomba";
            EnemyEntity.VelocityX = 0f;
        }
    }
}
