USE [MovieDatabase]
GO

/****** Object: Table [dbo].[movieModel] Script Date: 01-06-2022 11:53:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[movieModel] (
    [MovieId]          INT            IDENTITY (1, 1) NOT NULL,
    [MovieName]        NVARCHAR (MAX) NULL,
    [MovieDescription] NVARCHAR (MAX) NULL,
    [MovieType]        NVARCHAR (MAX) NULL,
    [MovieLanguage]    NVARCHAR (MAX) NULL
);


