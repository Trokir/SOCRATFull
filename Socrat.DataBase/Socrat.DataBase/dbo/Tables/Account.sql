CREATE TABLE [dbo].[Account] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Customer_Id]     UNIQUEIDENTIFIER NOT NULL,
    [Alias]           NVARCHAR (100)   NULL,
    [Bank_Id]         UNIQUEIDENTIFIER NOT NULL,
    [RS]              NVARCHAR (20)    NULL,
    [Currency_Id]     UNIQUEIDENTIFIER NULL,
    [Comment]         NVARCHAR (300)   NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Account_Bank] FOREIGN KEY ([Bank_Id]) REFERENCES [dbo].[Bank] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Account_Currency] FOREIGN KEY ([Currency_Id]) REFERENCES [dbo].[Currency] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Account_Customer] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE CASCADE 
);



GO
CREATE NONCLUSTERED INDEX [IX_Account_Bank]
    ON [dbo].[Account]([Bank_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Account_Customer]
    ON [dbo].[Account]([Customer_Id] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Account_Currency]
    ON [dbo].[Account]([Currency_Id] ASC);
GO

CREATE UNIQUE INDEX [IX_Account_Alias] ON [dbo].[Account] ([Alias])
GO

CREATE UNIQUE INDEX [IX_Account_Rs] ON [dbo].[Account] ([Rs])
GO
