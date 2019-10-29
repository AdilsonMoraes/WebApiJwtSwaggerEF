USE db_WebApiCliente


IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name = 'usuario_login') 
	BEGIN
		CREATE TABLE [dbo].[usuario_login](
			[id] [int] IDENTITY(1,1) NOT NULL,
			[Usuario] [varchar](20) NOT NULL,
			[Senha] [nvarchar](max) NULL,
			[IsAdministrator] [bit] NOT NULL,
			[TokenAuth] [nvarchar](max) NULL,
		 CONSTRAINT [PK_usuario_login] PRIMARY KEY CLUSTERED 
		(
			[id] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]				
	END

	INSERT INTO [usuario_login] (usuario, Senha, IsAdministrator, TokenAuth)
	VALUES ('ADM', 'ADM', 1, 'ADM123')