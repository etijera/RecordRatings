USE [CARGAPE1]
GO
/****** Object:  StoredProcedure [dbo].[PA_Usuarios]    Script Date: 23/06/2016 13:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	ALTER PROCEDURE [dbo].[PA_Usuarios] 
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
			ORDER BY Usuarios.Nombre	
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
					,Personas.Id				AS IdPersona
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
					AND Profesores.Estado = 'A'
					AND Usuarios.Nombre = @Nombre
		END

		IF @Operacion = 'SDATUSUALUM'
		BEGIN
			SELECT	Usuarios.Id
					,Personas.Id				AS IdPersona
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
					AND Alumnos.Estado = 'A'
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
