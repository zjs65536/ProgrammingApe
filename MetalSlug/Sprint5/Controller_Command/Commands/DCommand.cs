

namespace Sprint5
{
    public class DCommand : ICommand
    {
        private WarriorEntity Marco;
        public DCommand(WarriorEntity warriorEntity)
        {
            Marco = warriorEntity;
        }

        public void Execute()
        {
            if(Marco.WarriorState == WarriorState.Stand)
            {
                if(Marco.WarriorFacing == WarriorFacing.Left)
                {
                    Marco.WarriorActionState.FaceRightTransition();
                }
                else
                {
                    Marco.WarriorActionState.RunningTransition();
                }
            }
            else if(Marco.WarriorState == WarriorState.Run)
            {
                if(Marco.WarriorFacing == WarriorFacing.Left)
                {
                    Marco.WarriorActionState.StandingTransition();
                }
            }
            else if (Marco.WarriorState == WarriorState.Jump)
            {
                Marco.AccelarationX = 200f;
            }
        }
    }
}
