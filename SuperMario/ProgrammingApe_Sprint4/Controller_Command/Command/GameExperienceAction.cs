using Microsoft.Xna.Framework.Input;
using Sprint_4;
using Microsoft.Xna.Framework;

namespace Controller_Command
{
    public class GameState
    {
        public Game1 Game { get; set; }
        public ActionState_Enum state;

        public GameState(Game1 game)
        {
            Game = game;
        }
        public void CommandUpdate(KeyboardController keyboard, GamepadController gamepad)
        {
            // Keyboard
            keyboard.AddStrongCommand((int)Keys.Q, new ExitCommand(this));
            keyboard.AddCommand((int)Keys.C, new ShowBoxCommand(this));

            // Future Commmand
            keyboard.AddStrongCommand((int)Keys.P, new PauseCommand(this));
            keyboard.AddCommand((int)Keys.M, new MuteCommand(this));
            keyboard.AddStrongCommand((int)Keys.R, new ResetCommand(this));


            // Add command for gamepad in ActionState.
            gamepad.AddCommand((int)Buttons.Start, new ExitCommand(this));
        }

        public void ExitCommand()
        {
            Game.Exit();
        }

        public void PauseCommand()
        {
            if (Game.gameState_Enum == GameState_Enum.Playing)
            {
                Game.gameState_Enum = GameState_Enum.Stop;
                Game.soundManager.MuteControl(true);
            }
            else if (Game.gameState_Enum == GameState_Enum.Stop)
            {
                Game.gameState_Enum = GameState_Enum.Playing;
                Game.soundManager.MuteControl(false);
            }
        }

        public void MuteCommand()
        {
            if (Game.soundManager.muted)
            {
                Game.soundManager.MuteControl(false);
            }
            else
            {
                Game.soundManager.MuteControl(true);
            }
        }

        public void ShowBoxCommand()
        {
            Game.showBox = !Game.showBox;
        }

        public void ResetCommand()
        {
            Game.marioEntity.marioLife = 3;
            Game.marioEntity.startPoint = new Vector2(160, 384);
            Game.gameState_Enum = GameState_Enum.Playing;
            Game.Reset();
        }
    }

   
}
