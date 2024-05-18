


       -- Insertar restaurantes
INSERT INTO RESTAURANTE (cod, nombre, localidad, tipo, puntuacion, u_restaurante, nif)
VALUES (1, 'Pizzeria Napoli', 'Madrid', 'italiano', 4.5,  'info@pizzerianapoli.com', 'A12345678'),
       (2, 'Sushi Zen', 'Madrid', 'japonés', 4.8,  'reservations@sushizen.com', 'B87654321'),
       (3, 'Taqueria El Vaquero', 'Barcelona', 'mexicano', 4.2, 'contact@taqueriaelvaquero.com', 'C12348765');


       -- Insertar menús
INSERT INTO MENU (restaurante, plato)
VALUES (1, 1),
       (2, 2),
       (3, 3);

       -- Insertar opiniones de restaurantes
INSERT INTO OPINION_RESTAURANTE (cod_restaurante, id_opinion)
VALUES (1, 1),
       (2, 2),
       (3, 3);