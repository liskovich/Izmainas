﻿CREATE TABLE [dbo].[RecordsTemp]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
	[Teacher] NVARCHAR(100) NULL, 
	[Room] NVARCHAR(100) NULL, 
	[Note] NVARCHAR(MAX) NULL, 
	[ClassNumber] NVARCHAR(50) NULL, 
	[ClassLetter] NVARCHAR(50) NULL, 
	[Lessons] NVARCHAR(100) NULL, 
	[Date] DATETIME2 NULL
)