set BASE=%~dp0
set SRC_DIR=%BASE%\src\Acme.FooBarPlayer\bin\Debug
set DEST_DIR=%BASE%\players\FooBar_20000

if not exist "%DEST_DIR%" mkdir "%DEST_DIR%"

xcopy "%SRC_DIR%" "%DEST_DIR%" /e /f /y