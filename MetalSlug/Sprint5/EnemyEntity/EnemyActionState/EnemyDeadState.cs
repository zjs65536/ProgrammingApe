using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint5
{
    public class EnemyDeadState : EnemyActionState
    {
        public EnemyDeadState(EnemyEntity enemy) : base(enemy)
        {
        }

        public override void Enter(IEnemyActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;

            EnemyEntity.EnemyState = EnemyState.Die;
            EnemyEntity.Velocity = new Vector2(0, 0);
        }
    }
}
