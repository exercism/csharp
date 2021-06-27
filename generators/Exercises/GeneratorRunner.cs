using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Exercism.CSharp.Helpers;
using Exercism.CSharp.Input;

using Serilog;

namespace Exercism.CSharp.Exercises
{
    internal class GeneratorRunner
    {
        private readonly Options _options;
        private readonly Dictionary<string, Type> _exerciseGeneratorTypes;
        private readonly Lazy<ExerciseParser> _exerciseParser;

        public GeneratorRunner(Options options)
        {
            _options = options;
            _exerciseParser = new Lazy<ExerciseParser>(() => ExerciseParser.Create(options));
            _exerciseGeneratorTypes = FindExerciseGeneratorTypes();
        }

        public void RegenerateAllExercises()
        {
            foreach (var exerciseGeneratorType in _exerciseGeneratorTypes.Values)
                RegenerateExercise(exerciseGeneratorType);
        }

        public void RegenerateSingleExercise(string exercise)
        {
            if (_exerciseGeneratorTypes.TryGetValue(exercise, out var exerciseGeneratorType))
                RegenerateExercise(exerciseGeneratorType);
            else
                Log.Error("Could not find generator for {Name} exercise", exercise);
        }

        private void RegenerateExercise(Type exerciseGeneratorType)
        {
            var exerciseGenerator = Activator.CreateInstance(exerciseGeneratorType) as ExerciseGenerator;
            exerciseGenerator!.Regenerate(_exerciseParser.Value.Parse(exerciseGenerator.Name), _options);
            Log.Information("{Name}: updated", exerciseGenerator.Name);
        }

        private static Dictionary<string, Type> FindExerciseGeneratorTypes() =>
            Assembly.GetEntryAssembly()!.GetTypes()
                .Where(type => typeof(ExerciseGenerator).IsAssignableFrom(type) && !type.IsAbstract)
                .ToDictionary(type => type.ToExerciseName(), type => type, StringComparer.OrdinalIgnoreCase);
    }
}
