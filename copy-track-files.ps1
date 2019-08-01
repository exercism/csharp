<#
.SYNOPSIS
    Copy track files.
.DESCRIPTION
    Copy global, track-specific files that are applicable to each exercise.
.PARAMETER Exercise
    The slug of the exercise to be analyzed (optional).
.EXAMPLE
    The example below will copy the track-specific files to all exercises
    PS C:\> ./copy-track-files.ps1
.EXAMPLE
    The example below will copy the track-specific files to the "acronym" exercise
    PS C:\> ./copy-track-files.ps1 acronym
#>

param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

# Import shared functionality
. ./shared.ps1

$defaultEditorConfigSettings = Get-Content -Path ".editorconfig"

function Copy-Track-Files-For-Exercise ($ExerciseDirectory) {
    $exerciseName = (Get-Culture).TextInfo.ToTitleCase($ExerciseDirectory.Name).Replace("-", "")
    $editorConfigSettings = $defaultEditorConfigSettings.Replace( "[*.cs]", "[${exerciseName}.cs]")
    $exerciseEditorConfigPath = Join-Path $ExerciseDirectory.FullName ".editorconfig"

    Set-Content -Path $exerciseEditorConfigPath $editorConfigSettings
}

function Copy-Track-Files {
    Write-Output "Copying track files"

    $filter = if ($Exercise) { $($Exercise) } else { @() }
    Get-Childitem –Path "exercises" -Filter $filter -Directory | ForEach-Object {
        Copy-Track-Files-For-Exercise -ExerciseDirectory $_
    }
}

Copy-Track-Files

exit $LastExitCode