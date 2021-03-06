/**  Script estrutural  **/

IF db_id('Misterio') is NULL 
BEGIN
CREATE DATABASE Misterio
 COLLATE Latin1_General_CI_AI;
END
GO

use Misterio;


CREATE TABLE [Criminosos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CriminosoID] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Armas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ArmaID] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Locais](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
 CONSTRAINT [PK_LocalID] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE Criminosos ADD CONSTRAINT Unq_CriminosoNome UNIQUE(Nome);
ALTER TABLE Armas ADD CONSTRAINT Unq_ArmaNome UNIQUE(Nome);
ALTER TABLE Locais ADD CONSTRAINT Unq_LocalNome UNIQUE(Nome);