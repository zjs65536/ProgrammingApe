

namespace Sprint5
{
    public class RightCommand : ICommand
    {
        private WarriorEntity Tarma;
        public RightCommand(WarriorEntity tarmaEntity)
        {
            Tarma = tarmaEntity;
        }

        public void Execute()
        {
            if(Tarma.WarriorState == WarriorState.Stand)
            {
                if(Tarma.WarriorFacing == WarriorFacing.Right)
                {
                    Tarma.WarriorActionState.RunningTransition();
                }
                else
                {
                    Tarma.WarriorActionState.FaceRightTransition();
                }
            }
            else if(Tarma.WarriorState == WarriorState.Run)
            {
                if(Tarma.WarriorFacing == WarriorFacing.Left)
                {
                    Tarma.WarriorActionState.StandingTransition();
                }
            }
            else if (Tarma.WarriorState == WarriorState.Jump)
            {
                Tarma.AccelarationX = 200f;
            }
        }
    }
}