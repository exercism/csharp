using CommandLine;

namespace Generators;

public static class Program
{
    static void Main(string[] args) =>
        Parser.Default.ParseArguments<NewOptions, GenerateOptions>(args)
            .WithParsed<GenerateOptions>(HandleGenerateCommand)
            .WithParsed<NewOptions>(HandleNewCommand)
            .WithNotParsed(HandleErrors);

    private static void HandleGenerateCommand(GenerateOptions options)
    {
        if (options.Exercise is not null)
        {
            TestsGenerator.Generate(Exercises.TemplatedExercise(options.Exercise));
            return;
        }
            
        foreach (var exercise in Exercises.TemplatedExercises())
            TestsGenerator.Generate(exercise);
    }

    private static void HandleNewCommand(NewOptions options) =>
        TemplateGenerator.Generate(Exercises.TemplatedExercise(options.Exercise));

    private static void HandleErrors(IEnumerable<Error> errors)
    {
        foreach (var error in errors)
            Console.Error.WriteLine(error.ToString());
    }
    
    [Verb("generate", isDefault: true, HelpText = "Generate the test file's contents using the exercise's generator template file.")]
    private class GenerateOptions
    {
        [Option('e', "exercise", Required = false, HelpText = "The exercise (slug) which tests file to generate.")]
        public string? Exercise { get; set; }
    }

    [Verb("new", HelpText = "Create a new exercise generator template file.")]
    private class NewOptions
    {
        [Option('e', "exercise", Required = true, HelpText = "The exercise (slug) for which to generate a generator file.")]
        public string? Exercise { get; set; }
    }
}