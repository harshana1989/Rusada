CREATE TABLE [dbo].[Spotter]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[MakeId] int,
	[ModelId] int,
	[Registration] nvarchar(7),
	[Location] nvarchar(255),
	[Date] datetime,
	[IsActive] bit DEFAULT 'True',
	constraint FK_MakeId Foreign Key (MakeId) References Make(Id),
	constraint FK_AirlineModelId Foreign Key ([ModelId]) References AirlineModel(Id)
)
