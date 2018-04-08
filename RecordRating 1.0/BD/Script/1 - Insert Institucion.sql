
/*
	Autor		: Etijera
	Fecha		: 20160209
	Proposito	: Permite insetar el registro 

	NOTA		: 


	Probar		: SELECT * FROM Institucion
*/

USE [RECORDRATINGS]
GO

IF NOT ( SELECT COUNT(*) FROM Institucion ) > 0
BEGIN
	INSERT INTO Institucion(Nombre,Nit,Direccion,Telefono,Email,Resolusion,CodigoDane,Abreviaura,Lema,Director,Secretaria,Coordinador,Logo)
	VALUES('','','','','','','','','','','','','')
END