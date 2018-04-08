
/*
	Autor		: Etijera
	Fecha		: 20160209
	Proposito	: Permite insetar los tipos de usuarios utilizados en el sistema. 

	NOTA		: 


	Probar		: SELECT * FROM TipoUsuarios
*/


USE [RECORDRATINGS]
GO

IF NOT EXISTS (SELECT * FROM TipoUsuarios WHERE Codigo = '01') 
BEGIN
	INSERT INTO TipoUsuarios (Codigo,Nombre) 
	VALUES('01','ADMINISTRADOR')
END

IF NOT EXISTS (SELECT * FROM TipoUsuarios WHERE Codigo = '02') 
BEGIN
	INSERT INTO TipoUsuarios (Codigo,Nombre) 
	VALUES('02','PROFESOR')
END

IF NOT EXISTS (SELECT * FROM TipoUsuarios WHERE Codigo = '03') 
BEGIN
	INSERT INTO TipoUsuarios (Codigo,Nombre) 
	VALUES('03','PROFESOR')
END