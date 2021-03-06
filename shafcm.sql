USE [SHAFCM]
GO
/****** Object:  Table [dbo].[FCM]    Script Date: 24/03/2017 10:26:00 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FCM](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[token] [nvarchar](200) NULL,
 CONSTRAINT [PK_FCM] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
