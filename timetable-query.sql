USE [master]
GO
/****** Object:  Database [Timetable]    Script Date: 10/11/2023 20:47:53 ******/
CREATE DATABASE [Timetable]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Timetable', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Timetable.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Timetable_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Timetable_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [Timetable] SET AUTO_CLOSE OFF 
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
EXEC sys.sp_db_vardecimal_storage_format N'Timetable', N'ON'
GO
ALTER DATABASE [Timetable] SET QUERY_STORE = ON
GO
ALTER DATABASE [Timetable] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Timetable]
GO
/****** Object:  Table [dbo].[calendarDates]    Script Date: 10/11/2023 20:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calendarDates](
	[Id] [int] NOT NULL,
	[serviceId] [int] NOT NULL,
	[date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[calendars]    Script Date: 10/11/2023 20:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calendars](
	[Id] [int] NOT NULL,
	[monday] [bit] NOT NULL,
	[tuesday] [bit] NOT NULL,
	[wednesday] [bit] NOT NULL,
	[thursday] [bit] NOT NULL,
	[friday] [bit] NOT NULL,
	[saturday] [bit] NOT NULL,
	[sunday] [bit] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[routes]    Script Date: 10/11/2023 20:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[routes](
	[Id] [int] NOT NULL,
	[routeName] [text] NOT NULL,
	[routeColor] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stops]    Script Date: 10/11/2023 20:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stops](
	[Id] [int] NOT NULL,
	[stopName] [text] NOT NULL,
	[stopLat] [decimal](9, 6) NOT NULL,
	[stopLon] [decimal](9, 6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stopTimes]    Script Date: 10/11/2023 20:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stopTimes](
	[Id] [int] NOT NULL,
	[tripId] [int] NOT NULL,
	[stopId] [int] NOT NULL,
	[stopSequence] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trips]    Script Date: 10/11/2023 20:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trips](
	[routeId] [int] NOT NULL,
	[serviceId] [int] NOT NULL,
	[Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[calendarDates]  WITH CHECK ADD  CONSTRAINT [FK_calendarDates_calendars] FOREIGN KEY([serviceId])
REFERENCES [dbo].[calendars] ([Id])
GO
ALTER TABLE [dbo].[calendarDates] CHECK CONSTRAINT [FK_calendarDates_calendars]
GO
ALTER TABLE [dbo].[stopTimes]  WITH CHECK ADD  CONSTRAINT [FK_stopTime_stop] FOREIGN KEY([stopId])
REFERENCES [dbo].[stops] ([Id])
GO
ALTER TABLE [dbo].[stopTimes] CHECK CONSTRAINT [FK_stopTime_stop]
GO
ALTER TABLE [dbo].[stopTimes]  WITH CHECK ADD  CONSTRAINT [FK_stopTime_trip] FOREIGN KEY([tripId])
REFERENCES [dbo].[trips] ([Id])
GO
ALTER TABLE [dbo].[stopTimes] CHECK CONSTRAINT [FK_stopTime_trip]
GO
ALTER TABLE [dbo].[trips]  WITH CHECK ADD  CONSTRAINT [FK_trips_calendars] FOREIGN KEY([serviceId])
REFERENCES [dbo].[calendars] ([Id])
GO
ALTER TABLE [dbo].[trips] CHECK CONSTRAINT [FK_trips_calendars]
GO
ALTER TABLE [dbo].[trips]  WITH CHECK ADD  CONSTRAINT [FK_trips_routes] FOREIGN KEY([routeId])
REFERENCES [dbo].[routes] ([Id])
GO
ALTER TABLE [dbo].[trips] CHECK CONSTRAINT [FK_trips_routes]
GO
USE [master]
GO
ALTER DATABASE [Timetable] SET  READ_WRITE 
GO
