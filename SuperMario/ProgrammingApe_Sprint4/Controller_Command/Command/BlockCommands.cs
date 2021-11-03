namespace Controller_Command
{

    class BrickCommand : BlockStateCommand
    {
        public BrickCommand(BlockActionState receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.BrickCommand();
        }
    }

    class HiddenCommand : BlockStateCommand
    {
        public HiddenCommand(BlockActionState receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.HiddenCommand();
        }
    }

    class QuestionCommand : BlockStateCommand
    {
        public QuestionCommand(BlockActionState receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.QuestionCommand();
        }
    }

}
