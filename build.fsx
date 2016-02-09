// Include Fake library
#r "tools/FAKE/tools/FakeLib.dll"

open Fake
open Fake.CscHelper
open Fake.Testing.NUnit3

// Properties
let buildDir = getBuildParamOrDefault "buildDir" "./build/"
let sourceDir = "./exercises/"
let testDll = buildDir @@ "Tests.dll"
let nunitFrameworkDll = "tools/NUnit/lib/net45/nunit.framework.dll"

let sourceFiles() = !! (buildDir @@ "./**/*.cs") |> List.ofSeq
  
// Targets
Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "CopySource" (fun _ ->
    CopyDir buildDir sourceDir allFiles
)

Target "ModifySource" (fun _ ->
    sourceFiles()
    |> ReplaceInFiles [("[Ignore(\"Remove to run test\")]", ""); ("; Ignore", ""); (", Ignore = \"Remove to run test case\"", "")]
)

Target "Build" (fun _ ->
  sourceFiles()
  |> List.ofSeq
  |> Csc (fun p ->
           { p with Output = testDll
                    References = [nunitFrameworkDll]
                    Target = Library })
)

Target "Test" (fun _ ->
    Copy buildDir [nunitFrameworkDll]
    
    [testDll]
    |> NUnit3 (fun p -> 
        { p with
            ShadowCopy = false })
)

Target "Default" (fun _ -> ())

// Dependencies
"Clean"
    ==> "CopySource"
    ==> "ModifySource"    
    ==> "Build"    
    ==> "Test"
    ==> "Default"
  
RunTargetOrDefault "Default"