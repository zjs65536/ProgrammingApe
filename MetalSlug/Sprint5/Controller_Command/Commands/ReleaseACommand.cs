
namespace Sprint5
{
    public class ReleaseACommand : ICommand
    {
        private WarriorEntity Marco;

        public ReleaseACommand(WarriorEntity warriorEntity)
        {
            Marco = warriorEntity;
        }

        public void Execute()
        {
            if (Marco.WarriorState == WarriorState.Run && Marco.WarriorFacing == WarriorFacing.Left)
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
