[string]$SCRIPT = '0-build/build.cake'

dotnet --info

dotnet tool restore

if (Get-Command git -ErrorAction SilentlyContinue){
    [string]$GIT_COMMIT_SHA = git rev-parse --short HEAD
}

[string]$CAKE_ARGS = "--verbosity=diagnostic"
[string]$CAKE_GIT_ARGS ="-git-commit-sha=$GIT_COMMIT_SHA"

Write-Host "dotnet cake $SCRIPT $CAKE_ARGS $CAKE_GIT_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $CAKE_ARGS $CAKE_GIT_ARGS $ARGS
