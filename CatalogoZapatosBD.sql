--Creación de Base de Datos
create database CatalogoZapatosBD

--Mandar a llamar la Base de Datos que se usará
use CatalogoZapatosBD
go

--Creación de tablas que llevará la Base de Datos usando el comando DDL "Create"
create table Marca(
Id int not null identity (1,1),
Nombre nvarchar (20) not null,
primary key (Id)
);
go
create table Genero(
Id int not null identity (1,1),
Nombre nvarchar (10) not null, 
primary key (Id)
);
go
create table Proveedor(
Id int not null identity (1,1),
NombreEmpresa nvarchar (50) not null, 
Direccion nvarchar (50) not null,
Telefono nvarchar (15),
Movil nvarchar (15) not null,
Correo nvarchar (100) not null,
primary key (Id)
);
go
create table Administracion(
Id int not null identity (1,1),
Nombre nvarchar (50) not null,
CodigoEmpleado nvarchar (5) not null,
Clave nvarchar (10) not null,
primary key (Id)
);
go
create table Producto(
Id int not null identity (1,1),
Nombre nvarchar (20) not null,
Color nvarchar (20) not null,
Talla nvarchar (50) not null,
Precio nvarchar (10) not null,
PrecioAnterior nvarchar (15),
Imagen nvarchar (300) not null,
Descripcion nvarchar (300),
ProveedorID int not null,
MarcaID int not null,
GeneroID int not null,
AdministracionID int not null,
primary key (Id),
foreign key (ProveedorID) references Proveedor (Id),
foreign key (MarcaID) references Marca (Id),
foreign key (GeneroID) references Genero (Id),
foreign key (AdministracionID) references Administracion (Id)
);

--Comando para alterar una tabla de la Base de Datos agregando una columna nueva "Alter, Add"
alter table Administracion
add Cargo varchar (10)

--Comando para alterar una tabla de la Base de Datos eliminando una columna nueva "Alter, Drop"
alter table Administracion
drop column Cargo 

----------------------------------------------------------------------------------------------------------------------







