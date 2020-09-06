#!/bin/sh

set -ex

SCRIPT='0-build/build.cake'

dotnet --list-sdks

dotnet tool restore

dotnet format --check --dry-run --verbosity minimal

CAKE_ARGS="$SCRIPT --verbosity=verbose"

dotnet cake $CAKE_ARGS "$@"
