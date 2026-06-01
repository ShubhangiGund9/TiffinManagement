create database TiffinServiceDb
use TiffinServiceDb
Create table TblMessDetail(
                           MessId int identity Primary key,
						   MessName varchar(250),
						   OwnerName varchar(100),
						   Address varchar(500),
						   EmailAddress varchar(100),
						   Password varchar(15),
						   MobileNo varchar(15),
						   AlternativeNo varchar (15),
						   CreatedAt DateTime Default GetDate());

  Create table TblCategory(CategoryId int identity primary key,
                            CategoryName varchar(100),
							CreatedAt DateTime Default GetDate());

 Create table TblItem (ItemId int identity Primary Key ,
                       ItemName varchar(100),
					   Category int constraint fkcid references TblCategory(CategoryId),
					   Price Decimal(10,2),
					   Description varchar(500),
					   IsVegeterian Bit Default 1,
					   ItemImage varchar(500),
					   Tax float);
alter table TblItem add ItemPhoto Varchar(500);
alter table TblItem add Tax float;
					   select * from TblItem

select * from TblOrderDetail
Create table TblCustomer(CustomerId int identity Primary key,
                          CustomerName Varchar(500),
						  EmailAddress varchar(100),
						  CustomerAddress varchar(100),
						  MobileNo varchar(15),
						  Password varchar(10),
						  CreatedAt DateTime Default GetDate());
Select * from TblCustomer

Create Table TblDeliveryCharges(ChargeId int identity primary key,
                               ChargesFor varchar(100),
							   Charges Decimal(10,2));

Create table TblOrderDetail(OrderDetailId int identity primary key ,
                          Customer int constraint fkcustid references TblCustomer(CustomerId),
						  OrderStatus varchar(100),
						  PinCode varchar(10),
						  DeliveryAddress varchar(500),
						  OrderAt DateTime Default GetDate(),
						  DeliveryAt DateTime Default GetDate(),
						  TotalAmount Decimal(10,2),
						  Landmark varchar(100),
						  ExtraCharges Decimal(10,2),
						  Discount float,
						  Charge int constraint fkchid references TblDeliveryCharges(ChargeId));
select * from TblOrderDetail
Create Table TblOrderItem(OrderItemId int identity primary key,
                       Quantity int not null,
					   OrderDetail int constraint fkC1id references TblOrderDetail(OrderDetailId),
					   Item int constraint FkIid references TblItem(ItemId));
drop table TblOrderItem
Create table TblPayment( PaymentId int identity primary key,
                         OrderDetail int constraint fkODid references TblOrderDetail(OrderDetailid),
						 paymentAt DateTime Default GetDate(),
						 PatymentMode varchar(50),
						 paymentDescription varchar(200),
						 TotalAmount  decimal(10,2));

Create Table TblSpecialMenuThali( ThaliId int identity primary key,
                                 Title varchar(150),
								 Date DateTime Default GetDate(),
								 Amount Decimal(10,2),
								 Discount Decimal(10,2));


Create Table TblMenuthaliItem(ThaliItemId int identity primary key,
                               Thali int constraint fkTid references TblSpecialMenuThali(ThaliId),
							   Item int constraint fkI1id references TblItem(ItemId),
							   Quantity int);
							   
							   select * from TblCustomer
alter table TblCustomer
alter column Password nvarchar(100)
alter table TblCustomer
add Id nvarchar(450)
alter table TblCustomer add constraint FK_Customer_AspNetUsers foreign key(Id) references AspNetUsers(Id)