$ErrorActionPreference = 'Stop'

# PowerShell does not check the return code of native commands.
# There is a pending proposal to support this:
# https://github.com/PowerShell/PowerShell-RFC/pull/88/files
# https://github.com/PowerShell/PowerShell-RFC/pull/261
function Invoke-CallScriptExitOnError ($ScriptBlock) {
    <#
        .SYNOPSIS
            Run a native command.
        .PARAMETER Command
            The command to execute.
        .EXAMPLE
            The example below runs the { ./bin/configlet lint } script block

            Invoke-CallScriptExitOnError { ./bin/configlet lint }
    #>

    & $ScriptBlock

    if ($Lastexitcode -ne 0) {
        exit $Lastexitcode
    }
}
