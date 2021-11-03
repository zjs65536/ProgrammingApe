

namespace Sprint5
{
    public class ReleaseRightCommand : ICommand
    {
        private WarriorEntity Tarma;
        public ReleaseRightCommand(WarriorEntity tarmaEntity)
        {
            Tarma = tarmaEntity;
        }

        public void Execute()
        {
            if(Tarma.WarriorFacing == WarriorFacing.Right && Tarma.WarriorState == WarriorState.Run)
            {
                Tarma.WarriorActionState.StandingTransition();
            }
            else if(Tarma.WarriorState == WarriorState.Jump)
            {
                Tarma.AccelarationX = 0f;
            }
        }
    }
}