/****** Object:  StoredProcedure [dbo].[prc_EntitySelect]    Script Date: 17/02/2017 3:42:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[prc_EntitySelect]
	 @DBStatus INT OUTPUT
	,@IDNo int = null
	,@GUID nvarchar(50) = null
	,@Entity nvarchar(150) = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		 [IDNo]
		,[GUID]
		,[Entity]
		,[Address]		
		,[Remarks]
		,[VAT]
	FROM [dbo].[tblEntity] WITH (NOLOCK) 
	WHERE 
		((@IDNo IS NULL) OR [IDNo] = @IDNo)
		AND ((@GUID IS NULL) OR [GUID] = @GUID)
		AND ((@Entity IS NULL) OR [Entity] = @Entity)
		AND ([Deleted] != 1 OR [Deleted] is null)
	ORDER BY [Entity], [Address]

	SELECT  @DBStatus = @@ERROR

END
GO
