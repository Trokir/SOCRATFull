CREATE TABLE [dbo].[Contract] (
    [Id]                      UNIQUEIDENTIFIER CONSTRAINT [DF__Contract__Id__3FD07829] DEFAULT (newid()) NOT NULL,
    [Num]                     BIGINT           NULL,
    [ContractType_Id]         UNIQUEIDENTIFIER NULL,
    [Division_Id]             UNIQUEIDENTIFIER NULL,
    [Customer_Id]             UNIQUEIDENTIFIER NULL,
    [Coworker_Id]             UNIQUEIDENTIFIER NULL,
    [DateBegin]               DATETIME         NULL,
    [DateEnd]                 DATETIME         NULL,
    [Comment]                 NVARCHAR (100)   NULL,
    [Confirmed]               BIT              NULL,
    [PaymentType_Id]          UNIQUEIDENTIFIER NULL,
    [PaymentBeforeDay]        SMALLINT         NULL,
    [PaymentBeforePercent]    FLOAT (53)       NULL,
    [PaymentBeforeAmount]     INT              NULL,
    [PaymentReadyPercent]     FLOAT (53)       NULL,
    [PaymentReadyAmount]      INT              NULL,
    [PaymentAfterDay]         SMALLINT         NULL,
    [PaymentCreditLimit]      INT              NULL,
    [BillValidityPeriod]      SMALLINT         NULL,
    [PriceChangeDayInfo]      SMALLINT         NULL,
    [PriceChangeDate]         DATETIME         NULL,
    [EditorPrice]             NVARCHAR (31)    NULL,
    [EditorShippingPrice]     NVARCHAR (31)    NULL,
    [ShippingPriceChangeDate] DATETIME         NULL,
    [Spec]                    BIT              NULL,
    [DaysForProduct]          TINYINT          NULL,
    [DateTransferTime]        TIME (7)         NULL,
    [Default]                 BIT              NULL,
    [Price_Id]                UNIQUEIDENTIFIER NULL,
    [TenderId]                UNIQUEIDENTIFIER NULL,
    [RowVersion]              ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Contract] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contract_ContractType] FOREIGN KEY ([ContractType_Id]) REFERENCES [dbo].[ContractType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Contract_Coworker] FOREIGN KEY ([Coworker_Id]) REFERENCES [dbo].[Coworker] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Contract_Customer] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Contract_Division] FOREIGN KEY ([Division_Id]) REFERENCES [dbo].[Division] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Contract_PaymentType] FOREIGN KEY ([PaymentType_Id]) REFERENCES [dbo].[PaymentType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Contract_Price] FOREIGN KEY ([Price_Id]) REFERENCES [dbo].[Price] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Contract_Tender] FOREIGN KEY ([TenderId]) REFERENCES [dbo].[Tender] ([Id])
);







GO
CREATE NONCLUSTERED INDEX [IX_Contract_ContractType]
    ON [dbo].[Contract]([ContractType_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Contract_Coworker]
    ON [dbo].[Contract]([Coworker_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Contract_Customer]
    ON [dbo].[Contract]([Customer_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Contract_Division]
    ON [dbo].[Contract]([Division_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Contract_PaymentType]
    ON [dbo].[Contract]([PaymentType_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Contract_Price]
    ON [dbo].[Contract]([Price_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Contract_Tender]
    ON [dbo].[Contract]([TenderId] ASC);





