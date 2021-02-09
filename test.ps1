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

param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

# Import shared functionality
. ./shared.ps1

$buildDir = Join-Path $PSScriptRoot "build"
$practiceExercisesDir = Join-Path $buildDir "practice"
$conceptExercisesDir = Join-Path $buildDir "concept"
$sourceDir = Resolve-Path "exercises"

function Configlet-Lint {
    Write-Output "Linting config.json"
    Run-Command "./bin/fetch-configlet"
    Run-Command "./bin/configlet lint"
}

function Build-Generators { 
    Write-Output "Building generators"
    Run-Command "dotnet build ./generators"
}

function Clean {
    Write-Output "Cleaning previous build"
    Remove-Item -Recurse -Force $buildDir -ErrorAction Ignore
}

function Copy-Exercises {
    Write-Output "Copying exercises"
    Copy-Item $sourceDir -Destination $buildDir -Recurse
}

function Enable-All-Tests {
    Write-Output "Enabling all tests"
    Get-ChildItem -Path $buildDir -Include "*Tests.cs" -Recurse | ForEach-Object {
        (Get-Content $_.FullName) -replace "Skip = ""Remove this Skip property to run this test""", "" | Set-Content $_.FullName
    }
}

function Test-Refactoring-Projects {
    Write-Output "Testing refactoring projects"
    @("tree-building", "ledger", "markdown") | ForEach-Object { Run-Command "dotnet test $practiceExercisesDir/$_" }
}

function Replace-Stubs {
    Write-Output "Replacing concept exercise stubs with exemplar"
    Get-ChildItem -Path $conceptExercisesDir -Include "*.csproj" -Recurse | ForEach-Object {
        $stub = Join-Path $_.Directory ($_.BaseName + ".cs")
        $example = Join-Path $_.Directory ".meta" "Exemplar.cs"
    
        Move-Item -Path $example -Destination $stub -Force
    }

    Write-Output "Replacing practice exercise stubs with example"
    Get-ChildItem -Path $practiceExercisesDir -Include "*.csproj" -Recurse | ForEach-Object {
        $stub = Join-Path $_.Directory ($_.BaseName + ".cs")
        $example = Join-Path $_.Directory "Example.cs"
    
        Move-Item -Path $example -Destination $stub -Force
    }
}

function Test-Using-Example-Implementation {
    Write-Output "Running tests"

    if (-Not $Exercise) {
        Run-Command "dotnet test $buildDir/Exercises.sln"
    }
    elseif (Test-Path "$conceptExercisesDir/$exercise") {
        Run-Command "dotnet test $conceptExercisesDir/$exercise"
    }
    elseif (Test-Path "$practiceExercisesDir/$exercise") {
        Run-Command "dotnet test $practiceExercisesDir/$exercise"
    }
    else {
        throw "Could not find exercise '$exercise'"
    }
}

Configlet-Lint
Clean
Copy-Exercises
Enable-All-Tests

if (!$Exercise) {
    Build-Generators
    Test-Refactoring-Projects
}

Replace-Stubs
Test-Using-Example-Implementation

exit $LastExitCode