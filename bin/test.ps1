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

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

function Prepare-Exercise($Path) {
    $files = Get-Content (Join-Path $Path ".meta" "config.json") -Raw | ConvertFrom-Json | Select-Object -ExpandProperty files

    foreach ($fileType in @("example", "exemplar")) {
        for (($i = 0); $i -lt $files.$fileType.length; $i++) {
            $exampleFile = Join-Path $Path $files.$fileType[$i]
            $solutionFile = Join-Path $Path $files.solution[$i]

            Copy-Item -Path $solutionFile -Destination "${solutionFile}.tmp"
            Copy-Item -Path $exampleFile -Destination $solutionFile
        }
    }

    foreach ($testFile in $files.test) {
        $testFile = Join-Path $Path $testFile
        Copy-Item -Path $testFile -Destination "${testFile}.tmp"
        (Get-Content $testFile) -replace "Skip = ""Remove this Skip property to run this test""", "" | Set-Content $testFile
    }
}

function Restore-Exercise($Path) {
    Get-ChildItem -Path $Path -Include "*.tmp" -Recurse | ForEach-Object {
        $tmpFile = $_.FullName
        $originalFile = ($tmpFile -replace "\.tmp$", "")
        Move-Item -Path $tmpFile -Destination $originalFile -Force
    }
}

function Process-Exercises($Exercises, [ScriptBlock]$Action) {
    foreach ($ExerciseType in @("practice", "concept")) {
        $Exercises.$ExerciseType | ForEach-Object {
            &$Action (Join-Path "exercises" $ExerciseType $_)
        }
    }
}

function Prepare-Exercises($Exercises) {
    Process-Exercises $Exercises {
        param($Path)
        Prepare-Exercise $Path
    }
}

function Restore-Exercises($Exercises) {
    Process-Exercises $Exercises {
        param($Path)
        Restore-Exercise $Path
    }
}

function Parse-Test-Dlls {
    Select-String -Path "msbuild.log" -Pattern " -> (.+)" -AllMatches
    | Select-Object -ExpandProperty Matches
    | ForEach-Object { $_.Groups[1].Value }
}

function Run-Tests($Path) {
    & dotnet restore --verbosity quiet --locked-mode $Path
    & dotnet build   --verbosity quiet --no-restore $Path /flp:v=minimal
    & dotnet vstest  --logger:"console;verbosity=quiet" --parallel $(Parse-Test-Dlls)
}

function Find-Exercise-Path($Exercise, $Exercises) {
    if ($Exercises.practice.Contains($Exercise)) {
        Join-Path "exercises" "practice" $Exercise
    }
    elseif ($Exercises.concept.Contains($Exercise)) {
        Join-Path "exercises" "concept" $Exercise
    } else {
        throw "Could not find exercise '${Exercise}'"
    }
}

function Test-Single-Exercise($Exercise, $Exercises) {
    $path = Find-Exercise-Path $Exercise $Exercises

    try {
        Prepare-Exercise $path
        Run-Tests $path
    } finally {
        Restore-Exercise $path
    }
}

function Test-All-Exercises($Exercises) {
    try {
        Prepare-Exercises $Exercises
        Run-Tests "exercises/Exercises.sln"
    } finally {
        Restore-Exercises $Exercises
    }
}

function Parse-Exercises {
    Get-Content .\config.json -Raw |
    ConvertFrom-Json |
    Select-Object -ExpandProperty exercises |
    ForEach-Object {
        @{
            concept  = $_.concept  | Select-Object -ExpandProperty slug | Sort-Object
            practice = $_.practice | Select-Object -ExpandProperty slug | Sort-Object
        }
    }
}

function Build-Generators {
    Write-Output "Build generators"
    & dotnet restore --verbosity quiet --locked-mode generators
    & dotnet build   --verbosity quiet --no-restore generators
}

function Test-Refactoring-Exercise-Default-Implementations {
    Write-Output "Testing refactoring exercises"
    Run-Tests (Join-Path "exercises" "Refactoring.sln")
}

function Test-Exercise-Example-Implementations($Exercise) {
    Write-Output "Testing example implementations"
    $exercises = Parse-Exercises

    if ($Exercise) {
        Test-Single-Exercise $Exercise $Exercises
    } else {
        Test-All-Exercises $Exercises
    }
}

if (!$Exercise) {
    Test-Refactoring-Exercise-Default-Implementations
    Build-Generators
}

Test-Exercise-Example-Implementations $Exercise
