CREATE TABLE [dbo].[EMail] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [DateCreated]     DATETIME         CONSTRAINT [EMail_DF_DateCreated] DEFAULT (getdate()) NOT NULL,
    [DateSend]        DATETIME         CONSTRAINT [EMail_DF_DateSend] DEFAULT (getdate()) NULL,
    [From]            NVARCHAR (50)    NULL,
    [To]              NVARCHAR (50)    NOT NULL,
    [Subject]         NVARCHAR (150)   NOT NULL,
    [Body]            NVARCHAR (MAX)   NULL,
    [EmailStatusEnum] INT              NOT NULL,
    [RowVersion]      ROWVERSION       NOT NULL,
    [LastChangedUser] UNIQUEIDENTIFIER NULL,
    [LastChangedDate] DATETIME         NULL,
    CONSTRAINT [PK_EMail] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);


