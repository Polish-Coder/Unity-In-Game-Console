# Unity In-game Console

This is a simple in-game console for Unity games. It allows you to easily add commands and execute them at runtime.

## Getting started

1. Download the package and put it into `Assets/Plugins` folder in your project.
2. Add the `Console Canvas` prefab from `Prefabs` folder to your scene.
3. Add **Console Opener** script to the scene from `Examples` folder or create a new one.  See [example](#console-openers).
4. To create a new command, create a new C# script and inherit from the `Command` class. See [example](#commands).

**Note**: all command files must be placed in package folder.

## Requirements

- Unity v. 2020 or newer
- TextMeshPro v. 3.0.5 or newer

## Console Settings

You can change console settings in `Edit > Project Settings > In-game Console`.

## Examples

### Commands

All commands should be in the `Commands` folder. There are some example commands: `help`, `log` and `clear`. Here's an example command that prints specified text to the console:

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

### Console Openers

Here's an example console opener for default input system:

```csharp
private void Update()
{
    if (Input.GetKeyDown(KeyCode.F3))
    {
        Console.OpenOrClose();   
    }
}
```

Here's an example console opener for Unity Input System:

```csharp
private void Awake()
{
    inputs.Game.Console.performed += _ => Console.OpenOrClose();
}
```

**Note**: to use the `Console` class you must use `InGameConsole` namespace:
```csharp
using InGameConsole;
```
