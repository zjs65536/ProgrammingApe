using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller_Command
{
    class ExitCommand : GameExperienceCommand
    {
        public ExitCommand(GameState receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.ExitCommand();
        }
    }

    class PauseCommand : GameExperienceCommand
    {
        public PauseCommand(GameState receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.PauseCommand();
        }
    }

    class MuteCommand : GameExperienceCommand
    {
        public MuteCommand(GameState receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.MuteCommand();
        }
    }

    class ShowBoxCommand : GameExperienceCommand
    {
        public ShowBoxCommand(GameState receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.ShowBoxCommand();
        }
    }

    class ResetCommand : GameExperienceCommand
    {
        public ResetCommand(GameState receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.ResetCommand();
        }
    }
}
