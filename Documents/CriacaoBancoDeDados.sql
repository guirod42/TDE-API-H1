DROP TABLE Usuario
GO
DROP TABLE Categoria
GO
DROP TABLE Fornecedor
GO
DROP TABLE Produto
GO

CREATE TABLE dbo.Categoria (
	Id INT NOT NULL IDENTITY,
	Ativo BIT DEFAULT 1,
	Nome VARCHAR(200) NOT NULL,
	CriadoPor VARCHAR(50) DEFAULT USER_NAME(),
	CriadoEm DATETIME DEFAULT GETDATE(),	
	AtualizadoPor VARCHAR(50) DEFAULT USER_NAME(),
	AtualizadoEm DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE dbo.Fornecedor (
	Id INT NOT NULL IDENTITY,
	Ativo BIT DEFAULT 1,
	Nome VARCHAR(200) NOT NULL,
	TipoFornecedor INT NOT NULL,
	Documento VARCHAR(30) NOT NULL,
	Imagem VARCHAR(500) NOT NULL,
	CriadoPor VARCHAR(50),
	CriadoEm DATETIME,
	AtualizadoPor VARCHAR(50),
	AtualizadoEm DATETIME
);
GO

CREATE TABLE dbo.Produto (
	Id INT NOT NULL IDENTITY,	
	Ativo BIT DEFAULT 1,
	Nome VARCHAR(200) NOT NULL,
	Preco MONEY NOT NULL,
	Estoque INT NOT NULL,
	Imagem VARCHAR(500) NOT NULL,
	CriadoPor VARCHAR(50),
	CriadoEm DATETIME,
	AtualizadoPor VARCHAR(50),
	AtualizadoEm DATETIME
);
GO

CREATE TABLE dbo.Usuario (
	Id INT NOT NULL IDENTITY,
	Ativo BIT DEFAULT 1,
	UserName VARCHAR(50) UNIQUE NOT NULL,
	Password VARCHAR(200) NOT NULL,
	CriadoPor VARCHAR(50),
	CriadoEm DATETIME,
	AtualizadoPor VARCHAR(50),
	AtualizadoEm DATETIME
);

ALTER TABLE Fornecedor
ADD CONSTRAINT PK_Fornecedor
PRIMARY KEY (Id)
GO

ALTER TABLE Produto
ADD CONSTRAINT PK_Produto
PRIMARY KEY (Id)
GO

ALTER TABLE Categoria
ADD CONSTRAINT PK_Categoria
PRIMARY KEY (Id)
GO

ALTER TABLE Usuario
ADD CONSTRAINT PK_Usuario
PRIMARY KEY (Id)
GO

INSERT dbo.Categoria(Nome) VALUES ('Tênis')
,('Bola')
,('Barraca')
GO

INSERT dbo.Fornecedor(Nome, TipoFornecedor, Documento, Imagem) VALUES
 ('Marina e Carolina Esportes Ltda',1,'58.446.853/0001-31','www.forn.com.br')
,('Igor e Guilherme Camping ME',1,'27.525.601/0001-74','www.forn.com.br')
GO

INSERT dbo.Produto (Nome, Preco, Estoque, Imagem) VALUES
('Bola Copa do Mundo 2022',249.99,200,'www.prod.com.br')
,('Raquete de Tênis',99.99,30,'www.prod.com.br')
,('Bola Tênis',4.99,120,'www.prod.com.br')
,('Barraca Camping 4 pessoas',249.99,35,'www.prod.com.br')
,('Barraca Casal',149.99,65,'www.prod.com.br')
GO

INSERT dbo.Usuario(UserName, Password) VALUES ('guilherme','123456'), ('humberto','123456789')
GO

SELECT * FROM Produto
SELECT * FROM Fornecedor
SELECT * FROM Categoria
SELECT * FROM Usuario