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
    [Parameter(Position = 1, Mandatory = $true)][string]$Author,
    [Parameter(Position = 2)][int]$Difficulty = 1
)

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

# Use configlet to create the exercise
& bin/fetch-configlet
& bin/configlet create --practice-exercise $Exercise --difficulty $Difficulty --author $Author

# Create project
$exerciseName = (Get-Culture).TextInfo.ToTitleCase($Exercise).Replace("-", "")
$exerciseDir = "exercises/practice/${Exercise}"
$projectFile = "${exerciseDir}/${ExerciseName}.csproj"
& dotnet new install xunit.v3.templates
& dotnet new xunit3 --force --framework net10.0 --output $exerciseDir --name $ExerciseName
& dotnet sln exercises/Exercises.slnx add --solution-folder "/practice/" $projectFile
& dotnet add $projectFile package Exercism.Tests.xunit.v3 --version 0.1.0-beta1
& dotnet remove $projectFile package xunit.v3.mtp-v2
& dotnet add $projectFile package Exercism.Tests.xunit.v3 --version 0.1.0-beta1
& dotnet add $projectFile package xunit.runner.visualstudio --version 3.1.5
& dotnet add $projectFile package xunit.v3 --version 3.2.2
& dotnet add $projectFile package Microsoft.NET.Test.Sdk --version 18.3.0

# Remove and update files
Remove-Item -Path "global.json"
Remove-Item -Path "${exerciseDir}/xunit.runner.json"
Remove-Item -Path "${exerciseDir}/UnitTest1.cs"
(Get-Content -Path ".editorconfig") -Replace "\[\*\.cs\]", "[${exerciseName}.cs]" | Set-Content -Path "${exerciseDir}/.editorconfig"

$project = [xml]::new()
$project.PreserveWhitespace = $true
$project.Load($projectFile)

$restorePackagesWithLockFileElement = $project.CreateElement("RestorePackagesWithLockFile");
$restorePackagesWithLockFileElement.InnerText = "true"
$project.Project.PropertyGroup.AppendChild($project.CreateTextNode("  "))
$project.Project.PropertyGroup.AppendChild($restorePackagesWithLockFileElement)
$project.Project.PropertyGroup.AppendChild($project.CreateTextNode("`n  "))
$project.Project.PropertyGroup.SelectSingleNode("//RootNamespace").InnerText = "Exercism"
$project.Project.RemoveChild($project.Project.ItemGroup[0])

$project.Save($projectFile)

# Create new generator template and run generator (this will update the tests file)
bin/update-tests.ps1 -Exercise $Exercise -New -SyncProbSpecs

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
