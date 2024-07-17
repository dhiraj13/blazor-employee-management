#!/bin/bash
echo "Cleaning the solution..."
dotnet clean
echo "Rebuilding the solution..."
dotnet build
echo "Done."