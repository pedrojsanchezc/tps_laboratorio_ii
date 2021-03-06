USE [master]
GO
CREATE DATABASE [TP4_2D_PedroSanchez]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP4_2D_PedroSanchez', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TP4_2D_PedroSanchez.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP4_2D_PedroSanchez_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TP4_2D_PedroSanchez_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP4_2D_PedroSanchez].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET RECOVERY FULL 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET  MULTI_USER 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TP4_2D_PedroSanchez', N'ON'
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET QUERY_STORE = OFF
GO
USE [TP4_2D_PedroSanchez]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProducType] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateSale] [datetime] NOT NULL,
	[Price] [float] NOT NULL,
	[SaleProducts] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProducType], [Description], [Price], [Quantity]) VALUES (1, 0, N'Escritorio de Madera 40x60cm', 100, 48)
INSERT [dbo].[Products] ([Id], [ProducType], [Description], [Price], [Quantity]) VALUES (2, 0, N'Mesa Plegable de Madera 100x130cm', 120, 49)
INSERT [dbo].[Products] ([Id], [ProducType], [Description], [Price], [Quantity]) VALUES (3, 0, N'Tablas de Madera para Pisos Flotantes', 200, 49)
INSERT [dbo].[Products] ([Id], [ProducType], [Description], [Price], [Quantity]) VALUES (4, 1, N'Lamina de Acero 1Pulgada', 100, 47)
INSERT [dbo].[Products] ([Id], [ProducType], [Description], [Price], [Quantity]) VALUES (5, 1, N'Tuberia de Acero', 130, 50)
INSERT [dbo].[Products] ([Id], [ProducType], [Description], [Price], [Quantity]) VALUES (6, 1, N'Cadenas de Acero', 100, 49)
INSERT [dbo].[Products] ([Id], [ProducType], [Description], [Price], [Quantity]) VALUES (7, 2, N'Aguarras', 80, 50)
INSERT [dbo].[Products] ([Id], [ProducType], [Description], [Price], [Quantity]) VALUES (8, 2, N'Balde Plastico', 200, 48)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([Id], [DateSale], [Price], [SaleProducts]) VALUES (1, CAST(N'2022-07-31T00:42:20.080' AS DateTime), 700, N'Balde Plastico x 1
Aguarras x 1
Cadenas de Acero x 1
Tuberia de Acero x 1
Lamina de Acero 1Pulgada x 1
')
SET IDENTITY_INSERT [dbo].[Sales] OFF
GO
USE [master]
GO
ALTER DATABASE [TP4_2D_PedroSanchez] SET  READ_WRITE 
GO
