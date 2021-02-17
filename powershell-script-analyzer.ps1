<#
.SYNOPSIS
    Test the PowerShell scripts in the folders.
.DESCRIPTION
    Test the PowerShell strict correctness with https://github.com/PowerShell/PSScriptAnalyzer.
.EXAMPLE
    The example below will verify all the scripts in the repository
    PS C:\> ./powershell-script-analyzer.ps1
#>

# Install PSScriptAnalyzer only if not already available.
if (!(Get-Module -ListAvailable -Name PSScriptAnalyzer)) {
    Set-PSRepository -Name PSGallery -InstallationPolicy Trusted
    Install-Module PSScriptAnalyzer -Scope CurrentUser -Repository PSGallery -Force
}

Import-Module PSScriptAnalyzer
$PSSAResults = Invoke-ScriptAnalyzer -Path . -Recurse
$DETAILS = ($PSSAResults | ForEach-Object { "{0,-11} [{1,-3}, {2,-3}] {3,-50} {4,-35} - {5}" -f $_.Severity, $_.Line, $_.Column, $_.ScriptName, $_.RuleName, $_.Message } | Out-String -Width 88).Trim()
$DETAILS
$SUMMARY = ($PSSAResults | Group-Object -Property Severity -NoElement | Foreach-Object { "$($_.Count) $($_.Name)" }) -join ", "
$SUMMARY

exit $SUMMARY.Length
