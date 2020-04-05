CREATE TABLE [dbo].[Coworker] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [NameFirst]       NVARCHAR (30)    NULL,
    [NameMiddle]      NVARCHAR (30)    NULL,
    [NameLast]        NVARCHAR (30)    NULL,
    [Gender_Id]       UNIQUEIDENTIFIER NULL,
    [Birth]           DATETIME         NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_Coworker] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Coworker_Gender] FOREIGN KEY ([Gender_Id]) REFERENCES [dbo].[Gender] ([Id]) ON DELETE SET NULL
);




