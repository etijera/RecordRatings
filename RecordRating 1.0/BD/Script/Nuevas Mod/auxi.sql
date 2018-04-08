select * from Materias order by 1
select * from Cursos
select * from MateriasCursos where CodMateria = '021'
select * from MateriasCursos where CodMateria = '025'
select * from MateriasCursos where CodCurso = '0008'
select * from Areas

--10 025	EMPRENDIMIENTO
--13 029	EMPRENDIMIENTO (6 Y 7)
-- 10	021	LEGISLACIÓN

--update MateriasCursos set CodArea = '10' where CodMateria = '021'

--update MateriasCursos set CodProfesor = 'PF0001' where CodMateria = '025'

select * from Profesores
select * from Personas where Id ='137'
select * from RegistroNotas where CodPeriodo = '01' and AñoElectivo = '2016' and CodCurso = '0010' and CodMateria = '021' and CodProfesor = 'PF0015'
select * from RegistroNotas where CodPeriodo = '01' and AñoElectivo = '2016' and CodCurso = '0007' and CodMateria = '025' and CodProfesor = 'PF0015'

--update RegistroNotas set CodMateria = '029' where CodPeriodo = '01' and AñoElectivo = '2016' and CodCurso = '0001' and CodMateria = '025' and CodProfesor = 'PF0015'
--update RegistroNotas set CodMateria = '029' where CodPeriodo = '01' and AñoElectivo = '2016' and CodCurso = '0007' and CodMateria = '025' and CodProfesor = 'PF0015'

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
			WHERE	MateriasCursos.CodCurso = '0008'	
			ORDER BY Materias.Nombre

			select * from Cursos

			select	A.CodigoAlum
					,P.Nombre
			from	CursoAlumnos CA
					INNER JOIN Alumnos AS A ON A.CodigoAlum = CA.CodigoAlum
					INNER JOIN Personas P ON P.Id = A.IdPersona
			where AñoElectivo = '2016' and CodigoCurso = '0009' and A.CodigoAlum = 'ALU00082'
			order by A.CodigoAlum	
			
			select	A.CodigoAlum
					,P.Nombre
			from	CursoAlumnos CA
					INNER JOIN Alumnos AS A ON A.CodigoAlum = CA.CodigoAlum
					INNER JOIN Personas P ON P.Id = A.IdPersona
			where AñoElectivo = '2016' and CodigoCurso = '0009' and A.CodigoAlum = 'ALU00167'
			order by A.CodigoAlum

			select * from alumnos where CodigoAlum ='ALU00167'
			select * from alumnos where CodigoAlum ='ALU00082'

			select * from RegistroNotas where AñoElectivo='2016' and CodPeriodo = '01' and CodCurso = '0009' and CodAlumno='ALU00082'
'