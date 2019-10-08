[string]$SCRIPT       = '0-build/build.cake'

# git commit sha
if (Get-Command git -ErrorAction SilentlyContinue){
    [string]$GIT_COMMIT_SHA = git rev-parse --short HEAD
}

# Restore cake.tool
dotnet --diagnostic tool restore --verbosity diagnostic

# Start Cake
[string]$CAKE_ARGS = "--verbosity=diagnostic"
[string]$CAKE_GIT_ARGS ="-git-commit-sha=$GIT_COMMIT_SHA"

Write-Host "dotnet cake $SCRIPT $CAKE_ARGS $CAKE_GIT_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $CAKE_ARGS $CAKE_GIT_ARGS $ARGS
