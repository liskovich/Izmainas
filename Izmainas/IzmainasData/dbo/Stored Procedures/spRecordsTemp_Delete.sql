﻿CREATE PROCEDURE [dbo].[spRecordsTemp_Delete]
	@Id NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.RecordsTemp WHERE Id = @Id;
END
