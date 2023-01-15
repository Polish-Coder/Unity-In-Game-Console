# Unity In-game Console

This is a simple in-game console for Unity games. It allows you to easily add commands and execute them at runtime.

## Getting started

1. Download the package and import it into your Unity project.
2. Add the `Console Canvas` prefab from `Prefabs` folder to your scene.
3. To create a new command, create a new C# script and inherit from the `Command` class. Example below.

## Examples

Check out the `Examples` folder for some sample commands. Here's an example command that prints specified text to the console:

```csharp
using InGameConsole;

public class LogCommand : Command
{
    public override string Name => "log";
    public override string Description => "Writes a specified text message in the console";
    
    public override void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Write("No arguments given.");

            return;
        }

        Console.Write(string.Join(" ", args));
    }
}
```