#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.DotNetCli

let buildDir = "./build/"
let sourceDir = "./exercises/"

let testFiles = !! (buildDir @@ "*/*Test.cs")
let allProjects = !! (buildDir @@ "*/*.csproj")
let defaultProjects = 
    !! (buildDir @@ "*/*.csproj") -- 
       (buildDir @@ "*/DotDsl.csproj") --
       (buildDir @@ "*/Hangman.csproj") --
       (buildDir @@ "*/React.csproj")
let refactoringProjects = 
    !! (buildDir @@ "*/TreeBuilding.csproj") ++
       (buildDir @@ "*/Ledger.csproj")       ++
       (buildDir @@ "*/Markdown.csproj")

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

Target "IgnoreExampleImplementation" (fun _ ->
    RegexReplaceInFilesWithEncoding 
        "</PropertyGroup>" 
        "</PropertyGroup><ItemGroup><Compile Remove=\"Example.cs\" /></ItemGroup>"
        System.Text.Encoding.UTF8 allProjects
)

Target "BuildUsingStubImplementation" (fun _ ->
    Seq.iter restoreAndBuild defaultProjects
)

Target "EnableAllTests" (fun _ ->
    RegexReplaceInFilesWithEncoding 
        "Skip\s*=\s*\"Remove to run test\"" 
        "" 
        System.Text.Encoding.UTF8 testFiles
)

Target "TestRefactoringProjects" (fun _ ->
    Seq.iter restoreAndTest refactoringProjects
)

Target "ReplaceStubWithExampleImplementation" (fun _ ->
    let replaceStubWithExampleImplementation project =
        let projectDir = directory project
        let stubFile = projectDir @@ filename project + "" |> changeExt ".cs"
        let exampleFile = projectDir @@ "Example.cs"
        
        CopyFile stubFile exampleFile   

    Seq.iter replaceStubWithExampleImplementation allProjects
)

Target "TestUsingExampleImplementation" (fun _ ->
    Seq.iter restoreAndTest allProjects
)

"Clean"
  ==> "CopyExercises"
  ==> "IgnoreExampleImplementation"
  ==> "BuildUsingStubImplementation"
  ==> "EnableAllTests"
  ==> "TestRefactoringProjects"
  ==> "ReplaceStubWithExampleImplementation"
  ==> "TestUsingExampleImplementation"

RunTargetOrDefault "TestUsingExampleImplementation"
