--day 8 



--1

USE ITI;
GO

CREATE PROC SP_StudentCountPerDept
AS
BEGIN
    SELECT 
        D.Dept_Name,
        COUNT(S.St_Id) AS Student_Count
    FROM company.Department D
    LEFT JOIN Student S 
        ON D.Dept_Id = S.Dept_Id
    GROUP BY D.Dept_Name
END


EXEC SP_StudentCountPerDept;



--2
USE Company_SD;
GO

CREATE PROC SP_CheckProjectP1
AS
BEGIN
    DECLARE @EmpCount INT

    SELECT @EmpCount = COUNT(*)
    FROM Works_for
    WHERE Pno = 1   

    IF @EmpCount >= 3
        PRINT 'The number of employees in the project p1 is 3 or more'
    ELSE
    BEGIN
        PRINT 'The following employees work for the project p1'

        SELECT Fname, Lname
        FROM Human_Resource.Employee E
        JOIN Works_for W ON E.SSN = W.ESSn
        WHERE Pno = 500
    END
END



EXEC SP_CheckProjectP1;







--3
CREATE PROC SP_ReplaceEmployee
    @OldEmp INT,
    @NewEmp INT,
    @ProjectNo INT
AS
BEGIN
    UPDATE Works_for
    SET ESSn = @NewEmp
    WHERE ESSn = @OldEmp
      AND Pno = @ProjectNo
END


EXEC SP_ReplaceEmployee 512463, 968574, 600;





--4

USE Company_SD;
GO

ALTER TABLE Project
ADD Budget MONEY;



UPDATE Project
SET Budget = 100000
WHERE Budget IS NULL;



CREATE TABLE Project_Audit
(
    ProjectNo INT,
    UserName NVARCHAR(50),
    ModifiedDate DATETIME,
    Budget_Old MONEY,
    Budget_New MONEY
);



CREATE TRIGGER TR_ProjectBudgetAudit
ON Project
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Budget)
    BEGIN
        INSERT INTO Project_Audit
        SELECT 
            D.Pnumber,
            SUSER_NAME(),
            GETDATE(),
            D.Budget,
            I.Budget
        FROM deleted D
        JOIN inserted I
        ON D.Pnumber = I.Pnumber
    END
END



UPDATE Project
SET Budget = 200000
WHERE Pnumber = 500;




SELECT * FROM Project_Audit;







--5

USE ITI;
GO

CREATE TRIGGER TR_NoInsertDept
ON company.Department
INSTEAD OF INSERT
AS
BEGIN
    PRINT 'You cannot insert a new record in Department table'
END




INSERT INTO company.Department VALUES (10,'Test','','beni suef','','7-4-2026');





--6
use Company_Sd
go
create trigger tr_prevent_employee_insert_march
on Human_Resource.Employee
instead of insert
as
begin
    if month(getdate()) = 3
    begin
        print 'insertion into employee table is not allowed during march';
    end
    else
    begin
        insert into Human_Resource.Employee
        select * from inserted;
    end
end;
go



insert into [Human Resource].employee(ssn, Fname)
values (5362598, 'aya')





--7
CREATE TRIGGER TR_NoDeleteEmployee
ON Human_Resource.Employee
INSTEAD OF DELETE
AS
BEGIN
    PRINT 'You are not allowed to delete employees';
END
GO



DELETE FROM Human_Resource.Employee
WHERE SSN = 112233;



create table student_audit
(
	auditid int identity primary key,
    server_user_name varchar(100),
    audit_date datetime,
    note varchar(500)
);






--8


CREATE TABLE Employee_Audit
(
    EmpSSN INT,
    OldSalary INT,
    NewSalary INT,
    ChangeDate DATETIME
);



CREATE TRIGGER TR_SalaryAudit
ON Human_Resource.Employee
AFTER UPDATE
AS
BEGIN
    INSERT INTO Employee_Audit
    SELECT 
        d.SSN,
        d.Salary,
        i.Salary,
        GETDATE()
    FROM deleted d
    JOIN inserted i ON d.SSN = i.SSN
    WHERE d.Salary <> i.Salary;
END
GO



UPDATE Human_Resource.Employee
SET Salary = Salary + 100
WHERE SSN = 112233;





select * from Employee_Audit














