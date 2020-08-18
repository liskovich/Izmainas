CREATE PROCEDURE [dbo].[spRecords_GetByDate]
	@Date DATETIME2
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id], [Teacher], [Room], [Note], [ClassNumber], [ClassLetter], [Lessons], [Date] FROM dbo.Records
	WHERE [Date] = @Date;
END
