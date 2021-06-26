using System.IO;
using System.Linq;
using LibGit2Sharp;
using Serilog;

namespace Exercism.CSharp.Input
{
    internal class PropSpecsRepository
    {
        private const string ProblemSpecificationsGitUrl = "https://github.com/exercism/problem-specifications.git";
        private const string ProblemSpecificationsBranch = "master";
        private const string ProblemSpecificationsRemote = "origin";
        private const string ProblemSpecificationsRemoteBranch = ProblemSpecificationsRemote + "/" + ProblemSpecificationsBranch;

        private readonly Options _options;

        public PropSpecsRepository(Options options) => _options = options;

        public void SyncToLatest()
        {
            CloneRepository();
            ResetBranchToUpstream();
        }

        private void CloneRepository()
        {
            if (Directory.Exists(_options.ProbSpecsDir))
                return;

            Log.Information("Cloning repository...");

            Repository.Clone(ProblemSpecificationsGitUrl, _options.ProbSpecsDir);

            Log.Information("Repository cloned.");
        }

        private void ResetBranchToUpstream()
        {
            Log.Information("Updating repository to latest version...");

            using (var repository = new Repository(_options.ProbSpecsDir))
            {
                Commands.Fetch(repository, ProblemSpecificationsRemote, Enumerable.Empty<string>(), new FetchOptions(), null);

                var remoteBranch = repository.Branches[ProblemSpecificationsRemoteBranch];
                repository.Reset(ResetMode.Hard, remoteBranch.Tip);
            }

            Log.Information("Updated repository to latest version.");
        }
    }
}
