USE [GestorInventarios]
GO
/****** Object:  Table [dbo].[Elemento]    Script Date: 02/07/2019 0:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elemento](
	[ElementoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[FechaCaducidad] [datetime] NOT NULL,
	[TipoElementoID] [int] NOT NULL,
	[Disponible] [bit] NOT NULL,
 CONSTRAINT [PK_Elemento] PRIMARY KEY CLUSTERED 
(
	[ElementoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoElemento]    Script Date: 02/07/2019 0:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoElemento](
	[TipoElementoID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
 CONSTRAINT [PK_TipoElemento] PRIMARY KEY CLUSTERED 
(
	[TipoElementoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 02/07/2019 0:15:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[NombreAcceso] [varchar](100) NOT NULL,
	[Clave] [varchar](256) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Elemento] ON 
GO
INSERT [dbo].[Elemento] ([ElementoID], [Nombre], [FechaCaducidad], [TipoElementoID], [Disponible]) VALUES (1, N'Elemento tránsito', CAST(N'2019-07-05T00:00:00.000' AS DateTime), 1, 1)
GO
INSERT [dbo].[Elemento] ([ElementoID], [Nombre], [FechaCaducidad], [TipoElementoID], [Disponible]) VALUES (2, N'Elemento operativo', CAST(N'2019-07-07T00:00:00.000' AS DateTime), 2, 1)
GO
INSERT [dbo].[Elemento] ([ElementoID], [Nombre], [FechaCaducidad], [TipoElementoID], [Disponible]) VALUES (3, N'Elemento seguridad', CAST(N'2019-07-20T00:00:00.000' AS DateTime), 3, 0)
GO
SET IDENTITY_INSERT [dbo].[Elemento] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoElemento] ON 
GO
INSERT [dbo].[TipoElemento] ([TipoElementoID], [Descripcion]) VALUES (1, N'Tránsito')
GO
INSERT [dbo].[TipoElemento] ([TipoElementoID], [Descripcion]) VALUES (2, N'Operativo')
GO
INSERT [dbo].[TipoElemento] ([TipoElementoID], [Descripcion]) VALUES (3, N'Seguridad')
GO
SET IDENTITY_INSERT [dbo].[TipoElemento] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([UsuarioID], [NombreAcceso], [Clave]) VALUES (1, N'admin', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Elemento] ADD  CONSTRAINT [DF_Elemento_Disponible]  DEFAULT ((1)) FOR [Disponible]
GO
ALTER TABLE [dbo].[Elemento]  WITH CHECK ADD  CONSTRAINT [FK_Elemento_TipoElemento] FOREIGN KEY([TipoElementoID])
REFERENCES [dbo].[TipoElemento] ([TipoElementoID])
GO
ALTER TABLE [dbo].[Elemento] CHECK CONSTRAINT [FK_Elemento_TipoElemento]
GO
