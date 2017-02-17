SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prc_EntitySave]
	 @DBStatus INT OUTPUT
	,@NewID INT OUTPUT
	,@IDNo INT = null 
	,@GUID nvarchar(50) = null
	,@Entity nvarchar(150) = null
	,@Address nvarchar (max) = null	
	,@Remarks nvarchar(150) = null
	,@VAT float = null 
AS
BEGIN
	SET NOCOUNT ON;
	IF @IDNo = -1
		BEGIN
			INSERT INTO [dbo].[tblEntity]
			(
				 [GUID]
				,[Entity]
				,[Address]
				,[Remarks]
				,[VAT]
			)
			VALUES
			(
				 @GUID
				,@Entity
				,@Address
				,@Remarks
				,@VAT
			)
			
			Select @NewID =  @@Identity
		END
	ELSE
		BEGIN
			UPDATE [dbo].[tblEntity]
			 SET
			 [Entity] = @Entity
			,[Address] = @Address
			,[Remarks] = @Remarks
			,[VAT] = @VAT
			WHERE 
				[IDNo] = @IDNo
				AND ((@GUID IS NULL) OR [GUID] = @GUID)
		END

	SELECT  @DBStatus = @@ERROR
END