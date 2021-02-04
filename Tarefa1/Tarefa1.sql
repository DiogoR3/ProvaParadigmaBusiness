-- Criacao do banco de dados
CREATE DATABASE ProvaParadigma
GO
USE ProvaParadigma
GO

CREATE TABLE Departamento (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Nome VARCHAR(MAX)
)

-- Criacao das tabelas
CREATE TABLE Pessoa (
	Id INT IDENTITY(1,1),
	Nome VARCHAR(MAX),
	Salario FLOAT,
	DeptId INT NOT NULL FOREIGN KEY REFERENCES Departamento(Id)
)

-- Inserindo dados de exemplo
INSERT INTO Departamento VALUES ('TI')
INSERT INTO Departamento VALUES ('Vendas')

INSERT INTO Pessoa VALUES ('Joe', '7000', 1)
INSERT INTO Pessoa VALUES ('Henry', '8000', 2)
INSERT INTO Pessoa VALUES ('Sam', '6000', 2)
INSERT INTO Pessoa VALUES ('Max', '9000', 1)

-- Select com join
SELECT Dep.Nome AS Departamento, Pes.Nome AS Pessoa, Pes.Salario FROM Pessoa Pes
JOIN Departamento Dep ON Dep.Id = Pes.DeptId

-- Select sem join
SELECT Dep.Nome AS Departamento, Pes.Nome AS Pessoa, Pes.Salario FROM Pessoa Pes, Departamento Dep
WHERE Pes.DeptId = Dep.Id
