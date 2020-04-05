CREATE TABLE [dbo].[CustomerFormulaEquivalent] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CustomerId]      UNIQUEIDENTIFIER NOT NULL,
    [CustomerFormula] NVARCHAR (300)   NULL,
    [FormulaId]       UNIQUEIDENTIFIER NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerFormulaEquivalent] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerFormulaEquivalent_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CustomerFormulaEquivalent_Formula] FOREIGN KEY ([FormulaId]) REFERENCES [dbo].[Formula] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerFormulaEquivalent_Customer]
    ON [dbo].[CustomerFormulaEquivalent]([CustomerId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_CustomerFormulaEquivalent_Formula]
    ON [dbo].[CustomerFormulaEquivalent]([FormulaId] ASC);
