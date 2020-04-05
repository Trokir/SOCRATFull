CREATE TABLE [dbo].[BarcodeType] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Code]            NVARCHAR (50)    NULL,
    [Description]     NVARCHAR (200)   NULL,
    [Enumerator]      INT              DEFAULT ((0)) NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_BarcodeType] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);




