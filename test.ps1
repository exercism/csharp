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

$ErrorActionPreference = 'Stop'

$buildDir = Join-Path $PSScriptRoot "build"
$exercisesDir = Resolve-Path "exercises"

# By default, PowerShell does not check the return code
# of native commands (see https://github.com/PowerShell/PowerShell-RFC/pull/88/files)
function RunCommand ($command) {
    Invoke-Expression $command

    if ($Lastexitcode -ne 0) {
        exit $Lastexitcode 
    }
}

function ConfigletLint {
    Write-Output "Linting config.json"
    RunCommand "./bin/fetch-configlet"
    RunCommand "./bin/configlet lint ."
}

function BuildGenerators { 
    Write-Output "Building generators"
    RunCommand "dotnet build ./generators"
}
function Clean {
    Write-Output "Cleaning previous build"
    Remove-Item -Recurse -Force $buildDir -ErrorAction Ignore
}
function CopyExercises {
    Write-Output "Copying exercises"
    Copy-Item $exercisesDir -Destination $buildDir -Recurse
}

function EnableAllTests {
    Write-Output "Enabling all tests"
    Get-ChildItem -Path $buildDir -Include "*Test.cs" -Recurse | ForEach-Object {
        (Get-Content $_.FullName) -replace "Skip = ""Remove to run test""", "" | Set-Content $_.FullName
    }
}

function TestRefactoringProjects {
    Write-Output "Testing refactoring projects"
    @("tree-building", "ledger", "markdown") | ForEach-Object { RunCommand "dotnet test $buildDir/$_" }
}

function ReplaceStubsWithExample {
    Write-Output "Replacing stubs with example"
    Get-ChildItem -Path $buildDir -Include "*.csproj" -Recurse | ForEach-Object {
        $stub = Join-Path $_.Directory ($_.BaseName + ".cs")
        $example = Join-Path $_.Directory "Example.cs"
    
        Move-Item -Path $example -Destination $stub -Force
    }
}

function TestUsingExampleImplementation {
    Write-Output "Running tests"
    $testTarget = if ($Exercise) { "$buildDir/$Exercise" } else { "$buildDir/Exercises.sln" }
    RunCommand "dotnet test $testTarget"
}

ConfigletLint
Clean
CopyExercises
EnableAllTests

if (!$Exercise) {
    BuildGenerators
    TestRefactoringProjects
}

ReplaceStubsWithExample
TestUsingExampleImplementation

exit $LastExitCode