#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.DotNetCli

let buildDir = "./build/"
let sourceDir = "./exercises/"
let projects = !! (buildDir @@ "*/*.csproj")
let tests = !! (buildDir @@ "**/*Test.cs")

let restore project = DotNetCli.Restore (fun p -> 
    { p with NoCache = true
             Project = project })

let build project = DotNetCli.Build (fun p ->
    { p with Project = project })

let test project = DotNetCli.Test (fun p -> 
    { p with Project = project })

let restoreAndBuild project = 
    restore project
    build project    

let restoreAndTest project =    
    restore project
    test project

Target "Clean" (fun _ -> 
    CleanDirs [buildDir]
)

Target "Copy" (fun _ -> 
    CopyDir buildDir sourceDir allFiles
)

Target "Test" (fun _ ->
    let ignorePattern = "Skip\s*=\s*\"Remove to run test\""
    RegexReplaceInFilesWithEncoding ignorePattern "" System.Text.Encoding.UTF8 tests
    
    Seq.iter restoreAndTest projects
)

"Clean"
  ==> "Copy"
  ==> "Test"

RunTargetOrDefault "Test"