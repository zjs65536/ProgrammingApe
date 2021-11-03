namespace Sprint5
{
    public class QuitCommand : ICommand
    {
        private Game1 Game;
        public QuitCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.Exit();
        }
    }
}
