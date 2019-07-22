USE [StudentEnrollment]
GO

/****** Object:  Table [dbo].[Enrollment]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Enrollment](
	[Student_ID] [nchar](40) NULL,
	[First_Name] [nchar](40) NULL,
	[Last_Name] [nchar](40) NULL,
	[Gender] [nchar](40) NULL,
	[DOB] [nchar](40) NULL,
	[Address] [nvarchar](50) NULL,
	[Department] [nchar](40) NULL,
	[Program] [nchar](40) NULL
) ON [PRIMARY]

GO

