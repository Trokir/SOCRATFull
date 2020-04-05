CREATE TABLE [dbo].[CustomerOrderFile] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CustomerId]      UNIQUEIDENTIFIER NOT NULL,
    [FileName]        NVARCHAR (150)   NULL,
    [FileChangeDate]  DATETIME         NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerOrderFile] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerOrderFile_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerOrderFile_Customer]
    ON [dbo].[CustomerOrderFile]([CustomerId] ASC);