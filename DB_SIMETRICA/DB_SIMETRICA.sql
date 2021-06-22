CREATE DATABASE DB_SIMETRICA
GO
USE DB_SIMETRICA
GO


CREATE TABLE AREA_DEAPARTMENTO(
	CODIGO INT PRIMARY KEY IDENTITY,
	NOMBRE VARCHAR(25) NOT NULL,
)

CREATE TABLE ESTATUS(
	CODIGO INT PRIMARY KEY IDENTITY,
	ESTATUS VARCHAR(15)
)

CREATE TABLE CANDIDATOS(
	CODIGO INT PRIMARY KEY IDENTITY,
	NOMBRE VARCHAR(25) NOT NULL,
	APELLIDO VARCHAR(30) NOT NULL,
	CEDULA VARCHAR(11) NOT NULL,
	EMAIL VARCHAR(21) NOT NULL,
	DIRECCION VARCHAR(21),
    LENGUAJE_PRO VARCHAR(20),
	EXPERIENCIA varchar(500),
	A�O_EXPERIENCIA INT,
	AREA INT NOT NULL,
    CONSTRAINT FK_AREA_DEAPARTMENTO
	   FOREIGN KEY (AREA) 
	REFERENCES AREA_DEAPARTMENTO(CODIGO)
)

CREATE TABLE EVALUACION_CAND(
	CODIGO INT PRIMARY KEY IDENTITY,
	CANDIDATO INT NOT NULL,
	PERSONAL_RRHH VARCHAR(21) NOT NULL,
	COMENTARIO VARCHAR(450),
	ESTATUS INT NOT NULL,
	FECHA_TRAN DATETIME DEFAULT GETDATE()
	CONSTRAINT FK_CANDIDATO
	   FOREIGN KEY (CANDIDATO) 
	REFERENCES CANDIDATOS(CODIGO),
	CONSTRAINT FK_ESTATUS
	   FOREIGN KEY (ESTATUS) 
	REFERENCES ESTATUS(CODIGO)
)

GO

INSERT INTO AREA_DEAPARTMENTO(NOMBRE) VALUES('Backed-End')
INSERT INTO AREA_DEAPARTMENTO(NOMBRE) VALUES('Front-End')
INSERT INTO AREA_DEAPARTMENTO(NOMBRE) VALUES('Base de datos')
INSERT INTO AREA_DEAPARTMENTO(NOMBRE) VALUES('Analista')
INSERT INTO AREA_DEAPARTMENTO(NOMBRE) VALUES('QA')

GO

INSERT INTO ESTATUS (ESTATUS)VALUES('Mal');
INSERT INTO ESTATUS (ESTATUS)VALUES('Bueno');
INSERT INTO ESTATUS (ESTATUS)VALUES('Muy bueno');
INSERT INTO ESTATUS (ESTATUS)VALUES('Excelente');
 