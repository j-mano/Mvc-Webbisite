CREATE TABLE [dbo].[Companies] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [Name]               NVARCHAR (255)   NOT NULL,
    [OrganizationNumber] INT              NOT NULL,
    [Notes]              NVARCHAR (255)   NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

