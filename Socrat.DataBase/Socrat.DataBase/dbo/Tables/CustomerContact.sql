CREATE TABLE [dbo].[CustomerContact] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Customer_Id]     UNIQUEIDENTIFIER NULL,
    [ContactType_Id]  UNIQUEIDENTIFIER NULL,
    [Value]           NVARCHAR (100)   NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerContact] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerContact_ContactType] FOREIGN KEY ([ContactType_Id]) REFERENCES [dbo].[ContactType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_CustomerContact_Customer] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerContact_Customer]
    ON [dbo].[CustomerContact]([Customer_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CustomerContact_ContactType]
    ON [dbo].[CustomerContact]([ContactType_Id] ASC);