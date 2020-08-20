CREATE PROCEDURE [dbo].[spRecords_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id], [Teacher], [Room], [Note], [ClassNumber], [ClassLetter], [Lessons], [Date] FROM dbo.Records
	ORDER BY [Date] DESC;
END