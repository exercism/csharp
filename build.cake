#addin "Cake.FileHelpers"

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

///////////////////////////////////////////////////////////////////////////////
// SETUP
///////////////////////////////////////////////////////////////////////////////

var buildDir = Directory("./build/");
var buildExerciseDir = buildDir + Directory("exercises");
var sourceDir = Directory("./exercises/");

var defaultSln = buildDir + File("Exercises.Default.sln");
var allSln = buildDir + File("Exercises.All.sln");
var refactoringSln = buildDir + File("Exercises.Refactoring.sln");


// Since dotnet core does not support testing by solution as of now, 
// we need to keep a tab of the project files for running tests. 

var buildPath = buildDir.Path.FullPath;
var allProjects = GetFiles(buildPath + "/**/*.csproj");

/** The following exercises provide a stub implementation and the 
    user has to complete the implementation. Therefore compiling 
    these will result in failed compilation. Remove these and 
    test the rest of the exercises.
*/
var defaultProjects = allProjects 
    -  GetFiles(buildPath + "/**/DotDsl.csproj")
    -  GetFiles(buildPath + "/**/Hangman.csproj")
    -  GetFiles(buildPath + "/**/React.csproj");

/** These projects have full and working implementations, and have
    all the tests enabled. These should pass without any changes.
*/
var refactoringProjects = GetFiles(buildPath + "/**/TreeBuilding.csproj")
    + GetFiles(buildPath + "/**/Ledger.csproj")
    + GetFiles(buildPath + "/**/Markdown.csproj");


///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////


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


Task("RestoreAndBuildStubImplementations")
    .IsDependentOn("RestoreNugetPackages")
    .Does(() => {
        DotNetCoreBuild(defaultSln);
});


Task("EnableAllTests")
    .IsDependentOn("RestoreAndBuildStubImplementations")
    .Does(() => {
        var skipRE = @"Skip\s*=\s*""Remove to run test""";
        ReplaceRegexInFiles("./build/**/*Test.cs", skipRE, "");
    });


Task("RestoreAndTestRefactoringProjects")
    .IsDependentOn("EnableAllTests")
    .Does(() => {
        foreach (var project in refactoringProjects) {
            DotNetCoreTest(project.FullPath);
        }
});


Task("ReplaceStubWithExample")
    .IsDependentOn("RestoreAndTestRefactoringProjects")
    .Does(() => {
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
        foreach (var project in allProjects) {
            DotNetCoreTest(project.FullPath);
        }
    });
    

Task("Default")
    .IsDependentOn("TestUsingExampleImplementation")
    .Does(() => { });


RunTarget(target);