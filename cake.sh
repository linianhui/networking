#!/bin/sh

set -x

SCRIPT='0-build/build.cake'
CAKE_VERSION='0.35.0'

# git commit sha
if command -v git >/dev/null 2>&1; then 
  GIT_COMMIT_SHA=$(git rev-parse --short HEAD)
fi

# Install  cake.tool
dotnet tool install --global --version $CAKE_VERSION cake.tool
export PATH="$PATH:$HOME/.dotnet/tools"

# Start Cake
CAKE_ARGS="$SCRIPT --verbosity=diagnostic -git-commit-sha=$GIT_COMMIT_SHA"

echo "\033[32mdotnet cake $CAKE_ARGS $@"

dotnet cake $CAKE_ARGS "$@"
