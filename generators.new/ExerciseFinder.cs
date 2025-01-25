using Humanizer;

namespace Generators;

internal record Exercise(string Slug, string Name);

internal static class ExerciseFinder
{
    internal static IEnumerable<Exercise> TemplatedExercises() =>
        Directory.EnumerateFiles(Paths.PracticeExercisesDir, "Generator.tpl", SearchOption.AllDirectories)
            .Select(templateFile => Directory.GetParent(templateFile)!.Parent!.Name)
            .Select(ToExercise)
            .OrderBy(exercise => exercise.Slug);

    private static Exercise ToExercise(string slug) => new(slug, slug.Pascalize());
}