
namespace Sprint5
{
    public class ReleaseWCommand : ICommand
    {
        private WarriorEntity Marco;

        public ReleaseWCommand(WarriorEntity warriorEntity)
        {
            Marco = warriorEntity;
        }

        public void Execute()
        {
            if(Marco.WarriorState == WarriorState.Jump)
            {
                Marco.AccelarationY = 0;
            }
        }
    }
}
