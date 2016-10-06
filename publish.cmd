@echo off

echo Uploading package to NuGet feed
.\build\NuGet\NuGet.exe push Stugo.Maybe\bin\Release\*.nupkg