#!/usr/bin/env bash

# Define directories.
SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
TOOLS_DIR=$SCRIPT_DIR/tools
CAKE_VERSION=0.21.1
CAKE_DIR=$TOOLS_DIR/Cake.CoreCLR.$CAKE_VERSION
CAKE_DLL=$CAKE_DIR/Cake.dll
CAKE_ZIP=$TOOLS_DIR/Cake.CoreCLR.$CAKE_VERSION.zip
CAKE_URL=https://www.nuget.org/api/v2/package/Cake.CoreCLR/$CAKE_VERSION
DOTNET_DIR=$SCRIPT_DIR/.dotnet
DOTNET_CORE_2_VERSION=2.0.0
DOTNET_CORE_1_VERSION=1.0.4
DOTNET_INSTALLER_SCRIPT_URL=https://raw.githubusercontent.com/dotnet/cli/master/scripts/obtain/dotnet-install.sh
DOTNET_INSTALLER_SCRIPT=$DOTNET_DIR/dotnet-install.sh

# Define default arguments.
TARGET="Default"
CONFIGURATION="Release"
VERBOSITY="Normal"
DRYRUN=
CAKE_ARGUMENTS=()

# Parse arguments.
for i in "$@"; do
    case $1 in
        -t|--target) TARGET="$2"; shift ;;
        -c|--configuration) CONFIGURATION="$2"; shift ;;
        -v|--verbosity) VERBOSITY="$2"; shift ;;
        -d|--dryrun) DRYRUN="-dryrun" ;;
        --) shift; CAKE_ARGUMENTS+=("$@"); break ;;
        *) CAKE_ARGUMENTS+=("$1") ;;
    esac
    shift
done

# Make sure the tools folder exist.
if [ ! -d "$TOOLS_DIR" ]; then
  mkdir "$TOOLS_DIR"
fi

# Make sure the dotnet folder exist.
if [ ! -d "$DOTNET_DIR" ]; then
  mkdir "$DOTNET_DIR"
fi

# Download .NET installer script if it does not exist.
if [ ! -f "$DOTNET_INSTALLER_SCRIPT" ]; then
    echo "Downloading .NET installer script..."
    curl -Lsfo "$DOTNET_INSTALLER_SCRIPT" $DOTNET_INSTALLER_SCRIPT_URL
    if [ $? -ne 0 ]; then
        echo "An error occured while downloading .NET installer script."
        exit 1
    fi
fi

# Install .NET Core runtimes
$DOTNET_INSTALLER_SCRIPT --version $DOTNET_CORE_1_VERSION --install-dir "$DOTNET_DIR" --no-path
$DOTNET_INSTALLER_SCRIPT --version $DOTNET_CORE_2_VERSION --install-dir "$DOTNET_DIR" --no-path
export PATH="$DOTNET_DIR":$PATH
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_CLI_TELEMETRY_OPTOUT=1

# Install Cake
if [ ! -f "$CAKE_DLL" ]; then
    curl -Lsfo "$CAKE_ZIP" "$CAKE_URL"
    unzip -q "$CAKE_ZIP" -d "$CAKE_DIR"
    rm -f "$CAKE_ZIP"
    if [ $? -ne 0 ]; then
        echo "An error occured while installing Cake."
        exit 1
    fi
fi

# Make sure that Cake has been installed.
if [ ! -f "$CAKE_DLL" ]; then
    echo "Could not find Cake.dll at '$CAKE_DLL'."
    exit 1
fi

# Start Cake
dotnet "$CAKE_DLL" --verbosity="$VERBOSITY" --configuration="$CONFIGURATION" --target="$TARGET" $DRYRUN "${CAKE_ARGUMENTS[@]}"