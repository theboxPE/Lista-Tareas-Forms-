create database lista
go

use lista 
go

create table cliente
(
codigo varchar(5),
titulo varchar(50),
descri varchar(100)
);
go

create proc sp_listar
as
select * from cliente order by codigo
go

create proc sp_buscar
@titulo varchar(50)
as 
select codigo, titulo, descri from cliente where titulo like @titulo + '%'
go

create proc sp_mantenimiento
@codigo varchar(5),
@titulo varchar(50),
@descri varchar(100),
@accion varchar(50) output
as
if(@accion='1')
begin
	declare @codnuevo varchar(5), @codmax varchar(5)
	set @codmax = (select max(codigo) from cliente)
	set @codmax = ISNULL(@codmax, 'A0000')
	set @codnuevo = 'A'+RIGHT(RIGHT(@codmax, 4)+10001, 4)
	insert into cliente(codigo,titulo,descri)
	values(@codnuevo,@titulo,@descri)
	set @accion ='Se genero el codigo: ' +@codnuevo 
end
else if(@accion= '2')
begin
	update cliente set titulo=@titulo, descri=@descri where codigo=@codigo
	set @accion= 'Se modifico el codigo: ' +@codigo
end
else if(@accion= '3')
begin
	delete from cliente where codigo=@codigo
	set @accion= 'Se borro el codigo: ' +@codigo
end
go

