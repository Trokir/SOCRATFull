CREATE TABLE [dbo].[EntityChange] (
    [Id]               UNIQUEIDENTIFIER CONSTRAINT [DF_EntityChange_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Guid]             UNIQUEIDENTIFIER NOT NULL,
    [TypeName]         VARCHAR (100)    NOT NULL,
    [TextPresentation] VARCHAR (1000)   NOT NULL,
    [Editor]           VARCHAR (100)    NOT NULL,
    [Dated]            DATETIME2 (7)    CONSTRAINT [DF_EntityChangesHistory_Dated] DEFAULT (getdate()) NOT NULL,
    [State]            VARCHAR (10)     NULL,
    [Serialized]       VARCHAR (MAX)    NOT NULL,
    [RowVersion]       ROWVERSION       NOT NULL,
    [LastChangedUser]  UNIQUEIDENTIFIER NULL,
    [LastChangedDate]  DATETIME         NULL,
    CONSTRAINT [PK_EntityChangesHistory] PRIMARY KEY CLUSTERED ([Id] ASC)
);



