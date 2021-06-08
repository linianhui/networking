#!/bin/sh

set -ex

SCRIPT='cake/build.cake'

dotnet --list-sdks

dotnet tool restore

dotnet format --check --verbosity diagnostic

CAKE_ARGS="$SCRIPT --verbosity=verbose"

dotnet cake $CAKE_ARGS "$@"
