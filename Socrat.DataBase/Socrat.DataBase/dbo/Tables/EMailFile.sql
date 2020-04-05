CREATE TABLE [dbo].[EMailFile] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [FileFullPath]    NVARCHAR (MAX)   NOT NULL,
    [EMail_Id]        UNIQUEIDENTIFIER NOT NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_EMailFile] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EMailFile_EMail] FOREIGN KEY ([EMail_Id]) REFERENCES [dbo].[EMail] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_EMailFile_EMail]
    ON [dbo].[EMailFile]([EMail_Id] ASC);
