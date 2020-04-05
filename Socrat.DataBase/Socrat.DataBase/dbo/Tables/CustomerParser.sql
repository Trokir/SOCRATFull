CREATE TABLE [dbo].[CustomerParser] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CustomerId]      UNIQUEIDENTIFIER NOT NULL,
    [ParserId]        UNIQUEIDENTIFIER NOT NULL,
    [Default]         BIT              NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerParser] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerParser_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_CustomerParser_Parser] FOREIGN KEY ([ParserId]) REFERENCES [dbo].[Parser] ([Id]), 
    CONSTRAINT [AK_CustomerParser] UNIQUE ([CustomerId], [ParserId])
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerParser_Customer]
    ON [dbo].[CustomerParser]([CustomerId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CustomerParser_Parser]
    ON [dbo].[CustomerParser]([ParserId] ASC);
