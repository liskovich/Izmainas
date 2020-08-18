CREATE PROCEDURE [dbo].[spEmails_GetById]
	@Id NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id], [Email], [CreatedDate] FROM dbo.Emails WHERE Id = @Id;
END
