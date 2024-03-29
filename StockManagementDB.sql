USE [master]
GO
/****** Object:  Database [StockManagementDB]    Script Date: 11/12/2019 11:18:06 PM ******/
CREATE DATABASE [StockManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockManagementDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockManagementDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockManagementDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockManagementDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StockManagementDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StockManagementDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StockManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StockManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [StockManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockManagementDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StockManagementDB]
GO
/****** Object:  Table [dbo].[AdminTable]    Script Date: 11/12/2019 11:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_AdminTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CatagoryTable]    Script Date: 11/12/2019 11:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatagoryTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Catagory] [varchar](50) NULL,
 CONSTRAINT [PK_CatagoryTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyTable]    Script Date: 11/12/2019 11:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Company] [varchar](50) NULL,
 CONSTRAINT [PK_CompanyTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemTable]    Script Date: 11/12/2019 11:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NULL,
	[ReorderLevel] [int] NULL,
	[CatagoryId] [int] NULL,
	[CompanyId] [int] NULL,
	[AvailableQuantity] [int] NULL,
 CONSTRAINT [PK_ItemTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockOutTable]    Script Date: 11/12/2019 11:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOutTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Item] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[Condition] [varchar](50) NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_StockOutTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AdminTable] ON 

INSERT [dbo].[AdminTable] ([Id], [Name], [Password]) VALUES (1, N'Tanim', N'12345')
INSERT [dbo].[AdminTable] ([Id], [Name], [Password]) VALUES (2, N'Mushfiq', N'12345')
INSERT [dbo].[AdminTable] ([Id], [Name], [Password]) VALUES (3, N'Showmik', N'12345')
SET IDENTITY_INSERT [dbo].[AdminTable] OFF
SET IDENTITY_INSERT [dbo].[CatagoryTable] ON 

INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1012, N'Electronics')
INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1013, N'Bevarages')
INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1014, N'Stationaries')
INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1015, N'Cosmetics')
INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1016, N'Bakery')
INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1017, N'Men''s Fashion')
INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1018, N'Women''s Fashion')
INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1019, N'Sports')
INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1020, N'Home Appliances')
INSERT [dbo].[CatagoryTable] ([Id], [Catagory]) VALUES (1021, N'Groceries')
SET IDENTITY_INSERT [dbo].[CatagoryTable] OFF
SET IDENTITY_INSERT [dbo].[CompanyTable] ON 

INSERT [dbo].[CompanyTable] ([Id], [Company]) VALUES (2008, N'Pran')
INSERT [dbo].[CompanyTable] ([Id], [Company]) VALUES (2009, N'RFL')
INSERT [dbo].[CompanyTable] ([Id], [Company]) VALUES (2010, N'Unilever')
INSERT [dbo].[CompanyTable] ([Id], [Company]) VALUES (2011, N'Walton')
INSERT [dbo].[CompanyTable] ([Id], [Company]) VALUES (2012, N'Aarong')
INSERT [dbo].[CompanyTable] ([Id], [Company]) VALUES (2013, N'Matador')
INSERT [dbo].[CompanyTable] ([Id], [Company]) VALUES (2014, N'Xiaomi')
SET IDENTITY_INSERT [dbo].[CompanyTable] OFF
SET IDENTITY_INSERT [dbo].[ItemTable] ON 

INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1013, N'All Time Bun', 10, 1016, 2008, 50)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1014, N'Full Sleeve T-Shirt', 5, 1017, 2012, 12)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1015, N'Vision LED TV', 5, 1012, 2009, 10)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1016, N'Vision Electronic Iron', 5, 1012, 2009, 5)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1017, N'Vision GD Refrigerator', 2, 1012, 2009, 3)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1018, N'Classic Bowl', 15, 1020, 2009, 36)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1019, N'Metal Pen', 12, 1014, 2009, 60)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1020, N'Color Pencil Large', 12, 1014, 2009, 24)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1021, N'Paper Basket', 10, 1014, 2009, 6)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1022, N'Stamp Pad', 5, 1014, 2009, 10)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1023, N'Primo F3', 5, 1012, 2011, 12)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1024, N'Air Purifier', 2, 1020, 2011, 5)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1025, N'Dish Washer', 5, 1020, 2011, 15)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1026, N'Hair Dryer', 15, 1018, 2011, 10)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1027, N'Silk Fatua', 10, 1017, 2012, 12)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1028, N'Blue Embroidered Silk-Cotton Panjabi ', 5, 1017, 2012, 10)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1029, N'Printed Shalwar Kameez', 5, 1018, 2012, 10)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1030, N'Frutix', 5, 1013, 2008, 15)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1031, N'Mango Fruit', 10, 1013, 2008, 30)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1032, N'Clear Shampoo', 10, 1015, 2010, 7)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1033, N'Dove Men+ Care', 10, 1015, 2010, 20)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1034, N'Matador Pencilic', 12, 1014, 2013, 24)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1035, N'Matador WoodMark', 12, 1014, 2013, 36)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1036, N'Xiaomi MI Sports Shows', 10, 1019, 2014, 10)
INSERT [dbo].[ItemTable] ([Id], [ItemName], [ReorderLevel], [CatagoryId], [CompanyId], [AvailableQuantity]) VALUES (1037, N'Xiaomi WalkingPad', 10, 1019, 2014, 5)
SET IDENTITY_INSERT [dbo].[ItemTable] OFF
SET IDENTITY_INSERT [dbo].[StockOutTable] ON 

INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2023, N'All Time Bun', N'Pran', 10, N'Sell', CAST(0x0000AB0301638887 AS DateTime))
INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2024, N'Clear Shampoo', N'Unilever', 5, N'Sell', CAST(0x0000AB0301638892 AS DateTime))
INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2025, N'Full Sleeve T-Shirt', N'Aarong', 3, N'Sell', CAST(0x0000AB030163889B AS DateTime))
INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2026, N'Classic Bowl', N'RFL', 12, N'Sell', CAST(0x0000AB03016388A4 AS DateTime))
INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2027, N'Frutix', N'Pran', 10, N'Sell', CAST(0x0000AB03016388AF AS DateTime))
INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2028, N'Clear Shampoo', N'Unilever', 1, N'Damage', CAST(0x0000AB0301640309 AS DateTime))
INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2029, N'Silk Fatua', N'Aarong', 2, N'Damage', CAST(0x0000AB0301640312 AS DateTime))
INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2030, N'Clear Shampoo', N'Unilever', 2, N'Damage', CAST(0x0000AB0301640319 AS DateTime))
INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2031, N'All Time Bun', N'Pran', 10, N'Lost', CAST(0x0000AB0301643CCF AS DateTime))
INSERT [dbo].[StockOutTable] ([Id], [Item], [Company], [Quantity], [Condition], [TimeStamp]) VALUES (2032, N'Silk Fatua', N'Aarong', 1, N'Lost', CAST(0x0000AB0301643CDB AS DateTime))
SET IDENTITY_INSERT [dbo].[StockOutTable] OFF
ALTER TABLE [dbo].[ItemTable]  WITH CHECK ADD  CONSTRAINT [FK_ItemTable_CatagoryTable] FOREIGN KEY([CatagoryId])
REFERENCES [dbo].[CatagoryTable] ([Id])
GO
ALTER TABLE [dbo].[ItemTable] CHECK CONSTRAINT [FK_ItemTable_CatagoryTable]
GO
ALTER TABLE [dbo].[ItemTable]  WITH CHECK ADD  CONSTRAINT [FK_ItemTable_CompanyTable] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[CompanyTable] ([Id])
GO
ALTER TABLE [dbo].[ItemTable] CHECK CONSTRAINT [FK_ItemTable_CompanyTable]
GO
USE [master]
GO
ALTER DATABASE [StockManagementDB] SET  READ_WRITE 
GO
