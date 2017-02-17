/****** Object:  Table [dbo].[tblEntity]    Script Date: 17/02/2017 3:34:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEntity](
	[IDNo] [int] IDENTITY(1,1) NOT NULL,
	[GUID] [uniqueidentifier] NULL,
	[Entity] [nvarchar](150) NULL,
	[Address] [nvarchar](150) NULL,
	[Remarks] [nvarchar](150) NULL,
	[VAT] [float] NULL,
	[DateAdded] [date] NULL,
	[DateUpdated] [date] NULL,
	[AddedByUserGuid] [nvarchar](50) NULL,
	[UpdatedByUserGuid] [nvarchar](50) NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_tblEntity] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO