-- Criacao do banco de dados
CREATE DATABASE ProvaParadigma
GO
USE ProvaParadigma
GO

-- Criacao das tabelas
CREATE TABLE Departamento (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Nome VARCHAR(MAX)
)

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

-- Resposta
SELECT Dep.Nome AS Departamento, Pessoa.Nome AS Pessoa, AuxPessoa.Salario FROM Pessoa 
JOIN (SELECT MAX(Salario) Salario, DeptId FROM Pessoa GROUP BY DeptId) AuxPessoa 
ON AuxPessoa.DeptId = Pessoa.DeptId AND Pessoa.Salario = AuxPessoa.Salario
JOIN Departamento Dep ON Dep.Id = Pessoa.DeptId
