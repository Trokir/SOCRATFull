CREATE TABLE [dbo].[DivisionContact] (
    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_DivisionContact_Id] DEFAULT (newid()) NOT NULL,
    [Division_Id]       UNIQUEIDENTIFIER NULL,
    [DepartmentType_Id] UNIQUEIDENTIFIER NULL,
    [ContactType_Id]    UNIQUEIDENTIFIER NULL,
    [Value]             NVARCHAR (50)    NULL,
    [RowVersion]        ROWVERSION       NOT NULL,
    [LastChangedUser]   UNIQUEIDENTIFIER NULL,
    [LastChangedDate]   DATETIME         NULL,
    CONSTRAINT [PK_DivisionContact] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DivisionContact_ContactType] FOREIGN KEY ([ContactType_Id]) REFERENCES [dbo].[ContactType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_DivisionContact_DepartmentType] FOREIGN KEY ([DepartmentType_Id]) REFERENCES [dbo].[DepartmentType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_DivisionContact_Division] FOREIGN KEY ([Division_Id]) REFERENCES [dbo].[Division] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_DivisionContact_ContactType]
    ON [dbo].[DivisionContact]([ContactType_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_DivisionContact_DepartmentType]
    ON [dbo].[DivisionContact]([DepartmentType_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_DivisionContact_Division]
    ON [dbo].[DivisionContact]([Division_Id] ASC);


