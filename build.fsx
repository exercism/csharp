// Include Fake library
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Testing.NUnit3

// Directories
let buildDir  = "./build/"
let sourceDir  = "./exercises/"

// Files
let solutionFile = buildDir @@ "/exercises.csproj"
let compiledOutput = buildDir @@ "xcsharp.dll"

// Targets
Target "PrepareUnchanged" (fun _ -> 
    CleanDirs [buildDir]
    CopyDir buildDir sourceDir allFiles
)

Target "BuildUnchanged" (fun _ ->
    MSBuildRelease buildDir "Build" [solutionFile]
    |> Log "Build unchanged output: "
)

Target "PrepareTests" (fun _ ->
    CleanDirs [buildDir]
    CopyDir buildDir sourceDir allFiles

    let ignorePattern = "(\[Ignore\(\"Remove to run test\"\)]|, Ignore = \"Remove to run test case\")"

    !! (buildDir @@ "**/*Test.cs")
    |> RegexReplaceInFilesWithEncoding ignorePattern "" System.Text.Encoding.UTF8
)

Target "BuildTests" (fun _ ->
    MSBuildRelease buildDir "Build" [solutionFile]
    |> Log "Build tests output: "
)

Target "Test" (fun _ ->
    if getEnvironmentVarAsBool "APPVEYOR" then
        [compiledOutput]
        |> NUnit3 (fun p -> { p with 
                                ShadowCopy = false
                                ToolPath = "nunit3-console.exe" })
    else
        [compiledOutput]
        |> NUnit3 (fun p -> { p with ShadowCopy = false })
)

// Build order
"PrepareUnchanged"
  ==> "BuildUnchanged"
  ==> "PrepareTests"
  ==> "BuildTests"    
  ==> "Test"

// start build
RunTargetOrDefault "Test"