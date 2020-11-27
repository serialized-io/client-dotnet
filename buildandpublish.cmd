@echo off
dotnet clean
dotnet build
dotnet test
dotnet pack --configuration Release
cd SerializedClient
echo Run: dotnet nuget push "bin/Release/Serialized.Client.x.y.z.nupkg" --source "github"