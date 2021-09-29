USE [demo]
GO
/****** Object:  Table [dbo].[City]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NULL,
	[Sid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Cid] [int] IDENTITY(1,1) NOT NULL,
	[CName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[relation]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[relation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SchoolId] [int] NULL,
	[ClassId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[English] [int] NULL,
	[Hindi] [int] NULL,
	[Math] [int] NULL,
	[Science] [int] NULL,
	[StudentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RId] [int] IDENTITY(1,1) NOT NULL,
	[RName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[schools]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schools](
	[SchoolId] [int] IDENTITY(1,1) NOT NULL,
	[SchoolName] [varchar](50) NULL,
	[SchoolEmail] [varchar](50) NULL,
	[SchoolAddress] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Sid] [int] IDENTITY(1,1) NOT NULL,
	[SName] [varchar](50) NULL,
	[Cid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NULL,
	[StudentAddress] [varchar](50) NULL,
	[StudentRollNo] [bigint] NULL,
	[Id] [int] NULL,
	[ResultId] [int] NULL,
	[Cid] [int] NULL,
	[Sid] [int] NULL,
	[Cityid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserPass] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[Rid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (1, N'Nizamuddin', 1)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (2, N'New Delhi', 1)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (3, N'Ghaziabad', 2)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (4, N'Noida', 2)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (5, N'Girathalana.', 3)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (6, N'Panagamuwa', 3)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (7, N'Dehiwala', 4)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (8, N'Moratuwa', 4)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (9, N'Albany', 5)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (10, N'Amsterdam', 5)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (11, N'Anchorage', 6)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (12, N'Juneau', 6)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (13, N'Quetta', 7)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (14, N'Turbat', 7)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (15, N'Peshawar', 8)
INSERT [dbo].[City] ([CityId], [CityName], [Sid]) VALUES (16, N'Mardan', 8)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (1, N'Nursery')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (2, N'LKG')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (3, N'UKG')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (4, N'I')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (5, N'II')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (6, N'III')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (7, N'IV')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (8, N'V')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (9, N'VI')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (10, N'VII')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (11, N'VIII')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (12, N'IX')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (13, N'X')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (14, N'XI')
INSERT [dbo].[Classes] ([ClassId], [ClassName]) VALUES (15, N'XII')
SET IDENTITY_INSERT [dbo].[Classes] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Cid], [CName]) VALUES (1, N'India')
INSERT [dbo].[Country] ([Cid], [CName]) VALUES (2, N'ShriLanka')
INSERT [dbo].[Country] ([Cid], [CName]) VALUES (3, N'US')
INSERT [dbo].[Country] ([Cid], [CName]) VALUES (4, N'Pakistan')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[relation] ON 

INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (1, 1, 1)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (2, 1, 2)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (3, 1, 3)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (4, 1, 4)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (5, 1, 5)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (6, 1, 6)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (7, 1, 7)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (8, 1, 8)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (9, 1, 9)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (10, 1, 10)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (11, 1, 11)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (12, 1, 12)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (13, 1, 13)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (14, 1, 14)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (15, 2, 1)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (16, 2, 2)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (17, 2, 3)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (18, 2, 4)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (19, 2, 5)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (20, 2, 6)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (21, 2, 7)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (22, 2, 8)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (23, 2, 9)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (24, 2, 10)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (25, 2, 11)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (26, 2, 12)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (27, 2, 13)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (28, 2, 14)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (29, 3, 1)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (30, 3, 2)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (31, 3, 3)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (32, 3, 4)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (33, 3, 5)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (34, 3, 6)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (35, 3, 7)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (36, 3, 8)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (37, 3, 9)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (38, 3, 10)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (39, 3, 11)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (40, 3, 12)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (41, 3, 13)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (42, 3, 14)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (43, 1, 15)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (44, 2, 15)
INSERT [dbo].[relation] ([Id], [SchoolId], [ClassId]) VALUES (45, 3, 15)
SET IDENTITY_INSERT [dbo].[relation] OFF
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (1, 56, 76, 56, 33, 1)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (2, 26, 36, 23, 31, 2)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (3, 23, 34, 23, 12, 3)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (4, 34, 45, 84, 98, 4)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (5, 74, 78, 98, 78, 5)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (6, 45, 84, 75, 48, 6)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (7, 74, 95, 87, 85, 7)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (8, 45, 75, 82, 87, 8)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (9, 95, 78, 87, 93, 9)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (10, 75, 45, 84, 60, 10)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (11, 41, 78, 98, 84, 11)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (12, 75, 65, 25, 63, 12)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (13, 43, 71, 67, 47, 13)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (14, 46, 72, 47, 36, 14)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (15, 76, 39, 72, 63, 15)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (16, 48, 76, 90, 76, 16)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (17, 79, 85, 97, 37, 17)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (18, 58, 26, 71, 78, 18)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (19, 67, 63, 22, 25, 19)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (20, 74, 56, 26, 34, 20)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (21, 57, 71, 97, 78, 21)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (22, 56, 76, 56, 33, 22)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (23, 26, 36, 23, 31, 23)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (24, 23, 34, 23, 12, 24)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (25, 34, 45, 84, 98, 25)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (26, 74, 78, 98, 78, 26)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (27, 45, 84, 75, 48, 27)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (28, 74, 95, 87, 85, 28)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (29, 45, 75, 82, 87, 29)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (30, 95, 78, 87, 93, 30)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (31, 75, 45, 84, 60, 31)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (32, 41, 78, 98, 84, 32)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (33, 75, 65, 25, 63, 33)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (34, 43, 71, 67, 47, 34)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (35, 46, 72, 47, 36, 35)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (36, 76, 39, 72, 63, 36)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (37, 48, 76, 90, 76, 37)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (38, 79, 85, 97, 37, 38)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (39, 58, 26, 71, 78, 39)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (40, 67, 63, 22, 25, 40)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (41, 74, 56, 26, 34, 41)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (42, 57, 71, 97, 78, 42)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (43, 56, 76, 56, 33, 43)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (44, 26, 36, 23, 31, 44)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (45, 23, 34, 23, 12, 45)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (46, 34, 45, 84, 98, 46)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (47, 74, 78, 98, 78, 47)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (48, 45, 84, 75, 48, 48)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (49, 74, 95, 87, 85, 49)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (50, 45, 75, 82, 87, 50)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (51, 95, 78, 87, 93, 51)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (52, 75, 45, 84, 60, 52)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (53, 41, 78, 98, 84, 53)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (54, 75, 65, 25, 63, 54)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (55, 43, 71, 67, 47, 55)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (56, 46, 72, 47, 36, 56)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (57, 76, 39, 72, 63, 57)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (58, 48, 76, 90, 76, 58)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (59, 79, 85, 97, 37, 59)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (60, 58, 26, 71, 78, 60)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (61, 67, 63, 22, 25, 61)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (62, 74, 56, 26, 34, 62)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (63, 57, 71, 97, 78, 63)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (64, 56, 76, 56, 33, 64)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (65, 26, 36, 23, 31, 65)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (66, 23, 34, 23, 12, 66)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (67, 34, 45, 84, 98, 67)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (68, 74, 78, 98, 78, 68)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (69, 45, 84, 75, 48, 69)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (70, 74, 95, 87, 85, 70)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (71, 45, 75, 82, 87, 71)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (72, 95, 78, 87, 93, 72)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (73, 75, 45, 84, 60, 73)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (74, 41, 78, 98, 84, 74)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (75, 75, 65, 25, 63, 75)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (76, 43, 71, 67, 47, 76)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (77, 46, 72, 47, 36, 77)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (78, 76, 39, 72, 63, 78)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (79, 48, 76, 90, 76, 79)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (80, 79, 85, 97, 37, 80)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (81, 58, 26, 71, 78, 81)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (82, 67, 63, 22, 25, 82)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (83, 74, 56, 26, 34, 83)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (84, 57, 71, 97, 78, 84)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (85, 56, 76, 56, 33, 85)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (86, 26, 36, 23, 31, 86)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (87, 23, 34, 23, 12, 87)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (88, 34, 45, 84, 98, 88)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (89, 74, 78, 98, 78, 89)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (90, 45, 84, 75, 48, 90)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (91, 74, 95, 87, 85, 91)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (92, 45, 75, 82, 87, 92)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (93, 95, 78, 87, 93, 93)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (94, 75, 45, 84, 60, 94)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (95, 41, 78, 98, 84, 95)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (96, 75, 65, 25, 63, 96)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (97, 43, 71, 67, 47, 97)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (98, 46, 72, 47, 36, 98)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (99, 76, 39, 72, 63, 99)
GO
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (100, 48, 76, 90, 76, 100)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (101, 79, 85, 97, 37, 101)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (102, 58, 26, 71, 78, 102)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (103, 67, 63, 22, 25, 103)
INSERT [dbo].[Results] ([ResultId], [English], [Hindi], [Math], [Science], [StudentId]) VALUES (104, 74, 56, 26, 34, 104)
SET IDENTITY_INSERT [dbo].[Results] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RId], [RName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RId], [RName]) VALUES (2, N'Teacher')
INSERT [dbo].[Roles] ([RId], [RName]) VALUES (3, N'Student')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[schools] ON 

INSERT [dbo].[schools] ([SchoolId], [SchoolName], [SchoolEmail], [SchoolAddress]) VALUES (1, N'CPS', N'cps@gmail.com', N'Modinagar')
INSERT [dbo].[schools] ([SchoolId], [SchoolName], [SchoolEmail], [SchoolAddress]) VALUES (2, N'Dayawati', N'dayawati@gmail.com', N'Modinagar')
INSERT [dbo].[schools] ([SchoolId], [SchoolName], [SchoolEmail], [SchoolAddress]) VALUES (3, N'TRM', N'trm@gmail.com', N'Modinagar')
SET IDENTITY_INSERT [dbo].[schools] OFF
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([Sid], [SName], [Cid]) VALUES (1, N'Delhi', 1)
INSERT [dbo].[States] ([Sid], [SName], [Cid]) VALUES (2, N'UP', 1)
INSERT [dbo].[States] ([Sid], [SName], [Cid]) VALUES (3, N'Kurunegala', 2)
INSERT [dbo].[States] ([Sid], [SName], [Cid]) VALUES (4, N'Colombo', 2)
INSERT [dbo].[States] ([Sid], [SName], [Cid]) VALUES (5, N'New York', 3)
INSERT [dbo].[States] ([Sid], [SName], [Cid]) VALUES (6, N'Alaska', 3)
INSERT [dbo].[States] ([Sid], [SName], [Cid]) VALUES (7, N'Balochistan', 4)
INSERT [dbo].[States] ([Sid], [SName], [Cid]) VALUES (8, N'Khyber', 4)
SET IDENTITY_INSERT [dbo].[States] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (1, N'Student101', N'Address101', 1001, 1, 1, 1, 1, 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (2, N'Student102', N'Address102', 1002, 2, 2, 2, 3, 5)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (3, N'Student103', N'Address103', 1003, 3, 3, 3, 5, 9)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (4, N'Student104', N'Address104', 1004, 4, 4, 4, 7, 13)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (5, N'Student105', N'Address105', 1005, 5, 5, 1, 2, 3)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (6, N'Student106', N'Address106', 1006, 6, 6, 2, 4, 7)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (7, N'Student107', N'Address107', 1007, 7, 7, 3, 6, 11)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (8, N'Student108', N'Address108', 1008, 8, 8, 4, 8, 15)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (9, N'Student119', N'Address109', 1009, 9, 9, 1, 1, 2)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (10, N'Student110', N'Address110', 1010, 10, 10, 2, 3, 6)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (11, N'Student111', N'Address111', 1011, 11, 11, 3, 5, 10)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (12, N'Student112', N'Address112', 1012, 12, 12, 4, 7, 14)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (13, N'Student113', N'Address113', 1013, 13, 13, 1, 2, 4)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (14, N'Student114', N'Address114', 1014, 14, 14, 2, 4, 8)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (15, N'Student115', N'Address115', 1015, 15, 15, 3, 6, 12)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (16, N'Student116', N'Address116', 1016, 16, 16, 4, 8, 16)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (17, N'Student117', N'Address117', 1017, 17, 17, 1, 1, 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (18, N'Student118', N'Address118', 1018, 18, 18, 2, 3, 5)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (19, N'Student119', N'Address119', 1019, 19, 19, 3, 5, 9)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (20, N'Student120', N'Address120', 1020, 20, 20, 4, 7, 13)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (21, N'Student121', N'Address121', 1021, 21, 21, 1, 2, 3)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (22, N'Student122', N'Address122', 1022, 22, 22, 2, 4, 7)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (23, N'Student123', N'Address123', 1023, 23, 23, 3, 6, 11)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (24, N'Student124', N'Address124', 1024, 24, 24, 4, 8, 15)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (25, N'Student125', N'Address125', 1025, 25, 25, 1, 1, 2)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (26, N'Student126', N'Address126', 1026, 26, 26, 2, 3, 6)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (27, N'Student127', N'Address127', 1027, 27, 27, 3, 5, 10)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (28, N'Student128', N'Address128', 1028, 28, 28, 4, 7, 14)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (29, N'Student129', N'Address129', 1029, 29, 29, 1, 2, 4)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (30, N'Student130', N'Address130', 1030, 30, 30, 2, 4, 8)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (31, N'Student131', N'Address131', 1031, 31, 31, 3, 6, 12)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (32, N'Student132', N'Address132', 1032, 32, 32, 4, 8, 16)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (33, N'Student133', N'Address133', 1033, 33, 33, 1, 1, 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (34, N'Student134', N'Address134', 1034, 34, 34, 2, 3, 5)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (35, N'Student135', N'Address135', 1035, 35, 35, 3, 5, 9)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (36, N'Student136', N'Address136', 1036, 36, 36, 4, 7, 13)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (37, N'Student137', N'Address137', 1037, 37, 37, 1, 2, 3)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (38, N'Student138', N'Address138', 1038, 38, 38, 2, 4, 7)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (39, N'Student139', N'Address139', 1039, 39, 39, 3, 6, 11)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (40, N'Student140', N'Address140', 1040, 40, 40, 4, 8, 15)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (41, N'Student141', N'Address141', 1041, 41, 41, 1, 1, 2)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (42, N'Student142', N'Address142', 1042, 42, 42, 2, 3, 6)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (43, N'Student143', N'Address143', 1043, 1, 43, 3, 5, 10)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (44, N'Student144', N'Address144', 1044, 2, 44, 4, 7, 14)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (45, N'Student145', N'Address145', 1045, 3, 45, 1, 2, 4)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (46, N'Student146', N'Address146', 1046, 4, 46, 2, 4, 8)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (47, N'Student147', N'Address147', 1047, 5, 47, 3, 6, 12)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (48, N'Student148', N'Address148', 1048, 6, 48, 4, 8, 16)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (49, N'Student149', N'Address149', 1049, 7, 49, 1, 1, 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (50, N'Student150', N'Address150', 1050, 8, 50, 2, 3, 5)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (51, N'Student151', N'Address151', 1051, 9, 51, 3, 5, 9)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (52, N'Student152', N'Address152', 1052, 10, 52, 4, 7, 13)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (53, N'Student153', N'Address153', 1053, 11, 53, 1, 2, 3)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (54, N'Student154', N'Address154', 1054, 12, 54, 2, 4, 7)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (55, N'Student155', N'Address155', 1055, 13, 55, 3, 6, 11)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (56, N'Student156', N'Address156', 1056, 14, 56, 4, 8, 15)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (57, N'Student157', N'Address157', 1057, 15, 57, 1, 1, 2)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (58, N'Student158', N'Address158', 1058, 16, 58, 2, 3, 6)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (59, N'Student159', N'Address159', 1059, 17, 59, 3, 5, 10)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (60, N'Student160', N'Address160', 1060, 18, 60, 4, 7, 14)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (61, N'Student161', N'Address161', 1061, 19, 61, 1, 2, 4)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (62, N'Student162', N'Address162', 1062, 20, 62, 2, 4, 8)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (63, N'Student163', N'Address163', 1063, 21, 63, 3, 6, 12)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (64, N'Student164', N'Address164', 1064, 22, 64, 4, 8, 16)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (65, N'Student165', N'Address165', 1065, 23, 65, 1, 1, 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (66, N'Student166', N'Address166', 1066, 24, 66, 2, 3, 5)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (67, N'Student167', N'Address167', 1067, 25, 67, 3, 5, 9)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (68, N'Student168', N'Address168', 1068, 26, 68, 4, 7, 13)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (69, N'Student169', N'Address169', 1069, 27, 69, 1, 2, 3)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (70, N'Student170', N'Address170', 1070, 28, 70, 2, 4, 7)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (71, N'Student171', N'Address171', 1071, 29, 71, 3, 6, 11)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (72, N'Student172', N'Address172', 1072, 30, 72, 4, 8, 15)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (73, N'Student173', N'Address173', 1073, 31, 73, 1, 1, 2)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (74, N'Student174', N'Address174', 1074, 32, 74, 2, 3, 6)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (75, N'Student175', N'Address175', 1075, 33, 75, 3, 5, 10)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (76, N'Student176', N'Address176', 1076, 34, 76, 4, 7, 14)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (77, N'Student177', N'Address177', 1077, 35, 77, 1, 2, 4)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (78, N'Student178', N'Address178', 1078, 36, 78, 2, 4, 8)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (79, N'Student179', N'Address179', 1079, 37, 79, 3, 6, 12)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (80, N'Student180', N'Address180', 1080, 38, 80, 4, 8, 16)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (81, N'Student181', N'Address181', 1081, 39, 81, 1, 1, 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (82, N'Student182', N'Address182', 1082, 40, 82, 2, 3, 5)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (83, N'Student183', N'Address183', 1083, 41, 83, 3, 5, 9)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (84, N'Student184', N'Address184', 1084, 42, 84, 4, 7, 13)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (85, N'Student185', N'Address185', 1085, 1, 85, 1, 2, 3)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (86, N'Student186', N'Address186', 1086, 2, 86, 2, 4, 7)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (87, N'Student187', N'Address187', 1087, 3, 87, 3, 6, 11)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (88, N'Student188', N'Address188', 1088, 4, 88, 4, 8, 15)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (89, N'Student189', N'Address189', 1089, 5, 89, 1, 1, 2)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (90, N'Student190', N'Address190', 1090, 6, 90, 2, 3, 6)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (91, N'Student191', N'Address191', 1091, 7, 91, 3, 5, 10)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (92, N'Student192', N'Address192', 1092, 8, 92, 4, 7, 14)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (93, N'Student193', N'Address193', 1093, 9, 93, 1, 2, 4)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (94, N'Student194', N'Address194', 1094, 10, 94, 2, 4, 8)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (95, N'Student195', N'Address195', 1095, 11, 95, 3, 6, 12)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (96, N'Student196', N'Address196', 1096, 12, 96, 4, 8, 16)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (97, N'Student197', N'Address197', 1097, 13, 97, 1, 1, 1)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (98, N'Student198', N'Address198', 1098, 14, 98, 2, 3, 5)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (99, N'Student199', N'Address199', 1099, 15, 99, 3, 5, 9)
GO
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (100, N'Student200', N'Address200', 1200, 16, 100, 4, 7, 13)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (101, N'Student201', N'Address201', 1201, 17, 101, 1, 2, 3)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (102, N'Student202', N'Address202', 1202, 18, 102, 2, 4, 7)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (103, N'Student203', N'Address203', 1203, 19, 103, 3, 6, 11)
INSERT [dbo].[Students] ([StudentId], [StudentName], [StudentAddress], [StudentRollNo], [Id], [ResultId], [Cid], [Sid], [Cityid]) VALUES (104, N'Student204', N'Address204', 1204, 20, 104, 4, 8, 15)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[UserLogin] ON 

INSERT [dbo].[UserLogin] ([UserId], [UserName], [UserPass], [IsActive], [Rid]) VALUES (1, N'gaurav', N'987878', 1, 1)
INSERT [dbo].[UserLogin] ([UserId], [UserName], [UserPass], [IsActive], [Rid]) VALUES (2, N'gagan', N'12345', 1, 2)
INSERT [dbo].[UserLogin] ([UserId], [UserName], [UserPass], [IsActive], [Rid]) VALUES (3, N'gopal', N'12345', 1, 3)
SET IDENTITY_INSERT [dbo].[UserLogin] OFF
ALTER TABLE [dbo].[City]  WITH CHECK ADD FOREIGN KEY([Sid])
REFERENCES [dbo].[States] ([Sid])
GO
ALTER TABLE [dbo].[relation]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
GO
ALTER TABLE [dbo].[relation]  WITH CHECK ADD FOREIGN KEY([SchoolId])
REFERENCES [dbo].[schools] ([SchoolId])
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[States]  WITH CHECK ADD FOREIGN KEY([Cid])
REFERENCES [dbo].[Country] ([Cid])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([Cid])
REFERENCES [dbo].[Country] ([Cid])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([Cityid])
REFERENCES [dbo].[City] ([CityId])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[relation] ([Id])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([ResultId])
REFERENCES [dbo].[Results] ([ResultId])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([Sid])
REFERENCES [dbo].[States] ([Sid])
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD FOREIGN KEY([Rid])
REFERENCES [dbo].[Roles] ([RId])
GO
/****** Object:  StoredProcedure [dbo].[sp_ClassById]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_ClassById]
@id int
as
begin
select * from Classes where ClassId=@id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ClassList]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_ClassList]
as
begin
select * from Classes
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Country]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Country]
as
begin
	select * from Country
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteStudent]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_DeleteStudent]
@sid int
as
begin
	delete from Students where StudentId = @sid
end
GO
/****** Object:  StoredProcedure [dbo].[sp_edit]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_edit]
@id int
as
begin
	select * from Students join relation on Students.Id = relation.Id where StudentId = @id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getcitybyId]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_getcitybyId]
@sid int
as
begin
	select * from City where Sid = @sid
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertStudent]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_InsertStudent]  
@Name varchar(50),  
@Address varchar(50),  
@RollNo bigint,  
@realtionId int,
@cid int,
@sid int,
@cityid int
as  
begin  
	insert into Students (StudentName, StudentAddress, StudentRollNo, Id, Cid, Sid, CityId)  
	values (@Name, @Address, @RollNo, @realtionId, @cid, @sid, @cityid)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Login]  
@username varchar(50),  
@userpass varchar(50)  
as  
begin  
select * from UserLogin join Roles on UserLogin.Rid = Roles.RId  
where UserName = @username and UserPass = @userpass  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Relation]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Relation]
@SchoolId int,
@ClassId int
as
begin
select * from relation where relation.SchoolId = @SchoolId and relation.ClassId = @ClassId
end
GO
/****** Object:  StoredProcedure [dbo].[sp_SchoolById]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_SchoolById]
@id int
as
begin
select * from schools where SchoolId = @id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_SchoolList]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_SchoolList]  
as  
begin  
select * from schools  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_State]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_State]
@id int
as
begin
	select * from States where Cid = @id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_StudentByClassId]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_StudentByClassId]
@classId int,
@schoolId int
as 
begin 
	select Students.StudentId, Students.StudentName, Students.StudentRollNo, Students.StudentAddress, Classes.ClassName, schools.SchoolName from Students join relation 
	on Students.Id = relation.Id
	join Classes on
	relation.ClassId = Classes.ClassId
	join schools on
	relation.SchoolId = schools.SchoolId
	where Classes.ClassId = @classId and schools.SchoolId = @schoolId
end
GO
/****** Object:  StoredProcedure [dbo].[sp_StudentById]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_StudentById]  
@sid int  
as  
begin  
 select Students.StudentId, Students.StudentName, Students.StudentRollNo, StudentAddress, Classes.ClassName,  
 (English + Hindi + Science + Math)/4 as StudentResult  
 from Students join relation on Students.Id = relation.Id  
 join Classes on relation.ClassId = Classes.ClassId  
 join Results on Students.StudentId = Results.StudentId  
 where Students.StudentId = @sid  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_StudentBySchool]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_StudentBySchool]  
@schoolId int  
as  
begin  
 select Students.StudentId, Students.StudentName, Students.StudentRollNo,
 Classes.ClassId, schools.SchoolId, Students.Cid, Students.Sid, Students.Cityid,  
 Students.StudentAddress, Classes.ClassName, schools.SchoolName   
 from Students join relation  
 on Students.Id = relation.Id  
 join Classes on  
 relation.ClassId = Classes.ClassId  
 join schools on  
 relation.SchoolId = schools.SchoolId  
 where schools.SchoolId = @schoolId  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_StudentResultClassId]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_StudentResultClassId]
@classId int,
@schoolId int
as
begin
	select Students.StudentId, Students.StudentName, Students.StudentRollNo,
	Students.StudentAddress, Classes.ClassName, schools.SchoolName,(Results.English + Results.Hindi + Results.Math + Results.Science)/4 as StudentResult 
	from Students join relation on
	Students.Id = relation.Id
	join Classes on
	relation.ClassId = Classes.ClassId
	join schools on
	relation.SchoolId = schools.SchoolId
	join Results on
	Results.StudentId = Students.StudentId
	where Classes.ClassId = @classId and schools.SchoolId = @schoolId
end
GO
/****** Object:  StoredProcedure [dbo].[sp_StudentResultschoolId]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_StudentResultschoolId]
@schoolId int
as
begin
	select Students.StudentId, Students.StudentName, Students.StudentRollNo,
	Students.StudentAddress, Classes.ClassName, schools.SchoolName,(Results.English + Results.Hindi + Results.Math + Results.Science)/4 as StudentResult,
	Classes.ClassId
	from Students join relation on
	Students.Id = relation.Id
	join Classes on
	relation.ClassId = Classes.ClassId
	join schools on
	relation.SchoolId = schools.SchoolId
	join Results on
	Results.StudentId = Students.StudentId
	where schools.SchoolId = @schoolId
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStudent]    Script Date: 14/Sep/21 12:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_UpdateStudent]  
@id int,  
@name varchar(50),  
@address varchar(100),  
@rollNo bigint,  
@relationid int,
@cid int,
@sid int,
@cityid int
as  
begin  
	update Students set StudentName=@name, StudentAddress=@address, StudentRollNo=@rollNo,  
	Id=@relationid, Cid = @cid, Sid = @sid, CityId = @cityid where StudentId = @id  
end
GO
