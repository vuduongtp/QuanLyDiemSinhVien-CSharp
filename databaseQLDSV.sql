USE [QLDSV]
GO
/****** Object:  User [spconnect]    Script Date: 1/2/2020 6:30:39 PM ******/
CREATE USER [spconnect] FOR LOGIN [spconnect] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [ADMIN]    Script Date: 1/2/2020 6:30:39 PM ******/
CREATE ROLE [ADMIN]
GO
/****** Object:  DatabaseRole [MSmerge_A4C92B57CA5442ED8FC888DD31272E5B]    Script Date: 1/2/2020 6:30:39 PM ******/
CREATE ROLE [MSmerge_A4C92B57CA5442ED8FC888DD31272E5B]
GO
/****** Object:  DatabaseRole [MSmerge_A6BFA1E7609B4019A0D5DAE83CC413E8]    Script Date: 1/2/2020 6:30:39 PM ******/
CREATE ROLE [MSmerge_A6BFA1E7609B4019A0D5DAE83CC413E8]
GO
/****** Object:  DatabaseRole [MSmerge_DB5DC4D68488416CA6C9A84805EB4061]    Script Date: 1/2/2020 6:30:39 PM ******/
CREATE ROLE [MSmerge_DB5DC4D68488416CA6C9A84805EB4061]
GO
/****** Object:  DatabaseRole [MSmerge_PAL_role]    Script Date: 1/2/2020 6:30:39 PM ******/
CREATE ROLE [MSmerge_PAL_role]
GO
/****** Object:  DatabaseRole [USER]    Script Date: 1/2/2020 6:30:39 PM ******/
CREATE ROLE [USER]
GO
ALTER ROLE [db_owner] ADD MEMBER [spconnect]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_A4C92B57CA5442ED8FC888DD31272E5B]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_A6BFA1E7609B4019A0D5DAE83CC413E8]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_DB5DC4D68488416CA6C9A84805EB4061]
GO
/****** Object:  Schema [ADMIN]    Script Date: 1/2/2020 6:30:39 PM ******/
CREATE SCHEMA [ADMIN]
GO
/****** Object:  Schema [MSmerge_PAL_role]    Script Date: 1/2/2020 6:30:39 PM ******/
CREATE SCHEMA [MSmerge_PAL_role]
GO
/****** Object:  Table [dbo].[MONHOC]    Script Date: 1/2/2020 6:30:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONHOC](
	[MAMH] [nchar](8) NOT NULL,
	[TENMH] [nvarchar](40) NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_MONHOC] PRIMARY KEY CLUSTERED 
(
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIEM]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIEM](
	[MASV] [nchar](8) NOT NULL,
	[MAMH] [nchar](8) NOT NULL,
	[LAN] [smallint] NOT NULL,
	[DIEM] [float] NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_DIEM] PRIMARY KEY CLUSTERED 
(
	[MASV] ASC,
	[MAMH] ASC,
	[LAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SINHVIEN]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SINHVIEN](
	[MASV] [nchar](8) NOT NULL,
	[HO] [nvarchar](40) NULL,
	[TEN] [nvarchar](10) NULL,
	[MALOP] [nchar](8) NOT NULL,
	[PHAI] [bit] NULL,
	[NGAYSINH] [datetime] NULL,
	[NOISINH] [nvarchar](40) NULL,
	[DIACHI] [nvarchar](80) NULL,
	[GHICHU] [ntext] NULL,
	[NGHIHOC] [bit] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_SINHVIEN] PRIMARY KEY CLUSTERED 
(
	[MASV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_BANGDIEMTONGKET]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_BANGDIEMTONGKET]
AS
select  DIEM.MASV,HO,TEN,MALOP,TENMH,DIEM=MAX(DIEM) from DIEM, (select MASV,HO,TEN,MALOP from SINHVIEN where NGHIHOC=0) as sv,(select MAMH,TENMH from MONHOC) as mh
  where DIEM.MASV = sv.MASV and DIEM.MAMH=mh.MAMH group by DIEM.MASV,HO,TEN,MALOP,TENMH
GO
/****** Object:  View [dbo].[DSNHAPSV]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[DSNHAPSV] AS
select * from SINHVIEN where MASV=''
GO
/****** Object:  Table [dbo].[LOP]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOP](
	[MALOP] [nchar](8) NOT NULL,
	[TENLOP] [nvarchar](200) NULL,
	[MAKH] [nchar](8) NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_LOP] PRIMARY KEY CLUSTERED 
(
	[MALOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_SISO]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_SISO]
AS
SELECT L.MALOP , L.TENLOP, COUNT(S.MASV ) AS SISO
FROM LOP L LEFT JOIN 
  (SELECT MASV, MALOP FROM SINHVIEN WHERE NGHIHOC='FALSE') S
     ON L.MALOP=S.MALOP 
GROUP BY L.MALOP, L.TENLOP
GO
/****** Object:  View [dbo].[DSLOP]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DSLOP] AS
SELECT MALOP FROM LOP
GO
/****** Object:  View [dbo].[DANHSACH]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[DANHSACH] AS
SELECT MASV=MASV,HO=HO,TEN=TEN,MALOP,DIEM='' FROM SINHVIEN
GO
/****** Object:  View [dbo].[V_DS_PHANMANH]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_DS_PHANMANH]
AS
SELECT  TENKHOA=PUBS.name, TENSERVER= subscriber_server
   FROM dbo.sysmergepublications PUBS,  dbo.sysmergesubscriptions SUBS
   WHERE PUBS.pubid= SUBS.PUBID  AND PUBS.publisher <> SUBS.subscriber_server
GO
/****** Object:  View [dbo].[V_DS_PHANMANH2]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[V_DS_PHANMANH2]
AS
SELECT top 2 TENKHOA=PUBS.name, TENSERVER= subscriber_server
   FROM dbo.sysmergepublications PUBS,  dbo.sysmergesubscriptions SUBS
   WHERE PUBS.pubid= SUBS.PUBID  AND PUBS.publisher <> SUBS.subscriber_server
GO
/****** Object:  Table [dbo].[GIANGVIEN]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIANGVIEN](
	[MAGV] [nchar](10) NOT NULL,
	[HO] [nvarchar](50) NOT NULL,
	[TEN] [nvarchar](10) NOT NULL,
	[MAKH] [nchar](8) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_GIANGVIEN] PRIMARY KEY CLUSTERED 
(
	[MAGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOCPHI]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOCPHI](
	[MASV] [nchar](8) NOT NULL,
	[NIENKHOA] [nvarchar](12) NOT NULL,
	[HOCKY] [int] NOT NULL,
	[HOCPHI] [int] NOT NULL,
	[SOTIENDADONG] [int] NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_HOCPHI] PRIMARY KEY CLUSTERED 
(
	[MASV] ASC,
	[NIENKHOA] ASC,
	[HOCKY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHOA]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHOA](
	[MAKH] [nchar](8) NOT NULL,
	[TENKH] [nvarchar](40) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_KHOA] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'08VTA01 ', N'CTDL    ', 1, 8, N'bffea28f-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'08VTA01 ', N'VB      ', 1, 8, N'c0bd3330-7afc-e911-a658-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'08VTA02 ', N'CTDL    ', 1, 8, N'c0fea28f-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'08VTA02 ', N'VB      ', 1, 8, N'c1bd3330-7afc-e911-a658-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'08VTA101', N'CTDL    ', 1, 8, N'bd8d184c-782c-ea11-a667-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'08VTA102', N'CTDL    ', 1, 8, N'c1fea28f-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'08VTA102', N'VB      ', 1, 8, N'c2bd3330-7afc-e911-a658-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA101', N'CSDL1   ', 1, 7, N'c8d78223-0d2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA101', N'CSDL1   ', 2, 5, N'd0481156-0d2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA101', N'CSDLP   ', 1, 8, N'8aedc855-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA101', N'CTDL    ', 1, 8, N'35e486e5-0c2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA102', N'CSDL1   ', 1, 7, N'c9d78223-0d2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA102', N'CSDL1   ', 2, 5, N'd1481156-0d2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA102', N'CSDLP   ', 1, 8.5, N'8bedc855-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA102', N'CTDL    ', 1, 8, N'36e486e5-0c2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA103', N'CSDL1   ', 1, 7, N'cad78223-0d2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA103', N'CSDL1   ', 2, 5, N'd2481156-0d2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA103', N'CSDLP   ', 1, 7.5, N'8cedc855-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'09THA103', N'CTDL    ', 1, 8, N'37e486e5-0c2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'1       ', N'CTDL    ', 1, 8, N'c2fea28f-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'1       ', N'VB      ', 1, 8, N'c3bd3330-7afc-e911-a658-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'2       ', N'CSDLP   ', 1, 7.5, N'29f8a52e-f72c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'2       ', N'CTDL    ', 1, 8, N'03e306d8-452a-ea11-a667-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'2       ', N'CTDL    ', 2, 10, N'fcd39675-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'2       ', N'LTCB    ', 1, 8, N'a0c7be54-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ100', N'CSDLP   ', 1, 6.5, N'2af8a52e-f72c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ100', N'CTDL    ', 1, 8, N'04e306d8-452a-ea11-a667-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ100', N'CTDL    ', 2, 10, N'fdd39675-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ100', N'LTCB    ', 1, 8, N'a1c7be54-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ101', N'CSDLP   ', 1, 6.5, N'2bf8a52e-f72c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ101', N'CTDL    ', 1, 8, N'05e306d8-452a-ea11-a667-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ101', N'CTDL    ', 2, 10, N'fed39675-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ101', N'LTCB    ', 1, 8, N'a2c7be54-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ102', N'CSDLP   ', 1, 8.5, N'2cf8a52e-f72c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ102', N'CTDL    ', 1, 8, N'06e306d8-452a-ea11-a667-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ102', N'CTDL    ', 2, 10, N'ffd39675-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ102', N'LTCB    ', 1, 8, N'a3c7be54-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ103', N'CSDLP   ', 1, 7, N'2df8a52e-f72c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ103', N'CTDL    ', 1, 8, N'07e306d8-452a-ea11-a667-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ103', N'CTDL    ', 2, 10, N'00d49675-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'D16CQ103', N'LTCB    ', 1, 8, N'a4c7be54-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'g       ', N'CTDL    ', 1, 8, N'c3fea28f-012d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'g       ', N'VB      ', 1, 10, N'023d764b-2c1f-ea11-a661-9cda3ef7e398')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N14DCN02', N'CSDLP   ', 1, 8, N'0571f9e8-2f2d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N14DCN02', N'CTDL    ', 1, 10, N'd3bea8d9-f22c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15DCCN1', N'CSDLP   ', 1, 8, N'0671f9e8-2f2d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15DCCN1', N'CTDL    ', 1, 9, N'd4bea8d9-f22c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15DCCN2', N'CSDLP   ', 1, 8.5, N'0771f9e8-2f2d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15DCCN2', N'CTDL    ', 1, 10, N'd5bea8d9-f22c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15DCCN3', N'CSDLP   ', 1, 8.5, N'0871f9e8-2f2d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15DCCN3', N'CTDL    ', 1, 10, N'd6bea8d9-f22c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT01 ', N'CSDL1   ', 1, 6, N'30b36f80-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT01 ', N'CTDL    ', 1, 10, N'be0b0e02-f82c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT01 ', N'CTDL    ', 2, 8.5, N'02f67a0b-fa2c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT01 ', N'LTCB    ', 1, 8, N'01e34263-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT02 ', N'CSDL1   ', 1, 6, N'31b36f80-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT02 ', N'CTDL    ', 1, 8, N'bf0b0e02-f82c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT02 ', N'CTDL    ', 2, 8.5, N'03f67a0b-fa2c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT02 ', N'LTCB    ', 1, 8, N'02e34263-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT03 ', N'CSDL1   ', 1, 6, N'32b36f80-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT03 ', N'CTDL    ', 1, 8, N'c00b0e02-f82c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT03 ', N'CTDL    ', 2, 10, N'04f67a0b-fa2c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT03 ', N'LTCB    ', 1, 8, N'03e34263-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT04 ', N'CSDL1   ', 1, 6, N'33b36f80-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT04 ', N'CTDL    ', 1, 8, N'c10b0e02-f82c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT04 ', N'CTDL    ', 2, 10, N'05f67a0b-fa2c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N15VT04 ', N'LTCB    ', 1, 8, N'04e34263-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN61 ', N'CTDL    ', 1, 8.5, N'6559b8ec-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN61 ', N'LTCB    ', 1, 3, N'ac46ec68-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN61 ', N'LTCB    ', 2, 8, N'5ec7a083-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN62 ', N'CTDL    ', 1, 7.5, N'6659b8ec-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN62 ', N'LTCB    ', 1, 0, N'ad46ec68-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN62 ', N'LTCB    ', 2, 8, N'5fc7a083-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN63 ', N'CTDL    ', 1, 6, N'6759b8ec-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN63 ', N'LTCB    ', 1, 4, N'ae46ec68-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN63 ', N'LTCB    ', 2, 8, N'60c7a083-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN64 ', N'CTDL    ', 1, 6, N'6859b8ec-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN64 ', N'LTCB    ', 1, 5, N'af46ec68-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN64 ', N'LTCB    ', 2, 8, N'61c7a083-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN65 ', N'CTDL    ', 1, 5.5, N'6959b8ec-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN65 ', N'LTCB    ', 1, 6, N'b046ec68-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN65 ', N'LTCB    ', 2, 8, N'62c7a083-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN66 ', N'CTDL    ', 1, 6.5, N'6a59b8ec-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN66 ', N'LTCB    ', 1, 7, N'b146ec68-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN66 ', N'LTCB    ', 2, 8, N'63c7a083-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN67 ', N'CTDL    ', 1, 8.5, N'6b59b8ec-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN67 ', N'LTCB    ', 1, 8, N'b246ec68-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN67 ', N'LTCB    ', 2, 8, N'64c7a083-412d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16DC02 ', N'CSDLP   ', 1, 8.5, N'0971f9e8-2f2d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16DC02 ', N'CTDL    ', 1, 10, N'd7bea8d9-f22c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16DCCN4', N'CSDL1   ', 1, 7.5, N'cbd78223-0d2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16DCCN4', N'CSDL1   ', 2, 10, N'd3481156-0d2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16DCCN4', N'CSDLP   ', 1, 6.5, N'8dedc855-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16DCCN4', N'CTDL    ', 1, 8, N'38e486e5-0c2a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16DCN05', N'CTDL    ', 1, 8, N'8fc01c66-782c-ea11-a667-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16DCN05', N'CTDL    ', 2, 10, N'97eb9dfd-f82c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT05 ', N'CSDL1   ', 1, 6, N'34b36f80-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT05 ', N'CTDL    ', 1, 8, N'c20b0e02-f82c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT05 ', N'CTDL    ', 2, 10, N'06f67a0b-fa2c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT05 ', N'LTCB    ', 1, 8, N'05e34263-f92c-ea11-a668-9cda3ef7e39b')
GO
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT06 ', N'CSDL1   ', 1, 6, N'35b36f80-302d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT06 ', N'CTDL    ', 1, 8, N'c30b0e02-f82c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT06 ', N'CTDL    ', 2, 10, N'07f67a0b-fa2c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT06 ', N'LTCB    ', 1, 8, N'06e34263-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT5  ', N'CTDL    ', 1, 10, N'90c01c66-782c-ea11-a667-9cda3ef7e39b')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16VT5  ', N'CTDL    ', 2, 10, N'56d6e903-f92c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV01      ', N'NGUYEN HONG', N'SON       ', N'CNTT    ', N'7dae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV02      ', N'TRUONG DINH', N'HUY       ', N'CNTT    ', N'7eae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV03      ', N'NGUYEN XUAN', N'KHANH     ', N'VT      ', N'7fae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV04      ', N'TRAN DINH', N'THUAN     ', N'VT      ', N'80ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV05      ', N'LUU NGUYEN KI', N'THU', N'CNTT    ', N'81ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV06      ', N'NGUYEN ANH ', N'HAO', N'CNTT    ', N'82ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV07      ', N'VO XUAN', N'THE', N'CNTT    ', N'83ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV09      ', N'NGUYEN TAT BAO', N'THIEN', N'VT      ', N'84ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV10      ', N'HUYNH TRUNG', N'TRU', N'CNTT    ', N'85ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV11      ', N'NGUYEN ANH', N'PHONG', N'VT      ', N'86ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV12      ', N'NGUYEN LINH', N'NHAM', N'CNTT    ', N'87ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'D16CQ100', N'2018-2019', 1, 7000000, 0, N'8e9d412b-ec29-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'D16CQ102', N'2018-2019', 1, 7000000, 0, N'ed674987-142a-ea11-a666-9cda3ef7e39b')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'N16CN61 ', N'2018-2019', 1, 7000000, 7000000, N'e37b7cbe-122d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'N16CN62 ', N'2018-2019', 1, 7000000, 7000000, N'109744d5-122d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'N16CN63 ', N'2018-2019', 1, 7000000, 7000000, N'9ef5c7e5-122d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'N16CN66 ', N'2018-2019', 1, 5000000, 5000000, N'0a9baff6-122d-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[KHOA] ([MAKH], [TENKH], [rowguid]) VALUES (N'CNTT    ', N'Công nghệ thông tin', N'73ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[KHOA] ([MAKH], [TENKH], [rowguid]) VALUES (N'VT      ', N'Viễn thông', N'74ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'C10THA1 ', N'Cao dang chính  CNTT', N'CNTT    ', N'88ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D08VTA1 ', N'Đại học chính qui 1  Viễn thông Khóa 2008', N'VT      ', N'8eae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D08VTA2 ', N'Đại học chính qui 2  Viễn thông Khóa 2008', N'VT      ', N'ce30e983-2ce7-e911-a650-9cda3ef7e398')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D09VTA1 ', N'Đại học chính qui 1  Viễn thông Khóa 2009', N'VT      ', N'8fae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D11CQ1  ', N'Đại học chính quy 3', N'CNTT    ', N'a3638ba3-ed2c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D15CQCN1', N'Đại học chính qui 1  ngành Hệ thống thông tin Khóa 2015', N'CNTT    ', N'8dae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D15CQCN2', N'Đại học chính quý lop cntt khóa 2015 02', N'CNTT    ', N'86fd689c-ed2c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D15VTA1 ', N'Vien thong 1', N'VT      ', N'fad067a9-94e3-e911-a64e-9cda3ef7e39b')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D15VTA12', N'Vien thong 3', N'VT      ', N'73293c78-2ce7-e911-a650-9cda3ef7e398')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D15VTA2 ', N'Vien thong 8', N'VT      ', N'bfaec3c8-eff0-e911-a654-9cda3ef7e39b')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D16CQCN1', N'Đại học chính qui 1  ngành Công nghệ thông tin Khóa 2016', N'CNTT    ', N'8cae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D16CQCN2', N'Đại học chính quy', N'CNTT    ', N'90ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D16VTA1 ', N'2016 vt1', N'VT      ', N'97cbad45-84f9-e911-a658-9cda3ef7e39b')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'CSDL1   ', N'Co so du lieu', N'76ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'CSDLP   ', N'Co so du lieu phan tan', N'77ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'CTDL    ', N'Cấu trúc dữ liệu', N'75ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'LTCB    ', N'Lap trinh can ban', N'79ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'THCS1   ', N'Tin hoc co so 1', N'7aae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'THDC    ', N'Tin học nâng cao', N'7bae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'TRR1    ', N'Toán rời rạc 1', N'7cae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'VB      ', N'lập trình visua basic', N'78ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'VXL     ', N'Vi xử lí', N'd4b51a64-ea22-ea11-a662-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'08VTA01 ', N'Luong', N'dai', N'D09VTA1 ', 0, CAST(N'2000-06-28T00:00:00.000' AS DateTime), N'hcm', N'hcm', N'a', 0, N'b3867eea-06fb-e911-a658-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'08VTA02 ', N'Phùng', N'B', N'D09VTA1 ', 0, CAST(N'2000-06-28T00:00:00.000' AS DateTime), N'hcm', N'hcm', N'a', 0, N'70c01cf5-06fb-e911-a658-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'08VTA101', N'Nguyễn Thanh', N'Hằng', N'D08VTA1 ', 1, CAST(N'1975-12-07T00:00:00.000' AS DateTime), N'Haø noäi', N'11 Leâ Vaên Syõ', N'', 0, N'95ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'08VTA102', N'Luong', N'Trang', N'D09VTA1 ', 0, CAST(N'2000-06-28T00:00:00.000' AS DateTime), N'hcm', N'hcm', N'a', 0, N'035314a3-d7fa-e911-a658-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'09THA101', N'Le Thi Bích', N'Thùy', N'D16CQCN1', 1, CAST(N'1976-06-06T00:00:00.000' AS DateTime), N'update4', N'Ngoâ Quyeàn', N' ', 0, N'e5dccbfb-d7fa-e911-a658-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'09THA102', N'Trần Thi', N'Hoa', N'D16CQCN1', 0, CAST(N'1976-07-07T00:00:00.000' AS DateTime), N'HCM', N'222 Lyù Thaùi Toå', N' ', 0, N'6bfbb973-d7fa-e911-a658-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'09THA103', N'Nguyễn Thị Yến', N'Lan', N'D16CQCN1', 0, CAST(N'1976-08-08T00:00:00.000' AS DateTime), N'Khaùnh Hoøa', N'333 HHT, BT', N'', 0, N'e6dccbfb-d7fa-e911-a658-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'1       ', N'1', N'1', N'D09VTA1 ', 1, CAST(N'2019-10-21T00:00:00.000' AS DateTime), N'1', N'1', N'1', 0, N'14cba900-07fb-e911-a658-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'2       ', N'adad', N'sdsds', N'D16CQCN2', 1, CAST(N'2019-12-18T00:00:00.000' AS DateTime), N'fds', N'fsd', N'fds', 0, N'fe7dda49-1023-ea11-a662-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'3       ', N'adad', N'sdsds', N'D16CQCN2', 1, CAST(N'2019-12-18T00:00:00.000' AS DateTime), N'fds', N'fsd', N'fds', 1, N'ff7dda49-1023-ea11-a662-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'4       ', N'adad', N'sdsds', N'D16CQCN2', 1, CAST(N'2019-12-18T00:00:00.000' AS DateTime), N'fds', N'fsd', N'fds', 1, N'007eda49-1023-ea11-a662-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'5       ', N'adad', N'sdsds', N'D16CQCN2', 1, CAST(N'2019-12-18T00:00:00.000' AS DateTime), N'fds', N'fsd', N'fds', 1, N'2a5f5751-1023-ea11-a662-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'abvvv   ', N's', N's', N'D16VTA1 ', 1, CAST(N'2019-12-04T00:00:00.000' AS DateTime), N's', N's', N's', 0, N'07bf1c65-de20-ea11-a662-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'D16CQ100', N'abc', N'ad', N'D16CQCN2', 0, CAST(N'2000-07-13T00:00:00.000' AS DateTime), N'a', N'a', N'a', 0, N'08ffcdbc-e122-ea11-a662-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'D16CQ101', N'A', N'a', N'D16CQCN2', 1, CAST(N'2019-11-26T00:00:00.000' AS DateTime), N'a', N'a', N'a', 0, N'07ffcdbc-e122-ea11-a662-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'D16CQ102', N'Nguyen', N'An', N'D16CQCN2', 1, CAST(N'2019-02-20T00:00:00.000' AS DateTime), N'a', N'a', N'a', 0, N'fddafc41-2d11-ea11-a65f-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'D16CQ103', N'Tran', N'B', N'D16CQCN2', 0, CAST(N'2019-11-05T00:00:00.000' AS DateTime), N'aaa', N'aa', N'', 0, N'd2825096-d122-ea11-a662-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'g       ', N'g', N'g', N'D09VTA1 ', 0, CAST(N'2019-11-05T00:00:00.000' AS DateTime), N'g', N'g', N'g', 0, N'8a7e5654-9711-ea11-a65f-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N14DCN02', N'THAI', N'HA', N'D15CQCN1', 0, CAST(N'1998-06-16T00:00:00.000' AS DateTime), N'ĐĂC LẮC', N'HCM', N'A', 0, N'2cd9b241-ebfa-e911-a658-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15DCCN1', N'Tran Nguyen', N'Minh', N'D15CQCN1', 1, CAST(N'1995-06-19T00:00:00.000' AS DateTime), N'PHU TAN', N'22 Caø Mau', N'a', 0, N'99ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15DCCN2', N'Nguyen Hoang', N'An', N'D15CQCN1', 1, CAST(N'1995-06-06T00:00:00.000' AS DateTime), N'PHU YEN', N'HA NOI', N'', 0, N'92ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15DCCN3', N'Lê Thị', N'Thu', N'D15CQCN1', 0, CAST(N'1995-02-19T00:00:00.000' AS DateTime), N'Phuù yeân', N'CAN THO', N' ', 0, N'94ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15VT01 ', N'ĐỖ DUY', N'MẠNH', N'D15VTA1 ', 1, CAST(N'2009-06-17T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'0c74452d-f12c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15VT02 ', N'BÙI TIẾN ', N'DŨNG', N'D15VTA1 ', 1, CAST(N'1997-05-11T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'9ea3dc44-f12c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15VT03 ', N'NGUYỄN CÔNG', N'PHƯỢNG', N'D15VTA1 ', 0, CAST(N'1989-01-16T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'e6c16b63-f12c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15VT04 ', N'HUỲNH TẤN', N'SINH', N'D15VTA1 ', 1, CAST(N'2020-01-09T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'f72d3a77-f12c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN61 ', N'Phùng', N'Đại', N'D15CQCN2', 1, CAST(N'1998-06-16T00:00:00.000' AS DateTime), N'Nam Định', N'HCM', NULL, 0, N'd1f118f2-ef2c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN62 ', N'TRẦN', N'TRANG', N'D15CQCN2', 1, CAST(N'1997-06-11T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'bd0ae61d-f02c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN63 ', N'NGUYẾN ', N'LINH', N'D15CQCN2', 1, CAST(N'1998-07-30T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'c761f93b-f02c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN64 ', N'PHAN VĂN', N'ĐỨC', N'D15CQCN2', 1, CAST(N'1998-10-13T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'2d31fc5e-f02c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN65 ', N'NGUYẾN QUANG', N'HẢI', N'D15CQCN2', 1, CAST(N'1997-10-16T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'5aa7a78a-f02c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN66 ', N'NGUYỄN TIẾN', N'LINH', N'D15CQCN2', 1, CAST(N'1998-06-24T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'df3258b6-f02c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN67 ', N'ĐOÀN VĂN', N'HẬU', N'D15CQCN2', 1, CAST(N'1999-07-15T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'6b7ef3d8-f02c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16DC02 ', N'NGUYEN', N'TRANG', N'D15CQCN1', 0, CAST(N'1997-02-12T00:00:00.000' AS DateTime), N'HCM', N'HN', N'A', 0, N'ba56ac17-d7fa-e911-a658-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16DCCN4', N'Phung Van', N'Dai1', N'D16CQCN1', 1, CAST(N'1998-06-16T00:00:00.000' AS DateTime), N'Nam Dinh', N'HCM', N'', 0, N'93ae9f02-8be3-e911-a64d-9cda3ef7e398')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16DCN05', N'Nguyễn', N'Linh', N'D08VTA2 ', 1, CAST(N'2019-11-12T00:00:00.000' AS DateTime), N'a', N'a', N'a', 0, N'de4ccf38-9711-ea11-a65f-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16VT05 ', N'HÀ ĐỨC', N'CHINH', N'D15VTA1 ', 1, CAST(N'1999-06-16T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'c4e1a78d-f12c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16VT06 ', N'TRẦN ĐÌNH', N'TRỌNG', N'D15VTA1 ', 1, CAST(N'2020-01-16T00:00:00.000' AS DateTime), N'A', N'A', N'A', 0, N'e8d286a6-f12c-ea11-a668-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16VT5  ', N'Lionel', N'Messi', N'D08VTA2 ', 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'NH', N'HN', N'Mã SV cũ N16DCCN5 chuyển từ lớp C10THA1 ', 0, N'e56e9efe-752c-ea11-a667-9cda3ef7e39b')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'svte    ', N'test', N'test', N'D11CQ1  ', 0, CAST(N'2020-01-07T00:00:00.000' AS DateTime), N'r', N'r', N'r', 0, N'99a6cbef-082d-ea11-a668-9cda3ef7e39b')
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_TENLOP]    Script Date: 1/2/2020 6:30:40 PM ******/
ALTER TABLE [dbo].[LOP] ADD  CONSTRAINT [UK_TENLOP] UNIQUE NONCLUSTERED 
(
	[TENLOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MONHOC]    Script Date: 1/2/2020 6:30:40 PM ******/
ALTER TABLE [dbo].[MONHOC] ADD  CONSTRAINT [IX_MONHOC] UNIQUE NONCLUSTERED 
(
	[TENMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DIEM] ADD  CONSTRAINT [MSmerge_df_rowguid_02AD8A49355F4FC3B364B1C33D841CE8]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[GIANGVIEN] ADD  CONSTRAINT [MSmerge_df_rowguid_770F5822EB984E28B2B80C3D3A5BE3AD]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[HOCPHI] ADD  CONSTRAINT [DF_HOCPHI_HOCKY]  DEFAULT ((1)) FOR [HOCKY]
GO
ALTER TABLE [dbo].[HOCPHI] ADD  CONSTRAINT [DF_HOCPHI_HOCPHI]  DEFAULT ((6000000)) FOR [HOCPHI]
GO
ALTER TABLE [dbo].[HOCPHI] ADD  CONSTRAINT [DF_HOCPHI_SOTIENDADONG]  DEFAULT ((0)) FOR [SOTIENDADONG]
GO
ALTER TABLE [dbo].[HOCPHI] ADD  CONSTRAINT [MSmerge_df_rowguid_BED210DAB5F445B5AAB691B4E318BE66]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[KHOA] ADD  CONSTRAINT [MSmerge_df_rowguid_01143F04F9644A3D819621E365A51C7B]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[LOP] ADD  CONSTRAINT [MSmerge_df_rowguid_8E41E13313E94F7AA1F7591F07B715DE]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[MONHOC] ADD  CONSTRAINT [MSmerge_df_rowguid_9A9B75CB125B4DC8B00DE14C719D8A5C]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[SINHVIEN] ADD  CONSTRAINT [MSmerge_df_rowguid_FF200BFCD2D041A5B5F98A1A7EA417F8]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[DIEM]  WITH CHECK ADD  CONSTRAINT [FK_DIEM_MONHOC1] FOREIGN KEY([MAMH])
REFERENCES [dbo].[MONHOC] ([MAMH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [FK_DIEM_MONHOC1]
GO
ALTER TABLE [dbo].[DIEM]  WITH NOCHECK ADD  CONSTRAINT [FK_DIEM_SINHVIEN] FOREIGN KEY([MASV])
REFERENCES [dbo].[SINHVIEN] ([MASV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [FK_DIEM_SINHVIEN]
GO
ALTER TABLE [dbo].[GIANGVIEN]  WITH CHECK ADD  CONSTRAINT [FK_GIANGVIEN_KHOA] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHOA] ([MAKH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GIANGVIEN] CHECK CONSTRAINT [FK_GIANGVIEN_KHOA]
GO
ALTER TABLE [dbo].[HOCPHI]  WITH CHECK ADD  CONSTRAINT [FK_HOCPHI_SINHVIEN] FOREIGN KEY([MASV])
REFERENCES [dbo].[SINHVIEN] ([MASV])
GO
ALTER TABLE [dbo].[HOCPHI] CHECK CONSTRAINT [FK_HOCPHI_SINHVIEN]
GO
ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_KHOA] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHOA] ([MAKH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_KHOA]
GO
ALTER TABLE [dbo].[SINHVIEN]  WITH CHECK ADD  CONSTRAINT [FK_SINHVIEN_LOP] FOREIGN KEY([MALOP])
REFERENCES [dbo].[LOP] ([MALOP])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SINHVIEN] CHECK CONSTRAINT [FK_SINHVIEN_LOP]
GO
ALTER TABLE [dbo].[DIEM]  WITH NOCHECK ADD  CONSTRAINT [CK_DIEM_DIEM] CHECK  (([DIEM]>=(0) AND [DIEM]<=(10)))
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [CK_DIEM_DIEM]
GO
ALTER TABLE [dbo].[DIEM]  WITH NOCHECK ADD  CONSTRAINT [CK_DIEM_LAN] CHECK  (([LAN]=(1) OR [LAN]=(2)))
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [CK_DIEM_LAN]
GO
/****** Object:  StoredProcedure [dbo].[ChuyenLop]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ChuyenLop]
  @X nvarchar(8), @ML nvarchar(10)
AS
	DECLARE @MALOP NVARCHAR(10)
	set @malop=(select MALOP from sinhvien   where masv =@X)
  if exists(select masv from sinhvien   where masv =@X)
    if exists(select malop from Lop where  malop =@ML)
       Update  sinhvien set malop=@ML,GHICHU='Chuyen tu lop'+@MALOP+'sang lop'+@ML        
						where masv=@X  
  else
    if exists(select masv from link1.qldsv.dbo.sinhvien  where masv =@X)
      if exists(select malop from link1.qldsv.dbo.Lop where  malop =@ML)
        Update  link1.qldsv.dbo.sinhvien  set malop=@ML,GHICHU='Chuyen tu lop'+@MALOP+'sang lop'+@ML  
				where masv=@X
    
GO
/****** Object:  StoredProcedure [dbo].[Lay_Tenlogin]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Lay_Tenlogin]
  @USERNAME VARCHAR(50)
  
AS
select tendangnhap=SUSER_SNAME(sid) from sys.sysusers where name=@USERNAME
GO
/****** Object:  StoredProcedure [dbo].[SETNGHIHOC]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SETNGHIHOC]
  @X nvarchar(8), @GHICHU nvarchar(200)
AS
  if exists(select masv from sinhvien   where masv =@X)
  begin
       Update  sinhvien set NGHIHOC=1,GHICHU=@GHICHU        
						where masv=@X  
	end
  else
      if exists(select masv from link1.qldsv.dbo.sinhvien   where masv =@X)
	 begin
        Update  link1.qldsv.dbo.sinhvien  set NGHIHOC=1,GHICHU=@GHICHU 
				where masv=@X
	end
	 else 
	 if exists(select masv from link0.qldsv.dbo.sinhvien   where masv =@X)
	 begin
        Update  link0.qldsv.dbo.sinhvien  set NGHIHOC=1,GHICHU=@GHICHU 
				where masv=@X
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_BANGDIEM]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_BANGDIEM]
@MALOP NVARCHAR (50),@MAMH NVARCHAR (50),@LANTHI int
AS 
  
   select HO,TEN ,DIEM=ISNULL(DIEM,0) from (select MASV,HO,TEN from SINHVIEN where MALOP=@MALOP and NGHIHOC=0) as sv left join (select * from DIEM where MAMH=@MAMH and LAN=@LANTHI) as d on sv.MASV=d.MASV
  --select HO,TEN,  DIEM from DIEM, (select MASV,HO,TEN from SINHVIEN where MALOP=@MALOP) as sv where DIEM.MASV = sv.MASV and MAMH=@MAMH and LAN=@LANTHI
 
 
 --select HO,TEN ,ISNULL(DIEM,0) from (select MASV,HO,TEN from SINHVIEN) as sv left join (select * from DIEM where MAMH='VB') as d on sv.MASV=d.MASV 
GO
/****** Object:  StoredProcedure [dbo].[SP_BANGDIEMTONGKET]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BANGDIEMTONGKET]
@MALOP NVARCHAR (50)
AS 
  select MASV,HOVATEN=HO+' '+TEN,TENMH,DIEM from V_BANGDIEMTONGKET where MALOP=@MALOP
GO
/****** Object:  StoredProcedure [dbo].[SP_BDMH]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_BDMH]
@MALOP NVARCHAR(10), @MAMH NVARCHAR(10),  @LANTHI INT
AS
BEGIN
  select sv.MASV,HoVaTen=HO+' '+TEN ,DIEM=ISNULL(DIEM,0) from (select MASV,HO,TEN from SINHVIEN where MALOP=@MALOP and NGHIHOC=0) as sv left join (select * from DIEM where MAMH=@MAMH and LAN=@LANTHI) as d on sv.MASV=d.MASV
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DANGNHAP]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DANGNHAP]
@TENLOGIN NVARCHAR (50)
AS
DECLARE @TENUSER NVARCHAR(50)
SELECT @TENUSER=NAME FROM sys.sysusers WHERE sid = SUSER_SID(@TENLOGIN)
 
 SELECT USERNAME = @TENUSER, 
  HOTEN = (SELECT HO+ ' '+ TEN FROM GIANGVIEN  WHERE MAGV = @TENUSER ),
   TENNHOM= NAME
   FROM sys.sysusers 
   WHERE UID = (SELECT GROUPUID 
                 FROM SYS.SYSMEMBERS 
                   WHERE MEMBERUID= (SELECT UID FROM sys.sysusers 
                                      WHERE NAME=@TENUSER))
GO
/****** Object:  StoredProcedure [dbo].[SP_DSTHIHETMON]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DSTHIHETMON]
@MALOP NVARCHAR(10)
AS
select MASV,HOVATEN=HO+' '+TEN,SOTO='',DIEM='',CHUKI='' from SINHVIEN where MALOP=@MALOP and NGHIHOC=0
GO
/****** Object:  StoredProcedure [dbo].[SP_INDANHSACHSINHVIEN]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[SP_INDANHSACHSINHVIEN] @MALOP nchar(8)
AS 
SELECT
	   HO,
	   TEN,
	   PHAI = (CONVERT(NVARCHAR(3), CASE PHAI WHEN 1 THEN N'Nam' ELSE N'Nữ' END)),
	   Convert(nvarchar, NGAYSINH, 105)AS NGAYSINH,
	   NOISINH,
	   DIACHI 
	FROM SINHVIEN
	WHERE MALOP=@MALOP and NGHIHOC=0
GO
/****** Object:  StoredProcedure [dbo].[SP_INHOCPHILOP]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SP_INHOCPHILOP] @MALOP nchar(8), @NIENKHOA nvarchar(12), @HOCKY INT
AS 
SELECT
	   HOTEN=HO+' '+TEN,
	   ISNULL(HOCPHI,0) as HOCPHI,
	   ISNULL(SOTIENDADONG,0) as SOTIENDADONG
FROM (SELECT MASV,HO,TEN 
	  FROM SINHVIEN 
	  WHERE MALOP=@MALOP) AS SV 
	LEFT JOIN 
	  (SELECT MASV,HOCPHI,SOTIENDADONG 
	   FROM HOCPHI 
	   WHERE NIENKHOA=@NIENKHOA AND HOCKY=@HOCKY) AS HP
	ON SV.MASV=HP.MASV
ORDER BY TEN ASC




GO
/****** Object:  StoredProcedure [dbo].[SP_INPHIEUDIEM]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_INPHIEUDIEM] @MASV nchar(8)
AS 
  
If  exists(select masv,NGHIHOC from  sinhvien where masv =@MASV AND NGHIHOC=0)
BEGIN
	SELECT
		TENMH,
		MAX(DIEM) as DIEM
	FROM
			MONHOC AS MH
		INNER JOIN 
			(SELECT DIEM,MAMH FROM DIEM WHERE MASV=@MASV) AS D
			ON MH.MAMH = D.MAMH,
			SINHVIEN
	GROUP BY
		MH.TENMH
	ORDER BY
		MH.TENMH ASC
END
ELSE
    raiserror ( 'Ma sinh vien ban tim khong co hoac sinh vien da nghi hoc', 16, 1)



GO
/****** Object:  StoredProcedure [dbo].[SP_TAOLOGIN]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_TAOLOGIN]
  @LGNAME VARCHAR(50),
  @PASS VARCHAR(50),
  @USERNAME VARCHAR(50),
  @ROLE VARCHAR(50)
AS
  DECLARE @RET INT
  EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS,'QLDSV'
  IF (@RET =1)  -- LOGIN NAME BI TRUNG
     RETURN 1
 
  EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
  IF (@RET =1)  -- USER  NAME BI TRUNG
  BEGIN
       EXEC SP_DROPLOGIN @LGNAME
       RETURN 2
  END
  EXEC sp_addrolemember @ROLE, @USERNAME
  IF @ROLE= 'PGV' OR @ROLE= 'KHOA' OR @ROLE='PKETOAN'
    EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
RETURN 0  -- THANH CONG

GO
/****** Object:  StoredProcedure [dbo].[SP_TIMDIEMTUMAMONHOC]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_TIMDIEMTUMAMONHOC] 
@MAMH Nvarchar(10)
AS
 
If  exists(select MAMH from  MONHOC where MAMH =@MAMH)
 BEGIN
	select top 1 MAMH
		from DIEM
			where MAMH=@MAMH
END
 else
    if exists(select MAMH from LINK1.qldsv.dbo.monhoc where MAMH =@MAMH)
	BEGIN
     select top 1  MAMH
        from LINK1.qldsv.dbo.DIEM as diem
           where MAMH=@MAMH  
	END
  else
    if exists(select MAMH from LINK0.qldsv.dbo.monhoc where MAMH =@MAMH)
	BEGIN
     select top 1  MAMH
        from LINK0.qldsv.dbo.DIEM as diem
           where MAMH=@MAMH  
	END






GO
/****** Object:  StoredProcedure [dbo].[SP_TIMDIEMTUMASINHVIEN]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_TIMDIEMTUMASINHVIEN] 
@MASV Nvarchar(10)
AS
 
If  exists(select MASV from  SINHVIEN where MASV =@MASV)
 BEGIN
	select top 1 MASV
		from DIEM
			where MASV=@MASV
END
 else
    if exists(select MASV from LINK1.qldsv.dbo.sinhvien where MASV =@MASV)
	BEGIN
     select top 1  MASV
        from LINK1.qldsv.dbo.DIEM as diem
           where MASV=@MASV  
	END
  else
    if exists(select MASV from LINK0.qldsv.dbo.sinhvien where MASV =@MASV)
	BEGIN
     select top 1  MASV
        from LINK0.qldsv.dbo.DIEM as diem
           where MASV=@MASV  
	END






GO
/****** Object:  StoredProcedure [dbo].[SP_TIMHOCPHITUMASINHVIEN]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_TIMHOCPHITUMASINHVIEN] 
@MASV Nvarchar(10)
AS
 
if exists(select MASV from LINK3.qldsv.dbo.sinhvien where MASV =@MASV)
	BEGIN
     select top 1  MASV
        from LINK3.qldsv.dbo.HOCPHI as HOCPHI
           where MASV=@MASV  
	END






GO
/****** Object:  StoredProcedure [dbo].[SP_TIMSV]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_TIMSV] 
@X Nvarchar(10)
AS
 
If  exists(select masv from  sinhvien where masv =@X)
 BEGIN
	select masv, ho, ten,NGAYSINH,tenlop, tenkh ,khoa.MAKH,sv.MALOP
		from khoa, Lop, (SELECT masv,Ho, TEN, NGAYSINH,MALOP FROM Sinhvien where MASV=@X) as SV
			where khoa.MAKH=lop.MAKH  and LOP.MALOP=SV.MALOP 
END
 else
    if exists(select masv from LINK1.qldsv.dbo.sinhvien where masv =@X)
	 BEGIN
     select masv, ho, ten,NGAYSINH,tenlop, tenkh ,kh.MAKH,sv.MALOP
        from LINK1.qldsv.dbo.khoa KH, LINK1.qldsv.dbo.lop L, (SELECT masv,Ho, TEN, NGAYSINH,MALOP FROM LINK1.qldsv.dbo.Sinhvien where MASV=@X) as SV
           where KH.MAKH=L.MAKH  and L.MALOP=SV.MALOP  
	end
 else
    if exists(select masv from LINK0.qldsv.dbo.sinhvien where masv =@X)
	 BEGIN
     select masv, ho, ten,NGAYSINH,tenlop, tenkh ,kh.MAKH,sv.MALOP
        from LINK0.qldsv.dbo.khoa KH, LINK1.qldsv.dbo.lop L, (SELECT masv,Ho, TEN, NGAYSINH,MALOP FROM LINK0.qldsv.dbo.Sinhvien where MASV=@X) as SV
           where KH.MAKH=L.MAKH  and L.MALOP=SV.MALOP  
	end




GO
/****** Object:  StoredProcedure [dbo].[SP_TIMSVDANGHIHOC]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_TIMSVDANGHIHOC] 
@X Nvarchar(10)
AS
 
If  exists(select masv from  sinhvien where masv =@X)
 BEGIN
	select tenlop, tenkh , ho, ten,NGAYSINH
		from khoa, Lop, (SELECT Ho, TEN, NGAYSINH,MALOP,NGHIHOC FROM Sinhvien where MASV=@X and NGHIHOC=1) as SV
			where khoa.MAKH=lop.MAKH  and LOP.MALOP=SV.MALOP 
END
 else
    if exists(select masv from LINK1.qldsv.dbo.sinhvien where masv =@X)
	BEGIN
     select tenlop, tenkh , ho, ten,NGAYSINH
        from LINK1.qldsv.dbo.khoa KH, LINK1.qldsv.dbo.lop L, (SELECT Ho, TEN, NGAYSINH,MALOP,NGHIHOC FROM LINK1.qldsv.dbo.Sinhvien where MASV=@X and NGHIHOC=1) as SV
           where KH.MAKH=L.MAKH  and L.MALOP=SV.MALOP 
	END 
  else
    if exists(select masv from LINK0.qldsv.dbo.sinhvien where masv =@X)
	BEGIN
     select tenlop, tenkh , ho, ten,NGAYSINH
        from LINK0.qldsv.dbo.khoa KH, LINK1.qldsv.dbo.lop L, (SELECT Ho, TEN, NGAYSINH,MALOP,NGHIHOC FROM LINK0.qldsv.dbo.Sinhvien where MASV=@X and NGHIHOC=1) as SV
           where KH.MAKH=L.MAKH  and L.MALOP=SV.MALOP 
	END 




GO
/****** Object:  StoredProcedure [dbo].[Xoa_Login]    Script Date: 1/2/2020 6:30:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Xoa_Login]
  @LGNAME VARCHAR(50),
  @USRNAME VARCHAR(50)
  
AS
EXEC SP_DROPUSER @USRNAME
  EXEC SP_DROPLOGIN @LGNAME
GO
