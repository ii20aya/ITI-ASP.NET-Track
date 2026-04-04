--day 5 , p1 "iti"


--1
SELECT COUNT(*) AS StudentsWithAge
FROM Student
WHERE St_Age IS NOT NULL;



--2
SELECT DISTINCT Ins_Name
FROM Instructor;



--3

SELECT 
    St_Id,
    ISNULL(St_Fname + ' ' + St_Lname, 'No Name') AS StudentFullName,
    ISNULL(D.Dept_Name, 'No Department') AS DepartmentName
FROM Student S
inner JOIN Department D ON S.Dept_Id = D.Dept_Id;



--4
SELECT 
    I.Ins_Name,
    ISNULL(D.Dept_Name, 'No Department') AS DepartmentName
FROM Instructor I
LEFT JOIN Department D ON I.Dept_Id = D.Dept_Id;


--5
SELECT 
    S.St_Fname + ' ' + S.St_Lname AS StudentFullName,
    C.Crs_Name AS CourseName,
    SC.Grade
FROM Student S
INNER JOIN Stud_Course SC ON S.St_Id = SC.St_Id
INNER JOIN Course C ON SC.Crs_Id = C.Crs_Id
WHERE SC.Grade IS NOT NULL;



--6

SELECT 
    T.Top_Name,
    COUNT(C.Crs_Id) AS CourseCount
FROM Topic T
inner JOIN Course C ON T.Top_Id = C.Top_Id
GROUP BY T.Top_Name;


--7
SELECT 
    MAX(Salary) AS MaxSalary,
    MIN(Salary) AS MinSalary
FROM Instructor;


--8
SELECT *
FROM Instructor
WHERE Salary < (SELECT AVG(Salary) FROM Instructor);



--9
SELECT D.Dept_Name
FROM Instructor I
INNER JOIN Department D ON I.Dept_Id = D.Dept_Id
WHERE I.Salary = (SELECT MIN(Salary) FROM Instructor);


--10

SELECT TOP 2 Salary
FROM Instructor
ORDER BY Salary DESC;



--11
SELECT 
    Ins_Name,
    COALESCE(Salary, 'Instructor Bonus') AS SalaryOrBonus
FROM Instructor;


--12
SELECT AVG(Salary) AS AvgSalary
FROM Instructor;


--13
SELECT 
    S.St_Fname AS StudentName,
    Sup.St_Fname + ' ' + Sup.St_Lname AS SupervisorName
FROM Student S
inner JOIN Student Sup ON S.St_super = Sup.St_Id;

--14
WITH RankedSalaries AS (
    SELECT 
        Dept_Id,
        Ins_Name,
        Salary,
        RANK() OVER (PARTITION BY Dept_Id ORDER BY Salary DESC) AS SalaryRank
    FROM Instructor
)
SELECT *
FROM RankedSalaries
WHERE SalaryRank <= 2;




--15
WITH RandomStudent AS (
    SELECT 
        St_Id,
        St_Fname + ' ' + St_Lname AS StudentName,
        Dept_Id,
        ROW_NUMBER() OVER (PARTITION BY Dept_Id ORDER BY NEWID()) AS rn
    FROM Student
)
SELECT *
FROM RandomStudent
WHERE rn = 1;


