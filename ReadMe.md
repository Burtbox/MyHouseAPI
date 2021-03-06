# My House API

The .NetCore 2.0 API for the myHouse platform

## Getting Started

1. Create a local database using
 ```
 .\BuildScripts\CreateNewDb.ps1
 ```
2. Point the appsettings.Development.json to the database 
3. Run the MyHouseAPI.csproj (vsCode or vs F5)
4. Get a valid firebase Token,
    run the integration tests (two firebase user tokens are provided there)
    or run the MyHouseClient app and login (https://github.com/Burtbox/MyHouseClient.git)
5. Via localhost\swagger post API requests

### Prerequisites

You will need the following versions (or higher) of:

```
.NetCore 2.0 SDK
SQL Server 2016
SQL Server Management Studio 2016
Visual Studio Code (or Visual Stuido 2017)
```

Recommended Extensions for Visual Studio Code
```
    C#
    Powershell
    .NetCore Test Runner
```

### Installing

Create a local database with
```
.\BuildScripts\CreateNewDb.ps1
```

Set the appSettings.Development.json to use that database

Run the API 

Go to localhost\swagger to view and use the endpoints

## Running the unit tests

Visual Studio Code .NetCore Test runner (or Ctrl + R, Ctrl + T) - run tests
Visual Studio Test Explorer - run tests
cmd - run
```
dotnet test ./MyHouse_UnitTests/MyHouseUnitTests.csproj
```

### Running the integration tests

These test End to End functionality and require live data

A test database already exists on EDLAPTOP, to update this:
1. Run the update db script
```
.\BuildScripts\UpgradeDb.ps1
```

Locally create a new test db: (drops and creates)
1. Run the setup command: 
(this creates a new integration test db on EDLAPTOP\EDLAPTOPSQL as MyHouse_Dev_Tests 
with the data setup in ./MyHouse_IntegrationTests/TestData)
```
.\BuildScripts\SetupUnitTestDb.ps1
```
Debug a specific test:
1. switch testsettings.json to your local api (commented in file)
2. Run the web api (F5)
3. Debug a specific test (above the method name in vscode)

Deploy static test api:
Stop app pool MyHouseTestAPI on edLaptop
```
dotnet publish ./MyHouse_API -c Release -o "\\edlaptop\wwwroot\MyHouseTestAPI"
```

Run all tests: 
1. switch testsettings.json to use test api on edpaptop (commented in file)
2. Use .netTestExplorer plugin to run all tests

### And coding style tests

Not implemented

## Deployment

Integration Test API: 
    1. Stop the app pool MyHouseAPI on livingroompc
    2. Run the command 

    ```
    dotnet publish ./MyHouse_API -c Release -o "C:\inetpub\wwwroot\MyHouseAPI\MyHouse_API\bin\Release\" 
    ```
    copy to living room pc
## Built With

* [dotnet/core](https://github.com/dotnet/core)
* [SQLServer](https://www.microsoft.com/en-gb/sql-server/sql-server-2016)

## Contributing

To contribute to this project create a pull request on github (https://github.com/Burtbox/MyHouseAPI.git) 

## Versioning

We use git for versioning. For the versions available, see the [tags on this repository](https://github.com/Burtbox/MyHouseAPI.git/tags). 

## Authors

* **Ed Burt** - *Developer* - (https://github.com/Burtbox)
* **Chris Field** - *Developer* - (https://github.com/chrisjfield)

See also the list of [contributors](https://github.com/Burtbox/MyHouseAPI/graphs/contributors) who participated in this project.

## License

This project is unlicensed

## Acknowledgments

* The Access Group (https://www.theaccessgroup.com/)
* Microsoft (https://www.microsoft.com/en-gb/)

