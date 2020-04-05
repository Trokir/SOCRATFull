CREATE TABLE [dbo].[FormulaItemProcessing] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [FormulaItem_Id]   UNIQUEIDENTIFIER NOT NULL,
    [ProcessingNom_Id] UNIQUEIDENTIFIER NOT NULL,
    [Discriminator]    NVARCHAR (128)   NULL,
    [SelectedSurface]  TINYINT          NULL,
    [SelectedSides]    INT              NULL,
    [Distance1]        FLOAT (53)       NULL,
    [Distance2]        FLOAT (53)       NULL,
    [Distance3]        FLOAT (53)       NULL,
    [Distance4]        FLOAT (53)       NULL,
    [Distance5]        FLOAT (53)       NULL,
    [Distance6]        FLOAT (53)       NULL,
    [Distance7]        FLOAT (53)       NULL,
    [Distance8]        FLOAT (53)       NULL,
    [Sequence]         SMALLINT         NULL,
    [Processing_Id]    UNIQUEIDENTIFIER NULL,
    [RowVersion]       ROWVERSION       NOT NULL,
    CONSTRAINT [PK_FormulaItemProcessing] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FormulaItemProcessing_FormulaItem] FOREIGN KEY ([FormulaItem_Id]) REFERENCES [dbo].[FormulaItem] ([Id]),
    CONSTRAINT [FK_FormulaItemProcessing_ProcessingNom] FOREIGN KEY ([ProcessingNom_Id]) REFERENCES [dbo].[ProcessingNom] ([Id])
);





GO
CREATE NONCLUSTERED INDEX [IX_FormulaItemProcessing_FormulaItem]
    ON [dbo].[FormulaItemProcessing]([FormulaItem_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_FormulaItemProcessing_ProcessingNom]
    ON [dbo].[FormulaItemProcessing]([ProcessingNom_Id] ASC);





