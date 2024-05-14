CREATE TABLE [dbo].[USUARIO](
    [correo] VARCHAR(20) NOT NULL PRIMARY KEY,
    [nombre] VARCHAR(20),
    [telefono] INT,
    [tipo_usuario] BIT NOT NULL,
    [id_metodo_pago] INT,
    CONSTRAINT fk_metodo_pago_usuario FOREIGN KEY (id_metodo_pago) REFERENCES METODO_PAGO(id_metodo)
);
GO

CREATE TABLE [dbo].[DIRECCION](
    [nombre_calle] VARCHAR(20) NOT NULL,
    [calle_num] INT NOT NULL,
    [cod_p] INT,
    [ciudad] VARCHAR(10),
    [comunidad] VARCHAR(10),
    [restaurante] INT,
    [cliente] VARCHAR(20) NOT NULL,
    CONSTRAINT fk_usuario_direccion FOREIGN KEY(cliente) REFERENCES USUARIO(correo),
    PRIMARY KEY (nombre_calle, calle_num) -- Clave primaria compuesta
);
GO

CREATE TABLE [dbo].[RESTAURANTE] (
    [cod] INT NOT NULL PRIMARY KEY,
    [nombre] CHAR(10),
    [localidad] VARCHAR(15),
    [tipo] CHAR(10) CONSTRAINT fk_tipo_restaurante CHECK(tipo IN ('chino', 'indio', 'arabe', 'mexicano', 'italiano')),
    [puntuacion] FLOAT,
    [direccion] VARCHAR(20) NOT NULL,
    [num_dir] INT NOT NULL UNIQUE, -- Cambiado a UNIQUE
    [plato] VARCHAR(20),
    [u_restaurante] VARCHAR(20) NOT NULL,
    CONSTRAINT fk_urestaurante_restaurante FOREIGN KEY(u_restaurante) REFERENCES USUARIO(correo),
    CONSTRAINT fk_direccion_restaurante FOREIGN KEY(direccion, num_dir) REFERENCES DIRECCION(nombre_calle, calle_num)
);
GO

CREATE TABLE [dbo].[PLATO](
    [id] INT NOT NULL PRIMARY KEY,
    [nombre] VARCHAR(20),
    [alergenos] CHAR(10) CHECK(alergenos IN ('masricos', 'pescado', 'soja')),
    [puntuacion] FLOAT
);
GO

CREATE TABLE [dbo].[MENU](
    [restaurante] INT,
    [plato] INT,
    CONSTRAINT pk_menu PRIMARY KEY (restaurante, plato), -- Clave primaria compuesta
    CONSTRAINT fk_menu_restaurante FOREIGN KEY(restaurante) REFERENCES RESTAURANTE(cod),
    CONSTRAINT fk_plato_menu FOREIGN KEY(plato) REFERENCES PLATO(id)
);
GO

CREATE TABLE [dbo].[OPINION] (
    [id] INT NOT NULL PRIMARY KEY,
    [descripcion] VARCHAR(50), 
    [valoracion] FLOAT,
    [usuario] VARCHAR(20) NOT NULL,
    CONSTRAINT fk_usuario_opinion FOREIGN KEY(usuario) REFERENCES USUARIO(correo)
);
GO

CREATE TABLE [dbo].[FAVORITOS](
    [id] INT NOT NULL PRIMARY KEY,
    [usuario] VARCHAR(20) NOT NULL,
    CONSTRAINT fk_usuario_favoritos FOREIGN KEY(usuario) REFERENCES USUARIO(correo)
);
GO

CREATE TABLE [dbo].[LINPED](
    [linea] INT NOT NULL,
    [num_pedido] INT NOT NULL,
    [importe] FLOAT,
    [cantidad] FLOAT,
    [plato] INT NOT NULL, 
    CONSTRAINT pk_linped PRIMARY KEY (linea, num_pedido), -- Clave primaria compuesta
    CONSTRAINT fk_num_linped FOREIGN KEY(num_pedido) REFERENCES PEDIDO(num_pedido),
    CONSTRAINT fk_plato_linped FOREIGN KEY(plato) REFERENCES PLATO(id)
);
GO

CREATE TABLE [dbo].[PEDIDO](
    [num_pedido] INT NOT NULL PRIMARY KEY,
    [fecha] DATE,
    [usuario] VARCHAR(20) NOT NULL,
    CONSTRAINT fk_usuario_pedido FOREIGN KEY(usuario) REFERENCES USUARIO(correo)
);
GO

CREATE TABLE [dbo].[CESTA] (
    [id] INT NOT NULL PRIMARY KEY,
    [num_pedido] INT,
    CONSTRAINT fk_num_pedido_cesta FOREIGN KEY(num_pedido) REFERENCES PEDIDO(num_pedido)
);
GO

CREATE TABLE [dbo].[OPINION_RESTAURANTE](
    [cod_restaurante] INT,
    [id_opinion] INT,
    CONSTRAINT pk_opinion_restaurante PRIMARY KEY (cod_restaurante, id_opinion), -- Clave primaria compuesta
    CONSTRAINT fk_restaurante_opinion FOREIGN KEY(cod_restaurante) REFERENCES RESTAURANTE(cod),
    CONSTRAINT fk_opinion_restaurante FOREIGN KEY(id_opinion) REFERENCES OPINION(id)
);
GO

CREATE TABLE [dbo].[PLATO_OPINION](
    [id_p] INT,
    [id_o] INT,
    CONSTRAINT pk_plato_opinion PRIMARY KEY (id_p, id_o), -- Clave primaria compuesta
    CONSTRAINT fk_plato_opinion_plato FOREIGN KEY(id_p) REFERENCES PLATO(id),
    CONSTRAINT fk_plato_opinion_opinion FOREIGN KEY(id_o) REFERENCES OPINION(id)
);
GO

CREATE TABLE [dbo].[PLATO_FAVORITOS](
    [id_p] INT,
    [id_f] INT,
    CONSTRAINT pk_plato_favoritos PRIMARY KEY (id_p, id_f), -- Clave primaria compuesta
    CONSTRAINT fk_plato_favoritos_plato FOREIGN KEY(id_p) REFERENCES PLATO(id),
    CONSTRAINT fk_plato_favoritos_favoritos FOREIGN KEY(id_f) REFERENCES FAVORITOS(id)
);
GO

CREATE TABLE METODO_PAGO (
    id_metodo INT PRIMARY KEY,
    tipo VARCHAR(20), 
    numero_tarjeta VARCHAR(20), 
    fecha_vencimiento DATE, 
    usuario_correo VARCHAR(20), 
    FOREIGN KEY (usuario_correo) REFERENCES USUARIO(correo)
);


