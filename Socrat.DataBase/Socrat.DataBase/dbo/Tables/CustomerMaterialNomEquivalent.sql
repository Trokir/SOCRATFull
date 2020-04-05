CREATE TABLE [dbo].[CustomerMaterialNomEquivalent] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CustomerId]      UNIQUEIDENTIFIER NULL,
    [NomCode]         NVARCHAR (50)    NULL,
    [MaterialNomId]   UNIQUEIDENTIFIER NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerMaterialNomEquivalent] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerMaterialNomEquivalent_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CustomerMaterialNomEquivalent_MaterialNom] FOREIGN KEY ([MaterialNomId]) REFERENCES [dbo].[MaterialNom] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerMaterialNomEquivalent_Customer]
    ON [dbo].[CustomerMaterialNomEquivalent]([CustomerId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CustomerMaterialNomEquivalent_MaterialNom]
    ON [dbo].[CustomerMaterialNomEquivalent]([MaterialNomId] ASC);