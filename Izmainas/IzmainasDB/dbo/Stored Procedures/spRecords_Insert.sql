CREATE PROCEDURE [dbo].[spRecords_Insert]
	@Id NVARCHAR(50),
	@Teacher NVARCHAR(100),
	@Room NVARCHAR(100),
	@Note NVARCHAR(MAX),
	@ClassNumber NVARCHAR(50),
	@ClassLetter NVARCHAR(50),
	@Lessons NVARCHAR(100),
	@Date DATETIME2
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Records(Id, Teacher, Room, Note, ClassNumber, ClassLetter, Lessons, [Date])
	VALUES(@Id, @Teacher, @Room, @Note, @ClassNumber, @ClassLetter, @Lessons, @Date);
END
