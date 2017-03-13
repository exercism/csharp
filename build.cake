using System.IO;
using System.Text.RegularExpressions;

var target = Argument("target", "Default");

var sourceDir = "./exercises";
var buildDir  = "./build";

var defaultSln     = buildDir + "/Exercises.Default.sln";
var allSln         = buildDir + "/Exercises.All.sln";
var refactoringSln = buildDir + "/Exercises.Refactoring.sln";

var dotNetCoreBuildSettings = new DotNetCoreBuildSettings { NoIncremental = true };

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

Task("BuildStubImplementations")
    .IsDependentOn("RestoreNugetPackages")
    .Does(() => {
        DotNetCoreBuild(defaultSln, dotNetCoreBuildSettings);
});

Task("EnableAllTests")
    .IsDependentOn("BuildStubImplementations")
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

        foreach (var refactoringProject in refactoringProjects) {
            DotNetCoreTest(refactoringProject.FullPath);
        }
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

        var allProjects = GetFiles(buildDir + "/*/*.csproj");

        foreach (var project in allProjects) {
            DotNetCoreTest(project.FullPath);
        }
    });

Task("Default")
    .IsDependentOn("TestUsingExampleImplementation")
    .Does(() => { });

RunTarget(target);