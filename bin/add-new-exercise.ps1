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
    PS C:\> ./add-new-exercise.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
    [Parameter(Mandatory = $true)][string]$Author,
    [Parameter()][int]$Difficulty = 1
)

$PSNativeCommandUseErrorActionPreference = $true

# Use fetch-configlet and configlet to create the exercise
$extension = if ($IsWindows) { ".exe" } else { "" }
$fetchConfiglet = Join-Path "bin" -ChildPath "fetch-configlet${extension}"
$configlet = Join-Path "bin" -ChildPath "configlet${extension}"
& $fetchConfiglet
& $configlet create --practice-exercise "${Exercise}" --difficulty "${Difficulty}" --author "${Author}"

# Create project
$exerciseName = (Get-Culture).TextInfo.ToTitleCase($Exercise).Replace("-", "")
$exerciseDir = Join-Path -Path "exercises" -ChildPath "practice" | Join-Path -ChildPath "${Exercise}"
$project = Join-Path -Path "${exerciseDir}" -ChildPath "${ExerciseName}.csproj"
& dotnet new xunit --force -lang "C#" --target-framework-override net8.0 -o "${exerciseDir}" -n "${ExerciseName}"
& dotnet sln (Join-Path "exercises" -ChildPath "Exercises.sln") add "${project}"
& dotnet remove "${project}" package "coverlet.collector"
& dotnet add "${project}" package "Exercism.Tests" --version "0.1.0-beta1"
& dotnet add "${project}" package "xunit.runner.visualstudio" --version "2.4.3"
& dotnet add "${project}" package "xunit" --version "2.4.1"
& dotnet add "${project}" package "Microsoft.NET.Test.Sdk" --version "16.8.3"

Remove-Item -Path (Join-Path "${exerciseDir}" -ChildPath "UnitTest1.cs")
Remove-Item -Path (Join-Path "${exerciseDir}" -ChildPath "GlobalUsings.cs")
(Get-Content -Path ".editorconfig") -Replace "\[\*\.cs\]", "[${exerciseName}.cs]" | Set-Content -Path (Join-Path "${exerciseDir}" -ChildPath ".editorconfig")

$generator = Join-Path "generators" -ChildPath "Exercises" | Join-Path -ChildPath "Generators" | Join-Path -ChildPath "${ExerciseName}.cs"
Set-Content -Path "${generator}" -Value @"
using System;

using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators;

internal class ${ExerciseName} : ExerciseGenerator
{
}
"@

& dotnet run --project "generators" --exercise "${Exercise}"
