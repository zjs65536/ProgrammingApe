
namespace Sprint5
{
    public class ReleaseUpCommand : ICommand
    {
        private WarriorEntity Tarma;
        public ReleaseUpCommand(WarriorEntity tarmaEntity)
        {
            Tarma = tarmaEntity;
        }

        public void Execute()
        {
            if(Tarma.WarriorState == WarriorState.Jump)
            {
                Tarma.AccelarationY = 0f;
            }
        }
    }
}