namespace DEV_6
{
    /// <summary>
    /// Invoker class
    /// </summary>
    class Invoker
    {
        ICommand Command;

        public Invoker() { }

        public void SetCommand(ICommand Command)
        {
            this.Command = Command;
        }

        public void ExecuteCommand()
        {
            Command.Execute();
        }
    }
}
