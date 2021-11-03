using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    

    
    public abstract class MarioState : IMarioActionState
    {
        #region The variables
        protected IMarioActionState previousState;

        // MarioEntity is the one we call in the MarioState.
        public MarioEntity MarioEntity{ get; protected set;}

        protected IMarioActionState CurrentState 
        {
            get { return MarioEntity.MarioState; }
            set { MarioEntity.MarioState = value; }
        }

         IMarioActionState IMarioActionState.PreviouseState
        {
            get { return previousState; }
        }
        #endregion



        // Method
        protected MarioState(MarioEntity entity) 
        {
            MarioEntity = entity;
        }

        public virtual void Enter(IMarioActionState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
        }

        public virtual void Exit() { }

        public virtual void DieTransition() { }
        public virtual void LandingTransition() { }
        public virtual void IdleTransition() { }
        public virtual void CrouchingTransition() { }
        public virtual void StandingTransition() { }
        public virtual void RunningTransition() { }
        public virtual void JumpingTransition() { }
        public virtual void FallingTransition() { }
        public virtual void FaceLeftTransition() { }
        public virtual void FaceRightTransition() { }
        public virtual void FlagTransition() { }

    }
}
