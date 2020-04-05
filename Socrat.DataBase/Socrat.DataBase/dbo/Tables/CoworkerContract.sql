CREATE TABLE [dbo].[CoworkerContact] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Coworker_Id]     UNIQUEIDENTIFIER NULL,
    [ContactType_Id]  UNIQUEIDENTIFIER NULL,
    [Value]           NVARCHAR (50)    NULL,
    [TimeRange_Id]    UNIQUEIDENTIFIER NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CoworkerContact] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CoworkerContact_ContactType] FOREIGN KEY ([ContactType_Id]) REFERENCES [dbo].[ContactType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_CoworkerContact_Coworker] FOREIGN KEY ([Coworker_Id]) REFERENCES [dbo].[Coworker] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_CoworkerContact_TimeRange] FOREIGN KEY ([TimeRange_Id]) REFERENCES [dbo].[TimeRange] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_CoworkerContact_Coworker]
    ON [dbo].[CoworkerContact]([Coworker_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CoworkerContact_ContactType]
    ON [dbo].[CoworkerContact]([ContactType_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CoworkerContact_TimeRange]
    ON [dbo].[CoworkerContact]([TimeRange_Id] ASC);