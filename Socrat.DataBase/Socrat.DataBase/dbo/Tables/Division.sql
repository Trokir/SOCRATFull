CREATE TABLE [dbo].[Division] (
    [Id]           UNIQUEIDENTIFIER CONSTRAINT [DF__Division__Id__50FB042B] DEFAULT (newid()) NOT NULL,
    [NameAlias]    NVARCHAR (20)    NULL,
    [NameShort]    NVARCHAR (30)    NULL,
    [NameFull]     NVARCHAR (50)    NULL,
    [Region]       NVARCHAR (30)    NULL,
    [Address_Id]   UNIQUEIDENTIFIER NULL,
    [Number]       NVARCHAR (2)     NULL,
    [FormulaSpoId] UNIQUEIDENTIFIER NULL,
    [FormulaSpdId] UNIQUEIDENTIFIER NULL,
    [RowVersion]   ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Division] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Division_Address] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Division_FormulaSpd] FOREIGN KEY ([FormulaSpdId]) REFERENCES [dbo].[Formula] ([Id]),
    CONSTRAINT [FK_Division_FormulaSpo] FOREIGN KEY ([FormulaSpoId]) REFERENCES [dbo].[Formula] ([Id]), 
    CONSTRAINT [AK_Division_NameAlias] UNIQUE ([NameAlias]),
	CONSTRAINT [AK_Division_NameShort] UNIQUE ([NameShort]),
	CONSTRAINT [AK_Division_NameFull] UNIQUE ([NameFull]),
	CONSTRAINT [AK_Division_Number] UNIQUE ([Number])
);




GO
CREATE NONCLUSTERED INDEX [IX_Division_Address]
    ON [dbo].[Division]([Address_Id] ASC);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Производственная площадка',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Division',
    @level2type = N'COLUMN',
    @level2name = N'Address_Id'