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

Run-Command "git submodule init"
Run-Command "git submodule update --remote"

exit $LastExitCode