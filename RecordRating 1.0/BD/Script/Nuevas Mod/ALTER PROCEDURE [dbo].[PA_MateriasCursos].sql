USE [CARGAPE1]
GO
/****** Object:  StoredProcedure [dbo].[PA_MateriasCursos]    Script Date: 09/06/2016 12:29:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	ALTER PROCEDURE [dbo].[PA_MateriasCursos] 
		@Operacion			VARCHAR(20)		= NULL
		,@CodCurso			VARCHAR(4)		= NULL	
		,@CodMateria		VARCHAR(3)		= NULL	
		,@IHS				INT				= NULL
		,@CodProfesor		VARCHAR(9)		= NULL
		,@AñoElectivo		INT				= NULL
		,@Porcentaje		INT				= NULL
		,@CodArea			VARCHAR(2)		= NULL
		
	AS

	BEGIN		
			
		IF @Operacion = 'SCURSOS'
		BEGIN
			SELECT	Id
					,CodigoCurso
					,Nombre	
			FROM	Cursos WITH(nolock) 	
			WHERE	delmrk = '1'
			ORDER BY CodGrado, CodGrupo
		END
		

		IF @Operacion = 'SCURSOS_AE'
		BEGIN
			SELECT	C.Id
					,C.CodigoCurso
					,C.Nombre			
			FROM	Cursos AS C WITH(nolock) 
					INNER JOIN	CursosAñoElectivo AS CA ON C.CodigoCurso = CA.CodigoCurso
			WHERE	C.delmrk = '1' AND CA.AñoElectivo = @AñoElectivo AND CA.Estado = 1
			ORDER BY C.CodGrado,C.CodGrupo
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
					,MateriasCursos.Porcentaje
					,MateriasCursos.CodProfesor
					,Personas.Nombre	AS Profesor
					,MateriasCursos.CodArea
			FROM	MateriasCursos WITH(nolock) 
					INNER JOIN Materias ON Materias.CodMateria = MateriasCursos.CodMateria
					INNER JOIN Profesores ON Profesores.CodigoProfesor = MateriasCursos.CodProfesor		AND Profesores.Estado = 'A'
					INNER JOIN Personas ON Personas.Id = Profesores.IdPersona
			WHERE	MateriasCursos.CodCurso = @CodCurso	
			ORDER BY Materias.Nombre
		END		

		IF @Operacion = 'SMATCURSOSCAB'
		BEGIN
			SELECT	MC.CodCurso
					,MC.CodArea	
					,A.Nombre			AS NombreArea	
					,SUM(MC.Porcentaje) AS TotalPorcentaje
			FROM	MateriasCursos AS MC WITH(nolock) 		
					INNER JOIN Areas AS A ON A.Codigo = MC.CodArea
			WHERE	MC.CodCurso = @CodCurso
			GROUP BY MC.CodCurso, MC.CodArea, A.Nombre	
			ORDER BY A.Nombre
		END	
		
		IF @Operacion = 'INSERT'
		BEGIN	

			INSERT INTO MateriasCursos(	CodCurso
										,CodMateria
										,IHS
										,CodProfesor
										,Porcentaje
										,CodArea)
					VALUES			(	@CodCurso
										,@CodMateria
										,@IHS
										,@CodProfesor
										,@Porcentaje
										,@CodArea)
			
			SELECT @CodCurso AS CodCurso,@CodMateria AS CodMateria
		END

		IF @Operacion = 'UPDATE'
		BEGIN
			UPDATE	MateriasCursos 
			SET		IHS				= 	@IHS
					,CodProfesor	= 	@CodProfesor
					,Porcentaje		= 	@Porcentaje
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
			ORDER BY Materias.Nombre
			
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
			ORDER BY Materias.Nombre
			
		END

		IF @Operacion = 'SMATCURONE'
		BEGIN
			SELECT	MateriasCursos.CodCurso
					,Cursos.Nombre	AS NombreCurso
					,MateriasCursos.CodMateria	
					,MateriasCursos.IHS
					,MateriasCursos.CodProfesor
					,MateriasCursos.Porcentaje
					,MateriasCursos.CodArea
					,ISNULL(Areas.Nombre,'') AS NombreArea
			FROM	MateriasCursos WITH(nolock) 
					INNER JOIN Cursos ON Cursos.CodigoCurso = MateriasCursos.CodCurso
					LEFT JOIN Areas ON Areas.Codigo = MateriasCursos.CodArea
			WHERE	MateriasCursos.CodCurso = @CodCurso AND MateriasCursos.CodMateria	= @CodMateria
			ORDER BY Cursos.CodGrado, Cursos.CodGrupo
		END

	END
