CREATE PROCEDURE [dbo].[spRecords_GetById]
	@Id NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id], [Teacher], [Room], [Note], [ClassNumber], [ClassLetter], [Lessons], [Date] FROM dbo.Records WHERE Id = @Id;
END
