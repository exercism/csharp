<#
.SYNOPSIS
This is a Powershell script to bootstrap a Cake build.
.DESCRIPTION
This Powershell script will download NuGet if missing, restore NuGet tools (including Cake)
and execute your Cake build script with the parameters you provide.
.PARAMETER Target
The build script target to run.
.PARAMETER Configuration
The build configuration to use.
.PARAMETER Verbosity
Specifies the amount of information to be displayed.
.PARAMETER WhatIf
Performs a dry run of the build script.
No tasks will be executed.
.PARAMETER Exercise
The exercise to build and test. If not specified, all exercises will be built and tested.
.PARAMETER ScriptArgs
Remaining arguments are added here.
.LINK
http://cakebuild.net
#>

[CmdletBinding()]
Param(
    [string]$Target = "Default",
    [ValidateSet("Release", "Debug")]
    [string]$Configuration = "Release",
    [ValidateSet("Quiet", "Minimal", "Normal", "Verbose", "Diagnostic")]
    [string]$Verbosity = "Normal",
    [switch]$WhatIf,
    [string]$Exercise,
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$ScriptArgs
)

function GetProxyEnabledWebClient
{
    $wc = New-Object System.Net.WebClient
    $proxy = [System.Net.WebRequest]::GetSystemWebProxy()
    $proxy.Credentials = [System.Net.CredentialCache]::DefaultCredentials        
    $wc.Proxy = $proxy
    return $wc
}

Write-Host "Preparing to run build script..."

if(!$PSScriptRoot){
    $PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent
}

$TOOLS_DIR = Join-Path $PSScriptRoot "tools"
$NUGET_URL = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
$NUGET_EXE = Join-Path $TOOLS_DIR "nuget.exe"
$CAKE_VERSION = "0.21.1"
$CAKE_DLL = Join-Path $TOOLS_DIR "Cake.CoreCLR.$CAKE_VERSION/Cake.dll"
$DOTNET_DIR = Join-Path $PSScriptRoot ".dotnet"
$DOTNET_CORE_2_VERSION = "2.0.0"
$DOTNET_CORE_1_VERSION = "1.0.4"
$DOTNET_INSTALLER_SCRIPT_URL = "https://raw.githubusercontent.com/dotnet/cli/master/scripts/obtain/dotnet-install.ps1"
$DOTNET_INSTALLER_SCRIPT = Join-Path $DOTNET_DIR "dotnet-install.ps1"

$env:PATH = "$TOOLS_DIR;$DOTNET_DIR;$env:PATH"

# Make sure tools folder exists
if ((Test-Path $PSScriptRoot) -and !(Test-Path $TOOLS_DIR)) {
    Write-Verbose -Message "Creating tools directory..."
    New-Item -Path $TOOLS_DIR -Type directory | out-null
}

# Make sure dotnet folder exists
if ((Test-Path $PSScriptRoot) -and !(Test-Path $DOTNET_DIR)) {
    Write-Verbose -Message "Creating .dotnet directory..."
    New-Item -Path $DOTNET_DIR -Type directory | out-null
}

# Try download .NET installer script if not exists
if (!(Test-Path $DOTNET_INSTALLER_SCRIPT)) {
    Write-Verbose -Message "Downloading .NET installer script..."
    try {
        $wc = GetProxyEnabledWebClient
        $wc.DownloadFile($DOTNET_INSTALLER_SCRIPT_URL, $DOTNET_INSTALLER_SCRIPT)
    } catch {
        Throw "Could not download .NET installer script."
    }
}

# Install .NET Core runtimes
Invoke-Expression "&`"$DOTNET_INSTALLER_SCRIPT`" -Version $DOTNET_CORE_1_VERSION -InstallDir `"$DOTNET_DIR`""
Invoke-Expression "&`"$DOTNET_INSTALLER_SCRIPT`" -Version $DOTNET_CORE_2_VERSION -InstallDir `"$DOTNET_DIR`""
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
$env:DOTNET_CLI_TELEMETRY_OPTOUT=1

# Try find NuGet.exe in path if not exists
if (!(Test-Path $NUGET_EXE)) {
    Write-Verbose -Message "Trying to find nuget.exe in PATH..."
    $existingPaths = $Env:Path -Split ';' | Where-Object { (![string]::IsNullOrEmpty($_)) -and (Test-Path $_ -PathType Container) }
    $NUGET_EXE_IN_PATH = Get-ChildItem -Path $existingPaths -Filter "nuget.exe" | Select -First 1
    if ($NUGET_EXE_IN_PATH -ne $null -and (Test-Path $NUGET_EXE_IN_PATH.FullName)) {
        Write-Verbose -Message "Found in PATH at $($NUGET_EXE_IN_PATH.FullName)."
        $NUGET_EXE = $NUGET_EXE_IN_PATH.FullName
    }
}

# Try download NuGet.exe if not exists
if (!(Test-Path $NUGET_EXE)) {
    Write-Verbose -Message "Downloading NuGet.exe..."
    try {
        $wc = GetProxyEnabledWebClient
        $wc.DownloadFile($NUGET_URL, $NUGET_EXE)
    } catch {
        Throw "Could not download NuGet.exe."
    }
}

# Save nuget.exe path to environment to be available to child processed
$ENV:NUGET_EXE = $NUGET_EXE

# Try install Cake
if (!(Test-Path $CAKE_DLL)) {
    Write-Verbose -Message "Installing Cake..."
    $NuGetOutput = Invoke-Expression "&`"$NUGET_EXE`" install Cake.CoreCLR -Version $CAKE_VERSION -OutputDirectory `"$TOOLS_DIR`""

    if ($LASTEXITCODE -ne 0) {
        Throw "Could not install Cake."
    }

    Write-Verbose -Message ($NuGetOutput | out-string)
}

# Make sure that Cake has been installed
if (!(Test-Path $CAKE_DLL)) {
    Throw "Could not find Cake.dll at $CAKE_DLL"
}

# Build Cake arguments
$cakeArguments = @("$Script");
if ($Target) { $cakeArguments += "-target=$Target" }
if ($Configuration) { $cakeArguments += "-configuration=$Configuration" }
if ($Verbosity) { $cakeArguments += "-verbosity=$Verbosity" }
if ($ShowDescription) { $cakeArguments += "-showdescription" }
if ($DryRun) { $cakeArguments += "-dryrun" }
if ($Exercise) { $cakeArguments += "-exercise=$Exercise" }
$cakeArguments += $ScriptArgs

# Start Cake
Write-Host "Running build script..."
Invoke-Expression "&dotnet `"$CAKE_DLL`" $cakeArguments"
exit $LASTEXITCODE