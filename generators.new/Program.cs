namespace Generators;

public static class Program 
{
    static void Main()
    {
        foreach (var exercise in ExerciseFinder.TemplatedExercises())
            TestGenerator.GenerateTestsFromTemplate(exercise);
    }
}