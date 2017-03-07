#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.DotNetCli
open System.Text

let project = environVarOrDefault "project" "*"
let buildDir = "./build/"
let sourceDir = "./exercises/"
let projectDirs = buildDir @@ project

let testFiles = !! (projectDirs @@ "*Test.cs")
let allProjects = !! (projectDirs @@ "*.csproj")
let defaultProjects = 
    !! (projectDirs @@ "*.csproj")        -- 
       (projectDirs @@ "DotDsl.csproj")  --
       (projectDirs @@ "Hangman.csproj") --
       (projectDirs @@ "React.csproj")
let refactoringProjects = 
    !! (projectDirs @@ "TreeBuilding.csproj") ++
       (projectDirs @@ "Ledger.csproj")       ++
       (projectDirs @@ "Markdown.csproj")

let restore project = DotNetCli.Restore (fun p -> { p with Project = project })
let build   project = DotNetCli.Build   (fun p -> { p with Project = project })
let test    project = DotNetCli.Test    (fun p -> { p with Project = project })

let restoreAndBuild project = 
    restore project
    build project    

let restoreAndTest project =    
    restore project
    test project

Target "Clean" (fun _ -> 
    DeleteDir buildDir
)

Target "CopyExercises" (fun _ -> 
    CopyDir buildDir sourceDir allFiles
)

Target "BuildUsingStubImplementation" (fun _ ->
    Seq.iter restoreAndBuild defaultProjects
)

Target "EnableAllTests" (fun _ ->
    let skipProperty = "Skip\s*=\s*\"Remove to run test\""
    RegexReplaceInFilesWithEncoding skipProperty "" Encoding.UTF8 testFiles
)

Target "TestRefactoringProjects" (fun _ ->
    Seq.iter restoreAndTest refactoringProjects
)

Target "ReplaceStubWithExampleImplementation" (fun _ ->
    let replaceStubWithExampleImplementation project =
        let stubFile = filename project + "" |> changeExt ".cs"
        let exampleFile = "Example.cs"
        RegexReplaceInFileWithEncoding exampleFile stubFile Encoding.UTF8 project

    Seq.iter replaceStubWithExampleImplementation allProjects
)

Target "TestUsingExampleImplementation" (fun _ ->
    Seq.iter restoreAndTest allProjects
)

"Clean"
  ==> "CopyExercises"
  ==> "BuildUsingStubImplementation"
  ==> "EnableAllTests"
  ==> "TestRefactoringProjects"
  ==> "ReplaceStubWithExampleImplementation"
  ==> "TestUsingExampleImplementation"

RunTargetOrDefault "TestUsingExampleImplementation"