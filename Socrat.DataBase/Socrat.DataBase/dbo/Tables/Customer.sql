CREATE TABLE [dbo].[Customer] (
    [Id]                        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [CustomerType_Id]           UNIQUEIDENTIFIER NULL,
    [OPF_Id]                    UNIQUEIDENTIFIER NULL,
    [NameAlias]                 NVARCHAR (150)   NULL,
    [NameFull]                  NVARCHAR (150)   NULL,
    [NameShort]                 NVARCHAR (30)    NULL,
    [NameForeign]               NVARCHAR (150)   NULL,
    [NameFirst]                 NVARCHAR (30)    NULL,
    [NameMiddle]                NVARCHAR (30)    NULL,
    [NameLast]                  NVARCHAR (30)    NULL,
    [Currency_Id]               UNIQUEIDENTIFIER NULL,
    [Country_Id]                UNIQUEIDENTIFIER NULL,
    [Inn]                       NVARCHAR (12)    NULL,
    [Kpp]                       NVARCHAR (9)     NULL,
    [Ogrn]                      NVARCHAR (15)    NULL,
    [Okpo]                      NVARCHAR (10)    NULL,
    [TaxNumberForeign]          NVARCHAR (90)    NULL,
    [DateReg]                   DATETIME         CONSTRAINT [Customer_DF_DateReg] DEFAULT (getdate()) NULL,
    [Manager_Id]                UNIQUEIDENTIFIER NULL,
    [TypeBarcode_Id]            UNIQUEIDENTIFIER NULL,
    [Code_1C]                   NVARCHAR (20)    NULL,
    [OrderLock]                 BIT              NULL,
    [ProdLoсk]                  BIT              NULL,
    [TaxUsn]                    BIT              NULL,
    [TaxEnvd]                   BIT              NULL,
    [IsOwner]                   BIT              NULL,
    [LegalAddress_Id]           UNIQUEIDENTIFIER NULL,
    [ActualAddress_Id]          UNIQUEIDENTIFIER NULL,
    [InvoiceMeasurementUnit_Id] UNIQUEIDENTIFIER NULL,
    [BarcodeTypeId]             UNIQUEIDENTIFIER NULL,
    [PoolStart]                 INT              DEFAULT ((0)) NULL,
    [RowVersion]                ROWVERSION       NOT NULL,
    [LastChangedUser]           UNIQUEIDENTIFIER NULL,
    [LastChangedDate]           DATETIME         NULL,
    CONSTRAINT [Customer_PK] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BarcodeType] FOREIGN KEY ([BarcodeTypeId]) REFERENCES [dbo].[BarcodeType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Country_Customer] FOREIGN KEY ([Country_Id]) REFERENCES [dbo].[Country] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Customer_Address1] FOREIGN KEY ([LegalAddress_Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Customer_Address2] FOREIGN KEY ([ActualAddress_Id]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_Customer_Currency] FOREIGN KEY ([Currency_Id]) REFERENCES [dbo].[Currency] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Customer_InvoiceMeasurementUnit] FOREIGN KEY ([InvoiceMeasurementUnit_Id]) REFERENCES [dbo].[InvoiceMeasurementUnit] ([Id]),
    CONSTRAINT [FK_CustomerType_Customer] FOREIGN KEY ([CustomerType_Id]) REFERENCES [dbo].[CustomerType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_OPF_Customer] FOREIGN KEY ([OPF_Id]) REFERENCES [dbo].[OPF] ([Id]) ON DELETE SET NULL 
);



GO
CREATE NONCLUSTERED INDEX [IX_Customer_Country]
    ON [dbo].[Customer]([Country_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Customer_Address1]
    ON [dbo].[Customer]([LegalAddress_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Customer_Address2]
    ON [dbo].[Customer]([ActualAddress_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Customer_Currency]
    ON [dbo].[Customer]([Currency_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Customer_InvoiceMeasurementUnit]
    ON [dbo].[Customer]([InvoiceMeasurementUnit_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Customer_CustomerType]
    ON [dbo].[Customer]([CustomerType_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Customer_OPF]
    ON [dbo].[Customer]([OPF_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Customer_BarcodeType]
    ON [dbo].[Customer]([BarcodeTypeId] ASC);




GO


CREATE UNIQUE INDEX [IX_Customer_Inn] ON [dbo].[Customer] ([Inn]) Where [Inn] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_Customer_Kpp] ON [dbo].[Customer] ([Kpp]) Where [Kpp] IS NOT NULL;
GO
