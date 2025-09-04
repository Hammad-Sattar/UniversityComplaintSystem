CREATE TABLE Departments (
    DepartmentId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Phone NVARCHAR(20),
    Role NVARCHAR(50) NOT NULL, -- Student, Faculty, Admin, DeptHead
    DepartmentId INT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId)
);

ALTER TABLE Departments
ADD HeadUserId INT NOT NULL DEFAULT 1; -- Temporary default, update later

ALTER TABLE Departments
ADD CONSTRAINT FK_Departments_HeadUser
FOREIGN KEY (HeadUserId) REFERENCES Users(UserId);

CREATE TABLE Complaints (
    ComplaintId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Status NVARCHAR(50) DEFAULT 'Pending', -- Pending, InProgress, Resolved, Rejected
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    UserId INT NOT NULL,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId)
);



CREATE TABLE ComplaintActions (
    ActionId INT PRIMARY KEY IDENTITY,
    ComplaintId INT NOT NULL,
    ActionByUserId INT NOT NULL,
    Action NVARCHAR(200) NOT NULL,
    ActionDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ComplaintId) REFERENCES Complaints(ComplaintId),
    FOREIGN KEY (ActionByUserId) REFERENCES Users(UserId)
);

