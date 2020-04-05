CREATE TABLE [dbo].[FrameItemProperties] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [GermDepth]          FLOAT (53)       NULL,
    [Gaz]                BIT              NULL,
    [ShprosNom_Id]       UNIQUEIDENTIFIER NULL,
    [ShprosFixatorId]    UNIQUEIDENTIFIER NULL,
    [ShprosXConnectorId] UNIQUEIDENTIFIER NULL,
    [ShprosTConnectorId] UNIQUEIDENTIFIER NULL,
    [ShprosYConnectorId] UNIQUEIDENTIFIER NULL,
    [RowVersion]         ROWVERSION       NOT NULL,
    [LastChangedUser]    UNIQUEIDENTIFIER NULL,
    [LastChangedDate]    DATETIME         NULL,
    CONSTRAINT [PK_FrameItemProperties] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FrameItemProperties_FormulaItem] FOREIGN KEY ([Id]) REFERENCES [dbo].[FormulaItem] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FrameItemProperties_MaterialNom] FOREIGN KEY ([ShprosNom_Id]) REFERENCES [dbo].[MaterialNom] ([Id]),
    CONSTRAINT [FK_FrameItemPropertiesF_MaterialNom] FOREIGN KEY ([ShprosFixatorId]) REFERENCES [dbo].[MaterialNom] ([Id]),
    CONSTRAINT [FK_FrameItemPropertiesT_MaterialNom] FOREIGN KEY ([ShprosXConnectorId]) REFERENCES [dbo].[MaterialNom] ([Id]),
    CONSTRAINT [FK_FrameItemPropertiesX_MaterialNom] FOREIGN KEY ([ShprosTConnectorId]) REFERENCES [dbo].[MaterialNom] ([Id]),
    CONSTRAINT [FK_FrameItemPropertiesY_MaterialNom] FOREIGN KEY ([ShprosYConnectorId]) REFERENCES [dbo].[MaterialNom] ([Id])
);



GO
CREATE NONCLUSTERED INDEX [IX_FrameItemProperties_MaterialNom]
    ON [dbo].[FrameItemProperties]([ShprosNom_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_FrameItemPropertiesF_MaterialNom]
    ON [dbo].[FrameItemProperties]([ShprosFixatorId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_FrameItemPropertiesX_MaterialNom]
    ON [dbo].[FrameItemProperties]([ShprosXConnectorId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_FrameItemPropertiesT_MaterialNom]
    ON [dbo].[FrameItemProperties]([ShprosTConnectorId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_FrameItemPropertiesY_MaterialNom]
    ON [dbo].[FrameItemProperties]([ShprosYConnectorId] ASC);



