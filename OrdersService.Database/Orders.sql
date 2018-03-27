CREATE TABLE [dbo].[Orders] 
(
	[Id]				BIGINT				IDENTITY (1, 1) NOT NULL,
	[CreationTimestamp]	DATETIMEOFFSET		CONSTRAINT [DF_Orders_CreationTimestamp] DEFAULT (GETUTCDATE()) NOT NULL,
	[Version]			ROWVERSION			NOT NULL,

	[DisplayId]			VARCHAR(50)			NOT NULL,
	[Price]				MONEY				NOT NULL,
	[CustomerName]		NVARCHAR (MAX)		NOT NULL,
	[Address]			NVARCHAR (MAX)		NULL,

    CONSTRAINT [PK_dbo.Application] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE NONCLUSTERED INDEX [IX_DisplayId] ON [dbo].[Orders]([DisplayId] ASC);
GO
