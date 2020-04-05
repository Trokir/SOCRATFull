CREATE TABLE [dbo].[DivisionSignature] (
    [Id]                       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Division_Id]              UNIQUEIDENTIFIER NULL,
    [DocumentType_Id]          UNIQUEIDENTIFIER NULL,
    [DocumentSignatureType_Id] UNIQUEIDENTIFIER NULL,
    [Coworker_Id]              UNIQUEIDENTIFIER NULL,
    [DocCoworkerPosition]      NVARCHAR (100)   NULL,
    [DocBasics]                NVARCHAR (50)    NULL,
    [Customer_Id]              UNIQUEIDENTIFIER NULL,
    [RowVersion]               ROWVERSION       NOT NULL,
    [LastChangedUser]          UNIQUEIDENTIFIER NULL,
    [LastChangedDate]          DATETIME         NULL,
    CONSTRAINT [PK_DivisionSignature] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DivisionSignature_Coworker] FOREIGN KEY ([Coworker_Id]) REFERENCES [dbo].[Coworker] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_DivisionSignature_Customer] FOREIGN KEY ([Customer_Id]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_DivisionSignature_Division] FOREIGN KEY ([Division_Id]) REFERENCES [dbo].[Division] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_DivisionSignature_DocumentSignatureType] FOREIGN KEY ([DocumentSignatureType_Id]) REFERENCES [dbo].[DocumentSignatureType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_DivisionSignature_DocumentType] FOREIGN KEY ([DocumentType_Id]) REFERENCES [dbo].[DocumentType] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_DivisionSignature_Coworker]
    ON [dbo].[DivisionSignature]([Coworker_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_DivisionSignature_Customer]
    ON [dbo].[DivisionSignature]([Customer_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_DivisionSignature_Division]
    ON [dbo].[DivisionSignature]([Division_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_DivisionSignature_DocumentSignatureType]
    ON [dbo].[DivisionSignature]([DocumentSignatureType_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_DivisionSignature_DocumentType]
    ON [dbo].[DivisionSignature]([DocumentType_Id] ASC);


