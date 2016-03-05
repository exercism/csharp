// Include Fake library
#r "tools/FAKE/tools/FakeLib.dll"

open Fake
open Fake.CscHelper
open Fake.Testing.NUnit3

// Properties
let sourceDir = "./exercises/"
let buildDir = getBuildParamOrDefault "buildDir" "./build/"
let buildExampleDir = buildDir @@ "example"
let buildTestDir = buildDir @@ "test"
let exampleDll = buildExampleDir @@ "example.dll"
let testDll = buildTestDir @@ "test.dll"
let nunitFrameworkDll = "tools/NUnit/lib/net45/nunit.framework.dll"

let exampleSourceFiles() = !! (buildExampleDir @@ "./**/*.cs") |> List.ofSeq
let testSourceFiles() = !! (buildTestDir @@ "./**/*.cs") |> List.ofSeq

let compile output files =
    files
    |> Csc (fun p ->
             { p with Output = output
                      References = [nunitFrameworkDll]
                      Target = Library })

// Targets
Target "CleanExamples" (fun _ -> CleanDir buildExampleDir)
Target "CleanTests"    (fun _ -> CleanDir buildTestDir)

Target "CopyExamples" (fun _ -> CopyDir buildExampleDir sourceDir allFiles)
Target "CopyTests"    (fun _ -> CopyDir buildTestDir sourceDir allFiles)

Target "PrepareTests" (fun _ ->
    testSourceFiles()
    |> ReplaceInFiles [("[Ignore(\"Remove to run test\")]", ""); (", Ignore = \"Remove to run test case\"", "")]
)

Target "CompileExamples" (fun _ -> exampleSourceFiles() |> compile exampleDll)
Target "CompileTests"    (fun _ -> testSourceFiles() |> compile testDll)

Target "Test" (fun _ ->
    Copy buildTestDir [nunitFrameworkDll]
    
    [testDll]
    |> NUnit3 (fun p -> 
        { p with
            ShadowCopy = false })
)

Target "Build" (fun _ -> ())
Target "Default" (fun _ -> ())
  
"CleanExamples"
    ==> "CopyExamples"  
    ==> "CompileExamples"
    ==> "Build"

"CleanTests"
    ==> "CopyTests"
    ==> "PrepareTests" 
    ==> "CompileTests"  
    ==> "Test"
  
"Build" ==> "Default"
"Test" ==> "Default"
  
RunTargetOrDefault "Default"