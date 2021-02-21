CREATE TABLE [dbo].[Stores] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [CompanyId] UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (100)   NOT NULL,
    [Adress]    NVARCHAR (512)   NOT NULL,
    [City]      NVARCHAR (512)   NOT NULL,
    [Zip]       NVARCHAR (16)    NOT NULL,
    [Country]   NVARCHAR (50)    NOT NULL,
    [Longitude] NVARCHAR (15)    NULL,
    [Latitude]  NVARCHAR (15)    NULL,
    CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Stores_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id])
);

