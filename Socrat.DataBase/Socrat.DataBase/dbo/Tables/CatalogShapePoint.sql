CREATE TABLE [dbo].[CatalogShapePoint] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [PointName]       NVARCHAR (20)    NULL,
    [Point_X]         FLOAT (53)       NULL,
    [Point_Y]         FLOAT (53)       NULL,
    [PointRadius]     FLOAT (53)       NULL,
    [Shape_Id]        UNIQUEIDENTIFIER NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CatalogShapePoint] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CatalogShape_CatalogShapePoint] FOREIGN KEY ([Shape_Id]) REFERENCES [dbo].[CatalogShape] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_CatalogShapePoint_CatalogShape]
    ON [dbo].[CatalogShapePoint]([Shape_Id] ASC);

