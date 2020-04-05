CREATE TABLE [dbo].[Address] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Country_Id]      UNIQUEIDENTIFIER NULL,
    [ZipCode]         NVARCHAR (30)    NULL,
    [ValueStr]        NVARCHAR (500)   NULL,
    [IsProduction]    BIT              NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Address_Country] FOREIGN KEY ([Country_Id]) REFERENCES [dbo].[Country] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Address_Country]
    ON [dbo].[Address]([Country_Id] ASC);
