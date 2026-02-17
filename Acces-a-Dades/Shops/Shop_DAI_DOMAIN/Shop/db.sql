-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- b1botiga.dbo.Client definition

-- Drop table

-- DROP TABLE b1botiga.dbo.Client;

CREATE TABLE b1botiga.dbo.Client (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	Nom nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	DNI nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ADDR nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__Client__3214EC2700913ECE PRIMARY KEY (ID)
);


-- b1botiga.dbo.Familia definition

-- Drop table

-- DROP TABLE b1botiga.dbo.Familia;

CREATE TABLE b1botiga.dbo.Familia (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	Nom nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Descripcio nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__Familia__3214EC279A7ACC31 PRIMARY KEY (ID)
);


-- b1botiga.dbo.CarritoCompras definition

-- Drop table

-- DROP TABLE b1botiga.dbo.CarritoCompras;

CREATE TABLE b1botiga.dbo.CarritoCompras (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	nom varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Descripcio varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ID_CLI uniqueidentifier NULL,
	DataCompra date NULL,
	CONSTRAINT PK__CarritoC__3214EC2710D248FD PRIMARY KEY (ID),
	CONSTRAINT FK__CarritoCo__ID_CL__1AD3FDA4 FOREIGN KEY (ID_CLI) REFERENCES b1botiga.dbo.Client(ID)
);


-- b1botiga.dbo.Product definition

-- Drop table

-- DROP TABLE b1botiga.dbo.Product;

CREATE TABLE b1botiga.dbo.Product (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	Code nvarchar(8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Descripcio nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Price decimal(10,2) NULL,
	Descompte decimal(10,2) NULL,
	IdFamilia uniqueidentifier NULL,
	Name varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK__Producte__3214EC27900FDAD7 PRIMARY KEY (ID),
	CONSTRAINT FK__Producte__id_tip__0D7A0286 FOREIGN KEY (IdFamilia) REFERENCES b1botiga.dbo.Familia(ID)
);


-- b1botiga.dbo.RegistrePreus definition

-- Drop table

-- DROP TABLE b1botiga.dbo.RegistrePreus;

CREATE TABLE b1botiga.dbo.RegistrePreus (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	ID_PROD uniqueidentifier NOT NULL,
	Price decimal(10,2) NOT NULL,
	DataRegistre date NULL,
	CONSTRAINT PK_RegistrePreus PRIMARY KEY (ID),
	CONSTRAINT FK_RegistrePreus_Product FOREIGN KEY (ID_PROD) REFERENCES b1botiga.dbo.Product(ID)
);


-- b1botiga.dbo.CarritoProducte definition

-- Drop table

-- DROP TABLE b1botiga.dbo.CarritoProducte;

CREATE TABLE b1botiga.dbo.CarritoProducte (
	ID uniqueidentifier DEFAULT newid() NOT NULL,
	ID_CARR uniqueidentifier NULL,
	ID_PROD uniqueidentifier NULL,
	Quantitat decimal(10,0) NOT NULL,
	Price decimal(38,0) NULL,
	CONSTRAINT PK__CarritoP__3214EC27A77FBC32 PRIMARY KEY (ID),
	CONSTRAINT FK__CarritoPr__ID_CA__114A936A FOREIGN KEY (ID_CARR) REFERENCES b1botiga.dbo.CarritoCompras(ID),
	CONSTRAINT FK__CarritoPr__ID_PR__123EB7A3 FOREIGN KEY (ID_PROD) REFERENCES b1botiga.dbo.Product(ID)
);