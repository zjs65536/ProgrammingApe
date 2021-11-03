

namespace Controller_Command
{
    
    // Future Command
    class DashCommand : ActionStateCommand
    {
        public DashCommand(MarioCommands receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.DashCommand();
        }
    }

    class StandardCommand : ActionStateCommand
    {
        public StandardCommand(MarioCommands receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.StandardCommand();
        }
    }

    class SuperCommand : ActionStateCommand
    {
        public SuperCommand(MarioCommands receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.SuperCommand();
        }
    }

    class FireCommand : ActionStateCommand
    {
        public FireCommand(MarioCommands receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.FireCommand();
        }
    }

    class DamageCommand : ActionStateCommand
    {
        public DamageCommand(MarioCommands receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.DamageCommand();
        }
    }

    class ProjectCommand : ActionStateCommand
    {
        public ProjectCommand(MarioCommands receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.ProjectCommand();
        }
    }
}
