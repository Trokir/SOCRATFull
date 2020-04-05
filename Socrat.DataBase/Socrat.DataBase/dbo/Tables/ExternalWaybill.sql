CREATE TABLE [dbo].[ExternalWaybill] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [WaybillId]         UNIQUEIDENTIFIER NOT NULL,
    [SellerId]          UNIQUEIDENTIFIER NOT NULL,
    [ConsigneeId]       UNIQUEIDENTIFIER NOT NULL,
    [BuyerId]           UNIQUEIDENTIFIER NOT NULL,
    [ConsignorId]       UNIQUEIDENTIFIER NOT NULL,
    [DeliveryAddressId] UNIQUEIDENTIFIER NULL,
    [DriverId]          UNIQUEIDENTIFIER NULL,
    [VehicleId]         UNIQUEIDENTIFIER NULL,
    [RowVersion]        ROWVERSION       NOT NULL,
    CONSTRAINT [PK_ExternalWaybill] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ExternalWaybill_Buyer] FOREIGN KEY ([BuyerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_ExternalWaybill_Consignee] FOREIGN KEY ([ConsigneeId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_ExternalWaybill_Consignor] FOREIGN KEY ([ConsignorId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_ExternalWaybill_CustomerAddress] FOREIGN KEY ([DeliveryAddressId]) REFERENCES [dbo].[CustomerAddress] ([Id]),
    CONSTRAINT [FK_ExternalWaybill_CustomerCoworker] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[CustomerCoworker] ([Id]),
    CONSTRAINT [FK_ExternalWaybill_Seller] FOREIGN KEY ([SellerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_ExternalWaybill_Vehicle] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicle] ([Id]),
    CONSTRAINT [FK_ExternalWaybill_Waybill] FOREIGN KEY ([WaybillId]) REFERENCES [dbo].[Waybill] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ExternalWaybill_Unique]
    ON [dbo].[ExternalWaybill]([WaybillId] ASC);

