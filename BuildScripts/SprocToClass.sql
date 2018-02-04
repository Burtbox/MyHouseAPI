DECLARE @conversionTable table

    (

  sqlType varchar(50)

      ,
  cType varchar(50)

    );



INSERT INTO @conversionTable
  ( sqlType, cType )

VALUES

  ( 'bigint', 'Int64' )

  ,
  ( 'binary', 'byte[]' )

  ,
  ( 'bit', 'bool' )

  ,
  ( 'char', 'string' )

  ,
  ( 'date', 'DateTime?' ) -- Make the DateTime types optional to prevent the c# default causing sql to error

  ,
  ( 'datetime', 'DateTime?' )

  ,
  ( 'datetime2', 'DateTime?' )

  ,
  (

    'datetimeoffset'

      , 'DateTimeOffset?'

    )

  ,
  ( 'decimal', 'decimal' )

  ,
  ( 'float', 'double' )

  ,
  ( 'image', 'byte[]' )

  ,
  ( 'int', 'int' )

  ,
  ( 'money', 'decimal' )

  ,
  ( 'nchar', 'string' )

  ,
  ( 'ntext', 'string' )

  ,
  ( 'numeric', 'decimal' )

  ,
  ( 'nvarchar', 'string' )

  ,
  ( 'real', 'single' )

  ,
  ( 'rowversion', 'byte[]' )

  ,
  ( 'smalldatetime', 'DateTime?' )

  ,
  ( 'smallint', 'Int16' )

  ,
  ( 'smallmoney', 'decimal' )

  ,
  ( 'sql_variant', 'object' )

  ,
  ( 'text', 'string' )

  ,
  ( 'time', 'TimeSpan' )

  ,
  ( 'timestamp', 'byte[]' )

  ,
  ( 'tinyint', 'byte' )

  ,
  ( 'uniqueidentifier', 'Guid' )

  ,
  ( 'varbinary', 'byte[]' )

  ,
  ( 'varchar', 'string' )

  ,
  ( 'xml', 'Xml' );



SELECT

  'public'                 AS [Accessor]

  , (

        SELECT

    cType

  FROM @conversionTable

  WHERE sqlType = Type_Name( user_type_id )

    )                        AS [Type]

  , Replace( name, '@', '' ) AS [Parameter_name]

  , '{ get; set; }'          AS [GetSet]

-- TYPE_NAME(user_type_id) AS [SQLType],

-- is_output

FROM sys.parameters

WHERE object_id = Object_Id( 'Houses.Households_Insert' );

--  AND is_output = 1;

 