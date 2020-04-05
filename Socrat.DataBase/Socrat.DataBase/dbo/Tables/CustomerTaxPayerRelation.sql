CREATE TABLE [dbo].[CustomerTaxPayerRelation] (
    [Id]              UNIQUEIDENTIFIER CONSTRAINT [DF_CustomerTaxPayerRelation_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Customer_Id]     UNIQUEIDENTIFIER NOT NULL,
    [Company_Id]      UNIQUEIDENTIFIER NOT NULL,
    [isDefault]       BIT              CONSTRAINT [DF_CustomerTaxPayerRelation_isDefault] DEFAULT ((0)) NOT NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerTaxPayerRelation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerTotaxPayerRelation_Customer] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_CustomerTotaxPayerRelation_Customer1] FOREIGN KEY ([Company_Id]) REFERENCES [dbo].[Customer] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_CustomerTaxPayerRelation_Customer]
    ON [dbo].[CustomerTaxPayerRelation]([Customer_Id] ASC);

	GO
CREATE NONCLUSTERED INDEX [IX_CustomerTaxPayerRelation_Customer1]
    ON [dbo].[CustomerTaxPayerRelation]([Company_Id] ASC);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CustomerTaxPayerRelation_Unique]
    ON [dbo].[CustomerTaxPayerRelation]([Customer_Id] ASC, [Company_Id] ASC);

