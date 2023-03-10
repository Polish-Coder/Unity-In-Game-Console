using InGameConsole;

public class LogCommand : Command
{
    public override string Name => "log";
    public override string Description => "Writes a specified text message in the console";
    
    public override void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Write(TextStyle.Error("No arguments given."));

            return;
        }

        Console.Write(TextStyle.Default(string.Join(" ", args)));
    }
}