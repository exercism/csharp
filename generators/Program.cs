using CommandLine;

namespace Generators;

public static class Program 
{
    private class Options
    {
        [Option('e', "exercise", Required = false, HelpText = "The exercise (slug) to generate the tests file for.")]
        public string? Exercise { get; set; }
    }
    
    static void Main(string[] args) =>
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(options =>
            {
                foreach (var exercise in Exercises(options))
                    TestsGenerator.Generate(exercise);
            });

    private static Exercise[] Exercises(Options options) =>
        options.Exercise is null
            ? Generators.Exercises.TemplatedExercises()
            : [Generators.Exercises.TemplatedExercise(options.Exercise)];
}