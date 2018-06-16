-- Creating table 'usuarios'
CREATE TABLE [dbo].[usuarios] (
    [Id] nvarchar(50)  NOT NULL,
    [nombre_usuario] nvarchar(150)  NOT NULL,
    [contraseña] nvarchar(max)  NOT NULL,
    [email] nvarchar(50)  NOT NULL
);