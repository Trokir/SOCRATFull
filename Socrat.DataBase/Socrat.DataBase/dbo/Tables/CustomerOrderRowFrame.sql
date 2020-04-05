CREATE TABLE [dbo].[CustomerOrderRowFrame] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [CustomerOrderRowId] UNIQUEIDENTIFIER NOT NULL,
    [FrameNum]           TINYINT          NULL,
    [Spros]              BIT              NULL,
    [Gaz]                BIT              NULL,
    [RowVersion]         ROWVERSION       NOT NULL,
    [LastChangedUser]    UNIQUEIDENTIFIER NULL,
    [LastChangedDate]    DATETIME         NULL,
    CONSTRAINT [PK_CustomerOrderRowFrame] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerOrderRowFrame_CustomerOrderRow] FOREIGN KEY ([CustomerOrderRowId]) REFERENCES [dbo].[CustomerOrderRow] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_CustomerOrderRowFrame_CustomerOrderRow]
    ON [dbo].[CustomerOrderRowFrame]([CustomerOrderRowId] ASC);
