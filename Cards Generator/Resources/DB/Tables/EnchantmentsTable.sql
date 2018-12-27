CREATE TABLE [dbo].[EnchantmentsTable]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NOT NULL, 
    [IsRanged] BIT NOT NULL, 
    [RangeLower] INT NULL, 
    [RangeHigher] INT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL
)
