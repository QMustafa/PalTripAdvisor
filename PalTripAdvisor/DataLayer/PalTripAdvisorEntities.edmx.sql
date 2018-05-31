
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/31/2018 18:35:55
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
    ALTER TABLE [dbo].[CurrenciesExchanges] DROP CONSTRAINT [FK_CurrenciesExchange_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_CurrenciesExchange_Currencies1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CurrenciesExchanges] DROP CONSTRAINT [FK_CurrenciesExchange_Currencies1];
GO
IF OBJECT_ID(N'[dbo].[FK_PointOfInterest_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointOfInterests] DROP CONSTRAINT [FK_PointOfInterest_Currencies];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Currencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Currencies];
GO
IF OBJECT_ID(N'[dbo].[CurrenciesExchanges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrenciesExchanges];
GO
IF OBJECT_ID(N'[dbo].[Hotels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hotels];
GO
IF OBJECT_ID(N'[dbo].[PointOfInterests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointOfInterests];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Currencies'
CREATE TABLE [dbo].[Currencies] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Slug] varchar(3)  NOT NULL
);
GO

-- Creating table 'CurrenciesExchanges'
CREATE TABLE [dbo].[CurrenciesExchanges] (
    [id] smallint IDENTITY(1,1) NOT NULL,
    [OriginalCurrencyId] smallint  NOT NULL,
    [TargetCurrencyId] smallint  NOT NULL,
    [Factor] decimal(6,3)  NOT NULL,
    [CreatedBy] varchar(50)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] varchar(50)  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'Hotels'
CREATE TABLE [dbo].[Hotels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [CountyName] varchar(50)  NOT NULL,
    [CityName] varchar(50)  NOT NULL,
    [Rating] int  NOT NULL,
    [Image] varchar(max)  NULL,
    [AveragePrice] decimal(8,2)  NOT NULL,
    [CreatedBy] varchar(50)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] varchar(50)  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'PointOfInterests'
CREATE TABLE [dbo].[PointOfInterests] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Image] varchar(max)  NULL,
    [CityName] varchar(50)  NOT NULL,
    [CountryName] varchar(50)  NOT NULL,
    [Starts] int  NULL,
    [CurrencyId] smallint  NOT NULL,
    [ZipCode] int  NOT NULL,
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

-- Creating primary key on [id] in table 'CurrenciesExchanges'
ALTER TABLE [dbo].[CurrenciesExchanges]
ADD CONSTRAINT [PK_CurrenciesExchanges]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Hotels'
ALTER TABLE [dbo].[Hotels]
ADD CONSTRAINT [PK_Hotels]
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