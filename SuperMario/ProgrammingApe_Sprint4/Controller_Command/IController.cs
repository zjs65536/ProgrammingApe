namespace Controller_Command
{
    public interface IController
    {
        void AddCommand(int key, ICommand value);
        void UpdateInput();
    }
}
