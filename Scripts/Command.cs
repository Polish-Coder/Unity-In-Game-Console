namespace InGameConsole
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract void Execute(string[] args);
    }
}