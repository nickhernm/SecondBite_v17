/*
Script de implementación para C:\USERS\RAMAJ\SOURCE\REPOS\SECONDBITE_V17\WEB\APP_DATA\DATABASE.MDF

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "C:\USERS\RAMAJ\SOURCE\REPOS\SECONDBITE_V17\WEB\APP_DATA\DATABASE.MDF"
:setvar DefaultFilePrefix "C_\USERS\RAMAJ\SOURCE\REPOS\SECONDBITE_V17\WEB\APP_DATA\DATABASE.MDF_"
:setvar DefaultDataPath "C:\Users\ramaj\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\ramaj\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Creando Tabla [dbo].[CESTA]...';


GO
CREATE TABLE [dbo].[CESTA] (
    [id]         INT NOT NULL,
    [num_pedido] INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[DIRECCION]...';


GO
CREATE TABLE [dbo].[DIRECCION] (
    [nombre_calle] VARCHAR (20) NOT NULL,
    [calle_num]    INT          NOT NULL,
    [cod_p]        INT          NULL,
    [ciudad]       VARCHAR (10) NULL,
    [comunidad]    VARCHAR (10) NULL,
    [restaurante]  INT          NULL,
    [cliente]      VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([nombre_calle] ASC, [calle_num] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[FAVORITOS]...';


GO
CREATE TABLE [dbo].[FAVORITOS] (
    [id]      INT          NOT NULL,
    [usuario] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[LINPED]...';


GO
CREATE TABLE [dbo].[LINPED] (
    [linea]      INT        NOT NULL,
    [num_pedido] INT        NOT NULL,
    [importe]    FLOAT (53) NULL,
    [cantidad]   FLOAT (53) NULL,
    [plato]      INT        NOT NULL,
    CONSTRAINT [pk_linped] PRIMARY KEY CLUSTERED ([linea] ASC, [num_pedido] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[MENU]...';


GO
CREATE TABLE [dbo].[MENU] (
    [restaurante] INT NOT NULL,
    [plato]       INT NOT NULL,
    CONSTRAINT [pk_menu] PRIMARY KEY CLUSTERED ([restaurante] ASC, [plato] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[METODO_PAGO]...';


GO
CREATE TABLE [dbo].[METODO_PAGO] (
    [id_metodo]         INT          NOT NULL,
    [tipo]              VARCHAR (20) NULL,
    [numero_tarjeta]    VARCHAR (20) NULL,
    [fecha_vencimiento] DATE         NULL,
    [usuario_correo]    VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([id_metodo] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[OPINION]...';


GO
CREATE TABLE [dbo].[OPINION] (
    [id]          INT          NOT NULL,
    [descripcion] VARCHAR (50) NULL,
    [valoracion]  FLOAT (53)   NULL,
    [usuario]     VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[OPINION_RESTAURANTE]...';


GO
CREATE TABLE [dbo].[OPINION_RESTAURANTE] (
    [cod_restaurante] INT NOT NULL,
    [id_opinion]      INT NOT NULL,
    CONSTRAINT [pk_opinion_restaurante] PRIMARY KEY CLUSTERED ([cod_restaurante] ASC, [id_opinion] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[PEDIDO]...';


GO
CREATE TABLE [dbo].[PEDIDO] (
    [num_pedido] INT          NOT NULL,
    [fecha]      DATE         NULL,
    [usuario]    VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([num_pedido] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[PLATO]...';


GO
CREATE TABLE [dbo].[PLATO] (
    [id]         INT          NOT NULL,
    [nombre]     VARCHAR (20) NULL,
    [alergenos]  CHAR (10)    NULL,
    [puntuacion] FLOAT (53)   NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[PLATO_FAVORITOS]...';


GO
CREATE TABLE [dbo].[PLATO_FAVORITOS] (
    [id_p] INT NOT NULL,
    [id_f] INT NOT NULL,
    CONSTRAINT [pk_plato_favoritos] PRIMARY KEY CLUSTERED ([id_p] ASC, [id_f] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[PLATO_OPINION]...';


GO
CREATE TABLE [dbo].[PLATO_OPINION] (
    [id_p] INT NOT NULL,
    [id_o] INT NOT NULL,
    CONSTRAINT [pk_plato_opinion] PRIMARY KEY CLUSTERED ([id_p] ASC, [id_o] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[RESTAURANTE]...';


GO
CREATE TABLE [dbo].[RESTAURANTE] (
    [cod]           INT          NOT NULL,
    [nombre]        CHAR (10)    NULL,
    [localidad]     VARCHAR (15) NULL,
    [tipo]          CHAR (10)    NULL,
    [puntuacion]    FLOAT (53)   NULL,
    [direccion]     VARCHAR (20) NOT NULL,
    [num_dir]       INT          NOT NULL,
    [plato]         VARCHAR (20) NULL,
    [u_restaurante] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([cod] ASC),
    UNIQUE NONCLUSTERED ([num_dir] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Tabla [dbo].[USUARIO]...';


GO
CREATE TABLE [dbo].[USUARIO] (
    [correo]         VARCHAR (20) NOT NULL,
    [nombre]         VARCHAR (20) NULL,
    [telefono]       INT          NULL,
    [tipo_usuario]   BIT          NOT NULL,
    [id_metodo_pago] INT          NULL,
    PRIMARY KEY CLUSTERED ([correo] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_num_pedido_cesta]...';


GO
ALTER TABLE [dbo].[CESTA] WITH NOCHECK
    ADD CONSTRAINT [fk_num_pedido_cesta] FOREIGN KEY ([num_pedido]) REFERENCES [dbo].[PEDIDO] ([num_pedido]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_restaurante_direccion]...';


GO
ALTER TABLE [dbo].[DIRECCION] WITH NOCHECK
    ADD CONSTRAINT [fk_restaurante_direccion] FOREIGN KEY ([restaurante]) REFERENCES [dbo].[RESTAURANTE] ([cod]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_usuario_direccion]...';


GO
ALTER TABLE [dbo].[DIRECCION] WITH NOCHECK
    ADD CONSTRAINT [fk_usuario_direccion] FOREIGN KEY ([cliente]) REFERENCES [dbo].[USUARIO] ([correo]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_usuario_favoritos]...';


GO
ALTER TABLE [dbo].[FAVORITOS] WITH NOCHECK
    ADD CONSTRAINT [fk_usuario_favoritos] FOREIGN KEY ([usuario]) REFERENCES [dbo].[USUARIO] ([correo]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_num_linped]...';


GO
ALTER TABLE [dbo].[LINPED] WITH NOCHECK
    ADD CONSTRAINT [fk_num_linped] FOREIGN KEY ([num_pedido]) REFERENCES [dbo].[PEDIDO] ([num_pedido]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_plato_linped]...';


GO
ALTER TABLE [dbo].[LINPED] WITH NOCHECK
    ADD CONSTRAINT [fk_plato_linped] FOREIGN KEY ([plato]) REFERENCES [dbo].[PLATO] ([id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_menu_restaurante]...';


GO
ALTER TABLE [dbo].[MENU] WITH NOCHECK
    ADD CONSTRAINT [fk_menu_restaurante] FOREIGN KEY ([restaurante]) REFERENCES [dbo].[RESTAURANTE] ([cod]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_plato_menu]...';


GO
ALTER TABLE [dbo].[MENU] WITH NOCHECK
    ADD CONSTRAINT [fk_plato_menu] FOREIGN KEY ([plato]) REFERENCES [dbo].[PLATO] ([id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa restricción sin nombre en [dbo].[METODO_PAGO]...';


GO
ALTER TABLE [dbo].[METODO_PAGO] WITH NOCHECK
    ADD FOREIGN KEY ([usuario_correo]) REFERENCES [dbo].[USUARIO] ([correo]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_usuario_opinion]...';


GO
ALTER TABLE [dbo].[OPINION] WITH NOCHECK
    ADD CONSTRAINT [fk_usuario_opinion] FOREIGN KEY ([usuario]) REFERENCES [dbo].[USUARIO] ([correo]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_restaurante_opinion]...';


GO
ALTER TABLE [dbo].[OPINION_RESTAURANTE] WITH NOCHECK
    ADD CONSTRAINT [fk_restaurante_opinion] FOREIGN KEY ([cod_restaurante]) REFERENCES [dbo].[RESTAURANTE] ([cod]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_opinion_restaurante]...';


GO
ALTER TABLE [dbo].[OPINION_RESTAURANTE] WITH NOCHECK
    ADD CONSTRAINT [fk_opinion_restaurante] FOREIGN KEY ([id_opinion]) REFERENCES [dbo].[OPINION] ([id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_usuario_pedido]...';


GO
ALTER TABLE [dbo].[PEDIDO] WITH NOCHECK
    ADD CONSTRAINT [fk_usuario_pedido] FOREIGN KEY ([usuario]) REFERENCES [dbo].[USUARIO] ([correo]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_plato_favoritos_plato]...';


GO
ALTER TABLE [dbo].[PLATO_FAVORITOS] WITH NOCHECK
    ADD CONSTRAINT [fk_plato_favoritos_plato] FOREIGN KEY ([id_p]) REFERENCES [dbo].[PLATO] ([id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_plato_favoritos_favoritos]...';


GO
ALTER TABLE [dbo].[PLATO_FAVORITOS] WITH NOCHECK
    ADD CONSTRAINT [fk_plato_favoritos_favoritos] FOREIGN KEY ([id_f]) REFERENCES [dbo].[FAVORITOS] ([id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_plato_opinion_plato]...';


GO
ALTER TABLE [dbo].[PLATO_OPINION] WITH NOCHECK
    ADD CONSTRAINT [fk_plato_opinion_plato] FOREIGN KEY ([id_p]) REFERENCES [dbo].[PLATO] ([id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_plato_opinion_opinion]...';


GO
ALTER TABLE [dbo].[PLATO_OPINION] WITH NOCHECK
    ADD CONSTRAINT [fk_plato_opinion_opinion] FOREIGN KEY ([id_o]) REFERENCES [dbo].[OPINION] ([id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_urestaurante_restaurante]...';


GO
ALTER TABLE [dbo].[RESTAURANTE] WITH NOCHECK
    ADD CONSTRAINT [fk_urestaurante_restaurante] FOREIGN KEY ([u_restaurante]) REFERENCES [dbo].[USUARIO] ([correo]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_direccion_restaurante]...';


GO
ALTER TABLE [dbo].[RESTAURANTE] WITH NOCHECK
    ADD CONSTRAINT [fk_direccion_restaurante] FOREIGN KEY ([direccion], [num_dir]) REFERENCES [dbo].[DIRECCION] ([nombre_calle], [calle_num]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Clave externa [dbo].[fk_metodo_pago_usuario]...';


GO
ALTER TABLE [dbo].[USUARIO] WITH NOCHECK
    ADD CONSTRAINT [fk_metodo_pago_usuario] FOREIGN KEY ([id_metodo_pago]) REFERENCES [dbo].[METODO_PAGO] ([id_metodo]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Restricción CHECK restricción sin nombre en [dbo].[PLATO]...';


GO
ALTER TABLE [dbo].[PLATO] WITH NOCHECK
    ADD CHECK (alergenos IN ('masricos', 'pescado', 'soja'));


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creando Restricción CHECK [dbo].[fk_tipo_restaurante]...';


GO
ALTER TABLE [dbo].[RESTAURANTE] WITH NOCHECK
    ADD CONSTRAINT [fk_tipo_restaurante] CHECK (tipo IN ('chino', 'indio', 'arabe', 'mexicano', 'italiano'));


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'La parte de transacción de la actualización de la base de datos se realizó correctamente.'
COMMIT TRANSACTION
END
ELSE PRINT N'Error de la parte de transacción de la actualización de la base de datos.'
GO
IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[CESTA] WITH CHECK CHECK CONSTRAINT [fk_num_pedido_cesta];

ALTER TABLE [dbo].[DIRECCION] WITH CHECK CHECK CONSTRAINT [fk_restaurante_direccion];

ALTER TABLE [dbo].[DIRECCION] WITH CHECK CHECK CONSTRAINT [fk_usuario_direccion];

ALTER TABLE [dbo].[FAVORITOS] WITH CHECK CHECK CONSTRAINT [fk_usuario_favoritos];

ALTER TABLE [dbo].[LINPED] WITH CHECK CHECK CONSTRAINT [fk_num_linped];

ALTER TABLE [dbo].[LINPED] WITH CHECK CHECK CONSTRAINT [fk_plato_linped];

ALTER TABLE [dbo].[MENU] WITH CHECK CHECK CONSTRAINT [fk_menu_restaurante];

ALTER TABLE [dbo].[MENU] WITH CHECK CHECK CONSTRAINT [fk_plato_menu];

ALTER TABLE [dbo].[OPINION] WITH CHECK CHECK CONSTRAINT [fk_usuario_opinion];

ALTER TABLE [dbo].[OPINION_RESTAURANTE] WITH CHECK CHECK CONSTRAINT [fk_restaurante_opinion];

ALTER TABLE [dbo].[OPINION_RESTAURANTE] WITH CHECK CHECK CONSTRAINT [fk_opinion_restaurante];

ALTER TABLE [dbo].[PEDIDO] WITH CHECK CHECK CONSTRAINT [fk_usuario_pedido];

ALTER TABLE [dbo].[PLATO_FAVORITOS] WITH CHECK CHECK CONSTRAINT [fk_plato_favoritos_plato];

ALTER TABLE [dbo].[PLATO_FAVORITOS] WITH CHECK CHECK CONSTRAINT [fk_plato_favoritos_favoritos];

ALTER TABLE [dbo].[PLATO_OPINION] WITH CHECK CHECK CONSTRAINT [fk_plato_opinion_plato];

ALTER TABLE [dbo].[PLATO_OPINION] WITH CHECK CHECK CONSTRAINT [fk_plato_opinion_opinion];

ALTER TABLE [dbo].[RESTAURANTE] WITH CHECK CHECK CONSTRAINT [fk_urestaurante_restaurante];

ALTER TABLE [dbo].[RESTAURANTE] WITH CHECK CHECK CONSTRAINT [fk_direccion_restaurante];

ALTER TABLE [dbo].[USUARIO] WITH CHECK CHECK CONSTRAINT [fk_metodo_pago_usuario];

ALTER TABLE [dbo].[RESTAURANTE] WITH CHECK CHECK CONSTRAINT [fk_tipo_restaurante];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.METODO_PAGO'), OBJECT_ID(N'dbo.PLATO'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Comprobando restricción:' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Error de comprobación de restricción:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'Error al comprobar las restricciones', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Actualización completada.';


GO
