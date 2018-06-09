
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------

-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [pan_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_articulocabecera_receta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[cabecera_receta] DROP CONSTRAINT [FK_articulocabecera_receta];
GO
IF OBJECT_ID(N'[dbo].[FK_articulodetalle_receta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_receta] DROP CONSTRAINT [FK_articulodetalle_receta];
GO

IF OBJECT_ID(N'[dbo].[FK_cabecera_producciondetalle_produccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_produccion] DROP CONSTRAINT [FK_cabecera_producciondetalle_produccion];
GO
IF OBJECT_ID(N'[dbo].[FK_cabecera_recetadetalle_produccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_produccion] DROP CONSTRAINT [FK_cabecera_recetadetalle_produccion];
GO
IF OBJECT_ID(N'[dbo].[FK_cabecera_recetadetalle_receta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_receta] DROP CONSTRAINT [FK_cabecera_recetadetalle_receta];
GO
IF OBJECT_ID(N'[dbo].[FK_costodetalle_produccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_produccion] DROP CONSTRAINT [FK_costodetalle_produccion];
GO

GO
IF OBJECT_ID(N'[dbo].[FK_lineafamilia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[familias] DROP CONSTRAINT [FK_lineafamilia];
GO


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[articuloes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[articuloes];
GO
IF OBJECT_ID(N'[dbo].[cabecera_produccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[cabecera_produccion];
GO
IF OBJECT_ID(N'[dbo].[cabecera_receta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[cabecera_receta];
GO
IF OBJECT_ID(N'[dbo].[costos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[costos];
GO
IF OBJECT_ID(N'[dbo].[detalle_produccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[detalle_produccion];
GO
IF OBJECT_ID(N'[dbo].[detalle_receta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[detalle_receta];
GO
IF OBJECT_ID(N'[dbo].[familias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[familias];
GO
IF OBJECT_ID(N'[dbo].[lineas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lineas];
GO
IF OBJECT_ID(N'[dbo].[unidad_medida]', 'U') IS NOT NULL
    DROP TABLE [dbo].[unidad_medida];
GO



-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'articuloes'
CREATE TABLE [dbo].[articuloes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [familiaId] int  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [unidad_medidaId] int  NOT NULL,
    [codigo_barra] nvarchar(max)  NOT NULL,
    [marca] nvarchar(max)  NOT NULL,
    [formato] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'cabecera_produccion'
CREATE TABLE [dbo].[cabecera_produccion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL
);
GO

-- Creating table 'cabecera_receta'
CREATE TABLE [dbo].[cabecera_receta] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [articuloId] int  NOT NULL
);
GO

-- Creating table 'costos'
CREATE TABLE [dbo].[costos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [valor] int  NOT NULL
);
GO

-- Creating table 'detalle_produccion'
CREATE TABLE [dbo].[detalle_produccion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cabecera_produccionId] int  NOT NULL,
    [kilos] decimal(18,0)  NOT NULL,
    [cabecera_recetaId] int  NOT NULL,
    [costoId] int  NOT NULL,
    [ventaId] int  NOT NULL
);
GO

-- Creating table 'detalle_receta'
CREATE TABLE [dbo].[detalle_receta] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cantidad] decimal(18,0)  NOT NULL,
    [cabecera_recetaId] int  NOT NULL,
    [articuloId] int  NOT NULL
);
GO

-- Creating table 'familias'
CREATE TABLE [dbo].[familias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [lineaId] int  NOT NULL
);
GO

-- Creating table 'lineas'
CREATE TABLE [dbo].[lineas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'unidad_medida'
CREATE TABLE [dbo].[unidad_medida] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'precio_venta'
CREATE TABLE [dbo].[precio_venta] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [valor] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'articuloes'
ALTER TABLE [dbo].[articuloes]
ADD CONSTRAINT [PK_articuloes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'cabecera_produccion'
ALTER TABLE [dbo].[cabecera_produccion]
ADD CONSTRAINT [PK_cabecera_produccion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'cabecera_receta'
ALTER TABLE [dbo].[cabecera_receta]
ADD CONSTRAINT [PK_cabecera_receta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'costos'
ALTER TABLE [dbo].[costos]
ADD CONSTRAINT [PK_costos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'detalle_produccion'
ALTER TABLE [dbo].[detalle_produccion]
ADD CONSTRAINT [PK_detalle_produccion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'detalle_receta'
ALTER TABLE [dbo].[detalle_receta]
ADD CONSTRAINT [PK_detalle_receta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'familias'
ALTER TABLE [dbo].[familias]
ADD CONSTRAINT [PK_familias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'lineas'
ALTER TABLE [dbo].[lineas]
ADD CONSTRAINT [PK_lineas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'unidad_medida'
ALTER TABLE [dbo].[unidad_medida]
ADD CONSTRAINT [PK_unidad_medida]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'precio_venta'
ALTER TABLE [dbo].[precio_venta]
ADD CONSTRAINT [PK_precio_venta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [articuloId] in table 'cabecera_receta'
ALTER TABLE [dbo].[cabecera_receta]
ADD CONSTRAINT [FK_articulocabecera_receta]
    FOREIGN KEY ([articuloId])
    REFERENCES [dbo].[articuloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_articulocabecera_receta'
CREATE INDEX [IX_FK_articulocabecera_receta]
ON [dbo].[cabecera_receta]
    ([articuloId]);
GO

-- Creating foreign key on [articuloId] in table 'detalle_receta'
ALTER TABLE [dbo].[detalle_receta]
ADD CONSTRAINT [FK_articulodetalle_receta]
    FOREIGN KEY ([articuloId])
    REFERENCES [dbo].[articuloes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_articulodetalle_receta'
CREATE INDEX [IX_FK_articulodetalle_receta]
ON [dbo].[detalle_receta]
    ([articuloId]);
GO

-- Creating foreign key on [familiaId] in table 'articuloes'
ALTER TABLE [dbo].[articuloes]
ADD CONSTRAINT [FK_familiaarticulo]
    FOREIGN KEY ([familiaId])
    REFERENCES [dbo].[familias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_familiaarticulo'
CREATE INDEX [IX_FK_familiaarticulo]
ON [dbo].[articuloes]
    ([familiaId]);
GO

-- Creating foreign key on [unidad_medidaId] in table 'articuloes'
ALTER TABLE [dbo].[articuloes]
ADD CONSTRAINT [FK_unidad_medidaarticulo]
    FOREIGN KEY ([unidad_medidaId])
    REFERENCES [dbo].[unidad_medida]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_unidad_medidaarticulo'
CREATE INDEX [IX_FK_unidad_medidaarticulo]
ON [dbo].[articuloes]
    ([unidad_medidaId]);
GO

-- Creating foreign key on [cabecera_produccionId] in table 'detalle_produccion'
ALTER TABLE [dbo].[detalle_produccion]
ADD CONSTRAINT [FK_cabecera_producciondetalle_produccion]
    FOREIGN KEY ([cabecera_produccionId])
    REFERENCES [dbo].[cabecera_produccion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cabecera_producciondetalle_produccion'
CREATE INDEX [IX_FK_cabecera_producciondetalle_produccion]
ON [dbo].[detalle_produccion]
    ([cabecera_produccionId]);
GO

-- Creating foreign key on [cabecera_recetaId] in table 'detalle_produccion'
ALTER TABLE [dbo].[detalle_produccion]
ADD CONSTRAINT [FK_cabecera_recetadetalle_produccion]
    FOREIGN KEY ([cabecera_recetaId])
    REFERENCES [dbo].[cabecera_receta]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cabecera_recetadetalle_produccion'
CREATE INDEX [IX_FK_cabecera_recetadetalle_produccion]
ON [dbo].[detalle_produccion]
    ([cabecera_recetaId]);
GO

-- Creating foreign key on [cabecera_recetaId] in table 'detalle_receta'
ALTER TABLE [dbo].[detalle_receta]
ADD CONSTRAINT [FK_cabecera_recetadetalle_receta]
    FOREIGN KEY ([cabecera_recetaId])
    REFERENCES [dbo].[cabecera_receta]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cabecera_recetadetalle_receta'
CREATE INDEX [IX_FK_cabecera_recetadetalle_receta]
ON [dbo].[detalle_receta]
    ([cabecera_recetaId]);
GO

-- Creating foreign key on [costoId] in table 'detalle_produccion'
ALTER TABLE [dbo].[detalle_produccion]
ADD CONSTRAINT [FK_costodetalle_produccion]
    FOREIGN KEY ([costoId])
    REFERENCES [dbo].[costos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_costodetalle_produccion'
CREATE INDEX [IX_FK_costodetalle_produccion]
ON [dbo].[detalle_produccion]
    ([costoId]);
GO

-- Creating foreign key on [ventaId] in table 'detalle_produccion'
ALTER TABLE [dbo].[detalle_produccion]
ADD CONSTRAINT [FK_ventadetalle_produccion]
    FOREIGN KEY ([ventaId])
    REFERENCES [dbo].[precio_venta]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ventadetalle_produccion'
CREATE INDEX [IX_FK_ventadetalle_produccion]
ON [dbo].[detalle_produccion]
    ([ventaId]);
GO

-- Creating foreign key on [lineaId] in table 'familias'
ALTER TABLE [dbo].[familias]
ADD CONSTRAINT [FK_lineafamilia]
    FOREIGN KEY ([lineaId])
    REFERENCES [dbo].[lineas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_lineafamilia'
CREATE INDEX [IX_FK_lineafamilia]
ON [dbo].[familias]
    ([lineaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------