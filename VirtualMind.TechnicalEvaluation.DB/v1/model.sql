if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UserInformation]'))
begin
	create table dbo.UserInformation  (
		id int primary key identity (1, 1),
		firstname nvarchar(30) not null,
		lastname nvarchar(30) not null,
		birthdate datetime,
		age int,
		dni nvarchar(30) not null,
		ts datetime not null,
	);
end
go

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UserTransaction]'))
begin
	create table dbo.UserTransaction  (
		id int primary key identity (1, 1),
		idUsuario int not null FOREIGN KEY REFERENCES UserInformation(id),
		amount nvarchar(20) not null,
		isoCurrency nvarchar(20) not null,
		price nvarchar(20) not null,
		ts datetime not null,
	);
end
go