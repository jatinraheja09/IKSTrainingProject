USE [MovieDatabase]
GO

/****** Object: Table [dbo].[theatreModel] Script Date: 01-06-2022 11:55:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[theatreModel] (
    [TheatreId]       INT            IDENTITY (1, 1) NOT NULL,
    [TheatreName]     NVARCHAR (MAX) NULL,
    [TheatreLocation] NVARCHAR (MAX) NULL,
    [TheatreCapacity] INT            NOT NULL
);


