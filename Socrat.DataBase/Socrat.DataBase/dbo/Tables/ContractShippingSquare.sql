CREATE TABLE [dbo].[ContractShippingSquare] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Contract_Id]     UNIQUEIDENTIFIER NULL,
    [SquAmount]       FLOAT (53)       NULL,
    [PriceSqu]        FLOAT (53)       NULL,
    [EditDate]        DATETIME         NULL,
    [User_Id]         UNIQUEIDENTIFIER NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_ContractShippingSquare] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContractShippingSquare_Contract] FOREIGN KEY ([Contract_Id]) REFERENCES [dbo].[Contract] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ContractShippingSquare_User] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_ContractShippingSquare_Contract]
    ON [dbo].[ContractShippingSquare]([Contract_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_ContractShippingSquare_User]
    ON [dbo].[ContractShippingSquare]([User_Id] ASC);