create database mvc_test;

use mvc_test;

create table mvc_table(
id int primary key,
name_user varchar(50),
email varchar(50),
birthday datetime);

insert into mvc_table values(1,'Edu', 'skeg@gmail.com', '2000/02/01');

select * from mvc_table;