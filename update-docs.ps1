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
    [CmdletBinding(SupportsShouldProcess)]
    param ()

    if ($PSCmdlet.ShouldProcess($true)) {
        Write-Output "Updating canonical data"
        Invoke-CommandExecution "./update-canonical-data.ps1" 
    }
}

function Update-DocFile {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Position = 0, Mandatory = $false)]
        [string]$Exercise
    )

    if ($PSCmdlet.ShouldProcess($true)) {
        Write-Output "Updating docs"
        $configlet_args = if ($Exercise) { @("-o", $Exercise) } else { @() }
        Invoke-CommandExecution "./bin/fetch-configlet"
        Invoke-CommandExecution "./bin/configlet generate . -p problem-specifications $configlet_args"
    }
}

Update-Canonical-Data
Update-DocFile $Exercise

exit $LastExitCode