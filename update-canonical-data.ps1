<#
.SYNOPSIS
    Update the canonical data.
.DESCRIPTION
    Update the canonical data to the latest version.
.EXAMPLE
    The example below will update the canonical data
    PS C:\> ./update-canonical-data.ps1
#>

# Import shared functionality
. ./shared.ps1

function Update-CanonicalData {
    [CmdletBinding(SupportsShouldProcess)]
    param()

    if ($PSCmdlet.ShouldProcess("all git submodules, including problem-specifications", "git init and update")) {
        Write-Output "Updating canonical data"
        Invoke-ExpressionExitOnError "git submodule init"
        Invoke-ExpressionExitOnError "git submodule update --remote"
    }
}

exit $LastExitCode
