using System.IO;
using System.Linq;
using LibGit2Sharp;
using Serilog;

namespace Generators.Input
{
    public class CanonicalDataFile
    {
        private const string ProblemSpecificationsGitUrl = "https://github.com/exercism/problem-specifications.git";
        private const string ProblemSpecificationsBranch = "master";
        private const string ProblemSpecificationsRemote = "origin";
        private const string ProblemSpecificationsRemoteBranch = ProblemSpecificationsRemote + "/" + ProblemSpecificationsBranch;

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

            UpdateToLatestVersion();
        }

        private void CloneRepository()
        {
            if (Directory.Exists(_options.CanonicalDataDirectory))
                return;

            Log.Information("Cloning repository...");

            Repository.Clone(ProblemSpecificationsGitUrl, _options.CanonicalDataDirectory);

            Log.Information("Repository cloned.");
        }

        private void UpdateToLatestVersion()
        {
            Log.Information("Updating repository to latest version...");

            using (var repository = new Repository(_options.CanonicalDataDirectory))
            {
                Commands.Fetch(repository, ProblemSpecificationsRemote, Enumerable.Empty<string>(), new FetchOptions(), null);
                
                var remoteBranch = repository.Branches[ProblemSpecificationsRemoteBranch];
                repository.Reset(ResetMode.Hard, remoteBranch.Tip);
            }   

            Log.Information("Updated repository to latest version.");
        }
    }
}
