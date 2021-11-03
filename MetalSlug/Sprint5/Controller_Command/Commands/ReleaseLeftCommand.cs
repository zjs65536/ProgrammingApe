
namespace Sprint5
{
    public class ReleaseLeftCommand : ICommand
    {
        private WarriorEntity Tarma;
        public ReleaseLeftCommand(WarriorEntity tarmaEntity)
        {
            Tarma = tarmaEntity;
        }

        public void Execute()
        {
            if (Tarma.WarriorFacing == WarriorFacing.Left && Tarma.WarriorState == WarriorState.Run)
            {
                Tarma.WarriorActionState.StandingTransition();
            }
            else if (Tarma.WarriorState == WarriorState.Jump)
            {
                Tarma.AccelarationX = 0;
            }
        }
    }
}