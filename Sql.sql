create database TestDb

use TestDb

---table---
Create table Userdata(
Id int Primary Key Identity (1,1),
Name VarChar (200),
Email varchar(150),
Mobile varchar(250),
City varchar(25)
);
---table end---

---procedure insert---
alter procedure AddUser(
@Name varchar (200),
@Email varchar(150),
@Mobile varchar(250),
@City varchar(25)
)
as
begin 
insert into Userdata(Name,Email,Mobile,City) values(@Name,@Email,@Mobile,@City)
end
---procedure insert end---


---procedure Retrieve---
create procedure getUser
as
begin 
select * from Userdata
end
---procedure Retrieve end---

---procedure update---
create procedure UpdateUser(
@Id int,
@Name varchar (200),
@Email varchar(150),
@Mobile varchar(250),
@City varchar(25)
)
as
begin
update Userdata set Name=@Name, Email=@Email, Mobile=@Mobile, City=@City where Id=@Id
end 
---procedure update end---

---procedure delete---
create procedure Deleteuser(
@Id int
)
as
begin
delete from Userdata where Id=@Id
end
---procedure delete end---

insert into UserTable values('raj','verma','bera','kawardha');


select * from Userdata