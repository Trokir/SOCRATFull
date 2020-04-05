CREATE TABLE [dbo].[CustomerAddress] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Customer_Id]     UNIQUEIDENTIFIER NULL,
    [Address_Id]      UNIQUEIDENTIFIER NULL,
    [IsProduction]    BIT              NULL,
    [Comment]         NVARCHAR (200)   NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerAddress] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerAddress_Address] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_CustomerAddress_Customer] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerAddress_Address]
    ON [dbo].[CustomerAddress]([Address_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CustomerAddress_Customer]
    ON [dbo].[CustomerAddress]([Customer_Id] ASC);

