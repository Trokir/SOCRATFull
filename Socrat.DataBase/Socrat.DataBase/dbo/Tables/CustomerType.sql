CREATE TABLE [dbo].[CustomerType] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Alias]           NVARCHAR (20)    NULL,
    [Comment]         NVARCHAR (70)    NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_CustomerType] PRIMARY KEY NONCLUSTERED ([Id] ASC), 
    CONSTRAINT [AK_CustomerType_Alias] UNIQUE ([Alias])
);




