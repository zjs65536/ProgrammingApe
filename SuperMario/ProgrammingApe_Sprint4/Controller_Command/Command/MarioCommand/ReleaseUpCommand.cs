using Sprint_4;

namespace Controller_Command
{
    public class ReleaseUpCommand : ICommand
    {
        private MarioEntity Mario;

        public ReleaseUpCommand(MarioEntity marioEntity)
        {
            Mario = marioEntity;
        }

        public void Execute()
        {
            Mario.yAccelaration = 0f;
        }
    }
}
