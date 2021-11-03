using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_4;



// This file is for Change the action state via the keyboard. The Receiver. 


namespace Controller_Command
{
    public class BlockActionState
    {
        BlockEntity block { get; set; }
        Game1 Game { get; set; }
        public BlockActionState(Game1 game, BlockEntity Block)
        {
            Game = game;
            block = Block;
        }


        public void brickCommandUpdate(KeyboardController keyboard, GamepadController gamepad)
        {
            // Add command for keyboard in Actionstates.


            keyboard.AddCommand((int)Keys.B, new BrickCommand(this));
        }
        public void hiddenCommandUpdate(KeyboardController keyboard, GamepadController gamepad)
        {

            keyboard.AddCommand((int)Keys.H, new HiddenCommand(this));
           
        }
         public void questionCommandUpdate(KeyboardController keyboard, GamepadController gamepad)
         {
            keyboard.AddCommand((int)Keys.OemQuestion, new QuestionCommand(this));
            

        }


        public void ExitCommand()
        {
            Game.Exit();
        }

        public void QuestionCommand()
        {
          
           
            if (Game.marioEntity.MarioStatus_Enum != MarioStatus_enum.Super && block.blockState_Enum == BlockState_enum.QuestionBlock)
            {
                block.BlockState.BumpTransition();
            }
            else
            {
                block.BlockState.FallingTransition();
            }
         

        }

        public void BrickCommand()
        {
            if (block.blockState_Enum == BlockState_enum.BrickBlock)
            {
                block.BlockState.BumpTransition();
            }
        }

        public void HiddenCommand()
        {
            if (block.blockState_Enum == BlockState_enum.HiddenBlock)
            {
                block.BlockState.StandardTransition();
            }

        }


    }
}
