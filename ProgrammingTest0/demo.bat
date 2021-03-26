echo off

rem Ejecuta todos los pasos necesarios para ver el proyecto corriendo

setlocal enableextensions

rem Revisar dependencias

where dotnet
if %ERRORLEVEL% EQU 0 goto npm

echo (!) dotnet 2.0+ debe estar instalado
goto end

:npm

where npm
if %ERRORLEVEL% EQU 0 goto rundemo

echo (!) npm debe estar instalado
goto end

:rundemo

rem Backend

set outputDir=.\demo

call dotnet publish Backend -c Release -r win-x64 -o %outputDir%
pushd %outputDir%
start Backend.exe
popd

rem Frontend

pushd Frontend
call npm install
call npm run build
call npm run serve
popd

:end