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


function Copy-TrackFilesForExercise ($ExerciseDirectory) {
    $exerciseName = (Get-Culture).TextInfo.ToTitleCase($ExerciseDirectory.Name).Replace("-", "")

    $defaultEditorConfigSettings = Get-Content -Path ".editorconfig"
    $editorConfigSettings = $defaultEditorConfigSettings.Replace( "[*.cs]", "[${exerciseName}.cs]")
    $exerciseEditorConfigPath = Join-Path $ExerciseDirectory.FullName ".editorconfig"

    Set-Content -Path $exerciseEditorConfigPath $editorConfigSettings
}

function Copy-TrackFilesForTrack {
    param (
        [Parameter(Position = 0, Mandatory = $false)]
        [string]$Exercise
    )

    Write-Output "Copying generic track files"

    $filter = if ($Exercise) { $($Exercise) } else { @() }
    Get-Childitem -Path "exercises\practice" -Filter $filter -Directory | ForEach-Object {
        Copy-TrackFilesForExercise -ExerciseDirectory $_
    }
    Get-Childitem -Path "exercises\concept" -Filter $filter -Directory | ForEach-Object {
        Copy-TrackFilesForExercise -ExerciseDirectory $_
    }
}

Copy-TrackFilesForTrack $Exercise

exit $LastExitCode
