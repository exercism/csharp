#addin nuget:?package=Cake.FileHelpers&version=3.2.0

using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

var exercise = Argument<string>("exercise", null);

var exercisesSourceDir = "./exercises";
var exercisesBuildDir  = "./build";

var parallelOptions = new ParallelOptions 
{
    MaxDegreeOfParallelism = System.Environment.ProcessorCount
};

Task("ConfigletLint")
    .Does(() => StartProcess("./bin/fetch-configlet"));
    .Does(() => StartProcess("./bin/configlet", "lint ."));

Task("BuildGenerators")
    .Does(() => DotNetCoreBuild("./generators/Generators.csproj"));

Task("Clean")
    .Does(() => CleanDirectory(exercisesBuildDir));

// Copy everything to build so we make no changes in the actual files.
Task("CopyExercises")
    .IsDependentOn("Clean")
    .Does(() => CopyDirectory($"{exercisesSourceDir}/{exercise}", $"{exercisesBuildDir}/{exercise}"));

Task("EnableAllTests")
    .IsDependentOn("CopyExercises")
    .Does(() => ReplaceTextInFiles($"{buildDir}/*/*Test.fs", "Skip = \"Remove to run test\"", ""));

Task("TestRefactoringProjects")
    .IsDependentOn("EnableAllTests")
    .Does(() => {
        var refactoringProjects = 
              GetFiles(exercisesBuildDir + "/*/TreeBuilding.csproj")
            + GetFiles(exercisesBuildDir + "/*/Ledger.csproj")
            + GetFiles(exercisesBuildDir + "/*/Markdown.csproj");

        Parallel.ForEach(refactoringProjects, parallelOptions, (project) => DotNetCoreTest(project.FullPath));
});

Task("ReplaceStubWithExample")
    .IsDependentOn("TestRefactoringProjects")
    .Does(() => {
        var allProjects = GetFiles(exercisesBuildDir + "/*/*.csproj");

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
        if (string.IsNullOrEmpty(exercise)) {
            DotNetCoreTest($"{exercisesBuildDir}/Exercises.sln");
        }
        else {
            DotNetCoreTest($"{exercisesBuildDir}/{exercise}");
        } 
    });

Task("Build")
    .IsDependentOn("ConfigletLint")
    .IsDependentOn("BuildGenerators")
    .IsDependentOn("TestUsingExampleImplementation")
    .Does(() => { });

RunTarget("Build");
