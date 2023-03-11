--Se llama la Base de Datos que se usará
use CatalogoZapatosBD

--insertar datos en las tablas de nuestra Base de Datos mediante el comando DML Insert
insert into Genero(Nombre) values
('Masculino');
insert into Genero(Nombre) values
('Femenino');

insert into Marca(Nombre) values
('Nike');
insert into Marca(Nombre) values
('Puma');
insert into Marca(Nombre) values
('Adidas');

insert into Proveedor(NombreEmpresa, Direccion,Telefono, Movil, Correo) values
('Nike Ic', 'New York', '24515891', '+1 65432198', 'NikeIcNW@hotmail.com');
insert into Proveedor(NombreEmpresa, Direccion,Telefono, Movil, Correo) values
('Puma SE', 'California', '24515891', '+1 65432198', 'PumaSEC@hotmail.com');
insert into Proveedor(NombreEmpresa, Direccion,Telefono, Movil, Correo) values
('Adidas AG', 'Newells', '24515891', '+1 65432198', 'AdidasAG@hotmail.com');

insert into Producto(Nombre, Color, Talla, Precio, Descripcion, MarcaID, ProveedorID, GeneroID ) values
('Nike Jordan A1', 'rojo c/blanco', '38-39-40-41', '$120.00','sin descripcion', '1', '1', '1');
insert into Producto(Nombre, Color, Talla, Precio, Descripcion, MarcaID, ProveedorID, GeneroID ) values
('Nike Air force', 'rojo c/blanco', '38-39-40-41', '$120.00','sin descripcion', '1', '1', '2');
insert into Producto(Nombre, Color, Talla, Precio, Descripcion, MarcaID, ProveedorID, GeneroID ) values
('Adidas samba', 'rojo c/blanco', '38-39-40-41', '$120.00','sin descripcion', '3', '3', '1');

insert into Administracion (Nombre, CodigoEmpleado, Clave) values
('Juan Arnulfo', 'sm222', '1234')

--Comando Select para consultar una tabla
select * from Genero
select * from Marca
select * from Producto
select * from Administracion
select * from Producto

--Comando Update para modificar los datos de los registros de una tabla
update Administracion set Nombre = 'Jonathan Morán'
where Id=1

--Comando Delete para eliminar registros de una tabla
Delete from Producto
where Id=3

