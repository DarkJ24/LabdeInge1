CREATE TABLE Clientes(
cedula char(9),
nombre varchar(255) not null,
apellido1 varchar(255),
apellido2 varchar(255),
correo varchar(255),
direccion varchar(255),
PRIMARY KEY(cedula)
);

CREATE TABLE Telefonos(
cliente char(9),
numero char(8),
PRIMARY KEY(cliente, numero),
FOREIGN KEY (cliente) REFERENCES Clientes(cedula)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

CREATE TABLE Cuentas(
cliente char(9),
tipo int default 1,
numero char(10),
PRIMARY KEY(cliente, numero),
FOREIGN KEY (cliente) REFERENCES Clientes(cedula)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);