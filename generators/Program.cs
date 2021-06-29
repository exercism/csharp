using System.Collections.Generic;

using CommandLine;
using Exercism.CSharp.Exercises;

using Serilog;

namespace Exercism.CSharp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Logging.Setup();

            Options.Parse(args)
                .WithParsed(OnParseSuccess)
                .WithNotParsed(OnParseError);
        }
        
        private static void OnParseSuccess(Options options)
        {
            var generatorRunner = new GeneratorRunner(options);

            // TODO: enable nullable
            if (options.Exercise == null)
                generatorRunner.RegenerateAllExercises();
            else
                generatorRunner.RegenerateSingleExercise(options.Exercise);
        }

        private static void OnParseError(IEnumerable<Error> errors) =>
            Log.Error("Errors: {Errors}", errors);
    }
}