[string]$SCRIPT       = '0-build/build.cake'
[string]$CAKE_VERSION = '0.35.0'

# git commit sha
if (Get-Command git -ErrorAction SilentlyContinue){
    [string]$GIT_COMMIT_SHA = git rev-parse --short HEAD
}

# Install cake.tool
dotnet tool install --global cake.tool --version $CAKE_VERSION

# Start Cake
[string]$CAKE_ARGS = "--verbosity=diagnostic"
[string]$CAKE_GIT_ARGS ="-git-commit-sha=$GIT_COMMIT_SHA"

Write-Host "dotnet cake $SCRIPT $CAKE_ARGS $CAKE_GIT_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $CAKE_ARGS $CAKE_GIT_ARGS $ARGS
