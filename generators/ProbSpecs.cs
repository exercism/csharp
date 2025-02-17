using LibGit2Sharp;

namespace Generators;

internal static class ProbSpecs
{
    internal static void Sync()
    {
        Console.WriteLine($"Syncing problem-specifications repo...");
        Clone();
        Pull();
    }

    private static void Clone()
    {
        if (!Directory.Exists(Paths.ProbSpecsDir))
            Repository.Clone("https://github.com/exercism/problem-specifications.git", Paths.ProbSpecsDir);
    }

    private static void Pull()
    {
        using var repo = new Repository(Paths.ProbSpecsDir);
        Commands.Pull(repo, new Signature("Exercism", "info@exercism.org", DateTimeOffset.Now), new PullOptions());
    }
}