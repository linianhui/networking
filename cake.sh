#!/bin/sh

set -ex

SCRIPT_FILE='cake/build.cake'
CAKE_ARGS='--verbosity=verbose'

dotnet --list-sdks

dotnet tool restore

dotnet format --check --fix-style error --verbosity diagnostic

dotnet cake $SCRIPT_FILE $CAKE_ARGS $@
