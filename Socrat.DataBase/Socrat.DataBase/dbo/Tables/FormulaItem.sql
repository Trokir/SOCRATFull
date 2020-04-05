CREATE TABLE [dbo].[FormulaItem] (
    [Id]                UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Formula_Id]        UNIQUEIDENTIFIER NULL,
    [MaterialNom_Id]    UNIQUEIDENTIFIER NULL,
    [ParMaterialNom_Id] UNIQUEIDENTIFIER NULL,
    [Position]          SMALLINT         NULL,
    [ParentItem_Id]     UNIQUEIDENTIFIER NULL,
    [ItemStr]           NVARCHAR (200)   NULL,
    [Discriminator]     NVARCHAR (128)   NULL,
    [Tolling]           BIT              NULL,
    [MaterialEnum]      INT              DEFAULT ((0)) NOT NULL,
    [RowVersion]        ROWVERSION       NOT NULL,
    CONSTRAINT [PK_FormulaItem] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FormulaItem_Formula] FOREIGN KEY ([Formula_Id]) REFERENCES [dbo].[Formula] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FormulaItem_FormulaItem] FOREIGN KEY ([ParentItem_Id]) REFERENCES [dbo].[FormulaItem] ([Id]),
    CONSTRAINT [FK_FormulaItem_MaterialNom] FOREIGN KEY ([MaterialNom_Id]) REFERENCES [dbo].[MaterialNom] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FormulaItem_ParMaterialNom] FOREIGN KEY ([ParMaterialNom_Id]) REFERENCES [dbo].[MaterialNom] ([Id])
);





GO
CREATE NONCLUSTERED INDEX [IX_FormulaItem_Formula]
    ON [dbo].[FormulaItem]([Formula_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_FormulaItem_FormulaItem]
    ON [dbo].[FormulaItem]([ParentItem_Id] ASC);
GO

GO
CREATE NONCLUSTERED INDEX [IX_FormulaItem_MaterialNom]
    ON [dbo].[FormulaItem]([MaterialNom_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_FormulaItem_ParMaterialNom]
    ON [dbo].[FormulaItem]([ParMaterialNom_Id] ASC);












