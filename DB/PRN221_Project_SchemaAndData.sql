USE [master]
GO
/****** Object:  Database [PRN221Project]    Script Date: 3/23/2024 10:06:51 PM ******/
CREATE DATABASE [PRN221Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN221Project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PRN221Project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN221Project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PRN221Project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PRN221Project] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN221Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN221Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN221Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN221Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN221Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN221Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN221Project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN221Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN221Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN221Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN221Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN221Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN221Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN221Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN221Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN221Project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN221Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN221Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN221Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN221Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN221Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN221Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN221Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN221Project] SET RECOVERY FULL 
GO
ALTER DATABASE [PRN221Project] SET  MULTI_USER 
GO
ALTER DATABASE [PRN221Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN221Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN221Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN221Project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN221Project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN221Project] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRN221Project', N'ON'
GO
ALTER DATABASE [PRN221Project] SET QUERY_STORE = ON
GO
ALTER DATABASE [PRN221Project] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PRN221Project]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 3/23/2024 10:06:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[areaId] [varchar](50) NOT NULL,
	[areaName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[areaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 3/23/2024 10:06:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[groupId] [int] IDENTITY(1,1) NOT NULL,
	[groupName] [varchar](50) NOT NULL,
	[subjectId] [varchar](50) NOT NULL,
	[lecturerId] [varchar](50) NOT NULL,
	[semester] [varchar](50) NULL,
	[year] [nchar](10) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[groupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lecturer]    Script Date: 3/23/2024 10:06:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecturer](
	[lecturerId] [varchar](50) NOT NULL,
	[lecturerName] [nvarchar](255) NOT NULL,
	[lecturerEmail] [varchar](150) NOT NULL,
	[lecturerGender] [int] NOT NULL,
	[lecturerDob] [datetime] NULL,
	[lecturerPhone] [varchar](50) NULL,
 CONSTRAINT [PK_Lecturer] PRIMARY KEY CLUSTERED 
(
	[lecturerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 3/23/2024 10:06:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[roomId] [int] IDENTITY(1,1) NOT NULL,
	[roomName] [varchar](50) NOT NULL,
	[areaId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[roomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 3/23/2024 10:06:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[sessionId] [int] IDENTITY(1,1) NOT NULL,
	[groupId] [int] NOT NULL,
	[roomId] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[timeslotId] [int] NOT NULL,
	[lecturerId] [varchar](50) NOT NULL,
	[SessionNo] [int] NOT NULL,
	[Online] [bit] NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[sessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 3/23/2024 10:06:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[subjectId] [varchar](50) NOT NULL,
	[subjectName] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[subjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 3/23/2024 10:06:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[timeslotId] [int] IDENTITY(1,1) NOT NULL,
	[timeslotName] [varchar](255) NOT NULL,
	[timeslotDescription] [varchar](255) NULL,
 CONSTRAINT [PK_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[timeslotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Area] ([areaId], [areaName]) VALUES (N'AL', N'Alpha')
INSERT [dbo].[Area] ([areaId], [areaName]) VALUES (N'BE', N'Beta')
INSERT [dbo].[Area] ([areaId], [areaName]) VALUES (N'DE', N'Delta')
INSERT [dbo].[Area] ([areaId], [areaName]) VALUES (N'EP', N'Epsilon')
INSERT [dbo].[Area] ([areaId], [areaName]) VALUES (N'GA', N'Gamma')
INSERT [dbo].[Area] ([areaId], [areaName]) VALUES (N'R1', N'Vovinam Area 1')
INSERT [dbo].[Area] ([areaId], [areaName]) VALUES (N'R2', N'Vovinam Area 2')
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([groupId], [groupName], [subjectId], [lecturerId], [semester], [year]) VALUES (2, N'SE1701', N'PRN211', N'chilp2', N'Spring', N'2024      ')
INSERT [dbo].[Group] ([groupId], [groupName], [subjectId], [lecturerId], [semester], [year]) VALUES (3, N'SE1801', N'PRJ301', N'sonnt5', N'Spring', N'2024      ')
INSERT [dbo].[Group] ([groupId], [groupName], [subjectId], [lecturerId], [semester], [year]) VALUES (4, N'SE1801', N'MAS291', N'anhnv64', N'Spring', N'2024      ')
INSERT [dbo].[Group] ([groupId], [groupName], [subjectId], [lecturerId], [semester], [year]) VALUES (5, N'SE1602', N'PRN221', N'chilp2', N'Spring', N'2024      ')
INSERT [dbo].[Group] ([groupId], [groupName], [subjectId], [lecturerId], [semester], [year]) VALUES (6, N'SE1615', N'PRN231', N'chilp2', N'Spring', N'2024      ')
INSERT [dbo].[Group] ([groupId], [groupName], [subjectId], [lecturerId], [semester], [year]) VALUES (8, N'SE1720', N'PRU211m', N'khuongpd', N'Spring', N'2024      ')
INSERT [dbo].[Group] ([groupId], [groupName], [subjectId], [lecturerId], [semester], [year]) VALUES (9, N'SE1912', N'PRO192', N'caupd', N'Spring', N'2024      ')
INSERT [dbo].[Group] ([groupId], [groupName], [subjectId], [lecturerId], [semester], [year]) VALUES (11, N'SE1735', N'PRU211m', N'sonnt5', N'Spring', N'2024      ')
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'anhkd', N'Khuat Duc Anh', N'anhkd@fe.edu.vn', 2, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'anhnv64', N'Nguyen Viet Anh', N'anhnv64@fe.edu.vn', 2, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'annt79', N'Nguyen An', N'annt79@fe.edu.vn', 2, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'caupd', N'Phan Dang Cau', N'caupd@fe.edu.vn', 2, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'chilp2', N'Le Phuong Chi', N'chilp2@fe.edu.vn', 1, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'giangdt26', N'Ðo Thai Giang', N'giangdt26@fe.edu.vn', 2, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'huectm', N'Chu Thi Minh Hue', N'huectm@fe.edu.vn', 1, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'hunghm31', N'Ha Manh Hung', N'hunghm31@fe.edu.vn', 2, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'khuongpd', N'Phuong Duy Khuong', N'khuongpd@fe.edu.vn', 2, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'sonnt5', N'Ngo Tung Son', N'sonnt5@fe.edu.vn', 2, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'thangpd10', N'Pham Duc Thang', N'thangpd10@fe.edu.vn', 2, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'thomlth2', N'Le thi Hong Thom', N'thomlth2@fe.edu.vn', 1, NULL, NULL)
INSERT [dbo].[Lecturer] ([lecturerId], [lecturerName], [lecturerEmail], [lecturerGender], [lecturerDob], [lecturerPhone]) VALUES (N'trungnt', N'Nguyen Tat Trung', N'trungnt@fe.edu.vn', 2, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (1, N'101', N'AL')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (2, N'102', N'AL')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (3, N'103', N'AL')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (4, N'201', N'AL')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (5, N'202', N'AL')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (6, N'203', N'AL')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (7, N'301', N'AL')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (8, N'302', N'AL')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (9, N'303', N'AL')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (10, N'101', N'BE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (11, N'102', N'BE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (12, N'103', N'BE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (13, N'201', N'BE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (14, N'202', N'BE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (15, N'203', N'BE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (16, N'301', N'BE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (17, N'302', N'BE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (18, N'303', N'BE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (19, N'101', N'DE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (20, N'102', N'DE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (21, N'103', N'DE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (22, N'201', N'DE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (23, N'202', N'DE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (24, N'203', N'DE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (25, N'301', N'DE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (26, N'302', N'DE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (27, N'303', N'DE')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (28, N'101', N'GA')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (29, N'102', N'GA')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (30, N'103', N'GA')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (31, N'201', N'GA')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (32, N'202', N'GA')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (33, N'203', N'GA')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (34, N'301', N'GA')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (35, N'302', N'GA')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (36, N'303', N'GA')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (37, N'101', N'EP')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (38, N'102', N'EP')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (39, N'103', N'EP')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (40, N'201', N'EP')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (41, N'202', N'EP')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (42, N'203', N'EP')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (43, N'301', N'EP')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (44, N'302', N'EP')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (45, N'303', N'EP')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (46, N'101', N'R1')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (47, N'102', N'R1')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (48, N'103', N'R1')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (49, N'104', N'R1')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (50, N'105', N'R1')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (51, N'101', N'R2')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (52, N'102', N'R2')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (53, N'103', N'R2')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (54, N'104', N'R2')
INSERT [dbo].[Room] ([roomId], [roomName], [areaId]) VALUES (55, N'105', N'R2')
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([sessionId], [groupId], [roomId], [date], [timeslotId], [lecturerId], [SessionNo], [Online]) VALUES (1, 2, 1, CAST(N'2024-02-19T00:00:00.000' AS DateTime), 1, N'chilp2', 1, 0)
INSERT [dbo].[Session] ([sessionId], [groupId], [roomId], [date], [timeslotId], [lecturerId], [SessionNo], [Online]) VALUES (2, 2, 1, CAST(N'2024-02-21T00:00:00.000' AS DateTime), 2, N'chilp2', 2, 0)
SET IDENTITY_INSERT [dbo].[Session] OFF
GO
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'CEA201', N'	Computer Organization and Architecture')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'CSD201', N'Data Structures and Algorithms')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'CSI104', N'Introduction to Computer Science')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'DBI202', N'Introduction to Databases')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'EXE101', N'Experiential Entrepreneurship 1')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'EXE201', N'Experiential Entrepreneurship 2')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'HCM202', N'Ho Chi Minh Ideology')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'IOT102', N'Internet Of Things')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'LAB211', N'OOP with Java Lab')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'MAD101', N'Discrete mathematics')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'MAE101', N'Mathematics for Engineering')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'MAS291', N'Statistics and Probability')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'MLN111', N'Philosophy of Marxism – Leninism')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'MLN122', N'Political economics of Marxism – Leninism')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'MLN131', N'Scientific socialism')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'OSG202', N'Operating Systems')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'PRF192', N'Programming Fundamentals')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'PRJ301', N'Java Web Application Development')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'PRM392', N'Mobile Programming')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'PRN211', N'Basic Cross-Platform Application Programming With .NET')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'PRN221', N'Advanced Cross-Platform Application Programming With .NET')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'PRN231', N'Building Cross-Platform Back-End Application With .NET')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'PRO192', N'Object-Oriented Programming')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'PRU211m', N'C# Programming and Unity')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'SEP490', N'SE Capstone Project')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'SSG104', N'Communication and In-Group Working Skills')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'SWD392', N'SW Architecture and Design')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'SWP391', N'Application development project')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'SWR302', N'Software Requirement')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'SWT301', N'Software Testing')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'VNR202', N'History of Vi?t Nam Communist Party')
INSERT [dbo].[Subject] ([subjectId], [subjectName]) VALUES (N'WDU203c', N'UI/UX Design')
GO
SET IDENTITY_INSERT [dbo].[TimeSlot] ON 

INSERT [dbo].[TimeSlot] ([timeslotId], [timeslotName], [timeslotDescription]) VALUES (1, N'Slot 1', N'07h30'' - 09h50''')
INSERT [dbo].[TimeSlot] ([timeslotId], [timeslotName], [timeslotDescription]) VALUES (2, N'Slot 2', N'10h00'' - 12h20''')
INSERT [dbo].[TimeSlot] ([timeslotId], [timeslotName], [timeslotDescription]) VALUES (3, N'Slot 3', N'12h50'' - 15h10''')
INSERT [dbo].[TimeSlot] ([timeslotId], [timeslotName], [timeslotDescription]) VALUES (4, N'Slot 4', N'15h20'' - 17h40''')
INSERT [dbo].[TimeSlot] ([timeslotId], [timeslotName], [timeslotDescription]) VALUES (5, N'Slot 5', N'18h00'' - 20h20''')
INSERT [dbo].[TimeSlot] ([timeslotId], [timeslotName], [timeslotDescription]) VALUES (6, N'Slot 6', N'20h00'' 22h20''')
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Subject] FOREIGN KEY([subjectId])
REFERENCES [dbo].[Subject] ([subjectId])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Subject]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Area] FOREIGN KEY([areaId])
REFERENCES [dbo].[Area] ([areaId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Area]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Group] FOREIGN KEY([groupId])
REFERENCES [dbo].[Group] ([groupId])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Group]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Lecturer] FOREIGN KEY([lecturerId])
REFERENCES [dbo].[Lecturer] ([lecturerId])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Lecturer]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Room] FOREIGN KEY([roomId])
REFERENCES [dbo].[Room] ([roomId])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Room]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_TimeSlot] FOREIGN KEY([timeslotId])
REFERENCES [dbo].[TimeSlot] ([timeslotId])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_TimeSlot]
GO
USE [master]
GO
ALTER DATABASE [PRN221Project] SET  READ_WRITE 
GO
