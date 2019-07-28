<#
.SYNOPSIS
    Update the canonical data.
.DESCRIPTION
    Update the canonical data to the latest version.
.EXAMPLE
    The example below will update the canonical data
    PS C:\> ./update-canonical-data.ps1
#>

git submodule init
git submodule update --remote

exit $LastExitCode