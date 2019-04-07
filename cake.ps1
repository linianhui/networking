[string]$SCRIPT       = '0-build/build.cake'
[string]$CAKE_VERSION = '0.33.0'

# nuget server config
$ENV:NUGET_REPOSITORY_API_URL = "http://nuget-server.test/nuget"
$ENV:NUGET_REPOSITORY_API_KEY = "123456"

# Install cake.tool
dotnet tool install --global cake.tool --version $CAKE_VERSION

# Start Cake
[string]$CAKE_ARGS = "-verbosity=diagnostic"

Write-Host "dotnet cake $SCRIPT $CAKE_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $CAKE_ARGS $ARGS