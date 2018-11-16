#!/bin/sh

SCRIPT='0-build/build.cake'
CAKE_VERSION='0.30.0'

# nuget server config
export NUGET_REPOSITORY_API_URL='http://nuget-server.test/nuget'
export NUGET_REPOSITORY_API_KEY='123456'

# Install  cake.tool
dotnet tool install --global cake.tool --version $CAKE_VERSION
export PATH="$PATH:$HOME/.dotnet/tools"

# Start Cake
CAKE_ARGS="$SCRIPT -verbosity=diagnostic"

echo "\033[32mdotnet cake $CAKE_ARGS $@"

dotnet cake $CAKE_ARGS "$@"
