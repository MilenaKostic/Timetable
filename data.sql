USE [master]
GO
/****** Object:  Database [BusTimetable]    Script Date: 13/12/2023 15:30:19 ******/
CREATE DATABASE [BusTimetable]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BusTimetable', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BusTimetable.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BusTimetable_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BusTimetable_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BusTimetable] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BusTimetable].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BusTimetable] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BusTimetable] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BusTimetable] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BusTimetable] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BusTimetable] SET ARITHABORT OFF 
GO
ALTER DATABASE [BusTimetable] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BusTimetable] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BusTimetable] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BusTimetable] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BusTimetable] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BusTimetable] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BusTimetable] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BusTimetable] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BusTimetable] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BusTimetable] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BusTimetable] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BusTimetable] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BusTimetable] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BusTimetable] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BusTimetable] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BusTimetable] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BusTimetable] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BusTimetable] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BusTimetable] SET  MULTI_USER 
GO
ALTER DATABASE [BusTimetable] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BusTimetable] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BusTimetable] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BusTimetable] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BusTimetable] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BusTimetable] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BusTimetable] SET QUERY_STORE = ON
GO
ALTER DATABASE [BusTimetable] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BusTimetable]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiryTime] [datetime2](7) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalendarDates]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarDates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CalendarDates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendars]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Monday] [bit] NOT NULL,
	[Tuesday] [bit] NOT NULL,
	[Wednesday] [bit] NOT NULL,
	[Thursday] [bit] NOT NULL,
	[Friday] [bit] NOT NULL,
	[Saturday] [bit] NOT NULL,
	[Sunday] [bit] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Calendars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Routes]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteName] [nvarchar](max) NULL,
	[RouteColor] [nvarchar](max) NULL,
 CONSTRAINT [PK_Routes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RouteStops]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteStops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[Rbr] [int] NOT NULL,
	[StopId] [int] NOT NULL,
	[TimeInterval] [int] NULL,
	[MetarDistance] [int] NULL,
 CONSTRAINT [PK_RouteStops] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shapes]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shapes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[RBr] [int] NOT NULL,
	[Lat] [float] NOT NULL,
	[Lon] [float] NOT NULL,
 CONSTRAINT [PK_Shapes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stops]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StopName] [nvarchar](max) NULL,
	[StopLat] [float] NOT NULL,
	[StopLon] [float] NOT NULL,
 CONSTRAINT [PK_Stops] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StopTimes]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StopTimes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StopId] [int] NOT NULL,
	[StopSequence] [int] NOT NULL,
	[TripId] [int] NOT NULL,
 CONSTRAINT [PK_StopTimes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trips]    Script Date: 13/12/2023 15:30:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trips](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK_Trips] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231204170229_INIT', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231204171215_Auth', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231204175239_Auth2', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231212002447_shape', N'6.0.25')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2b1f5ea6-5564-4f0b-8738-81a025d427c0', N'User', N'USER', N'9ccc329e-8cfa-42fc-81af-ba190e4d4dc1')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'35fb1668-5d1c-470e-927d-d6fe71b6ed08', N'Manager', N'MANAGER', N'3fd48e73-c284-4eb1-88eb-41e85bf9ae9b')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd28fa00a-1ba5-4d3d-9608-5516f218c669', N'Admin', N'ADMIN', N'bb8bb48d-49e8-41c6-8463-8a17796ec9b6')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator]) VALUES (N'598f7adf-ea83-41eb-a31a-9a73130e1c94', N'string', N'string', N'YuuGS/i/YSAvfrWIUDc7qlEoq7IZF45y8Jl8wpDJudE=', CAST(N'2023-12-16T01:15:23.8622623' AS DateTime2), N'string2', N'STRING2', N'string2@gmail.com', N'STRING2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPle1VORQBrLCYmZfUrmco97b0CmqnIS4zFhB7KxzAJ9877W4P2vZubW162Vudvytg==', N'XG7ZINGULBNVARVQ4ZI7PYLX6PG6EZTQ', N'5ccd3af3-130b-4eac-8ed9-616e5bf7e1f3', N'string', 0, 0, NULL, 1, 0, N'User')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator]) VALUES (N'd4d3d13c-295a-4a68-9a69-33b3ddb78c97', N'string', N'string', N'n7eqsivznXJPjOkH0SvfpB0eVo1CvZc3J7KN2uUCwhc=', CAST(N'2023-12-20T15:16:56.4257252' AS DateTime2), N'string1', N'STRING1', N'string1@gmail.com', N'STRING1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECM/BQjmzxeZ/2e1y6yunDfjG/qXNVEZyhiMTmVh576HxyhzJoAgwWtVlGRvrNsFfA==', N'HIO4C7JOLTQZME2WFU3YGMRSNAINLRDE', N'a64b791c-a24b-40aa-8b53-768c33f4bfac', N'string', 0, 0, NULL, 1, 0, N'User')
GO
SET IDENTITY_INSERT [dbo].[Routes] ON 

INSERT [dbo].[Routes] ([Id], [RouteName], [RouteColor]) VALUES (5, N'Kamenjar-Crvena česma', N'#4287f5')
INSERT [dbo].[Routes] ([Id], [RouteName], [RouteColor]) VALUES (6, N'Laćarak-Kuper-Mala Bosna', N'#b32e2e')
INSERT [dbo].[Routes] ([Id], [RouteName], [RouteColor]) VALUES (7, N'Laćarak-Industrijska zona-Groblje', N'#2e3bb3')
SET IDENTITY_INSERT [dbo].[Routes] OFF
GO
SET IDENTITY_INSERT [dbo].[RouteStops] ON 

INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (18, 6, 1, 10, 1, 1)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (19, 6, 2, 9, 1, 1)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (20, 6, 3, 12, 1, 1)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (21, 6, 4, 14, 1, 1)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (22, 5, 1, 23, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (23, 5, 2, 15, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (25, 5, 4, 14, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (26, 7, 2, 20, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (28, 7, 3, 22, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (29, 7, 4, 14, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (30, 5, 3, 24, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (31, 7, 1, 11, 0, 0)
SET IDENTITY_INSERT [dbo].[RouteStops] OFF
GO
SET IDENTITY_INSERT [dbo].[Shapes] ON 

INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (128, 6, 1, 44.972426470848454, 19.606845558038696)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (129, 6, 2, 44.972426470848454, 19.606845558038696)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (130, 6, 3, 44.97220635802443, 19.609391802801888)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (131, 6, 4, 44.97220635802443, 19.609391802801888)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (132, 6, 5, 44.97176612984196, 19.61488383152221)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (133, 6, 6, 44.97176612984196, 19.61488383152221)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (134, 6, 7, 44.970415063631641, 19.63567201835798)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (135, 6, 8, 44.970415063631641, 19.63567201835798)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (136, 6, 9, 44.970396087756, 19.636621950167953)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (137, 6, 10, 44.970396087756, 19.636621950167953)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (138, 6, 11, 44.970248075710344, 19.63696499130377)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (139, 6, 12, 44.970248075710344, 19.63696499130377)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (140, 6, 13, 44.970320184190548, 19.637126596845356)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (141, 6, 14, 44.970320184190548, 19.637126596845356)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (142, 6, 15, 44.97043403950105, 19.637210151675333)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (143, 6, 16, 44.97043403950105, 19.637210151675333)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (144, 6, 17, 44.970582051066771, 19.637098658631015)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (145, 6, 18, 44.970582051066771, 19.637098658631015)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (146, 6, 19, 44.970536509087225, 19.636755406835988)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (147, 6, 20, 44.970536509087225, 19.636755406835988)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (148, 6, 21, 44.970475786391582, 19.636283435617841)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (149, 6, 22, 44.970475786391582, 19.636283435617841)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (150, 6, 23, 44.970749038015704, 19.631113205455403)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (151, 6, 24, 44.970749038015704, 19.631113205455403)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (152, 6, 25, 44.97172058880264, 19.618048184007531)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (153, 6, 26, 44.97172058880264, 19.618048184007531)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (154, 6, 27, 44.972312619493209, 19.609724327978324)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (155, 6, 28, 44.972312619493209, 19.609724327978324)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (156, 6, 29, 44.96942830977234, 19.608716025830468)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (157, 6, 30, 44.96942830977234, 19.608716025830468)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (162, 5, 1, 44.976684349238433, 19.593816752602972)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (163, 5, 2, 44.976684349238433, 19.593816752602972)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (164, 5, 3, 44.975621806693972, 19.595337466622006)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (165, 5, 4, 44.975621806693972, 19.595337466622006)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (166, 5, 5, 44.974119034339793, 19.597528162636596)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (167, 5, 6, 44.974119034339793, 19.597528162636596)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (168, 5, 7, 44.973337273553874, 19.59855237953261)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (169, 5, 8, 44.973337273553874, 19.59855237953261)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (170, 5, 9, 44.973018494252372, 19.598868569751218)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (171, 5, 10, 44.973018494252372, 19.598868569751218)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (172, 5, 11, 44.972908439082033, 19.598863776330479)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (173, 5, 12, 44.972908439082033, 19.598863776330479)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (174, 5, 13, 44.972783203631309, 19.598967794299398)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (175, 5, 14, 44.972783203631309, 19.598967794299398)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (176, 5, 15, 44.972771818576781, 19.599145391091707)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (177, 5, 16, 44.972771818576781, 19.599145391091707)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (178, 5, 17, 44.97291223409141, 19.599300543439838)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (179, 5, 18, 44.97291223409141, 19.599300543439838)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (180, 5, 19, 44.972965364196511, 19.599369080301585)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (181, 5, 20, 44.972965364196511, 19.599369080301585)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (182, 5, 21, 44.972991929230595, 19.599665260668097)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (183, 5, 22, 44.972991929230595, 19.599665260668097)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (184, 5, 23, 44.972859103937125, 19.601060322018455)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (185, 5, 24, 44.972859103937125, 19.601060322018455)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (186, 5, 25, 44.972434060930759, 19.606720874771945)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (187, 5, 26, 44.972434060930759, 19.606720874771945)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (188, 5, 27, 44.97220635802443, 19.609230903522988)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (189, 5, 28, 44.97220635802443, 19.609230903522988)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (190, 5, 29, 44.97219497285537, 19.609487378141456)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (191, 5, 30, 44.97219497285537, 19.609487378141456)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (192, 5, 31, 44.969306861970246, 19.608737479067653)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (193, 5, 32, 44.969306861970246, 19.608737479067653)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (228, 7, 1, 44.981336535830764, 19.613851066667213)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (229, 7, 2, 44.981336535830764, 19.613851066667213)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (230, 7, 3, 44.981693213186986, 19.613899377474013)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (231, 7, 4, 44.981693213186986, 19.613899377474013)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (232, 7, 5, 44.981697007615004, 19.614478584942315)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (233, 7, 6, 44.981697007615004, 19.614478584942315)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (234, 7, 7, 44.9816628577537, 19.615849227195692)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (235, 7, 8, 44.9816628577537, 19.615849227195692)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (236, 7, 9, 44.981571791357375, 19.618144723574872)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (237, 7, 10, 44.981571791357375, 19.618144723574872)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (238, 7, 11, 44.97972007659309, 19.617093514952643)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (239, 7, 12, 44.97972007659309, 19.617093514952643)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (240, 7, 13, 44.9788093752624, 19.61641773798118)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (241, 7, 14, 44.9788093752624, 19.61641773798118)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (242, 7, 15, 44.977564726717496, 19.615495248782072)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (243, 7, 16, 44.977564726717496, 19.615495248782072)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (244, 7, 17, 44.9772611498033, 19.616353378269622)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (245, 7, 18, 44.9772611498033, 19.616353378269622)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (246, 7, 19, 44.976376972883457, 19.615967350091516)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (247, 7, 20, 44.976376972883457, 19.615967350091516)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (248, 7, 21, 44.975299245240244, 19.615532759054759)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (249, 7, 22, 44.975299245240244, 19.615532759054759)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (250, 7, 23, 44.975230937876084, 19.615490221788328)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (251, 7, 24, 44.975230937876084, 19.615490221788328)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (252, 7, 25, 44.975113297224837, 19.615345351457041)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (253, 7, 26, 44.975113297224837, 19.615345351457041)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (254, 7, 27, 44.975071553709917, 19.615205785672188)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (255, 7, 28, 44.975071553709917, 19.615205785672188)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (256, 7, 29, 44.975014630686083, 19.615120027051308)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (257, 7, 30, 44.975014630686083, 19.615120027051308)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (258, 7, 31, 44.9749425281081, 19.615130662753828)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (259, 7, 32, 44.9749425281081, 19.615130662753828)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (260, 7, 33, 44.974893194713033, 19.61518436237078)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (261, 7, 34, 44.974893194713033, 19.61518436237078)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (262, 7, 35, 44.9748248868652, 19.615221904427123)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (263, 7, 36, 44.9748248868652, 19.615221904427123)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (264, 7, 37, 44.97474898916105, 19.615280859806258)
GO
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (265, 7, 38, 44.97474898916105, 19.615280859806258)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (266, 7, 39, 44.974627552625478, 19.615307686331338)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (267, 7, 40, 44.974627552625478, 19.615307686331338)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (268, 7, 41, 44.974411243159523, 19.61523228733861)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (269, 7, 42, 44.974411243159523, 19.61523228733861)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (270, 7, 43, 44.9718875724367, 19.614295384245743)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (271, 7, 44, 44.9718875724367, 19.614295384245743)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (272, 7, 45, 44.971265176420445, 19.613494405490222)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (273, 7, 46, 44.971265176420445, 19.613494405490222)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (274, 7, 47, 44.970050725722018, 19.611912558171571)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (275, 7, 48, 44.970050725722018, 19.611912558171571)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (276, 7, 49, 44.969397947845941, 19.610732630126179)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (277, 7, 50, 44.969397947845941, 19.610732630126179)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (278, 7, 51, 44.9687299813985, 19.608952011439523)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (279, 7, 52, 44.9687299813985, 19.608952011439523)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (280, 7, 53, 44.968748957825404, 19.608736425032518)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (281, 7, 54, 44.968748957825404, 19.608736425032518)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (282, 7, 55, 44.968836249308218, 19.608630212881721)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (283, 7, 56, 44.968836249308218, 19.608630212881721)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (284, 7, 57, 44.968972879188527, 19.608575505796416)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (285, 7, 58, 44.968972879188527, 19.608575505796416)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (286, 7, 59, 44.969318247712621, 19.608677421977831)
INSERT [dbo].[Shapes] ([Id], [RouteId], [RBr], [Lat], [Lon]) VALUES (287, 7, 60, 44.969318247712621, 19.608677421977831)
SET IDENTITY_INSERT [dbo].[Shapes] OFF
GO
SET IDENTITY_INSERT [dbo].[Stops] ON 

INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (7, N'Stari most', 44.9733266395123, 19.5985337094836)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (8, N'KPZ', 44.9928598410139, 19.6102496756179)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (9, N'Malta', 44.9705088283079, 19.6354904926363)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (10, N'Bolnica', 44.97234603268, 19.6070807994653)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (11, N'Glavna stanica', 44.981754930056, 19.614005517108)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (12, N'SDK', 44.9720959091366, 19.6108558729326)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (13, N'Stelina', 44.9719976372496, 19.614026005402)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (14, N'Posta', 44.9691527398884, 19.608675632226)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (15, N'Lipa', 44.9756878368478, 19.5948411114508)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (16, N'Gimnazija', 44.9683959952577, 19.6056577732654)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (17, N'Secer sokak', 4496956493824234, 1960600116328174)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (18, N'MM', 44.965253394063531, 19.59919774858389)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (19, N'Lipa2', 44.97323860395943, 19.598897282319662)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (20, N'Orlovo naselje', 44.977245970915384, 19.616388711274659)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (21, N'MH-Zmajeva skola', 44.973101984240685, 19.614693223069228)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (22, N'Hala Pinki 2', 44.971686432999419, 19.613942836180925)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (23, N'TC Stop sop', 44.976714707307536, 19.593767893951252)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (24, N'Stari most2', 44.973648461162846, 19.597952959774823)
SET IDENTITY_INSERT [dbo].[Stops] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 13/12/2023 15:30:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 13/12/2023 15:30:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 13/12/2023 15:30:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 13/12/2023 15:30:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 13/12/2023 15:30:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 13/12/2023 15:30:19 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 13/12/2023 15:30:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RouteStops_RouteId]    Script Date: 13/12/2023 15:30:19 ******/
CREATE NONCLUSTERED INDEX [IX_RouteStops_RouteId] ON [dbo].[RouteStops]
(
	[RouteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RouteStops_StopId]    Script Date: 13/12/2023 15:30:19 ******/
CREATE NONCLUSTERED INDEX [IX_RouteStops_StopId] ON [dbo].[RouteStops]
(
	[StopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Discriminator]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[RouteStops]  WITH CHECK ADD  CONSTRAINT [FK_RouteStops_Routes_RouteId] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Routes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RouteStops] CHECK CONSTRAINT [FK_RouteStops_Routes_RouteId]
GO
ALTER TABLE [dbo].[RouteStops]  WITH CHECK ADD  CONSTRAINT [FK_RouteStops_Stops_StopId] FOREIGN KEY([StopId])
REFERENCES [dbo].[Stops] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RouteStops] CHECK CONSTRAINT [FK_RouteStops_Stops_StopId]
GO
USE [master]
GO
ALTER DATABASE [BusTimetable] SET  READ_WRITE 
GO
