
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/26/2022 10:13:23
-- Generated from EDMX file: C:\Users\acrim\OneDrive\Dokumenter\360highscores\360highscore4\360HighScoresv2\Models\scoredata.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [360highscores];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Faceit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Faceit];
GO
IF OBJECT_ID(N'[dbo].[Tetris]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tetris];
GO
IF OBJECT_ID(N'[dbo].[Minesweeper]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Minesweeper];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Faceit'
CREATE TABLE [dbo].[Faceit] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Navn] nvarchar(50)  NOT NULL,
    [Elo] int  NOT NULL
);
GO

-- Creating table 'Tetris'
CREATE TABLE [dbo].[Tetris] (
    [Navn] nvarchar(50)  NOT NULL,
    [Point] int  NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    [Rank] int  NULL
);
GO

-- Creating table 'Minesweeper'
CREATE TABLE [dbo].[Minesweeper] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Navn] nvarchar(50)  NOT NULL,
    [Tid] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Faceit'
ALTER TABLE [dbo].[Faceit]
ADD CONSTRAINT [PK_Faceit]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tetris'
ALTER TABLE [dbo].[Tetris]
ADD CONSTRAINT [PK_Tetris]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [Navn], [Tid] in table 'Minesweeper'
ALTER TABLE [dbo].[Minesweeper]
ADD CONSTRAINT [PK_Minesweeper]
    PRIMARY KEY CLUSTERED ([ID], [Navn], [Tid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------