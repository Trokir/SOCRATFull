CREATE TABLE [dbo].[CustomerOrder] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [CustomerName]        NVARCHAR (150)   NULL,
    [OrderCustomerNumber] NVARCHAR (50)    NULL,
    [CustomerAddress]     NVARCHAR (300)   NULL,
    [CustomerDate]        DATETIME         NULL,
    [CustomerOrderId]     NVARCHAR (50)    NULL,
    [OrderFormula]        NVARCHAR (150)   NULL,
    [OrderKoment]         NVARCHAR (200)   NULL,
    [ReceiveTime]         DATETIME         NULL,
    [CustomerOrderNumber] NVARCHAR (50)    NULL,
    [CustomerOrderName]   NVARCHAR (150)   NULL,
    [IsPoolList]          BIT              NULL,
    [CustomerOrderFileId] UNIQUEIDENTIFIER NOT NULL,
    [RowVersion]          ROWVERSION       NOT NULL,
    [LastChangedUser]     UNIQUEIDENTIFIER NULL,
    [LastChangedDate]     DATETIME         NULL,
    CONSTRAINT [PK_CustomerOrder] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerOrder_] FOREIGN KEY ([CustomerOrderFileId]) REFERENCES [dbo].[CustomerOrderFile] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerOrder_CustomerOrderFile]
    ON [dbo].[CustomerOrder]([CustomerOrderFileId] ASC);
