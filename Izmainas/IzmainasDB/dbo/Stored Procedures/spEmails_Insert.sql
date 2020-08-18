CREATE PROCEDURE [dbo].[spEmails_Insert]
	@Id NVARCHAR(50),
	@Email NVARCHAR(200),
	@CreatedDate DATETIME2
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Emails (Id, Email, CreatedDate)
	VALUES (@Id, @Email, @CreatedDate);
END
