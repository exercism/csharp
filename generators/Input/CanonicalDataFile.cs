using System.IO;
using System.Linq;
using LibGit2Sharp;
using Serilog;

namespace Generators.Input
{
    public class CanonicalDataFile
    {
        private const string ProblemSpecificationsGitUrl = "https://github.com/exercism/problem-specifications.git";
        private const string ProblemSpecificationsRemoteName = "origin";

        private readonly CanonicalDataOptions _options;

        public CanonicalDataFile(CanonicalDataOptions options)
        {
            _options = options;
        }
        
        public string Contents(string exercise)
        {
            var exerciseCanonicalDataPath = Path.Combine(_options.CanonicalDataDirectory, "exercises", exercise, "canonical-data.json");
            return File.ReadAllText(exerciseCanonicalDataPath);
        }

        public void DownloadData()
        {
            CloneRepository();

            if (_options.CacheCanonicalData)
                return;

            FetchBranch();
        }

        private void CloneRepository()
        {
            if (Directory.Exists(_options.CanonicalDataDirectory))
                return;

            Log.Information("Cloning repository...");

            Repository.Clone(ProblemSpecificationsGitUrl, _options.CanonicalDataDirectory);

            Log.Information("Repository cloned.");
        }

        private void FetchBranch()
        {
            Log.Information("Updating repository to latest version...");

            using (var repository = new Repository(_options.CanonicalDataDirectory))
                Commands.Fetch(repository, ProblemSpecificationsRemoteName, Enumerable.Empty<string>(), new FetchOptions(), null);

            Log.Information("Updated repository to latest version.");
        }
    }
}
