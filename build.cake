using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

var target = Argument("target", "Default");
var exercise = Argument<string>("exercise", null);

var sourceDir = "./exercises";
var buildDir  = "./build";

var parallelOptions = new ParallelOptions 
{
    MaxDegreeOfParallelism = System.Environment.ProcessorCount
};

Task("Clean")
    .Does(() => {
		CleanDirectory(buildDir);   
    });

// Copy everything to build so we make no changes in the actual files.
Task("CopyExercises")
    .IsDependentOn("Clean")
    .Does(() => {
        CopyDirectory($"{sourceDir}/{exercise}", $"{buildDir}/{exercise}");
    });

Task("EnableAllTests")
    .IsDependentOn("CopyExercises")
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
        // These projects have a working default implementation, and have
        // all the tests enabled. These should pass without any changes.
        var refactoringProjects = 
              GetFiles(buildDir + "/*/TreeBuilding.csproj")
            + GetFiles(buildDir + "/*/Ledger.csproj")
            + GetFiles(buildDir + "/*/Markdown.csproj");

        Parallel.ForEach(refactoringProjects, parallelOptions, (project) => DotNetCoreTest(project.FullPath));
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
        var allProjects = GetFiles(buildDir + "/*/*.csproj");
        Parallel.ForEach(allProjects, parallelOptions, (project) => DotNetCoreTest(project.FullPath));
    });

Task("Default")
    .IsDependentOn("TestUsingExampleImplementation")
    .Does(() => { });

RunTarget(target);