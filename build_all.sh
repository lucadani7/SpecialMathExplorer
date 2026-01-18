#!/bin/bash

PROJECT_NAME="SpecialMathExplorer"
OUTPUT_DIR="./READY_TO_SEND"

echo "--- Starting Process Executables Generation ---"
echo "Cleaning old folders..."
rm -rf $OUTPUT_DIR
dotnet clean "${PROJECT_NAME}.csproj" -c Release
mkdir -p $OUTPUT_DIR
echo "Generating executable for Windows (win-x64)..."
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o "$OUTPUT_DIR/Windows"
echo "Generating executable for Linux (linux-x64)..."
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true -o "$OUTPUT_DIR/Linux"
echo "Generating executable for Mac Apple Silicon (osx-arm64)..."
dotnet publish -c Release -r osx-arm64 --self-contained true -p:PublishSingleFile=true -o "$OUTPUT_DIR/Mac_Silicon"
echo "Generating executable for Mac Intel (osx-x64)..."
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true -o "$OUTPUT_DIR/Mac_Intel"
echo "--- PROCESS IS OVER! ---"
echo "All the executables are in this folder: $OUTPUT_DIR"