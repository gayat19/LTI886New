create database dbHospital

use dbHospital

 --tblUser(username,password,role)
 --tblDoctor(id,name,exp,phone)
 --tblPatient(id,name,age,phone,details,status)
 --tblAppoitment(id,date,doctor_id,patient_id,time)
 create table tblUser(
 username varchar(10) primary key,
 password varchar(20),
 role varchar(10) check(role in ('doctor','patient','admin')))

 create table tblDoctor(
 id int identity(1,1) primary key,
 name varchar(20),
 years_of_exp float,
 phone varchar(20),
 username varchar(10) references tblUser(username))

  create table tblPatient(
 id int identity(101,1) primary key,
 name varchar(20),
 age int,
 phone varchar(20),
 details text,
 status varchar(10) check(status in ('active','disabled')),
 username varchar(10) references tblUser(username))


alter proc proc_LoginCheck(@un varchar(10),@pass varchar(10))
 as 
 begin
     select u.username username,role,status from tblUser u left join tblPatient p
	 on p.username=u.username
	 where u.username= @un and password=@pass
 end

insert into tblUser values('ramu','1234','doctor')
insert into tblUser values('somu','9876','doctor')
insert into tblUser values('gita','0000','patient')
insert into tblUser values('anita','1111','patient')

select * from tblDoctor
select * from tblPatient
select * from tbluser

proc_LoginCheck 'ramu','1234'