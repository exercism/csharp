<#
.SYNOPSIS
    Add a new exercise.
.DESCRIPTION
    Add the files need to add a new exercise.
.PARAMETER Exercise
    The slug of the exercise to add.
.PARAMETER Topics
    The topics of the exercise (optional).
.PARAMETER Core
    Indicates if the exercise is a core exercise (optional).
.PARAMETER Difficulty
    The difficulty of the exercise on a scale from 1 to 10 (optional).
.PARAMETER UnlockedBy
    The slug of the exercise that unlocks exercise (optional).
.EXAMPLE
    The example below will add the "acronym" exercise
    PS C:\> ./add-new-exercise.ps1 acronym
.EXAMPLE
    The example below will add the "acronym" exercise as a core exercise
    PS C:\> ./add-new-exercise.ps1 acronym -Core
.EXAMPLE
    The example below will add the "acronym" exercise as a core exercise, with
    two topics, a specified difficulty and being unlocked by "two-fer"
    PS C:\> ./add-new-exercise.ps1 acronym -Core -Topics strings,optional -Difficulty 3 -UnlockedBy two-fer
#>

param (
    [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
    [Parameter()][string[]]$Topics = @(),
    [Parameter()][switch]$Core,
    [Parameter()][int]$Difficulty = 1,
    [Parameter()]$UnlockedBy
)

$exerciseName = (Get-Culture).TextInfo.ToTitleCase($Exercise).Replace("-", "")
$exercisesDir = Resolve-Path "exercises"
$exerciseDir = Join-Path $exercisesDir $Exercise

function Add-Project {
    $csProj = "$exerciseDir/$exerciseName.csproj"

    dotnet new xunit -lang "C#" -o $exerciseDir -n $exerciseName
    dotnet sln "$exercisesDir/Exercises.sln" add $csProj
    
    Remove-Item -Path "$exerciseDir/UnitTest1.cs"
    
    New-Item -ItemType File -Path "$exerciseDir/$exerciseName.cs"
    New-Item -ItemType File -Path "$exerciseDir/Example.cs"
    
    [xml]$proj = Get-Content $csProj
    $compilePropertyGroup = $proj.CreateElement("PropertyGroup");
    $compileElement = $proj.CreateElement("Compile");
    $removeAttribute = $proj.CreateAttribute("Remove");
    $removeAttribute.Value = "Example.cs";
    $compileElement.Attributes.Append($removeAttribute);
    $compilePropertyGroup.AppendChild($compileElement);
    $propertyGroup = $proj.Project.PropertyGroup
    $propertyGroup.ParentNode.InsertAfter($compilePropertyGroup, $propertyGroup)
    $proj.Save($csProj)
}

function Add-Generator {
    $generatorsDir = Resolve-Path "generators"
    $generatorsExercisesDir = Join-Path $generatorsDir "Exercises"
    $generatorsExerciseGeneratorsDir = Join-Path $generatorsExercisesDir "Generators"
    $generator = Join-Path $generatorsExerciseGeneratorsDir "$exerciseName.cs"
    $generatorClass = "namespace Exercism.CSharp.Exercises.Generators`n{`n    public class $exerciseName : GeneratorExercise`n    {`n    }`n}"
    
    Set-Content -Path $generator -Value $generatorClass
}

function Copy-Track-Files { ./copy-track-files.ps1 $Exercise }

function Update-Docs { ./update-docs.ps1 $Exercise }
function Update-Tests { ./generate-tests.ps1 $Exercise }

function Update-Config-Json {
    $configJson = Resolve-Path "config.json"

    $config = Get-Content $configJson | ConvertFrom-JSON
    $config.exercises += [pscustomobject]@{
        slug        = $Exercise;
        uuid        = [Guid]::NewGuid();
        core        = $Core.IsPresent;
        unlocked_by = $UnlockedBy;
        difficulty  = $Difficulty;
        topics      = $Topics;
    }
    
    ConvertTo-Json -InputObject $config -Depth 10 | Set-Content -Path $configJson
}

Add-Project
Add-Generator
Copy-Track-Files
Update-Docs
Update-Tests
Update-Config-Json

exit $LastExitCode