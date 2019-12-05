USE [master]
GO
/****** Object:  Database [Akinator]    Script Date: 4/12/2019 10:41:58 ******/
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
/****** Object:  User [alumno]    Script Date: 4/12/2019 10:41:58 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[filtros]    Script Date: 4/12/2019 10:41:58 ******/
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
/****** Object:  Table [dbo].[Personaje]    Script Date: 4/12/2019 10:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personaje](
	[Id_Personaje] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[foto] [varchar](50) NULL,
 CONSTRAINT [PK_Personaje] PRIMARY KEY CLUSTERED 
(
	[Id_Personaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[respuestas]    Script Date: 4/12/2019 10:41:58 ******/
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
INSERT [dbo].[filtros] ([filtro], [id_Filtro], [esDecisiva]) VALUES (N'sexo', 2, N'1')
INSERT [dbo].[filtros] ([filtro], [id_Filtro], [esDecisiva]) VALUES (N'nombre', 3, N'0')
INSERT [dbo].[filtros] ([filtro], [id_Filtro], [esDecisiva]) VALUES (N'color de pelo', 4, N'0')
INSERT [dbo].[filtros] ([filtro], [id_Filtro], [esDecisiva]) VALUES (N'hobbie', 5, N'1')
SET IDENTITY_INSERT [dbo].[filtros] OFF
SET IDENTITY_INSERT [dbo].[Personaje] ON 

INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (1, N'Anita', N'anita')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (2, N'Barki', N'barki')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (3, N'Binker', N'binker')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (4, N'Cebolla ', N'cebolla')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (5, N'Damian', N'Damian')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (6, N'Flor Lob', N'Flor-Lob')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (7, N'Leo Lob', N'leo-lob')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (8, N'Maga', N'maga')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (9, N'Marcos Wendy', N'Marcos-Wendy')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (10, N'Nati', N'nati')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (11, N'Peter', N'Peter')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (12, N'Stanca', N'Stancrack')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (13, N'Tobi Salem', N'Tobi-Salem')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (14, N'Vero ', N'vero')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (15, N'Yani', N'yani')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (16, N'AFAFWD', N'descarga (2).jfif')
INSERT [dbo].[Personaje] ([Id_Personaje], [nombre], [foto]) VALUES (17, N'saffase', N'descarga (2).jfif')
SET IDENTITY_INSERT [dbo].[Personaje] OFF
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 1, N'coordinador')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 1, N'mujer')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 1, N'Anita')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 1, N'negro')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 1, N'musica')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 2, N'asistente del Labo')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 2, N'Julian')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 2, N'negro')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 2, N'aviones')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 3, N'profesor')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 3, N'hombre')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 2, N'hombre')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 3, N'Ezequiel')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 3, N'castaño')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 3, N'playstation')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 4, N'profesor ')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 4, N'hombre')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 4, N'Ariel')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 4, N'blanco')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 4, N'rugby')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 5, N'director')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 5, N'hombre')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 5, N'Damian')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 5, N'marron')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 5, N'rompecabezas')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 6, N'estudiante')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 6, N'mujer')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 6, N'Flor')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 6, N'castaño')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 6, N'baile')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 7, N'profesor')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 7, N'hombre')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 7, N'Leonardo')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 7, N'negro')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 7, N'paddle')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 8, N'coordinadora')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 8, N'mujer')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 8, N'Magali')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 8, N'rubia')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 8, N'series')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 9, N'estudiante')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 9, N'hombre')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 9, N'Marcos')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 9, N'negro')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 9, N'piano')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 10, N'coordinadora')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 10, N'mujer')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 10, N'Natalie')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 10, N'castaño')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 10, N'peliculas')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 11, N'coordinador')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 11, N'hombre')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 11, N'Ariel')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 11, N'negro')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 11, N'tennis')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 12, N'profesor')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 12, N'hombre')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 12, N'Gabriel')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 12, N'negro')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 12, N'futbol')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 13, N'estudiante')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 13, N'hombre')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 13, N'Tobias')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 13, N'castalo')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 13, N'natacion')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 14, N'profesora')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 14, N'mujer')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 14, N'Veronica')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 14, N'castaño ')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 14, N'aplicar design thinking')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 15, N'profesora')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 15, N'mujer')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 15, N'Yanina')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 15, N'negro')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 15, N'dibujar')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (1, 17, N'sgseg')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (2, 17, N'segsg')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (3, 17, N'esfs')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (4, 17, N'efsef')
INSERT [dbo].[respuestas] ([fk_Filtro], [id_Personaje], [respuesta]) VALUES (5, 17, N'f')
/****** Object:  StoredProcedure [dbo].[SP_AgregarPersonaje]    Script Date: 4/12/2019 10:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_AgregarPersonaje]
@nombre varchar(50),
@foto varchar(50)
as
INSERT INTO [dbo].[Personaje](
            [nombre]
           ,[foto])
     VALUES

          (@nombre,@foto)
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarFiltros]    Script Date: 4/12/2019 10:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_InsertarFiltros]
@profesion varchar(50),
@sexo varchar(50),
@nombre varchar(50),
@pelo varchar(50),
@hobbie varchar(50)
as
declare @idPer varchar(50)

select @idPer = max(Personaje.Id_Personaje) from Personaje 
INSERT INTO [dbo].[respuestas]
           ([fk_Filtro]
           ,[id_Personaje]
           ,[respuesta])
     VALUES
           (1,@idPer,@profesion)
INSERT INTO [dbo].[respuestas]
           ([fk_Filtro]
           ,[id_Personaje]
           ,[respuesta])
     VALUES
           (2,@idPer,@sexo)

INSERT INTO [dbo].[respuestas]
           ([fk_Filtro]
           ,[id_Personaje]
           ,[respuesta])
     VALUES
           (3,@idPer,@nombre)
INSERT INTO [dbo].[respuestas]
           ([fk_Filtro]
           ,[id_Personaje]
           ,[respuesta])
     VALUES
           (4,@idPer,@pelo)

INSERT INTO [dbo].[respuestas]
           ([fk_Filtro]
           ,[id_Personaje]
           ,[respuesta])
     VALUES
           (5,@idPer,@hobbie)






GO
/****** Object:  StoredProcedure [dbo].[sp_traerFiltros]    Script Date: 4/12/2019 10:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_traerFiltros]
as
select filtro, esDecisiva
from filtros
GO
/****** Object:  StoredProcedure [dbo].[sp_traerRespuestas]    Script Date: 4/12/2019 10:41:58 ******/
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
