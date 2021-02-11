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

Invoke-CommandExecution "git submodule init"
Invoke-CommandExecution "git submodule update --remote"

exit $LastExitCode