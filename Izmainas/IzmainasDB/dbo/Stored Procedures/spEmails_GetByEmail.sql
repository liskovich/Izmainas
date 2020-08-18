CREATE PROCEDURE [dbo].[spEmails_GetByEmail]
	@Email NVARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id], [Email], [CreatedDate] FROM dbo.Emails WHERE Email = @Email;
END
