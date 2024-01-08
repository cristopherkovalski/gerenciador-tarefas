CREATE DATABASE IF NOT EXISTS GerenciadorTarefas;

USE GerenciadorTarefas;
CREATE TABLE Endereco (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Numero VARCHAR(255),
    Logradouro VARCHAR(255),
    Cidade VARCHAR(255),
    Estado VARCHAR(255),
    CEP VARCHAR(10)
);

CREATE TABLE Usuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255),
    Sobrenome VARCHAR(255),
    EnderecoId INT,
    CPF VARCHAR(14),
    TipoUsuario ENUM('Desenvolvedor', 'TechLeader'),
    Time VARCHAR(255),
    Situacao VARCHAR(255),
    DataAdmissao DATETIME,
    DataDemissao DATETIME,
    FOREIGN KEY (EnderecoId) REFERENCES Endereco(Id)
);

CREATE TABLE Tarefa (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255),
    Descricao TEXT,
    ResponsavelId INT,
    Status VARCHAR(255),
    DataInicio DATETIME,
    DataFim DATETIME,
    FOREIGN KEY (ResponsavelId) REFERENCES Usuario(Id)
);

CREATE TABLE Login (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Senha VARCHAR(255) NOT NULL,
	TipoUsuario ENUM('Desenvolvedor', 'TechLeader'),
    UsuarioId INT,
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id)
);
