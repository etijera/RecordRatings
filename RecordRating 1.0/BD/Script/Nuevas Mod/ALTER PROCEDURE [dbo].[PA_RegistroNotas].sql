USE [CARGAPE1]
GO
/****** Object:  StoredProcedure [dbo].[PA_RegistroNotas]    Script Date: 22/06/2016 13:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
	ALTER PROCEDURE [dbo].[PA_RegistroNotas] 
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
			GROUP BY Personas.Nombre,CodProfesor,CodCurso,Cursos.Nombre, Cursos.CodGrado, Cursos.CodGrupo
			ORDER BY Cursos.CodGrado, Cursos.CodGrupo

		END		
		
		IF @Operacion = 'SCURPROF_AE'
		BEGIN
			SELECT	MateriasCursos.CodCurso
					,Cursos.Nombre
			FROM	Profesores
					INNER JOIN Personas			ON Personas.Id = Profesores.IdPersona
					INNER JOIN MateriasCursos	ON MateriasCursos.CodProfesor = Profesores.CodigoProfesor
					INNER JOIN Cursos			ON Cursos.CodigoCurso =	MateriasCursos.CodCurso
					INNER JOIN CursosAñoElectivo AS CA ON Cursos.CodigoCurso = CA.CodigoCurso 
			WHERE	MateriasCursos.CodProfesor = @CodProfesor	AND Profesores.Estado = 'A'
					AND CA.AñoElectivo = @AñoElectivo AND CA.Estado = 1
			GROUP BY Personas.Nombre,CodProfesor,CodCurso,Cursos.Nombre, Cursos.CodGrado, Cursos.CodGrupo
			ORDER BY Cursos.CodGrado, Cursos.CodGrupo

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
			ORDER BY Materias.Nombre
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
			ORDER BY Materias.Nombre
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
			ORDER BY Personas.Nombre
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
					, Materias.Nombre + '    (' + CAST(MC.Porcentaje AS VARCHAR(3)) + ' %)' 			AS NombreMateria				
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
					,MC.Porcentaje
					,CAST((MC.Porcentaje * RegistroNotas.NotaFinal)/100 AS numeric(18,3)) AS ValorPorcentual
			FROM	RegistroNotas
					INNER JOIN Alumnos ON Alumnos.CodigoAlum = RegistroNotas.CodAlumno		AND	Alumnos.Estado IN ('A','S')
					INNER JOIN Personas ON Personas.Id = Alumnos.IdPersona
					INNER JOIN Cursos ON Cursos.CodigoCurso = RegistroNotas.CodCurso
					INNER JOIN Materias ON Materias.CodMateria = RegistroNotas.CodMateria
					INNER JOIN MateriasCursos AS MC ON MC.CodCurso = RegistroNotas.CodCurso AND MC.CodMateria = RegistroNotas.CodMateria
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
			ORDER BY RegistroNotas.CodCurso,Areas.Nombre,Materias.Nombre

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
			ORDER BY RegistroNotas.CodCurso,Areas.Nombre,Materias.Nombre
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
