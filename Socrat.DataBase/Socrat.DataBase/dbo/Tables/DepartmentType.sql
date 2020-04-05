CREATE TABLE [dbo].[DepartmentType] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]            NVARCHAR (30)    NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_DepartmentType] PRIMARY KEY NONCLUSTERED ([Id] ASC), 
    CONSTRAINT [AK_DepartmentType_Name] UNIQUE ([Name])
);


