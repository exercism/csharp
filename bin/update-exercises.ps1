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
.EXAMPLE
    The example below will update the "acronym" exercise and regenerate the tests
    PS C:\> ./update-exercises.ps1 acronym -RegenerateTests
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $false)][string]$Exercise,
    [Parameter()][switch]$RegenerateTests
)

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

# Use fetch-configlet and configlet to create the exercise
$extension = if ($IsWindows) { ".exe" } else { "" }
$fetchConfiglet = Join-Path "bin" -ChildPath "fetch-configlet${extension}"
$configlet = Join-Path "bin" -ChildPath "configlet${extension}"

$syncArgs = @("sync", "--docs", "--metadata", "--filepaths", "--update", "--yes")
$generatorArgs = @("run", "--project", "generators")

if ($Exercise) {
    $syncArgs += "--exercise ${Exercise}"
    $generatorArgs += "--exercise ${Exercise}"
}

Start-Process -FilePath $fetchConfiglet -Wait
Start-Process -FilePath $configlet -ArgumentList $syncArgs -Wait
Start-Process "dotnet" -ArgumentList $generatorArgs -Wait
