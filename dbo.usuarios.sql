CREATE TABLE [dbo].[usuarios] (
    [Id]             NVARCHAR (50)  NOT NULL,
    [nombre_usuario] NVARCHAR (150) NOT NULL,
    [contraseña]     NVARCHAR (MAX) NOT NULL,
    [email]          NVARCHAR (50)  NOT NULL
);

