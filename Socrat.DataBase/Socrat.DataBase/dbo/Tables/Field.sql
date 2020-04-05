CREATE TABLE [dbo].[Field] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Name]            NVARCHAR (40)    NULL,
    [IsFixed]         BIT              NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_Field] PRIMARY KEY NONCLUSTERED ([Id] ASC), 
    CONSTRAINT [AK_Field_Name] UNIQUE ([Name])
);


