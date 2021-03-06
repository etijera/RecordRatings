USE [master]
GO
/****** Object:  Database [RECORDRATINGS]    Script Date: 09/02/2016 13:16:17 ******/
CREATE DATABASE [RECORDRATINGS]
 CONTAINMENT = NONE
GO
ALTER DATABASE [RECORDRATINGS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RECORDRATINGS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RECORDRATINGS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET ARITHABORT OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RECORDRATINGS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RECORDRATINGS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RECORDRATINGS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RECORDRATINGS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET RECOVERY FULL 
GO
ALTER DATABASE [RECORDRATINGS] SET  MULTI_USER 
GO
ALTER DATABASE [RECORDRATINGS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RECORDRATINGS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RECORDRATINGS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RECORDRATINGS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [RECORDRATINGS] SET DELAYED_DURABILITY = DISABLED 
GO
USE [RECORDRATINGS]
GO
/****** Object:  UserDefinedFunction [dbo].[PADL]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:  Igor Nikiforov,  Montreal,  EMail: udfunctions@gmail.com   
 -- PADL(), PADR(), PADC() User-Defined Functions
 -- Returns a string from an expression, padded with spaces or characters to a specified length on the left or right sides, or both.
 -- PADL similar to the Oracle function PL/SQL  LPAD 
CREATE function [dbo].[PADL]  (@cString nvarchar(4000), @nLen smallint, @cPadCharacter nvarchar(4000) = ' ' )
returns nvarchar(4000)
as
  begin
        declare @length smallint, @lengthPadCharacter smallint
        if @cPadCharacter is NULL or  datalength(@cPadCharacter) = 0
           set @cPadCharacter = space(1) 
        select  @length = datalength(@cString)/(case SQL_VARIANT_PROPERTY(@cString,'BaseType') when 'nvarchar' then 2  else 1 end) -- for unicode
        select  @lengthPadCharacter = datalength(@cPadCharacter)/(case SQL_VARIANT_PROPERTY(@cPadCharacter,'BaseType') when 'nvarchar' then 2  else 1 end) -- for unicode

        if @length >= @nLen
           set  @cString = left(@cString, @nLen)
        else
	       begin
              declare @nLeftLen smallint
              set @nLeftLen = @nLen - @length  -- Quantity of characters, added at the left
              set @cString = left(replicate(@cPadCharacter, ceiling(@nLeftLen/@lengthPadCharacter) + 2), @nLeftLen)+ @cString
           end

    return (@cString)
  end

GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumnos](
	[IdPersona] [int] NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Alumnos_delmrk]  DEFAULT ((1)),
	[CodigoAlum] [varchar](8) NOT NULL CONSTRAINT [DF_Alumnos_CodigoAlum]  DEFAULT (''),
	[Carnet] [varchar](20) NOT NULL,
	[Estado] [varchar](2) NOT NULL CONSTRAINT [DF_Alumnos_Estado]  DEFAULT ('I'),
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[CodigoAlum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Areas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Areas_delmrk]  DEFAULT ((1)),
	[Codigo] [varchar](2) NOT NULL CONSTRAINT [DF_Areas_Codigo]  DEFAULT (''),
	[Nombre] [varchar](150) NOT NULL CONSTRAINT [DF_Areas_Nombre]  DEFAULT (''),
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CursoAlumnos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CursoAlumnos](
	[CodigoAlum] [varchar](8) NOT NULL CONSTRAINT [DF_CursoAlumnos_CodigoAlum]  DEFAULT (''),
	[CodigoCurso] [varchar](4) NOT NULL CONSTRAINT [DF_CursoAlumnos_CodigoCurso]  DEFAULT (''),
	[AñoElectivo] [int] NOT NULL CONSTRAINT [DF_CursoAlumnos_AñoElectivo]  DEFAULT ((0)),
 CONSTRAINT [PK_CursoAlumnos] PRIMARY KEY CLUSTERED 
(
	[CodigoAlum] ASC,
	[CodigoCurso] ASC,
	[AñoElectivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cursos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Cursos_delmrk]  DEFAULT ((1)),
	[CodigoCurso] [varchar](4) NOT NULL CONSTRAINT [DF_Cursos_CodigoCurso]  DEFAULT (''),
	[CodGrupo] [varchar](2) NOT NULL CONSTRAINT [DF_Cursos_CodGrupo]  DEFAULT (''),
	[CodGrado] [varchar](2) NOT NULL CONSTRAINT [DF_Cursos_CodGrado]  DEFAULT (''),
	[Jornada] [varchar](50) NOT NULL CONSTRAINT [DF_Cursos_Jornada]  DEFAULT (''),
	[Nombre] [varchar](20) NOT NULL CONSTRAINT [DF_Cursos_Nombre]  DEFAULT (''),
 CONSTRAINT [PK_Cursos] PRIMARY KEY CLUSTERED 
(
	[CodigoCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Desempeños]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Desempeños](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Desempeños_delmrk]  DEFAULT ((1)),
	[CodigoDesemp] [varchar](2) NOT NULL CONSTRAINT [DF_Desempeños_CodigoDesemp]  DEFAULT (''),
	[Nombre] [varchar](100) NOT NULL CONSTRAINT [DF_Desempeños_Nombre]  DEFAULT (''),
	[NotaMin] [numeric](18, 2) NOT NULL CONSTRAINT [DF_Desempeños_NotaMin]  DEFAULT ((0)),
	[NotaMax] [numeric](18, 2) NOT NULL CONSTRAINT [DF_Desempeños_NotaMax]  DEFAULT ((0)),
 CONSTRAINT [PK_Desempeños] PRIMARY KEY CLUSTERED 
(
	[CodigoDesemp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grados]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Grados_delmrk]  DEFAULT ((1)),
	[CodigoGrado] [varchar](2) NOT NULL CONSTRAINT [DF_Grados_CodigoGrado]  DEFAULT (''),
	[Nombre] [varchar](50) NOT NULL CONSTRAINT [DF_Grados_Nombre]  DEFAULT (''),
	[Numero] [int] NOT NULL CONSTRAINT [DF_Grados_Numero]  DEFAULT ((0)),
 CONSTRAINT [PK_Grados] PRIMARY KEY CLUSTERED 
(
	[CodigoGrado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grupos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Grupos_delmrk]  DEFAULT ((1)),
	[CodigoGrupo] [varchar](2) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Grupos] PRIMARY KEY CLUSTERED 
(
	[CodigoGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Institucion]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Institucion](
	[Nombre] [varchar](350) NOT NULL CONSTRAINT [DF_Empresa_Nombre]  DEFAULT (''),
	[Nit] [varchar](50) NOT NULL CONSTRAINT [DF_Empresa_Nit]  DEFAULT (''),
	[Direccion] [varchar](350) NOT NULL CONSTRAINT [DF_Empresa_Direccion]  DEFAULT (''),
	[Telefono] [varchar](50) NOT NULL CONSTRAINT [DF_Empresa_Telefono]  DEFAULT (''),
	[Email] [varchar](100) NOT NULL CONSTRAINT [DF_Empresa_Email]  DEFAULT (''),
	[Resolusion] [varchar](250) NOT NULL CONSTRAINT [DF_Empresa_Resolusion]  DEFAULT (''),
	[CodigoDane] [varchar](50) NOT NULL CONSTRAINT [DF_Table_1_Codigo Dane]  DEFAULT (''),
	[Abreviaura] [varchar](50) NOT NULL,
	[Lema] [varchar](150) NOT NULL CONSTRAINT [DF_Empresa_Lema]  DEFAULT (''),
	[Director] [varchar](150) NOT NULL CONSTRAINT [DF_Empresa_Director]  DEFAULT (''),
	[Secretaria] [varchar](150) NOT NULL CONSTRAINT [DF_Empresa_Secretaria]  DEFAULT (''),
	[Coordinador] [varchar](150) NOT NULL CONSTRAINT [DF_Empresa_Coordinador]  DEFAULT (''),
	[Logo] [varchar](800) NOT NULL CONSTRAINT [DF_Empresa_Logo]  DEFAULT ('')
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Materias_delmrk]  DEFAULT ((1)),
	[CodArea] [varchar](2) NOT NULL CONSTRAINT [DF_Materias_CodArea]  DEFAULT (''),
	[CodMateria] [varchar](3) NOT NULL CONSTRAINT [DF_Materias_CodMateria]  DEFAULT (''),
	[Nombre] [varchar](150) NOT NULL CONSTRAINT [DF_Materias_Nombre]  DEFAULT (''),
 CONSTRAINT [PK_Materias] PRIMARY KEY CLUSTERED 
(
	[CodMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MateriasCursos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MateriasCursos](
	[CodCurso] [varchar](4) NOT NULL CONSTRAINT [DF_MateriasCursos_CodCurso]  DEFAULT (''),
	[CodMateria] [varchar](3) NOT NULL CONSTRAINT [DF_MateriasCursos_CodMateria]  DEFAULT (''),
	[IHS] [int] NOT NULL CONSTRAINT [DF_MateriasCursos_IHS]  DEFAULT ((0)),
	[CodProfesor] [varchar](6) NOT NULL CONSTRAINT [DF_MateriasCursos_CodProfesor]  DEFAULT (''),
 CONSTRAINT [PK_MateriasCursos] PRIMARY KEY CLUSTERED 
(
	[CodCurso] ASC,
	[CodMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Niveles]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Niveles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Niveles_delmrk]  DEFAULT ((1)),
	[CodNivel] [varchar](2) NOT NULL CONSTRAINT [DF_Niveles_CodNivel]  DEFAULT (''),
	[Nombre] [varchar](150) NOT NULL CONSTRAINT [DF_Niveles_Nombre]  DEFAULT (''),
 CONSTRAINT [PK_Niveles] PRIMARY KEY CLUSTERED 
(
	[CodNivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Periodos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Periodos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Periodos_delmrk]  DEFAULT ((1)),
	[CodigoPeriodo] [varchar](2) NOT NULL CONSTRAINT [DF_Periodos_CodPeriodo]  DEFAULT (''),
	[Nombre] [varchar](50) NOT NULL,
	[Numero] [int] NOT NULL CONSTRAINT [DF_Periodos_Numero]  DEFAULT ((0)),
	[Porcentaje] [int] NOT NULL CONSTRAINT [DF_Periodos_Porcentaje]  DEFAULT ((0)),
 CONSTRAINT [PK_Periodos] PRIMARY KEY CLUSTERED 
(
	[CodigoPeriodo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Personas_delmrk]  DEFAULT ((1)),
	[Nombre] [varchar](200) NOT NULL CONSTRAINT [DF_Personas_Nombre]  DEFAULT (''),
	[PrimerNombre] [varchar](50) NOT NULL CONSTRAINT [DF_Personas_PrimerNombre]  DEFAULT (''),
	[SegundoNombre] [varchar](50) NOT NULL CONSTRAINT [DF_Personas_SegundoNombre]  DEFAULT (''),
	[PrimerApellido] [varchar](50) NOT NULL CONSTRAINT [DF_Personas_PrimerApellido]  DEFAULT (''),
	[SegundoApellido] [varchar](50) NOT NULL CONSTRAINT [DF_Personas_SegundoApellido]  DEFAULT (''),
	[Identificacion] [varchar](50) NOT NULL CONSTRAINT [DF_Personas_Identificacion]  DEFAULT (''),
	[Direccion] [varchar](150) NOT NULL CONSTRAINT [DF_Personas_Direccion]  DEFAULT (''),
	[Telefono] [varchar](50) NOT NULL CONSTRAINT [DF_Personas_Telefono]  DEFAULT (''),
	[Email] [varchar](150) NOT NULL CONSTRAINT [DF_Personas_Email]  DEFAULT (''),
	[Sexo] [varchar](1) NOT NULL CONSTRAINT [DF_Personas_Sexo]  DEFAULT ('M'),
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonaUsuarios]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonaUsuarios](
	[IdPersona] [int] NOT NULL,
	[CodUsuario] [varchar](8) NOT NULL CONSTRAINT [DF_PersonaUsuarios_CodUsuario]  DEFAULT (''),
	[CodTipoUsuario] [varchar](2) NOT NULL CONSTRAINT [DF_PersonaUsuarios_CodTipoUsuario]  DEFAULT (''),
 CONSTRAINT [PK_PersonaUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC,
	[CodUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profesores](
	[IdPersona] [int] NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Profesores_delmrk]  DEFAULT ((1)),
	[CodigoProfesor] [varchar](6) NOT NULL,
	[Estado] [varchar](2) NOT NULL CONSTRAINT [DF_Profesores_Estado]  DEFAULT ('I'),
 CONSTRAINT [PK_Profesores] PRIMARY KEY CLUSTERED 
(
	[CodigoProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProfesorMaterias]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProfesorMaterias](
	[CodMateria] [varchar](3) NOT NULL CONSTRAINT [DF_ProfesorMaterias_CodMateria]  DEFAULT (''),
	[CodigoProfesor] [varchar](6) NOT NULL CONSTRAINT [DF_ProfesorMaterias_CodigoProfesor]  DEFAULT (''),
 CONSTRAINT [PK_ProfesorMaterias] PRIMARY KEY CLUSTERED 
(
	[CodMateria] ASC,
	[CodigoProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegistroNotas]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegistroNotas](
	[CodAlumno] [varchar](8) NOT NULL CONSTRAINT [DF_RegistroNotas_CodAlumno]  DEFAULT (''),
	[CodProfesor] [varchar](6) NOT NULL CONSTRAINT [DF_RegistroNotas_CodProfesor]  DEFAULT (''),
	[CodCurso] [varchar](4) NOT NULL CONSTRAINT [DF_RegistroNotas_CodCurso]  DEFAULT (''),
	[CodMateria] [varchar](3) NOT NULL CONSTRAINT [DF_RegistroNotas_CodMateria]  DEFAULT (''),
	[CodPeriodo] [varchar](2) NOT NULL CONSTRAINT [DF_RegistroNotas_CodPeriodo]  DEFAULT (''),
	[Nota1] [numeric](18, 2) NOT NULL CONSTRAINT [DF_RegistroNotas_Nota1]  DEFAULT ((0)),
	[PorcN1] [numeric](18, 2) NOT NULL CONSTRAINT [DF_RegistroNotas_PorcN1]  DEFAULT ((0)),
	[Nota2] [numeric](18, 2) NOT NULL CONSTRAINT [DF_RegistroNotas_Nota2]  DEFAULT ((0)),
	[PorcN2] [numeric](18, 2) NOT NULL CONSTRAINT [DF_RegistroNotas_PorcN2]  DEFAULT ((0)),
	[Nota3] [numeric](18, 2) NOT NULL CONSTRAINT [DF_RegistroNotas_Nota3]  DEFAULT ((0)),
	[PorcN3] [numeric](18, 2) NOT NULL CONSTRAINT [DF_RegistroNotas_PorcN3]  DEFAULT ((0)),
	[Nota4] [numeric](18, 2) NOT NULL CONSTRAINT [DF_RegistroNotas_Nota4]  DEFAULT ((0)),
	[PorcN4] [numeric](18, 2) NOT NULL CONSTRAINT [DF_RegistroNotas_PorcN4]  DEFAULT ((0)),
	[NotaFinal] [numeric](18, 2) NOT NULL CONSTRAINT [DF_RegistroNotas_Nota]  DEFAULT ((0)),
	[Fallas] [int] NOT NULL CONSTRAINT [DF_RegistroNotas_Fallas]  DEFAULT ((0)),
	[AñoElectivo] [int] NOT NULL CONSTRAINT [DF_RegistroNotas_AñoElectivo]  DEFAULT ((0))
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoUsuarios]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoUsuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_TipoUsuarios_delmrk]  DEFAULT ((1)),
	[Codigo] [varchar](2) NOT NULL CONSTRAINT [DF_TipoUsuarios_Codigo]  DEFAULT (''),
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoUsuarios] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[delmrk] [varchar](1) NOT NULL CONSTRAINT [DF_Usuarios_delmrk]  DEFAULT ((1)),
	[Codigo] [varchar](8) NOT NULL CONSTRAINT [DF_Usuarios_Codigo]  DEFAULT (''),
	[Nombre] [varchar](50) NOT NULL CONSTRAINT [DF_Usuarios_Nombre]  DEFAULT (''),
	[Contrasenia] [varchar](50) NOT NULL CONSTRAINT [DF_Table_1_Contraseña]  DEFAULT (''),
	[CodTipoUsuario] [varchar](2) NOT NULL CONSTRAINT [DF_Usuarios_TipoUsuario]  DEFAULT (''),
 CONSTRAINT [PK_Usuarios_1] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[PA_Alumnos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Alumnos] 
		@Operacion			VARCHAR(20)		= NULL
		,@Id				INT				= NULL
		,@CodigoAlum		VARCHAR(8)		= NULL	
		,@Carnet			VARCHAR(20)		= NULL	
		,@Nombre			VARCHAR(200)	= NULL
		,@PrimerNombre		VARCHAR(50)		= NULL
		,@SegundoNombre		VARCHAR(50)		= NULL
		,@PrimerApellido	VARCHAR(50)		= NULL
		,@SegundoApellido	VARCHAR(50)		= NULL
		,@Identificacion	VARCHAR(50)		= NULL
		,@Direccion			VARCHAR(150)	= NULL
		,@Telefono			VARCHAR(150)	= NULL
		,@Email				VARCHAR(150)	= NULL
		,@Sexo				VARCHAR(1)		= NULL		
		,@AñoElectivo		INT				= NULL
		,@Contrasenia		VARCHAR(50)	= NULL
		,@CodTipoUsuario	VARCHAR(2)	= NULL
		,@NombreUsuario		VARCHAR(50)	= NULL
		,@Estado			VARCHAR(2)	= NULL
	AS

	BEGIN
		
		DECLARE @CodAlumno VARCHAR(8)		
		SET		@CodAlumno = 'ALU00000'

		DECLARE @CodUsuario VARCHAR(8)		
		SET		@CodUsuario = 'USU00000'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Personas.Id
					,Alumnos.CodigoAlum
					,Personas.Nombre
					,Personas.PrimerNombre
					,Personas.SegundoNombre
					,Personas.PrimerApellido
					,Personas.SegundoApellido
					,Personas.Identificacion
					,Alumnos.Carnet
					,Personas.Direccion
					,Personas.Telefono
					,Personas.Email
					,Personas.Sexo
					,Alumnos.Estado
			FROM	Alumnos WITH(nolock) 
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
			WHERE	Personas.Id = @Id 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Personas.Id
					,Alumnos.CodigoAlum
					,Personas.Nombre
					,Personas.Identificacion
					,Alumnos.Carnet
					,ISNULL(Cursos.Nombre, 'NO ASIGNADO') AS Curso
					,CASE 
						WHEN Alumnos.Estado = 'A' THEN 'ACTIVO'
						WHEN Alumnos.Estado = 'S' THEN 'SUSPENDIDO'
						WHEN Alumnos.Estado = 'E' THEN 'EXPULSADO'
						WHEN Alumnos.Estado = 'R' THEN 'RETIRADO'
						ELSE 'INACTIVO'
					END								AS Estado
					,Personas.Email
			FROM	Alumnos WITH(nolock) 
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
					LEFT JOIN  CursoAlumnos ON CursoAlumnos.CodigoAlum = Alumnos.CodigoAlum AND CursoAlumnos.AñoElectivo = @AñoElectivo
					LEFT JOIN  Cursos ON Cursos.CodigoCurso = CursoAlumnos.CodigoCurso
			WHERE	Alumnos.delmrk = '1'			
		END

		IF @Operacion = 'SELECTIDENTI'
		BEGIN
			SELECT	*
			FROM	Personas WITH(nolock) 
			WHERE	Personas.delmrk = '1'
					AND Identificacion = @Identificacion
		END
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodAlumno = 'ALU'+LTRIM(RTRIM(DBO.PadL(ISNULL(count(CodigoAlum),0)+1,5,'0'))) FROM Alumnos
			SELECT @CodUsuario = 'USU'+LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,5,'0'))) FROM Usuarios

			INSERT INTO Personas	(Nombre
									,PrimerNombre
									,SegundoNombre
									,PrimerApellido
									,SegundoApellido
									,Identificacion
									,Direccion
									,Telefono
									,Sexo
									,Email)
			VALUES					(@Nombre
									,@PrimerNombre
									,@SegundoNombre
									,@PrimerApellido
									,@SegundoApellido
									,@Identificacion
									,@Direccion
									,@Telefono
									,@Sexo
									,@Email)

			SELECT @Id = @@IDENTITY

			INSERT INTO Alumnos (	IdPersona
									,CodigoAlum
									,Carnet
									,Estado)
			VALUES				(	@Id
									,@CodAlumno
									,@Carnet
									,@Estado)

			INSERT INTO Usuarios	(Codigo
									,Nombre
									,Contrasenia
									,CodTipoUsuario)
			VALUES					(@CodUsuario
									,@NombreUsuario
									,@Contrasenia
									,@CodTipoUsuario)

			INSERT INTO PersonaUsuarios (IdPersona
										,CodUsuario
										,CodTipoUsuario)
			VALUES						(@Id
										,@CodUsuario
										,@CodTipoUsuario)
			

			SELECT @Id AS IdPersona,@CodAlumno AS CodAlumno
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Personas 
			SET		Nombre				= @Nombre
					,PrimerNombre		= @PrimerNombre
					,SegundoNombre		= @SegundoNombre
					,PrimerApellido		= @PrimerApellido
					,SegundoApellido	= @SegundoApellido
					,Identificacion		= @Identificacion
					,Direccion			= @Direccion
					,Telefono			= @Telefono
					,Email				= @Email	
					,Sexo				= @Sexo							
			WHERE	Id = @Id

			UPDATE	Alumnos 
			SET		Carnet		= @Carnet
					,Estado				= @Estado
			WHERE	IdPersona	= @Id

			SELECT Alumnos.CodigoAlum AS CodAlumno  FROM Alumnos
			WHERE  Alumnos.IdPersona = @Id
		END

		IF @Operacion = 'DEL'
		BEGIN
			SELECT @CodUsuario = CodUsuario FROM PersonaUsuarios WHERE IdPersona = @Id

			DELETE FROM PersonaUsuarios WHERE IdPersona = @Id

			DELETE FROM Usuarios WHERE Codigo = @CodUsuario

			DELETE FROM Alumnos WHERE	IdPersona	= @Id

			DELETE FROM Personas WHERE	Id	= @Id

			--UPDATE	Alumnos 
			--SET		delmrk		= '0'
			--WHERE	IdPersona	= @Id
			
			--UPDATE	Personas 
			--SET		delmrk		= '0'
			--WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Areas]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Areas] 
		@Operacion			VARCHAR(20)	= NULL
		,@Id				INT			= NULL
		,@Codigo			VARCHAR(2)	= NULL	
		,@Nombre			VARCHAR(150)= NULL
	AS

	BEGIN
		
		DECLARE @CodArea VARCHAR(2)		
		SET		@CodArea = '00'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Areas.Id
					,Areas.Codigo
					,Areas.Nombre					
			FROM	Areas WITH(nolock) 
			WHERE	Areas.Id = @Id 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Areas.Id
					,Areas.Codigo
					,Areas.Nombre					
			FROM	Areas WITH(nolock) 
			WHERE	Areas.delmrk = '1'			
		END	
		
		IF @Operacion = 'SELECTNAME'
		BEGIN
			SELECT	* 
			FROM	Areas 
			WHERE	delmrk = '1' 
					AND Nombre = @Nombre
		END	
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodArea = LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,2,'0'))) FROM Areas

			INSERT INTO Areas	(	Codigo
									,Nombre)
			VALUES				(	@CodArea
									,@Nombre)

			SELECT @Id = @@IDENTITY
			SELECT @Id AS IdArea,@CodArea AS CodArea
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Areas 
			SET		Nombre		= @Nombre
			WHERE	Id = @Id

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			UPDATE	Areas 
			SET		delmrk		= '0'
			WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_CursoAlumnos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_CursoAlumnos] 
		@Operacion			VARCHAR(20)		= NULL	
		,@CodigoAlum		VARCHAR(8)		= NULL
		,@CodigoCurso		VARCHAR(4)		= NULL	
		,@AñoElectivo		INT				= NULL
		
	AS

	BEGIN		
		
		IF @Operacion = 'SCURSOS'
		BEGIN
			SELECT	Id
					,CodigoCurso
					,Nombre	
			FROM	Cursos WITH(nolock) 	
			WHERE	delmrk = '1'
		END		

		IF @Operacion = 'SALUMCURSOS'
		BEGIN
			SELECT	CursoAlumnos.CodigoCurso
					,CursoAlumnos.CodigoAlum
					,Personas.Nombre	AS Alumno
					,Alumnos.Carnet		AS Carnet
					,CursoAlumnos.AñoElectivo
			FROM	CursoAlumnos WITH(nolock) 
					INNER JOIN Cursos ON Cursos.CodigoCurso= CursoAlumnos.CodigoCurso
					INNER JOIN Alumnos ON Alumnos.CodigoAlum = CursoAlumnos.CodigoAlum
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
			WHERE	CursoAlumnos.CodigoCurso = @CodigoCurso AND CursoAlumnos.AñoElectivo = @AñoElectivo	
		END		
		
		IF @Operacion = 'SALUMCURSOONE'
		BEGIN
			SELECT	CursoAlumnos.CodigoCurso
					,Cursos.Nombre		AS NombreCurso
					,CursoAlumnos.CodigoAlum
					,Personas.Nombre	AS Alumno
					,CursoAlumnos.AñoElectivo
			FROM	CursoAlumnos WITH(nolock) 
					INNER JOIN Cursos ON Cursos.CodigoCurso= CursoAlumnos.CodigoCurso
					INNER JOIN Alumnos ON Alumnos.CodigoAlum = CursoAlumnos.CodigoAlum
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
			WHERE	CursoAlumnos.AñoElectivo = @AñoElectivo	AND
					CursoAlumnos.CodigoAlum  = @CodigoAlum
		END						
		
		IF @Operacion = 'INSERT'
		BEGIN	

			INSERT INTO CursoAlumnos(	CodigoAlum
										,CodigoCurso
										,AñoElectivo)
					VALUES			(	@CodigoAlum
										,@CodigoCurso
										,@AñoElectivo)
			
			SELECT @CodigoCurso AS CodCurso,@CodigoAlum AS CodAlumno
		END

		IF @Operacion = 'UPDATECUR'
		BEGIN
			DELETE FROM	CursoAlumnos
			WHERE	CodigoAlum = @CodigoAlum AND AñoElectivo	= @AñoElectivo

			INSERT INTO CursoAlumnos(	CodigoAlum
										,CodigoCurso
										,AñoElectivo)
					VALUES			(	@CodigoAlum
										,@CodigoCurso
										,@AñoElectivo)

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			DELETE	CursoAlumnos 	
			WHERE	CodigoAlum  = @CodigoAlum  AND
					CodigoCurso	= @CodigoCurso AND 
					AñoElectivo	= @AñoElectivo
			
		END

		IF @Operacion = 'SALUNOASIG'
		BEGIN
			SELECT	Alumnos.CodigoAlum
					,Personas.Nombre
					,Alumnos.Carnet
			FROM	Alumnos							
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona			
			WHERE	Alumnos.delmrk = '1'
					AND Alumnos.CodigoAlum NOT IN (	SELECT	CodigoAlum
													FROM	CursoAlumnos
													WHERE	AñoElectivo	= @AñoElectivo )
					AND Alumnos.Estado = 'A'
			
			
		END	

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Cursos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Cursos] 
		@Operacion			VARCHAR(20)		= NULL
		,@Id				INT				= NULL
		,@CodigoCurso		VARCHAR(4)		= NULL	
		,@CodGrupo			VARCHAR(2)		= NULL	
		,@CodGrado			VARCHAR(2)		= NULL
		,@Jornada			VARCHAR(50)		= NULL
		,@Nombre			VARCHAR(70)		= NULL
		
	AS

	BEGIN
		
		DECLARE @CodCur VARCHAR(4)		
		SET		@CodCur = '0000'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Cursos.Id
					,Cursos.CodigoCurso
					,Cursos.Nombre	
					,Cursos.CodGrupo
					,Cursos.CodGrado
					,Cursos.Jornada			
			FROM	Cursos WITH(nolock) 
			WHERE	Cursos.Id = @Id 			
		END
	
		IF @Operacion = 'SELECTCOD'
		BEGIN
			SELECT	Cursos.Id
					,Cursos.CodigoCurso
					,Cursos.Nombre	
					,Cursos.CodGrupo
					,Cursos.CodGrado
					,Cursos.Jornada			
			FROM	Cursos WITH(nolock) 
			WHERE	Cursos.CodigoCurso = @CodigoCurso			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Cursos.Id
					,Cursos.CodigoCurso
					,Cursos.Nombre	
					,Cursos.CodGrupo
					,Cursos.CodGrado
					,Cursos.Jornada			
			FROM	Cursos WITH(nolock)  
			WHERE	Cursos.delmrk = '1'			
		END	
		
		IF @Operacion = 'SELECTNAME'
		BEGIN
			SELECT	* 
			FROM	Cursos 
			WHERE	delmrk = '1' 
					AND Nombre = @Nombre
		END	
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodCur = LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,4,'0'))) FROM Cursos

			INSERT INTO Cursos(	CodigoCurso
								,CodGrupo
								,CodGrado
								,Jornada
								,Nombre)
			VALUES			(	@CodCur
								,@CodGrupo
								,@CodGrado
								,@Jornada
								,@Nombre)

			SELECT @Id = @@IDENTITY
			SELECT @Id AS IdCurso,@CodCur AS CodCurso
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Cursos 
			SET		CodGrupo	= @CodGrupo
					,CodGrado	= @CodGrado
					,Jornada	= @Jornada
					,Nombre		= @Nombre
			WHERE	Id = @Id

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			UPDATE	Cursos 
			SET		delmrk		= '0'
			WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Desempeños]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Desempeños] 
		@Operacion			VARCHAR(20)		= NULL
		,@Id				INT				= NULL
		,@CodigoDesemp		VARCHAR(2)		= NULL	
		,@Nombre			VARCHAR(100)	= NULL	
		,@NotaMin			VARCHAR(9)		= NULL
		,@NotaMax			VARCHAR(9)		= NULL
		
	AS

	BEGIN
		
		DECLARE @CodDes VARCHAR(2)		
		SET		@CodDes = '00'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Desempeños.Id
					,Desempeños.CodigoDesemp
					,Desempeños.Nombre	
					,Desempeños.NotaMin
					,Desempeños.NotaMax		
			FROM	Desempeños WITH(nolock) 
			WHERE	Desempeños.Id = @Id 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Desempeños.Id
					,Desempeños.CodigoDesemp
					,Desempeños.Nombre	
					,Desempeños.NotaMin
					,Desempeños.NotaMax		
			FROM	Desempeños WITH(nolock) 
			WHERE	Desempeños.delmrk = '1'			
		END	
		
		IF @Operacion = 'SELECTNAME'
		BEGIN
			SELECT	* 
			FROM	Desempeños 
			WHERE	delmrk = '1' 
					AND Nombre = @Nombre
		END	
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodDes = LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,2,'0'))) FROM Desempeños

			INSERT INTO Desempeños(	CodigoDesemp
									,Nombre
									,NotaMin
									,NotaMax)
			VALUES			(	@CodDes
								,@Nombre
								,@NotaMin
								,@NotaMax)

			SELECT @Id = @@IDENTITY
			SELECT @Id AS IdDesempeño,@CodDes AS CodDesempeño
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Desempeños 
			SET		Nombre		=	@Nombre
					,NotaMin	=	@NotaMin
					,NotaMax	=	@NotaMax
			WHERE	Id = @Id

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			UPDATE	Desempeños 
			SET		delmrk		= '0'
			WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Empresa]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Empresa] 
		@Operacion			VARCHAR(20)	= NULL
		,@Nombre			VARCHAR(350)= NULL
		,@Nit				VARCHAR(50)	= NULL	
		,@Direccion			VARCHAR(350)= NULL
		,@Telefono			VARCHAR(50)	= NULL
		,@Email				VARCHAR(100)= NULL
		,@Resolusion		VARCHAR(250)= NULL
		,@CodigoDane		VARCHAR(50) = NULL
		,@Abreviaura		VARCHAR(50) = NULL
		,@Lema				VARCHAR(150)= NULL
		,@Director			VARCHAR(150)= NULL
		,@Secretaria		VARCHAR(150)= NULL
		,@Coordinador		VARCHAR(150)= NULL
		,@Logo				VARCHAR(800)= NULL
	AS

	BEGIN
				
		IF @Operacion = 'SELECT'
		BEGIN
			SELECT	Nombre
					,Nit
					,Direccion
					,Telefono
					,Email
					,Resolusion
					,CodigoDane
					,Abreviaura
					,Lema
					,Director
					,Secretaria
					,Coordinador
					,Logo
			FROM	Empresa WITH(nolock) 
					
		END

	

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Empresa 
			SET		Nombre			= @Nombre
					,Nit			= @Nit
					,Direccion		= @Direccion
					,Telefono		= @Telefono
					,Email			= @Email
					,Resolusion		= @Resolusion
					,CodigoDane		= @CodigoDane
					,Abreviaura		= @Abreviaura
					,Lema			= @Lema
					,Director		= @Director
					,Secretaria		= @Secretaria
					,Coordinador	= @Coordinador
					,Logo			= @Logo

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Grados]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Grados] 
		@Operacion			VARCHAR(20)		= NULL
		,@Id				INT				= NULL
		,@CodigoGrado		VARCHAR(2)		= NULL	
		,@Nombre			VARCHAR(50)		= NULL
		,@Numero			INT				= NULL
		
	AS

	BEGIN
		
		DECLARE @CodGr VARCHAR(2)		
		SET		@CodGr = '00'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Grados.Id
					,Grados.CodigoGrado
					,Grados.Nombre		
					,Grados.Numero			
			FROM	Grados WITH(nolock) 
			WHERE	Grados.Id = @Id 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Grados.Id
					,Grados.CodigoGrado
					,Grados.Nombre		
					,Grados.Numero			
			FROM	Grados WITH(nolock) 
			WHERE	Grados.delmrk = '1'			
		END	
		
		IF @Operacion = 'SELECTNAME'
		BEGIN
			SELECT	* 
			FROM	Grados 
			WHERE	delmrk = '1' 
					AND Nombre = @Nombre
		END	
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodGr = LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,2,'0'))) FROM Grados

			INSERT INTO Grados(	CodigoGrado
									,Nombre
									,Numero)
			VALUES				(	@CodGr
									,@Nombre
									,@Numero)

			SELECT @Id = @@IDENTITY
			SELECT @Id AS IdGrado,@CodGr AS CodGrado
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Grados 
			SET		Nombre		= @Nombre
					,Numero		= @Numero
			WHERE	Id = @Id

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			UPDATE	Grados 
			SET		delmrk		= '0'
			WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Grupos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Grupos] 
		@Operacion			VARCHAR(20)		= NULL
		,@Id				INT				= NULL
		,@CodigoGrupo		VARCHAR(2)		= NULL	
		,@Nombre			VARCHAR(20)		= NULL
		,@Numero			INT				= NULL
		
	AS

	BEGIN
		
		DECLARE @CodGru VARCHAR(2)		
		SET		@CodGru = '00'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Grupos.Id
					,Grupos.CodigoGrupo
					,Grupos.Nombre			
			FROM	Grupos WITH(nolock) 
			WHERE	Grupos.Id = @Id 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Grupos.Id
					,Grupos.CodigoGrupo
					,Grupos.Nombre			
			FROM	Grupos WITH(nolock) 
			WHERE	Grupos.delmrk = '1'			
		END	
		
		IF @Operacion = 'SELECTNAME'
		BEGIN
			SELECT	* 
			FROM	Grupos 
			WHERE	delmrk = '1' 
					AND Nombre = @Nombre
		END	
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodGru = LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,2,'0'))) FROM Grupos

			INSERT INTO Grupos(	CodigoGrupo
									,Nombre)
			VALUES				(	@CodGru
									,@Nombre)

			SELECT @Id = @@IDENTITY
			SELECT @Id AS IdGrupo,@CodGru AS CodGrupo
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Grupos 
			SET		Nombre		= @Nombre
			WHERE	Id = @Id

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			UPDATE	Grupos 
			SET		delmrk		= '0'
			WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Institucion]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Institucion] 
		@Operacion			VARCHAR(20)	= NULL
		,@Nombre			VARCHAR(350)= NULL
		,@Nit				VARCHAR(50)	= NULL	
		,@Direccion			VARCHAR(350)= NULL
		,@Telefono			VARCHAR(50)	= NULL
		,@Email				VARCHAR(100)= NULL
		,@Resolusion		VARCHAR(250)= NULL
		,@CodigoDane		VARCHAR(50) = NULL
		,@Abreviaura		VARCHAR(50) = NULL
		,@Lema				VARCHAR(150)= NULL
		,@Director			VARCHAR(150)= NULL
		,@Secretaria		VARCHAR(150)= NULL
		,@Coordinador		VARCHAR(150)= NULL
		,@Logo				VARCHAR(800)= NULL
	AS

	BEGIN
				
		IF @Operacion = 'SELECT'
		BEGIN
			SELECT	Nombre
					,Nit
					,Direccion
					,Telefono
					,Email
					,Resolusion
					,CodigoDane
					,Abreviaura
					,Lema
					,Director
					,Secretaria
					,Coordinador
					,Logo
			FROM	Institucion WITH(nolock) 
					
		END
	
		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Institucion 
			SET		Nombre			= @Nombre
					,Nit			= @Nit
					,Direccion		= @Direccion
					,Telefono		= @Telefono
					,Email			= @Email
					,Resolusion		= @Resolusion
					,CodigoDane		= @CodigoDane
					,Abreviaura		= @Abreviaura
					,Lema			= @Lema
					,Director		= @Director
					,Secretaria		= @Secretaria
					,Coordinador	= @Coordinador
					,Logo			= @Logo

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Materias]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Materias] 
		@Operacion			VARCHAR(20)	= NULL
		,@Id				INT			= NULL
		,@CodArea			VARCHAR(2)	= NULL	
		,@CodMateria		VARCHAR(8)	= NULL	
		,@Nombre			VARCHAR(150)	= NULL
	AS

	BEGIN
		
		DECLARE @CodMat VARCHAR(3)		
		SET		@CodMat = '000'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Materias.Id
					,Materias.CodArea
					,Areas.Nombre  AS NombreArea
					,Materias.CodMateria
					,Materias.Nombre
			FROM	Materias WITH(nolock) 
					INNER JOIN Areas ON Areas.Codigo = Materias.CodArea
			WHERE	Materias.Id = @Id 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Materias.Id
					,Materias.CodArea
					,Materias.CodMateria
					,Areas.Nombre AS NombreArea
					,Materias.Nombre
			FROM	Materias WITH(nolock) 
					INNER JOIN Areas ON Areas.Codigo = Materias.CodArea
			WHERE	Materias.delmrk = '1'			
		END

		IF @Operacion = 'SELECTNAME'
		BEGIN
			SELECT	* 
			FROM	Materias 
			WHERE	delmrk = '1' 
					AND Nombre = @Nombre
		END
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodMat = LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,3,'0'))) FROM Materias

			INSERT INTO Materias	(CodArea
									,CodMateria
									,Nombre)
			VALUES					(@CodArea
									,@CodMat
									,@Nombre)

			SELECT @Id = @@IDENTITY
			SELECT @Id AS IdMateria,@CodMat AS CodMateria
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Materias 
			SET		CodArea		= @CodArea
					,Nombre		= @Nombre
			WHERE	Id = @Id

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			UPDATE	Materias 
			SET		delmrk		= '0'
			WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_MateriasCursos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_MateriasCursos] 
		@Operacion			VARCHAR(20)		= NULL
		,@CodCurso			VARCHAR(4)		= NULL	
		,@CodMateria		VARCHAR(3)		= NULL	
		,@IHS				INT				= NULL
		,@CodProfesor		VARCHAR(9)		= NULL
		
	AS

	BEGIN		
		
		IF @Operacion = 'SCURSOS'
		BEGIN
			SELECT	Id
					,CodigoCurso
					,Nombre	
			FROM	Cursos WITH(nolock) 	
			WHERE	delmrk = '1'
		END

		IF @Operacion = 'SCURSOONE'
		BEGIN
			SELECT	Id
					,CodigoCurso
					,Nombre		AS NombreCurso
			FROM	Cursos WITH(nolock) 	
			WHERE	delmrk = '1' AND CodigoCurso = @CodCurso
		END

		IF @Operacion = 'SMATCURSOS'
		BEGIN
			SELECT	MateriasCursos.CodCurso
					,MateriasCursos.CodMateria	
					,Materias.Nombre	AS Materia
					,MateriasCursos.IHS
					,MateriasCursos.CodProfesor
					,Personas.Nombre	AS Profesor
			FROM	MateriasCursos WITH(nolock) 
					INNER JOIN Materias ON Materias.CodMateria = MateriasCursos.CodMateria
					INNER JOIN Profesores ON Profesores.CodigoProfesor = MateriasCursos.CodProfesor		AND Profesores.Estado = 'A'
					INNER JOIN Personas ON Personas.Id = Profesores.IdPersona
			WHERE	MateriasCursos.CodCurso = @CodCurso		
		END		
		
		IF @Operacion = 'INSERT'
		BEGIN	

			INSERT INTO MateriasCursos(	CodCurso
										,CodMateria
										,IHS
										,CodProfesor)
					VALUES			(	@CodCurso
										,@CodMateria
										,@IHS
										,@CodProfesor)
			
			SELECT @CodCurso AS CodCurso,@CodMateria AS CodMateria
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	MateriasCursos 
			SET		IHS				= 	@IHS
					,CodProfesor	= 	@CodProfesor
			WHERE	CodCurso = @CodCurso AND CodMateria	= @CodMateria

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			DELETE	MateriasCursos 	
			WHERE	CodCurso = @CodCurso AND CodMateria	= @CodMateria
			
		END

		IF @Operacion = 'SMATNOASIG'
		BEGIN
			SELECT	Materias.CodMateria
					,Materias.Nombre
			FROM	Materias					
			WHERE	Materias.delmrk = '1'
					AND Materias.CodMateria NOT IN (	SELECT	CodMateria
														FROM	MateriasCursos
														WHERE	CodCurso = @CodCurso )
			
		END

		IF @Operacion = 'SMATASIG'
		BEGIN
			SELECT	Materias.CodMateria
					,Materias.Nombre
			FROM	Materias					
			WHERE	Materias.delmrk = '1'
					AND Materias.CodMateria  IN (	SELECT	CodMateria
														FROM	MateriasCursos
														WHERE	CodCurso = @CodCurso )
			
		END

		IF @Operacion = 'SMATCURONE'
		BEGIN
			SELECT	MateriasCursos.CodCurso
					,Cursos.Nombre	AS NombreCurso
					,MateriasCursos.CodMateria	
					,MateriasCursos.IHS
					,MateriasCursos.CodProfesor
			FROM	MateriasCursos WITH(nolock) 
					INNER JOIN Cursos ON Cursos.CodigoCurso = MateriasCursos.CodCurso
			WHERE	MateriasCursos.CodCurso = @CodCurso AND MateriasCursos.CodMateria	= @CodMateria
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Niveles]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Niveles] 
		@Operacion			VARCHAR(20)	= NULL
		,@Id				INT			= NULL
		,@CodNivel			VARCHAR(2)	= NULL	
		,@Nombre			VARCHAR(150)= NULL
	AS

	BEGIN
		
		DECLARE @CodN VARCHAR(2)		
		SET		@CodN = '00'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Niveles.Id
					,Niveles.CodNivel
					,Niveles.Nombre					
			FROM	Niveles WITH(nolock) 
			WHERE	Niveles.Id = @Id 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Niveles.Id
					,Niveles.CodNivel
					,Niveles.Nombre					
			FROM	Niveles WITH(nolock) 
			WHERE	Niveles.delmrk = '1'			
		END	
		
		IF @Operacion = 'SELECTNAME'
		BEGIN
			SELECT	* 
			FROM	Niveles 
			WHERE	delmrk = '1' 
					AND Nombre = @Nombre
		END	
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodN = LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,2,'0'))) FROM Niveles

			INSERT INTO Niveles	(	CodNivel
									,Nombre)
			VALUES				(	@CodN
									,@Nombre)

			SELECT @Id = @@IDENTITY
			SELECT @Id AS IdNivel,@CodN AS CodNivel
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Niveles 
			SET		Nombre		= @Nombre
			WHERE	Id = @Id

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			UPDATE	Niveles 
			SET		delmrk		= '0'
			WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Periodos]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Periodos] 
		@Operacion			VARCHAR(20)		= NULL
		,@Id				INT				= NULL
		,@CodigoPeriodo		VARCHAR(2)		= NULL	
		,@Nombre			VARCHAR(50)		= NULL
		,@Numero			INT				= NULL
		,@Porcentaje		INT				= NULL
	AS

	BEGIN
		
		DECLARE @CodPe VARCHAR(2)		
		SET		@CodPe = '00'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Periodos.Id
					,Periodos.CodigoPeriodo
					,Periodos.Nombre		
					,Periodos.Numero		
					,Periodos.Porcentaje	
			FROM	Periodos WITH(nolock) 
			WHERE	Periodos.Id = @Id 			
		END

		IF @Operacion = 'SELECTCOD'
		BEGIN
			SELECT	Periodos.Id
					,Periodos.CodigoPeriodo
					,Periodos.Nombre		
					,Periodos.Numero		
					,Periodos.Porcentaje	
			FROM	Periodos WITH(nolock) 
			WHERE	Periodos.CodigoPeriodo = @CodigoPeriodo 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Periodos.Id
					,Periodos.CodigoPeriodo
					,Periodos.Nombre		
					,Periodos.Numero		
					,Periodos.Porcentaje	
			FROM	Periodos WITH(nolock) 
			WHERE	Periodos.delmrk = '1'			
		END	
		
		IF @Operacion = 'SELECTNAME'
		BEGIN
			SELECT	* 
			FROM	Periodos 
			WHERE	delmrk = '1' 
					AND Nombre = @Nombre
		END	
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodPe = LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,2,'0'))) FROM Periodos

			INSERT INTO Periodos(	CodigoPeriodo
									,Nombre
									,Numero
									,Porcentaje)
			VALUES				(	@CodPe
									,@Nombre
									,@Numero
									,@Porcentaje)

			SELECT @Id = @@IDENTITY
			SELECT @Id AS IdPeriodo,@CodPe AS CodPeriodo
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Periodos 
			SET		Nombre		= @Nombre
					,Numero		= @Numero
					,Porcentaje	= @Porcentaje
			WHERE	Id = @Id

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			UPDATE	Periodos 
			SET		delmrk		= '0'
			WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Profesores]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Profesores] 
		@Operacion			VARCHAR(20)		= NULL
		,@Id				INT				= NULL
		,@CodigoProfesor	VARCHAR(6)		= NULL	
		,@Nombre			VARCHAR(200)	= NULL
		,@PrimerNombre		VARCHAR(50)		= NULL
		,@SegundoNombre		VARCHAR(50)		= NULL
		,@PrimerApellido	VARCHAR(50)		= NULL
		,@SegundoApellido	VARCHAR(50)		= NULL
		,@Identificacion	VARCHAR(50)		= NULL
		,@Direccion			VARCHAR(150)	= NULL
		,@Telefono			VARCHAR(150)	= NULL
		,@Email				VARCHAR(150)	= NULL
		,@Sexo				VARCHAR(1)		= NULL
		,@Contrasenia		VARCHAR(50)	= NULL
		,@CodTipoUsuario	VARCHAR(2)	= NULL
		,@NombreUsuario			VARCHAR(50)	= NULL
		,@Estado			VARCHAR(2)	= NULL
	AS

	BEGIN
		
		DECLARE @CodProfe VARCHAR(6)		
		SET		@CodProfe = 'PF0000'

		DECLARE @CodUsuario VARCHAR(8)		
		SET		@CodUsuario = 'USU00000'

		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Personas.Id
					,Profesores.CodigoProfesor
					,Personas.Nombre
					,Personas.PrimerNombre
					,Personas.SegundoNombre
					,Personas.PrimerApellido
					,Personas.SegundoApellido
					,Personas.Identificacion
					,Personas.Direccion
					,Personas.Telefono
					,Personas.Email
					,Personas.Sexo
					,Profesores.Estado
			FROM	Profesores WITH(nolock) 
					INNER JOIN Personas ON Personas.Id = Profesores.IdPersona
			WHERE	Personas.Id = @Id 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Personas.Id
					,Profesores.CodigoProfesor
					,Personas.Nombre
					,Personas.Identificacion
					,CASE 
						WHEN Profesores.Estado = 'A' THEN 'ACTIVO'
						WHEN Profesores.Estado = 'R' THEN 'RETIRADO'
						ELSE 'INACTIVO'
					END								AS Estado
					,Personas.Direccion
					,Personas.Email
			FROM	Profesores WITH(nolock) 
					INNER JOIN Personas ON Personas.Id = Profesores.IdPersona
			WHERE	Profesores.delmrk = '1'			
		END

		IF @Operacion = 'SELECTIDENTI'
		BEGIN
			SELECT	*
			FROM	Personas WITH(nolock) 
			WHERE	Personas.delmrk = '1'
					AND Identificacion = @Identificacion
		END
		
		IF @Operacion = 'INSERT'
		BEGIN
			SELECT @CodProfe = 'PF'+LTRIM(RTRIM(DBO.PadL(ISNULL(count(CodigoProfesor),0)+1,4,'0'))) FROM Profesores
			SELECT @CodUsuario = 'USU'+LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,5,'0'))) FROM Usuarios

			INSERT INTO Personas	(Nombre
									,PrimerNombre
									,SegundoNombre
									,PrimerApellido
									,SegundoApellido
									,Identificacion
									,Direccion
									,Telefono
									,Email
									,Sexo)
			VALUES					(@Nombre
									,@PrimerNombre
									,@SegundoNombre
									,@PrimerApellido
									,@SegundoApellido
									,@Identificacion
									,@Direccion
									,@Telefono
									,@Email
									,@Sexo)

			SELECT @Id = @@IDENTITY

			INSERT INTO Profesores (IdPersona
									,CodigoProfesor
									,Estado)
			VALUES				(	@Id
									,@CodProfe
									,@Estado)

			INSERT INTO Usuarios	(Codigo
									,Nombre
									,Contrasenia
									,CodTipoUsuario)
			VALUES					(@CodUsuario
									,@NombreUsuario
									,@Contrasenia
									,@CodTipoUsuario)

			INSERT INTO PersonaUsuarios (IdPersona
										,CodUsuario
										,CodTipoUsuario)
			VALUES						(@Id
										,@CodUsuario
										,@CodTipoUsuario)

			SELECT @Id AS IdPersona,@CodProfe AS CodProfesor
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	Personas 
			SET		Nombre				= @Nombre
					,PrimerNombre		= @PrimerNombre
					,SegundoNombre		= @SegundoNombre
					,PrimerApellido		= @PrimerApellido
					,SegundoApellido	= @SegundoApellido
					,Identificacion		= @Identificacion
					,Direccion			= @Direccion
					,Telefono			= @Telefono
					,Email				= @Email	
					,Sexo				= @Sexo
			WHERE	Id = @Id	
			
			UPDATE	Profesores 
			SET		Estado = @Estado		
			WHERE	IdPersona = @Id

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			SELECT @CodUsuario = CodUsuario FROM PersonaUsuarios WHERE IdPersona = @Id

			DELETE FROM PersonaUsuarios WHERE IdPersona = @Id

			DELETE FROM Usuarios WHERE Codigo = @CodUsuario

			DELETE FROM Profesores WHERE	IdPersona	= @Id

			DELETE FROM Personas WHERE	Id = @Id

			--UPDATE	Profesores 
			--SET		delmrk		= '0'
			--WHERE	IdPersona	= @Id
			
			--UPDATE	Personas 
			--SET		delmrk		= '0'
			--WHERE	Id = @Id
			
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_ProfesorMaterias]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	
	CREATE PROCEDURE [dbo].[PA_ProfesorMaterias] 
		@Operacion			VARCHAR(20)	= NULL
		,@CodigoProfesor	VARCHAR(6)	= NULL	
		,@CodMateria		VARCHAR(3)	= NULL	

	AS

	BEGIN		
		
		IF @Operacion = 'SMATERIAS'
		BEGIN
			SELECT	Materias.Id
					,Areas.Nombre
					,Materias.CodMateria
					,Materias.Nombre	
			FROM	Materias WITH(nolock)
					INNER JOIN Areas ON Areas.Codigo = Materias.CodArea 	
			WHERE	Materias.delmrk = '1'
		END

		IF @Operacion = 'SMATERIAONE'
		BEGIN
			SELECT	Materias.Id
					,Materias.CodMateria
					,Materias.Nombre		AS NombreMateria
			FROM	Materias WITH(nolock) 	
			WHERE	delmrk = '1' AND CodMateria= @CodMateria
		END

		IF @Operacion = 'SMATERIPROFE'
		BEGIN
			SELECT	ProfesorMaterias.CodigoProfesor					
					,Areas.Nombre		AS Area
					,ProfesorMaterias.CodMateria	
					,Materias.Nombre	AS Materia
			FROM	ProfesorMaterias WITH(nolock) 
					INNER JOIN Materias ON Materias.CodMateria = ProfesorMaterias.CodMateria
					INNER JOIN Areas ON Areas.Codigo = Materias.CodArea  
					INNER JOIN Profesores ON Profesores.CodigoProfesor = ProfesorMaterias.CodigoProfesor	AND Profesores.Estado = 'A'
					INNER JOIN Personas ON Personas.Id = Profesores.IdPersona					
			WHERE	ProfesorMaterias.CodigoProfesor = @CodigoProfesor	
		END		
		
		
		IF @Operacion = 'SPROFMATER'
		BEGIN 
			DECLARE @Count INT 
			SELECT @Count=COUNT(*) FROM ProfesorMaterias WHERE	ProfesorMaterias.CodMateria = @CodMateria

			IF @Count > 0 
			BEGIN
				SELECT	Personas.Id
						,ProfesorMaterias.CodigoProfesor	
						,Personas.Nombre
				FROM	ProfesorMaterias WITH(nolock) 
						INNER JOIN Materias ON Materias.CodMateria = ProfesorMaterias.CodMateria
						INNER JOIN Profesores ON Profesores.CodigoProfesor = ProfesorMaterias.CodigoProfesor AND Profesores.Estado = 'A'
						INNER JOIN Personas ON Personas.Id = Profesores.IdPersona				
				WHERE	ProfesorMaterias.CodMateria = @CodMateria	
			END
			ELSE
			BEGIN
				SELECT	Personas.Id
						,Profesores.CodigoProfesor
						,Personas.Nombre					
				FROM	Profesores WITH(nolock) 
						INNER JOIN Personas ON Personas.Id = Profesores.IdPersona
				WHERE	Profesores.delmrk = '1'	AND Profesores.Estado = 'A'
			END
		END


		IF @Operacion = 'INSERT'
		BEGIN	

			INSERT INTO ProfesorMaterias(	CodMateria
											,CodigoProfesor)
					VALUES				(	@CodMateria
											,@CodigoProfesor)
			
			SELECT COUNT(*) FROM ProfesorMaterias
		END		

		IF @Operacion = 'DELONE'
		BEGIN
			DELETE	ProfesorMaterias 	
			WHERE	CodigoProfesor = @CodigoProfesor AND CodMateria	= @CodMateria
			
		END

		IF @Operacion = 'DELALL'
		BEGIN
			DELETE	ProfesorMaterias 	
			WHERE	CodigoProfesor = @CodigoProfesor 
			
		END

		IF @Operacion = 'SMATPROFENOASIG'
		BEGIN
			IF @CodigoProfesor != ''
			BEGIN
				SELECT	Materias.CodMateria
						,Materias.Nombre
				FROM	Materias					
				WHERE	Materias.delmrk = '1'
						AND Materias.CodMateria NOT IN (	SELECT	ProfesorMaterias.CodMateria
															FROM	ProfesorMaterias
															WHERE	CodigoProfesor = @CodigoProfesor)
			END
			ELSE
			BEGIN
				SELECT	Materias.CodMateria
						,Materias.Nombre
				FROM	Materias					
				WHERE	Materias.delmrk = '1'
			END
			
		END

		IF @Operacion = 'SMATPROFEASIG'
		BEGIN
			SELECT	Materias.CodMateria
					,Materias.Nombre
			FROM	Materias					
			WHERE	Materias.delmrk = '1'
					AND Materias.CodMateria  IN (	SELECT	ProfesorMaterias.CodMateria
														FROM	ProfesorMaterias
														WHERE	CodigoProfesor = @CodigoProfesor )
			
		END

		IF @Operacion = 'SMATERIPROFEONE'
		BEGIN
			SELECT	ProfesorMaterias.CodigoProfesor
					,ProfesorMaterias.CodMateria	
					,Materias.Nombre	AS Materia
			FROM	ProfesorMaterias WITH(nolock) 
					INNER JOIN Materias ON Materias.CodMateria = ProfesorMaterias.CodMateria
					INNER JOIN Profesores ON Profesores.CodigoProfesor = ProfesorMaterias.CodigoProfesor
					INNER JOIN Personas ON Personas.Id = Profesores.IdPersona					
			WHERE	ProfesorMaterias.CodigoProfesor = @CodigoProfesor AND ProfesorMaterias.CodMateria = @CodMateria
		END

		IF @Operacion = 'SMATERIPROFEROW'
		BEGIN
			SELECT	@CodigoProfesor
					,Areas.Nombre			AS Area
					,Materias.CodMateria	AS CodMateria
					,Materias.Nombre		AS Materia
			FROM	Materias WITH(nolock) 
					INNER JOIN Areas ON Areas.Codigo = Materias.CodArea									
			WHERE	Materias.CodMateria = @CodMateria
		END

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_RegistroNotas]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
	CREATE PROCEDURE [dbo].[PA_RegistroNotas] 
		@Operacion			VARCHAR(20)		= NULL	
		,@CodAlumno			VARCHAR(8)		= NULL
		,@CodProfesor		VARCHAR(6)		= NULL
		,@CodCurso			VARCHAR(4)		= NULL	
		,@CodMateria		VARCHAR(3)		= NULL		
		,@CodPeriodo		VARCHAR(2)		= NULL		
		,@Nota1				NUMERIC(18,2)	= NULL			
		,@PorcN1			NUMERIC(18,2)	= NULL	
		,@Nota2				NUMERIC(18,2)	= NULL			
		,@PorcN2			NUMERIC(18,2)	= NULL		
		,@Nota3				NUMERIC(18,2)	= NULL			
		,@PorcN3			NUMERIC(18,2)	= NULL		
		,@Nota4				NUMERIC(18,2)	= NULL			
		,@PorcN4			NUMERIC(18,2)	= NULL	
		,@NotaFinal			NUMERIC(18,2)	= NULL
		,@Fallas			INT				= NULL
		,@AñoElectivo		INT				= NULL
		
	AS

	BEGIN				
		
		IF @Operacion = 'SCURPROF'
		BEGIN
			SELECT	MateriasCursos.CodCurso
					,Cursos.Nombre
			FROM	Profesores
					INNER JOIN Personas			ON Personas.Id = Profesores.IdPersona
					INNER JOIN MateriasCursos	ON MateriasCursos.CodProfesor = Profesores.CodigoProfesor
					INNER JOIN Cursos			ON Cursos.CodigoCurso =	MateriasCursos.CodCurso
			WHERE	MateriasCursos.CodProfesor = @CodProfesor	AND Profesores.Estado = 'A'
			GROUP BY Personas.Nombre,CodProfesor,CodCurso,Cursos.Nombre

		END		

		IF @Operacion = 'SMATCURPROF'
		BEGIN
			SELECT	MateriasCursos.CodMateria
					,Materias.Nombre
					,MateriasCursos.IHS
			FROM	Profesores
					INNER JOIN Personas			ON Personas.Id = Profesores.IdPersona
					INNER JOIN MateriasCursos	ON MateriasCursos.CodProfesor = Profesores.CodigoProfesor
					INNER JOIN Cursos			ON Cursos.CodigoCurso =	MateriasCursos.CodCurso
					INNER JOIN Materias			ON Materias.CodMateria = MateriasCursos.CodMateria
			WHERE	MateriasCursos.CodProfesor = @CodProfesor AND MateriasCursos.CodCurso = @CodCurso AND Profesores.Estado = 'A'
		END			
		
		IF @Operacion = 'SMATCURSOS'
		BEGIN
			SELECT	MateriasCursos.CodMateria
					,Materias.Nombre
					,MateriasCursos.IHS
			FROM	MateriasCursos	
					INNER JOIN Cursos			ON Cursos.CodigoCurso =	MateriasCursos.CodCurso
					INNER JOIN Materias			ON Materias.CodMateria = MateriasCursos.CodMateria
			WHERE	MateriasCursos.CodCurso = @CodCurso
		END		
			
		IF @Operacion = 'SPROFMATECURSO'
		BEGIN
			SELECT	MateriasCursos.CodProfesor
					,Personas.Nombre
			FROM	MateriasCursos	
					INNER JOIN Cursos			ON Cursos.CodigoCurso =	MateriasCursos.CodCurso
					INNER JOIN Materias			ON Materias.CodMateria = MateriasCursos.CodMateria
					INNER JOIN Profesores		ON Profesores.CodigoProfesor = MateriasCursos.CodProfesor	AND Profesores.Estado = 'A'
					INNER JOIN Personas			ON Personas.Id = Profesores.IdPersona
			WHERE	MateriasCursos.CodCurso = @CodCurso AND MateriasCursos.CodMateria = @CodMateria
		END				

		IF @Operacion = 'INSERT'
		BEGIN	

			INSERT INTO RegistroNotas(	CodAlumno
										,CodProfesor
										,CodCurso
										,CodMateria
										,CodPeriodo
										,Nota1
										,PorcN1
										,Nota2
										,PorcN2
										,Nota3
										,PorcN3
										,Nota4
										,PorcN4
										,NotaFinal
										,Fallas
										,AñoElectivo)
					VALUES			(	@CodAlumno
										,@CodProfesor
										,@CodCurso
										,@CodMateria
										,@CodPeriodo
										,@Nota1
										,@PorcN1
										,@Nota2
										,@PorcN2
										,@Nota3
										,@PorcN3
										,@Nota4
										,@PorcN4
										,@NotaFinal
										,@Fallas
										,@AñoElectivo)
			
			SELECT	@CodAlumno		AS CodAlumno
					,@CodProfesor	AS CodProfesor
					,@CodCurso		AS CodCurso
					,@CodMateria	AS CodMateria
					,@CodPeriodo	AS CodPeriodo
					,@AñoElectivo	AS AñoElectivo
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	RegistroNotas 
			SET		Nota1		= @Nota1
					,PorcN1		= @PorcN1
					,Nota2		= @Nota2
					,PorcN2		= @PorcN2
					,Nota3		= @Nota3
					,PorcN3		= @PorcN3
					,Nota4		= @Nota4
					,PorcN4		= @PorcN4
					,NotaFinal	= @NotaFinal
					,Fallas		= @Fallas
			WHERE	CodAlumno	= @CodAlumno	AND
					CodProfesor = @CodProfesor 	AND
					CodCurso	= @CodCurso		AND
					CodMateria	= @CodMateria	AND
					CodPeriodo	= @CodPeriodo	AND
					AñoElectivo	= @AñoElectivo

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'SELECTUPD'
		BEGIN
			SELECT	RegistroNotas.CodAlumno		AS CodigoAlum
					,Personas.Nombre			AS Alumno		
					,RegistroNotas.CodProfesor	AS CodProfesor
					,RegistroNotas.CodCurso		AS CodigoCurso
					,RegistroNotas.CodMateria	AS CodMateria
					,RegistroNotas.CodPeriodo	AS CodPeriodo
					,RegistroNotas.Nota1		AS SerConvi	
					,RegistroNotas.PorcN1		AS Nota1		
					,RegistroNotas.Nota2		AS Hacer
					,RegistroNotas.PorcN2		AS Nota2			
					,RegistroNotas.Nota3		AS Conocer
					,RegistroNotas.PorcN3		AS Nota3			
					,RegistroNotas.Nota4		AS Saber
					,RegistroNotas.PorcN4		AS Nota4
					,RegistroNotas.NotaFinal	AS NotaFinal
					,RegistroNotas.Fallas		AS Fallas
					,RegistroNotas.AñoElectivo	AS AñoElectivo
			FROM	RegistroNotas
					INNER JOIN Alumnos ON Alumnos.CodigoAlum = RegistroNotas.CodAlumno AND Alumnos.Estado IN ('A','S')
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
			WHERE	RegistroNotas.CodProfesor	= @CodProfesor 	AND
					RegistroNotas.CodCurso		= @CodCurso		AND
					RegistroNotas.CodMateria	= @CodMateria	AND
					RegistroNotas.CodPeriodo	= @CodPeriodo	AND
					RegistroNotas.AñoElectivo	= @AñoElectivo
			ORDER BY Personas.Nombre
			
		END

		IF @Operacion = 'SELECTINSERT'
		BEGIN			
			SELECT	CursoAlumnos.CodigoAlum				AS CodigoAlum
					,Personas.Nombre					AS Alumno
					,@CodProfesor						AS CodProfesor
					,CursoAlumnos.CodigoCurso			AS CodigoCurso
					,@CodMateria						AS CodMateria
					,@CodPeriodo						AS CodPeriodo
					,CASt( 0 AS NUMERIC(18,2))			AS SerConvi
					,CASt( 0 AS NUMERIC(18,2))			AS Nota1					
					,CASt( 0 AS NUMERIC(18,2))			AS Hacer
					,CASt( 0 AS NUMERIC(18,2))			AS Nota2					
					,CASt( 0 AS NUMERIC(18,2))			AS Conocer
					,CASt( 0 AS NUMERIC(18,2))			AS Nota3					
					,CASt( 0 AS NUMERIC(18,2))			AS Saber
					,CASt( 0 AS NUMERIC(18,2))			AS Nota4
					,CASt( 0 AS NUMERIC(18,2))			AS NotaFinal
					,CASt( 0 AS NUMERIC(18,2))			AS Fallas
					,@AñoElectivo						AS AñoElectivo
			FROM	CursoAlumnos
					--RIGHT JOIN CursoAlumnos ON CursoAlumnos.CodigoCurso = RegistroNotas.CodCurso 
					INNER JOIN Alumnos ON Alumnos.CodigoAlum = CursoAlumnos.CodigoAlum	AND Alumnos.Estado IN ('A','S')
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona 
			WHERE		
					CursoAlumnos.CodigoCurso	= @CodCurso		AND				
					CursoAlumnos.AñoElectivo	= @AñoElectivo	
			ORDER BY Personas.Nombre
		END

		IF @Operacion = 'SBOLEXCURCAB'
		BEGIN

			--SELECT	RegistroNotas.CodAlumno		AS CodigoAlum
			--			,Personas.Nombre			AS Alumno		
			--			,RegistroNotas.CodCurso		AS CodigoCurso
			--			,Cursos.Nombre				AS NombreCurso
			--			,Materias.CodArea			AS CodArea
			--			,Areas.Nombre				AS NombreArea
			--			,RegistroNotas.CodMateria	AS CodMateria
			--			,Materias.Nombre			AS NombreMateria
			--			,RegistroNotas.CodPeriodo	AS CodPeriodo					
			--			,RegistroNotas.NotaFinal	AS NotaFinal
			--			,(	SELECT	Nombre 
			--				FROM	Desempeños 
			--				WHERE	RegistroNotas.NotaFinal >= NotaMin AND 
			--						RegistroNotas.NotaFinal <= NotaMax) AS DesempeñoMateria
			--			,RegistroNotas.Fallas		AS Fallas
			--			,RegistroNotas.AñoElectivo	AS AñoElectivo
			--	FROM	RegistroNotas
			--			INNER JOIN Alumnos ON Alumnos.CodigoAlum = RegistroNotas.CodAlumno
			--			INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
			--			INNER JOIN Cursos ON Cursos.CodigoCurso = RegistroNotas.CodCurso
			--			INNER JOIN Materias ON Materias.CodMateria = RegistroNotas.CodMateria
			--			INNER JOIN Areas ON Areas.Codigo = Materias.CodArea
			--	WHERE	RegistroNotas.CodCurso		= @CodCurso		AND
			--			RegistroNotas.CodPeriodo	= @CodPeriodo	AND
			--			RegistroNotas.AñoElectivo	= @AñoElectivo
			--	ORDER BY Personas.Nombre,RegistroNotas.CodCurso,Areas.Nombre,Materias.Nombre

			SELECT	RegistroNotas.CodAlumno		AS CodigoAlum
					,Personas.Nombre			AS Alumno		
					,RegistroNotas.CodCurso		AS CodigoCurso
					,Cursos.Nombre				AS NombreCurso
			FROM	RegistroNotas
					INNER JOIN Alumnos ON Alumnos.CodigoAlum = RegistroNotas.CodAlumno	AND	Alumnos.Estado IN ('A','S')
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
					INNER JOIN Cursos ON Cursos.CodigoCurso = RegistroNotas.CodCurso									
			WHERE	RegistroNotas.CodCurso		= @CodCurso		AND
					RegistroNotas.CodPeriodo	= @CodPeriodo	AND
					RegistroNotas.AñoElectivo	= @AñoElectivo
			GROUP BY RegistroNotas.CodAlumno,Personas.Nombre,RegistroNotas.CodCurso	,Cursos.Nombre	
			ORDER BY Personas.Nombre

		END

		--IF @Operacion = 'SBOLEXCURDET1'
		--BEGIN
		--	SELECT	RegistroNotas.CodAlumno		AS CodigoAlum	
		--			,RegistroNotas.CodCurso		AS CodigoCurso
		--			,Materias.CodArea			AS CodArea
		--			,Areas.Nombre				AS NombreArea					
		--	FROM	RegistroNotas
		--			INNER JOIN Alumnos ON Alumnos.CodigoAlum = RegistroNotas.CodAlumno
		--			INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
		--			INNER JOIN Cursos ON Cursos.CodigoCurso = RegistroNotas.CodCurso
		--			INNER JOIN Materias ON Materias.CodMateria = RegistroNotas.CodMateria
		--			INNER JOIN Areas ON Areas.Codigo = Materias.CodArea
		--	WHERE	RegistroNotas.CodCurso		= @CodCurso		AND
		--			RegistroNotas.CodPeriodo	= @CodPeriodo	AND
		--			RegistroNotas.AñoElectivo	= @AñoElectivo
		--	GROUP BY RegistroNotas.CodAlumno,RegistroNotas.CodCurso	,Materias.CodArea,Areas.Nombre	
		--	ORDER BY RegistroNotas.CodCurso,Areas.Nombre

		--END

		IF @Operacion = 'SBOLEXCURDET2'
		BEGIN
			--SELECT	RegistroNotas.CodAlumno		AS CodigoAlum						
			--		,Materias.CodArea			AS CodArea	
			--		,Areas.Nombre				AS NombreArea						
			--		,RegistroNotas.CodMateria	AS CodMateria
			--		,Materias.Nombre			AS NombreMateria				
			--		,RegistroNotas.NotaFinal	AS NotaFinal
			--		,(	SELECT	Nombre 
			--			FROM	Desempeños 
			--			WHERE	RegistroNotas.NotaFinal >= NotaMin AND 
			--					RegistroNotas.NotaFinal <= NotaMax) AS DesempeñoMateria
			--		,RegistroNotas.Fallas		AS Fallas
			--FROM	RegistroNotas
			--		INNER JOIN Alumnos ON Alumnos.CodigoAlum = RegistroNotas.CodAlumno
			--		INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
			--		INNER JOIN Cursos ON Cursos.CodigoCurso = RegistroNotas.CodCurso
			--		INNER JOIN Materias ON Materias.CodMateria = RegistroNotas.CodMateria
			--		INNER JOIN Areas ON Areas.Codigo = Materias.CodArea
			--WHERE	RegistroNotas.CodCurso		= @CodCurso		AND
			--		RegistroNotas.CodPeriodo	= @CodPeriodo	AND
			--		RegistroNotas.AñoElectivo	= @AñoElectivo				
			--ORDER BY RegistroNotas.CodCurso,Materias.CodArea,Materias.Nombre

			SELECT	RegistroNotas.CodAlumno		AS CodigoAlum						
					,Materias.CodArea			AS CodArea	
					,Areas.Nombre				AS NombreArea						
					,RegistroNotas.CodMateria	AS CodMateria
					,Materias.Nombre			AS NombreMateria				
					,RegistroNotas.NotaFinal	AS NotaFinal
					,CAST(ISNULL(SubPer1.ValorPorcPeriodo1,0) AS NUMERIC(18,2))		 AS ValorPorcPeriodo1
					,CAST(ISNULL(SubPer1.PorcPeriodo1,20) AS NUMERIC(18,2))		 AS PorcPeriodo1
					,CAST(ISNULL(SubPer2.ValorPorcPeriodo2,0) AS NUMERIC(18,2)) AS ValorPorcPeriodo2
					,CAST(ISNULL(SubPer2.PorcPeriodo2,30) AS NUMERIC(18,2)) AS PorcPeriodo2
					,CAST(ISNULL(SubPer3.ValorPorcPeriodo3,0) AS NUMERIC(18,2)) AS ValorPorcPeriodo3
					,CAST(ISNULL(SubPer3.PorcPeriodo3,20) AS NUMERIC(18,2)) AS PorcPeriodo3
					,CAST(ISNULL(SubPer4.ValorPorcPeriodo4,0) AS NUMERIC(18,2)) AS ValorPorcPeriodo4
					,CAST(ISNULL(SubPer4.PorcPeriodo4,30) AS NUMERIC(18,2)) AS PorcPeriodo4
					,CAST(ISNULL(SubPer1.ValorPorcPeriodo1,0) AS NUMERIC(18,2))	+ 
						CAST(ISNULL(SubPer2.ValorPorcPeriodo2,0) AS NUMERIC(18,2)) +
						CAST(ISNULL(SubPer3.ValorPorcPeriodo3,0) AS NUMERIC(18,2)) +
						CAST(ISNULL(SubPer4.ValorPorcPeriodo4,0) AS NUMERIC(18,2))		AS SumaPeriodos
					,(	SELECT	Nombre 
						FROM	Desempeños 
						WHERE	RegistroNotas.NotaFinal >= NotaMin AND 
								RegistroNotas.NotaFinal <= NotaMax) AS DesempeñoMateria
					,RegistroNotas.Fallas		AS Fallas
			FROM	RegistroNotas
					INNER JOIN Alumnos ON Alumnos.CodigoAlum = RegistroNotas.CodAlumno		AND	Alumnos.Estado IN ('A','S')
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
					INNER JOIN Cursos ON Cursos.CodigoCurso = RegistroNotas.CodCurso
					INNER JOIN Materias ON Materias.CodMateria = RegistroNotas.CodMateria
					INNER JOIN Areas ON Areas.Codigo = Materias.CodArea

					LEFT JOIN (SELECT	RegistroNotas.CodAlumno
										,RegistroNotas.CodCurso
										,RegistroNotas.CodMateria
										,RegistroNotas.AñoElectivo
										,NotaFinal
										,CAST(ROUND(CAST(CAST(Periodos.Porcentaje AS NUMERIC(18,2))/100 AS NUMERIC(18,2))*NotaFinal,1)AS NUMERIC(18,2)) AS ValorPorcPeriodo1
										,Periodos.Porcentaje				AS PorcPeriodo1
								FROM	RegistroNotas
										INNER JOIN Periodos ON RegistroNotas.CodPeriodo = Periodos.CodigoPeriodo
								WHERE	RegistroNotas.CodPeriodo = '01' AND
										RegistroNotas.CodCurso		= @CodCurso		AND
										--RegistroNotas.CodPeriodo	= @CodPeriodo	AND
										RegistroNotas.AñoElectivo	= @AñoElectivo	) AS SubPer1 ON SubPer1.CodAlumno	= RegistroNotas.CodAlumno	AND
																									SubPer1.CodCurso	= RegistroNotas.CodCurso	AND
																									SubPer1.CodMateria	= RegistroNotas.CodMateria	AND 
																									SubPer1.AñoElectivo	= RegistroNotas.AñoElectivo
					LEFT JOIN (SELECT	RegistroNotas.CodAlumno
										,RegistroNotas.CodCurso
										,RegistroNotas.CodMateria
										,RegistroNotas.AñoElectivo
										,NotaFinal
										,CAST(ROUND(CAST(CAST(Periodos.Porcentaje AS NUMERIC(18,2))/100 AS NUMERIC(18,2))*NotaFinal,1)AS NUMERIC(18,2)) AS ValorPorcPeriodo2
										,Periodos.Porcentaje		AS PorcPeriodo2
								FROM	RegistroNotas
										INNER JOIN Periodos ON RegistroNotas.CodPeriodo = Periodos.CodigoPeriodo
								WHERE	RegistroNotas.CodPeriodo = '02' AND
										RegistroNotas.CodCurso		= @CodCurso		AND
										--RegistroNotas.CodPeriodo	= @CodPeriodo	AND
										RegistroNotas.AñoElectivo	= @AñoElectivo	) AS SubPer2 ON SubPer2.CodAlumno	= RegistroNotas.CodAlumno	AND
																									SubPer2.CodCurso	= RegistroNotas.CodCurso	AND
																									SubPer2.CodMateria	= RegistroNotas.CodMateria	AND 
																									SubPer2.AñoElectivo	= RegistroNotas.AñoElectivo
					LEFT JOIN (SELECT	RegistroNotas.CodAlumno
										,RegistroNotas.CodCurso
										,RegistroNotas.CodMateria
										,RegistroNotas.AñoElectivo
										,NotaFinal
										,CAST(ROUND(CAST(CAST(Periodos.Porcentaje AS NUMERIC(18,2))/100 AS NUMERIC(18,2))*NotaFinal,1)AS NUMERIC(18,2)) AS ValorPorcPeriodo3
										,Periodos.Porcentaje		AS PorcPeriodo3
								FROM	RegistroNotas
										INNER JOIN Periodos ON RegistroNotas.CodPeriodo = Periodos.CodigoPeriodo
								WHERE	RegistroNotas.CodPeriodo = '03' AND
										RegistroNotas.CodCurso		= @CodCurso		AND
										--RegistroNotas.CodPeriodo	= @CodPeriodo	AND
										RegistroNotas.AñoElectivo	= @AñoElectivo	) AS SubPer3 ON SubPer3.CodAlumno	= RegistroNotas.CodAlumno	AND
																									SubPer3.CodCurso	= RegistroNotas.CodCurso	AND
																									SubPer3.CodMateria	= RegistroNotas.CodMateria	AND 
																									SubPer3.AñoElectivo	= RegistroNotas.AñoElectivo
					LEFT JOIN (SELECT	RegistroNotas.CodAlumno
										,RegistroNotas.CodCurso
										,RegistroNotas.CodMateria
										,RegistroNotas.AñoElectivo
										,NotaFinal
										,CAST(ROUND(CAST(CAST(Periodos.Porcentaje AS NUMERIC(18,2))/100 AS NUMERIC(18,2))*NotaFinal,1)AS NUMERIC(18,2)) AS ValorPorcPeriodo4
										,Periodos.Porcentaje		AS PorcPeriodo4
								FROM	RegistroNotas
										INNER JOIN Periodos ON RegistroNotas.CodPeriodo = Periodos.CodigoPeriodo
								WHERE	RegistroNotas.CodPeriodo = '04' AND
										RegistroNotas.CodCurso		= @CodCurso		AND
										--RegistroNotas.CodPeriodo	= @CodPeriodo	AND
										RegistroNotas.AñoElectivo	= @AñoElectivo	) AS SubPer4 ON SubPer4.CodAlumno	= RegistroNotas.CodAlumno	AND
																									SubPer4.CodCurso	= RegistroNotas.CodCurso	AND
																									SubPer4.CodMateria	= RegistroNotas.CodMateria	AND 
																									SubPer4.AñoElectivo	= RegistroNotas.AñoElectivo
			WHERE	RegistroNotas.CodCurso		= @CodCurso		AND
					RegistroNotas.CodPeriodo	= @CodPeriodo	AND
					RegistroNotas.AñoElectivo	= @AñoElectivo				
			ORDER BY RegistroNotas.CodCurso,Materias.CodArea,Materias.Nombre

		END

		IF @Operacion = 'SELNOTAALUM'
		BEGIN
			SELECT	Materias.CodArea
					,Areas.Nombre				AS NombreArea
					,RegistroNotas.CodMateria
					,Materias.Nombre			AS NombreMateria			
					,RegistroNotas.NotaFinal	AS NotaFinalP1
					,CAST(ROUND(CAST(CAST(Periodos.Porcentaje AS NUMERIC(18,2))/100 AS NUMERIC(18,2))*RegistroNotas.NotaFinal,1)AS NUMERIC(18,2)) AS ValorPorcPeriodo1
					,CAST(ISNULL(SubPer2.NotaFinalP2,0) AS NUMERIC(18,2)) AS NotaFinalP2
					,CAST(ISNULL(SubPer2.ValorPorcPeriodo2,0) AS NUMERIC(18,2)) AS ValorPorcPeriodo2	
					,CAST(ISNULL(SubPer3.NotaFinalP3,0) AS NUMERIC(18,2)) AS NotaFinalP3
					,CAST(ISNULL(SubPer3.ValorPorcPeriodo3,0) AS NUMERIC(18,2)) AS ValorPorcPeriodo3	
					,CAST(ISNULL(SubPer4.NotaFinalP4,0) AS NUMERIC(18,2)) AS NotaFinalP4
					,CAST(ISNULL(SubPer4.ValorPorcPeriodo4,0) AS NUMERIC(18,2)) AS ValorPorcPeriodo4
					,(CAST(ROUND(CAST(CAST(Periodos.Porcentaje AS NUMERIC(18,2))/100 AS NUMERIC(18,2))*RegistroNotas.NotaFinal,1)AS NUMERIC(18,2))+
					 CAST(ISNULL(SubPer2.ValorPorcPeriodo2,0) AS NUMERIC(18,2)) + CAST(ISNULL(SubPer3.ValorPorcPeriodo3,0) AS NUMERIC(18,2)) +
					 CAST(ISNULL(SubPer4.ValorPorcPeriodo4,0) AS NUMERIC(18,2)) ) AS Acumulado
					,RegistroNotas.Fallas + ISNULL(SubPer2.Fallas,0)  + ISNULL(SubPer3.Fallas,0) + ISNULL(SubPer4.Fallas,0)  AS Fallas
			FROM	RegistroNotas 
					INNER JOIN Materias ON Materias.CodMateria = RegistroNotas.CodMateria
					INNER JOIN Areas ON Areas.Codigo = Materias.CodArea
					INNER JOIN Periodos ON Periodos.CodigoPeriodo = RegistroNotas.CodPeriodo

					LEFT JOIN (SELECT	RegistroNotas.CodAlumno
										,RegistroNotas.CodMateria
										,RegistroNotas.AñoElectivo
										,NotaFinal
										,Fallas
										,NotaFinal	AS NotaFinalP2
										,CAST(ROUND(CAST(CAST(Periodos.Porcentaje AS NUMERIC(18,2))/100 AS NUMERIC(18,2))*NotaFinal,1)AS NUMERIC(18,2)) AS ValorPorcPeriodo2
										,Periodos.Porcentaje				AS PorcPeriodo2
								FROM	RegistroNotas
										INNER JOIN Periodos ON RegistroNotas.CodPeriodo = Periodos.CodigoPeriodo
								WHERE	RegistroNotas.CodPeriodo = '02' AND
										RegistroNotas.CodAlumno	= @CodAlumno	AND
										RegistroNotas.AñoElectivo	= @AñoElectivo	) AS SubPer2 ON SubPer2.CodAlumno	= RegistroNotas.CodAlumno	AND																									
																									SubPer2.CodMateria	= RegistroNotas.CodMateria	AND 
																									SubPer2.AñoElectivo	= RegistroNotas.AñoElectivo
					LEFT JOIN (SELECT	RegistroNotas.CodAlumno
										,RegistroNotas.CodMateria
										,RegistroNotas.AñoElectivo
										,NotaFinal
										,Fallas
										,NotaFinal	AS NotaFinalP3
										,CAST(ROUND(CAST(CAST(Periodos.Porcentaje AS NUMERIC(18,2))/100 AS NUMERIC(18,2))*NotaFinal,1)AS NUMERIC(18,2)) AS ValorPorcPeriodo3
										,Periodos.Porcentaje				AS PorcPeriodo3
								FROM	RegistroNotas
										INNER JOIN Periodos ON RegistroNotas.CodPeriodo = Periodos.CodigoPeriodo
								WHERE	RegistroNotas.CodPeriodo = '03' AND
										RegistroNotas.CodAlumno	= @CodAlumno	AND
										RegistroNotas.AñoElectivo	= @AñoElectivo	) AS SubPer3 ON SubPer3.CodAlumno	= RegistroNotas.CodAlumno	AND																									
																									SubPer3.CodMateria	= RegistroNotas.CodMateria	AND 
																									SubPer3.AñoElectivo	= RegistroNotas.AñoElectivo

					LEFT JOIN (SELECT	RegistroNotas.CodAlumno
										,RegistroNotas.CodMateria
										,RegistroNotas.AñoElectivo
										,NotaFinal
										,Fallas
										,NotaFinal	AS NotaFinalP4
										,CAST(ROUND(CAST(CAST(Periodos.Porcentaje AS NUMERIC(18,2))/100 AS NUMERIC(18,2))*NotaFinal,1)AS NUMERIC(18,2)) AS ValorPorcPeriodo4
										,Periodos.Porcentaje				AS PorcPeriodo4
								FROM	RegistroNotas
										INNER JOIN Periodos ON RegistroNotas.CodPeriodo = Periodos.CodigoPeriodo
								WHERE	RegistroNotas.CodPeriodo = '04' AND
										RegistroNotas.CodAlumno	= @CodAlumno	AND
										RegistroNotas.AñoElectivo	= @AñoElectivo	) AS SubPer4 ON SubPer4.CodAlumno	= RegistroNotas.CodAlumno	AND																									
																									SubPer4.CodMateria	= RegistroNotas.CodMateria	AND 
																									SubPer4.AñoElectivo	= RegistroNotas.AñoElectivo

			WHERE	RegistroNotas.CodAlumno = @CodAlumno
					AND RegistroNotas.AñoElectivo = @AñoElectivo
					AND RegistroNotas.CodPeriodo = '01'
		END

		IF @Operacion = 'SELECTPLANILLA'
		BEGIN			
			SELECT	CursoAlumnos.CodigoAlum				AS CodigoAlum			
					,Personas.PrimerApellido			AS PrimerApellido
					,Personas.SegundoApellido			AS SegundoApellido
					,Personas.PrimerNombre				AS PrimerNombre
					,Personas.SegundoNombre				AS SegundoNombre
					,Cursos.CodigoCurso					AS CodigoCurso
					,Cursos.Nombre						AS NombreCurso										
			FROM	CursoAlumnos					
					INNER JOIN Alumnos ON Alumnos.CodigoAlum = CursoAlumnos.CodigoAlum	AND Alumnos.Estado IN ('A','S')
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona 
					INNER JOIN Cursos ON Cursos.CodigoCurso = CursoAlumnos.CodigoCurso
			WHERE		
					CursoAlumnos.CodigoCurso	= @CodCurso		AND				
					CursoAlumnos.AñoElectivo	= @AñoElectivo	
			ORDER BY Personas.Nombre
		END

		IF @Operacion = 'SELCONSOXCUR'
		BEGIN
			DECLARE @Iteracion		INT	
					,@NomMateria	VARCHAR(MAX)= ''
					,@Materias		VARCHAR(MAX)= ''
					,@Materias2		VARCHAR(MAX)= ''	
						
			SET		@Iteracion		= 0	
			SET		@NomMateria	= ''
			SET		@Materias		= ''
			SET		@Materias2		= ''
		
			DECLARE @Consulta	NVARCHAR(MAX)	
			SET	@Consulta = " SELECT	CodAlumno
										,Nombre
										*MATERIAS*
								FROM
										(SELECT	RN.CodAlumno
												,P.Nombre
												,Materias.Nombre			AS NombreMateria			
												,RN.NotaFinal	AS NotaFinalP1
										FROM	RegistroNotas AS RN 
												INNER JOIN Materias ON Materias.CodMateria = RN.CodMateria
												INNER JOIN Periodos ON Periodos.CodigoPeriodo = RN.CodPeriodo	
												INNER JOIN Alumnos AS AL ON AL.CodigoAlum = RN.CodAlumno
												INNER JOIN Personas AS P ON P.Id = AL.IdPersona	

										WHERE	RN.AñoElectivo = '*@AñoElectivo*'
												AND RN.CodPeriodo = '*@CodPeriodo*'
												AND RN.CodCurso = '*@CodCurso*'
												) SUB
									PIVOT
									(
										SUM(SUB.NotaFinalP1) FOR SUB.NombreMateria  IN (*MATERIAS2*)
									) AS PIVOTABLE;"			

			DECLARE Materias_Cursor CURSOR FOR

					SELECT	DISTINCT "[" + Materias.Nombre + "]"	AS NombreMateria	
					FROM	RegistroNotas AS RN 
							INNER JOIN Materias ON Materias.CodMateria = RN.CodMateria
							INNER JOIN Periodos ON Periodos.CodigoPeriodo = RN.CodPeriodo	
							INNER JOIN Alumnos AS AL ON AL.CodigoAlum = RN.CodAlumno
							INNER JOIN Personas AS P ON P.Id = AL.IdPersona	

					WHERE	RN.AñoElectivo = @AñoElectivo
							AND RN.CodPeriodo = @CodPeriodo
							AND RN.CodCurso = @CodCurso	
					ORDER BY  NombreMateria
			OPEN Materias_Cursor
			FETCH NEXT FROM Materias_Cursor 
			INTO  @NomMateria
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				IF @Iteracion = 0
				BEGIN
					SET @Materias2 = @Materias2 + @NomMateria
				END
				ELSE
				BEGIN
					SET @Materias2 = @Materias2 + "," + @NomMateria
				END

				SET @Materias = @Materias + "," + @NomMateria

				SET @Iteracion = 1

				FETCH NEXT FROM Materias_Cursor 
				INTO  @NomMateria
			END
			CLOSE Materias_Cursor
			DEALLOCATE Materias_Cursor


			SET	@Consulta = REPLACE(@Consulta,'*MATERIAS*',@Materias)
			SET	@Consulta = REPLACE(@Consulta,'*MATERIAS2*',@Materias2)
			SET	@Consulta = REPLACE(@Consulta,'*@AñoElectivo*',@AñoElectivo)
			SET	@Consulta = REPLACE(@Consulta,'*@CodPeriodo*',@CodPeriodo)
			SET	@Consulta = REPLACE(@Consulta,'*@CodCurso*',@CodCurso)

			IF @Materias <> ''
			BEGIN
				EXEC sp_executesql 	 @Consulta
			END

		END 

	END

GO
/****** Object:  StoredProcedure [dbo].[PA_Usuarios]    Script Date: 09/02/2016 13:16:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[PA_Usuarios] 
		@Operacion			VARCHAR(20)	= NULL
		,@Id				INT			= NULL
		,@Codigo			VARCHAR(8)	= NULL	
		,@Nombre			VARCHAR(50)	= NULL
		,@NombrePersona		VARCHAR(200)	= NULL
		,@Contrasenia		VARCHAR(50)	= NULL
		,@CodTipoUsuario	VARCHAR(2)	= NULL
		,@PrimerNombre		VARCHAR(50)		= NULL
		,@SegundoNombre		VARCHAR(50)		= NULL
		,@PrimerApellido	VARCHAR(50)		= NULL
		,@SegundoApellido	VARCHAR(50)		= NULL
		,@Identificacion	VARCHAR(50)		= NULL
		,@Direccion			VARCHAR(150)	= NULL
		,@Telefono			VARCHAR(150)	= NULL
		,@Email				VARCHAR(150)	= NULL
		,@Sexo				VARCHAR(1)		= NULL	
		,@IdPersona			INT			= NULL
	AS

	BEGIN
		
		DECLARE @CodUsuario VARCHAR(8)		
		SET		@CodUsuario = 'USU00000'

		DECLARE @CodProfe VARCHAR(6)		
		SET		@CodProfe = 'PF0000'

		DECLARE @CodAlumno VARCHAR(8)		
		SET		@CodAlumno = 'ALU00000'
		
		IF @Operacion = 'SELECTID'
		BEGIN
			SELECT	Usuarios.Id
					 ,Personas.Id		AS IdPersona
					,Personas.Nombre	AS NombrePersona
					,Personas.PrimerNombre
					,Personas.SegundoNombre
					,Personas.PrimerApellido
					,Personas.SegundoApellido
					,Personas.Identificacion
					,Personas.Direccion
					,Personas.Telefono
					,Personas.Email
					,Personas.Sexo
					,Usuarios.Codigo
					,Usuarios.Nombre
					,Usuarios.Contrasenia 
					,Usuarios.CodTipoUsuario
					--,TipoUsuarios.Nombre		AS NombreTipoUsuario
			FROM	Usuarios WITH(nolock) 
					INNER JOIN TipoUsuarios ON TipoUsuarios.Codigo = Usuarios.CodTipoUsuario
					INNER JOIN PersonaUsuarios ON PersonaUsuarios.CodUsuario = Usuarios.Codigo
					INNER JOIN Personas ON Personas.Id = PersonaUsuarios.IdPersona
			WHERE	Usuarios.Id = @Id 			
		END

		IF @Operacion = 'SELECTALL'
		BEGIN
			SELECT	Usuarios.Id
					,Personas.Id		AS IdPersona
					--,Personas.PrimerNombre
					--,Personas.SegundoNombre
					--,Personas.PrimerApellido
					--,Personas.SegundoApellido
					--,Personas.Identificacion
					--,Personas.Direccion
					--,Personas.Telefono
					--,Personas.Email
					--,Personas.Sexo
					,Usuarios.Codigo
					,Usuarios.Nombre
					,Usuarios.Contrasenia 
					,Usuarios.CodTipoUsuario
					,TipoUsuarios.Nombre   AS NombreTipoUsuario
			FROM	Usuarios WITH(nolock) 
					INNER JOIN TipoUsuarios ON TipoUsuarios.Codigo = Usuarios.CodTipoUsuario
					INNER JOIN PersonaUsuarios ON PersonaUsuarios.CodUsuario = Usuarios.Codigo
					INNER JOIN Personas ON Personas.Id = PersonaUsuarios.IdPersona
			WHERE	Usuarios.delmrk = '1'	AND Personas.delmrk = '1'		
		END

		IF @Operacion = 'SELECTNAME'
		BEGIN
			SELECT	Usuarios.Id
					,Personas.Id				AS IdPersona
					,Usuarios.CodTipoUsuario
					,TipoUsuarios.Nombre		AS TipoUsuario
					,Usuarios.Codigo
					,Usuarios.Nombre
					,Usuarios.Contrasenia 
					,Personas.Nombre		AS NombrePersona
			FROM	Usuarios 
					INNER JOIN TipoUsuarios ON TipoUsuarios.Codigo = Usuarios.CodTipoUsuario
					INNER JOIN PersonaUsuarios ON PersonaUsuarios.CodUsuario = Usuarios.Codigo
					INNER JOIN Personas ON Personas.Id = PersonaUsuarios.IdPersona
			WHERE	Usuarios.delmrk = '1' 
					AND Usuarios.Nombre = @Nombre
		END
		
		IF @Operacion = 'SDATUSUPRO'
		BEGIN
			SELECT	Usuarios.Id
					,Usuarios.CodTipoUsuario
					,TipoUsuarios.Nombre		AS TipoUsuario
					,Usuarios.Codigo
					,Usuarios.Nombre
					,Usuarios.Contrasenia 
					,Personas.Nombre		AS NombrePersona
					,Profesores.CodigoProfesor	
			FROM	Usuarios 
					INNER JOIN TipoUsuarios ON TipoUsuarios.Codigo = Usuarios.CodTipoUsuario
					INNER JOIN PersonaUsuarios ON PersonaUsuarios.CodUsuario = Usuarios.Codigo
					INNER JOIN Personas ON Personas.Id = PersonaUsuarios.IdPersona
					INNER JOIN Profesores ON Personas.Id = Profesores.IdPersona
			WHERE	Usuarios.delmrk = '1' 
					AND Usuarios.Nombre = @Nombre
		END

		IF @Operacion = 'SDATUSUALUM'
		BEGIN
			SELECT	Usuarios.Id
					,Usuarios.CodTipoUsuario
					,TipoUsuarios.Nombre		AS TipoUsuario
					,Usuarios.Codigo
					,Usuarios.Nombre
					,Usuarios.Contrasenia 
					,Personas.Nombre		AS NombrePersona
					,Alumnos.CodigoAlum	
			FROM	Usuarios 
					INNER JOIN TipoUsuarios ON TipoUsuarios.Codigo = Usuarios.CodTipoUsuario
					INNER JOIN PersonaUsuarios ON PersonaUsuarios.CodUsuario = Usuarios.Codigo
					INNER JOIN Personas ON Personas.Id = PersonaUsuarios.IdPersona
					INNER JOIN Alumnos ON Personas.Id = Alumnos.IdPersona
			WHERE	Usuarios.delmrk = '1' 
					AND Usuarios.Nombre = @Nombre
		END
		
		IF @Operacion = 'INSERTBASICO'
		BEGIN
			SELECT @CodUsuario = 'USU'+LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,5,'0'))) FROM Usuarios

			INSERT INTO Personas	(Nombre
									,PrimerNombre
									,SegundoNombre
									,PrimerApellido
									,SegundoApellido
									,Identificacion
									,Direccion
									,Telefono
									,Sexo
									,Email)
			VALUES					(@NombrePersona
									,@PrimerNombre
									,@SegundoNombre
									,@PrimerApellido
									,@SegundoApellido
									,@Identificacion
									,@Direccion
									,@Telefono
									,@Sexo
									,@Email)

			SELECT @Id = @@IDENTITY

			INSERT INTO Usuarios	(Codigo
									,Nombre
									,Contrasenia
									,CodTipoUsuario)
			VALUES					(@CodUsuario
									,@Nombre
									,@Contrasenia
									,@CodTipoUsuario)

			INSERT INTO PersonaUsuarios (IdPersona
										,CodUsuario
										,CodTipoUsuario)
			VALUES						(@Id
										,@CodUsuario
										,@CodTipoUsuario)
			
			SELECT @Id AS IdPersona,@CodUsuario AS CodUsuario
		END
		
		IF @Operacion = 'INSERTPROFE'
		BEGIN
			SELECT @CodUsuario = 'USU'+LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,5,'0'))) FROM Usuarios
			SELECT @CodProfe = 'PF'+LTRIM(RTRIM(DBO.PadL(ISNULL(count(CodigoProfesor),0)+1,4,'0'))) FROM Profesores

			INSERT INTO Personas	(Nombre
									,PrimerNombre
									,SegundoNombre
									,PrimerApellido
									,SegundoApellido
									,Identificacion
									,Direccion
									,Telefono
									,Sexo
									,Email)
			VALUES					(@NombrePersona
									,@PrimerNombre
									,@SegundoNombre
									,@PrimerApellido
									,@SegundoApellido
									,@Identificacion
									,@Direccion
									,@Telefono
									,@Sexo
									,@Email)			

			SELECT @Id = @@IDENTITY

			INSERT INTO Profesores (IdPersona
									,CodigoProfesor
									,Estado)
			VALUES				(	@Id
									,@CodProfe
									,'I')

			INSERT INTO Usuarios	(Codigo
									,Nombre
									,Contrasenia
									,CodTipoUsuario)
			VALUES					(@CodUsuario
									,@Nombre
									,@Contrasenia
									,@CodTipoUsuario)

			INSERT INTO PersonaUsuarios (IdPersona
										,CodUsuario
										,CodTipoUsuario)
			VALUES						(@Id
										,@CodUsuario
										,@CodTipoUsuario)
			
			SELECT @Id AS IdPersona,@CodUsuario AS CodUsuario
		END
		
		IF @Operacion = 'INSERTALUMNO'
		BEGIN
			SELECT @CodUsuario = 'USU'+LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,5,'0'))) FROM Usuarios
			SELECT @CodAlumno = 'ALU'+LTRIM(RTRIM(DBO.PadL(ISNULL(count(CodigoAlum),0)+1,5,'0'))) FROM Alumnos

			INSERT INTO Personas	(Nombre
									,PrimerNombre
									,SegundoNombre
									,PrimerApellido
									,SegundoApellido
									,Identificacion
									,Direccion
									,Telefono
									,Sexo
									,Email)
			VALUES					(@NombrePersona
									,@PrimerNombre
									,@SegundoNombre
									,@PrimerApellido
									,@SegundoApellido
									,@Identificacion
									,@Direccion
									,@Telefono
									,@Sexo
									,@Email)			

			SELECT @Id = @@IDENTITY

			INSERT INTO Alumnos (	IdPersona
									,CodigoAlum
									,Carnet
									,Estado)
			VALUES				(	@Id
									,@CodAlumno
									,@Identificacion
									,'I')

			INSERT INTO Usuarios	(Codigo
									,Nombre
									,Contrasenia
									,CodTipoUsuario)
			VALUES					(@CodUsuario
									,@Nombre
									,@Contrasenia
									,@CodTipoUsuario)

			INSERT INTO PersonaUsuarios (IdPersona
										,CodUsuario
										,CodTipoUsuario)
			VALUES						(@Id
										,@CodUsuario
										,@CodTipoUsuario)
			
			SELECT @Id AS IdPersona,@CodUsuario AS CodUsuario
		END

		IF @Operacion = 'UPDATE'
		BEGIN			

			IF (@IdPersona != '-1')
			BEGIN
				UPDATE	Usuarios 
				SET		Contrasenia		= @Contrasenia
						,CodTipoUsuario	= @CodTipoUsuario
				WHERE	Id = @Id
			
				UPDATE	Personas 
				SET		Nombre				= @NombrePersona
						,PrimerNombre		= @PrimerNombre
						,SegundoNombre		= @SegundoNombre
						,PrimerApellido		= @PrimerApellido
						,SegundoApellido	= @SegundoApellido
						,Identificacion		= @Identificacion
						,Direccion			= @Direccion
						,Telefono			= @Telefono
						,Email				= @Email	
						,Sexo				= @Sexo							
				WHERE	Id = @IdPersona

				SELECT @@ROWCOUNT AS CantidadAfectada
			END
			ELSE
			BEGIN
				UPDATE	Usuarios 
				SET		Contrasenia		= @Contrasenia
						,CodTipoUsuario	= @CodTipoUsuario
				WHERE	Id = @Id
			END
		END

		IF @Operacion = 'DEL'
		BEGIN	
			SELECT @CodUsuario = Usuarios.Codigo FROM Usuarios WHERE Usuarios.Id = @Id	
			
			DELETE FROM Personas WHERE Id = @IdPersona

			DELETE FROM Usuarios WHERE	Id = @Id

			DELETE FROM PersonaUsuarios WHERE	CodUsuario = @CodUsuario AND IdPersona = @IdPersona							
		END

	END

GO
USE [master]
GO
ALTER DATABASE [RECORDRATINGS] SET  READ_WRITE 
GO
