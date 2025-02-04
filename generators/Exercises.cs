using System.Text.Json;

using Humanizer;

namespace Generators;

internal record Exercise(string Slug, string Name);

internal static class Exercises
{
    internal static List<Exercise> Templated(string? slug = null) => Find(slug, hasTemplate: true);

    internal static List<Exercise> Untemplated(string? slug = null) => Find(slug, hasTemplate: false);

    private static List<Exercise> Find(string? slug, bool hasTemplate) =>
        Parse()
            .Where(exercise => slug is null || exercise.Slug == slug)
            .Where(exercise => hasTemplate == HasTemplate(exercise))
            .ToList();

    private static IEnumerable<Exercise> Parse() =>
        JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(Paths.TrackConfigFile))
            .GetProperty("exercises")
            .GetProperty("practice")
            .EnumerateArray()
            .Select(exercise => exercise.GetProperty("slug").ToString())
            .Select(ToExercise);

    private static Exercise ToExercise(string slug) => new(slug, slug.Dehumanize());
    
    private static bool HasTemplate(Exercise exercise) => File.Exists(Paths.TemplateFile(exercise));
}