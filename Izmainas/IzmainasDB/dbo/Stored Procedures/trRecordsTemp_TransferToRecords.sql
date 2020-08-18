CREATE PROCEDURE [dbo].[trRecordsTemp_TransferToRecords]
AS
BEGIN
	SET NOCOUNT ON;
	--BEGIN TRANSACTION;
	INSERT INTO dbo.Records (Id, Teacher, Room, Note, ClassNumber, ClassLetter, Lessons, [Date])
	SELECT [Id], [Teacher], [Room], [Note], [ClassNumber], [ClassLetter], [Lessons], [Date] FROM dbo.RecordsTemp;
	
	DELETE FROM dbo.RecordsTemp;
	--COMMIT;
END
