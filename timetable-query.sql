USE [master]
GO
/****** Object:  Database [Timetable]    Script Date: 27/11/2023 14:27:07 ******/
CREATE DATABASE [Timetable]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Timetable', FILENAME = N'E:\SqlData\Timetable.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Timetable_log', FILENAME = N'E:\SqlData\Timetable_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Timetable] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Timetable].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Timetable] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Timetable] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Timetable] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Timetable] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Timetable] SET ARITHABORT OFF 
GO
ALTER DATABASE [Timetable] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Timetable] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Timetable] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Timetable] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Timetable] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Timetable] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Timetable] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Timetable] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Timetable] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Timetable] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Timetable] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Timetable] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Timetable] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Timetable] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Timetable] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Timetable] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Timetable] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Timetable] SET RECOVERY FULL 
GO
ALTER DATABASE [Timetable] SET  MULTI_USER 
GO
ALTER DATABASE [Timetable] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Timetable] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Timetable] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Timetable] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Timetable] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Timetable] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Timetable] SET QUERY_STORE = ON
GO
ALTER DATABASE [Timetable] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Timetable]
GO
/****** Object:  Table [dbo].[CalendarDates]    Script Date: 27/11/2023 14:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarDates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendars]    Script Date: 27/11/2023 14:27:08 ******/
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
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Routes]    Script Date: 27/11/2023 14:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteName] [nvarchar](50) NOT NULL,
	[RouteColor] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__routes__3214EC0795824CF7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RouteStops]    Script Date: 27/11/2023 14:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteStops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[Rbr] [int] NOT NULL,
	[StopId] [int] NOT NULL,
	[TimeDistance] [int] NULL,
	[MetarDistance] [int] NULL,
 CONSTRAINT [PK_RouteStop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stops]    Script Date: 27/11/2023 14:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StopName] [text] NOT NULL,
	[StopLat] [float] NOT NULL,
	[StopLon] [float] NOT NULL,
 CONSTRAINT [PK__stops__72B081883E9D0EA3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StopTimes]    Script Date: 27/11/2023 14:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StopTimes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TripId] [int] NOT NULL,
	[StopId] [int] NOT NULL,
	[StopSequence] [int] NOT NULL,
 CONSTRAINT [PK__stopTime__3214EC07F3D9C565] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trips]    Script Date: 27/11/2023 14:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trips](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK__trips__303EBF8597703709] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27/11/2023 14:27:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__Users__3214EC27F7F6CA40] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CalendarDates] ON 

INSERT [dbo].[CalendarDates] ([Id], [ServiceId], [Date]) VALUES (6, 1, CAST(N'2023-12-12' AS Date))
INSERT [dbo].[CalendarDates] ([Id], [ServiceId], [Date]) VALUES (7, 1, CAST(N'2023-11-13' AS Date))
INSERT [dbo].[CalendarDates] ([Id], [ServiceId], [Date]) VALUES (8, 1, CAST(N'2023-11-13' AS Date))
INSERT [dbo].[CalendarDates] ([Id], [ServiceId], [Date]) VALUES (9, 2, CAST(N'2023-11-13' AS Date))
INSERT [dbo].[CalendarDates] ([Id], [ServiceId], [Date]) VALUES (11, 1, CAST(N'2023-11-17' AS Date))
SET IDENTITY_INSERT [dbo].[CalendarDates] OFF
GO
SET IDENTITY_INSERT [dbo].[Calendars] ON 

INSERT [dbo].[Calendars] ([Id], [Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday], [Sunday], [StartDate], [EndDate]) VALUES (1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2023-12-14' AS Date), CAST(N'2023-12-14' AS Date))
INSERT [dbo].[Calendars] ([Id], [Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday], [Sunday], [StartDate], [EndDate]) VALUES (2, 1, 1, 1, 1, 1, 1, 1, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-12' AS Date))
INSERT [dbo].[Calendars] ([Id], [Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday], [Sunday], [StartDate], [EndDate]) VALUES (3, 1, 1, 1, 1, 1, 0, 0, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-12' AS Date))
INSERT [dbo].[Calendars] ([Id], [Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday], [Sunday], [StartDate], [EndDate]) VALUES (4, 0, 1, 1, 1, 1, 0, 0, CAST(N'2023-11-12' AS Date), CAST(N'2023-11-12' AS Date))
INSERT [dbo].[Calendars] ([Id], [Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday], [Sunday], [StartDate], [EndDate]) VALUES (5, 1, 1, 1, 1, 1, 1, 1, CAST(N'2023-11-13' AS Date), CAST(N'2023-11-13' AS Date))
INSERT [dbo].[Calendars] ([Id], [Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday], [Sunday], [StartDate], [EndDate]) VALUES (6, 1, 1, 1, 1, 1, 1, 1, CAST(N'2023-11-13' AS Date), CAST(N'2023-11-13' AS Date))
INSERT [dbo].[Calendars] ([Id], [Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday], [Sunday], [StartDate], [EndDate]) VALUES (7, 1, 1, 1, 1, 1, 1, 1, CAST(N'2023-11-20' AS Date), CAST(N'2023-11-30' AS Date))
SET IDENTITY_INSERT [dbo].[Calendars] OFF
GO
SET IDENTITY_INSERT [dbo].[Routes] ON 

INSERT [dbo].[Routes] ([Id], [RouteName], [RouteColor]) VALUES (1, N'Kamenjar-Crvena česma', N'plava')
INSERT [dbo].[Routes] ([Id], [RouteName], [RouteColor]) VALUES (2, N'Laćarak-Kuper-Mala Bosna', N'zelena')
INSERT [dbo].[Routes] ([Id], [RouteName], [RouteColor]) VALUES (7, N'Laćarak-Industrijska zona-Groblje', N'crvena')
SET IDENTITY_INSERT [dbo].[Routes] OFF
GO
SET IDENTITY_INSERT [dbo].[RouteStops] ON 

INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeDistance], [MetarDistance]) VALUES (2, 1, 2, 2, NULL, NULL)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeDistance], [MetarDistance]) VALUES (3, 1, 3, 3, NULL, NULL)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeDistance], [MetarDistance]) VALUES (4, 1, 4, 9, NULL, NULL)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeDistance], [MetarDistance]) VALUES (5, 1, 5, 8, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RouteStops] OFF
GO
SET IDENTITY_INSERT [dbo].[Stops] ON 

INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (1, N'Stari most', 44.973326639512344, 19.598533709483643)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (2, N'stanica1', 0, 0)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (3, N'string', 0, 0)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (7, N'KPZ', 0, 0)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (8, N'Malta', 44.970508828307935, 19.635490492636311)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (9, N'Bolnica', 44.97234603267998, 19.607080799465265)
SET IDENTITY_INSERT [dbo].[Stops] OFF
GO
SET IDENTITY_INSERT [dbo].[Trips] ON 

INSERT [dbo].[Trips] ([Id], [RouteId], [ServiceId]) VALUES (4, 1, 1)
SET IDENTITY_INSERT [dbo].[Trips] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Address], [Email], [Username], [Password]) VALUES (4, N'string', N'string', N'string', N'string2', N'string2', N'string')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Address], [Email], [Username], [Password]) VALUES (5, N'string', N'string', N'string', N'string3', N'string3', N'string')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Address], [Email], [Username], [Password]) VALUES (6, N'string', N'string', N'string', N'string32', N'string32', N'string')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Address], [Email], [Username], [Password]) VALUES (7, N'admin', N'admin', N'admin', N'admin', N'admin', N'admin')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Address], [Email], [Username], [Password]) VALUES (8, N'Milena', N'Kostić', N'Petra Drapsina', N'milenakostic00@gmail.com', N'Milena', N'aaaaaaa')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Address], [Email], [Username], [Password]) VALUES (10, N'Milena', N'Kostić', N'Petra Drapsina', N'milenakostic002@gmail.com', N'seler', N'aaaaaaaa')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__66DCF95C3EAEC0F1]    Script Date: 27/11/2023 14:27:08 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__66DCF95C3EAEC0F1] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__AB6E6164A9C2BF10]    Script Date: 27/11/2023 14:27:08 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__AB6E6164A9C2BF10] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CalendarDates]  WITH CHECK ADD  CONSTRAINT [FK_calendarDates_calendars] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Calendars] ([Id])
GO
ALTER TABLE [dbo].[CalendarDates] CHECK CONSTRAINT [FK_calendarDates_calendars]
GO
ALTER TABLE [dbo].[RouteStops]  WITH CHECK ADD FOREIGN KEY([RouteId])
REFERENCES [dbo].[Routes] ([Id])
GO
ALTER TABLE [dbo].[RouteStops]  WITH CHECK ADD FOREIGN KEY([RouteId])
REFERENCES [dbo].[Routes] ([Id])
GO
ALTER TABLE [dbo].[RouteStops]  WITH CHECK ADD FOREIGN KEY([StopId])
REFERENCES [dbo].[Stops] ([Id])
GO
ALTER TABLE [dbo].[RouteStops]  WITH CHECK ADD FOREIGN KEY([StopId])
REFERENCES [dbo].[Stops] ([Id])
GO
ALTER TABLE [dbo].[StopTimes]  WITH CHECK ADD  CONSTRAINT [FK_stopTime_stop] FOREIGN KEY([StopId])
REFERENCES [dbo].[Stops] ([Id])
GO
ALTER TABLE [dbo].[StopTimes] CHECK CONSTRAINT [FK_stopTime_stop]
GO
ALTER TABLE [dbo].[StopTimes]  WITH CHECK ADD  CONSTRAINT [FK_stopTime_trip] FOREIGN KEY([TripId])
REFERENCES [dbo].[Trips] ([Id])
GO
ALTER TABLE [dbo].[StopTimes] CHECK CONSTRAINT [FK_stopTime_trip]
GO
ALTER TABLE [dbo].[Trips]  WITH CHECK ADD  CONSTRAINT [FK_trips_calendars] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Calendars] ([Id])
GO
ALTER TABLE [dbo].[Trips] CHECK CONSTRAINT [FK_trips_calendars]
GO
ALTER TABLE [dbo].[Trips]  WITH CHECK ADD  CONSTRAINT [FK_trips_routes] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Routes] ([Id])
GO
ALTER TABLE [dbo].[Trips] CHECK CONSTRAINT [FK_trips_routes]
GO
USE [master]
GO
ALTER DATABASE [Timetable] SET  READ_WRITE 
GO
