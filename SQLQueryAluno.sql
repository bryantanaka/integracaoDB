USE [Sabado]

/****** Object:  Table [dbo].[Aluno]    Script Date: 29/10/2021 08:20:13 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Aluno](
	[codAluno] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[dataNascimento] [date] NULL,
	[sobrenome] [varchar](50) NULL,
	[nomeCompleto]  AS (concat([nome],' ',[sobrenome])),
	[idade]  AS (datediff(year,[dataNascimento],getdate())),
PRIMARY KEY CLUSTERED 
(
	[codAluno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[Telefone]    Script Date: 29/10/2021 08:20:13 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Telefone](
	[codTelefone] [int] IDENTITY(1,1) NOT NULL,
	[codAluno] [int] NULL,
	[tipo] [varchar](32) NULL,
	[telefone] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[codTelefone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Aluno] ON 

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (1, N'Mark', CAST(N'1990-03-03' AS Date), N'Joselli')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (2, N'Mark', CAST(N'1981-06-20' AS Date), N'Joselli')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (3, N'Shadow', CAST(N'2001-03-22' AS Date), N'Moon')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (4, N'John', CAST(N'2000-04-01' AS Date), N'Snow')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (6, N'Bilbo', CAST(N'1820-06-21' AS Date), N'Bolseiro')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (7, N'Bob', CAST(N'2013-03-21' AS Date), N'Esponja')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (8, N'Jota', CAST(N'1978-12-02' AS Date), NULL)

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (9, N'Bilbo', CAST(N'1820-06-21' AS Date), NULL)

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (10, N'Lula', CAST(N'2001-03-22' AS Date), N'Molusco')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (11, N'Patrick', CAST(N'2000-04-01' AS Date), N'Estrela')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (12, N'Tony', CAST(N'3200-05-03' AS Date), N'Stark')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (13, N'Irmão', CAST(N'1820-06-21' AS Date), N'Jorel')

INSERT [dbo].[Aluno] ([codAluno], [nome], [dataNascimento], [sobrenome]) VALUES (14, N'Rocky', CAST(N'2013-03-21' AS Date), N'Balboa')

SET IDENTITY_INSERT [dbo].[Aluno] OFF

SET IDENTITY_INSERT [dbo].[Telefone] ON 

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (1, 1, N'celular', N'41444444')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (2, 1, N'casa', N'31999999')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (15, 2, N'celular', N'33333')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (16, 3, N'celular', N'4444')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (17, 2, N'trabalho', N'4444')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (18, 6, N'casa', N'5555')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (19, 7, N'trabalho', N'77777')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (20, 8, N'celular', N'8888')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (21, 9, N'casa', N'999')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (22, 10, N'vizinho', N'1010')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (23, 12, N'amante', N'111111')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (24, 13, N'irmão', N'111111')

INSERT [dbo].[Telefone] ([codTelefone], [codAluno], [tipo], [telefone]) VALUES (25, 14, N'treinador', N'111111')

SET IDENTITY_INSERT [dbo].[Telefone] OFF

ALTER TABLE [dbo].[Telefone]  WITH CHECK ADD  CONSTRAINT [fk_aluno] FOREIGN KEY([codAluno])
REFERENCES [dbo].[Aluno] ([codAluno])

ALTER TABLE [dbo].[Telefone] CHECK CONSTRAINT [fk_aluno]



SELECT * from Aluno;
SELECT * from Telefone;