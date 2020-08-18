CREATE PROCEDURE [dbo].[spEmails_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id], [Email], [CreatedDate] FROM dbo.Emails;
END
