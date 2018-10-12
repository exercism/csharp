using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

var target = Argument("target", "Default");
var exercise = Argument<string>("exercise", null);

var exercisesSourceDir = "./exercises";
var exercisesBuildDir  = "./build";

var parallelOptions = new ParallelOptions 
{
    MaxDegreeOfParallelism = System.Environment.ProcessorCount
};

Task("Clean")
    .Does(() => {
		CleanDirectory(exercisesBuildDir);   
    });

// Copy everything to build so we make no changes in the actual files.
Task("CopyExercises")
    .IsDependentOn("Clean")
    .Does(() => {
        CopyDirectory($"{exercisesSourceDir}/{exercise}", $"{exercisesBuildDir}/{exercise}");
    });

Task("EnableAllTests")
    .IsDependentOn("CopyExercises")
    .Does(() => {
        var skipRegex = new Regex(@"Skip\s*=\s*""Remove to run test""", RegexOptions.Compiled);
        var testFiles = GetFiles(exercisesBuildDir + "/*/*Test.cs");

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


Task("BuildGenerators")
    .Does(() => {
       DotNetCoreBuild("./generators/Generators.csproj");
    });

Task("TestUsingExampleImplementation")
    .IsDependentOn("ReplaceStubWithExample")
    .Does(() => {
        var allProjects = GetFiles(exercisesBuildDir + "/*/*.csproj");
        Parallel.ForEach(allProjects, parallelOptions, (project) => DotNetCoreTest(project.FullPath));
    });
Task("Default")
    .IsDependentOn("BuildGenerators")
    .IsDependentOn("TestUsingExampleImplementation")
    .Does(() => { });

RunTarget(target);
