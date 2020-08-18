CREATE PROCEDURE [dbo].[spRecords_Edit]
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
	UPDATE dbo.Records
	SET Teacher = @Teacher, Room = @Room, Note = @Note, ClassNumber = @ClassNumber, ClassLetter = @ClassLetter,
	Lessons = @Lessons, [Date] = @Date WHERE Id = @Id;
END
