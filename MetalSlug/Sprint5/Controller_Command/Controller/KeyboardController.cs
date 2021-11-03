using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint5
{
    public class KeyboardController : IController
    {

        #region Properties
        Game1 Game;
        WarriorEntity Marco;
        WarriorEntity Tarma;
        List<BulletEntity> Bullets;

        protected Dictionary<int, ICommand> pressingCommand;
        protected Dictionary<int, ICommand> onePressCommand;
        protected Dictionary<int, ICommand> releaseCommand;
        KeyboardState previousKeyboardState;
        Keys[] previousKeys;
        #endregion
        public KeyboardController(Game1 game, WarriorEntity marco, WarriorEntity tarma, List<BulletEntity> bullets)
        {
            Game = game;
            Marco = marco;
            Tarma = tarma;
            Bullets = bullets;
            previousKeyboardState = Keyboard.GetState();

            CommandInitial();
        }

        public void CommandInitial()
        {
            pressingCommand = new Dictionary<int, ICommand>();
            onePressCommand = new Dictionary<int, ICommand>();
            releaseCommand = new Dictionary<int, ICommand>();
            PressingCommandInitial();
            OnePressCommnadInitial();
            ReleaseCommnadInitial();         
        }

        public void PressingCommandInitial()
        {
            pressingCommand.Add((int)Keys.A, new ACommand(Marco));
            pressingCommand.Add((int)Keys.D, new DCommand(Marco));
            pressingCommand.Add((int)Keys.W, new WCommand(Marco));
            pressingCommand.Add((int)Keys.S, new SCommand(Marco));
            pressingCommand.Add((int)Keys.Up, new UpCommand(Tarma));
            pressingCommand.Add((int)Keys.Down, new DownCommand(Tarma));
            pressingCommand.Add((int)Keys.Left, new LeftCommand(Tarma));
            pressingCommand.Add((int)Keys.Right, new RightCommand(Tarma));
        }

        public void OnePressCommnadInitial()
        {
            onePressCommand.Add((int)Keys.Space, new SpaceCommand(Game, Marco, Bullets));
            onePressCommand.Add((int)Keys.RightControl, new RightControlCommand(Game, Tarma, Bullets));
            onePressCommand.Add((int)Keys.Q, new QuitCommand(Game));
            onePressCommand.Add((int)Keys.R, new ResetCommand(Game));
        }

        public void ReleaseCommnadInitial()
        {
            releaseCommand.Add((int)Keys.A, new ReleaseACommand(Marco));
            releaseCommand.Add((int)Keys.D, new ReleaseDCommand(Marco));
            releaseCommand.Add((int)Keys.W, new ReleaseWCommand(Marco));
            releaseCommand.Add((int)Keys.S, new RealseSCommand(Marco));
            releaseCommand.Add((int)Keys.Left, new ReleaseLeftCommand(Tarma));
            releaseCommand.Add((int)Keys.Right, new ReleaseRightCommand(Tarma));
            releaseCommand.Add((int)Keys.Up, new ReleaseUpCommand(Tarma));
            releaseCommand.Add((int)Keys.Down, new ReleaseDownCommand(Tarma));

        }
        
        public void UpdateInpute()
        {
            KeyboardState currentState = Keyboard.GetState();
            Keys[] keys = currentState.GetPressedKeys();
            foreach(Keys key in keys)
            {
                if (pressingCommand.ContainsKey((int)key))
                {
                    pressingCommand[(int)key].Execute();
                }
                else if (!previousKeyboardState.IsKeyDown(key))
                {
                    if (onePressCommand.ContainsKey((int)key))
                    {
                        onePressCommand[(int)key].Execute();
                    }
                }
            }
            if(previousKeys != null)
            {
                foreach (Keys key in previousKeys)
                {
                    if (Keyboard.GetState().IsKeyUp(key))
                    {
                        if (releaseCommand.ContainsKey((int)key))
                            releaseCommand[(int)key].Execute();
                    }
                }
            }
            previousKeys = keys;
            previousKeyboardState = currentState;
        }
    }
}
