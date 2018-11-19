.\bin\fetch-configlet
.\bin\configlet generate .
Get-ChildItem -File -Path ".\config\patches" -Filter *.patch | % {& git apply $_.FullName}