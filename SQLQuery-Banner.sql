USE [greenhouse.banner]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 09/23/2015 10:21:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BannerName] [nvarchar](250) NOT NULL,
	[BannerImage] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Position] [int] NOT NULL,
	[DateTimeCreate] [datetime] NOT NULL,
	[DateTimeModify] [datetime] NULL,
	[GuidCreate] [uniqueidentifier] NOT NULL,
	[GuidModify] [uniqueidentifier] NULL,
	[BannerDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Banner] ON
INSERT [dbo].[Banner] ([Id], [BannerName], [BannerImage], [IsActive], [Position], [DateTimeCreate], [DateTimeModify], [GuidCreate], [GuidModify], [BannerDescription]) VALUES (1, N'Banner 1', N'6-8-2015-17-51-24-831.jpg', 1, 1, CAST(0x0000A4EC012645E8 AS DateTime), CAST(0x0000A4EC012810CD AS DateTime), N'b47e77d0-63c7-4b6a-95b9-14dbf8c598ff', N'07b615e6-d670-4c2d-9a29-084313268517', NULL)
INSERT [dbo].[Banner] ([Id], [BannerName], [BannerImage], [IsActive], [Position], [DateTimeCreate], [DateTimeModify], [GuidCreate], [GuidModify], [BannerDescription]) VALUES (2, N'Banner 2', N'6-8-2015-18-04-44-855.JPG', 1, 2, CAST(0x0000A4EC0129EF6B AS DateTime), NULL, N'da8ed53d-7c9c-4dad-89d8-ae9da9ae3692', NULL, NULL)
INSERT [dbo].[Banner] ([Id], [BannerName], [BannerImage], [IsActive], [Position], [DateTimeCreate], [DateTimeModify], [GuidCreate], [GuidModify], [BannerDescription]) VALUES (3, N'Banner 3', N'6-8-2015-18-08-23-772.jpg', 1, 3, CAST(0x0000A4EC012A8667 AS DateTime), CAST(0x0000A4EC012AEFE6 AS DateTime), N'dd8eb7db-f982-4388-b0a9-3f26a54a2dd0', N'd0c2615c-e526-4183-8292-32ea1699fdd0', NULL)
INSERT [dbo].[Banner] ([Id], [BannerName], [BannerImage], [IsActive], [Position], [DateTimeCreate], [DateTimeModify], [GuidCreate], [GuidModify], [BannerDescription]) VALUES (4, N'Banner 4', N'6-8-2015-18-08-42-648.jpg', 1, 4, CAST(0x0000A4EC012B0632 AS DateTime), NULL, N'3f08b117-ab69-4192-812e-7d8443ad21b9', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Banner] OFF
