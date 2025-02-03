using CommandLine;

namespace Generators;

[Verb("generate", isDefault: true, HelpText = "Generate the test file's contents using the exercise's generator template file.")]
internal class GenerateOptions
{
    [Option('e', "exercise", Required = false, HelpText = "The exercise (slug) which tests file to generate.")]
    public string? Exercise { get; set; }
}

[Verb("new", HelpText = "Create a new exercise generator template file.")]
internal class NewOptions
{
    [Option('e', "exercise", Required = true, HelpText = "The exercise (slug) for which to generate a generator file.")]
    public string Exercise { get; set; }
}
