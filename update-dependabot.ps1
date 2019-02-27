$outputPath = "./.dependabot/config.yml"

Remove-Item $outputPath

Add-Content $outputPath "version: 1"
Add-Content $outputPath ""
Add-Content $outputPath "update_configs:"

$paths = Get-ChildItem -Recurse -Path *.csproj

foreach ($path in $paths)
{
	$dir = $path.Directory
	$relativePath = Resolve-Path -Relative $dir
	$relativePath = $relativePath.Replace(".\", "/")
	$relativePath = $relativePath.Replace("\", "/")
	
	$directoryLine = "      directory: `"" + $relativePath + "`""
	
	Add-Content $outputPath "    - package_manager: `"dotnet:nuget`""
	Add-Content $outputPath $directoryLine
	Add-Content $outputPath "      update_schedule: `"live`""
	Add-Content $outputPath ""
}