CREATE TABLE [dbo].[Formula] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [FormulaStr] NVARCHAR (400)   NULL,
    [RowVersion] ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Formula] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);




