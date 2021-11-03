

namespace Sprint5
{
    public class ACommand : ICommand
    {
        private WarriorEntity Marco;
        public ACommand(WarriorEntity warriorEntity)
        {
            Marco = warriorEntity;
        }

        public void Execute()
        {
            if (Marco.WarriorState == WarriorState.Stand)
            {
                if (Marco.WarriorFacing == WarriorFacing.Right)
                {
                    Marco.WarriorActionState.FaceLeftTransition();
                }
                else
                {
                    Marco.WarriorActionState.RunningTransition();
                }
            }
            else if (Marco.WarriorState == WarriorState.Run)
            {
                if (Marco.WarriorFacing == WarriorFacing.Right)
                {
                    Marco.WarriorActionState.StandingTransition();
                }
            }
            else if (Marco.WarriorState == WarriorState.Jump)
            {
                Marco.AccelarationX = -200f;
            }
        }
    }
}
