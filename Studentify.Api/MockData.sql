USE [Studentify]
GO

INSERT INTO [dbo].[Teachers] ([TeacherName], [ImageUrl])
VALUES
('John Doe', 'https://via.placeholder.com/200x320.png?text=John+Doe'),
('Jane Doe', NULL),
('Lars Erik Robert Tublen', NULL)
GO

INSERT INTO [dbo].[Subjects] ([SubjectName], [Description], [ImageUrl])
VALUES
('Math', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'https://via.placeholder.com/320x320.png?text=Subject+1'),
('Web Dev', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'https://via.placeholder.com/320x320.png?text=Subject+1')
GO

INSERT INTO [dbo].[Courses] ([SubjectId], [TeacherId], [CourseName], [Description], [ImageUrl])
VALUES
(1, 1, 'Basic Math', '1+1=2 and so on.', 'https://via.placeholder.com/320x320.png?text=Math+101'),
(1, 2, 'Advanced Math', '1*1=1 and other stuff', 'https://via.placeholder.com/320x320.png?text=Complex+Math'),
(2, 3, 'WebAPI', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'https://via.placeholder.com/320x320.png?text=WebAPI'),
(2, 3, 'Asp.NET Core', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'https://via.placeholder.com/320x320.png?text=Asp.NET+Core'),
(2, 3, 'Javascript', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'https://via.placeholder.com/320x320.png?text=Javascript')
GO

INSERT INTO [dbo].[Students] ([StudentName], [ImageUrl])
VALUES
('James Doe', 'https://via.placeholder.com/200x320.png?text=James+Doe'),
('Adrian', NULL),
('Jonathan', NULL),
('Mikael', NULL),
('Saiid', NULL)
GO

INSERT INTO [dbo].[Grades] ([StudentId], [CourseId], [StudentGrade])
VALUES
(1,1,1),
(1,2,3),
(2,3,3),
(2,4,3),
(3,5,3),
(3,4,3),
(4,3,2),
(4,4,3),
(4,2,-1),
(5,5,3),
(5,4,5)
GO

INSERT INTO [dbo].[CourseStudent] ([CoursesCourseId], [StudentsStudentId])
VALUES
(1,1),
(2,1),
(2,4),
(3,2),
(3,4),
(4,2),
(4,3),
(4,4),
(4,5),
(5,3),
(5,5)
GO

