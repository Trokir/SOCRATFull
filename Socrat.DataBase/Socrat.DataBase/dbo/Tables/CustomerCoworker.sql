CREATE TABLE [dbo].[CustomerCoworker] (
    [Id]              UNIQUEIDENTIFIER CONSTRAINT [DF_CustomerCoworker_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [CustomerId]      UNIQUEIDENTIFIER NOT NULL,
    [CoworkerId]      UNIQUEIDENTIFIER NOT NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerCoworker] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerCoworker_Coworker] FOREIGN KEY ([CoworkerId]) REFERENCES [dbo].[Coworker] ([Id]),
    CONSTRAINT [FK_CustomerCoworker_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerCoworker_Coworker]
    ON [dbo].[CustomerCoworker]([CoworkerId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CustomerCoworker_Customer]
    ON [dbo].[CustomerCoworker]([CustomerId] ASC);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CustomerCoworker_Unique]
    ON [dbo].[CustomerCoworker]([CoworkerId] ASC, [CustomerId] ASC);

