<#
.SYNOPSIS
    Generate tests.
.DESCRIPTION
    Generate tests based on the latest canonical data.
.PARAMETER Exercise
    The slug of the exercise to be analyzed (optional).
.EXAMPLE
    The example below will regenerate all tests
    PS C:\> ./generate-tests.ps1
.EXAMPLE
    The example below will regenerate the tests for the "acronym" exercise
    PS C:\> ./generate-tests.ps1 acronym
#>

param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

./update-canonical-data.ps1

$args = if ($Exercise) { @("--exercise", $Exercise) } else { @() }
dotnet run --project ./generators $args