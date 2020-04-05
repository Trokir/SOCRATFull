CREATE TABLE [dbo].[Country] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [NameAlias]       NVARCHAR (20)    NULL,
    [NameShort]       NVARCHAR (30)    NULL,
    [NameFull]        NVARCHAR (150)   NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY NONCLUSTERED ([Id] ASC) 
);


GO

CREATE UNIQUE INDEX [IX_Country_NameAlias] ON [dbo].[Country] ([NameAlias]) WHERE [NameAlias] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_Country_NameShort] ON [dbo].[Country] ([NameShort]) WHERE [NameShort] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_Country_NameFull] ON [dbo].[Country] ([NameFull]) WHERE [NameFull] IS NOT NULL;
GO
