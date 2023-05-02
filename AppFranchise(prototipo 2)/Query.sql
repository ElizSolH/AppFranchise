---Nombre de base de datos: AppFranchise2
--Nombre del autor: Solís Hernández Elizabeth
--Nombre del programa: AppFranchise (Prototipo 2)
--Descripción del programa: Segundo prototipo del software de control de franquicias, empleados y pedidos de la tienda Kawaii Shop
--Fecha de creación: 18 de octubre del 2016
--Versión: 1.0
Create database AppFranchise2
go
use AppFranchise2
go
---Tablas de acuerdo al modelo Entidad-Relación
Create table Empleados
(ID_Empleado int identity (1,1) primary key not null,
Nombre_Emp varchar (50) unique not null,
Edad_Emp int,
Contraseña_Emp varchar (10) not null,
Rol_Emp varchar (30) not null,
Usuario_Emp varchar (20) unique not null)
go
Create table Franquicias
(ID_Franquicia int identity (1,1) primary key not null,
Direccion_franq varchar (50) not null,
Telefono_franq varchar (15),
Pais_franq varchar (15)not null)
go
Create table Clientes
(ID_Cliente int identity (1,1) primary key not null,
Nombre_cli varchar (50) unique not null,
Telefono_cli varchar (15),
ID_Franquicia int foreign key (ID_Franquicia) references Franquicias (ID_Franquicia) not null)
go
Create table Pedidos
(ID_Pedido int identity (1,1) primary key not null,
Fecha_pedido date not null,
Fecha_envio date,
Fecha_recibo date,
Estado varchar (15),
Cantidad int not null,
Producto varchar (25) not null,
Medida varchar (15) not null,
Monto money not null,
ID_Empleado int foreign key (ID_Empleado) references Empleados (ID_Empleado) not null,
ID_Cliente int foreign key (ID_Cliente) references Clientes (ID_Cliente) not null)
go
Create table Historial
(Id_historial int identity (1,1) primary key not null,
Fecha_pedido date not null,
Fecha_accion date not null,
Accion varchar(20) not null)
go
--Registros:
INSERT INTO Empleados values ('Sofia',25,'123','Gerente General','sofi')
go
---=====================================PROCEDIMIENTOS ===============================
-------Añadir empleados:
Create proc spu_añadir_empleados
@nombre varchar (50),@edad int, @contra varchar (10), @rol varchar (15),@usuario varchar (20)
AS
BEGIN
	SET NOCOUNT ON;
		INSERT INTO Empleados values (@nombre,@edad,@contra,@rol,@usuario)
END
go
Exec spu_añadir_empleados @nombre = 'Elizabeth',@edad = 19,@contra = '123',@rol = 'Vendedor',@usuario = 'YNM'
Exec spu_añadir_empleados @nombre = 'Pedro',@edad = 21,@contra = '123',@rol = 'Gerente General',@usuario = 'nenuco'
go
---------Procedimiento para evaluar si está correcto usuario y contraseña
Create proc spu_logeo
@usuario varchar(20),@contra varchar (10),@rol varchar(15)
AS
BEGIN
	SET NOCOUNT ON;
	Select count (*) from Empleados where Usuario_emp= 'YNM' and Contraseña_emp = '123' and Rol_emp='Vendedor'
END
go
---------Obtener el nombre del empleado:
Create proc spu_nombre_empleado
@usuario varchar (20),@rol varchar (20)
AS
BEGIN
	SET NOCOUNT ON;
		Select Nombre_Emp from Empleados where  Usuario_Emp = @usuario and Rol_Emp = @rol
END
GO
EXEC spu_nombre_empleado 'YNM','Vendedor'
GO
---------Eliminar empleados 
Create proc spu_delete_empleados
@usuario varchar (20)
AS
BEGIN
	SET NOCOUNT ON;
DELETE FROM Empleados where Usuario_Emp=@usuario
END
go
Exec spu_delete_empleados @usuario = 'YNM'
go
---------Modificar empleados
Create proc spu_modificar_empleados
@nombre varchar (20),@edad int , @psw varchar (10),@usu varchar (20),@id int
AS
BEGIN
	SET NOCOUNT ON;
UPDATE Empleados set Edad_Emp=@edad,Contraseña_Emp=@psw ,Nombre_Emp=@nombre where ID_Empleado = @id
END
go
Exec spu_modificar_empleados @nombre = '',@edad = 1,@psw='',@usu = '',@id=1
go
-------Obtener los datos de un empleado:
Create proc spu_datos_empleado
@nombre varchar (20),@edad int, @rol varchar(20)
AS
	BEGIN
	SET NOCOUNT ON;
	Select * from Empleados where Nombre_Emp = @nombre and Edad_Emp = @edad and Rol_Emp = @rol
	END
go
Exec spu_datos_empleado '',1,''
go
-----Obtener la edad del empleado:
Create proc spu_edad_empleado
@usuario varchar (20),@rol varchar(20)
AS
	BEGIN
	SET NOCOUNT ON;
	Select Edad_Emp from Empleados where Usuario_Emp = @usuario and Rol_Emp = @rol
	END
go
Exec spu_edad_empleado '',''
go
-------Añadir franquicias:
Create proc spu_añadir_franquicias
@direccion varchar (50),@telefono varchar(15), @pais varchar (15)
AS
BEGIN
	SET NOCOUNT ON;
INSERT INTO Franquicias values (@direccion,@telefono,@pais)
END
go
Exec spu_añadir_franquicias @direccion = 'Apurímac',@telefono = '2397348912',@pais = 'Perú'
go
-------Modificar franquicias
Create proc spu_modificar_franquicias
@direccion varchar (50),@telefono varchar(15), @pais varchar (15),@ID int
AS
BEGIN
	SET NOCOUNT ON;
UPDATE Franquicias SET Direccion_franq=@direccion,Telefono_franq=@telefono,Pais_franq=@pais WHERE ID_Franquicia=@ID
END
go
Exec spu_modificar_franquicias @direccion = 'Lima',@telefono = '2397348912',@pais = 'Perú', @id = 1
go
-------Eliminar franquicias
Create proc spu_eliminar_franquicias
@ID int
AS
BEGIN
	SET NOCOUNT ON;
DELETE FROM Franquicias where ID_Franquicia = @ID
END
go
Exec spu_eliminar_franquicias @id=1
go
-------Obtener los datos de una franquicia específica
Create proc spu_franquicia_datos
@dir varchar (50),@pais varchar (15)
AS
BEGIN
SET NOCOUNT ON;
Select * FROM Franquicias where Direccion_franq = @dir and Pais_franq = @pais
END
GO
Exec spu_franquicia_datos 'Lima','Perú'
go
------Obtener datos de una franquicia a partir del ID
Create proc spu_datos_franq_id
@id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Franquicias where ID_Franquicia=@id
END
GO
Exec spu_datos_franq_id 1
go
GO
-------Añadir Clientes
Create proc spu_añadir_clientes
@nombre varchar (50),@telefono varchar(15), @franquicia int
AS
BEGIN
	SET NOCOUNT ON;
INSERT INTO Clientes values (@nombre,@telefono,@franquicia)
END
go
Exec spu_añadir_clientes @nombre = 'Karolina Rojas',@telefono = '2397348912',@franquicia = 1
Exec spu_añadir_clientes @nombre = 'Juan José',@telefono = '2397323019',@franquicia = 1
go
-------Modificar Clientes
Create proc spu_modificar_clientes
@nombre varchar (50),@telefono varchar(15), @franquicia int
AS
BEGIN
	SET NOCOUNT ON;
UPDATE Clientes SET Telefono_cli = @telefono,ID_Franquicia = @franquicia where Nombre_cli=@nombre
END
go
select * from clientes
Exec spu_modificar_clientes @nombre = '',@telefono = '',@franquicia =1
go
-------Eliminar Clientes
Create proc spu_eliminar_clientes
@id varchar (50)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Pedidos where ID_Cliente = @id
DELETE FROM Clientes where ID_Cliente = @id
END
go
Exec spu_eliminar_clientes 
go
-------Obtener los datos de los clientes 
Create proc spu_datos_cliente
@nombre varchar (50),@id int
AS
	BEGIN
	SET NOCOUNT ON;
	Select * from Clientes where Nombre_cli = @nombre and ID_Franquicia=@id
END
GO
Exec spu_datos_cliente 'Pedro Rodríguez',2
GO
-------Seleccionar la franquicia a la que pertenece el cliente
Create proc spu_cliente_franquicia
@nombre varchar (50)
AS
	BEGIN 
	SET NOCOUNT ON;
	SELECT f.Direccion_franq,f.Pais_franq FROM Clientes c INNER JOIN Franquicias f on c.ID_Franquicia = f.ID_Franquicia WHERE c.Nombre_cli = @nombre
	END
GO
exec spu_cliente_franquicia 'Eli'
go
-----Obtener el id del cliente por nombre
Create proc spu_cliente_id
@nombre varchar(50)
AS
	BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Clientes where Nombre_cli=@nombre
	END
GO
Exec spu_cliente_id 'Pedro Rodríguez'
go
------Obtener la dirección y país de la franquicia que representa el cliente especificado
Create proc spu_destino_cliente
@id int
AS
	BEGIN
	SET NOCOUNT ON;
	SELECT f.Direccion_franq,f.Pais_franq FROM Franquicias f INNER JOIN Clientes c on c.ID_Franquicia=f.ID_Franquicia WHERE c.ID_Cliente=@id
	END
GO
Exec spu_destino_cliente 1
GO
-------Seleccionar lo clientes o representantes de una franquicia en específico
Create proc spu_representa_franquicia
@id int
AS
	BEGIN 
	SET NOCOUNT ON;
	SELECT c.ID_Cliente,c.Nombre_cli, c.Telefono_cli,c.ID_Franquicia FROM Clientes c INNER JOIN Franquicias f on c.ID_Franquicia = f.ID_Franquicia WHERE f.ID_Franquicia = @id
	END
GO
exec spu_representa_franquicia 1
go
-------Añadir pedidos
Create proc spu_añadir_pedidos
@fpedido date, @cantidad int,@producto varchar (25),@medida varchar (15),@monto money,@empleado int,@cliente int
AS
BEGIN
	SET NOCOUNT ON;
INSERT INTO Pedidos values (@fpedido,null,null,null,@cantidad,@producto,@medida,@monto,@empleado,@cliente)
END
go
Exec spu_añadir_pedidos @fpedido = '01/10/16', @cantidad=3,@producto='Polo Rilakkuma',@medida='piezas',@monto=1200,@empleado=1,@cliente=2
go
------Modificar pedido recien solicitado
Create proc spu_modificar_pedidos
@cantidad int,@producto varchar (25),@medida varchar (15),@monto money,@ped int
AS
BEGIN
	SET NOCOUNT ON;
UPDATE Pedidos set Cantidad=@cantidad,Medida=@medida,Monto=@monto,Producto=@producto where ID_Pedido=@ped
END
go
Exec spu_modificar_pedidos 2,'producto','medida',234,1
go
----Cancelar un pedido
Create proc spu_eliminar_pedido
@id int
AS
BEGIN 
	SET NOCOUNT ON;
	DELETE FROM Pedidos where ID_Pedido=@id
END
go
Exec spu_eliminar_pedido 1
go
----Mostrar datos de un pedido
Create proc spu_mostrar_pedidos
@id int
AS
BEGIN
	SET NOCOUNT ON;
select * from Pedidos where ID_Pedido=@id
END
go
exec spu_mostrar_pedidos 1
go
---Buscar un pedido por fecha
Create proc spu_Pedido_Fecha
@fecha date
AS
BEGIN
	SET NOCOUNT ON;
	select * from vista_recibo where Enviado =@fecha or Recibido = @fecha or Solicitado = @fecha
END
go
exec spu_Pedido_Fecha '12/11/16'
go
-------Añadir fecha de envío de un pedido ya registrado
Create proc spu_añadir_envio
@numPed int,@fenvio date
AS
BEGIN
	SET NOCOUNT ON;											
	if exists (select * from Pedidos where ID_Pedido=@numPed)
	BEGIN
		UPDATE Pedidos set Fecha_envio=@fenvio where ID_Pedido=@numPed
	END
END
go
Exec spu_añadir_envio @numPed=2,@fenvio='01/12/16'
go
------Añadir fecha de recibo de un pedido ya enviado
Create proc spu_añadir_recibo
@numPed int,@frecibo date,@estado varchar
AS
BEGIN
	SET NOCOUNT ON;											
	if (select ID_Pedido from Pedidos where ID_Pedido=@numPed)>0
	BEGIN
		UPDATE Pedidos set Fecha_recibo=@frecibo,Estado=@estado where ID_Pedido=@numPed
	END
END
go
Exec spu_añadir_recibo @numPed=2,@frecibo='12/12/16',@estado=''
go

--===================================================VISTAS===========================================================================
--Empleados:
Create view vista_empleados(Nombre,Edad,Puesto)
AS
Select Nombre_Emp,Edad_Emp,Rol_Emp FROM Empleados 
GO
Select * from vista_empleados
GO
--Franquicias:
Create view vista_franquicias(Dirección,País,Teléfono)
AS
Select Direccion_franq,Pais_franq,Telefono_franq FROM Franquicias
GO
Select * from vista_franquicias
go
--Puestos:
Create view vista_puestos(Puesto)
AS
Select distinct(Rol_Emp) FROM Empleados 
GO
Select * from vista_puestos
GO
--Clientes:
Create view vista_clientes(Nombre,Telefono)
AS
Select Nombre_cli,Telefono_cli FROM Clientes 
GO
SELECT * FROM vista_clientes
GO
--Pedidos registrados:
Create view vista_pedidos(Producto,Unidad_Medida,Cantidad,Monto,Fecha)
AS
Select Producto,Medida,Cantidad,Monto,Fecha_pedido FROM Pedidos where Fecha_envio is null and Fecha_recibo is null
GO
Select * from vista_pedidos
GO
--Pedidos registrados con su destino:
Create view vista_pedidos_destino(Num_pedido,Direccion,Pais,Producto,Unidad_Medida,Cantidad,Monto,Fecha)
AS
Select p.ID_Pedido,f.Direccion_franq,f.Pais_franq, p.Producto,p.Medida,p.Cantidad,p.Monto,p.Fecha_pedido 
FROM Pedidos p 
INNER JOIN Clientes c 
on p.ID_Cliente = c.ID_Cliente 
INNER JOIN Franquicias f
on c.ID_Franquicia = f.ID_Franquicia
where Fecha_envio is null and Fecha_recibo is null
GO
Select * from vista_pedidos_destino
GO
--Pedidos enviados:
Create view vista_envios(Num_Pedido,Producto,Unidad_Medida,Cantidad,Monto,Solicitado,Enviado,Direccion,Pais)
AS
Select p.Id_Pedido,p.Producto,p.Medida,p.Cantidad,p.Monto,p.Fecha_pedido,p.Fecha_envio,f.Direccion_franq,f.Pais_franq
FROM Pedidos p
INNER JOIN Clientes c
on c.ID_Cliente = p.ID_Cliente
INNER JOIN Franquicias f
on f.ID_Franquicia =c.ID_Franquicia
where Fecha_recibo is null and Fecha_envio is not null
GO
Select * from vista_envios
go
--Pedidos recibidos:
Create view vista_recibo(Producto,Unidad_Medida,Cantidad,Monto,Solicitado,Enviado,Recibido)
AS
Select Producto,Medida,Cantidad,Monto,Fecha_pedido,Fecha_envio,Fecha_recibo FROM Pedidos where Fecha_recibo is not null
GO
Select * from vista_recibo

GO
---Historial de movimientos
Create view vista_historial(Fecha_pedido,Fecha_movimiento,Tipo_movimiento)
AS
Select Fecha_pedido,Fecha_accion,Accion FROM Historial
GO
select * from vista_historial
GO
--=======================================================TRIGGERS=======================================================
---Añadir al historial el movimiento que se realice en la tabla Pedidos
----Al registrar
CREATE TRIGGER tg_Historial_Pedidos_Registro
ON Pedidos
 AFTER INSERT AS
 BEGIN
	--Se registra el movimiento en el historial
	INSERT INTO Historial values ((SELECT Fecha_pedido from inserted),GETDATE(),'Registro')
END
GO
----Al modificar
CREATE TRIGGER tg_Historial_Pedidos_Modif
ON pedidos
AFTER INSERT AS
BEGIN
	INSERT INTO Historial values((Select fecha_pedido from inserted),getdate(),'Modificación')
END
GO
----Al eliminar
CREATE TRIGGER tg_Historial_Pedidos_Elimina
ON pedidos
AFTER DELETE AS
BEGIN
	INSERT INTO Historial values((Select fecha_pedido from inserted),getdate(),'Eliminación')
END
GO
----Al registrar envío
CREATE TRIGGER tg_Historial_Pedidos_Envio
ON pedidos
AFTER UPDATE AS
IF UPDATE(Fecha_envio)
BEGIN
	INSERT INTO Historial values((Select fecha_pedido from inserted),getdate(),'Envio')
END
GO
----Al registrar entrega
CREATE TRIGGER tg_Historial_Pedidos_Entrega
ON pedidos
AFTER UPDATE AS
IF UPDATE(Fecha_recibo)
BEGIN
	INSERT INTO Historial values((Select fecha_pedido from inserted),getdate(),'Entrega')
END
GO
exec spu_añadir_pedidos @fpedido = '11/21/16', @cantidad=4,@producto='Medias',@medida='piezas',@monto=1200,@empleado=1,@cliente=2
select * from Historial
exec spu_modificar_pedidos 10,'Medias','piezas',1500,3