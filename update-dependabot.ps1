$output = [System.Text.StringBuilder]::new()

[void]$output.AppendLine("version: 1")
[void]$output.AppendLine("")
[void]$output.AppendLine("update_configs:")

$paths = Get-ChildItem -Recurse -Path *.csproj

foreach ($path in $paths)
{
	$dir = $path.Directory
	$relativePath = Resolve-Path -Relative $dir
	$relativePath = $relativePath.Replace(".\", "/")
	$relativePath = $relativePath.Replace("\", "/")
	
	if ($relativePath.StartsWith("/build"))
	{
		continue
	}
	
	[void]$output.AppendLine("    - package_manager: `"dotnet:nuget`"")
	[void]$output.AppendLine("      directory: `"" + $relativePath + "`"")
	[void]$output.AppendLine("      update_schedule: `"live`"")
	[void]$output.AppendLine("")
}

Set-Content "./.dependabot/config.yml" $output.ToString()