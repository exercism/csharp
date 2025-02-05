using CommandLine;

namespace Generators;

public static class Program
{
    static void Main(string[] args) =>
        Parser.Default.ParseArguments<NewOptions, UpdateOptions>(args)
            .WithParsed<NewOptions>(HandleNewCommand)
            .WithParsed<UpdateOptions>(HandleUpdateCommand)
            .WithParsed<SyncOptions>(HandleSyncCommand)
            .WithNotParsed(HandleErrors);

    private static void HandleNewCommand(NewOptions options) =>
        Exercises.Untemplated(options.Exercise).ForEach(TemplateGenerator.Generate);

    private static void HandleUpdateCommand(UpdateOptions options) =>
        Exercises.Templated(options.Exercise).ForEach(TestsGenerator.Generate);

    private static void HandleSyncCommand(SyncOptions options) =>
        ProbSpecs.Sync();

    private static void HandleErrors(IEnumerable<Error> errors) =>
        errors.ToList().ForEach(Console.Error.WriteLine);

    [Verb("new", HelpText = "Create a new exercise generator template file.")]
    private class NewOptions
    {
        [Option('e', "exercise", Required = false, HelpText = "The exercise (slug) for which to generate a generator file.")]
        public string? Exercise { get; set; }
    }
    
    [Verb("update", isDefault: true, HelpText = "Update the test file's contents using the exercise's generator template file.")]
    private class UpdateOptions
    {
        [Option('e', "exercise", Required = false, HelpText = "The exercise (slug) which tests file to generate.")]
        public string? Exercise { get; set; }
    }

    [Verb("sync", HelpText = "Sync the problem specifications repo.")]
    private class SyncOptions;
}