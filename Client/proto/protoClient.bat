@echo off 

set srcPath=%cd%\

set distCsPath=%srcPath%..\unity\Assets\Script\Network\ProtoMsg

set binPath=%srcPath%\bin

::for /r "%srcPath%" %%i in (*.proto) do ( %binPath%\protoGen -i:%%i -o:%distCsPath%\%%~ni.cs  )


%binPath%\protoGen -i:%srcPath%\MyDemo.proto -o:%distCsPath%\MyDemo.cs 

rem for /r "%srcPath%" %%i in (*.proto) do ( %binPath%\protoc --gogofaster_out=%distGoPath% %%i --proto_path=%srcPath% )
 
echo "ok"

pause