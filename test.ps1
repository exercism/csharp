<#
.SYNOPSIS
    Test the solution.
.DESCRIPTION
    Test the solution to verify correctness. This script verifies that:
    - The config.json file is correct
    - The generators project builds successfully
    - The example implementations pass the test suites
    - The refactoring projects stub files pass the test suites
.PARAMETER Exercise
    The slug of the exercise to verify (optional).
.EXAMPLE
    The example below will verify the full solution
    PS C:\> ./test.ps1
.EXAMPLE
    The example below will verify the "acronym" exercise
    PS C:\> ./test.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

# Import shared functionality
. ./shared.ps1


function Invoke-Configlet-Lint {
    Write-Output "Linting config.json"
    Invoke-CallScriptExitOnError { ./bin/fetch-configlet }
    Invoke-CallScriptExitOnError { ./bin/configlet lint }
}

function Invoke-Build-Generators { 
    Write-Output "Building generators"
    Invoke-CallScriptExitOnError { dotnet build ./generators }
}

function Clean($BuildDir) {
    Write-Output "Cleaning previous build"
    Remove-Item -Recurse -Force $BuildDir -ErrorAction Ignore
}

function Copy-Exercise($SourceDir, $BuildDir) {
    Write-Output "Copying exercises"
    Copy-Item $SourceDir -Destination $BuildDir -Recurse
}

function Enable-AllUnitTest($BuildDir) {
    Write-Output "Enabling all tests"
    Get-ChildItem -Path $BuildDir -Include "*Tests.cs" -Recurse | ForEach-Object {
        (Get-Content $_.FullName) -replace "Skip = ""Remove this Skip property to run this test""", "" | Set-Content $_.FullName
    }
}

function Test-Refactoring-Exercise($PracticeExercisesDir) {
    Write-Output "Testing refactoring projects"
    @("tree-building", "ledger", "markdown") | ForEach-Object {
        Invoke-CallScriptExitOnError { dotnet test "$practiceExercisesDir/$_" }
    }
}

function Set-ExampleImplementation {
    [CmdletBinding(SupportsShouldProcess)]
    param($ExercisesDir, $ReplaceFileName)

    if ($PSCmdlet.ShouldProcess("Exercise $ReplaceFileName", "replace solution with example")) {
        Get-ChildItem -Path $ExercisesDir -Include "*.csproj" -Recurse | ForEach-Object {
            $stub = Join-Path -Path $_.Directory ($_.BaseName + ".cs")
            $example = Join-Path -Path $_.Directory ".meta" $ReplaceFileName
        
            Move-Item -Path $example -Destination $stub -Force
        }
    }
}

function Use-ExampleImplementation {
    [CmdletBinding(SupportsShouldProcess)]
    param($ConceptExercisesDir, $PracticeExercisesDir)

    if ($PSCmdlet.ShouldProcess("Exercises directory", "replace all solutions with corresponding examples")) {
        Write-Output "Replacing concept exercise stubs with exemplar"
        Set-ExampleImplementation $ConceptExercisesDir "Exemplar.cs"

        Write-Output "Replacing practice exercise stubs with example"
        Set-ExampleImplementation $PracticeExercisesDir "Example.cs"
    }
}

function Test-ExerciseImplementation($Exercise, $BuildDir, $ConceptExercisesDir, $PracticeExercisesDir) {
    Write-Output "Running tests"

    if (-Not $Exercise) {
        Invoke-CallScriptExitOnError { dotnet test "$BuildDir/Exercises.sln" }
    }
    elseif (Test-Path "$ConceptExercisesDir/$Exercise") {
        Invoke-CallScriptExitOnError { dotnet test "$ConceptExercisesDir/$Exercise" }
    }
    elseif (Test-Path "$PracticeExercisesDir/$Exercise") {
        Invoke-CallScriptExitOnError { dotnet test "$PracticeExercisesDir/$Exercise" }
    }
    else {
        throw "Could not find exercise '$Exercise'"
    }
}


$buildDir = Join-Path $PSScriptRoot "build"
$practiceExercisesDir = Join-Path $buildDir "practice"
$conceptExercisesDir = Join-Path $buildDir "concept"
$sourceDir = Resolve-Path "exercises"


Invoke-Configlet-Lint
Clean $buildDir
Copy-Exercise $sourceDir $buildDir
Enable-AllUnitTest $buildDir

if (!$Exercise) {
    Invoke-Build-Generators
    Test-Refactoring-Exercise $practiceExercisesDir
}

Use-ExampleImplementation $conceptExercisesDir $practiceExercisesDir
Test-ExerciseImplementation -Exercise $Exercise -BuildDir $buildDir -ConceptExercisesDir $conceptExercisesDir -PracticeExercisesDir $practiceExercisesDir

exit $LastExitCode
