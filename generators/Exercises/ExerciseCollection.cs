using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Input;

namespace Exercism.CSharp.Exercises
{
    public class ExerciseCollection : IEnumerable<Exercise>
    {
        private readonly CanonicalDataFile _canonicalDataFile;
        private readonly Dictionary<string, Type> _exerciseTypesByName;

        public ExerciseCollection(CanonicalDataFile canonicalDataFile)
            => (_canonicalDataFile, _exerciseTypesByName) = (canonicalDataFile, GetExerciseTypesByName());

        private static Dictionary<string, Type> GetExerciseTypesByName()
            => Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(IsConcreteGenerator)
                .ToDictionary(type => type.ToExerciseName(), StringComparer.OrdinalIgnoreCase);

        private static bool IsConcreteGenerator(Type type) => typeof(Exercise).IsAssignableFrom(type);

        public IEnumerator<Exercise> GetEnumerator() => GetExercises().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<Exercise> GetExercises()
        {
            foreach (var exercise in TrackConfigFile.GetExercises())
            {
                var exerciseName = exercise.Slug.ToExerciseName();
                if (exercise.Deprecated)
                    yield return new DeprecatedExercise(exerciseName);
                else if (HasNoCanonicalData(exerciseName))
                    yield return new MissingDataExercise(exerciseName);
                else if (IsNotImplemented(exerciseName))
                    yield return new UnimplementedExercise(exerciseName);
                else if (IsOutdated(exerciseName))
                    yield return new OutdatedExercise(exerciseName);
                else
                    yield return CreateExercise(exerciseName);
            }
        }

        private bool HasNoCanonicalData(string exerciseName) => !_canonicalDataFile.Exists(exerciseName);

        private bool IsNotImplemented(string exerciseName) => !_exerciseTypesByName.ContainsKey(exerciseName.ToExerciseName());

        private bool IsOutdated(string exerciseName) {
            var filePath = FilePathHelper.TestClassFilePath(exerciseName, exerciseName.ToTestClassName());
            var firsLine = File.ReadLines(filePath).First();

            if (firsLine.StartsWith("//")) {
                var testversion = Regex.Match(firsLine, @"[\d\.]{5}").Value;
                var canonicalDataParser = new CanonicalDataParser(_canonicalDataFile);
                var canonicalDataVersion = canonicalDataParser.Parse(exerciseName).Version;
                return testversion != canonicalDataVersion;
            }

            return false;
        }

        private Exercise CreateExercise(string exerciseName)
            => (Exercise)Activator.CreateInstance(_exerciseTypesByName[exerciseName.ToExerciseName()]);
    }
}
