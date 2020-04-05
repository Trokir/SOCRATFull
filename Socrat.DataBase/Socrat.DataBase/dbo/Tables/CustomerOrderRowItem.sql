CREATE TABLE [dbo].[CustomerOrderRowItem] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [CustomerOrderRowId] UNIQUEIDENTIFIER NOT NULL,
    [Num]                SMALLINT         NULL,
    [RowVersion]         ROWVERSION       NOT NULL,
    [LastChangedUser]    UNIQUEIDENTIFIER NULL,
    [LastChangedDate]    DATETIME         NULL,
    CONSTRAINT [PK_CustomerOrderRowItem] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerOrderRowItem_CustomerOrderRow] FOREIGN KEY ([CustomerOrderRowId]) REFERENCES [dbo].[CustomerOrderRow] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerOrderRowItem_CustomerOrderRow]
    ON [dbo].[CustomerOrderRowItem]([CustomerOrderRowId] ASC);





