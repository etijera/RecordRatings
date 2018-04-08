

/*
	Autor		: Etijera
	Fecha		: 20160209
	Proposito	: Permite insetar el usuario administrador en el sistema. Y tambien lo crea como persona.

	NOTA		: 


	Probar		: SELECT * FROM Usuarios WHERE Nombre = 'ADMIN'
				  SELECT * from personas
				  SELECT * from personaUsuarios
*/

USE [RECORDRATINGS]
GO

IF NOT EXISTS (SELECT * FROM Usuarios WHERE Nombre = 'ADMIN') 
BEGIN
	INSERT INTO Usuarios (Codigo,Nombre,Contrasenia,CodTipoUsuario)
	VALUES((SELECT 'USU'+LTRIM(RTRIM(DBO.PadL(ISNULL(Max(Id),0)+1,5,'0'))) FROM Usuarios),'ADMIN','ADMIN','01')


	INSERT INTO Personas(Nombre,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Identificacion,Direccion,Telefono,Email,Sexo)
	VALUES('ADMIN ADMIN','ADMIN','','ADMIN','','ADMIN','','','','M')


	INSERT INTO PersonaUsuarios(IdPersona,CodUsuario,CodTipoUsuario)
	VALUES(@@IDENTITY,(SELECT Codigo FROM Usuarios WHERE Nombre = 'ADMIN'),'01')
END
