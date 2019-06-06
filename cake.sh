#!/bin/sh

SCRIPT='0-build/build.cake'
CAKE_VERSION='0.33.0'

# git commit sha
export GIT_COMMIT_SHA=$(git rev-parse --short HEAD)
echo "\033[32mGIT_COMMIT_SHA: $GIT_COMMIT_SHA"

# Install  cake.tool
dotnet tool install --global cake.tool --version $CAKE_VERSION
export PATH="$PATH:$HOME/.dotnet/tools"

# Start Cake
CAKE_ARGS="$SCRIPT -verbosity=diagnostic"

echo "\033[32mdotnet cake $CAKE_ARGS $@"

dotnet cake $CAKE_ARGS "$@"
