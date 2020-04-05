CREATE TABLE [dbo].[AddressElementType] (
    [Id]                    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]                  NVARCHAR (50)    NULL,
    [Code]                  NVARCHAR (10)    NULL,
    [Sort]                  SMALLINT         NULL,
    [AddressElementTypeNum] INT              NULL,
    [RowVersion]            ROWVERSION       NOT NULL,
    [LastChangedUser]       UNIQUEIDENTIFIER NULL,
    [LastChangedDate]       DATETIME         NULL,
    CONSTRAINT [PK_AddressElementType] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);






