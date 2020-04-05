CREATE TABLE [dbo].[FieldValue] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Field_Id]        UNIQUEIDENTIFIER NULL,
    [Value]           NVARCHAR (50)    NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_FieldValue] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FieldValue_Field] FOREIGN KEY ([Field_Id]) REFERENCES [dbo].[Field] ([Id]) ON DELETE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_FieldValue_Field]
    ON [dbo].[FieldValue]([Field_Id] ASC);
