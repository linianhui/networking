[string]$SCRIPT = '0-build/build.cake'

dotnet --list-sdks

dotnet tool restore

dotnet format --check --dry-run --verbosity minimal

if (Get-Command git -ErrorAction SilentlyContinue){
    [string]$GIT_COMMIT_SHA = git rev-parse --short HEAD
}

[string]$CAKE_ARGS = "--verbosity=verbose"
[string]$CAKE_GIT_ARGS ="-git-commit-sha=$GIT_COMMIT_SHA"

Write-Host "dotnet cake $SCRIPT $CAKE_ARGS $CAKE_GIT_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $CAKE_ARGS $CAKE_GIT_ARGS $ARGS
