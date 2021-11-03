using Sprint_4;

namespace Controller_Command
{
    public class LeftCommand : ICommand
    {
        private MarioEntity Mario;

        public LeftCommand(MarioEntity marioEntity)
        {
            Mario = marioEntity;
        }

        public void Execute()
        {
            if (Mario.MarioActionState_Enum == MarioActionState_enum.Idle)
            {
                if (Mario.SpriteFacing == SpriteFacing_enum.Right)
                {
                    Mario.MarioState.FaceLeftTransition();
                }
                else
                {
                    Mario.MarioState.RunningTransition();
                }
            }
            else if(Mario.MarioActionState_Enum == MarioActionState_enum.Jumping  || Mario.MarioActionState_Enum == MarioActionState_enum.Falling)
            {
                if (Mario.VelocityX > -100f)
                {
                    Mario.xAccelaration = -200f;
                }
                else
                {
                    Mario.xAccelaration = 0;
                }
            }
            else if(Mario.MarioActionState_Enum == MarioActionState_enum.Running)
            {
                if (Mario.SpriteFacing == SpriteFacing_enum.Right)
                {
                    Mario.MarioState.IdleTransition();
                }

            }
        }
    }
}
