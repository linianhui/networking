#!/bin/sh

set -x

# dotnet info
dotnet --info

SCRIPT='0-build/build.cake'

# git commit sha
if command -v git >/dev/null 2>&1; then 
  GIT_COMMIT_SHA=$(git rev-parse --short HEAD)
fi

# Restore cake.tool
dotnet tool restore

# Start Cake
CAKE_ARGS="$SCRIPT --verbosity=diagnostic -git-commit-sha=$GIT_COMMIT_SHA"

echo "\033[32mdotnet cake $CAKE_ARGS $@"

dotnet cake $CAKE_ARGS "$@"
