param(
    # The name of the sql server instance to run the script on
    [string]$server = "localhost\SQL2016",

    # The database name to run the script on
    [string]$db = "MyHouse_Dev_V3", 
    
    # The path (relative or absolute) of the sql file
    [string]$inputFile = ".\build\MyHouseDB.sql"
)

Write-Host "Running file $($inputFile) on $($server) $($db)"

try 
{
    Invoke-Sqlcmd -ServerInstance $server -Database $db -InputFile $inputFile -Verbose
} 
catch 
{
  "error when running sql"
  Write-Host($error)
}

Write-Host "Running script complete"