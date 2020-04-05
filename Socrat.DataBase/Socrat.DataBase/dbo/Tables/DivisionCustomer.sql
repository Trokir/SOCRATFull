CREATE TABLE [dbo].[DivisionCustomer] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Division_Id]     UNIQUEIDENTIFIER NULL,
    [Customer_Id]     UNIQUEIDENTIFIER NULL,
    [Default]         BIT              NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_DivisionCustomer] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DivisionCustomer_Customer] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_DivisionCustomer_Division] FOREIGN KEY ([Division_Id]) REFERENCES [dbo].[Division] ([Id]) ON DELETE SET NULL, 
    CONSTRAINT [AK_DivisionCustomer] UNIQUE ([Division_Id], [Customer_Id])
);



GO
CREATE NONCLUSTERED INDEX [IX_DivisionCustomer_Division]
    ON [dbo].[DivisionCustomer]([Division_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_DivisionCustomer_Customer]
    ON [dbo].[DivisionCustomer]([Customer_Id] ASC);
