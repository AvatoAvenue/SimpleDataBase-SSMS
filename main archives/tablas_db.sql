CREATE DATABASE topicos_farmacias
USE topicos_farmacias

CREATE TABLE ciudades(
id_ciudad INT PRIMARY KEY NOT NULL,
nombre VARCHAR (50),
estado VARCHAR (50),
superficie VARCHAR (50),
poblacion VARCHAR(50)
)

CREATE TABLE propietarios(
id_propietario INT PRIMARY KEY NOT NULL,
nombre VARCHAR (50),
ciudad VARCHAR (50),
calle VARCHAR (50),
numero_calle VARCHAR (20),
cp VARCHAR(20)
)

CREATE TABLE farmacias(
id_farmacia INT PRIMARY KEY NOT NULL,
nombre VARCHAR (50),
telefono VARCHAR (20),
domicilio VARCHAR (50),
id_ciudad INT,
FOREIGN KEY (id_ciudad) REFERENCES ciudades (id_ciudad),
id_propietario INT,
FOREIGN KEY (id_propietario) REFERENCES propietarios (id_propietario)
)

CREATE TABLE clientes(
id_cliente INT PRIMARY KEY NOT NULL,
nombre VARCHAR (50),
telefono VARCHAR (20),
correo VARCHAR (50),
calle VARCHAR (50),
numero_calle VARCHAR (20),
cp VARCHAR (20),
rfc VARCHAR (20)
)

CREATE TABLE tickets(
id_ticket INT PRIMARY KEY NOT NULL,
fecha VARCHAR (50),
hora VARCHAR (20),
costo_total VARCHAR (50),
id_cliente INT,
FOREIGN KEY (id_cliente) REFERENCES clientes (id_cliente)
)

CREATE TABLE medicamentos (
id_medicamento INT PRIMARY KEY NOT NULL,
nombre VARCHAR (50),
componentes VARCHAR (20),
comercial VARCHAR (20)
)
CREATE TABLE detalles_medicamentos(
id_farmacia INT,
id_medicamento INT,
PRIMARY KEY (id_farmacia,id_medicamento),
FOREIGN KEY (id_farmacia) REFERENCES farmacias (id_farmacia),
FOREIGN KEY (id_medicamento) REFERENCES medicamentos (id_medicamento)
)
CREATE TABLE detalles_compras(
id_ticket INT,
id_medicamento INT,
PRIMARY KEY (id_ticket,id_medicamento),
FOREIGN KEY (id_ticket) REFERENCES tickets (id_ticket),
FOREIGN KEY (id_medicamento) REFERENCES medicamentos (id_medicamento)
)