$EditorConfigSettings = Get-Content -Path ".editorconfig"

Get-Childitem –Path "exercises" -Directory | ForEach-Object { 

    $Exercise = (Get-Culture).TextInfo.ToTitleCase($_.Name).Replace("-", "")
    $ExerciseEditorConfigSettings = $EditorConfigSettings.Replace( "[*.cs]", "[$Exercise.cs]")
    $ExerciseEditorConfigPath = Join-Path $_.FullName ".editorconfig"

    Set-Content -Path $ExerciseEditorConfigPath $ExerciseEditorConfigSettings
}

exit $LastExitCode