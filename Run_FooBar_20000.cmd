
@echo off
set BASE=%~dp0\players\FooBar_20000

echo ---------------------------------------------------------------------------
echo %DATE% %TIME% Starting FooBar 20000
echo %DATE% %TIME% Starting FooBar 20000 >> %BASE%\Run_FooBar_20000.log

:loop
cd /D %BASE%
FooBarPlayer.exe
echo ---------------------------------------------------------------------------
echo %DATE% %TIME% Restarting FooBar 20000
echo %DATE% %TIME% Restarting FooBar 20000 >> %BASE%\Run_FooBar_20000.log
goto :loop
