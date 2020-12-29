create database dbWebAPI
use dbWebAPI

create table Customer
(id int identity(1,1) primary key,
name varchar(20),
age int)

insert into Customer(name,age) values('Ramu',22)
insert into Customer(name,age) values('Somu',21)
insert into Customer(name,age) values('Bimu',32)
insert into Customer(name,age) values('Domu',29)

select * from Customer
