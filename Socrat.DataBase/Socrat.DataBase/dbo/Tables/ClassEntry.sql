CREATE TABLE [dbo].[ClassEntry] (
    [Id]              UNIQUEIDENTIFIER CONSTRAINT [DF_ClassEntry_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Alias]           NVARCHAR (256)   NOT NULL,
    [Name]            NVARCHAR (256)   NOT NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_ClassEntry] PRIMARY KEY CLUSTERED ([Id] ASC)
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ClassEntryUnique]
    ON [dbo].[ClassEntry]([Name] ASC);

