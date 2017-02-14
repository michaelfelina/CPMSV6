/****** Object:  StoredProcedure [dbo].[prc_UserSelect]    Script Date: 13/02/2017 12:43:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[prc_UserSelect]
	 @DBStatus INT OUTPUT
	,@IDNo int = null
	,@AccountType int = null
	,@UserName nvarchar (50) = null
	,@Guid uniqueidentifier = null
	,@EntityGuid uniqueidentifier = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		 [IDNo]
		,[Guid]
		,[Name]
		,[UserName]
		,[Password]
		,[Remarks]
		,[Photo]
		,[AccountType]
		,[ValidFrom]
		,[ValidTo]
		,[DateAdded]
		,[DateUpdated]
		,[AddedByUser]
		,[AddedByUserGuid]
		,[UpdatedByUser]
		,[UpdatedByUserGuid]
		,[Deleted]
	FROM [dbo].[tblUserAccounts] WITH (NOLOCK) 
	WHERE 
		((@IDNo IS NULL) OR [IDNo] = @IDNo)
		AND ((@Guid IS NULL) OR [Guid] = @Guid)
		AND ((@EntityGuid IS NULL) OR [EntityGuid] = @EntityGuid)
		AND ((@UserName IS NULL) OR [UserName] = @UserName)
		AND [Deleted] = 0
		AND [AccountType] = @AccountType

	SELECT  @DBStatus = @@ERROR

END

