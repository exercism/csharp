using System.Collections.Generic;
using CommandLine;

namespace Generators
{
    public class Options
    {
        [Option('e', "exercises", Required = false, 
            HelpText = "Exercises to generate (if not specified, defaults to all exercises).")]
        public IEnumerable<string> Exercises { get; set; }
    }
}