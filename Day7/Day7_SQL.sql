create table tbl_user
(username varchar(20) primary key,
password varchar(20) ,
name varchar(20))

insert into tbl_user values('ramu','1234','Ramu A')
insert into tbl_user values('somu','1111','Somu B')

create procedure proc_GetDoctorWisePatienst
as
begin
    select docid doctor_id,d.name doctor_name,p.name patient_name,p.phone patient_phone
	from tbl_appointment a join tbl_Patient p
	on a.patient_id = p.id
	join tbl_Doctor d 
	on a.docid = d.id
end
use dbCodeFirst
drop database dbCodeFirst
Create database dbCodeFirst

select * from EmployeeDetails


sp_help EmployeeDetails