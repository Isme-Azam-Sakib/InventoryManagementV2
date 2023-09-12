CREATE TABLE [dbo].[accessories] (
    [ProductCode]     VARCHAR(10)           NOT NULL,
    [AccessoriesName] VARCHAR (70)  NOT NULL,
    [Specification]   VARCHAR (500) NOT NULL,
    [Price]           INT    NOT NULL,
    [Stock]           INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ProductCode] ASC)
);

