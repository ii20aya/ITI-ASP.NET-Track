--day 5 , p2



-- 1.  Instructor

CREATE TABLE Instructor (
    ID INT IDENTITY(1,1) PRIMARY KEY,          
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    BD DATE NOT NULL,
    HireDate DATE DEFAULT GETDATE(),           
    Address NVARCHAR(10) CHECK (Address IN ('Cairo','Alex')), 
    Salary DECIMAL(10,2) DEFAULT 3000 CHECK (Salary BETWEEN 1000 AND 5000),
    OverTime DECIMAL(10,2) UNIQUE,
    Age AS (YEAR(GETDATE()) - YEAR(BD)),      
    NetSalary AS (Salary + OverTime)          
);


-- 2. Course

CREATE TABLE Course (
    CID INT IDENTITY(1,1) PRIMARY KEY,
    CName NVARCHAR(100) NOT NULL,
    Duration INT UNIQUE                        
);


-- 3. Lab 

CREATE TABLE Lab (
    LID INT NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    Capacity INT CHECK (Capacity < 20),
    CID INT NOT NULL,
    CONSTRAINT PK_Lab PRIMARY KEY (LID, CID),
    CONSTRAINT FK_Lab_Course FOREIGN KEY (CID) REFERENCES Course(CID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);



-- 4. Table: Teach (Many-to-Many)

CREATE TABLE Teach (
    InstructorID INT NOT NULL,
    CourseID INT NOT NULL,
    PRIMARY KEY (InstructorID, CourseID),
    CONSTRAINT FK_Teach_Instructor FOREIGN KEY (InstructorID) REFERENCES Instructor(ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT FK_Teach_Course FOREIGN KEY (CourseID) REFERENCES Course(CID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
