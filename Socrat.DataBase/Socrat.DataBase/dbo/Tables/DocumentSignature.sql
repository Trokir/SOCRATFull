CREATE TABLE [dbo].[DocumentSignature] (
    [Id]                       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [DocumentType_Id]          UNIQUEIDENTIFIER NULL,
    [DocumentSignatureType_Id] UNIQUEIDENTIFIER NULL,
    [RowVersion]               ROWVERSION       NOT NULL,
    [LastChangedUser]          UNIQUEIDENTIFIER NULL,
    [LastChangedDate]          DATETIME         NULL,
    CONSTRAINT [PK_DocumentSignature] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DocumentSignature_DocumentSignatureType] FOREIGN KEY ([DocumentSignatureType_Id]) REFERENCES [dbo].[DocumentSignatureType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_DocumentSignature_DocumentType] FOREIGN KEY ([DocumentType_Id]) REFERENCES [dbo].[DocumentType] ([Id]) ON DELETE SET NULL
);



GO
CREATE NONCLUSTERED INDEX [IX_DocumentSignature_DocumentType]
    ON [dbo].[DocumentSignature]([DocumentType_Id] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_DocumentSignature_DocumentSignatureType]
    ON [dbo].[DocumentSignature]([DocumentSignatureType_Id] ASC);
