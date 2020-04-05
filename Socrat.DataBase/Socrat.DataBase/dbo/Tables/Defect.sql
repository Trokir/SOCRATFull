CREATE TABLE [dbo].[Defect] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [OrderRowItemId]  UNIQUEIDENTIFIER NOT NULL,
    [DefectType]      INT              DEFAULT ((0)) NULL,
    [DefectReason]    INT              DEFAULT ((0)) NULL,
    [Comment]         NVARCHAR (500)   NULL,
    [Code1с]          NVARCHAR (30)    NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_Defect] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Defect_OrderRowItem] FOREIGN KEY ([OrderRowItemId]) REFERENCES [dbo].[OrderRowItem] ([Id]) ON DELETE CASCADE
);





GO
CREATE NONCLUSTERED INDEX [IX_Defect_OrderRowItem]
    ON [dbo].[Defect]([OrderRowItemId] ASC);
