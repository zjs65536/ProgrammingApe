using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint_4
{
    public abstract class EnemyState : IEnemyState
    {
        #region The variables
        protected IEnemyState previousState;

        // MarioEntity is the one we call in the MarioState.
        public EnemyEntity EnemyEntity { get; protected set; }

        protected IEnemyState CurrentState
        {
            get { return EnemyEntity.EnemyState; }
            set { EnemyEntity.EnemyState = value; }
        }

        IEnemyState IEnemyState.PreviouseState { get { return previousState; } }
        #endregion


        // Method
        protected EnemyState(EnemyEntity entity)
        {
            EnemyEntity = entity;
        }

        public virtual void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }

        public virtual void Exit() { }
        public virtual void DieTransition() { } 
        public virtual void ShellTransition() { }
        public virtual void KoopaStandardTransition() { }
        public virtual void PiranhaHideTransition() { }
        public virtual void PiranhaStandardTransition() { }

        public virtual void Update(GameTime gameTime) { }
    }
}
