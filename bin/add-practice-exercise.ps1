<#
.SYNOPSIS
    Add a new exercise.
.DESCRIPTION
    Add the files need to add a new exercise.
.PARAMETER Exercise
    The slug of the exercise to add.
.PARAMETER Author
    The author of the exercise.
.PARAMETER Difficulty
    The difficulty of the exercise on a scale from 1 to 10 (optional, default: 1).
.EXAMPLE
    The example below will add the "acronym" exercise
    PS C:\> ./bin/add-practice-exercise.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
    [Parameter(Mandatory = $true)][string]$Author,
    [Parameter()][int]$Difficulty = 1
)

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

# Use configlet to create the exercise
& bin/fetch-configlet
& bin/configlet create --practice-exercise $Exercise --difficulty $Difficulty --author $Author

# Create project
$exerciseName = (Get-Culture).TextInfo.ToTitleCase($Exercise).Replace("-", "")
$exerciseDir = "exercises/practice/${Exercise}"
$project = "${exerciseDir}/${ExerciseName}.csproj"
& dotnet new xunit --force -lang "C#" --target-framework-override net8.0 -o $exerciseDir -n $ExerciseName
& dotnet sln exercises/Exercises.sln add $project

# Update project packages
& dotnet remove $project package coverlet.collector
& dotnet add $project package Exercism.Tests --version 0.1.0-beta1
& dotnet add $project package xunit.runner.visualstudio --version 2.4.3
& dotnet add $project package xunit --version 2.4.1
& dotnet add $project package Microsoft.NET.Test.Sdk --version 16.8.3

# Remove and update files
Remove-Item -Path "${exerciseDir}/UnitTest1.cs"
(Get-Content -Path ".editorconfig") -Replace "\[\*\.cs\]", "[${exerciseName}.cs]" | Set-Content -Path "${exerciseDir}/.editorconfig"

# Add and run generator (this will update the tests file)
$generator = "generators/Exercises/Generators/${ExerciseName}.cs"
Add-Content -Path $generator -Value @"
using System;

using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators;

internal class ${exerciseName} : ExerciseGenerator
{
}
"@
& dotnet run --project generators --exercise $Exercise

# Output the next steps
$files = Get-Content "exercises/practice/${Exercise}/.meta/config.json" | ConvertFrom-Json | Select-Object -ExpandProperty files
Write-Output @"
Your next steps are:
- Check the test suite in $($files.test | Join-String -Separator ",")
  - If the tests need changes, update the '${exerciseName}' class in the '${generator}' file
    and then run: 'dotnet run --project generators --exercise ${Exercise}'
- Any test cases you don't implement, mark them in 'exercises/practice/${slug}/.meta/tests.toml' with "include = false"
- Create the example solution in $($files.example | Join-String -Separator ",")
- Verify the example solution passes the tests by running 'bin/verify-exercises ${slug}'
- Create the stub solution in $($files.solution | Join-String -Separator ",")
- Update the 'difficulty' value for the exercise's entry in the 'config.json' file in the repo's root
- Validate CI using 'bin/configlet lint' and 'bin/configlet fmt'
"@
