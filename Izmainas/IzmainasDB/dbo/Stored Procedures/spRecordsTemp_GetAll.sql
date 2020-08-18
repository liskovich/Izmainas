CREATE PROCEDURE [dbo].[spRecordsTemp_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id], [Teacher], [Room], [Note], [ClassNumber], [ClassLetter], [Lessons], [Date] FROM dbo.RecordsTemp;
END
