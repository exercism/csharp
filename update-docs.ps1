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

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

# Import shared functionality
. ./shared.ps1

function Update-Documentation {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Position = 0, Mandatory = $false)]
        [string]$Exercise
    )

    if ($PSCmdlet.ShouldProcess((& { If ($Exercise) { $Exercise } Else { "All Exercises" } }), "fetch configlet and pull specifications")) {
        Write-Output "Updating docs"
        Invoke-CallScriptExitOnError { ./bin/fetch-configlet }

        $configletArgs = if ($Exercise) { @("-e", $Exercise) } else { @() }
        Invoke-CallScriptExitOnError { ./bin/configlet sync --docs --update --yes $configletArgs }
    }
}

Update-Documentation -Exercise $Exercise

exit $LastExitCode
