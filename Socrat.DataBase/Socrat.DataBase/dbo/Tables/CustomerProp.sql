CREATE TABLE [dbo].[CustomerProp] (
    [Id]                  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Customer_Id]         UNIQUEIDENTIFIER NULL,
    [CustomerPropType_Id] UNIQUEIDENTIFIER NULL,
    [Value]               BINARY (1024)    NULL,
    [RowVersion]          ROWVERSION       NOT NULL,
    [LastChangedUser]     UNIQUEIDENTIFIER NULL,
    [LastChangedDate]     DATETIME         NULL,
    CONSTRAINT [PK_CustomerProp] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_CustomerProp] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_CustomerPropType_CustometProp] FOREIGN KEY ([CustomerPropType_Id]) REFERENCES [dbo].[CustomerPropType] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerProp_CustomerPropType]
    ON [dbo].[CustomerProp]([CustomerPropType_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CustomerProp_Customer]
    ON [dbo].[CustomerProp]([Customer_Id] ASC);


