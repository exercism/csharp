if (!(Get-Module -ListAvailable -Name PSScriptAnalyzer)) {
    Set-PSRepository -Name PSGallery -InstallationPolicy Trusted
    Install-Module PSScriptAnalyzer -Scope CurrentUser -Repository PSGallery -Force
}

Import-Module PSScriptAnalyzer
$PSSAResults = Invoke-ScriptAnalyzer -Path . -ExcludeRule PSAvoidTrailingWhitespace -Recurse
$DETAILS = ($PSSAResults | ForEach-Object { "{0,-11} [{1,-3}, {2,-3}] {3,-50} {4,-35} - {5}" -f $_.Severity, $_.Line, $_.Column, $_.ScriptName, $_.RuleName, $_.Message } | Out-String -Width 88).Trim()
$DETAILS
$SUMMARY = ($PSSAResults | Group-Object -Property Severity -NoElement | Foreach-Object { "$($_.Count) $($_.Name)" }) -join ", "
$SUMMARY

if ($SUMMARY.Count -ne 0) {
    throw
}

exit $LastExitCode