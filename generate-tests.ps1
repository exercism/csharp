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

param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)


# Import shared functionality
. ./shared.ps1

function Update-Canonical-Data {
    [CmdletBinding(SupportsShouldProcess)]
    param()

    if ($PSCmdlet.ShouldProcess($true)) {
        Write-Output "Updating canonical data"
        Invoke-CommandExecution "./update-canonical-data.ps1" 
    }
}

function Update-TestFile {
    [CmdletBinding(SupportsShouldProcess)]
    param (
        [Parameter(Position = 0, Mandatory = $false)]
        [string]$Exercise
    )

    $generators_exec = "./generators"
    $generators_args = if ($Exercise) { @("--exercise", $Exercise) } else { @() }

    
    if ($PSCmdlet.ShouldProcess($generators_exec)) {
        Write-Output "Updating tests"
        Invoke-CommandExecution "dotnet run --project $generators_exec $generators_args"
    }
}

Update-Canonical-Data
Update-TestFile $Exercise