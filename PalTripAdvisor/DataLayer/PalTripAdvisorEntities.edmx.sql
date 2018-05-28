
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/27/2018 17:45:25
-- Generated from EDMX file: D:\Work\University\SOA\PalTripAdvisor\PalTripAdvisor\DataLayer\PalTripAdvisorEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PalTripAdvisorServices];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CurrenciesExchange_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CurrenciesExchange] DROP CONSTRAINT [FK_CurrenciesExchange_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_CurrenciesExchange_Currencies1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CurrenciesExchange] DROP CONSTRAINT [FK_CurrenciesExchange_Currencies1];
GO
IF OBJECT_ID(N'[dbo].[FK_PointOfInterest_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointOfInterest] DROP CONSTRAINT [FK_PointOfInterest_Currencies];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Currencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Currencies];
GO
IF OBJECT_ID(N'[dbo].[CurrenciesExchange]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrenciesExchange];
GO
IF OBJECT_ID(N'[dbo].[PointOfInterest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointOfInterest];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Currencies'
CREATE TABLE [dbo].[Currencies] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Slug] varchar(3)  NOT NULL
);
GO

-- Creating table 'CurrenciesExchanges'
CREATE TABLE [dbo].[CurrenciesExchanges] (
    [Id] uniqueidentifier  NOT NULL,
    [OriginalCurrencyId] uniqueidentifier  NOT NULL,
    [TargetCurrencyId] uniqueidentifier  NOT NULL,
    [Factor] decimal(6,3)  NOT NULL,
    [CreatedBy] varchar(50)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] varchar(50)  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'PointOfInterests'
CREATE TABLE [dbo].[PointOfInterests] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Image] varbinary(max)  NULL,
    [CityName] varchar(50)  NOT NULL,
    [CountryName] varchar(50)  NOT NULL,
    [Starts] int  NULL,
    [CurrencyId] uniqueidentifier  NOT NULL,
    [CreatedBy] varchar(50)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] varchar(50)  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Currencies'
ALTER TABLE [dbo].[Currencies]
ADD CONSTRAINT [PK_Currencies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CurrenciesExchanges'
ALTER TABLE [dbo].[CurrenciesExchanges]
ADD CONSTRAINT [PK_CurrenciesExchanges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PointOfInterests'
ALTER TABLE [dbo].[PointOfInterests]
ADD CONSTRAINT [PK_PointOfInterests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OriginalCurrencyId] in table 'CurrenciesExchanges'
ALTER TABLE [dbo].[CurrenciesExchanges]
ADD CONSTRAINT [FK_CurrenciesExchange_Currencies]
    FOREIGN KEY ([OriginalCurrencyId])
    REFERENCES [dbo].[Currencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CurrenciesExchange_Currencies'
CREATE INDEX [IX_FK_CurrenciesExchange_Currencies]
ON [dbo].[CurrenciesExchanges]
    ([OriginalCurrencyId]);
GO

-- Creating foreign key on [TargetCurrencyId] in table 'CurrenciesExchanges'
ALTER TABLE [dbo].[CurrenciesExchanges]
ADD CONSTRAINT [FK_CurrenciesExchange_Currencies1]
    FOREIGN KEY ([TargetCurrencyId])
    REFERENCES [dbo].[Currencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CurrenciesExchange_Currencies1'
CREATE INDEX [IX_FK_CurrenciesExchange_Currencies1]
ON [dbo].[CurrenciesExchanges]
    ([TargetCurrencyId]);
GO

-- Creating foreign key on [CurrencyId] in table 'PointOfInterests'
ALTER TABLE [dbo].[PointOfInterests]
ADD CONSTRAINT [FK_PointOfInterest_Currencies]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[Currencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PointOfInterest_Currencies'
CREATE INDEX [IX_FK_PointOfInterest_Currencies]
ON [dbo].[PointOfInterests]
    ([CurrencyId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------