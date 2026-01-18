#!/bin/bash

PROJECT_NAME="SpecialMathExplorer"
OUTPUT_DIR="./READY_TO_SEND"

echo "--- Starting Process Executables Generation ---"
echo "Cleaning old folders..."
rm -rf $OUTPUT_DIR
dotnet clean "${PROJECT_NAME}.csproj" -c Release
mkdir -p $OUTPUT_DIR
echo "Generating executable for Windows (win-x64)..."
dotnet publish "${PROJECT_NAME}.csproj" -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o "$OUTPUT_DIR/Windows"
echo "Generating executable for Linux (linux-x64)..."
dotnet publish "${PROJECT_NAME}.csproj" -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true -o "$OUTPUT_DIR/Linux"
echo "Generating executable for Mac Apple Silicon (osx-arm64)..."
dotnet publish "${PROJECT_NAME}.csproj" -c Release -r osx-arm64 --self-contained true -p:PublishSingleFile=true -o "$OUTPUT_DIR/Mac_Silicon"
echo "Generating executable for Mac Intel (osx-x64)..."
dotnet publish "${PROJECT_NAME}.csproj" -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true -o "$OUTPUT_DIR/Mac_Intel"
echo "Auto-compressing in .zip archives..."
cd "$OUTPUT_DIR" || { echo "Error: Couldn't enter into $OUTPUT_DIR"; exit 1; }
zip -r Windows.zip Windows/ > /dev/null
zip -r Linux.zip Linux/ > /dev/null
zip -r Mac_Silicon.zip Mac_Silicon/ > /dev/null
zip -r Mac_Intel.zip Mac_Intel/ > /dev/null
echo "Cleaning intermediar folders (Windows/, Mac/, etc.)..."
rm -rf Windows/ Linux/ Mac_Silicon/ Mac_Intel/
cd .. || { echo "Error: Couldn't return to root directory"; exit 1; }
echo "--- PROCESS IS OVER! ---"
echo "In this folder you can find .zip archives: $OUTPUT_DIR"