<#
.SYNOPSIS
    Update the exercises.
.DESCRIPTION
    Update the exercises' docs, metadata, and tests.
.PARAMETER Exercise
    The slug of the exercise to update (optional).
.EXAMPLE
    The example below will update all exercises
    PS C:\> ./update-exercises.ps1
.EXAMPLE
    The example below will update the "acronym" exercise
    PS C:\> ./update-exercises.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $false)][string]$Exercise,
    [Parameter()][switch]$RegenerateTests
)

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

& bin/fetch-configlet

if ($Exercise) {
    & configlet sync --docs --metadata --filepaths --update --yes --exercise $Exercise
    & dotnet run --project generators --exercise $Exercise
} else {
    & configlet sync --docs --metadata --filepaths --update --yes
    & dotnet run --project generators
}
