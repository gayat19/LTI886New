create database dbTraining

use dbTraining

create table tbl_Doctor
( id int identity(1,1) primary key,
  name varchar(20),
  years_of_exp float
)

alter proc proc_Update_Doctor_Exp(@did int, @exp float)
as
begin
    update tbl_Doctor set years_of_exp= round(@exp,2) where id = @did
end


create proc proc_Insert_Doctor(@dname varchar(20), @exp float)
as
begin
    Insert into tbl_Doctor(name,years_of_exp) values(@dname,@exp)
end

create proc proc_Delete_Doctor(@did int)
as
begin
    delete from tbl_Doctor where id = @did
end

exec proc_Insert_Doctor 'Rita', 12.1
exec proc_Insert_Doctor 'Sita', 2.5
exec proc_Insert_Doctor 'Mala', 10

select * from tbl_Doctor

create table tbl_Patient
(id int identity(1,1) primary key,
name varchar(20),
phone varchar(20),
remarks varchar(100))

select * from tbl_Patient
drop table tbl_appointment


create table tbl_appointment
(app_id int identity(101,1) primary key,
docid int references tbl_doctor(id),
patient_id int references tbl_patient(id),
app_date date,
app_time int)


