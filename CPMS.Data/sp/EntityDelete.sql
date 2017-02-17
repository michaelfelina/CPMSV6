/****** Object:  StoredProcedure [dbo].[prc_EntityDelete]    Script Date: 17/02/2017 3:40:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[prc_EntityDelete]
	 @DBStatus INT OUTPUT
	,@IDNo int = null
	,@GUID uniqueidentifier = null
	,@Entity nvarchar(150) = null
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[tblEntity]
	Set Deleted = 1
	WHERE 
		[IDNo] = @IDNo
		AND ((@GUID IS NULL) OR [GUID] = @GUID)
		AND ((@Entity IS NULL) OR [Entity] = @Entity)

	SELECT  @DBStatus = @@ERROR

END
GO