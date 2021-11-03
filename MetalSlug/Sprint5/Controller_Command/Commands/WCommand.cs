

namespace Sprint5
{
    public class WCommand : ICommand
    {
        private WarriorEntity Marco;
        public WCommand(WarriorEntity warriorEntity)
        {
            Marco = warriorEntity;
        }

        public void Execute()
        {
            if(Marco.WarriorState == WarriorState.Run || Marco.WarriorState == WarriorState.Stand)
            {
                Marco.WarriorActionState.JumpingTransition();
                Marco.AccelarationY = -350f;
                Marco.Game.SoundManager.PlayJump();
            }
            else if(Marco.WarriorState == WarriorState.Crounch)
            {
                Marco.WarriorActionState.StandingTransition();
            }
        }
    }
}
