

namespace Sprint5
{
    public class DownCommand : ICommand
    {
        private WarriorEntity Tarma;
        public DownCommand(WarriorEntity tarmaEntity)
        {
            Tarma = tarmaEntity;
        }

        public void Execute()
        {
            if(Tarma.WarriorState == WarriorState.Stand || Tarma.WarriorState == WarriorState.Run)
            {
                Tarma.WarriorActionState.CrunchingTransition();
            }
        }
    }
}