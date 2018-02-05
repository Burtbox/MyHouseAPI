param(
    # The name of the sql server instance to run the script on
    [string]$server = "EDLAPTOP\EDLAPTOPSQL",

    # The database name to run the script on
    [string]$db = "MyHouse_Dev", 
    
    # The path (relative or absolute) of the sql file
    [string]$inputFile = ".\build\MyHouseDB.sql"
)

Write-Host "Running file $($inputFile) on $($server) $($db)"

try 
{
    Invoke-Sqlcmd -InputFile $inputFile -ServerInstance $server -Database $db -Username "HMApp" -Password "dickbutt11!"
} 
catch 
{
  "error when running sql"
  Write-Host($error)
}

Write-Host "Running script complete"