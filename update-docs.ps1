# Usage: .\update-docs.ps1. This will regenerate the docs for all exercises.
# Usage: .\update-docs.ps1 -o <exercise>. This will regenerate the docs for the specified exercise.

git submodule init
git submodule update --remote

.\bin\fetch-configlet
.\bin\configlet generate . -p problem-specifications $args