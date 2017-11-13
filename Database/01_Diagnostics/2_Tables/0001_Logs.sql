IF OBJECT_ID(N'[Diagnostics].[Logs]', 'U') IS NULL
BEGIN
	CREATE TABLE [Diagnostics].[Logs] (

	   [Id] int IDENTITY(1,1) NOT NULL,
	   [Message] nvarchar(max) NULL,
	   [MessageTemplate] nvarchar(max) NULL,
	   [Level] nvarchar(128) NULL,
	   [TimeStamp] datetimeoffset(7) NOT NULL,  -- use datetime for SQL Server pre-2008
	   [Exception] nvarchar(max) NULL,
	   [Properties] xml NULL,
	   [LogEvent] nvarchar(max) NULL

	   CONSTRAINT [PK__Diagnostics__Logs] 
		 PRIMARY KEY CLUSTERED ([Id] ASC) 
		 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
			   ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
		 ON [PRIMARY]

	) ON [PRIMARY]
END
GO