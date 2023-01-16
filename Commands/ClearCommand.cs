using InGameConsole;

public class ClearCommand : Command
{
    public override string Name => "clear";
    public override string Description => "Clears console output";
    
    public override void Execute(string[] args)
    {
        Console.Clear();
    }
}