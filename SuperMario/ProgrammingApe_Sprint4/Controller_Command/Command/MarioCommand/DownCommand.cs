using Sprint_4;

namespace Controller_Command
{
    public class DownCommand : ICommand
    {
        private MarioEntity Mario;

        public DownCommand(MarioEntity marioEntity)
        {
            Mario = marioEntity;
        }

        public void Execute()
        {
            if (Mario.MarioActionState_Enum == MarioActionState_enum.Idle || Mario.MarioActionState_Enum == MarioActionState_enum.Running)
            {
                Mario.MarioState.CrouchingTransition();
            }
        }
    }
}
