
/****** Object:  StoredProcedure [dbo].[PA_CursoAlumnos]    Script Date: 07/04/2018 10:08:34 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	ALTER PROCEDURE [dbo].[PA_CursoAlumnos] 
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

		IF @Operacion = 'SCURSOS_AE'
		BEGIN
			SELECT	CU.Id
					,CU.CodigoCurso
					,CU.Nombre	
			FROM	Cursos AS CU WITH(nolock) 
					INNER JOIN CursosAñoElectivo AS CAE ON CU.CodigoCurso = CAE.CodigoCurso
			WHERE	CU.delmrk = '1'		
					AND CAE.AñoElectivo = @AñoElectivo		
			ORDER BY CU.CodGrado,CU.CodGrupo				
		END	

	END
