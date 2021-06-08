[string]$SCRIPT = 'cake/build.cake'

dotnet --list-sdks

dotnet tool restore

dotnet format --check --verbosity diagnostic

[string]$CAKE_ARGS = "--verbosity=verbose"

Write-Host "dotnet cake $SCRIPT $CAKE_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $CAKE_ARGS $ARGS
