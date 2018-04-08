

/*
	Autor		: Etijera
	Fecha		: 20160209
	Proposito	: Permite insetar los periodos necesarios en el sistema

	NOTA		: Los periodos pueden variar de acuerdo a las necesidades del usuario.


	Probar		: SELECT * FROM Periodos
*/

USE [RECORDRATINGS]
GO

IF NOT EXISTS (SELECT * FROM Periodos WHERE CodigoPeriodo = '01') 
BEGIN
	INSERT INTO Periodos (CodigoPeriodo,Nombre,Numero,Porcentaje) 
	VALUES('01','PRIMER PERIODO','1','20')
END


IF NOT EXISTS (SELECT * FROM Periodos WHERE CodigoPeriodo = '02') 
BEGIN
	INSERT INTO Periodos (CodigoPeriodo,Nombre,Numero,Porcentaje) 
	VALUES('02','SEGUNDO PERIODO','2','30')
END


IF NOT EXISTS (SELECT * FROM Periodos WHERE CodigoPeriodo = '03') 
BEGIN
	INSERT INTO Periodos (CodigoPeriodo,Nombre,Numero,Porcentaje) 
	VALUES('03','TERCER PERIODO','3','20')
END


IF NOT EXISTS (SELECT * FROM Periodos WHERE CodigoPeriodo = '04') 
BEGIN
	INSERT INTO Periodos (CodigoPeriodo,Nombre,Numero,Porcentaje) 
	VALUES('04','CUARTO PERIODO','4','30')
END