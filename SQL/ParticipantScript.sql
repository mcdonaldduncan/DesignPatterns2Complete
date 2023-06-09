USE [PROG455SP23]
GO
/****** Object:  StoredProcedure [dbo].[UpdateParticipant]    Script Date: 5/3/2023 10:25:10 PM ******/
DROP PROCEDURE [dbo].[UpdateParticipant]
GO
/****** Object:  StoredProcedure [dbo].[GetParticipantsByName]    Script Date: 5/3/2023 10:25:10 PM ******/
DROP PROCEDURE [dbo].[GetParticipantsByName]
GO
/****** Object:  StoredProcedure [dbo].[GetAllParticipants]    Script Date: 5/3/2023 10:25:10 PM ******/
DROP PROCEDURE [dbo].[GetAllParticipants]
GO
/****** Object:  StoredProcedure [dbo].[DeleteParticipant]    Script Date: 5/3/2023 10:25:10 PM ******/
DROP PROCEDURE [dbo].[DeleteParticipant]
GO
/****** Object:  StoredProcedure [dbo].[AddParticipant]    Script Date: 5/3/2023 10:25:10 PM ******/
DROP PROCEDURE [dbo].[AddParticipant]
GO
/****** Object:  Table [dbo].[Participant]    Script Date: 5/3/2023 10:25:10 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Participant]') AND type in (N'U'))
DROP TABLE [dbo].[Participant]
GO
/****** Object:  Table [dbo].[Participant]    Script Date: 5/3/2023 10:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[GemStone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Participant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Participant] ON 

INSERT [dbo].[Participant] ([ID], [Name], [GemStone]) VALUES (1, N'Duncan', N'Emerald')
INSERT [dbo].[Participant] ([ID], [Name], [GemStone]) VALUES (2, N'Leo', N'Ruby')
INSERT [dbo].[Participant] ([ID], [Name], [GemStone]) VALUES (3, N'Guybrush', N'Diamond')
INSERT [dbo].[Participant] ([ID], [Name], [GemStone]) VALUES (4, N'Terry', N'Opal')
INSERT [dbo].[Participant] ([ID], [Name], [GemStone]) VALUES (5, N'Test', N'Ruby')
INSERT [dbo].[Participant] ([ID], [Name], [GemStone]) VALUES (6, N'FullTest', N'Diamond')
SET IDENTITY_INSERT [dbo].[Participant] OFF
GO
/****** Object:  StoredProcedure [dbo].[AddParticipant]    Script Date: 5/3/2023 10:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddParticipant]
    @Name NVARCHAR(50),
    @GemStone NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[Participant] ([Name], [GemStone]) VALUES (@Name, @GemStone);
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteParticipant]    Script Date: 5/3/2023 10:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteParticipant]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM [dbo].[Participant] WHERE [ID] = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllParticipants]    Script Date: 5/3/2023 10:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllParticipants]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM [dbo].[Participant];
END
GO
/****** Object:  StoredProcedure [dbo].[GetParticipantsByName]    Script Date: 5/3/2023 10:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetParticipantsByName]
    @Name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM [dbo].[Participant] WHERE [Name] LIKE '%' + @Name + '%';
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateParticipant]    Script Date: 5/3/2023 10:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateParticipant]
    @ID INT,
    @Name NVARCHAR(50),
    @GemStone NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [dbo].[Participant] SET [Name] = @Name, [GemStone] = @GemStone WHERE [ID] = @ID;
END
GO
