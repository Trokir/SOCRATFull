CREATE TABLE [dbo].[CoworkerPosition] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Division_Id]     UNIQUEIDENTIFIER NULL,
    [WorkPosition_Id] UNIQUEIDENTIFIER NULL,
    [Coworker_Id]     UNIQUEIDENTIFIER NULL,
    [Default]         BIT              NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CoworkerPosition] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CoworkerPosition_Coworker] FOREIGN KEY ([Coworker_Id]) REFERENCES [dbo].[Coworker] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_CoworkerPosition_Division] FOREIGN KEY ([Division_Id]) REFERENCES [dbo].[Division] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_CoworkerPosition_WorkPosition] FOREIGN KEY ([WorkPosition_Id]) REFERENCES [dbo].[WorkPosition] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_CoworkerPosition_Division]
    ON [dbo].[CoworkerPosition]([Division_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CoworkerPosition_WorkPosition]
    ON [dbo].[CoworkerPosition]([WorkPosition_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CoworkerPosition_Coworker]
    ON [dbo].[CoworkerPosition]([Coworker_Id] ASC);