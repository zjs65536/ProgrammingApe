using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_4;

namespace Controller_Command
{
    public class GamepadController : IController
    {
        Game game;
        MarioEntity Mario; 
        protected Dictionary<int, ICommand> commands;
        public GamepadController(Game game, MarioEntity marioEntity)
            : base ()
        {
            this.game = game;
            Mario = marioEntity;
            commands = new Dictionary<int, ICommand>();
            InitialCommand();
        }
        public void InitialCommand()
        {
            commands.Add((int)Buttons.DPadLeft, new LeftCommand(Mario));
            commands.Add((int)Buttons.DPadRight, new RightCommand(Mario));
            commands.Add((int)Buttons.A, new UpCommand(Mario));
            commands.Add((int)Buttons.DPadDown, new DownCommand(Mario));

        }
        public void AddCommand(int key, ICommand value)
        {
            commands.Add(key, value);
        }

        public void UpdateInput()
        {

            GamePadState currentState = GamePad.GetState(PlayerIndex.One);

            if (currentState.IsConnected)
            {
             
                    var buttonList = (Buttons[])Enum.GetValues(typeof(Buttons));

                  foreach (var button in buttonList)
                    {
                        if (currentState.IsButtonDown(button))
                            if (commands.ContainsKey((int)button))
                                commands[(int)button].Execute();
                    }
                

            }
        }

    }
}
