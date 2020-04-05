CREATE TABLE [dbo].[FormType] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF__FormType__Id__5D2BD0E6] DEFAULT (newid()) NOT NULL,
    [Name]       VARCHAR (20)     NOT NULL,
    [SidesCount] INT              NULL,
    [RowVersion] ROWVERSION       NOT NULL,
    CONSTRAINT [PK__FormType__3214EC076E9489FF] PRIMARY KEY CLUSTERED ([Id] ASC)
);









GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_FormType_UniqueByName]
    ON [dbo].[FormType]([Name] ASC);

