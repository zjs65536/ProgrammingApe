

namespace Sprint5
{
    public class UpCommand : ICommand
    {
        private WarriorEntity Tarma;
        public UpCommand(WarriorEntity tarmaEntity)
        {
            Tarma = tarmaEntity;
        }

        public void Execute()
        {
            if(Tarma.WarriorState == WarriorState.Run || Tarma.WarriorState == WarriorState.Stand)
            {
                Tarma.WarriorActionState.JumpingTransition();
                Tarma.AccelarationY = -350f;
                Tarma.Game.SoundManager.PlayJump();
            }
            else if(Tarma.WarriorState == WarriorState.Crounch)
            {
                Tarma.WarriorActionState.StandingTransition();
            }
        }
    }
}