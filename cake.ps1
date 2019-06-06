[string]$SCRIPT       = '0-build/build.cake'
[string]$CAKE_VERSION = '0.33.0'

# git commit sha
$ENV:GIT_COMMIT_SHA = git rev-parse --short HEAD
Write-Host "GIT_COMMIT_SHA: $ENV:GIT_COMMIT_SHA" -ForegroundColor GREEN

Get-ChildItem ENV:
# Install cake.tool
dotnet tool install --global cake.tool --version $CAKE_VERSION

# Start Cake
[string]$CAKE_ARGS = "-verbosity=diagnostic"

Write-Host "dotnet cake $SCRIPT $CAKE_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $CAKE_ARGS $ARGS