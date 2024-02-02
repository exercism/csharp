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

function Enable-All-UnitTests($BuildDir) {
    Write-Output "Enabling all tests"
    Get-ChildItem -Path $BuildDir -Include "*Tests.cs" -Recurse | ForEach-Object {
        (Get-Content $_.FullName) -replace "Skip = ""Remove this Skip property to run this test""", "" | Set-Content $_.FullName
    }
}

function Test-Refactoring-Projects($PracticeExercisesDir) {
    Write-Output "Testing refactoring projects"
    @("tree-building", "ledger", "markdown") | ForEach-Object {
        Invoke-Tests -Path "$PracticeExercisesDir/$_"
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

function Test-ExerciseImplementation($Exercise, $BuildDir, $ConceptExercisesDir, $PracticeExercisesDir, $IsCI) {
    Write-Output "Running tests"

    if (-Not $Exercise) {
        Invoke-Tests -Path $BuildDir -IsCI $IsCI
    }
    elseif (Test-Path "$ConceptExercisesDir/$Exercise") {
        Invoke-Tests -Path "$ConceptExercisesDir/$Exercise" -IsCI $IsCI
    }
    elseif (Test-Path "$PracticeExercisesDir/$Exercise") {
        Invoke-Tests -Path "$PracticeExercisesDir/$Exercise" -IsCI $IsCI
    }
    else {
        throw "Could not find exercise '$Exercise'"
    }
}

function Invoke-Tests($Path, $IsCI) {
    if ($IsCI) {
        Get-ChildItem -Path $Path -Include "*.csproj" -Recurse | ForEach-Object {
            Invoke-CallScriptExitOnError { dotnet add $_.FullName package JunitXml.TestLogger -n -v 3.0.134 }
        }
        Invoke-CallScriptExitOnError { dotnet test $Path --logger "junit;LogFilePath=results/test.xml" }
    }
    else {
        Invoke-CallScriptExitOnError { dotnet test "$Path" }
    }
}


$buildDir = Join-Path $PSScriptRoot "build"
$practiceExercisesDir = Join-Path $buildDir "practice"
$conceptExercisesDir = Join-Path $buildDir "concept"
$sourceDir = Resolve-Path "exercises"
$isCi = [System.Convert]::ToBoolean($env:CI)

Clean $buildDir
Copy-Exercise $sourceDir $buildDir
Enable-All-UnitTests $buildDir

if (!$Exercise) {
    Invoke-Build-Generators
    Test-Refactoring-Projects $practiceExercisesDir
}

Use-ExampleImplementation $conceptExercisesDir $practiceExercisesDir
Test-ExerciseImplementation -Exercise $Exercise -BuildDir $buildDir -ConceptExercisesDir $conceptExercisesDir -PracticeExercisesDir $practiceExercisesDir -IsCI $isCi

exit $LastExitCode
