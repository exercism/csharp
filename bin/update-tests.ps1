<#
.SYNOPSIS
    Generate the tests for exercises
.DESCRIPTION
    Generate the tests for exercises that have a template.
    The tests are generated from canonical data.
.PARAMETER Exercise
    The slug of the exercise to generate the tests for (optional).
.PARAMETER CreateNew
    Create a new test generator file before generating the tests (switch).
.PARAMETER SyncProbSpecs
    Sync the prob-specs repo used (switch).
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
    [string]$Exercise,

    [Parameter()]
    [switch]$New,

    [Parameter()]
    [switch]$SyncProbSpecs
)

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

function Run-Command($verb, $exercise = $null) {
    if ($exercise) {
        & dotnet run --project generators $verb --exercise $exercise
    } else {
        & dotnet run --project generators $verb
    }
}

if ($SyncProbSpecs.IsPresent) {
    Run-Command sync
}

if ($New.IsPresent) {
    Run-Command new $Exercise
}

Run-Command update $Exercise
