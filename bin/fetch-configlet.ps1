$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

if ($PSVersionTable.PSVersion.Major -le 5) {
    # PreserveAuthorizationOnRedirect requires PowerShell Core 7+
    # TODO create a tool that install pwsh in the directory https://docs.microsoft.com/en-us/dotnet/core/tools/local-tools-how-to-use
    throw "Please run with PowerShell Core 'pwsh'. If you need to install pwsh globally: 'dotnet tool install --global PowerShell'"
}

function Get-DownloadUrl($FileName, $RequestOpts) {
    $latestUrl = "https://api.github.com/repos/exercism/configlet/releases/latest"
    $assets = Invoke-RestMethod -Uri $latestUrl -PreserveAuthorizationOnRedirect @RequestOpts | Select-Object -ExpandProperty assets
    return $assets | Where-Object { $_.browser_download_url -match $FileName } | Select-Object -ExpandProperty browser_download_url -First 1
}

# Use GITHUB_TOKEN to download the configlet metadata and binaries from github releases for github actions.
$requestOpts = @{
    Headers           = If ($env:GITHUB_TOKEN) { @{ Authorization = "Bearer ${env:GITHUB_TOKEN}" } } Else { @{ } }
    MaximumRetryCount = 3
    RetryIntervalSec  = 1
}
$outputDirectory = "bin"
$arch = If ([Environment]::Is64BitOperatingSystem) { "64bit" } Else { "32bit" }
$fileName = "configlet-windows-$arch.zip"

Write-Output "Fetching configlet download URL"
$downloadUrl = Get-DownloadUrl -FileName $fileName -RequestOpts $requestOpts
$outputFile = Join-Path -Path $outputDirectory -ChildPath $fileName

Write-Output "Fetching configlet binaries"
# Use PreserveAuthorizationOnRedirect named parameter doesn't work on WSL
Invoke-WebRequest -Uri $downloadUrl -OutFile $outputFile @requestOpts
Expand-Archive -Path $outputFile -DestinationPath $outputDirectory -Force
Remove-Item -Path $outputFile
