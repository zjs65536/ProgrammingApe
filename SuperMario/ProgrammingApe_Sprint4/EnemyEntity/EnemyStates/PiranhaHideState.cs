using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class PiranhaHideState : EnemyState
    {
        public PiranhaHideState(EnemyEntity enemyEntity)
            : base(enemyEntity)
        {
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            EnemyEntity.EnemyState_Enum = EnemyState_enum.PiranhaHide;
            EnemyEntity.EnemyType = "piranha";
            // EnemyEntity.VelocityY = 1;
        }

        public override void PiranhaStandardTransition()
        {
            CurrentState.Exit();
            CurrentState = new PiranhaStandardState(EnemyEntity);
            CurrentState.Enter(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (EnemyEntity.VelocityY == -1)
            {
                EnemyEntity.VelocityY = EnemyEntity.VelocityY * -1;

            }
            //    if (Math.Abs(EnemyEntity._position.Y - EnemyEntity.Anchor.Y) <= 0)
            // EnemyEntity.VelocityY = EnemyEntity.VelocityY * -1;
            //       EnemyEntity.VelocityY = 1;
            //  else
            if (Math.Abs(EnemyEntity._position.Y - EnemyEntity.Anchor.Y) > 45 && EnemyEntity.VelocityY == 1)
                EnemyEntity.VelocityY = 0;
        }
    }
}
