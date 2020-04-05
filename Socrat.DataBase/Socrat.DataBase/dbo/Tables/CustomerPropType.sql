CREATE TABLE [dbo].[CustomerPropType] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Alias]           NVARCHAR (20)    NULL,
    [PropName]        NVARCHAR (70)    NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerPropType] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);



