using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_4
{
    public class GameControll
    {
        public Game1 Game;
        private SpriteFont SpriteFont;
        private SpriteFont SpriteFont2;
        private Camera Camera;
        private string restart;
        private string quit;
        private string resume;
        private string lose;
        private string win;
        public GameControll(Game1 game)
        {
            Game = game;          
            SpriteFont = Game.Content.Load<SpriteFont>("Fonts/GameControll1");
            SpriteFont2 = Game.Content.Load<SpriteFont>("Fonts/GameControll2");
            restart = "Press R to restart the game";
            quit = "Press Q to quite the game";
            resume = "Press P to resume the game.";
            lose = "GAME OVER";
            win = "Win!!!";
        }

        public void Load(Camera camera)
        {
            Camera = camera;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Game.gameState_Enum == GameState_Enum.Lose)
            {
                spriteBatch.DrawString(SpriteFont2, lose, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 100), Color.Black);
                spriteBatch.DrawString(SpriteFont, restart, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 200), Color.Black);
                spriteBatch.DrawString(SpriteFont, quit, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 300), Color.Black);
                
            }
            else if(Game.gameState_Enum == GameState_Enum.Stop)
            {
                spriteBatch.DrawString(SpriteFont, resume, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 100), Color.Black);
                spriteBatch.DrawString(SpriteFont, quit, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 200), Color.Black);
            }
            else if(Game.gameState_Enum == GameState_Enum.Win)
            {
                spriteBatch.DrawString(SpriteFont2, win, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 100), Color.Black);
                spriteBatch.DrawString(SpriteFont, restart, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 200), Color.Black);
                spriteBatch.DrawString(SpriteFont, quit, new Vector2(Camera.Position.X + 300, Camera.Position.Y + 300), Color.Black);
            }
        }
    }
}
