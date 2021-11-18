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

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
    [Parameter()][string[]]$Topics = @(),
    [Parameter()][switch]$Core,
    [Parameter()][int]$Difficulty = 1,
    [Parameter()]$UnlockedBy
)

# Import shared functionality
. ./shared.ps1

function Add-Project {
    param (
        [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
        [Parameter(Position = 1, Mandatory = $true)][string]$ExerciseName
    )

    Write-Output "Adding project"

    # TODO We need to support concept exercises
    $exercisesDir = Resolve-Path "exercises"
    $exerciseDir = Join-Path -Path $exercisesDir "practice" $Exercise

    $csProj = "$exerciseDir/$ExerciseName.csproj"

    Invoke-CallScriptExitOnError { dotnet new xunit -lang "C#" --target-framework-override net6.0 -o $exerciseDir -n $ExerciseName }
    Invoke-CallScriptExitOnError { dotnet sln "$exercisesDir/Exercises.sln" add $csProj }

    Remove-Item -Path "$exerciseDir/UnitTest1.cs"

    New-Item -ItemType File -Path "$exerciseDir/$ExerciseName.cs"
    New-Item -ItemType Directory -Path "$exerciseDir/.meta"
    New-Item -ItemType File -Path "$exerciseDir/.meta/Example.cs"

    [xml]$proj = Get-Content $csProj
    $propertyGroup = $proj.Project.PropertyGroup

    $nugetItemGroup = $proj.Project.ItemGroup;
    $nugetItemGroup.RemoveAll();
    $nugetList = @(@{nuget = "Microsoft.NET.Test.Sdk"; Version = "16.8.3" }, @{nuget = "xunit"; Version = "2.4.1" }, @{nuget = "xunit.runner.visualstudio"; version = "2.4.3" })
    $nugetList | ForEach-Object {
        $packageElement = $proj.CreateElement("PackageReference");
        $includeAttribute = $proj.CreateAttribute("Include");
        $includeAttribute.Value = $_.nuget;
        $packageElement.Attributes.Append($includeAttribute);
        $versionAttribute = $proj.CreateAttribute("Version");
        $versionAttribute.Value = $_.version;
        $packageElement.Attributes.Append($versionAttribute);
        $nugetItemGroup.AppendChild($packageElement);
    }

    $compileItemGroup = $proj.CreateElement("ItemGroup");
    $compileElement = $proj.CreateElement("Compile");
    $removeAttribute = $proj.CreateAttribute("Remove");
    $removeAttribute.Value = ".meta/Example.cs";
    $compileElement.Attributes.Append($removeAttribute);
    $compileItemGroup.AppendChild($compileElement);
    $propertyGroup.ParentNode.InsertAfter($compileItemGroup, $propertyGroup);

    $proj.Save($csProj);
}

function Add-GeneratorClass {
    param (
        [Parameter(Position = 0, Mandatory = $true)][string]$ExerciseName
    )

    Write-Output "Adding generator"

    $generatorsDir = Resolve-Path "generators"
    $generatorsExercisesDir = Join-Path $generatorsDir "Exercises"
    $generatorsExerciseGeneratorsDir = Join-Path $generatorsExercisesDir "Generators"
    $generator = Join-Path $generatorsExerciseGeneratorsDir "$ExerciseName.cs"
    $generatorClass = "namespace Exercism.CSharp.Exercises.Generators`n{`n    public class $ExerciseName : GeneratorExercise`n    {`n    }`n}"

    Set-Content -Path $generator -Value $generatorClass
}

function Copy-TrackFilesForExercise {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Position = 0, Mandatory = $true)][string]$Exercise
    )

    if ($PSCmdlet.ShouldProcess("exercise $Exercise", "copy generic track files")) {
        Write-Output "Copying track files"
        ./copy-track-files.ps1 $Exercise
    }
}

function Update-Readme {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Position = 0, Mandatory = $true)][string]$Exercise
    )

    if ($PSCmdlet.ShouldProcess("exercise $Exercise", "update Readme files")) {
        Write-Output "Updating README"
        ./update-docs.ps1 $Exercise
    }
}

function Update-TestSuite {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Position = 0, Mandatory = $true)][string]$Exercise
    )

    if ($PSCmdlet.ShouldProcess("exercise $Exercise", "generate new tests")) {
        Write-Output "Updating test suite"
        ./generate-tests.ps1 $Exercise
    }
}

function Update-ConfigJson {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Mandatory = $true, Position = 0)][string]$Exercise,
        [Parameter()][string[]]$Topics = @(),
        [Parameter()][switch]$Core,
        [Parameter()][int]$Difficulty = 1,
        [Parameter()]$UnlockedBy
    )

    $configJson = Resolve-Path "config.json"
    $prerequisites = @()
    if ($UnlockedBy) { $prerequisites += $UnlockedBy }

    # TODO We need to support the creation of a concept exercise with the new config.json
    $config = Get-Content $configJson | ConvertFrom-JSON
    $config.exercises.practice += [pscustomobject]@{
        slug          = $Exercise;
        uuid          = [Guid]::NewGuid();
        core          = $Core.IsPresent;
        practices     = @($Exercise);
        prerequisites = $prerequisites;
        difficulty    = $Difficulty;
        topics        = $Topics;
    }

    if ($PSCmdlet.ShouldProcess("config.json", "add new file")) {
        Write-Output "Updating config.json"
        ConvertTo-Json -InputObject $config -Depth 10 | Set-Content -Path $configJson
    }

    Invoke-CallScriptExitOnError { ./bin/fetch-configlet }
    Invoke-CallScriptExitOnError { ./bin/configlet fmt . }
}

$exerciseName = (Get-Culture).TextInfo.ToTitleCase($Exercise).Replace("-", "")

Add-Project $Exercise $exerciseName
Add-GeneratorClass $exerciseName
Copy-TrackFilesForExercise $Exercise
Update-Readme $Exercise
Update-TestSuite $Exercise
Update-ConfigJson $Exercise -Topics $Topics -Core $Core -Difficulty $Difficulty -UnlockedBy $UnlockedBy

exit $LastExitCode
