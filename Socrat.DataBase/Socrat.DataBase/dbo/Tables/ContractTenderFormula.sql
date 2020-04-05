CREATE TABLE [dbo].[ContractTenderFormula]
(
	[Id] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL, 
    [Contract_Id] UNIQUEIDENTIFIER NULL, 
    [Formula_Id] UNIQUEIDENTIFIER NULL, 
    [Price] FLOAT NULL, 
    [SquReady] FLOAT NULL, 
    [EditDate] DATETIME NULL, 
    [Limit] FLOAT NULL, 
    CONSTRAINT [FK_ContractTenderFormula_Contract] FOREIGN KEY ([Contract_Id]) REFERENCES [Contract]([Id]) ON DELETE SET NULL, 
    CONSTRAINT [PK_ContractTenderFormula] PRIMARY KEY NONCLUSTERED ([Id]), 
    CONSTRAINT [FK_ContractTenderFormula_Formula] FOREIGN KEY ([Formula_Id]) REFERENCES [Formula]([Id]) ON DELETE CASCADE
)
