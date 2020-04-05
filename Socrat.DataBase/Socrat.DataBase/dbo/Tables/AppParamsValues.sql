CREATE TABLE [dbo].[AppParamsValues] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [AppParams_Id]    UNIQUEIDENTIFIER NOT NULL,
    [Division_Id]     UNIQUEIDENTIFIER NOT NULL,
    [Value]           NVARCHAR (400)   NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_AppParamsValues] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AppParamsValues_AppParams] FOREIGN KEY ([AppParams_Id]) REFERENCES [dbo].[AppParams] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AppParamsValues_Division] FOREIGN KEY ([Division_Id]) REFERENCES [dbo].[Division] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [AK_AppParamsValues_AppParamsId_DivisionId] UNIQUE NONCLUSTERED ([AppParams_Id] ASC, [Division_Id] ASC)
);



GO
CREATE NONCLUSTERED INDEX [IX_AppParamsValues_AppParams]
    ON [dbo].[AppParamsValues]([AppParams_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_AppParamsValues_Division]
    ON [dbo].[AppParamsValues]([Division_Id] ASC);