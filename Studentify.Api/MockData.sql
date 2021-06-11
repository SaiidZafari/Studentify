USE [Studentify]
GO

INSERT INTO [dbo].[Teachers] ([TeacherName], [ImageUrl])
VALUES
('John Doe', '/images/Teacher.png'),
('Jane Doe', '/images/Teacher1.png'),
('Robert Tublen', '/images/Teacher2.png'),
('Rutger Hansson', NULL),
('Gunhilda Gottlieb', NULL)
GO

INSERT INTO [dbo].[Subjects] ([SubjectName], [Description], [ImageUrl])
VALUES
('Math', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'https://via.placeholder.com/320x320.png?text=Subject+1'),
('Web Dev', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 'https://via.placeholder.com/320x320.png?text=Subject+2')
GO

INSERT INTO [dbo].[Courses] ([SubjectId], [TeacherId], [CourseName], [Description], [ImageUrl])
VALUES
(2, 1, 'Basic Math', 'Practical mathematics has been a human activity from as far back as written records exist. The research required to solve mathematical problems can take years or even centuries of sustained inquiry.', '/images/basic_math.jpg'),
(2, 2, 'Advanced Math', 'Mathematics always played a special role in scientific thought, serving since ancient times as a model of truth and rigor for rational inquiry, and giving tools or even a foundation for other sciences (especially physics).', '/images/advanced_math.jpg'),
(2, 3, 'WebAPI', 'A Web API is an application programming interface for either a web server or a web browser.', '/images/webapi.jpg'),
(2, 3, 'Asp.NET Core', 'ASP.NET Core is a free and open-source web framework and successor to ASP.NET, developed by Microsoft. It is a modular framework that runs on both the full .NET Framework, on Windows, and the cross-platform .NET Core.', '/images/asp_net_core.jpg'),
(2, 3, 'Javascript', 'Alongside HTML and CSS, JavaScript is one of the core technologies of the World Wide Web. Over 97% of websites use it client-side for web page behaviour.', '/images/javascript.jpg')
GO

INSERT INTO [dbo].[Students] ([StudentName], [ImageUrl])
VALUES
('James Doe', 'https://via.placeholder.com/180x200.png?text=James+Doe'),
('Adrian', '/images/StudentD-1.png'),
('Jonathan', '/images/StudentD-2.png'),
('Mikael', '/images/StudentD-3.png'),
('Saiid', '/images/StudentD-4.png')
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

