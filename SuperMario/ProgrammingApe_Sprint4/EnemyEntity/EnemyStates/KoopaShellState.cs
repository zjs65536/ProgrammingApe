using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class KoopaShellState : EnemyState
    {
        public KoopaShellState(EnemyEntity enemyEntity)
            : base(enemyEntity)
        {
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            EnemyEntity.EnemyState_Enum = EnemyState_enum.KoopaShell;
            EnemyEntity.EnemyType = "koopaShell";
            EnemyEntity.VelocityX = 0f;
        }

        public override void KoopaStandardTransition()
        {
            CurrentState.Exit();
            CurrentState = new KoopaStandardState(EnemyEntity);
            CurrentState.Enter(this);
        }
    }
}
