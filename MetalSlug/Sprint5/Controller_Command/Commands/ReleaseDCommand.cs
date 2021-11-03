
namespace Sprint5
{
    public class ReleaseDCommand : ICommand
    {
        private WarriorEntity Marco;

        public ReleaseDCommand(WarriorEntity warriorEntity)
        {
            Marco = warriorEntity;
        }

        public void Execute()
        {
            if(Marco.WarriorState == WarriorState.Run && Marco.WarriorFacing == WarriorFacing.Right)
            {
                Marco.WarriorActionState.StandingTransition();
            }
            else if (Marco.WarriorState == WarriorState.Jump)
            {
                Marco.AccelarationX = 0f;
            }
        }
    }
}
