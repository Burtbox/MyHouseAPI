param(
    # The directory of the MyHouseAPI repo (no backslash at the end)
    [string]$repoDir = "C:\WebProjects\MyHouseAPI",

    # The name of the sql server instance to run the script on
    [string]$server = "EDLAPTOP\EDLAPTOPSQL",

    # The database name to create
    [string]$db = "MyHouse_Dev_Tests"
)
## Set up local variables
Write-Host "Beginning set up of local vars"

$buildScriptsDir = $repoDir + "\BuildScripts"
$buildOutputDir = $buildScriptsDir + "\build"
$buildOutputScript = $buildOutputDir + "\MyHouseDB.sql"
$integrationTestOutputScript = $buildOutputDir + "\IntegrationTestSetup.sql"
$databaseScriptsDir = $repoDir + "\Database"
$dropAndCreateDbQuery = "ALTER DATABASE $($db) SET SINGLE_USER WITH ROLLBACK IMMEDIATE
                         GO
                         IF EXISTS(SELECT name FROM sys.databases WHERE name = '$($db)') 
                            DROP DATABASE $($db)
                         GO
                            CREATE DATABASE $($db)
                         GO"

Write-Host "Completed set up of local vars"

## Create New Database
Write-Host "Beginning creating new database from $($repoDir) on $($server) as $($db)"

try 
{
    Invoke-Sqlcmd -ServerInstance $server -Database "master" -Query $dropAndCreateDbQuery -Verbose -Username "HMApp" -Password "dickbutt11!"
} 
catch 
{
  "error when creating database"
  Write-Host($error)
}

Write-Host "Creating database complete"

## Create single sql script from all in repo
Write-Host "Beginning combining of myHouseDb sql scripts"
Invoke-Expression -Command "$($buildScriptsDir)\CombineSQLScripts.ps1 -source $($databaseScriptsDir) -output $($buildOutputScript)"
Write-Host "Completed combining of myHouseDb sql scripts"

## Run single script on new database
Write-Host "Beginning run of myHouseDb sql"
Invoke-Expression -Command "$($buildScriptsDir)\RunSQLScript.ps1 -server $($server) -db $($db) -inputFile $($buildOutputScript)"
Write-Host "Completed run of myHouseDb sql"

## Create single sql script from integration test setup scripts
Write-Host "Beginning combining of integration test sql scripts"
Invoke-Expression -Command "$($buildScriptsDir)\CombineSQLScripts.ps1 -source $($databaseScriptsDir) -output $($integrationTestOutputScript)"
Write-Host "Completed combining of integration test sql scripts"

## Run single script on new database
Write-Host "Beginning run of integration test sql"
Invoke-Expression -Command "$($buildScriptsDir)\RunSQLScript.ps1 -server $($server) -db $($db) -inputFile $($integrationTestOutputScript)"
Write-Host "Completed run of integration test sql"

Write-Host "Completed creating new integration test database from $($repoDir) on $($server) as $($db)"
