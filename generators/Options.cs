using System.IO;

using CommandLine;

namespace Exercism.CSharp
{
    internal class Options
    {
        [Option('e', "exercise", Required = false, HelpText = "The exercise to generate.")]
        public string Exercise { get; set; }

        // TODO: set to default value
        [Option('d', "dir", Required = false, HelpText = "The directory of the problem-specifications repo. If the not specified, the repo will be downloaded.")]
        public string ProbSpecsDir { get; set; }

        public string PracticeExercisesDir = Path.Combine("..", "exercises", "practice");
        
        public static ParserResult<Options> Parse(string[] args) => Parser.Default.ParseArguments<Options>(args);
    }
}