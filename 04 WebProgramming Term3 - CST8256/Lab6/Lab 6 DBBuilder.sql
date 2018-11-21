USE [StudentRecord]
GO

/****** Object: Table [dbo].[AcademicRecord] Script Date: 9/17/2017 10:42:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[AcademicRecord];
GO
DROP TABLE [dbo].[Course];
GO
DROP TABLE [dbo].[Student];
GO
DROP TABLE [dbo].[Employee_Role];
GO
DROP TABLE [dbo].[Employee];
GO
DROP TABLE [dbo].[Role];
GO

CREATE TABLE [dbo].[Course] (
    [Code]  NVARCHAR (10) NOT NULL PRIMARY KEY,
    [Title] NVARCHAR (50) NOT NULL
);

CREATE TABLE [dbo].[Student] (
    [Id]   NVARCHAR (10) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR (50) NOT NULL,
	[Type] NVARCHAR (10) NULL
);

CREATE TABLE [dbo].[AcademicRecord]
(
	[CourseCode] NVARCHAR(10) NOT NULL , 
    [StudentId] NVARCHAR(10) NOT NULL, 
    [Grade] INT NULL, 
    PRIMARY KEY ([StudentId], [CourseCode]), 
    CONSTRAINT [FK_AcademicRecord_Course] FOREIGN KEY ([CourseCode]) REFERENCES [Course]([Code]), 
    CONSTRAINT [FK_AcademicRecord_Student] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id]) 
)

CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Role]
(
    [Id] INT,
    [Role] VARCHAR(100) NULL,
	CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[Employee_Role]
(
    [Employee_Id] INT,
    [Role_Id] INT,
	CONSTRAINT [PK_Employee_Role] PRIMARY KEY ([Employee_Id], [Role_Id]),
	CONSTRAINT [FK_ToEmployee] FOREIGN KEY ([Employee_Id]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [FK_ToRole] FOREIGN KEY ([Role_Id]) REFERENCES [dbo].[Role] ([Id])
);


INSERT INTO [dbo].[Course] ([Code], [Title]) VALUES (N'CST8257', N'Web Application Development')
INSERT INTO [dbo].[Course] ([Code], [Title]) VALUES (N'CST8255', N'ASP.NET  Programming')
INSERT INTO [dbo].[Course] ([Code], [Title]) VALUES (N'CST8256', N'Web Programming Language I')
INSERT INTO [dbo].[Course] ([Code], [Title]) VALUES (N'CST8259', N'Web Programming Language II')
INSERT INTO [dbo].[Course] ([Code], [Title]) VALUES (N'CST2200', N'Database Management and Administration System')

INSERT INTO [dbo].[Student] ([Id], [Name], [Type]) VALUES (N'0001', N'Wei Gong', N'Fulltime')
INSERT INTO [dbo].[Student] ([Id], [Name], [Type]) VALUES (N'0002', N'John Smith', N'Fulltime')
INSERT INTO [dbo].[Student] ([Id], [Name], [Type]) VALUES (N'0003', N'Adam Smith', N'Fulltime')
INSERT INTO [dbo].[Student] ([Id], [Name], [Type]) VALUES (N'0004', N'Jane Doe', N'Parttime')
INSERT INTO [dbo].[Student] ([Id], [Name], [Type]) VALUES (N'0006', N'May Davison', N'Parttime')
INSERT INTO [dbo].[Student] ([Id], [Name], [Type]) VALUES (N'0008', N'Peter Robinson', N'Parttime')
INSERT INTO [dbo].[Student] ([Id], [Name], [Type]) VALUES (N'0011', N'Peter Robinson', N'Coop')
INSERT INTO [dbo].[Student] ([Id], [Name], [Type]) VALUES (N'0012', N'Stephen Harp', N'Coop')

INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST2200', N'0001', 70)
INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST8255', N'0001', 90)
INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST8255', N'0002', 70)
INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST8255', N'0003', 80)
INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST8255', N'0004', 90)
INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST8255', N'0006', 89)
INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST8255', N'0008', 85)
INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST2200', N'0011', 88)
INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST2200', N'0012', 65)

INSERT INTO [dbo].[Employee] (name, UserName, password) VALUES ('Wei Gong', 'gongw', 'Password1');
INSERT INTO [dbo].[Employee] (name, UserName, password) VALUES ('John Smith', 'smithj', 'Password1');
INSERT INTO [dbo].[Employee] (name, UserName, password) VALUES ('Jane Doe', 'doej', 'Password1');
INSERT INTO [dbo].[Employee] (name, UserName, password) VALUES ('Mary Robinson', 'robinm', 'Password1');
INSERT INTO [dbo].[Employee] (name, UserName, password) VALUES ('David Jones', 'jonesd', 'Password1');

INSERT INTO [dbo].[Role] (Id, Role) VALUES (1, 'Department Chair');
INSERT INTO [dbo].[Role] (Id, Role) VALUES (2, 'Coordinator');
INSERT INTO [dbo].[Role] (Id, Role) VALUES (3, 'Instructor');

INSERT INTO [dbo].[Employee_Role] (Employee_Id, Role_Id) VALUES (4, 1);
INSERT INTO [dbo].[Employee_Role] (Employee_Id, Role_Id) VALUES (1, 3);
INSERT INTO [dbo].[Employee_Role] (Employee_Id, Role_Id) VALUES (2, 2);
INSERT INTO [dbo].[Employee_Role] (Employee_Id, Role_Id) VALUES (3, 3);
INSERT INTO [dbo].[Employee_Role] (Employee_Id, Role_Id) VALUES (5, 2);
INSERT INTO [dbo].[Employee_Role] (Employee_Id, Role_Id) VALUES (5, 3);

