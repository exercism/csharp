$toolsDirectory = Join-Path $PSScriptRoot "tools"
$nugetDirectory = Join-Path $toolsDirectory "nuget"
$nugetExe = Join-Path $nugetDirectory "nuget.exe"
$fakeExe = Join-Path $toolsDirectory "fake/tools/fake.exe"
$nunitFrameworkDll = Join-Path $toolsDirectory "nunit/lib/net45/nunit.framework.dll"
$nunitConsoleExe = Join-Path $toolsDirectory "nunit.console/tools/nunit3-console.exe"

If (!(Test-Path $nugetExe)) {   
    # Ensure the directory exists (which is required by DownloadFile)
    New-Item $nugetDirectory -Type Directory | Out-Null
    
    $nugetUrl = "https://dist.nuget.org/win-x86-commandline/v3.3.0/nuget.exe"    
	(New-Object System.Net.WebClient).DownloadFile($nugetUrl, $nugetExe)
}

If (!(Test-Path $nugetExe)) {
	Throw "Could not find nuget.exe"
}

& $nugetExe install FAKE -Version 4.17.1 -ExcludeVersion -OutputDirectory $toolsDirectory
If (!(Test-Path $fakeExe)) {
	Throw "Could not find fake.exe"
}

& $nugetExe install NUnit -Version 3.0.1 -ExcludeVersion -OutputDirectory $toolsDirectory
If (!(Test-Path $nunitFrameworkDll)) {
	Throw "Could not find nunit.framework.dll"
}

& $nugetExe install NUnit.Console -Version 3.0.1 -ExcludeVersion -OutputDirectory $toolsDirectory
If (!(Test-Path $nunitConsoleExe)) {
	Throw "Could not find nunit3-console.exe"
}

# Use FAKE to execute the build script
& $fakeExe $args