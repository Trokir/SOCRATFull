CREATE TABLE [dbo].[ContractType] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]            NVARCHAR (100)   NULL,
    [ContractTypeNum] INT              NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_ContractType] PRIMARY KEY NONCLUSTERED ([Id] ASC), 
    CONSTRAINT [AK_ContractType_Name] UNIQUE ([Name])
);




