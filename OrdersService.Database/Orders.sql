CREATE TABLE [dbo].[Orders] 
(
    [Id]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreationTimestamp] DATETIMEOFFSET CONSTRAINT [DF_Orders_CreationTimestamp] DEFAULT (GETUTCDATE()) NOT NULL,
    [Version]           ROWVERSION     NOT NULL,
    [OrderId]           VARCHAR(50)    NOT NULL,
    [Price]             MONEY          NOT NULL,
    [CustomerName]      NVARCHAR (260) NOT NULL,
    [PostCode]          VARCHAR (32)   NOT NULL,
    [Number]            INT            NOT NULL,
    [Street]            NVARCHAR (100) NOT NULL,
    [City]              NVARCHAR (100) NOT NULL,
    [Country]           NVARCHAR (100) NOT NULL,
    [Phone]             VARCHAR  (15)  NULL,

    CONSTRAINT [PK_dbo.Application] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[Orders]([OrderId] ASC);
GO
