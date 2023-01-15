using InGameConsole;

public class HelpCommand : Command
{
    public override string Name => "help";
    public override string Description => "Displays all available commands";
    
    public override void Execute(string[] args)
    {
        foreach (Command command in Console.Commands)
        {
            Console.Write(TextStyle.Info(command.Name) + " - " + TextStyle.Default(command.Description));
        }
    }
}