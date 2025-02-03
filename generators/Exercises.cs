using System.Text.Json;

using Humanizer;

namespace Generators;

internal record Exercise(string Slug, string Name, bool HasTemplate);

internal static class Exercises
{
    internal static List<Exercise> TemplatedExercises() =>
        Directory.EnumerateFiles(Paths.PracticeExercisesDir, "Generator.tpl", SearchOption.AllDirectories)
            .Select(templateFile => Directory.GetParent(templateFile)!.Parent!.Name)
            .Select(ToExercise)
            .OrderBy(exercise => exercise.Slug)
            .ToList();

    internal static Exercise TemplatedExercise(string slug)
    {
        var exercise = ToExercise(slug);

        if (!Directory.Exists(Paths.ExerciseDir(exercise)))
            throw new ArgumentException($"Could not find exercise '{slug}'.");
        
        if (!File.Exists(Paths.TemplateFile(exercise)))
            throw new ArgumentException($"Could not find template file for exercise '{slug}'.");

        return exercise;
    }

    private static Exercise ToExercise(string slug) => new(slug, slug.Dehumanize(), true);
    
    private static IEnumerable<string> ParseExerciseSlugs() =>
        ParseConfig()
            .GetProperty("exercises")
            .GetProperty("practice")
            .EnumerateArray()
            .Select(exercise => exercise.GetProperty("slug").ToString());
    
    private static JsonElement ParseConfig() =>
        JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(Paths.TrackConfigFile));  
}