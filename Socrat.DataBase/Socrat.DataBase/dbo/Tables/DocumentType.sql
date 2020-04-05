CREATE TABLE [dbo].[DocumentType] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]            NVARCHAR (30)    NOT NULL,
    [Code]            NVARCHAR (15)    NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_DocumentType] PRIMARY KEY NONCLUSTERED ([Id] ASC), 
    CONSTRAINT [AK_DocumentType_Name] UNIQUE ([Name]),
	CONSTRAINT [AK_DocumentType_Code] UNIQUE ([Code]),
);


