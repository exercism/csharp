using CommandLine;

namespace Generators;

public static class Program
{
    static void Main(string[] args) =>
        Parser.Default.ParseArguments<NewOptions, GenerateOptions>(args)
            .WithParsed<GenerateOptions>(HandleGenerateCommand)
            .WithParsed<NewOptions>(HandleNewCommand)
            .WithNotParsed(HandleErrors);

    private static void HandleGenerateCommand(GenerateOptions options) =>
        Exercises.Templated().ForEach(TestsGenerator.Generate);

    private static void HandleNewCommand(NewOptions options) =>
        Exercises.Untemplated().ForEach(TemplateGenerator.Generate);

    private static void HandleErrors(IEnumerable<Error> errors) =>
        errors.ToList().ForEach(Console.Error.WriteLine);
    
    [Verb("generate", isDefault: true, HelpText = "Generate the test file's contents using the exercise's generator template file.")]
    private class GenerateOptions
    {
        [Option('e', "exercise", Required = false, HelpText = "The exercise (slug) which tests file to generate.")]
        public string? Exercise { get; set; }
    }

    [Verb("new", HelpText = "Create a new exercise generator template file.")]
    private class NewOptions
    {
        [Option('e', "exercise", Required = false, HelpText = "The exercise (slug) for which to generate a generator file.")]
        public string? Exercise { get; set; }
    }
}