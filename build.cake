#addin "Cake.FileHelpers"

var target = Argument("target", "Default");

var buildDir = "./build/";
var sourceDir = "./exercises/";

var allProjects = GetFiles(buildDir + "**/*.csproj");

/** The following exercises provide a stub implementation and the 
    user has to complete the implementation. Therefore compiling 
    these will result in failed compilation. Remove these and 
    test the rest of the exercises.
*/
var defaultProjects = allProjects 
    -  GetFiles(buildDir + "**/DotDsl.csproj")
    -  GetFiles(buildDir + "**/Hangman.csproj")
    -  GetFiles(buildDir + "**/React.csproj");

/** These projects have full and working implementations, and have
    all the tests enabled. These should pass without any changes.
*/
var refactoringProjects = GetFiles(buildDir + "**/TreeBuilding.csproj")
    + GetFiles(buildDir + "**/Ledger.csproj")
    + GetFiles(buildDir + "**/Markdown.csproj");


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
       foreach (var project in allProjects) {
           DotNetCoreRestore(project.FullPath);
       }
    });


Task("RestoreAndBuildStubImplementations")
    .IsDependentOn("RestoreNugetPackages")
    .Does(() => {
        foreach (var project in defaultProjects) {
            DotNetCoreBuild(project.FullPath);
        }
});


Task("EnableAllTests")
    .IsDependentOn("RestoreAndBuildStubImplementations")
    .Does(() => {
        var skipRE = @"Skip\s*=\s*""Remove to run test""";
        ReplaceRegexInFiles(buildDir + "**/*Test.cs", skipRE, "");
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