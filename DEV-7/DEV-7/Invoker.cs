namespace DEV_7
{
    /// <summary>
    /// Command pattern Invoker, initiate commands
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
