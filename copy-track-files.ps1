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

$defaultEditorConfigSettings = Get-Content -Path ".editorconfig"
$filter = if ($Exercise) { $($Exercise) } else { @() }

Get-Childitem –Path "exercises" -Filter $filter -Directory | ForEach-Object {
    $exerciseName = (Get-Culture).TextInfo.ToTitleCase($_.Name).Replace("-", "")
    $editorConfigSettings = $defaultEditorConfigSettings.Replace( "[*.cs]", "[${exerciseName}.cs]")
    $exerciseEditorConfigPath = Join-Path $_.FullName ".editorconfig"

    Set-Content -Path $exerciseEditorConfigPath $editorConfigSettings
}

exit $LastExitCode