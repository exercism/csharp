namespace Generators;

internal static class Paths
{
    private static readonly string RootDir = GetRootDir();
    internal static readonly string ProbSpecsDir = Path.Join(RootDir, ".problem-specifications");
    private static readonly string ProbSpecsExercisesDir = Path.Join(ProbSpecsDir, "exercises");
    internal static readonly string PracticeExercisesDir = Path.Join(RootDir, "exercises", "practice");

    internal static string ExerciseDir(Exercise exercise) => Path.Join(PracticeExercisesDir, exercise.Slug);
    internal static string TestsFile(Exercise exercise) => Path.Join(ExerciseDir(exercise), $"{exercise.Name}Tests.cs");
    internal static string TestsTomlFile(Exercise exercise) => Path.Join(ExerciseDir(exercise), ".meta", "tests.toml");
    internal static string TemplateFile(Exercise exercise) => Path.Join(ExerciseDir(exercise), ".meta", "Generator.tpl");
    internal static string CanonicalDataFile(Exercise exercise) => Path.Join(ProbSpecsExercisesDir, exercise.Slug, "canonical-data.json");

    private static string GetRootDir()
    {
        // Workaround: IDEs use a different current directory than dotnet run
        var currentDir = Environment.CurrentDirectory;
        while (!File.Exists(Path.Join(currentDir, "LICENSE")))
            currentDir = Path.GetDirectoryName(currentDir);

        return currentDir!;
    }
}