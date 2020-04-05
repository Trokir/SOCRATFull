CREATE TABLE [dbo].[Currency] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Alias]           NVARCHAR (20)    NULL,
    [Comment]         NVARCHAR (50)    NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_Currency] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);



