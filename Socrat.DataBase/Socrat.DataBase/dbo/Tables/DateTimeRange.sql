CREATE TABLE [dbo].[DateTimeRange] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]            NVARCHAR (100)   NULL,
    [Start]           DATETIME         NULL,
    [Finish]          DATETIME         NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_DateTimeRange] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);



