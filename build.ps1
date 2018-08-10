<#
.SYNOPSIS
Build and test the Exercism C# exercises.
.DESCRIPTION
This script runs the Cake build.cake script, which does the following:
- Build each exercise's project.
- Run the exercise's tests against the example implementation.
- Run the refactoring tests against the default implementation.
.PARAMETER Exercise
The name of the exercise to build.
.EXAMPLE
.\build.ps1
Build and test all exercises
.EXAMPLE
.\build.ps1 -Exercise anagram
Build and test only the anagram exercise
.LINK
https://github.com/exercism/csharp
#>
[CmdletBinding()]
Param(
    [Parameter(Mandatory=$false)]
    [string]$Exercise
)

$SCRIPT_DIR = $PSScriptRoot
$TOOLS_DIR = Join-Path $SCRIPT_DIR "tools"
$CAKE_VERSION = "0.27.1"
$CAKE_DIR = Join-Path $TOOLS_DIR "Cake.$CAKE_VERSION"
$CAKE_DLL = Join-Path $CAKE_DIR "Cake.dll"
$CAKE_ZIP = Join-Path $TOOLS_DIR "Cake.$CAKE_VERSION.zip"
$CAKE_ZIP_URL = "https://github.com/cake-build/cake/releases/download/v$CAKE_VERSION/Cake-bin-coreclr-v$CAKE_VERSION.zip"
$DOTNET_VERSION = "2.1.302"
$DOTNET_DIR = Join-Path $TOOLS_DIR "dotnet.$DOTNET_VERSION"
$DOTNET_COMMAND = Join-Path $DOTNET_DIR "dotnet.exe"
$DOTNET_INSTALL_SCRIPT = Join-Path $DOTNET_DIR "dotnet-install.ps1"
$DOTNET_INSTALL_SCRIPT_URL = "https://dot.net/v1/dotnet-install.ps1"    

function DownloadFile([string] $Url, [string] $Path)
{
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
    $webClient = New-Object System.Net.WebClient
    $webClient.Proxy.Credentials = [System.Net.CredentialCache]::DefaultCredentials
    $webClient.DownloadFile($Url, $Path)
}

# Ensure Cake is installed
if (!(Test-Path $CAKE_DLL)) {
    New-Item -ItemType Directory -Force -Path $CAKE_DIR | Out-Null
    DownloadFile -Url $CAKE_ZIP_URL -Path $CAKE_ZIP
    Expand-Archive $CAKE_ZIP -DestinationPath $CAKE_DIR | Out-Null
    Remove-Item -Force -Path $CAKE_ZIP | Out-Null
}

# Ensure .NET Core runtime is installed
if (!(Test-Path $DOTNET_COMMAND)) {
    New-Item -ItemType Directory -Force -Path $DOTNET_DIR | Out-Null
    DownloadFile -Url $DOTNET_INSTALL_SCRIPT_URL -Path $DOTNET_INSTALL_SCRIPT
    Invoke-Expression "&`"$DOTNET_INSTALL_SCRIPT`" -Version $DOTNET_VERSION -InstallDir `"$DOTNET_DIR`" -NoPath"
    Remove-Item -Force -Path $DOTNET_INSTALL_SCRIPT | Out-Null
}

$cakeArguments = @("$Script");
if ($Exercise) { $cakeArguments += "--exercise=$Exercise" }
Invoke-Expression "&$DOTNET_COMMAND `"$CAKE_DLL`" $cakeArguments"