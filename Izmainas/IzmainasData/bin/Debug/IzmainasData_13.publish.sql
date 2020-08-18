﻿/*
Deployment script for IzmainasData

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "IzmainasData"
:setvar DefaultFilePrefix "IzmainasData"
:setvar DefaultDataPath "C:\Users\sk\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\sk\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering [dbo].[spRecords_GetToday]...';


GO
ALTER PROCEDURE [dbo].[spRecords_GetToday]
	@Date DATETIME2
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id], [Teacher], [Room], [Note], [ClassNumber], [ClassLetter], [Lessons], [Date] FROM dbo.Records
	WHERE [Date] = CONVERT(datetime2, GETDATE());
	--CAST([Date] AS datetime2) = CAST(GETDATE() as datetime2);
END
GO
PRINT N'Update complete.';


GO
