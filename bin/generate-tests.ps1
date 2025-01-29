<#
.SYNOPSIS
    Generate the tests for exercises
.DESCRIPTION
    Generate the tests for exercises that have a template.
    The tests are generated from canonical data.
.PARAMETER Exercise
    The slug of the exercise to generate the tests for (optional).
.EXAMPLE
    The example below will generate the tests for exercises with a template
    PS C:\> ./test.ps1
.EXAMPLE
    The example below will generate the tests for the specified exercise
    PS C:\> ./test.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

if ($Exercise) {
    dotnet run --project generators --exercise $Exercise
} else {
    dotnet run --project generators
}
