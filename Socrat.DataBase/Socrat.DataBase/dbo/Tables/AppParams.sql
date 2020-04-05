CREATE TABLE [dbo].[AppParams] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Category]        NVARCHAR (150)   NULL,
    [Alias]           NVARCHAR (150)   NULL,
    [Name]            NVARCHAR (300)   NULL,
    [Value]           NVARCHAR (400)   NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_AppParams] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [AK_AppParams_Alias] UNIQUE NONCLUSTERED ([Alias] ASC)
);


