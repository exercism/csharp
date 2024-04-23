﻿using System.IO;
using System.Linq;
using LibGit2Sharp;
using Serilog;

namespace Exercism.CSharp.Input;

internal class PropSpecsRepository
{
    private const string ProblemSpecificationsGitUrl = "https://github.com/exercism/problem-specifications.git";
    private const string ProblemSpecificationsBranch = "main";
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

            Log.Debug("Cloning repository...");

            Repository.Clone(ProblemSpecificationsGitUrl, _options.ProbSpecsDir);

            Log.Debug("Repository cloned.");
        }

    private void ResetBranchToUpstream()
    {
            Log.Debug("Updating repository to latest version...");

            using (var repository = new Repository(_options.ProbSpecsDir))
            {
                Commands.Fetch(repository, ProblemSpecificationsRemote, Enumerable.Empty<string>(), new FetchOptions(), null);

                var remoteBranch = repository.Branches[ProblemSpecificationsRemoteBranch];
                repository.Reset(ResetMode.Hard, remoteBranch.Tip);
            }

            Log.Debug("Updated repository to latest version.");
        }
}