--day 7 


--1

use ITI;

create view V_StudentCourse
as
select concat(s.St_Fname,' ',s.St_Lname) as StudentFullName,c.Crs_Name
from Student s
inner join Stud_Course sc on s.St_Id = sc.St_Id
inner join Course c on sc.Crs_Id = c.Crs_Id
where sc.Grade > 50
go
--test
select * from V_StudentCourse
go


--2

create view V_ManagerTopics
with encryption
as
select i.Ins_Name as ManagerName,t.Top_Name
from Company.Department d
inner join Instructor i on d.Dept_Manager = i.Ins_Id
inner join Ins_Course ic on i.Ins_Id = ic.Ins_Id
inner join Course c on ic.Crs_Id = c.Crs_Id
inner join Topic t on c.Top_Id = t.Top_Id
go
--test
select * from V_ManagerTopics
sp_helptext V_ManagerTopics;

go




--3

create view V_InstructorDept
as
select i.Ins_Name,d.Dept_Name
from Instructor i
inner join Company.Department d on i.Dept_Id = d.Dept_Id
where d.Dept_Name in ('SD','Java')
go
--test
select * from V_InstructorDept
go




create view V1
as
select *
from Student
where St_Address in ('Alex','Cairo')
with check option
go
--test
UPDATE V1
SET St_Address='tanta'
WHERE St_Address='alex';


--5
use Company_SD
go
create view V_ProjectEmpCount
as
select p.Pname,count(w.ESSn) as EmpCount
from Project p
left join Works_for w on p.Pnumber = w.Pno
group by p.Pname
go
--test
select * from V_ProjectEmpCount



--6.

-- errorrrrrrrrrrrr


Use ITI
create clustered index InX_ManagerHiredate
on Company.Department(Manager_hiredate)
--DROP INDEX PK_Department ON Company.Department;




--7
create unique index IX_UniqueAge
on Student(St_Fname)



--8
USE Company_SD;
GO

DECLARE @SSN INT, @Salary INT

DECLARE EmpCursor CURSOR
FOR
SELECT SSN, Salary FROM Human_Resource.Employee

OPEN EmpCursor

FETCH NEXT FROM EmpCursor INTO @SSN, @Salary

WHILE @@FETCH_STATUS = 0
BEGIN
    IF @Salary < 3000
        UPDATE  Human_Resource.Employee
        SET Salary = Salary * 1.10
        WHERE SSN = @SSN
    ELSE
        UPDATE  Human_Resource.Employee
        SET Salary = Salary * 1.20
        WHERE SSN = @SSN

    FETCH NEXT FROM EmpCursor INTO @SSN, @Salary
END

CLOSE EmpCursor
DEALLOCATE EmpCursor



--9
USE ITI;
GO

DECLARE @DeptName NVARCHAR(50),
        @ManagerName NVARCHAR(50)

DECLARE DeptCursor CURSOR
FOR
SELECT D.Dept_Name, I.Ins_Name
FROM company.Department D
JOIN Instructor I ON D.Dept_Manager = I.Ins_Id

OPEN DeptCursor
FETCH NEXT FROM DeptCursor INTO @DeptName, @ManagerName

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @DeptName + ' - ' + @ManagerName
    FETCH NEXT FROM DeptCursor INTO @DeptName, @ManagerName
END

CLOSE DeptCursor
DEALLOCATE DeptCursor




--10

DECLARE @AllNames NVARCHAR(MAX)='',
        @Name NVARCHAR(50)

DECLARE InsCursor CURSOR
FOR SELECT Ins_Name FROM Instructor

OPEN InsCursor
FETCH NEXT FROM InsCursor INTO @Name

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @AllNames = @AllNames + @Name + ', '
    FETCH NEXT FROM InsCursor INTO @Name
END

PRINT @AllNames

CLOSE InsCursor
DEALLOCATE InsCursor





--11
use master
CREATE TABLE Users
(
    UserID INT PRIMARY KEY,
    TransactionAmount INT
);

CREATE TABLE NewTransactions
(
    UserID INT PRIMARY KEY,
    TransactionAmount INT
);




INSERT INTO Users VALUES
(1,1000),
(2,2000),
(3,3000);

INSERT INTO NewTransactions VALUES
(2,2500),   
(3,3500),  
(4,4000);   -- مش موجود وهيتعمله Insert


MERGE Users AS T
USING NewTransactions AS S
ON T.UserID = S.UserID

WHEN MATCHED THEN
    UPDATE SET T.TransactionAmount = S.TransactionAmount

WHEN NOT MATCHED THEN
    INSERT (UserID, TransactionAmount)
    VALUES (S.UserID, S.TransactionAmount);



    SELECT * FROM Users;






    --12

    CREATE LOGIN ITIStud
WITH PASSWORD = 'ITI@123';

USE ITI;
GO

CREATE USER ITIStud
FOR LOGIN ITIStud;


GRANT SELECT, INSERT ON Student TO ITIStud;
GRANT SELECT, INSERT ON Course TO ITIStud;


DENY UPDATE, DELETE ON Student TO ITIStud;
DENY UPDATE, DELETE ON Course TO ITIStud;


SELECT * FROM Student;
UPDATE Student SET St_Age = 25 WHERE St_Id = 1;

