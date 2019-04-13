# Usage: .\update-docs.ps1. This will regenerate the docs for all exercises.
# Usage: .\update-docs.ps1 -o <exercise>. This will regenerate the docs for the specified exercise.

.\bin\fetch-configlet
.\bin\configlet generate . $args