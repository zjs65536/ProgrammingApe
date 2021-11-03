using Sprint_4;

namespace Controller_Command
{
    public class ReleaseLeftCommand : ICommand
    {
        private MarioEntity Mario;

        public ReleaseLeftCommand(MarioEntity marioEntity)
        {
            Mario = marioEntity;
        }

        public void Execute()
        {
            if(Mario.MarioActionState_Enum == MarioActionState_enum.Running)
            {
                Mario.MarioState.IdleTransition();
            }
            else if(Mario.MarioActionState_Enum == MarioActionState_enum.Jumping || Mario.MarioActionState_Enum == MarioActionState_enum.Falling)
            {
                Mario.xAccelaration = 0f;
            }
        }
    }
}
