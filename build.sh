#!/usr/bin/env bash

# Define directories.
SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
TOOLS_DIR=$SCRIPT_DIR/tools
CAKE_VERSION=0.18.0
CAKE_DLL=$TOOLS_DIR/Cake.CoreCLR.$CAKE_VERSION/Cake.dll
DOTNET_VERSION=1.0.1

# Make sure the tools folder exist. 
if [ ! -d "$TOOLS_DIR" ]; then
  mkdir "$TOOLS_DIR"
fi

###########################################################################
# INSTALL .NET CORE CLI
###########################################################################

if [[ ! $(command -v dotnet) ]] || [ ! $(dotnet --version) == "$DOTNET_VERSION" ] ; then
    echo "Installing .NET CLI..."
    
    if [ ! -d "$SCRIPT_DIR/.dotnet" ]; then
        mkdir "$SCRIPT_DIR/.dotnet"
    fi
    curl -Lsfo "$SCRIPT_DIR/.dotnet/dotnet-install.sh" https://dot.net/v1/dotnet-install.sh
    sudo bash "$SCRIPT_DIR/.dotnet/dotnet-install.sh" --version DOTNET_VERSION --install-dir .dotnet --no-path
    export PATH="$SCRIPT_DIR/.dotnet":$PATH
    export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
    export DOTNET_CLI_TELEMETRY_OPTOUT=1
    "$SCRIPT_DIR/.dotnet/dotnet" --info
fi

# ###########################################################################
# # INSTALL CAKE
# ###########################################################################

if [ ! -f "$CAKE_DLL" ]; then
    curl -Lsfo Cake.CoreCLR.zip "https://www.nuget.org/api/v2/package/Cake.CoreCLR/$CAKE_VERSION" && unzip -q Cake.CoreCLR.zip -d "$TOOLS_DIR/Cake.CoreCLR.$CAKE_VERSION" && rm -f Cake.CoreCLR.zip
    if [ $? -ne 0 ]; then
        echo "An error occured while installing Cake."
        exit 1
    fi
fi

# Make sure that Cake has been installed.
if [ ! -f "$CAKE_DLL" ]; then
    echo "Could not find Cake.exe at '$CAKE_DLL'."
    exit 1
fi

###########################################################################
# RUN BUILD SCRIPT
###########################################################################

# Start Cake
exec dotnet "$CAKE_DLL" "$@"