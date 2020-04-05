CREATE TABLE [dbo].[BuiltInReport] (
    [Id]              UNIQUEIDENTIFIER CONSTRAINT [DF_BuiltInReport_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Alias]           NVARCHAR (256)   NOT NULL,
    [Name]            NVARCHAR (256)   NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_BuiltInReport] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BuiltInReportUnique]
    ON [dbo].[BuiltInReport]([Name] ASC);

