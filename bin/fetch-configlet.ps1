$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

function Get-DownloadUrl($FileName) {
    if ($PSVersionTable.PSVersion.Major -le 5) {
        # PreserveAuthorizationOnRedirect requires PowerShell 7+
        throw "Please upgrade to PowerShell Core with 'dotnet tool install --global PowerShell'"
    }

    $requestOpts = @{
        Headers           = If ($env:GITHUB_TOKEN) { @{ Authorization = "Bearer ${env:GITHUB_TOKEN}" } } Else { @{ } }
        MaximumRetryCount = 3
        RetryIntervalSec  = 1
    }
    $latestUrl = "https://api.github.com/repos/exercism/configlet/releases/latest"
    $assets = Invoke-RestMethod -Uri $latestUrl -PreserveAuthorizationOnRedirect @requestOpts | Select-Object -ExpandProperty assets
    $assets | Where-Object { $_.browser_download_url -match $FileName } | Select-Object -ExpandProperty browser_download_url
}

$outputDirectory = "bin"
$arch = If ([Environment]::Is64BitOperatingSystem) { "64bit" } Else { "32bit" }
$fileName = "configlet-windows-$arch.zip"

$downloadUrl = Get-DownloadUrl $fileName
$outputFile = Join-Path -Path $outputDirectory -ChildPath $fileName
Invoke-WebRequest -Uri $downloadUrl -OutFile $outputFile @requestOpts
Expand-Archive $outputFile -DestinationPath $outputDirectory -Force
Remove-Item -Path $outputFile