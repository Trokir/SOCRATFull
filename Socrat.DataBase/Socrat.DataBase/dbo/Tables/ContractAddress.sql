CREATE TABLE [dbo].[ContractAddress] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Contract_Id]     UNIQUEIDENTIFIER NULL,
    [Address_Id]      UNIQUEIDENTIFIER NULL,
    [District]        NVARCHAR (16)    NULL,
    [DistanceMark]    NVARCHAR (16)    NULL,
    [DistanceLength]  INT              NULL,
    [Comment]         NVARCHAR (100)   NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_ContractAddress] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContractAddress_Address] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_ContractAddress_Contract] FOREIGN KEY ([Contract_Id]) REFERENCES [dbo].[Contract] ([Id])
);



GO
CREATE NONCLUSTERED INDEX [IX_ContractAddress_Contract]
    ON [dbo].[ContractAddress]([Contract_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_ContractAddress_Address]
    ON [dbo].[ContractAddress]([Address_Id] ASC);