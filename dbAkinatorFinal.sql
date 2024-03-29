USE [master]
GO
/****** Object:  Database [Akinator]    Script Date: 4/12/2019 08:09:02 ******/
CREATE DATABASE [Akinator]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Akinator', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Akinator.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Akinator_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Akinator_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Akinator] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Akinator].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Akinator] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Akinator] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Akinator] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Akinator] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Akinator] SET ARITHABORT OFF 
GO
ALTER DATABASE [Akinator] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Akinator] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Akinator] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Akinator] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Akinator] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Akinator] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Akinator] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Akinator] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Akinator] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Akinator] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Akinator] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Akinator] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Akinator] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Akinator] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Akinator] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Akinator] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Akinator] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Akinator] SET RECOVERY FULL 
GO
ALTER DATABASE [Akinator] SET  MULTI_USER 
GO
ALTER DATABASE [Akinator] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Akinator] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Akinator] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Akinator] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Akinator] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Akinator', N'ON'
GO
ALTER DATABASE [Akinator] SET QUERY_STORE = OFF
GO
USE [Akinator]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Akinator]
GO
/****** Object:  User [alumno]    Script Date: 4/12/2019 08:09:02 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[filtros]    Script Date: 4/12/2019 08:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[filtros](
	[filtro] [varchar](50) NOT NULL,
	[id_Filtro] [int] IDENTITY(1,1) NOT NULL,
	[esDecisiva] [varchar](1) NULL,
 CONSTRAINT [PK_filtros] PRIMARY KEY CLUSTERED 
(
	[id_Filtro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personaje]    Script Date: 4/12/2019 08:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personaje](
	[Id_Personaje] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[foto] [varbinary](50) NULL,
 CONSTRAINT [PK_Personaje] PRIMARY KEY CLUSTERED 
(
	[Id_Personaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[respuestas]    Script Date: 4/12/2019 08:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[respuestas](
	[fk_Filtro] [int] NOT NULL,
	[id_Personaje] [int] NOT NULL,
	[respuesta] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[filtros] ON 

INSERT [dbo].[filtros] ([filtro], [id_Filtro], [esDecisiva]) VALUES (N'profesion', 1, N'1')
INSERT [dbo].[filtros] ([filtro], [id_Filtro], [esDecisiva]) VALUES (N'edad', 2, N'1')
INSERT [dbo].[filtros] ([filtro], [id_Filtro], [esDecisiva]) VALUES (N'nombre', 3, N'0')
INSERT [dbo].[filtros] ([filtro], [id_Filtro], [esDecisiva]) VALUES (N'color de pelo', 4, N'0')
SET IDENTITY_INSERT [dbo].[filtros] OFF
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 1, N'deportista')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 1, N'18')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 2, N'artista')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 2, N'18')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 1, N'Juan')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 1, N'deportista')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 1, N'18')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 2, N'artista')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 2, N'18')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 1, N'Juan')
ALTER TABLE [dbo].[respuestas]  WITH CHECK ADD  CONSTRAINT [FK_respuestas_filtros] FOREIGN KEY([fk_Filtro])
REFERENCES [dbo].[filtros] ([id_Filtro])
GO
ALTER TABLE [dbo].[respuestas] CHECK CONSTRAINT [FK_respuestas_filtros]
GO
/****** Object:  StoredProcedure [dbo].[sp_traerFiltros]    Script Date: 4/12/2019 08:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_traerFiltros]
as
select filtro, esDecisiva
from filtros
GO
/****** Object:  StoredProcedure [dbo].[sp_traerRespuestas]    Script Date: 4/12/2019 08:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_traerRespuestas]
as
SELECT filtros.filtro, respuestas.id_Personaje, respuestas.respuesta 
from respuestas
inner join filtros on respuestas.fk_Filtro = filtros.id_Filtro


GO
USE [master]
GO
ALTER DATABASE [Akinator] SET  READ_WRITE 
GO
