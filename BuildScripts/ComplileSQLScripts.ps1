param(
    #[string]$path = $(throw "You must enter the path to the .sql files you want to append."),
    [string]$NewFileName = "MyHouseDB.sql"
)
 
$path = "C:\WebProjects\MyHouseAPI\Database"
$outFile = "$path\$NewFileName"
 
cls
if((Test-Path $outFile) -eq $true) {Remove-Item -Path $outFile -Force}
 
$files = Get-ChildItem -LiteralPath $path -Include "*.sql" -Recurse
 
New-Item -ItemType file -Path $outFile | Out-Null
 
foreach($file in $files)
{
    Write-Host "Appending file $file..." -ForegroundColor Gray
    $content = Get-Content -Path $file.FullName 
    Add-Content -Path $outFile "/*"
    Add-Content -Path $outFile "-- File Name: $file "
    Add-Content -Path $outFile "-- First Created: $($file.CreationTime.ToString())"
    Add-Content -Path $outFile "-- Last Modified: $($file.LastWriteTime.ToString())"
    Add-Content -Path $outFile "*/"
    Add-Content -Path $outFile $content
    Add-Content -Path $outFile "GO`n"
}
 
Write-Host "Completed file $outFile" -ForegroundColor DarkGreen