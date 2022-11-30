SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
DROP TABLE IF EXISTS [dbo].[Category];
CREATE TABLE [dbo].[Category] (
    [ID]               INT IDENTITY (1, 1)	NOT NULL,
    [Name]             NVARCHAR (30)		NOT NULL,
    [Description]      NVARCHAR (100)		NULL,
    [IDParentCategory] INT					NULL
);