CREATE PROCEDURE [dbo].[spRecordsTemp_GetById]
	@Id NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id], [Teacher], [Room], [Note], [ClassNumber], [ClassLetter], [Lessons], [Date] FROM dbo.RecordsTemp WHERE Id = @Id;
END
