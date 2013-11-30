REM Starten von OpenCover via NUnit
"C:\Program Files (x86)\OpenCover\OpenCover.Console.exe" -target:"C:\Program Files\Gallio\bin\Gallio.Echo.exe" -targetdir:"E:\Entwicklung\FDM\FDMTest\bin\Debug" -targetargs:"E:\Entwicklung\FDM\FDMTest\bin\Debug\FDMTest.dll /pd:E:\Entwicklung\FDM\FDMTest\bin\Debug" -register:user "-filter:+[*]* -[Gallio*]* -[Microsoft*]* -[*Test]*" -output:"E:\tmp\coverresult.xml"

REM Erstellen des Reports mit Hilfe von ReportGenerator
E:\Entwicklung\ReportGenerator\bin\ReportGenerator.exe E:\tmp\coverresult.xml E:\tmp\coverreport

Öffnen des Report-Ergebnisses im Standard-Browser
rem start REPORTORDNER\coverreport\index.htm

