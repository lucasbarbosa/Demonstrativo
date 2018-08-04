echo INICIANDO BUILDING DA SOLUTION
set msBuildDir=C:\Program Files (x86)\MSBuild\14.0\Bin

call "%msBuildDir%\msbuild.exe"  C:\Projetos\GTF\Gft.Test\Gft.Test.csproj
call "%msBuildDir%\msbuild.exe"  C:\Projetos\GTF\Gft\Gft.csproj
set msBuildDir=

echo BUILD CONCLUIDO!

echo RODANDO TESTES
cd C:/Projetos/GTF/Gft.Test/bin/Debug/
MSTest /testcontainer:Gft.Test.dll
echo TESTES CONCLUIDOS!
pause