CREATE TABLE [dbo].[Brand] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Vendor_Id]   UNIQUEIDENTIFIER NULL,
    [Name]        VARCHAR (150)    NULL,
    [Material_Id] UNIQUEIDENTIFIER NULL,
    [RowVersion]  ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Brand_Material] FOREIGN KEY ([Material_Id]) REFERENCES [dbo].[Material] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Brand_Vendor] FOREIGN KEY ([Vendor_Id]) REFERENCES [dbo].[Vendor] ([Id]) ON DELETE SET NULL, 
    CONSTRAINT [AK_Brand] UNIQUE ([Vendor_Id], [Name],  [Material_Id])
);





GO
CREATE NONCLUSTERED INDEX [IX_Brand_Material]
    ON [dbo].[Brand]([Material_Id] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Brand_Vendor]
    ON [dbo].[Brand]([Vendor_Id] ASC);



