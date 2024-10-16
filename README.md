Teste Para DesafioTJ

Sistema desenvolvido com as praticas do Clean Arquiteture com as Camadas 1 - API(EndPoints) 2 - Application(Contato do externo com Interno, criando assim segurança) 3 - Domain(Core do projeto, bem como dominio e base para repositorios) 4 - Domain.Test( Implementacao de XUnit para cobertura de codigo e teste unitarios) 5 - Infra.Data (Camada de acesso ao banco de dados) 6 - Infra.Data.IoC( Injeção de dependencia) 7 - WebUI (Camada Front-end)

banco de dados criado uma tabela foi gerado com a connection string na qual deve ser mduada e direcionada com o banco local (O mesmo fica localizado na Camada 6 (Infra.Data.Ioc)

Foram feitas os testes unitarios para os metodos selecionados. A cobertura está tanto para Controller quanto para a camada Application e Repository

SEGUE SCRIPT DE BANCO DE DADOS :


USE [DESAFIOTJ]
GO

/****** Object:  Table [dbo].[Assunto]    Script Date: 16/10/2024 09:38:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Assunto](
	[CodAs] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodAs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Autor](
	[CodAu] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodAu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Livro](
	[Codl] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](40) NOT NULL,
	[Editora] [varchar](40) NOT NULL,
	[Edicao] [int] NOT NULL,
	[AnoPublicacao] [varchar](4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Livro_Assunto](
	[Livro_Codl] [int] NOT NULL,
	[Assunto_codAs] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Livro_Assunto]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Assunto_Assunto] FOREIGN KEY([Livro_Codl])
REFERENCES [dbo].[Assunto] ([CodAs])
GO

ALTER TABLE [dbo].[Livro_Assunto] CHECK CONSTRAINT [FK_Livro_Assunto_Assunto]
GO

ALTER TABLE [dbo].[Livro_Assunto]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Assunto_Livro] FOREIGN KEY([Livro_Codl])
REFERENCES [dbo].[Livro] ([Codl])
GO

ALTER TABLE [dbo].[Livro_Assunto] CHECK CONSTRAINT [FK_Livro_Assunto_Livro]
GO

CREATE TABLE [dbo].[Livro_Autor](
	[Livro_Codl] [int] NOT NULL,
	[Autor_CodAu] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Livro_Autor]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Autor_Autor] FOREIGN KEY([Autor_CodAu])
REFERENCES [dbo].[Autor] ([CodAu])
GO

ALTER TABLE [dbo].[Livro_Autor] CHECK CONSTRAINT [FK_Livro_Autor_Autor]
GO

ALTER TABLE [dbo].[Livro_Autor]  WITH CHECK ADD  CONSTRAINT [FK_Livro_Autor_Livro] FOREIGN KEY([Livro_Codl])
REFERENCES [dbo].[Livro] ([Codl])
GO

ALTER TABLE [dbo].[Livro_Autor] CHECK CONSTRAINT [FK_Livro_Autor_Livro]
GO
