CREATE TABLE [dbo].[CatalogShape] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [SidesCount]      INT              NOT NULL,
    [CatalogNumber]   INT              NULL,
    [IsCatalogShape]  BIT              DEFAULT ('true') NOT NULL,
    [ShapeImage]      IMAGE            NULL,
    [FormType_Id]     UNIQUEIDENTIFIER NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CatalogShape] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CatalogShape_FormType] FOREIGN KEY ([FormType_Id]) REFERENCES [dbo].[FormType] ([Id])
);



