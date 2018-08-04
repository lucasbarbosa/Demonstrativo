echo INICIANDO BUILDING DA SOLUTION
set msBuildDir=C:\Program Files (x86)\MSBuild\14.0\Bin

call "%msBuildDir%\msbuild.exe"  C:\Projetos\GTF\Gtf.sln /p:Configuration=Debug /l:FileLogger,Microsoft.Build.Engine;logfile=Manual_MSBuild_ReleaseVersion_LOG.log
set msBuildDir=

echo BUILD CONCLUIDO!

echo RODANDO TESTES
cd C:\Projetos\GTF\Gft.Test\bin\Debug
MSTest /testcontainer:Gft.Test.dll
echo TESTES CONCLUIDOS!
pause