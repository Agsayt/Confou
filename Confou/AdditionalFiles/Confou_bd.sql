USE [master]
GO
/****** Object:  Database [Beklemishev_Confou]    Script Date: 22.12.2021 20:43:00 ******/
CREATE DATABASE [Beklemishev_Confou]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Beklemishev_Confou', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Beklemishev_Confou.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Beklemishev_Confou_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Beklemishev_Confou_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Beklemishev_Confou] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Beklemishev_Confou].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Beklemishev_Confou] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET ARITHABORT OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Beklemishev_Confou] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Beklemishev_Confou] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Beklemishev_Confou] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Beklemishev_Confou] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET RECOVERY FULL 
GO
ALTER DATABASE [Beklemishev_Confou] SET  MULTI_USER 
GO
ALTER DATABASE [Beklemishev_Confou] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Beklemishev_Confou] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Beklemishev_Confou] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Beklemishev_Confou] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Beklemishev_Confou] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Beklemishev_Confou] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Beklemishev_Confou', N'ON'
GO
ALTER DATABASE [Beklemishev_Confou] SET QUERY_STORE = OFF
GO
USE [Beklemishev_Confou]
GO
/****** Object:  Table [dbo].[ActionType]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionType](
	[ActionId] [int] IDENTITY(1,1) NOT NULL,
	[ActionName] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ActionType] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgeRestrictionTypes]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgeRestrictionTypes](
	[AgeRestrictionId] [int] IDENTITY(1,1) NOT NULL,
	[RestrictionName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_AgeRestrictionTypes] PRIMARY KEY CLUSTERED 
(
	[AgeRestrictionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillingInformation]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillingInformation](
	[BillingId] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NOT NULL,
	[TransactionResult] [bit] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[SellerId] [int] NOT NULL,
	[BuyerEmail] [varchar](30) NOT NULL,
 CONSTRAINT [PK_BillingInformation] PRIMARY KEY CLUSTERED 
(
	[BillingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buyer]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buyer](
	[BuyerEmail] [varchar](30) NOT NULL,
	[UserId] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Buyer] PRIMARY KEY CLUSTERED 
(
	[BuyerEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuyerToTicket]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyerToTicket](
	[BuyerEmail] [varchar](30) NOT NULL,
	[TicketId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DisactivatedAccounts]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DisactivatedAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Reason] [nvarchar](100) NULL,
	[Date] [datetime] NOT NULL,
	[DisactivatedBy] [int] NOT NULL,
	[DisactivatedTime] [datetime] NOT NULL,
	[DisactivatedType] [int] NOT NULL,
 CONSTRAINT [PK_DisactivatedAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DisactivatedTypes]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DisactivatedTypes](
	[DisactivatedTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_DisactivatedTypes] PRIMARY KEY CLUSTERED 
(
	[DisactivatedTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[OrgarnizatorID] [int] NOT NULL,
	[EventName] [nvarchar](50) NOT NULL,
	[HallName] [nvarchar](50) NOT NULL,
	[EventAddress] [nvarchar](100) NOT NULL,
	[EventDescription] [nvarchar](500) NOT NULL,
	[EventDate] [datetime] NOT NULL,
	[EventStatus] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[AgeRestriction] [int] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventStatuses]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventStatuses](
	[EventStatusId] [int] NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EventStatuses] PRIMARY KEY CLUSTERED 
(
	[EventStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logging]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logging](
	[LogId] [int] NOT NULL,
	[Action] [int] NOT NULL,
	[TargetTable] [nvarchar](20) NOT NULL,
	[TargetId] [int] NOT NULL,
	[Author] [int] NOT NULL,
	[AuthorIP] [varchar](11) NOT NULL,
	[ActionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Logging] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[OrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[AssigneeId] [int] NOT NULL,
	[OrganizationName] [nvarchar](100) NOT NULL,
	[OrganizationINN] [numeric](12, 0) NOT NULL,
	[Fee] [numeric](2, 2) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateAuthor] [int] NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seller](
	[SellerId] [int] IDENTITY(1,1) NOT NULL,
	[AssigneeId] [int] NOT NULL,
	[SellerAddress] [nvarchar](100) NOT NULL,
	[SellerName] [nvarchar](30) NOT NULL,
	[SellerTickets] [int] NOT NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[SellerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerToTicket]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerToTicket](
	[SellerId] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketPlacementType]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketPlacementType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlacementName] [nvarchar](20) NOT NULL,
	[PlacementNumber] [int] NULL,
 CONSTRAINT [PK_TicketPlacementType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketPool]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketPool](
	[EventId] [int] NOT NULL,
	[TicketTypeId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
	[Seat] [int] NOT NULL,
	[TicketCode] [uniqueidentifier] NOT NULL,
	[SoldDate] [datetime] NOT NULL,
	[SoldBy] [int] NOT NULL,
	[BillingId] [int] NOT NULL,
	[TicketStatus] [int] NOT NULL,
	[Placement] [int] NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketStatuses]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketStatuses](
	[TicketStatusId] [int] IDENTITY(1,1) NOT NULL,
	[TicketStatusName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TicketStatuses] PRIMARY KEY CLUSTERED 
(
	[TicketStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketType]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketType](
	[TicketTypeId] [int] NOT NULL,
	[TicketName] [nvarchar](30) NOT NULL,
	[TicketPrice] [decimal](18, 2) NOT NULL,
	[TicketAmount] [int] NOT NULL,
	[TicketTypeStatus] [int] NOT NULL,
	[TicketVisibility] [bit] NOT NULL,
 CONSTRAINT [PK_TicketType] PRIMARY KEY CLUSTERED 
(
	[TicketTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketTypeStatuses]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketTypeStatuses](
	[TicketTypeStatusId] [int] IDENTITY(1,1) NOT NULL,
	[TypeStatusName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_TicketTypeStatuses] PRIMARY KEY CLUSTERED 
(
	[TicketTypeStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22.12.2021 20:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(100,1) NOT NULL,
	[Login] [varchar](30) NOT NULL,
	[PasswordHash] [varchar](100) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[MiddleName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateAuthor] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BillingInformation]  WITH CHECK ADD  CONSTRAINT [FK_BillingInformation_Buyer] FOREIGN KEY([BuyerEmail])
REFERENCES [dbo].[Buyer] ([BuyerEmail])
GO
ALTER TABLE [dbo].[BillingInformation] CHECK CONSTRAINT [FK_BillingInformation_Buyer]
GO
ALTER TABLE [dbo].[BillingInformation]  WITH CHECK ADD  CONSTRAINT [FK_BillingInformation_Seller] FOREIGN KEY([SellerId])
REFERENCES [dbo].[Seller] ([SellerId])
GO
ALTER TABLE [dbo].[BillingInformation] CHECK CONSTRAINT [FK_BillingInformation_Seller]
GO
ALTER TABLE [dbo].[Buyer]  WITH CHECK ADD  CONSTRAINT [FK_Buyer_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Buyer] CHECK CONSTRAINT [FK_Buyer_Users]
GO
ALTER TABLE [dbo].[BuyerToTicket]  WITH CHECK ADD  CONSTRAINT [FK_BuyerToTicket_Buyer] FOREIGN KEY([BuyerEmail])
REFERENCES [dbo].[Buyer] ([BuyerEmail])
GO
ALTER TABLE [dbo].[BuyerToTicket] CHECK CONSTRAINT [FK_BuyerToTicket_Buyer]
GO
ALTER TABLE [dbo].[BuyerToTicket]  WITH CHECK ADD  CONSTRAINT [FK_BuyerToTicket_Tickets] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([TicketId])
GO
ALTER TABLE [dbo].[BuyerToTicket] CHECK CONSTRAINT [FK_BuyerToTicket_Tickets]
GO
ALTER TABLE [dbo].[DisactivatedAccounts]  WITH CHECK ADD  CONSTRAINT [FK_DisactivatedAccounts_DisactivatedTypes] FOREIGN KEY([DisactivatedType])
REFERENCES [dbo].[DisactivatedTypes] ([DisactivatedTypeId])
GO
ALTER TABLE [dbo].[DisactivatedAccounts] CHECK CONSTRAINT [FK_DisactivatedAccounts_DisactivatedTypes]
GO
ALTER TABLE [dbo].[DisactivatedAccounts]  WITH CHECK ADD  CONSTRAINT [FK_DisactivatedAccounts_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[DisactivatedAccounts] CHECK CONSTRAINT [FK_DisactivatedAccounts_Users]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_AgeRestrictionTypes] FOREIGN KEY([AgeRestriction])
REFERENCES [dbo].[AgeRestrictionTypes] ([AgeRestrictionId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_AgeRestrictionTypes]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventStatuses] FOREIGN KEY([EventStatus])
REFERENCES [dbo].[EventStatuses] ([EventStatusId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventStatuses]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Organizations] FOREIGN KEY([OrgarnizatorID])
REFERENCES [dbo].[Organizations] ([OrganizationID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Organizations]
GO
ALTER TABLE [dbo].[Logging]  WITH CHECK ADD  CONSTRAINT [FK_Logging_ActionType] FOREIGN KEY([Action])
REFERENCES [dbo].[ActionType] ([ActionId])
GO
ALTER TABLE [dbo].[Logging] CHECK CONSTRAINT [FK_Logging_ActionType]
GO
ALTER TABLE [dbo].[Organizations]  WITH CHECK ADD  CONSTRAINT [FK_Organizations_Users] FOREIGN KEY([AssigneeId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Organizations] CHECK CONSTRAINT [FK_Organizations_Users]
GO
ALTER TABLE [dbo].[Seller]  WITH CHECK ADD  CONSTRAINT [FK_Seller_Users] FOREIGN KEY([AssigneeId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Seller] CHECK CONSTRAINT [FK_Seller_Users]
GO
ALTER TABLE [dbo].[SellerToTicket]  WITH CHECK ADD  CONSTRAINT [FK_SellerToTicket_Seller] FOREIGN KEY([SellerId])
REFERENCES [dbo].[Seller] ([SellerId])
GO
ALTER TABLE [dbo].[SellerToTicket] CHECK CONSTRAINT [FK_SellerToTicket_Seller]
GO
ALTER TABLE [dbo].[SellerToTicket]  WITH CHECK ADD  CONSTRAINT [FK_SellerToTicket_Tickets] FOREIGN KEY([SellerId])
REFERENCES [dbo].[Tickets] ([TicketId])
GO
ALTER TABLE [dbo].[SellerToTicket] CHECK CONSTRAINT [FK_SellerToTicket_Tickets]
GO
ALTER TABLE [dbo].[TicketPool]  WITH CHECK ADD  CONSTRAINT [FK_TicketPool_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[TicketPool] CHECK CONSTRAINT [FK_TicketPool_Events]
GO
ALTER TABLE [dbo].[TicketPool]  WITH CHECK ADD  CONSTRAINT [FK_TicketPool_TicketType] FOREIGN KEY([TicketTypeId])
REFERENCES [dbo].[TicketType] ([TicketTypeId])
GO
ALTER TABLE [dbo].[TicketPool] CHECK CONSTRAINT [FK_TicketPool_TicketType]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_BillingInformation] FOREIGN KEY([BillingId])
REFERENCES [dbo].[BillingInformation] ([BillingId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_BillingInformation]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Events]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_TicketPlacementType] FOREIGN KEY([Placement])
REFERENCES [dbo].[TicketPlacementType] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_TicketPlacementType]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_TicketStatuses] FOREIGN KEY([TicketStatus])
REFERENCES [dbo].[TicketStatuses] ([TicketStatusId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_TicketStatuses]
GO
ALTER TABLE [dbo].[TicketType]  WITH CHECK ADD  CONSTRAINT [FK_TicketType_TicketTypeStatuses] FOREIGN KEY([TicketTypeStatus])
REFERENCES [dbo].[TicketTypeStatuses] ([TicketTypeStatusId])
GO
ALTER TABLE [dbo].[TicketType] CHECK CONSTRAINT [FK_TicketType_TicketTypeStatuses]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([UserId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [Beklemishev_Confou] SET  READ_WRITE 
GO
