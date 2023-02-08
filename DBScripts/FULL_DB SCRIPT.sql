CREATE DATABASE TasksDB
GO
USE [TasksDB]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 2023-02-08 1:21:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Priority] [int] NULL,
	[Category] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Task_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetAllTasks]    Script Date: 2023-02-08 1:21:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTasks] 
AS
BEGIN
    SELECT *
    FROM Task ;
   
END
GO
/****** Object:  StoredProcedure [dbo].[GetTaskById]    Script Date: 2023-02-08 1:21:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTaskById] (@Id int) 
AS
BEGIN
    SELECT *
    FROM Task 
    WHERE id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[SaveTask]    Script Date: 2023-02-08 1:21:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveTask] (
	@Title NVARCHAR(50), 
	@Description NVARCHAR(50), 
	@StartDate DATE, 
	@EndDate DATE, 
	@Priority INT, 
	@Category NVARCHAR(50), 
	@Status NVARCHAR(50)
) 
AS
BEGIN
    INSERT INTO Task (Title, [Description], StartDate, EndDate, [Priority], Category, [Status])
    VALUES (@Title, @Description, @StartDate, @EndDate, @Priority, @Category, @Status)
END
GO
/****** Object:  StoredProcedure [dbo].[SelectTask]    Script Date: 2023-02-08 1:21:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectTask] (@Id int) 
AS
BEGIN
    SELECT *
    FROM Task 
    WHERE id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[SelectTaskByDateRange]    Script Date: 2023-02-08 1:21:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectTaskByDateRange] (@StartDate datetime, @EndDate datetime) 
AS
BEGIN
    SELECT *
    FROM Task 
    WHERE (StartDate between @StartDate and @EndDate) and (EndDate between @StartDate and @EndDate)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTask]    Script Date: 2023-02-08 1:21:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTask] (@Id int, @Title NVARCHAR(50), @Description NVARCHAR(50), 
                           @StartDate DATE, @EndDate DATE, 
                           @Priority INT, @Category NVARCHAR(50), @Status NVARCHAR(50)) 
AS
BEGIN
    UPDATE Task 
    SET 
		Title = @Title,
		[Description] = @Description, 
        StartDate = @StartDate, 
        EndDate = @EndDate, 
        Priority = @Priority, 
        Category = @Category,
		[Status] =@Status
    WHERE id = @Id;
END
GO
