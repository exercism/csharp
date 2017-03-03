#addin "Cake.FileHelpers"

// TODO:
// Remove comments
// Add option to take in project name from command line
// Beautify
// Remove limit of 2 from everywhere

var target = Argument("target", "Default");
var project = Argument("project", "*");

var buildDir = "./build/";
var sourceDir = "./exercises/";
var projects = GetFiles(buildDir + "**/" + project + ".csproj");


Task("Clean")
	.Does(() => {
		CleanDirectory("./build/");   
    });


// Copy everything to build so we make no changes in the 
// actual files.
Task("Copy-Exercises")
    .IsDependentOn("Clean")
    .Does(() => {
        CopyDirectory(sourceDir, buildDir);
    });


Task("Restore-Nuget-Packages")
    .IsDependentOn("Copy-Exercises")
    .Does(() => {
       foreach (var project in projects) {
            DotNetCoreRestore(project.ToString());
       }
    });


Task("Enable-All-Tests")
    .IsDependentOn("Restore-Nuget-Packages")
    .Does(() => {
        var testFiles = GetFiles(buildDir + "**/*Test.cs");
        foreach (var testFile in testFiles) {
            var skipRE = @"Skip\s*=\s*""Remove to run test""";
            ReplaceRegexInFiles(buildDir + "**/*Test.cs", skipRE, "");
        }

    });


Task("Replace-Stub-With-Example")
    .IsDependentOn("Enable-All-Tests")
    .Does(() => {
        foreach (var project in projects) {
            var projectDir = project.GetDirectory();
            var projectName = project.GetFilenameWithoutExtension();
            var stub = projectDir.GetFilePath(projectName).AppendExtension("cs");
            var example = projectDir.GetFilePath("Example.cs");
            
            DeleteFile(stub);
            MoveFile(example, stub);
        }
    });


Task("Build")
    .IsDependentOn("Replace-Stub-With-Example")
    .Does(() => {
       foreach (var project in projects) {
            DotNetCoreBuild(project.ToString());
       }
    });


Task("Test")
    .IsDependentOn("Build")
    .Does(() => {
        foreach (var project in projects) {
            DotNetCoreTest(project.ToString());
        }
    });


Task("Default")
    .IsDependentOn("Test")
    .Does(() => {});


RunTarget(target);