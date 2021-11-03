using Sprint_4;

namespace Controller_Command
{
    public class ReleaseRightCommand : ICommand
    {
        private MarioEntity Mario;

        public ReleaseRightCommand(MarioEntity marioEntity)
        {
            Mario = marioEntity;
        }

        public void Execute()
        {
            if (Mario.MarioActionState_Enum == MarioActionState_enum.Running)
            {
                Mario.MarioState.IdleTransition();
            }
            else if (Mario.MarioActionState_Enum == MarioActionState_enum.Jumping || Mario.MarioActionState_Enum == MarioActionState_enum.Falling)
            {
                Mario.xAccelaration = 0;
            }
        }
    }
}