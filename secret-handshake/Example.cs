using System;
using System.Collections.Generic;
using System.Linq;

public class SecretHandshake
{
    private readonly int commandValue;
    private readonly Dictionary<int, string> commandValues;

    public SecretHandshake(int commandValue)
    {
        this.commandValue = commandValue;
        commandValues = new Dictionary<int, string>
        {
            { 1, "wink" },
            { 2, "double blink" },
            { 4, "close your eyes" },
            { 8, "jump" }
        };
    }

    public string[] Commands()
    {
        List<string> commands = new List<string>();
        foreach (var value in commandValues.OrderBy(x => x.Key))
        {
            if ((commandValue & value.Key) != 0)
            {
                commands.Add(value.Value);
            }
        }

        if (ShouldReverse())
        {
            return commands.AsEnumerable().Reverse().ToArray();
        }
        else
        {
            return commands.ToArray();
        }
    }

    private bool ShouldReverse()
    {
        return (commandValue & 16) != 0;
    }
}
