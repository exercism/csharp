$ErrorActionPreference = 'Stop'

# PowerShell does not check the return code of native commands.
# There is a pending proposal to support this: https://github.com/PowerShell/PowerShell-RFC/pull/88/files
function Run-Command ($Command, $NumRetries = 0) {
    <#
        .SYNOPSIS
            Run a native command.
        .PARAMETER Command
            The command to execute.
        .EXAMPLE
            The example below runs the "./bin/configlet hint ." command

            Run-Command "./bin/configlet hint ."
    #>

	for ($i = 0; $i -le $NumRetries; $i++) {
		Invoke-Expression $Command
	
		if ($Lastexitcode -eq 0) {
			return
		}
		
		Start-Sleep -Seconds 5
	}

    exit $Lastexitcode
}