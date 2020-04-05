CREATE TABLE [dbo].[AddressElement] (
    [Id]                    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [AddressElementType_Id] UNIQUEIDENTIFIER NULL,
    [Name]                  NVARCHAR (50)    NULL,
    [NameShort]             NVARCHAR (20)    NULL,
    [Code]                  NVARCHAR (10)    NULL,
    [RowVersion]            ROWVERSION       NOT NULL,
    [LastChangedUser]       UNIQUEIDENTIFIER NULL,
    [LastChangedDate]       DATETIME         NULL,
    CONSTRAINT [PK_AddressElement] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AddressElement_AddressElementType] FOREIGN KEY ([AddressElementType_Id]) REFERENCES [dbo].[AddressElementType] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_AddressElement_AddressElementType]
    ON [dbo].[AddressElement]([AddressElementType_Id] ASC);


