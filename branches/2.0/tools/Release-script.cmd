@echo off
nant -buildfile:mvvm-core.build.xml -D:build-mode=release Release
pause
