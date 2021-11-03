using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint_4;



// This file is for Change the action state via the keyboard. The Receiver. 


namespace Controller_Command
{
    public class MarioCommands
    {
        List<FireballEntity> Fireballs;
        MarioEntity Mario { get; set; }
        Game1 Game { get; set; }
        public MarioCommands(Game1 game, MarioEntity Mario, List<FireballEntity> fireballs)
        {
            Game = game;
            this.Mario = Mario;
            Fireballs = fireballs;
        }


        public void CommandUpdate(KeyboardController keyboard, GamepadController gamepad)
        {
            // Add command for keyboard in Actionstates.


            // Add command for gamepad in ActionState.


            gamepad.AddCommand((int)Buttons.B, new DashCommand(this));

            // Add command for keyboard for changing the Avator state.
            keyboard.AddCommand((int)Keys.Y, new StandardCommand(this));

            keyboard.AddCommand((int)Keys.U, new SuperCommand(this));

            keyboard.AddCommand((int)Keys.I, new FireCommand(this));

            keyboard.AddCommand((int)Keys.O, new DamageCommand(this));

            keyboard.AddCommand((int)Keys.Space, new ProjectCommand(this));

        }


        public void ProjectCommand()
        {
            if(Fireballs.Count < 2 && Mario.MarioStatus_Enum == MarioStatus_enum.Fire)
            {
                FireballEntity fireball = new FireballEntity(Mario.SpriteFactory, Mario._position, Mario.SpriteFacing);
                Fireballs.Add(fireball);
            }
        }

        public void ExitCommand()
        {
            Game.Exit();
        }
        public void DashCommand()
        {
            // Future Command.
        }

        public void StandardCommand()
        {
            Mario.MarioStatus_Enum = MarioStatus_enum.Standard;
        }

        public void SuperCommand()
        {
            Mario.MarioStatus_Enum = MarioStatus_enum.Super;
        }

        public void FireCommand()
        {
            Mario.MarioStatus_Enum = MarioStatus_enum.Fire;
        }

        public void DamageCommand()
        {
            if (Mario.MarioStatus_Enum == MarioStatus_enum.Standard)
            {
                Mario.SoundManager.PlayMarioDie();
                Mario.MarioState.DieTransition();
                Mario.levelReset = true;
            }
            else if (Mario.MarioStatus_Enum == MarioStatus_enum.Fire || Mario.MarioStatus_Enum == MarioStatus_enum.Super)
                Mario.MarioStatus_Enum = MarioStatus_enum.Standard;
        }

        public void FireballCommand()
        {
            
        }
    }
}
