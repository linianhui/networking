[string]$SCRIPT_FILE = 'cake/build.cake'
[string]$CAKE_ARGS   = "--verbosity=verbose"

dotnet --list-sdks

dotnet tool restore

dotnet format --check --fix-style error --verbosity diagnostic

Write-Host "dotnet cake $SCRIPT_FILE $CAKE_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT_FILE $CAKE_ARGS $ARGS
