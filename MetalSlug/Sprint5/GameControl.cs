using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{

    public class GameControll
    {
        public Game1 Game;
        private SpriteFont SpriteFont;
        private Camera Camera;
        private string Win;
        private string Lose;
        private string Quit;

        public GameControll(Game1 game)
        {
            Game = game;
            SpriteFont = Game.Content.Load<SpriteFont>("SpriteFont/Game");
            Win = "MISSION   COMPLETE";
            Lose = "MISSION   FAILED";
            Quit = "Press Q to quite the game";
        }

        public void Load(Camera camera)
        {
            Camera = camera;
        }

        public void Update()
        {
            if (Game.Marco.WarriorLife <= 0 && Game.Tarma.WarriorLife <= 0 && Game.Marco.HealthPoint == 0 && Game.Tarma.HealthPoint == 0)
            {
                Game.GameState = GameState.Lose;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game.GameState == GameState.Lose)
            {
                spriteBatch.DrawString(SpriteFont, Lose, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 150), Color.Black);
                spriteBatch.DrawString(SpriteFont, Quit, new Vector2(Camera.Position.X + 280, Camera.Position.Y + 250), Color.Black);
            }
            else if (Game.GameState == GameState.Win)
            {
                spriteBatch.DrawString(SpriteFont, Win, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 150), Color.Black);
                spriteBatch.DrawString(SpriteFont, Quit, new Vector2(Camera.Position.X + 280, Camera.Position.Y + 250), Color.Black);
            }
        }
    }
}