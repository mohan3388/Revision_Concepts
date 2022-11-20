create database TestDb

use TestDb

Create table Userdata(
Id int Primary Key Identity (1,1),
Name VarChar (200),
Email varchar(150),
Mobile varchar(250),
City varchar(25)
);

alter procedure AddUser(
@Name VarChar (200),
@Email varchar(150),
@Mobile varchar(250),
@City varchar(25)
)
as
begin 
insert into Userdata(Name,Email,Mobile,City) values(@Name,@Email,@Mobile,@City)
end

create procedure getUser
as
begin 
select * from Userdata
end

insert into UserTable values('raj','verma','bera','kawardha');


select * from Userdata