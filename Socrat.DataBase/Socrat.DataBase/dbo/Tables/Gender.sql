CREATE TABLE [dbo].[Gender] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]            NVARCHAR (30)    NOT NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [Gender_PK] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);



