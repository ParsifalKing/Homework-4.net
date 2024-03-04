create table Stores
(
    Id serial primary key,
	StoreName varchar(100),
	Address varchar(200)
);

create table Products
(
    Id serial primary key,
	ProductName varchar(100),
	Quantity int
);

create table Store_Product
(
    StoreId int references Stores(Id),
	ProductId int references Products(Id),
	Quantity int
);

create table Movements
(
    Id serial primary key,
	ProductId int references Products(Id) not null,
	FromStore int references Stores(Id) not null,
	ToStore int references Stores(Id) not null,
	Quantity int,
	DateOfMovement date
);

insert into Products(ProductName,Quantity) values('Pepsi',16),('Lay''s',10),('Cake',8),('banana',2)
insert into Stores(StoreName,Address) values('Centre store','Dushanbe'),('store 2','Dushanbe'),('Bokhtar Store','Bokhtar')

insert into Movements(ProductId,FromStore,ToStore,Quantity,DateOfMovement)
values(2,1,3,1,'2024-02-25');

insert into Store_Product(StoreId,ProductId,Quantity) values(1,1,16),(1,2,6),(2,2,4),(2,3,3),(3,3,5),(3,4,2);

select * from Products
select * from Store_Product
select * from Stores
select * from Movements

