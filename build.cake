using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

var target = Argument("target", "Default");

var sourceDir = "./exercises";
var buildDir  = "./build";

var allSln         = buildDir + "/Exercises.All.sln";
var refactoringSln = buildDir + "/Exercises.Refactoring.sln";

var dotNetCoreMSBuildSettings = new DotNetCoreMSBuildSettings
{
    MaxCpuCount = 0
};

var dotNetCoreBuildSettings = new DotNetCoreBuildSettings 
{ 
    NoIncremental = true,
    MSBuildSettings = dotNetCoreMSBuildSettings 
};

var dotNetCoreTestSettings = new DotNetCoreTestSettings
{
    NoBuild = true
};

Task("Clean")
    .Does(() => {
		CleanDirectory(buildDir);   
    });

// Copy everything to build so we make no changes in the actual files.
Task("CopyExercises")
    .IsDependentOn("Clean")
    .Does(() => {
        CopyDirectory(sourceDir, buildDir);
    });

Task("RestoreNugetPackages")
    .IsDependentOn("CopyExercises")
    .Does(() => {
        DotNetCoreRestore(allSln);
    });

Task("EnableAllTests")
    .IsDependentOn("RestoreNugetPackages")
    .Does(() => {
        var skipRegex = new Regex(@"Skip\s*=\s*""Remove to run test""", RegexOptions.Compiled);
        var testFiles = GetFiles(buildDir + "/*/*Test.cs");

        foreach (var testFile in testFiles) {
            var contents = System.IO.File.ReadAllText(testFile.FullPath);

            if (skipRegex.IsMatch(contents)) {
                var updatedContents = skipRegex.Replace(contents, "");
                System.IO.File.WriteAllText(testFile.FullPath, updatedContents);
            }
        }
    });

Task("TestRefactoringProjects")
    .IsDependentOn("EnableAllTests")
    .Does(() => {
        DotNetCoreBuild(refactoringSln, dotNetCoreBuildSettings);

        // These projects have a working default implementation, and have
        // all the tests enabled. These should pass without any changes.
        var refactoringProjects = 
              GetFiles(buildDir + "/*/TreeBuilding.csproj")
            + GetFiles(buildDir + "/*/Ledger.csproj")
            + GetFiles(buildDir + "/*/Markdown.csproj");

        Parallel.ForEach(refactoringProjects, (project) => DotNetCoreTest(project.FullPath, dotNetCoreTestSettings));
});

Task("ReplaceStubWithExample")
    .IsDependentOn("TestRefactoringProjects")
    .Does(() => {
        var allProjects = GetFiles(buildDir + "/*/*.csproj");

        foreach (var project in allProjects) {
            var projectDir = project.GetDirectory();
            var projectName = project.GetFilenameWithoutExtension();
            var stub = projectDir.GetFilePath(projectName).AppendExtension("cs");
            var example = projectDir.GetFilePath("Example.cs");
            
            DeleteFile(stub);
            MoveFile(example, stub);
        }
    });

Task("TestUsingExampleImplementation")
    .IsDependentOn("ReplaceStubWithExample")
    .Does(() => {
        DotNetCoreBuild(allSln, dotNetCoreBuildSettings);
        var parallelOptions = new ParallelOptions 
        {
            MaxDegreeOfParallelism = System.Environment.ProcessorCount
        };

        var allProjects = GetFiles(buildDir + "/*/*.csproj");
        Parallel.ForEach(allProjects, parallelOptions, (project) => DotNetCoreTest(project.FullPath, dotNetCoreTestSettings));
    });

Task("Default")
    .IsDependentOn("TestUsingExampleImplementation")
    .Does(() => { });

RunTarget(target);