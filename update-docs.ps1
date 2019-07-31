<#
.SYNOPSIS
    Regenerate the docs.
.DESCRIPTION
    Regenerate the docs for all exercises based on the latest canonical data.
.PARAMETER Exercise
    The slug of the exercise to regenerate the doc for (optional).
.EXAMPLE
    The example below will regenerate all docs
    PS C:\> ./update-docs.ps1
.EXAMPLE
    The example below will regenerate the doc for the "acronym" exercise
    PS C:\> ./update-docs.ps1 acronym
#>

param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

# Import shared functionality
. ./shared.ps1

function Update-Canonical-Data {
    Write-Output "Updating canonical data"
    Run-Command "./update-canonical-data.ps1" 
}

function Update-Docs {
    Write-Output "Updating docs"
    $args = if ($Exercise) { @("-o", $Exercise) } else { @() }
    Run-Command "./bin/fetch-configlet"
    Run-Command "./bin/configlet generate . -p problem-specifications $args"
}

Update-Canonical-Data
Update-Docs

exit $LastExitCode