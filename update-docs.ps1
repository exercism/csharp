<#
.SYNOPSIS
    Regenerate the docs.
.DESCRIPTION
    Regenerate the docs for all exercises based on the latest canonical data.
.PARAMETER Exercise
    The slug of the exercise to regenerate the docs for (optional).
.EXAMPLE
    The example below will regenerate all docs
    PS C:\> ./update-docs.ps1
.EXAMPLE
    The example below will regenerate the tests for the "acronym" exercise
    PS C:\> ./update-docs.ps1 acronym
#>

param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

./update-canonical-data.ps1

./bin/fetch-configlet

$args = if ($Exercise) { @("-o", $Exercise) } else { @() }
./bin/configlet generate . -p problem-specifications $args

exit $LastExitCode