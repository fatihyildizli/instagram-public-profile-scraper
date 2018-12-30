USE [Northwind]
GO

/****** Object:  Table [dbo].[Instagram_Log]    Script Date: 30.12.2018 16:12:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Instagram_Log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Following] [nchar](10) NULL,
	[Followers] [nchar](10) NULL,
	[Posts] [nvarchar](max) NULL,
	[SnapShotTime] [datetime] NULL,
	[uri] [nvarchar](50) NULL,
	[IsPrivate] [bit] NULL,
	[LastPostLikes] [nvarchar](50) NULL,
	[LastPostImageUri] [nvarchar](max) NULL,
 CONSTRAINT [PK__Instagra__3214EC2711FE660E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


