CREATE TABLE [dbo].[CustomerOrderRow] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
	[Num]			  INT			   NULL,		
    [Width]           SMALLINT         NULL,
    [Height]          SMALLINT         NULL,
    [Formula]         NVARCHAR (150)   NULL,
    [Count]           SMALLINT         NULL,
    [UsedCount]       SMALLINT         NULL,
    [Mark]            NVARCHAR (200)   NULL,
    [Barcode]         NVARCHAR (200)   NULL,
    [Comment]         NVARCHAR (200)   NULL,
    [CellNumber]      NVARCHAR (10)    NULL,
    [CartNumber]      NVARCHAR (10)    NULL,
    [ProductionParty] NVARCHAR (10)    NULL,
    [CustNumCustomer] NVARCHAR (100)   NULL,
    [IsTender]        BIT              NULL,
    [TenderNumber]    NVARCHAR (50)    NULL,
    [CustomerOrderId] UNIQUEIDENTIFIER NOT NULL,
    [Used]            BIT              NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerOrderRow] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerOrderRow_CustomerOrder] FOREIGN KEY ([CustomerOrderId]) REFERENCES [dbo].[CustomerOrder] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerOrderRow_CustomerOrder]
    ON [dbo].[CustomerOrderRow]([CustomerOrderId] ASC);
