using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Sprint_4;
namespace Controller_Command
{
    public class KeyboardController : IController
    {
        MarioEntity Mario;
        Game1 game;
        KeyboardState previousKeyboardState;
        protected Dictionary<int, ICommand> Commands;
        protected Dictionary<int, ICommand> MarioCommands;
        protected Dictionary<int, ICommand> ReleaseCommand;
        protected Dictionary<int, ICommand> StrongCommand;
        Keys[] previousKeys;
        public KeyboardController(Game1 game, MarioEntity marioEntity)
        {
            this.game = game;
            Mario = marioEntity;
            Commands = new Dictionary<int, ICommand>();
            MarioCommands = new Dictionary<int, ICommand>();
            ReleaseCommand = new Dictionary<int, ICommand>();
            StrongCommand = new Dictionary<int, ICommand>();
            previousKeyboardState = Keyboard.GetState();
            MarioCommandInitial();
        }

        public void MarioCommandInitial()
        {
            // Movement
            MarioCommands.Add((int)Keys.A, new LeftCommand(Mario));
            MarioCommands.Add((int)Keys.Left, new LeftCommand(Mario));
            MarioCommands.Add((int)Keys.D, new RightCommand(Mario));
            MarioCommands.Add((int)Keys.Right, new RightCommand(Mario));
            MarioCommands.Add((int)Keys.W, new UpCommand(Mario));
            MarioCommands.Add((int)Keys.Up, new UpCommand(Mario));
            MarioCommands.Add((int)Keys.S, new DownCommand(Mario));
            MarioCommands.Add((int)Keys.Down, new DownCommand(Mario));

            // Release
            ReleaseCommand.Add((int)Keys.A, new ReleaseLeftCommand(Mario));
            ReleaseCommand.Add((int)Keys.Left, new ReleaseLeftCommand(Mario));
            ReleaseCommand.Add((int)Keys.D, new ReleaseRightCommand(Mario));
            ReleaseCommand.Add((int)Keys.Right, new ReleaseRightCommand(Mario));
            ReleaseCommand.Add((int)Keys.S, new ReleaseDownCommand(Mario));
            ReleaseCommand.Add((int)Keys.Down, new ReleaseDownCommand(Mario));
            ReleaseCommand.Add((int)Keys.W, new ReleaseUpCommand(Mario));
            ReleaseCommand.Add((int)Keys.Up, new ReleaseUpCommand(Mario));

        }

        public void AddCommand(int key, ICommand value)
        {
            Commands.Add(key, value);
        }

        public void AddStrongCommand(int key, ICommand value)
        {
            StrongCommand.Add(key, value);
        }

        public void UpdateInput()
        {
            KeyboardState currentState = Keyboard.GetState();
            Keys[] keys = currentState.GetPressedKeys();
            foreach (Keys key in keys)
            {
                if (game.gameState_Enum == GameState_Enum.Playing)
                {
                    if (MarioCommands.ContainsKey((int)key))
                    {
                        MarioCommands[(int)key].Execute();
                    }
                    else if (!previousKeyboardState.IsKeyDown(key))
                    {
                        if (Commands.ContainsKey((int)key))
                        {
                            Commands[(int)key].Execute();
                        }
                    }

                }
                if (previousKeyboardState != currentState)
                {
                    if (StrongCommand.ContainsKey((int)key))
                    {
                        StrongCommand[(int)key].Execute();
                    }
                }
            }
            if(previousKeys != null && game.gameState_Enum == GameState_Enum.Playing)
            {
                foreach(Keys key in previousKeys) 
                {
                    if (Keyboard.GetState().IsKeyUp(key))
                    {
                        if (ReleaseCommand.ContainsKey((int)key))
                            ReleaseCommand[(int)key].Execute();
                    }
                }
            }
            previousKeys = keys;
            previousKeyboardState = currentState;


        }
    }
}
