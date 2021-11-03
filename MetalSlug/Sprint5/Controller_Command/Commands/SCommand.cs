

namespace Sprint5
{
    public class SCommand : ICommand
    {
        private WarriorEntity Marco;
        public SCommand(WarriorEntity warriorEntity)
        {
            Marco = warriorEntity;
        }

        public void Execute()
        {
            if(Marco.WarriorState == WarriorState.Stand || Marco.WarriorState == WarriorState.Run)
            {
                Marco.WarriorActionState.CrunchingTransition();
            }
        }
    }
}
