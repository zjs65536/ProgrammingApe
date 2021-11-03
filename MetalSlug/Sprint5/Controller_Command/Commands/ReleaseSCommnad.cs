

namespace Sprint5
{
    public class RealseSCommand : ICommand
    {
        private WarriorEntity Marco;

        public RealseSCommand(WarriorEntity warriorEntity)
        {
            Marco = warriorEntity;
        }

        public void Execute()
        {
            if(Marco.WarriorState == WarriorState.Crounch)
            {
                Marco.WarriorActionState.StandingTransition();
            }
        }
    }
}
