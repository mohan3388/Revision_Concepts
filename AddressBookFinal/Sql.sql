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
select * from AddressBook

create table AddressBook(
Id int primary key Identity(1,1),
FirstName varchar(255),
LastName varchar(255),
Email varchar(255),
Mobile varchar(255),
Address varchar(255),
City varchar(255),
State varchar(255),
Pincode varchar(255)
)

alter procedure SpAddressBook(
@FirstName varchar(255),
@LastName varchar(255),
@Email varchar(255),
@Mobile varchar(255),
@Address varchar(255),
@City varchar(255),
@State varchar(255),
@Pincode varchar(255)
)
as
begin
insert into AddressBook values(@FirstName,@LastName,@Email,@Mobile,@Address,@City,@State,@Pincode)
end


create procedure SpgetAddressBook
as
begin
select * from AddressBook
end

create procedure SpUpdateAddressBook(
@Id int,
@FirstName varchar(255),
@LastName varchar(255),
@Email varchar(255),
@Mobile varchar(255),
@Address varchar(255),
@City varchar(255),
@State varchar(255),
@Pincode varchar(255)
)
as
begin
update AddressBook set FirstName=@FirstName, LastName=@LastName, Email=@Email, Mobile=@Mobile, Address=@Address, City=@City, State=@State, Pincode=@Pincode where Id=@Id;
end