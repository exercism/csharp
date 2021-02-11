$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

$requestOpts = @{
    Headers           = If ($env:GITHUB_TOKEN) { @{ Authorization = "Bearer ${env:GITHUB_TOKEN}" } } Else { @{ } }
    MaximumRetryCount = 3
    RetryIntervalSec  = 1
}

function Get-DownloadUrl($FileName, $RequestOpts) {
    if ($PSVersionTable.PSVersion.Major -le 5) {
        # PreserveAuthorizationOnRedirect requires PowerShell 7+
        throw "Please upgrade to PowerShell Core. For example: 'dotnet tool install --global PowerShell'"
    }
    
    $latestUrl = "https://api.github.com/repos/exercism/configlet/releases/latest"
    $assets = Invoke-RestMethod -Uri $latestUrl -PreserveAuthorizationOnRedirect @RequestOpts | Select-Object -ExpandProperty assets
    $assets | Where-Object { $_.browser_download_url -match $FileName } | Select-Object -ExpandProperty browser_download_url
}

$outputDirectory = "bin"
$arch = If ([Environment]::Is64BitOperatingSystem) { "64bit" } Else { "32bit" }
$fileName = "configlet-windows-$arch.zip"

$downloadUrl = Get-DownloadUrl $fileName $requestOpts
$outputFile = Join-Path -Path $outputDirectory -ChildPath $fileName
Invoke-WebRequest -Uri $downloadUrl -OutFile $outputFile -PreserveAuthorizationOnRedirect @requestOpts
Expand-Archive $outputFile -DestinationPath $outputDirectory -Force
Remove-Item -Path $outputFile