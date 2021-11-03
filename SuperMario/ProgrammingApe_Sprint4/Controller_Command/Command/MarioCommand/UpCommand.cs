using Sprint_4;

namespace Controller_Command
{
    public class UpCommand : ICommand
    {
        private MarioEntity Mario;

        public UpCommand(MarioEntity marioEntity)
        {
            Mario = marioEntity;
        }

        public void Execute()
        {
            if (Mario.MarioActionState_Enum == MarioActionState_enum.Idle || Mario.MarioActionState_Enum == MarioActionState_enum.Running)
            {
                Mario.MarioState.JumpingTransition();
                Mario.yAccelaration = -500f;
                if (Mario.MarioStatus_Enum == MarioStatus_enum.Standard)
                {
                    Mario.SoundManager.PlayStandardJump();
                }
                else
                {
                    Mario.SoundManager.PlaySuperJump();
                }
            }
            else if (Mario.MarioActionState_Enum == MarioActionState_enum.Crouching)
            {
                Mario.MarioState.IdleTransition();
            }
        }
    }
}
