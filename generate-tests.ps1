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

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

. ./shared.ps1

function Update-TestFilesForTrack {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Position = 0, Mandatory = $false)]
        [string]$Exercise
    )

    $generatorsProject = "./generators"
    $generatorsArgs = if ($Exercise) { @("--exercise", $Exercise) } else { @() }

    if ($PSCmdlet.ShouldProcess($generatorsProject, "execute")) {
        Write-Output "Updating tests"
        Invoke-CallScriptExitOnError { dotnet run --project $generatorsProject $generatorsArgs }
    }
}

Update-TestFilesForTrack $Exercise
