#!/usr/bin/env bash

SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
TOOLS_DIR=$SCRIPT_DIR/tools
CAKE_VERSION=0.27.1
CAKE_DIR=$TOOLS_DIR/Cake.$CAKE_VERSION
CAKE_DLL=$CAKE_DIR/Cake.dll
CAKE_ZIP=$TOOLS_DIR/Cake.$CAKE_VERSION.zip
CAKE_ZIP_URL=https://github.com/cake-build/cake/releases/download/v$CAKE_VERSION/Cake-bin-coreclr-v$CAKE_VERSION.zip
DOTNET_VERSION=2.1.302
DOTNET_DIR=$TOOLS_DIR/dotnet.$DOTNET_VERSION
DOTNET_COMMAND=$DOTNET_DIR/dotnet
DOTNET_INSTALL_SCRIPT=$DOTNET_DIR/dotnet-install.sh
DOTNET_INSTALL_SCRIPT_URL=https://dot.net/v1/dotnet-install.sh

# Ensure Cake is installed
if [ ! -f "$CAKE_DLL" ]; then
    mkdir -p $CAKE_DIR
    curl -Lsfo "$CAKE_ZIP" "$CAKE_ZIP_URL"
    unzip -q "$CAKE_ZIP" -d "$CAKE_DIR"
    rm -f "$CAKE_ZIP"
fi

# Ensure .NET Core runtime is installed
if [ ! -f "$DOTNET_COMMAND" ]; then
    mkdir -p $DOTNET_DIR
    curl -Lsfo "$DOTNET_INSTALL_SCRIPT" "$DOTNET_INSTALL_SCRIPT_URL"
    chmod u+x $DOTNET_INSTALL_SCRIPT
    $DOTNET_INSTALL_SCRIPT --version $DOTNET_VERSION --install-dir "$DOTNET_DIR" --no-path
    rm -f $DOTNET_INSTALL_SCRIPT
fi

$DOTNET_COMMAND "$CAKE_DLL" "$@"