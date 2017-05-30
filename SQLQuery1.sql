
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2017 16:30:53
-- Generated from EDMX file: C:\Users\mezentsev\Downloads\TILab1WPF\TILab1WPF\Model\UniverModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [tempdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Mark_Criterion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mark] DROP CONSTRAINT [FK_Mark_Criterion];
GO
IF OBJECT_ID(N'[dbo].[FK_Result_Alternative]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Result] DROP CONSTRAINT [FK_Result_Alternative];
GO
IF OBJECT_ID(N'[dbo].[FK_Result_LPR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Result] DROP CONSTRAINT [FK_Result_LPR];
GO
IF OBJECT_ID(N'[dbo].[FK_Vector_Alternative]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vector] DROP CONSTRAINT [FK_Vector_Alternative];
GO
IF OBJECT_ID(N'[dbo].[FK_Vector_Mark]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vector] DROP CONSTRAINT [FK_Vector_Mark];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Alternative]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alternative];
GO
IF OBJECT_ID(N'[dbo].[Criterion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Criterion];
GO
IF OBJECT_ID(N'[dbo].[LPR]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LPR];
GO
IF OBJECT_ID(N'[dbo].[Mark]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mark];
GO
IF OBJECT_ID(N'[dbo].[Result]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Result];
GO
IF OBJECT_ID(N'[dbo].[Vector]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vector];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alternatives'
CREATE TABLE [dbo].[Alternatives] (
    [ANum] int IDENTITY(1,1) NOT NULL,
    [AName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Criteria'
CREATE TABLE [dbo].[Criteria] (
    [CNum] int IDENTITY(1,1) NOT NULL,
    [CName] nvarchar(max)  NOT NULL,
    [CRange] int  NOT NULL,
    [CWeight] int  NOT NULL,
    [CType] nvarchar(255)  NOT NULL,
    [OptimType] nvarchar(255)  NOT NULL,
    [EdIzmer] nvarchar(255)  NOT NULL,
    [ScaleType] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'LPRs'
CREATE TABLE [dbo].[LPRs] (
    [LNum] int IDENTITY(1,1) NOT NULL,
    [LName] nvarchar(max)  NOT NULL,
    [LRange] int  NOT NULL
);
GO

-- Creating table 'Marks'
CREATE TABLE [dbo].[Marks] (
    [MNum] int IDENTITY(1,1) NOT NULL,
    [CNum] int  NOT NULL,
    [MName] nvarchar(max)  NOT NULL,
    [MRange] int  NOT NULL,
    [NumMark] int  NOT NULL,
    [NormMark] int  NOT NULL
);
GO

-- Creating table 'Results'
CREATE TABLE [dbo].[Results] (
    [RNum] int IDENTITY(1,1) NOT NULL,
    [LNum] int  NOT NULL,
    [ANum] int  NOT NULL,
    [Range] int  NOT NULL,
    [AWeight] int  NOT NULL
);
GO

-- Creating table 'Vectors'
CREATE TABLE [dbo].[Vectors] (
    [VNum] int IDENTITY(1,1) NOT NULL,
    [ANum] int  NOT NULL,
    [MNum] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ANum] in table 'Alternatives'
ALTER TABLE [dbo].[Alternatives]
ADD CONSTRAINT [PK_Alternatives]
    PRIMARY KEY CLUSTERED ([ANum] ASC);
GO

-- Creating primary key on [CNum] in table 'Criteria'
ALTER TABLE [dbo].[Criteria]
ADD CONSTRAINT [PK_Criteria]
    PRIMARY KEY CLUSTERED ([CNum] ASC);
GO

-- Creating primary key on [LNum] in table 'LPRs'
ALTER TABLE [dbo].[LPRs]
ADD CONSTRAINT [PK_LPRs]
    PRIMARY KEY CLUSTERED ([LNum] ASC);
GO

-- Creating primary key on [MNum] in table 'Marks'
ALTER TABLE [dbo].[Marks]
ADD CONSTRAINT [PK_Marks]
    PRIMARY KEY CLUSTERED ([MNum] ASC);
GO

-- Creating primary key on [RNum] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [PK_Results]
    PRIMARY KEY CLUSTERED ([RNum] ASC);
GO

-- Creating primary key on [VNum] in table 'Vectors'
ALTER TABLE [dbo].[Vectors]
ADD CONSTRAINT [PK_Vectors]
    PRIMARY KEY CLUSTERED ([VNum] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ANum] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Result_Alternative]
    FOREIGN KEY ([ANum])
    REFERENCES [dbo].[Alternatives]
        ([ANum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Result_Alternative'
CREATE INDEX [IX_FK_Result_Alternative]
ON [dbo].[Results]
    ([ANum]);
GO

-- Creating foreign key on [ANum] in table 'Vectors'
ALTER TABLE [dbo].[Vectors]
ADD CONSTRAINT [FK_Vector_Alternative]
    FOREIGN KEY ([ANum])
    REFERENCES [dbo].[Alternatives]
        ([ANum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vector_Alternative'
CREATE INDEX [IX_FK_Vector_Alternative]
ON [dbo].[Vectors]
    ([ANum]);
GO

-- Creating foreign key on [CNum] in table 'Marks'
ALTER TABLE [dbo].[Marks]
ADD CONSTRAINT [FK_Mark_Criterion]
    FOREIGN KEY ([CNum])
    REFERENCES [dbo].[Criteria]
        ([CNum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mark_Criterion'
CREATE INDEX [IX_FK_Mark_Criterion]
ON [dbo].[Marks]
    ([CNum]);
GO

-- Creating foreign key on [LNum] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Result_LPR]
    FOREIGN KEY ([LNum])
    REFERENCES [dbo].[LPRs]
        ([LNum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Result_LPR'
CREATE INDEX [IX_FK_Result_LPR]
ON [dbo].[Results]
    ([LNum]);
GO

-- Creating foreign key on [MNum] in table 'Vectors'
ALTER TABLE [dbo].[Vectors]
ADD CONSTRAINT [FK_Vector_Mark]
    FOREIGN KEY ([MNum])
    REFERENCES [dbo].[Marks]
        ([MNum])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vector_Mark'
CREATE INDEX [IX_FK_Vector_Mark]
ON [dbo].[Vectors]
    ([MNum]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------