
/****** Object:  StoredProcedure [dbo].[PA_Materias]    Script Date: 10/06/2016 7:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	ALTER PROCEDURE [dbo].[PA_Materias] 
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
		
		IF @Operacion = 'SELECTCOD'
		BEGIN
			SELECT	Materias.Id
					,Materias.CodArea
					,Areas.Nombre  AS NombreArea
					,Materias.CodMateria
					,Materias.Nombre
			FROM	Materias WITH(nolock) 
					INNER JOIN Areas ON Areas.Codigo = Materias.CodArea
			WHERE	Materias.CodMateria = @CodMateria 			
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
			ORDER BY Areas.Nombre, Materias.Nombre	
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

			SELECT	@CodMateria = CodMateria
			FROM	Materias 
			WHERE	Id = @Id
			
			UPDATE	MateriasCursos
			SET		CodArea		= @CodArea
			WHERE	CodMateria	= @CodMateria

			SELECT @@ROWCOUNT AS CantidadAfectada
		END

		IF @Operacion = 'DEL'
		BEGIN
			UPDATE	Materias 
			SET		delmrk		= '0'
			WHERE	Id = @Id
			
		END

	END
