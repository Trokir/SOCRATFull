CREATE TABLE [dbo].[ContactType] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]            NVARCHAR (30)    NOT NULL,
    [RegexMask]       NVARCHAR (150)   NULL,
    [TypeCode]        INT              CONSTRAINT [DF_ContactType_TypeCode] DEFAULT ((0)) NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_ContactType] PRIMARY KEY NONCLUSTERED ([Id] ASC), 
    CONSTRAINT [AK_ContactType_Name] UNIQUE ([Name])
);







