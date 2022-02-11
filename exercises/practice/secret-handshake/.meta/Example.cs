using System.Collections.Generic;
using System.Linq;

public class SecretHandshake
{
    private static readonly Dictionary<int, string> CommandValues = new Dictionary<int, string>
        {
            { 1, "wink" },
            { 2, "double blink" },
            { 4, "close your eyes" },
            { 8, "jump" }
        };

    public static string[] Commands(int commandValue)
    {
        var commands = new List<string>();
        foreach (var value in CommandValues.OrderBy(x => x.Key))
        {
            if ((commandValue & value.Key) != 0)
            {
                commands.Add(value.Value);
            }
        }

        if (ShouldReverse(commandValue))
        {
            return commands.AsEnumerable().Reverse().ToArray();
        }
        return commands.ToArray();
    }

    private static bool ShouldReverse(int commandValue)
    {
        return (commandValue & 16) != 0;
    }
}
