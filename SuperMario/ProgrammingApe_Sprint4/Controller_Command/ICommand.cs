
namespace Controller_Command
{
    public interface ICommand
    {
        void Execute();
    }

    public abstract class ActionStateCommand : ICommand
    {
        protected MarioCommands receiver;
        public ActionStateCommand(MarioCommands receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }

    public abstract class GameExperienceCommand : ICommand
    {
        protected GameState receiver;
        public GameExperienceCommand(GameState receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }

    public abstract class BlockStateCommand : ICommand
    {
        protected BlockActionState receiver;
        public BlockStateCommand(BlockActionState receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }

}
