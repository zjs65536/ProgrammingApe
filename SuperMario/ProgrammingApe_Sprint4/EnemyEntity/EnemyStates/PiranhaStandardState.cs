using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    class PiranhaStandardState : EnemyState
    {
        public PiranhaStandardState(EnemyEntity enemyEntity)
            : base(enemyEntity)
        {
        }

        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            EnemyEntity.EnemyState_Enum = EnemyState_enum.Piranha;
            EnemyEntity.EnemyType = "piranhaStandard";
            // EnemyEntity.VelocityX = 15f;
            EnemyEntity.VelocityY = -1;
        }

        public override void PiranhaHideTransition()
        {
            CurrentState.Exit();
            CurrentState = new PiranhaHideState(EnemyEntity);
            CurrentState.Enter(this);
        }

        public override void Update(GameTime gameTime)
        {


            if (Math.Abs(EnemyEntity._position.Y - EnemyEntity.Anchor.Y) > 45 || Math.Abs(EnemyEntity._position.Y - EnemyEntity.Anchor.Y) <= 0)
                EnemyEntity.VelocityY = EnemyEntity.VelocityY * -1;

        }
    }
}
