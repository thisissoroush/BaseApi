USE [master]
GO
/****** Object:  Database [BaseDB]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE DATABASE [BaseDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseDB', FILENAME = N'C:\Projects\BaseAPI\DB\BaseDB.mdf' , SIZE = 110592KB , MAXSIZE = UNLIMITED, FILEGROWTH = 102400KB )
 LOG ON 
( NAME = N'BaseDB_log', FILENAME = N'C:\Projects\BaseAPI\DB\BaseDB.ldf' , SIZE = 2355200KB , MAXSIZE = 2048GB , FILEGROWTH = 204800KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BaseDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaseDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaseDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BaseDB] SET  MULTI_USER 
GO
ALTER DATABASE [BaseDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BaseDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BaseDB', N'ON'
GO
ALTER DATABASE [BaseDB] SET QUERY_STORE = OFF
GO
USE [BaseDB]
GO
/****** Object:  Schema [article]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE SCHEMA [article]
GO
/****** Object:  Schema [Com]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE SCHEMA [Com]
GO
/****** Object:  Schema [Core]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE SCHEMA [Core]
GO
/****** Object:  Schema [GoogleUser]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE SCHEMA [GoogleUser]
GO
/****** Object:  Schema [Org]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE SCHEMA [Org]
GO
/****** Object:  Schema [Users]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE SCHEMA [Users]
GO
/****** Object:  Table [article].[tblArticleComments]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [article].[tblArticleComments](
	[Id] [bigint] NOT NULL,
	[ArticleID] [bigint] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[IsApprovd] [bit] NOT NULL,
 CONSTRAINT [PK_tblArticleComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [article].[tblArticles]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [article].[tblArticles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[TagNames] [nvarchar](max) NULL,
	[ArticleTypeID] [int] NOT NULL,
	[Article] [nvarchar](max) NOT NULL,
	[PublishDate] [bigint] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[VisitCount] [bigint] NOT NULL,
 CONSTRAINT [PK_tblArticles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [article].[tblArticleTypes]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [article].[tblArticleTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblArticleTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Com].[tblContactInfoType]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Com].[tblContactInfoType](
	[ID] [smallint] NOT NULL,
	[Title] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_tblContactInfoType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Com].[tblContactServersInfo]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Com].[tblContactServersInfo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[From] [nvarchar](100) NOT NULL,
	[ProviderID] [bigint] NOT NULL,
	[ProviderCustomURL] [nvarchar](200) NULL,
	[UseProxy] [bit] NOT NULL,
	[ProxyUserName] [nvarchar](100) NULL,
	[ProxyPassord] [nvarchar](100) NULL,
	[ProxyServer] [nvarchar](200) NULL,
	[ProxyPort] [nvarchar](5) NULL,
	[UseSSL] [bit] NOT NULL,
	[SSLPort] [nvarchar](5) NULL,
	[OrganizationID] [bigint] NOT NULL,
	[Type] [smallint] NOT NULL,
 CONSTRAINT [PK_tblContactServersInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Com].[tblOrganizationContactInfo]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Com].[tblOrganizationContactInfo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrganizationID] [bigint] NOT NULL,
	[Value] [nvarchar](10) NOT NULL,
	[TypeID] [smallint] NOT NULL,
 CONSTRAINT [PK_tblOrganizationContactInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Com].[tblUserContactInfo]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Com].[tblUserContactInfo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Value] [nvarchar](150) NOT NULL,
	[TypeID] [smallint] NOT NULL,
	[IsPrimary] [bit] NOT NULL,
 CONSTRAINT [PK_tblPeopleContactInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[ServicesDetailType]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[ServicesDetailType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ServicesDetailType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[ServicesTypes]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[ServicesTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ServicesTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblCategories]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblCategories](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[ParentID] [bigint] NULL,
 CONSTRAINT [PK_tblCategories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblGoogleClick]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblGoogleClick](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Website] [nvarchar](200) NOT NULL,
	[TagName] [nvarchar](100) NOT NULL,
	[TodaySearchedCounts] [bigint] NOT NULL,
	[TotalSearchedCounts] [bigint] NOT NULL,
	[TodayClickedCounts] [bigint] NOT NULL,
	[TotalClickedCounts] [bigint] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ClickPerDay] [int] NULL,
 CONSTRAINT [PK_tblGoogleClick] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblGoogleClickLogs]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblGoogleClickLogs](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClickID] [bigint] NOT NULL,
	[ViewerID] [bigint] NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
	[IP] [nvarchar](15) NULL,
	[LogType] [smallint] NULL,
	[UniqueID] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblGoogleClickLogTypes]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblGoogleClickLogTypes](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblGoogleClickScore]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblGoogleClickScore](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Score] [bigint] NOT NULL,
 CONSTRAINT [PK_tblGoogleClickScore] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblLogs]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblLogs](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Who] [nvarchar](50) NOT NULL,
	[What] [nvarchar](150) NOT NULL,
	[Where] [nvarchar](50) NOT NULL,
	[When] [char](10) NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tblLogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblOffService]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblOffService](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ServiceID] [bigint] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[StartDatePer] [char](8) NULL,
	[EndDatePer] [char](8) NULL,
	[StartDateEn] [char](8) NULL,
	[EndDateEn] [char](8) NULL,
 CONSTRAINT [PK_tblOffService] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblPayments]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblPayments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
	[ServiceID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[OffServiceID] [bigint] NOT NULL,
	[Paid] [nvarchar](20) NOT NULL,
	[PaymentTypeID] [smallint] NOT NULL,
 CONSTRAINT [PK_tblPayments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblPeriodicService]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblPeriodicService](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ServiceID] [bigint] NOT NULL,
	[IsOneTime] [bit] NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[WebSite] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblPeriodicService] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblPeriodicServiceTypes]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblPeriodicServiceTypes](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Type] [nchar](10) NOT NULL,
 CONSTRAINT [PK_tblPeriodicServiceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblServices]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblServices](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[StartDatePer] [int] NULL,
	[EndDatePer] [int] NULL,
	[StartDateEn] [int] NULL,
	[EndDateEn] [int] NULL,
	[PeriodTitle] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NOT NULL,
	[CategoryID] [bigint] NOT NULL,
	[TypeID] [int] NOT NULL,
	[OrganizationID] [bigint] NOT NULL,
	[BranchID] [bigint] NULL,
	[IsPeriodic] [bit] NOT NULL,
 CONSTRAINT [PK_tblServices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblServicesDetail]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblServicesDetail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ServicesID] [bigint] NOT NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_tblServicesDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblTagNames]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblTagNames](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PeriodicServiceID] [bigint] NOT NULL,
	[Tag] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tblTagNames] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblTransactions]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblTransactions](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
	[PaymentID] [bigint] NOT NULL,
 CONSTRAINT [PK_tblTransactions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Core].[tblVisistedSites]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Core].[tblVisistedSites](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[WebSite] [nvarchar](200) NOT NULL,
	[TagName] [nvarchar](200) NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tblVisistedSites] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPaymentTypes]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPaymentTypes](
	[ID] [smallint] NOT NULL,
	[Title] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblPaymentTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Org].[tblBranches]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Org].[tblBranches](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[OrganizationID] [bigint] NOT NULL,
	[ParentID] [bigint] NULL,
 CONSTRAINT [PK_tblBranches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Org].[tblOrganizations]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Org].[tblOrganizations](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tblOrganizations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Users].[tblRoles]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users].[tblRoles](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Users].[tblUserRoles]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users].[tblUserRoles](
	[ID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_tblUserRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Users].[tblUsers]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users].[tblUsers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[NationalCode] [char](10) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Salt] [nvarchar](100) NOT NULL,
	[Sugar] [nvarchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
	[LastModifyDate] [datetime2](7) NOT NULL,
	[OrganizationID] [bigint] NULL,
	[BranchID] [bigint] NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tblArticles]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_tblArticles] ON [article].[tblArticles]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblContactServersInfo_OrganizationID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblContactServersInfo_OrganizationID] ON [Com].[tblContactServersInfo]
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblOrganizationContactInfo_OrganizationID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblOrganizationContactInfo_OrganizationID] ON [Com].[tblOrganizationContactInfo]
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblOrganizationContactInfo_TypeID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblOrganizationContactInfo_TypeID] ON [Com].[tblOrganizationContactInfo]
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblPeopleContactInfo_PeopleID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblPeopleContactInfo_PeopleID] ON [Com].[tblUserContactInfo]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblPeopleContactInfo_TypeID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblPeopleContactInfo_TypeID] ON [Com].[tblUserContactInfo]
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblCategories_ParentID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblCategories_ParentID] ON [Core].[tblCategories]
(
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tblGoogleClick]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tblGoogleClick] ON [Core].[tblGoogleClick]
(
	[Website] ASC,
	[TagName] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tblGoogleClick_CUTOMERID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_tblGoogleClick_CUTOMERID] ON [Core].[tblGoogleClick]
(
	[UserID] ASC,
	[IsActive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GoogleClickLogs]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_GoogleClickLogs] ON [Core].[tblGoogleClickLogs]
(
	[ClickID] ASC,
	[ViewerID] ASC,
	[UniqueID] ASC,
	[IP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblGoogleClickLogs_TIME]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblGoogleClickLogs_TIME] ON [Core].[tblGoogleClickLogs]
(
	[DueDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tblGoogleClickScore]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_tblGoogleClickScore] ON [Core].[tblGoogleClickScore]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_tblOffService_Code]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblOffService_Code] ON [Core].[tblOffService]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_tblOffService_EndDateEn]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblOffService_EndDateEn] ON [Core].[tblOffService]
(
	[EndDateEn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_tblOffService_EndDatePer]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblOffService_EndDatePer] ON [Core].[tblOffService]
(
	[EndDatePer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblOffService_ServiceID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblOffService_ServiceID] ON [Core].[tblOffService]
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_tblOffService_StartDateEn]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblOffService_StartDateEn] ON [Core].[tblOffService]
(
	[StartDateEn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_tblOffService_StartDatePer]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblOffService_StartDatePer] ON [Core].[tblOffService]
(
	[StartDatePer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tblPeriodicService]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_tblPeriodicService] ON [Core].[tblPeriodicService]
(
	[ServiceID] ASC,
	[IsOneTime] ASC,
	[IsUsed] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblServices_BranchID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServices_BranchID] ON [Core].[tblServices]
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblServices_CategoryID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServices_CategoryID] ON [Core].[tblServices]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblServices_EndDateEn]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServices_EndDateEn] ON [Core].[tblServices]
(
	[EndDateEn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblServices_EndDatePer]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServices_EndDatePer] ON [Core].[tblServices]
(
	[EndDatePer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblServices_OrganizationID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServices_OrganizationID] ON [Core].[tblServices]
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_tblServices_Price]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServices_Price] ON [Core].[tblServices]
(
	[Price] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblServices_StartDateEn]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServices_StartDateEn] ON [Core].[tblServices]
(
	[StartDateEn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblServices_StartDatePer]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServices_StartDatePer] ON [Core].[tblServices]
(
	[StartDatePer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblServices_TypeID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServices_TypeID] ON [Core].[tblServices]
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblServicesDetail_TypeID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblServicesDetail_TypeID] ON [Core].[tblServicesDetail]
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NCI_tblTransactions_Code]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblTransactions_Code] ON [Core].[tblTransactions]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblBranches_OrganizationID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblBranches_OrganizationID] ON [Org].[tblBranches]
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NCI_tblBranches_ParentID]    Script Date: 7/3/2021 10:39:56 PM ******/
CREATE NONCLUSTERED INDEX [NCI_tblBranches_ParentID] ON [Org].[tblBranches]
(
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [article].[tblArticleComments] ADD  CONSTRAINT [DF_tblArticleComments_IsApprovd]  DEFAULT ((0)) FOR [IsApprovd]
GO
ALTER TABLE [article].[tblArticles] ADD  CONSTRAINT [DF_tblArticles_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [article].[tblArticles] ADD  CONSTRAINT [DF_tblArticles_VisitCount]  DEFAULT ((0)) FOR [VisitCount]
GO
ALTER TABLE [Com].[tblContactServersInfo] ADD  CONSTRAINT [DF_tblContactServersInfo_UseProxy]  DEFAULT ((0)) FOR [UseProxy]
GO
ALTER TABLE [Com].[tblContactServersInfo] ADD  CONSTRAINT [DF_tblContactServersInfo_UseSSL]  DEFAULT ((0)) FOR [UseSSL]
GO
ALTER TABLE [Com].[tblUserContactInfo] ADD  CONSTRAINT [DF_tblPeopleContactInfo_Type]  DEFAULT ((0)) FOR [TypeID]
GO
ALTER TABLE [Com].[tblUserContactInfo] ADD  CONSTRAINT [DF_tblPeopleContactInfo_IsPrimary]  DEFAULT ((0)) FOR [IsPrimary]
GO
ALTER TABLE [Core].[tblLogs] ADD  CONSTRAINT [DF_tblLogs_When]  DEFAULT (getdate()) FOR [When]
GO
ALTER TABLE [Core].[tblLogs] ADD  CONSTRAINT [DF_tblLogs_DueDate]  DEFAULT (getdate()) FOR [DueDate]
GO
ALTER TABLE [Core].[tblPayments] ADD  CONSTRAINT [DF_tblPayments_DueDate]  DEFAULT (getdate()) FOR [DueDate]
GO
ALTER TABLE [Core].[tblServices] ADD  CONSTRAINT [DF_tblServices_IsPeriodic]  DEFAULT ((0)) FOR [IsPeriodic]
GO
ALTER TABLE [Core].[tblTransactions] ADD  CONSTRAINT [DF_tblTransactions_DueDate]  DEFAULT (getdate()) FOR [DueDate]
GO
ALTER TABLE [Core].[tblVisistedSites] ADD  CONSTRAINT [DF_tblVisistedSites_DueDate]  DEFAULT (getdate()) FOR [DueDate]
GO
ALTER TABLE [Users].[tblUsers] ADD  CONSTRAINT [DF_tblUsers_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [Users].[tblUsers] ADD  CONSTRAINT [DF_tblUsers_LastModifyDate]  DEFAULT (getdate()) FOR [LastModifyDate]
GO
ALTER TABLE [article].[tblArticleComments]  WITH CHECK ADD  CONSTRAINT [FK_tblArticleComments_tblArticles] FOREIGN KEY([ArticleID])
REFERENCES [article].[tblArticles] ([Id])
GO
ALTER TABLE [article].[tblArticleComments] CHECK CONSTRAINT [FK_tblArticleComments_tblArticles]
GO
ALTER TABLE [article].[tblArticles]  WITH CHECK ADD  CONSTRAINT [FK_tblArticles_tblArticleTypes] FOREIGN KEY([ArticleTypeID])
REFERENCES [article].[tblArticleTypes] ([ID])
GO
ALTER TABLE [article].[tblArticles] CHECK CONSTRAINT [FK_tblArticles_tblArticleTypes]
GO
ALTER TABLE [article].[tblArticles]  WITH CHECK ADD  CONSTRAINT [FK_tblArticles_tblUsers] FOREIGN KEY([UserID])
REFERENCES [Users].[tblUsers] ([ID])
GO
ALTER TABLE [article].[tblArticles] CHECK CONSTRAINT [FK_tblArticles_tblUsers]
GO
ALTER TABLE [Com].[tblContactServersInfo]  WITH CHECK ADD  CONSTRAINT [FK_tblContactServersInfo_tblContactInfoType] FOREIGN KEY([Type])
REFERENCES [Com].[tblContactInfoType] ([ID])
GO
ALTER TABLE [Com].[tblContactServersInfo] CHECK CONSTRAINT [FK_tblContactServersInfo_tblContactInfoType]
GO
ALTER TABLE [Com].[tblContactServersInfo]  WITH CHECK ADD  CONSTRAINT [FK_tblContactServersInfo_tblOrganizations] FOREIGN KEY([OrganizationID])
REFERENCES [Org].[tblOrganizations] ([ID])
GO
ALTER TABLE [Com].[tblContactServersInfo] CHECK CONSTRAINT [FK_tblContactServersInfo_tblOrganizations]
GO
ALTER TABLE [Com].[tblOrganizationContactInfo]  WITH CHECK ADD  CONSTRAINT [FK_tblOrganizationContactInfo_tblContactInfoType] FOREIGN KEY([TypeID])
REFERENCES [Com].[tblContactInfoType] ([ID])
GO
ALTER TABLE [Com].[tblOrganizationContactInfo] CHECK CONSTRAINT [FK_tblOrganizationContactInfo_tblContactInfoType]
GO
ALTER TABLE [Com].[tblOrganizationContactInfo]  WITH CHECK ADD  CONSTRAINT [FK_tblOrganizationContactInfo_tblOrganizations] FOREIGN KEY([OrganizationID])
REFERENCES [Org].[tblOrganizations] ([ID])
GO
ALTER TABLE [Com].[tblOrganizationContactInfo] CHECK CONSTRAINT [FK_tblOrganizationContactInfo_tblOrganizations]
GO
ALTER TABLE [Com].[tblUserContactInfo]  WITH CHECK ADD  CONSTRAINT [FK_tblPeopleContactInfo_tblContactInfoType] FOREIGN KEY([TypeID])
REFERENCES [Com].[tblContactInfoType] ([ID])
GO
ALTER TABLE [Com].[tblUserContactInfo] CHECK CONSTRAINT [FK_tblPeopleContactInfo_tblContactInfoType]
GO
ALTER TABLE [Com].[tblUserContactInfo]  WITH CHECK ADD  CONSTRAINT [FK_tblUserContactInfo_tblUsers] FOREIGN KEY([UserID])
REFERENCES [Users].[tblUsers] ([ID])
GO
ALTER TABLE [Com].[tblUserContactInfo] CHECK CONSTRAINT [FK_tblUserContactInfo_tblUsers]
GO
ALTER TABLE [Core].[tblGoogleClick]  WITH CHECK ADD  CONSTRAINT [FK_tblGoogleClick_tblUsers] FOREIGN KEY([UserID])
REFERENCES [Users].[tblUsers] ([ID])
GO
ALTER TABLE [Core].[tblGoogleClick] CHECK CONSTRAINT [FK_tblGoogleClick_tblUsers]
GO
ALTER TABLE [Core].[tblGoogleClickLogs]  WITH CHECK ADD  CONSTRAINT [FK_ClickID_tblGoogleClickID] FOREIGN KEY([ClickID])
REFERENCES [Core].[tblGoogleClick] ([ID])
GO
ALTER TABLE [Core].[tblGoogleClickLogs] CHECK CONSTRAINT [FK_ClickID_tblGoogleClickID]
GO
ALTER TABLE [Core].[tblGoogleClickScore]  WITH CHECK ADD  CONSTRAINT [FK_tblGoogleClickScore_tblUsers] FOREIGN KEY([UserID])
REFERENCES [Users].[tblUsers] ([ID])
GO
ALTER TABLE [Core].[tblGoogleClickScore] CHECK CONSTRAINT [FK_tblGoogleClickScore_tblUsers]
GO
ALTER TABLE [Core].[tblOffService]  WITH CHECK ADD  CONSTRAINT [FK_tblOffService_tblServices] FOREIGN KEY([ServiceID])
REFERENCES [Core].[tblServices] ([ID])
GO
ALTER TABLE [Core].[tblOffService] CHECK CONSTRAINT [FK_tblOffService_tblServices]
GO
ALTER TABLE [Core].[tblPayments]  WITH CHECK ADD  CONSTRAINT [FK_tblPayments_tblOffService] FOREIGN KEY([OffServiceID])
REFERENCES [Core].[tblOffService] ([id])
GO
ALTER TABLE [Core].[tblPayments] CHECK CONSTRAINT [FK_tblPayments_tblOffService]
GO
ALTER TABLE [Core].[tblPayments]  WITH CHECK ADD  CONSTRAINT [FK_tblPayments_tblPaymentTypes] FOREIGN KEY([PaymentTypeID])
REFERENCES [dbo].[tblPaymentTypes] ([ID])
GO
ALTER TABLE [Core].[tblPayments] CHECK CONSTRAINT [FK_tblPayments_tblPaymentTypes]
GO
ALTER TABLE [Core].[tblPayments]  WITH CHECK ADD  CONSTRAINT [FK_tblPayments_tblServices] FOREIGN KEY([ServiceID])
REFERENCES [Core].[tblServices] ([ID])
GO
ALTER TABLE [Core].[tblPayments] CHECK CONSTRAINT [FK_tblPayments_tblServices]
GO
ALTER TABLE [Core].[tblPayments]  WITH CHECK ADD  CONSTRAINT [FK_tblPayments_tblUsers] FOREIGN KEY([UserID])
REFERENCES [Users].[tblUsers] ([ID])
GO
ALTER TABLE [Core].[tblPayments] CHECK CONSTRAINT [FK_tblPayments_tblUsers]
GO
ALTER TABLE [Core].[tblPeriodicService]  WITH CHECK ADD  CONSTRAINT [FK_tblPeriodicService_tblServices] FOREIGN KEY([ServiceID])
REFERENCES [Core].[tblServices] ([ID])
GO
ALTER TABLE [Core].[tblPeriodicService] CHECK CONSTRAINT [FK_tblPeriodicService_tblServices]
GO
ALTER TABLE [Core].[tblServices]  WITH CHECK ADD  CONSTRAINT [FK_tblServices_ServicesTypes] FOREIGN KEY([TypeID])
REFERENCES [Core].[ServicesTypes] ([ID])
GO
ALTER TABLE [Core].[tblServices] CHECK CONSTRAINT [FK_tblServices_ServicesTypes]
GO
ALTER TABLE [Core].[tblServices]  WITH CHECK ADD  CONSTRAINT [FK_tblServices_tblBranches] FOREIGN KEY([BranchID])
REFERENCES [Org].[tblBranches] ([ID])
GO
ALTER TABLE [Core].[tblServices] CHECK CONSTRAINT [FK_tblServices_tblBranches]
GO
ALTER TABLE [Core].[tblServices]  WITH CHECK ADD  CONSTRAINT [FK_tblServices_tblCategories] FOREIGN KEY([CategoryID])
REFERENCES [Core].[tblCategories] ([ID])
GO
ALTER TABLE [Core].[tblServices] CHECK CONSTRAINT [FK_tblServices_tblCategories]
GO
ALTER TABLE [Core].[tblServices]  WITH CHECK ADD  CONSTRAINT [FK_tblServices_tblOrganizations] FOREIGN KEY([OrganizationID])
REFERENCES [Org].[tblOrganizations] ([ID])
GO
ALTER TABLE [Core].[tblServices] CHECK CONSTRAINT [FK_tblServices_tblOrganizations]
GO
ALTER TABLE [Core].[tblServicesDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblServicesDetail_ServicesDetailType] FOREIGN KEY([TypeID])
REFERENCES [Core].[ServicesDetailType] ([ID])
GO
ALTER TABLE [Core].[tblServicesDetail] CHECK CONSTRAINT [FK_tblServicesDetail_ServicesDetailType]
GO
ALTER TABLE [Core].[tblServicesDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblServicesDetail_tblServices] FOREIGN KEY([ServicesID])
REFERENCES [Core].[tblServices] ([ID])
GO
ALTER TABLE [Core].[tblServicesDetail] CHECK CONSTRAINT [FK_tblServicesDetail_tblServices]
GO
ALTER TABLE [Core].[tblTagNames]  WITH CHECK ADD  CONSTRAINT [FK_tblTagNames_tblPeriodicService] FOREIGN KEY([PeriodicServiceID])
REFERENCES [Core].[tblPeriodicService] ([Id])
GO
ALTER TABLE [Core].[tblTagNames] CHECK CONSTRAINT [FK_tblTagNames_tblPeriodicService]
GO
ALTER TABLE [Core].[tblTransactions]  WITH CHECK ADD  CONSTRAINT [FK_tblTransactions_tblPayments] FOREIGN KEY([PaymentID])
REFERENCES [Core].[tblPayments] ([ID])
GO
ALTER TABLE [Core].[tblTransactions] CHECK CONSTRAINT [FK_tblTransactions_tblPayments]
GO
ALTER TABLE [Org].[tblBranches]  WITH CHECK ADD  CONSTRAINT [FK_tblBranches_tblOrganizations] FOREIGN KEY([OrganizationID])
REFERENCES [Org].[tblOrganizations] ([ID])
GO
ALTER TABLE [Org].[tblBranches] CHECK CONSTRAINT [FK_tblBranches_tblOrganizations]
GO
ALTER TABLE [Users].[tblUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_tblUserRoles_tblRoles] FOREIGN KEY([RoleID])
REFERENCES [Users].[tblRoles] ([ID])
GO
ALTER TABLE [Users].[tblUserRoles] CHECK CONSTRAINT [FK_tblUserRoles_tblRoles]
GO
ALTER TABLE [Users].[tblUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_tblUserRoles_tblUsers] FOREIGN KEY([UserID])
REFERENCES [Users].[tblUsers] ([ID])
GO
ALTER TABLE [Users].[tblUserRoles] CHECK CONSTRAINT [FK_tblUserRoles_tblUsers]
GO
ALTER TABLE [Users].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblUsers_tblBranches] FOREIGN KEY([BranchID])
REFERENCES [Org].[tblBranches] ([ID])
GO
ALTER TABLE [Users].[tblUsers] CHECK CONSTRAINT [FK_tblUsers_tblBranches]
GO
ALTER TABLE [Users].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblUsers_tblOrganizations] FOREIGN KEY([OrganizationID])
REFERENCES [Org].[tblOrganizations] ([ID])
GO
ALTER TABLE [Users].[tblUsers] CHECK CONSTRAINT [FK_tblUsers_tblOrganizations]
GO
/****** Object:  StoredProcedure [dbo].[AddGoogleSearch]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddGoogleSearch]
@UserID bigint, @WebSite nvarchar(50),@TagName nvarchar(50)
AS
BEGIN
	DECLARE @IsActive SMALLINT = (SELECT CASE WHEN @UserID = (SELECT ID FROM Users.tblUsers WHERE UserName = N'sonic') THEN 1 ELSE 0 END)
	IF NOT EXISTS(SELECT 1 FROM Core.tblGoogleClick WHERE UserID = @UserID and Website = @WebSite and TagName = @TagName)
	BEGIN
		INSERT Core.tblGoogleClick(Website,TagName,UserID,TodaySearchedCounts,TodayClickedCounts,TotalSearchedCounts,TotalClickedCounts,CreateDate,IsActive,ClickPerDay)
		VALUES (@WebSite,@TagName,@UserID,0,0,0,0,GETDATE(),@IsActive,0)
	END

	IF NOT EXISTS(SELECT 1 FROM Core.tblGoogleClickScore WHERE UserID = @UserID)
	BEGIN
		INSERT Core.tblGoogleClickScore(UserID,Score)
		VALUES (@UserID,10)
	END

END

  
GO
/****** Object:  StoredProcedure [dbo].[USP_AddGoogleLog]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_AddGoogleLog]
@ClickID BIGINT, @ViewerID BIGINT,@IP NVARCHAR(15),@LogType NVARCHAR(1), @UniqueID NVARCHAR(40)
AS
BEGIN
	INSERT Core.tblGoogleClickLogs(ClickID,ViewerID,DueDate,IP,LogType,UniqueID)
	SELECT @ClickID, @ViewerID, GETDATE(),@IP,@LogType,@UniqueID
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetGoogleSearchQueries]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[USP_GetGoogleSearchQueries]
@UserID bigint = null
AS
BEGIN
	IF @UserID is null
	BEGIN
		SELECT ID,Website,TagName,UserID,UniqueID 
		FROM (
		SELECT ROW_NUMBER() OVER(PARTITION BY GC.UserID, Website ORDER BY TodaySearchedCounts ASC) rowNum,GC.ID,Website,TagName,GC.UserID, CAST(NEWID() AS NVARCHAR(40)) as UniqueID
		FROM Core.tblGoogleClick GC
		LEFT JOIN Core.tblGoogleClickScore GCS ON GC.UserID = GCS.UserID
		WHERE IsActive = 1 and TodaySearchedCounts <= CASE WHEN ClickPerDay <> 0 THEN ClickPerDay ELSE	99999 END  AND GCS.Score > 0
		AND GC.ID NOT IN (SELECT ClickID FROM Core.tblGoogleClickLogs WHERE DueDate BETWEEN DATEADD(MINUTE,-5,GETDATE()) AND  GETDATE())
		) AS source
		WHERE source.rowNum = 1

	END
	ELSE
	BEGIN
		SELECT * FROM Core.tblGoogleClick WHERE UserID = @UserID
	END
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetUserData]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetUserData] 
@UserName NVARCHAR(50)
AS
BEGIN

	SELECT ID , UserName,FirstName,LastName,NationalCode,Password,Salt,Sugar
	FROM  Users.tblUsers 
	WHERE UserName = @UserName

    
END


GO
/****** Object:  StoredProcedure [dbo].[USP_RegisterUser]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_RegisterUser]
 @UserName NVARCHAR(50), @Password NVARCHAR(100), @Salt NVARCHAR(100),@Sugar NVARCHAR(100), 
 @NationalCode NVARCHAR(10),@FirstName NVARCHAR(50), @LastName NVARCHAR(50), @IsCustomer BIT,
 @Mobile NVARCHAR(11)

 AS
BEGIN

	
	INSERT	Users.tblUsers(UserName,FirstName,LastName,NationalCode,Password,Salt,Sugar,Active,LastModifyDate,OrganizationID,BranchID)
	SELECT @UserName,@FirstName,@LastName,@NationalCode,@Password,@Salt,@Sugar,1,SYSDATETIME(),NULL,NULL

	IF(@Mobile <> '')
		INSERT Com.tblUserContactInfo(UserID,Value,TypeID,IsPrimary)
		SELECT (select id from Users.tblUsers where UserName = @UserName),@Mobile,1,1
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateGoogleSearchResults]    Script Date: 7/3/2021 10:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_UpdateGoogleSearchResults]
@ID bigint, @IsClicked NVARCHAR(1), @Who bigint, @IP NVARCHAR(15) = '', @UniqueID NVARCHAR(40) = ''
AS
BEGIN

	DECLARE @tmp AS TABLE(LogTypes INT)
	INSERT @tmp
	SELECT LogType FROM Core.tblGoogleClickLogs WHERE ClickID = @ID AND ViewerID = @Who AND IP = @IP AND UniqueID = @UniqueID 
	IF(@IsClicked = 1
		AND EXISTS(SELECT 1 FROM @tmp WHERE LogTypes = 3)
		AND (SELECT COUNT(1) FROM @tmp WHERE LogTypes IN (1,2)) >= 1
				--AND DATEDIFF(SECOND,DueDate,GETDATE()) > ((SELECT COUNT(1) FROM Users.tblCustomers WHERE ID IN (SELECT ID FROM Core.tblGoogleClick))*55) ))
	)
	BEGIN
		UPDATE Core.tblGoogleClick
		SET TodayClickedCounts += 1
		, TodaySearchedCounts += 1
		, TotalSearchedCounts += 1
		,  TotalClickedCounts += 1
		WHERE ID = @ID

		DECLARE @UserID BIGINT = (select UserID from Core.tblGoogleClick where ID = @ID)
		IF(@Who <> @UserID)
		BEGIN
			UPDATE Core.tblGoogleClickScore
			SET Score += 1
			WHERE UserID = @Who

			UPDATE Core.tblGoogleClickScore
			SET Score -= 1
			WHERE UserID = @UserID
		END
		
	END

	IF(LOWER(FORMAT(GETDATE(),'tt')) = 'am' and FORMAT(GETDATE(),'hh') = '12' AND CAST(FORMAT(GETDATE(),'mm') AS DECIMAL(2,0)) BETWEEN 0 AND 10)
	BEGIN
		UPDATE Core.tblGoogleClick
		SET TodayClickedCounts = 0, TodaySearchedCounts = 0

		DELETE FROM Core.tblGoogleClickLogs WHERE DATEDIFF(MINUTE,DueDate,GETDATE()) > 30
	END
	
END



GO
USE [master]
GO
ALTER DATABASE [BaseDB] SET  READ_WRITE 
GO
