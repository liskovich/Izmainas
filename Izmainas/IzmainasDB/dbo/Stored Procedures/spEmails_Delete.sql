CREATE PROCEDURE [dbo].[spEmails_Delete]
	@Email NVARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Emails WHERE Email = @Email;
END
