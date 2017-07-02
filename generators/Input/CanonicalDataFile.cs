using System.IO;
using System.Linq;
using LibGit2Sharp;

namespace Generators.Input
{
    public static class CanonicalDataFile
    {
        private const string CacheDir = "./.cache";
        private const string ProblemSpecificationsGitUrl = "https://github.com/exercism/problem-specifications.git";
        private const string RemoteName = "origin";

        static CanonicalDataFile()
        {
            if (!Directory.Exists(CacheDir))
                Repository.Clone(ProblemSpecificationsGitUrl, CacheDir);

            using (var repository = new Repository(CacheDir))
                Commands.Fetch(repository, RemoteName, Enumerable.Empty<string>(), new FetchOptions(), null);
        }

        public static string Contents(string exercise)
        {
            var exerciseCanonicalDataPath = Path.Combine(CacheDir, "exercises", exercise, "canonical-data.json");
            return File.ReadAllText(exerciseCanonicalDataPath);
        }
    }
}
