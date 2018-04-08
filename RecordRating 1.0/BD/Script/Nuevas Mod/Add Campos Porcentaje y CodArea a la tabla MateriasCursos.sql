

-- Tipo:			Alter a tablas
-- Creación:		09/06/2016
-- Desarrollador:  	Erick Tijera Marchan
-- Proposito:		Agregar Campo Porcentaje y el campo CodArea a la tabla MateriasCursos

/* Modificaciones a tabla MateriasCursos  */

IF NOT EXISTS(SELECT * FROM sys.columns WHERE name = N'Porcentaje' AND object_id = OBJECT_ID(N'dbo.MateriasCursos'))
BEGIN
	ALTER TABLE dbo.MateriasCursos ADD Porcentaje INT DEFAULT (1) NOT NULL
END

IF NOT EXISTS(SELECT * FROM sys.columns WHERE name = N'CodArea' AND object_id = OBJECT_ID(N'dbo.MateriasCursos'))
BEGIN
	ALTER TABLE dbo.MateriasCursos ADD CodArea VARCHAR(2) DEFAULT ('') NOT NULL
END



------- Actualizar la informacion existente


--UPDATE	MC
--SET		MC.CodArea = M.CodArea
--FROM	MateriasCursos AS MC
--		INNER JOIN Materias AS M ON M.CodMateria = MC.CodMateria
