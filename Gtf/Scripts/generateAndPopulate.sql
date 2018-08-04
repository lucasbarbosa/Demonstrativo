CREATE DATABASE [Stephan] 
GO

USE [Stephan]
GO

/****** Object:  Table [dbo].[Type]    Script Date: 25/07/2018 20:48:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Type](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Period]    Script Date: 25/07/2018 20:48:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Period](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Period] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Meal]    Script Date: 25/07/2018 20:48:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Meal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[TypeId] [int] NOT NULL,
	[PeriodId] [int] NOT NULL,
 CONSTRAINT [PK_Meal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Meal]  WITH CHECK ADD  CONSTRAINT [FK_Meal_Period] FOREIGN KEY([PeriodId])
REFERENCES [dbo].[Period] ([Id])
GO

ALTER TABLE [dbo].[Meal] CHECK CONSTRAINT [FK_Meal_Period]
GO

ALTER TABLE [dbo].[Meal]  WITH CHECK ADD  CONSTRAINT [FK_Meal_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([Id])
GO

ALTER TABLE [dbo].[Meal] CHECK CONSTRAINT [FK_Meal_Type]
GO

insert into [type]
values 
('entrada'),
('acompanhamento'),
('bebida'),
('sobremesa')

insert into period
values
('manhã'),
('noite')

insert into meal
values 
('ovos',1	,1),
('torrada',2	,1),
('café',3	,1),
('carne',1	,2),
('batata',2	,2),
('vinho',3	,2),
('bolo',4	,2),
('erro',4	,1)