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

function Update-CanonicalData {
    [CmdletBinding(SupportsShouldProcess)]
    param ()

    if ($PSCmdlet.ShouldProcess("all git submodules, including problem-specifications", "git init and update")) {
        Write-Output "Updating canonical data"
        Invoke-CommandExecution "./update-canonical-data.ps1" 
    }
}

function Update-DocsFolder {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Position = 0, Mandatory = $false)]
        [string]$Exercise
    )

    if ($PSCmdlet.ShouldProcess((& { If ($Exercise) { $Exercise } Else { "All Exercises" } }), "fetch configlet and pull specifications")) {
        Write-Output "Updating docs"
        Invoke-CommandExecution "./bin/fetch-configlet"

        $configletArgs = if ($Exercise) { @("-e", $Exercise) } else { @() }
        Invoke-CommandExecution "./bin/configlet sync -p problem-specifications -o $configletArgs"
    }
}

Update-CanonicalData
Update-DocsFolder $Exercise

exit $LastExitCode
