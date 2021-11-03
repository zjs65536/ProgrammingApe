namespace Sprint5
{
    public class ResetCommand : ICommand
    {
        private Game1 Game;
        public ResetCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.Reset();
        }
    }
}
