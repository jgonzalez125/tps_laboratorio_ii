USE [master]
GO
/****** Object:  User [##MS_PolicyEventProcessingLogin##]    Script Date: 12/6/2021 3:56:21 AM ******/
CREATE USER [##MS_PolicyEventProcessingLogin##] FOR LOGIN [##MS_PolicyEventProcessingLogin##] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [##MS_AgentSigningCertificate##]    Script Date: 12/6/2021 3:56:21 AM ******/
CREATE USER [##MS_AgentSigningCertificate##] FOR LOGIN [##MS_AgentSigningCertificate##]
GO
/****** Object:  Table [dbo].[Entradas]    Script Date: 12/6/2021 3:56:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entradas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[costo] [float] NOT NULL,
	[consumicion] [bit] NOT NULL,
	[festival] [varchar](50) NOT NULL,
	[numeroButaca] [varchar](50) NULL,
	[areaCampo] [varchar](50) NULL,
	[tipo] [int] NOT NULL,
 CONSTRAINT [PK_Entradas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO Entradas (costo, consumicion, festival, numeroButaca, areaCampo, tipo)
VALUES (500, 1, 'LollaPalooza', 'M-19', NULL, 1)
INSERT INTO Entradas (costo, consumicion, festival, numeroButaca, areaCampo, tipo)
VALUES (500, 0, 'LollaPalooza', 'M-21', NULL, 1)
INSERT INTO Entradas (costo, consumicion, festival, numeroButaca, areaCampo, tipo)
VALUES (500, 1, 'LollaPalooza', 'M-32', NULL, 1)
INSERT INTO Entradas (costo, consumicion, festival, numeroButaca, areaCampo, tipo)
VALUES (500, 1, 'LollaPalooza', 'G-4', NULL, 1)
INSERT INTO Entradas (costo, consumicion, festival, numeroButaca, areaCampo, tipo)
VALUES (200, 1, 'LollaPalooza', NULL, 'Frente', 0)
INSERT INTO Entradas (costo, consumicion, festival, numeroButaca, areaCampo, tipo)
VALUES (200, 1, 'LollaPalooza', NULL, 'VIP', 0)
INSERT INTO Entradas (costo, consumicion, festival, numeroButaca, areaCampo, tipo)
VALUES (200, 1, 'LollaPalooza', NULL, 'Lateral', 0)
INSERT INTO Entradas (costo, consumicion, festival, numeroButaca, areaCampo, tipo)
VALUES (200, 1, 'LollaPalooza', NULL, 'Frente', 0)
GO
