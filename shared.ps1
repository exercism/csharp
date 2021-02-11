$ErrorActionPreference = 'Stop'

# PowerShell does not check the return code of native commands.
# There is a pending proposal to support this:
# https://github.com/PowerShell/PowerShell-RFC/pull/88/files
# https://github.com/PowerShell/PowerShell-RFC/pull/261
function Invoke-CommandExecution ($Command) {
    <#
        .SYNOPSIS
            Run a native command.
        .PARAMETER Command
            The command to execute.
        .EXAMPLE
            The example below runs the "./bin/configlet hint ." command

            Invoke-CommandExecution "./bin/configlet hint ."
    #>

    Invoke-Expression -Command $Command

    if ($Lastexitcode -ne 0) {
        exit $Lastexitcode
    }
}