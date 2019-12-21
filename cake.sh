#!/bin/sh

set -ex

SCRIPT='0-build/build.cake'

dotnet --list-sdks

dotnet tool restore

dotnet format --check --dry-run --verbosity minimal

if command -v git >/dev/null 2>&1; then 
  GIT_COMMIT_SHA=$(git rev-parse --short HEAD)
fi

CAKE_ARGS="$SCRIPT --verbosity=verbose -git-commit-sha=$GIT_COMMIT_SHA"

dotnet cake $CAKE_ARGS "$@"
