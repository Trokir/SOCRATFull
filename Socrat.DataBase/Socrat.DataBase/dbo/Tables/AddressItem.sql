CREATE TABLE [dbo].[AddressItem] (
    [Id]                UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Address_Id]        UNIQUEIDENTIFIER NULL,
    [AddressElement_Id] UNIQUEIDENTIFIER NULL,
    [Value]             NVARCHAR (100)   NULL,
    [RowVersion]        ROWVERSION       NOT NULL,
    [LastChangedUser]   UNIQUEIDENTIFIER NULL,
    [LastChangedDate]   DATETIME         NULL,
    CONSTRAINT [PK_AddressItem] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AddressItem_Address] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_AddressItem_AddressElement] FOREIGN KEY ([AddressElement_Id]) REFERENCES [dbo].[AddressElement] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_AddressItem_AddressElement]
    ON [dbo].[AddressItem]([AddressElement_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_AddressItem_Address]
    ON [dbo].[AddressItem]([Address_Id] ASC);
