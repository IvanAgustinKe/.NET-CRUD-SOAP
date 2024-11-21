Base de datos:

Creación: 
CREATE DATABASE PacientesDB
GO

USE PacientesDB;
GO 

CREATE TABLE Pacientes (
	 Id INT PRIMARY KEY IDENTITY,
	 name NVARCHAR(100),
	 Age INT
);

Servicio 
WebSiteServerSOAP

Aplicación donde consumo el servicio:
ConsoleCrudSOAP