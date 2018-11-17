Function RedirectLocationHeader([string]$url) {
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

    $latest = "https://github.com/exercism/configlet/releases/latest"
    $request = [System.Net.WebRequest]::Create($latest)
    $request.AllowAutoRedirect = $false
    $response = $request.GetResponse()

    $response.GetResponseHeader("Location")
}

Function LatestVersion {
    $location = RedirectLocationHeader("https://github.com/exercism/configlet/releases/latest")
    $location.Substring($location.LastIndexOf("/") + 1)
}

Function Arch {
    If ([Environment]::Is64BitOperatingSystem) { "64bit" } Else { "32bit" }
}

$arch = Arch
$version = LatestVersion
$fileName = "configlet-windows-$arch.zip"
$url = "https://github.com/exercism/configlet/releases/download/$version/$filename"
$outputDirectory = "bin"
$outputFile = Join-Path -Path $outputDirectory -ChildPath $fileName

Invoke-WebRequest -Uri $url -OutFile $outputFile
Expand-Archive $outputFile -DestinationPath $outputDirectory -Force
Remove-Item -Path $outputFile