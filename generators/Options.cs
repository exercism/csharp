using System;
using System.IO;
using CommandLine;

namespace Exercism.CSharp
{
    public class Options
    {
        private static string DefaultCanonicalDataDirectory
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "exercism", "problem-specifications");

        [Option('e', "exercise", Required = false,
            HelpText = "Exercise to generate (defaults to all exercises).")]
        public string Exercise { get; set; }

        [Option('s', "status", Required = false,
            HelpText = "The generator status to filter on (defaults to exercises with generator).")]
        public GeneratorStatus Status { get; set; }

        [Option('d', "canonicaldatadirectory", Required = false,
            HelpText = "Canonical data directory. If the directory does not exist, the canonical data will be downloaded.")]
        public string CanonicalDataDirectory { get; set; }

        [Option('c', "cachecanonicaldata", Required = false, Default = false,
            HelpText = "Use the cached canonical data and don't update the data.")]
        public bool CacheCanonicalData { get; set; }

        public bool ShouldGenerate { get; set; }

        public void Setup()
        {
            CanonicalDataDirectory = CanonicalDataDirectory ?? DefaultCanonicalDataDirectory;
            ShouldGenerate = Exercise != null;
        }
    }
}