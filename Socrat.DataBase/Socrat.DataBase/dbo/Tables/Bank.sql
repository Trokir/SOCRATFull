CREATE TABLE [dbo].[Bank] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Bik]             NVARCHAR (9)     NULL,
    [Alias]           NVARCHAR (200)   NULL,
    [Filial]          NVARCHAR (200)   NULL,
    [KS]              NVARCHAR (20)    NULL,
    [Phone]           NVARCHAR (12)    NULL,
    [Coment]          NVARCHAR (100)   NULL,
    [NameShort]       NVARCHAR (30)    NULL,
    [Address_Id]      UNIQUEIDENTIFIER NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_Bank] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Bank_Address] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]) 
);



GO
CREATE NONCLUSTERED INDEX [IX_Bank_Address]
    ON [dbo].[Bank]([Address_Id] ASC);


GO

CREATE UNIQUE INDEX [IX_Bank_Filial] ON [dbo].[Bank] ([Filial]) WHERE [Filial] IS NOT NULL

GO

CREATE UNIQUE INDEX [IX_Bank_Alias] ON [dbo].[Bank] ([Alias]) WHERE [Alias] IS NOT NULL

GO

CREATE UNIQUE INDEX [IX_Bank_KS] ON [dbo].[Bank] ([KS]) WHERE [KS] IS NOT NULL

GO

CREATE UNIQUE INDEX [IX_Bank_Bik] ON [dbo].[Bank] ([Bik]) WHERE [Bik] IS NOT NULL
GO
