use Trabajadores
go

create table Empleados
(
cod_emp char(5) primary key not null,
usr_nom varchar(50),
usr_direccion varchar(50),
fecha_ing date,
fecha_ter date,
ar_trabajo char(1)
)
go

---LISTAR---
create proc pb_listar
as
select * from Empleados
go

---REGISTRAR---

create proc pb_nuevo
@nombre varchar(50),
@direccion varchar(50),
@fechaing date,
@fechater date,
@area char(1)
as
declare @codigonuevo varchar(5)
set @codigonuevo= (select MAX(cod_emp) from Empleados)
set @codigonuevo= 'E' + RIGHT ('0000' + LTRIM (right(isnull(@codigonuevo,'0000'),4)+1),4)
insert into Empleados values (@codigonuevo,@nombre,@direccion,@fechaing,@fechater,@area)
go

---ELIMINAR---
create proc pb_eliminar
@codigo char(5)
as
delete from Empleados where cod_emp=@codigo
go

---MODIFICAR---
create proc pb_modificar
@codigo char(5),
@nombre varchar(50),
@direccion varchar(50),
@fechaing date,
@fechater date,
@area char(1)
as
update Empleados set usr_nom=@nombre,usr_direccion=@direccion,fecha_ing=@fechaing,fecha_ter=@fechater,ar_trabajo=@area 
where cod_emp=@codigo
go

---DATOS---
insert into Empleados values('E0001','VaidrollTeam','VaidrollTeam','2013-05-05','2013-10-06',2)

go

exec pb_listar
go