internal static class Paths
{
    private static readonly string RootDir = Path.GetFullPath(Path.Join(Environment.CurrentDirectory, "..", "..", "..", ".."));
    private static readonly string ProbSpecsExercisesDir = Path.Join(RootDir, ".problem-specifications", "exercises");
    internal static readonly string PracticeExercisesDir = Path.Join(RootDir, "exercises", "practice");

    private static string ExerciseDir(Exercise exercise) => Path.Join(PracticeExercisesDir, exercise.Slug);
    internal static string TestsFile(Exercise exercise) => Path.Join(ExerciseDir(exercise), $"{exercise.Name}Tests.cs");
    internal static string TestsTomlFile(Exercise exercise) => Path.Join(ExerciseDir(exercise), ".meta", "tests.toml");
    internal static string TemplateFile(Exercise exercise) => Path.Join(ExerciseDir(exercise), ".meta", "Generator.tpl");
    internal static string CanonicalDataFile(Exercise exercise) => Path.Join(ProbSpecsExercisesDir, exercise.Slug, "canonical-data.json");
}
