

namespace Sprint5
{
    public class ReleaseDownCommand : ICommand
    {
        private WarriorEntity Tarma;
        public ReleaseDownCommand(WarriorEntity tarmaEntity)
        {
            Tarma = tarmaEntity;
        }

        public void Execute()
        {
            if(Tarma.WarriorState == WarriorState.Crounch)
            {
                Tarma.WarriorActionState.StandingTransition();
            }
        }
    }
}