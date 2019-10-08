#!/bin/sh

set -x

SCRIPT='0-build/build.cake'

dotnet --version

dotnet tool restore

if command -v git >/dev/null 2>&1; then 
  GIT_COMMIT_SHA=$(git rev-parse --short HEAD)
fi

CAKE_ARGS="$SCRIPT --verbosity=diagnostic -git-commit-sha=$GIT_COMMIT_SHA"

dotnet cake $CAKE_ARGS "$@"
