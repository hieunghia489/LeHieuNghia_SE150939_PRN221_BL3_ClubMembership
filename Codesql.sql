
go
Create database ClubMembership;
go
use ClubMembership;
Create table Major(
Id int identity(1,1) primary key,
Code nvarchar(10) unique not null,
Name nvarchar(100) unique not null,
Description nvarchar(200) not null,
Status bit default 1
);

insert Major (Code,Name,Description) values ('SE','Software Enginner','Coder IT'); 
insert Major (Code,Name,Description) values ('MK','Marketing Global','Maketing'); 

go 
Create table Grade(
Id int identity(1,1) primary key,
Code nvarchar(10) unique not null,
Description nvarchar(255) not null,
StartDate datetime not null,
EndDate datetime,
Status bit default 1
);
insert Grade(Code,Description,StartDate,EndDate) values ('K15','Group student K15','2020-1-1','2024-1-1');
insert Grade(Code,Description,StartDate,EndDate) values ('K16','Group student K16','2021-1-1','2025-1-1');


go

create table Student(
Id int identity(1,1) primary key,
Code nvarchar(10) unique not null,
Name nvarchar(100) not null,
Gender bit not null,
Birthday datetime not null,
Image nvarchar(100),
DateEnroll datetime not null,
MajorId int foreign key references Major(Id),
GradeId int foreign key references Grade(Id),
Status bit default 1
);
insert Student(Code,Name,Gender,Birthday,DateEnroll,MajorId,GradeId) values ('SE150001','Nguyen Van A',1,'2001-1-1','2020-1-1',1,1);
insert Student(Code,Name,Gender,Birthday,DateEnroll,MajorId,GradeId) values ('SE150002','Nguyen Van B',1,'2001-2-2','2020-1-1',1,1);
insert Student(Code,Name,Gender,Birthday,DateEnroll,MajorId,GradeId) values ('SE150003','Le Thi C',0,'2002-1-1','2021-1-1',2,2);
insert Student(Code,Name,Gender,Birthday,DateEnroll,MajorId,GradeId) values ('SE150004','Tran Van D',1,'2002-1-1','2021-1-1',1,2);
insert Student(Code,Name,Gender,Birthday,DateEnroll,MajorId,GradeId) values ('SE150005','Pham Thi E',0,'2001-1-1','2020-1-1',2,1);


create table Club(
Id int identity(1,1) primary key,
Code nvarchar(10) unique not null,
Name nvarchar(100) unique not null,
Description nvarchar(200) not null,
CreateDate datetime not null,
Logo nvarchar(100),
Status bit default 1
);
insert Club(Code,Name,Description,CreateDate) values ('CSG','Coc Sai Gon','Social Club','2018-1-1');
insert Club(Code,Name,Description,CreateDate) values ('EFC','English Fun Club','English Club','2019-1-1');
create table Membership(
Id int identity(1,1) primary key,
Code nvarchar(255) not null unique,
StudentId int foreign key references Student(Id),
ClubId int foreign key references Club(Id),
JoinDate datetime not null,
LeaveDate datetime,
Status bit default 1
);
insert Membership(Code,StudentId,ClubId,JoinDate) values ('CSG001',1,1,'2020-1-1');
insert Membership(Code,StudentId,ClubId,JoinDate) values ('CSG002',2,1,'2021-1-1');
insert Membership(Code,StudentId,ClubId,JoinDate) values ('CSG003',3,1,'2021-1-1');
insert Membership(Code,StudentId,ClubId,JoinDate) values ('CSG004',4,1,'2021-1-1');
insert Membership(Code,StudentId,ClubId,JoinDate) values ('EFC001',5,2,'2021-1-1');

create table ClubBoard(
Id int identity(1,1) primary key,
ClubId int foreign key references Club(Id),
Semester nvarchar(100) not null,
StartSemester Datetime not null,
EndSemester datetime,
Status bit default 1
);
 insert ClubBoard (ClubId,Semester,StartSemester,EndSemester) values (1,'Summer2022','2022-5-5','2022-9-9');

 Create table GroupMember(
 Id int identity(1,1) primary key,
 Role Nvarchar(255) not null default 'Member',
 Status bit default 1,
 MembershipId int foreign key references Membership(Id),
 ClubBoardId int foreign key references ClubBoard(Id)
 );
 insert GroupMember (Role,MembershipId,ClubBoardId) values ('Leader',1,1);
  insert GroupMember (Role,MembershipId,ClubBoardId) values ('Member',2,1);
   insert GroupMember (Role,MembershipId,ClubBoardId) values ('Member',3,1);
    insert GroupMember (Role,MembershipId,ClubBoardId) values ('Member',4,1);
 create table ClubActivity(
 Id int identity(1,1) primary key,
ClubId int foreign key references Club(Id),
Title nvarchar(100) not null,
Description nvarchar(100) not null,
StartDate datetime not null,
EndDate datetime,
Status bit default 1
 );
 insert ClubActivity (ClubId,Title,Description,StartDate,EndDate) values(1,'Meeting','Meeting new member','2022-1-1','2022-1-2');
 create table Participant(
  Id int identity(1,1) primary key,
  MembershipId int foreign key references Membership(Id),
  ClubActivityId int foreign key references ClubActivity(Id),
  Attend bit default 1,
  Mission nvarchar(100) not null default 'Nothing',
  JoinDate datetime not null,
  Status bit default 1
 );
 insert Participant (MembershipId,ClubActivityId,Attend,Mission,JoinDate) values (1,1,1,'Cleaning','2022-1-1');
  insert Participant (MembershipId,ClubActivityId,Attend,Mission,JoinDate) values (2,1,1,'Cooking','2022-1-1');
   insert Participant (MembershipId,ClubActivityId,Attend,Mission,JoinDate) values (3,1,1,'Sleeping','2022-1-1');
    insert Participant (MembershipId,ClubActivityId,Attend,Mission,JoinDate) values (4,1,1,'Relaxing','2022-1-1');
	select * from Membership
