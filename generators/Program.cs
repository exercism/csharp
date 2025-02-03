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

    private static void HandleNewCommand(NewOptions options)
    {
        throw new NotImplementedException();
    }

    private static void HandleErrors(IEnumerable<Error> errors)
    {
        foreach (var error in errors)
            Console.Error.WriteLine(error.ToString());
    }
}