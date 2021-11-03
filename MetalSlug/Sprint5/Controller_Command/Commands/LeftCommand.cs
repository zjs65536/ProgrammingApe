

namespace Sprint5
{
    public class LeftCommand : ICommand
    {
        private WarriorEntity Tarma;
        public LeftCommand(WarriorEntity tarmaEntity)
        {
            Tarma = tarmaEntity;
        }

        public void Execute()
        {
            if (Tarma.WarriorState == WarriorState.Stand)
            {
                if (Tarma.WarriorFacing == WarriorFacing.Left)
                {
                    Tarma.WarriorActionState.RunningTransition();
                }
                else
                {
                    Tarma.WarriorActionState.FaceLeftTransition();
                }
            }
            else if (Tarma.WarriorState == WarriorState.Run)
            {
                if (Tarma.WarriorFacing == WarriorFacing.Right)
                {
                    Tarma.WarriorActionState.StandingTransition();
                }
            }
            else if (Tarma.WarriorState == WarriorState.Jump)
            {
                Tarma.AccelarationX = -200f;
            }
        }
    }
}