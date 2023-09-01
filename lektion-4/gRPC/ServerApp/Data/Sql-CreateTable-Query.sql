CREATE TABLE Customers (
	Id int not null identity primary key,
	Name nvarchar(50) not null,
	Email nvarchar(100) not null unique,
	PhoneNumber nvarchar(50) null
)