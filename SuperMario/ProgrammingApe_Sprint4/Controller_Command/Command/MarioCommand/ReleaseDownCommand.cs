using Sprint_4;

namespace Controller_Command
{
    public class ReleaseDownCommand : ICommand
    {
        private MarioEntity Mario;

        public ReleaseDownCommand(MarioEntity marioEntity)
        {
            Mario = marioEntity;
        }

        public void Execute()
        {
            Mario.MarioState.IdleTransition();
        }
    }
}
