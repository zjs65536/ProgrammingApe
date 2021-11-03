using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class KoopaStandardState : EnemyState
    {
        public KoopaStandardState(EnemyEntity enemyEntity)
            : base(enemyEntity)
        {
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            EnemyEntity.EnemyState_Enum = EnemyState_enum.KoopaAlive;
            EnemyEntity.EnemyType = "koopaStandard";
            EnemyEntity.VelocityX = 1f;
        }

        public override void ShellTransition()
        {
            CurrentState.Exit();
            CurrentState = new KoopaShellState(EnemyEntity);
            CurrentState.Enter(this);
        }
    }
}
