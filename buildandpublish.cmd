@echo off
dotnet clean
dotnet build
dotnet pack --configuration Release
echo Run: dotnet nuget push "SerializedClient/bin/Release/Serialized.Client.x.y.z.nupkg" --source "github"