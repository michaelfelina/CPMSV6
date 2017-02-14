/****** Object:  Table [dbo].[tblUserAccounts]    Script Date: 12/02/2017 11:20:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUserAccounts](
	[IDNo] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NULL,
	[EntityGuid] [uniqueidentifier] NULL,
	[Name] [nvarchar](150) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[Remarks] [nvarchar](max) NULL,
	[Photo] [image] NULL,
	[ValidFrom] [date] NULL,
	[ValidTo] [date] NULL,
	[DateAdded] [date] NULL,
	[DateUpdated] [date] NULL,
	[AddedByUser] [nvarchar](100) NULL,
	[AddedByUserGuid] [nvarchar](50) NULL,
	[UpdatedByUser] [nvarchar](100) NULL,
	[UpdatedByUserGuid] [nvarchar](50) NULL,
	[AccountType] [int] NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_tblUserAccounts] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO