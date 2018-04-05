/*
	HOUSEHOLDS -- ID, NAME
	OCCUPANTS -- USERID, HOUSEHOLDID, OCCUPANTID, DISPLAYNAME
*/

/* HouseholdId check: 
	In BaseController.cs / BaseRepository.cs -- will need to handle arrays check all items have same ID then check single
	we need to run a sproc that checks the HouseholdId is one that the user has
	All API calls require UserId (from firebase) and HouseholdId (from api call)
	Check pareing is valid then carry on
*/

/*
	Manage inredients screen, can edit,delete -> dedupe if exists elsewhere, else delete
	TIme - regex validate, form 1d 1h 30m 10s, save in minute, round up (i.e. 5.1 => 6)
	Need CLone recipie option
*/

-- Top col is PK

-- organise Lookups, Main tables, link tables
-- write in PKs and FKs
-- index every FK
-- not nulls
-- security is where clause on householdId server side
CREATE SCHEMA Food;
GO
CREATE TABLE Food.IngredientsLookup -- needs a rethink or figure out design around this
(
    IngredientId INT IDENTITY(1, 1),
    [Name] NVARCHAR(100)
);

CREATE TABLE Food.Recipies -- serve discovery screen as a mass user sub style thing
(
    RecipieId INT IDENTITY(1, 1),
    HouseholdId INT,
    --FK to household
    [Name] NVARCHAR(100),
    Serves INT,
    PrepTIme INT,
    CookTime INT,
    [Description] NVARCHAR(500),
    [Picture] VARBINARY(MAX),
    -- FILESTREAM for large images
    [Private] BIT,
    --hides it from everyone else's discover screen -- used with HouseholdId to keep a recipie to your household only
    ComplexityId TINYINT,
    -- fk to  RecipiesComplexity
    [CreatedDate] DATETIME2(3),
    -- default db level to today GETUTCDATE()
    [CreatedBy] NVARCHAR(36),
    -- FK to Houses.Occupants.OccupantId
    [ModifiedDate] DATETIME2(3),
    -- default db level to today GETUTCDATE()
    [ModifiedBy] NVARCHAR(36),
    -- FK to Houses.Occupants.OccupantId
);

CREATE TABLE Food.RecipiesComplexityLookUp
(
    ComplexityId TINYINT,
    [Name] NVARCHAR(50)
    -- Easy, Meduim, Hard
);

CREATE TABLE Food.RecipieSteps
(
    RecipieStepId INT IDENTITY(1, 1),
    RecipieId INT,
    -- FK to Recipies + index
    Step NVARCHAR(4000),
    [CreatedDate] DATETIME2(3),
    -- default db level to today GETUTCDATE()
    [CreatedBy] NVARCHAR(36),
    -- FK to Houses.Occupants.OccupantId
    [ModifiedDate] DATETIME2(3),
    -- default db level to today GETUTCDATE()
    [ModifiedBy] NVARCHAR(36),
    -- FK to Houses.Occupants.OccupantId
);

CREATE TABLE Food.RecipieIngredients
(
    RecipieIngredientId INT IDENTITY(1, 1),
    RecipieId INT,
    --FK to Recipies + index
    [Name] NVARCHAR(200),
    -- not FK as user sub
    Quantity DECIMAL(10, 2),
    UnitsID INT,
    -- FK to UnitsLookup, optional field
    [CreatedDate] DATETIME2(3),
    -- default db level to today GETUTCDATE()
    [CreatedBy] NVARCHAR(36),
    -- FK to Houses.Occupants.OccupantId
    [ModifiedDate] DATETIME2(3),
    -- default db level to today GETUTCDATE()
    [ModifiedBy] NVARCHAR(36),
    -- FK to Houses.Occupants.OccupantId
);

CREATE TABLE Food.HouseholdRecipies
(
    HouseholdRecipieId INT IDENTITY(1, 1),
    HouseholdId INT,
    -- fk to households -- index
    RecipieId INT
    -- fk to recipies  -- index
);

CREATE TABLE Food.RecipieVotes
(
    UserId VARCHAR(36),
    RecipieId INT,
    -- FK to recipies
    [Date] DATETIME2(3)
);

CREATE TABLE Food.RecipieCategories
(
    RecipieCategoryId INT IDENTITY(1, 1),
    CategoryId INT,
    -- FK to categoriesLookUp 
    RecipieId INT
    -- FK to recipies
);

CREATE TABLE Food.CategoriesLookUp
(
    CategoryId INT IDENTITY(1, 1),
    [Name] NVARCHAR(200)
);

CREATE TABLE Food.UnitsLookup
(
    UnitId INT IDENTITY(1, 1),
    [Name] NVARCHAR(10)
);

CREATE TABLE Food.ShoppingList
(
    ShoppingListId INT IDENTITY(1, 1),
    [Name] NVARCHAR(50),
    -- front end default to date to id list easily
    Complete BIT,
    -- DEFAULT ((0))
    [CreatedDate] DATETIME2(3),
    -- default db level to today GETUTCDATE()
    [CreatedBy] NVARCHAR(36),
    -- FK to Houses.Occupants.OccupantId
    [ModifiedDate] DATETIME2(3),
    -- default db level to today GETUTCDATE()
    [ModifiedBy] NVARCHAR(36),
    -- FK to Houses.Occupants.OccupantId
);

CREATE TABLE Food.ShoppingListIems
(
    ShoppingListItemId INT IDENTITY(1, 1),
    ItemName NVARCHAR(200),
    Quantity DECIMAL(10, 2),
    UnitsID INT,
    -- FK to UnitsLookup, optional field
    Bought BIT
    -- DEFAULT ((0))
);

CREATE TABLE Food.MealPlan
(
    MealPlanId INT IDENTITY(1,1),
    HouseholdId INT,
    -- Link to households
    RecipieId INT,
    -- Link to receipies
    DateId INT
);

CREATE TABLE Food.MealAttendees
(
    MealAttendeeId INT IDENTITY(1,1),
    DateId INT,
    [Name] NVARCHAR(50)
)

CREATE TABLE Food.DateLookup
(
    DateId INT IDENTITY(1,1),
    [Date] NVARCHAR(10)
    -- format dd/MM/YYYY
)
