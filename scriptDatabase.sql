USE [QLDSV]
GO
/****** Object:  User [HTKN]    Script Date: 08/30/2020 4:46:42 PM ******/
CREATE USER [HTKN] FOR LOGIN [HTKN] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [ADMIN]    Script Date: 08/30/2020 4:46:42 PM ******/
CREATE ROLE [ADMIN]
GO
/****** Object:  DatabaseRole [MSmerge_7A1AF0EBE2404840ADE62E4F9859C64A]    Script Date: 08/30/2020 4:46:42 PM ******/
CREATE ROLE [MSmerge_7A1AF0EBE2404840ADE62E4F9859C64A]
GO
/****** Object:  DatabaseRole [MSmerge_F83A1D9E84584C2687C9EA85A1413EA9]    Script Date: 08/30/2020 4:46:42 PM ******/
CREATE ROLE [MSmerge_F83A1D9E84584C2687C9EA85A1413EA9]
GO
/****** Object:  DatabaseRole [MSmerge_FBB6BB67C0524F5C9F1F379F0902E392]    Script Date: 08/30/2020 4:46:42 PM ******/
CREATE ROLE [MSmerge_FBB6BB67C0524F5C9F1F379F0902E392]
GO
/****** Object:  DatabaseRole [MSmerge_PAL_role]    Script Date: 08/30/2020 4:46:42 PM ******/
CREATE ROLE [MSmerge_PAL_role]
GO
/****** Object:  DatabaseRole [USER]    Script Date: 08/30/2020 4:46:42 PM ******/
CREATE ROLE [USER]
GO
ALTER ROLE [db_owner] ADD MEMBER [HTKN]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_7A1AF0EBE2404840ADE62E4F9859C64A]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_F83A1D9E84584C2687C9EA85A1413EA9]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_FBB6BB67C0524F5C9F1F379F0902E392]
GO
/****** Object:  Schema [ADMIN]    Script Date: 08/30/2020 4:46:42 PM ******/
CREATE SCHEMA [ADMIN]
GO
/****** Object:  Schema [MSmerge_PAL_role]    Script Date: 08/30/2020 4:46:42 PM ******/
CREATE SCHEMA [MSmerge_PAL_role]
GO
/****** Object:  Table [dbo].[DIEM]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIEM](
	[MASV] [nchar](8) NOT NULL,
	[MAMH] [nchar](8) NOT NULL,
	[LAN] [smallint] NOT NULL,
	[DIEM] [float] NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [MSmerge_df_rowguid_2E6E537C716D422D925BAC6DE392A496]  DEFAULT (newsequentialid()),
 CONSTRAINT [PK_DIEM] PRIMARY KEY CLUSTERED 
(
	[MASV] ASC,
	[MAMH] ASC,
	[LAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GIANGVIEN]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIANGVIEN](
	[MAGV] [nchar](10) NOT NULL,
	[HO] [nvarchar](50) NOT NULL,
	[TEN] [nvarchar](10) NOT NULL,
	[MAKH] [nchar](8) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [MSmerge_df_rowguid_ED44DAF9C0DD4D02848D99E6198CC04A]  DEFAULT (newsequentialid()),
 CONSTRAINT [PK_GIANGVIEN] PRIMARY KEY CLUSTERED 
(
	[MAGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOCPHI]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOCPHI](
	[MASV] [nchar](8) NOT NULL,
	[NIENKHOA] [nvarchar](12) NOT NULL,
	[HOCKY] [int] NOT NULL CONSTRAINT [DF_HOCPHI_HOCKY]  DEFAULT ((1)),
	[HOCPHI] [int] NOT NULL CONSTRAINT [DF_HOCPHI_HOCPHI]  DEFAULT ((6000000)),
	[SOTIENDADONG] [int] NOT NULL CONSTRAINT [DF_HOCPHI_SOTIENDADONG]  DEFAULT ((0)),
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [MSmerge_df_rowguid_9649DEAEEFC244C8AE946FDD4F49B5F8]  DEFAULT (newsequentialid()),
 CONSTRAINT [PK_HOCPHI] PRIMARY KEY CLUSTERED 
(
	[MASV] ASC,
	[NIENKHOA] ASC,
	[HOCKY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHOA]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHOA](
	[MAKH] [nchar](8) NOT NULL,
	[TENKH] [nvarchar](40) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [MSmerge_df_rowguid_9B22C8D9C4114C9897163E600D0B5169]  DEFAULT (newsequentialid()),
 CONSTRAINT [PK_KHOA] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOP]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOP](
	[MALOP] [nchar](8) NOT NULL,
	[TENLOP] [nvarchar](40) NULL,
	[MAKH] [nchar](8) NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [MSmerge_df_rowguid_C5EB901A624D4CC9A329B12A7DA6B651]  DEFAULT (newsequentialid()),
 CONSTRAINT [PK_LOP] PRIMARY KEY CLUSTERED 
(
	[MALOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MONHOC]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONHOC](
	[MAMH] [nchar](8) NOT NULL,
	[TENMH] [nvarchar](40) NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [MSmerge_df_rowguid_BFB2DA338BAA4AF5A54FF308B1A4468E]  DEFAULT (newsequentialid()),
 CONSTRAINT [PK_MONHOC] PRIMARY KEY CLUSTERED 
(
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SINHVIEN]    Script Date: 08/30/2020 4:46:42 PM ******/
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
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [MSmerge_df_rowguid_5C75819716D04A7DBD428FF23C2683B3]  DEFAULT (newsequentialid()),
 CONSTRAINT [PK_SINHVIEN] PRIMARY KEY CLUSTERED 
(
	[MASV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[V_BANGDIEMTONGKET]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_BANGDIEMTONGKET]
AS
select  DIEM.MASV,HO,TEN,MALOP,TENMH,DIEM=MAX(DIEM) from DIEM, (select MASV,HO,TEN,MALOP from SINHVIEN where NGHIHOC=0) as sv,(select MAMH,TENMH from MONHOC) as mh
  where DIEM.MASV = sv.MASV and DIEM.MAMH=mh.MAMH group by DIEM.MASV,HO,TEN,MALOP,TENMH

GO
/****** Object:  View [dbo].[V_DS_PHANMANH]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create VIEW [dbo].[V_DS_PHANMANH]
AS
SELECT  TENKHOA=PUBS.name, TENSERVER= subscriber_server
   FROM dbo.sysmergepublications PUBS,  dbo.sysmergesubscriptions SUBS
   WHERE PUBS.pubid= SUBS.PUBID  AND PUBS.publisher <> SUBS.subscriber_server
GO
/****** Object:  View [dbo].[v_SISO]    Script Date: 08/30/2020 4:46:42 PM ******/
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
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'000002  ', N'TRR1    ', 1, 8, N'b37ed931-dfe9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'000002  ', N'VB      ', 1, 9, N'db6c632a-dfe9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'000004  ', N'TRR1    ', 1, 8, N'2c7e0247-dfe9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'000004  ', N'VB      ', 1, 9, N'2d7e0247-dfe9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'000005  ', N'CTDL    ', 1, 8, N'63c9b690-7bea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'000006  ', N'CTDL    ', 1, 6, N'64c9b690-7bea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'10THA11 ', N'abc     ', 1, 5, N'cc0ed6db-00ea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'10THA11 ', N'abc     ', 2, 6, N'f97238d4-79ea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'10THA11 ', N'CSDL1   ', 1, 6, N'fb9c2a22-e4e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'10THA11 ', N'CTDL    ', 1, 6, N'71ef5bb5-02ea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'ấdf     ', N'abc     ', 1, 5, N'cd0ed6db-00ea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'ấdf     ', N'CSDL1   ', 1, 4, N'fc9c2a22-e4e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'ấdf     ', N'CTDL    ', 1, 5, N'72ef5bb5-02ea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n160001 ', N'abc     ', 1, 5, N'ce0ed6db-00ea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n160001 ', N'abc     ', 2, 6, N'fa7238d4-79ea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n160001 ', N'CSDL1   ', 1, 5, N'fd9c2a22-e4e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n160001 ', N'CTDL    ', 1, 5, N'73ef5bb5-02ea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn19 ', N'TRR1    ', 1, 8, N'550775a6-7024-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn19 ', N'VB      ', 1, 9, N'560775a6-7024-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn20 ', N'TRR1    ', 1, 8, N'e5cd6464-7124-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn20 ', N'VB      ', 1, 9, N'e6cd6464-7124-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn21 ', N'TRR1    ', 1, 8, N'38352197-7124-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn21 ', N'VB      ', 1, 9, N'39352197-7124-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN34 ', N'TRR1    ', 1, 8, N'02c7ce64-2520-ea11-bb74-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN34 ', N'VB      ', 1, 9, N'334a035d-2520-ea11-bb74-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn34 ', N'VB      ', 2, 10, N'74837194-8824-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn91 ', N'TRR1    ', 1, 8, N'233c500a-7724-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn91 ', N'VB      ', 1, 9, N'243c500a-7724-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn92 ', N'TRR1    ', 1, 8, N'ef7975a6-7624-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn92 ', N'VB      ', 1, 9, N'f07975a6-7624-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn93 ', N'TRR1    ', 1, 8, N'ce313b38-7624-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn93 ', N'VB      ', 1, 9, N'cf313b38-7624-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn94 ', N'TRR1    ', 1, 8, N'1cc36b8d-7524-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn94 ', N'VB      ', 1, 9, N'1dc36b8d-7524-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn95 ', N'TRR1    ', 1, 8, N'dd7ad30a-7424-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn95 ', N'VB      ', 1, 9, N'de7ad30a-7424-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'N16CN99 ', N'LTW     ', 1, 2, N'ce46461d-8f24-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn99 ', N'TRR1    ', 1, 8, N'01036369-7224-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn99 ', N'TRR1    ', 2, 10, N'cf3eaf05-7324-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn99 ', N'VB      ', 1, 9, N'02036369-7224-ea11-bb77-94e97998d46f')
INSERT [dbo].[DIEM] ([MASV], [MAMH], [LAN], [DIEM], [rowguid]) VALUES (N'n16cn99 ', N'VB      ', 2, 5, N'd03eaf05-7324-ea11-bb77-94e97998d46f')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV00      ', N'Tan', N'Hanh', N'CNTT    ', N'c04f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV02      ', N'TRUONG DINH', N'HUY       ', N'CNTT    ', N'c24f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV03      ', N'NGUYEN XUAN', N'KHANH     ', N'VT      ', N'c34f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV04      ', N'TRAN DINH', N'THUAN     ', N'VT      ', N'c44f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV05      ', N'Nguyen Anh ', N'Hao', N'CNTT    ', N'c54f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV06      ', N'TRAN TRUNG', N'NGHIA', N'CNTT    ', N'41678219-eee9-e911-bb63-98e7f45705b9')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV07      ', N'Pham Thanh', N'Toan', N'VT      ', N'bc590c71-eee9-e911-bb63-98e7f45705b9')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV10      ', N'NGUYEN HONG', N'SON', N'VT      ', N'4f365155-e7e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV11      ', N'NGUYEN HONG', N'SON       ', N'CNTT    ', N'c14f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[GIANGVIEN] ([MAGV], [HO], [TEN], [MAKH], [rowguid]) VALUES (N'GV12      ', N'Huynh Trung', N'Tru', N'CNTT    ', N'5c216bb2-c9e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'000002  ', N'2019-2020', 1, 1000000, 1000000, N'd0591746-dee9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'000002  ', N'2019-2020', 2, 2000000, 2000000, N'4f321255-dee9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'000003  ', N'2019-2020', 1, 1000000, 1000000, N'9d412fa7-dee9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'000003  ', N'2019-2020', 2, 2000000, 2000000, N'9e412fa7-dee9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'000004  ', N'2019-2020', 1, 1000000, 1000000, N'2e7e0247-dfe9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'000004  ', N'2019-2020', 2, 2000000, 2000000, N'2f7e0247-dfe9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'000005  ', N'2018-2019', 1, 100000000, 100000000, N'7d2ce85e-7cea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'08VTA101', N'2008-2012', 2, 5000000, 100000, N'1520c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'09THA103', N'2008-2009', 1, 500000, 500000, N'1620c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16at01 ', N'2018-2019', 1, 100000000, 10000000, N'1720c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn19 ', N'2008-2009', 1, 5000000, 500000, N'1820c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn20 ', N'2008-2009', 1, 5000000, 500000, N'1920c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn21 ', N'2008-2009', 1, 5000000, 500000, N'1a20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'N16CN34 ', N'2008-2009', 1, 5000000, 500000, N'1b20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'N16CN34 ', N'2017-2018', 1, 500000000, 500000000, N'1c20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'N16CN34 ', N'2017-2018', 2, 5000000, 50000000, N'1d20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn34 ', N'2017-2018', 3, 65654564, 56456456, N'1e20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'N16CN34 ', N'2018-2019', 1, 10000000, 50000000, N'1f20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'N16CN34 ', N'2018-2019', 2, 5000000, 1000000, N'2020c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn34 ', N'2019-2020', 1, 455445, 45456456, N'2120c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn34 ', N'2019-2020', 2, 1456456, 5456456, N'2220c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn34 ', N'2020-2021', 1, 3645645, 56456, N'2320c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn34 ', N'2020-2021', 2, 564564, 564564, N'2420c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn34 ', N'2021-2022', 1, 56456456, 56456456, N'2520c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn91 ', N'2008-2009', 1, 5000000, 500000, N'2620c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn92 ', N'2008-2009', 1, 5000000, 500000, N'2720c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn93 ', N'2008-2009', 1, 5000000, 500000, N'2820c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn94 ', N'2008-2009', 1, 5000000, 500000, N'2920c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn95 ', N'2008-2009', 1, 5000000, 500000, N'2a20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn98 ', N'2008-2009', 1, 5000000, 500000, N'2b20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn99 ', N'2008-2009', 1, 5000000, 500000, N'2c20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16cn99 ', N'2008-2009', 2, 5000000, 5000000, N'2d20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[HOCPHI] ([MASV], [NIENKHOA], [HOCKY], [HOCPHI], [SOTIENDADONG], [rowguid]) VALUES (N'n16vt55 ', N'2008-2009', 1, 5000000, 500000, N'2e20c38e-c5e9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[KHOA] ([MAKH], [TENKH], [rowguid]) VALUES (N'CNTT    ', N'Công nghệ thông tin', N'b64f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[KHOA] ([MAKH], [TENKH], [rowguid]) VALUES (N'VT      ', N'Viễn thông', N'b74f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'C10THA1 ', N'Cao dang chính qui CNTT', N'CNTT    ', N'c64f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D08VTA1 ', N'Viễn thông Khóa 2008', N'VT      ', N'ca4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D09VTA1 ', N'Viễn thông Khóa 2009', N'VT      ', N'cb4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D15CQCN1', N'Hệ thống thông tin', N'CNTT    ', N'c94f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D16CQCN1', N'Công nghệ thông tin 16 ', N'CNTT    ', N'c74f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D17CQCN1', N'Công nghệ thông tin 17', N'CNTT    ', N'c84f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[LOP] ([MALOP], [TENLOP], [MAKH], [rowguid]) VALUES (N'D18CN1  ', N'D18 Cong nghe 1', N'CNTT    ', N'89063f1e-7bea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'abc     ', N'Khong biet', N'61ace461-452c-ea11-bb7b-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'CSDL1   ', N'Co so du lieu', N'b94f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'CSDLP   ', N'Co so du lieu phan tan', N'ba4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'CTDL    ', N'Cau truc du lieu', N'b84f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'LTCB    ', N'Lap trinh can ban', N'bc4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'LTM12   ', N'Lập trình mạng', N'43223dea-841e-ea11-bb74-94e97998d46f')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'LTW     ', N'Lập trình web', N'797fff9c-c51c-ea11-bb73-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'MMT     ', N'Mang May Tinh', N'36809354-7bea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'sdgsdfg ', N'sdgsdgsdg', N'4b7013b0-f329-ea11-bb7a-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'THCS1   ', N'Tin hoc co so 1', N'bd4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'THDC    ', N'Tin hoïc ñaïi cöông1', N'be4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'TRR1    ', N'Toan roi rac 1', N'bf4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[MONHOC] ([MAMH], [TENMH], [rowguid]) VALUES (N'VB      ', N'Lap trình Visual Basic nang cao', N'bb4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'000002  ', N'VU', N'DUONG', N'D16CQCN1', 1, CAST(N'2020-08-13 00:00:00.000' AS DateTime), N'ND', N'ND', N'Chuyen lop. Ma sinh vien moi: 000004  ', 1, N'9997d9ec-bee9-ea11-bbd5-b94f9f9c5533')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'000003  ', N'VU', N'DUONG', N'D08VTA1 ', 1, CAST(N'2020-08-13 00:00:00.000' AS DateTime), N'ND', N'ND', N'Chuyen tu lopD09VTA1 sang lopD08VTA1 ', 0, N'9c412fa7-dee9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'000004  ', N'VU', N'DUONG', N'D08VTA1 ', 1, CAST(N'2020-08-13 00:00:00.000' AS DateTime), N'ND', N'ND', N'Chuyen lop. Ma sinh vien cu: 000002  ', 0, N'2b7e0247-dfe9-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'000005  ', N'Nguyen Van', N'A', N'D18CN1  ', 1, CAST(N'2020-08-05 00:00:00.000' AS DateTime), N'ND', N'ND', N'Chuyen tu lopD17CQCN1sang lopD18CN1  ', 0, N'43b56871-7bea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'000006  ', N'Tran Van', N'B', N'D18CN1  ', 1, CAST(N'2020-08-12 00:00:00.000' AS DateTime), N'ND', N'ND', NULL, 0, N'4420c682-7bea-ea11-bbd6-ea7cf81c617d')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'08VTA101', N'Nguyễn Thanh', N'Hằng', N'D08VTA1 ', 1, CAST(N'1975-12-07 00:00:00.000' AS DateTime), N'Haø noäi', N'11 Leâ Vaên Syõ', N' ', 0, N'd04f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'08VTA102', N'Võ Văn', N'Phát', N'D08VTA1 ', 1, CAST(N'1976-05-05 00:00:00.000' AS DateTime), N'Phuù Yeân', N'246 Phaân Ñình Phuøng', N' ', 0, N'd44f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'09THA101', N'Le Thi', N'Van', N'D16CQCN1', 0, CAST(N'1976-06-06 00:00:00.000' AS DateTime), N'Haø noäi', N'Ngoâ Quyeàn', N' ', 0, N'd54f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'09THA102', N'Trần Thi', N'Hoa', N'D16CQCN1', 0, CAST(N'1976-07-07 00:00:00.000' AS DateTime), N'Saøi goøn', N'222 Lyù Thaùi Toå', N' ', 0, N'd14f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'09THA103', N'Nguyễn Thị Yến', N'Lan', N'D16CQCN1', 0, CAST(N'1976-08-08 00:00:00.000' AS DateTime), N'Khaùnh Hoøa', N'333 HHT, BT', N' ', 1, N'd24f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'10THA11 ', N'Vu VAN', N'Duong', N'C10THA1 ', 1, CAST(N'1998-11-12 00:00:00.000' AS DateTime), N'ha noi', N'Hanoi', N' ', 0, N'55199752-ab23-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'ấdf     ', N'dss', N'sdgds', N'C10THA1 ', 1, CAST(N'1998-12-21 00:00:00.000' AS DateTime), N'sdfsd', N'sdf', N' ', 0, N'6632ad1e-c723-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'dfsdf   ', N'sdf', N'sf', N'D15CQCN1', 0, CAST(N'1905-02-24 00:00:00.000' AS DateTime), N'sdf', N'dsf', N'', 0, N'ab66b6d1-072a-ea11-bb7a-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15CN01 ', N'Tran Nguyen', N'Minh', N'D15CQCN1', 1, CAST(N'1995-06-19 00:00:00.000' AS DateTime), N'PHU TAN', N'22 Caø Mau', N' ', 0, N'd34f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15CN02 ', N'Nguyen Hoang', N'An', N'D15CQCN1', 1, CAST(N'1995-06-06 00:00:00.000' AS DateTime), N'PHU YEN', N'HA NOI', N' ', 0, N'cc4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15CN03 ', N'Lê Thị', N'Hà', N'D15CQCN1', 0, CAST(N'1995-02-19 00:00:00.000' AS DateTime), N'Phuù yeân', N'CAN THO', N' ', 0, N'cf4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N15CN09 ', N'dhfjyik', N'ghjkg', N'D15CQCN1', 0, CAST(N'2000-12-29 00:00:00.000' AS DateTime), N'ghkgk', N'hjkj', N'Chuyển sang lớp D09VTA1  với mã n15cn25', 1, N'b96248c8-002a-ea11-bb7a-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n15cn11 ', N'ádfsd', N'gfdsgf', N'D15CQCN1', 0, CAST(N'1998-12-21 00:00:00.000' AS DateTime), N'sdfdsf', N'sdfsdf', N' ', 0, N'd400b1aa-f523-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n15cn25 ', N'dhfjyik', N'ghjkg', N'D08VTA1 ', 0, CAST(N'1905-05-14 00:00:00.000' AS DateTime), N'ghkgk', N'hjkj', N'Chuyển sang lớp D16CQCN1 với mã n15cn30', 1, N'120dfb55-012a-ea11-bb7a-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n15cn30 ', N'dhfjyik', N'ghjkg', N'D16CQCN1', 0, CAST(N'1905-03-02 00:00:00.000' AS DateTime), N'ghkgk', N'hjkj', N'Mã SV cũ n15cn25 chuyển từ lớp D08VTA1 ', 0, N'e688c539-062a-ea11-bb7a-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n160001 ', N'Vu', N'Duong', N'C10THA1 ', 1, CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'ng', N'222', N'', 0, N'8b2f08eb-8ae7-ea11-bbd4-912bfaa07b4a')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16AT01 ', N'Pham Thanh', N'Nam', N'D15CQCN1', 1, CAST(N'1998-05-11 00:00:00.000' AS DateTime), N'Ha Noi', N'df', N' ', 0, N'44a2e6b7-eee9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN11 ', N'Nguyen van', N'A', N'D16CQCN1', 1, CAST(N'1998-12-10 00:00:00.000' AS DateTime), N'Nam Dinh', N'212', N' ', 0, N'a0dfa801-2823-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN123', N'sádsdf', N'afsd', N'D15CQCN1', 1, CAST(N'1995-12-21 00:00:00.000' AS DateTime), N'sdf', N'f', N' ', 0, N'fecb3a06-f623-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn14 ', N'ầdsf', N'ầdfd', N'D16CQCN1', 1, CAST(N'1998-12-21 00:00:00.000' AS DateTime), N'àdgdfg', N'fghfgj', N' ', 0, N'f82687d4-f923-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn19 ', N'Vũ Văn', N'Dương', N'D09VTA1 ', 1, CAST(N'1905-05-24 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Chuyển sang lớp D09VTA1  với mã n16cn94', 1, N'540775a6-7024-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn20 ', N'Vũ Văn', N'Dương', N'D16CQCN1', 1, CAST(N'1905-02-20 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N' ', 0, N'e4cd6464-7124-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn21 ', N'Vũ Văn', N'Dương', N'D08VTA1 ', 1, CAST(N'1905-02-27 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Chuyen tu lopD09VTA1 sang lopD08VTA1 ', 0, N'37352197-7124-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16CN34 ', N'Vũ Văn', N'Dương', N'D16CQCN1', 1, CAST(N'1998-06-23 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Chuyen tu lopD17CQCN1sang lopD16CQCN1', 0, N'cd4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn91 ', N'Vũ Văn', N'Dương', N'D17CQCN1', 1, CAST(N'1905-02-20 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Mã SV cũ n16cn92 từ lớp D08VTA1 ', 0, N'223c500a-7724-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn92 ', N'Vũ Văn', N'Dương', N'D08VTA1 ', 1, CAST(N'1905-02-27 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Chuyển sang lớp D17CQCN1 với mã n16cn91', 1, N'ee7975a6-7624-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn93 ', N'Vũ Văn', N'Dương', N'D16CQCN1', 1, CAST(N'1905-02-20 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Chuyển sang lớp D08VTA1  với mã n16cn92', 1, N'cd313b38-7624-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn94 ', N'Vũ Văn', N'Dương', N'D09VTA1 ', 1, CAST(N'1905-02-20 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Mã SV cũ n16cn19 từ lớp ', 0, N'1bc36b8d-7524-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn95 ', N'Vũ Văn', N'Dương', N'D09VTA1 ', 1, CAST(N'1905-02-27 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N' ', 0, N'dc7ad30a-7424-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn98 ', N'Vũ Văn', N'Dương', N'D16CQCN1', 1, CAST(N'1905-02-20 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Chuyển sang lớp D09VTA1  với mã n16vt55', 1, N'ce3eaf05-7324-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16cn99 ', N'Vũ Văn', N'Dương', N'D09VTA1 ', 1, CAST(N'1905-02-27 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Chuyển sang lớp D16CQCN1 với mã n16cn93', 1, N'00036369-7224-ea11-bb77-94e97998d46f')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'n16vt55 ', N'Vũ Văn', N'Dương', N'D09VTA1 ', 1, CAST(N'1905-02-27 00:00:00.000' AS DateTime), N'Nam Dinh', N'Nam Dinh', N'Mã SV cũ n16cn98 chuyển từ lớp D16CQCN1', 0, N'0d39b0f3-3426-ea11-bb7a-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'N16VTA01', N'Vũ Văn', N'Dương', N'D08VTA1 ', 1, CAST(N'1998-06-23 00:00:00.000' AS DateTime), N'Nam Dinh', N'97 Man Thien', N' ', 0, N'ce4f2fee-e3e9-e911-bb63-98e7f45705b9')
INSERT [dbo].[SINHVIEN] ([MASV], [HO], [TEN], [MALOP], [PHAI], [NGAYSINH], [NOISINH], [DIACHI], [GHICHU], [NGHIHOC], [rowguid]) VALUES (N'SV00    ', N'sádsdf', N'afsd', N'D09VTA1 ', 1, CAST(N'1905-05-17 00:00:00.000' AS DateTime), N'sdf', N'f', N'Mã SV cũ n16cn123 chuyển từ lớp D15CQCN1', 0, N'b2b7eeea-902c-ea11-bb7b-98e7f45705b9')
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_TENLOP]    Script Date: 08/30/2020 4:46:42 PM ******/
ALTER TABLE [dbo].[LOP] ADD  CONSTRAINT [UK_TENLOP] UNIQUE NONCLUSTERED 
(
	[TENLOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MONHOC]    Script Date: 08/30/2020 4:46:42 PM ******/
ALTER TABLE [dbo].[MONHOC] ADD  CONSTRAINT [IX_MONHOC] UNIQUE NONCLUSTERED 
(
	[TENMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[ChuyenLop]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SETNGHIHOC]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_BANGDIEM]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_BANGDIEM]
@MALOP NVARCHAR (50),@MAMH NVARCHAR (50),@LANTHI int
AS 
  
   select HO,TEN ,DIEM=ISNULL(DIEM,0) from (select MASV,HO,TEN from SINHVIEN where MALOP=@MALOP and NGHIHOC=0) as sv left join (select * from DIEM where MAMH=@MAMH and LAN=@LANTHI) as d on sv.MASV=d.MASV

GO
/****** Object:  StoredProcedure [dbo].[SP_BANGDIEMTONGKET]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_BANGDIEMTONGKET]
@MALOP NVARCHAR (50)
AS 
  select MASV,HOVATEN=HO+' '+TEN,TENMH,DIEM from V_BANGDIEMTONGKET where MALOP=@MALOP

GO
/****** Object:  StoredProcedure [dbo].[SP_BDMH]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_BDMH]
@MALOP NVARCHAR(10), @MAMH NVARCHAR(10),  @LANTHI INT
AS
BEGIN
  select sv.MASV,HoVaTen=HO+' '+TEN ,DIEM=ISNULL(DIEM,0) 
  from (select MASV,HO,TEN from SINHVIEN where MALOP=@MALOP and NGHIHOC=0) as sv 
  left join (select * from DIEM where MAMH=@MAMH and LAN=@LANTHI) as d 
  on sv.MASV=d.MASV
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ChuyenDiemSinhVien]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ChuyenDiemSinhVien]
@masv NCHAR( 10), @masvmoi NCHAR( 10)
AS
DECLARE @CrsrVar CURSOR,@MaSVDiem NCHAR(10), @MaMH NCHAR(10), @Lan INT, @Diem FLOAT 
SET XACT_ABORT ON
BEGIN TRAN
	BEGIN TRY
		EXEC SP_CursorDiemSinhVien  @CrsrVar OUTPUT, @masv
		FETCH NEXT FROM @CrsrVar  INTO  @MaSVDiem, @MaMH, @Lan, @Diem
		WHILE (@@FETCH_STATUS <> -1)
			BEGIN
				INSERT INTO DIEM (MASV,MAMH,LAN,DIEM) 
				VALUES (@masvmoi,@MaMH,@Lan,@Diem)
				FETCH NEXT FROM @CrsrVar  INTO  @MaSVDiem, @MaMH, @Lan, @Diem
			END
		CLOSE @CrsrVar
		DEALLOCATE @CrsrVar
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		CLOSE @CrsrVar
		DEALLOCATE @CrsrVar
		ROLLBACK TRAN
	END CATCH


GO
/****** Object:  StoredProcedure [dbo].[SP_ChuyenHocPhiSinhVien]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ChuyenHocPhiSinhVien]
@masv NCHAR(8), @masvmoi NCHAR(8)
AS
DECLARE @CrsrVar CURSOR,@MaSVHocPhi NCHAR(8), @NienKhoa NVARCHAR(12), @HocKy INT, @HocPhi INT,@SoTienDaDong INT 
SET XACT_ABORT ON
BEGIN TRAN
	BEGIN TRY
		EXEC SP_CursorHocPhiSinhVien  @CrsrVar OUTPUT, @masv
		FETCH NEXT FROM @CrsrVar  INTO  @MaSVHocPhi, @NienKhoa, @HocKy, @HocPhi, @SoTienDaDong
		WHILE (@@FETCH_STATUS <> -1)
			BEGIN
				INSERT INTO HOCPHI(MASV,NIENKHOA,HOCKY,HOCPHI,SOTIENDADONG) 
				VALUES (@masvmoi,@NienKhoa, @HocKy, @HocPhi, @SoTienDaDong)
				FETCH NEXT FROM @CrsrVar  INTO  @MaSVHocPhi, @NienKhoa, @HocKy, @HocPhi, @SoTienDaDong
			END
		CLOSE @CrsrVar
		DEALLOCATE @CrsrVar
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		CLOSE @CrsrVar
		DEALLOCATE @CrsrVar
		ROLLBACK TRAN
	END CATCH


GO
/****** Object:  StoredProcedure [dbo].[SP_ChuyenLopKhacKhoa]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ChuyenLopKhacKhoa]
@masv NCHAR(8), @masvmoi NCHAR(8), @malopmoi NCHAR(8)
AS
SET XACT_ABORT ON
BEGIN TRAN
	BEGIN TRY
		INSERT INTO SINHVIEN(MASV,HO,TEN,MALOP,PHAI,NGAYSINH,NOISINH,DIACHI,GHICHU,NGHIHOC) 
			SELECT MASV=@masvmoi,HO,TEN,MALOP=@malopmoi,PHAI,NGAYSINH,NOISINH,DIACHI,GHICHU='Chuyen lop. Ma sinh vien cu: '+@masv,NGHIHOC=0 
			FROM SINHVIEN WHERE MASV = @masv
		EXEC SP_ChuyenDiemSinhVien @masv,@masvmoi
		EXEC SP_ChuyenHocPhiSinhVien @masv,@masvmoi
		UPDATE SINHVIEN SET NGHIHOC=1, GHICHU='Chuyen lop. Ma sinh vien moi: '+@masvmoi
			WHERE MASV=@masv
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		RAISERROR('Co loi xay ra',16,1)
	END CATCH
GO
/****** Object:  StoredProcedure [dbo].[SP_ChuyenLopSV]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[SP_ChuyenLopSV]
@masv NCHAR(8), @masvmoi NCHAR(8), @malopmoi NCHAR(8)
AS 
EXEC LINK0.QLDSV.dbo.SP_ChuyenLopKhacKhoa @masv, @masvmoi, @malopmoi
GO
/****** Object:  StoredProcedure [dbo].[SP_CursorDiemSinhVien]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_CursorDiemSinhVien]
@OutCrsr CURSOR VARYING OUTPUT,@masv NVARCHAR( 10)
AS
SET @OutCrsr=CURSOR KEYSET FOR 
  SELECT MASV,MAMH,LAN,DIEM FROM DIEM 
  WHERE MASV=@masv
  ORDER BY MAMH ASC
  OPEN @OutCrsr
GO
/****** Object:  StoredProcedure [dbo].[SP_CursorHocPhiSinhVien]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_CursorHocPhiSinhVien]
@OutCrsr CURSOR VARYING OUTPUT,@masv NVARCHAR(10)
AS
SET @OutCrsr=CURSOR KEYSET FOR 
  SELECT MASV, NIENKHOA, HOCKY, HOCPHI, SOTIENDADONG FROM HOCPHI 
  WHERE MASV=@masv
  ORDER BY NIENKHOA ASC
  OPEN @OutCrsr
GO
/****** Object:  StoredProcedure [dbo].[SP_DANGNHAP]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DSTHIHETMON]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DSTHIHETMON]
@MALOP NVARCHAR(10)
AS
select MASV,HOVATEN=HO+' '+TEN,SOTO='',DIEM='',CHUKI='' from SINHVIEN where MALOP=@MALOP and NGHIHOC=0

GO
/****** Object:  StoredProcedure [dbo].[SP_INDANHSACHSINHVIEN]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INHOCPHILOP]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INPHIEUDIEM]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_LayMaKhoa]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[SP_LayMaKhoa]
@malop NCHAR(8)
AS
select MAKH FROM LINK0.QLDSV.dbo.LOP WHERE MALOP = @malop
GO
/****** Object:  StoredProcedure [dbo].[SP_TAOLOGIN]    Script Date: 08/30/2020 4:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_TAOLOGIN]
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
  IF @ROLE= 'PGV' OR @ROLE= 'Khoa' OR @ROLE='PKeToan'
    EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
RETURN 0  -- THANH CONG
GO
/****** Object:  StoredProcedure [dbo].[SP_TIMDIEMTUMAMONHOC]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_TIMDIEMTUMASINHVIEN]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_TIMHOCPHITUMASINHVIEN]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_TIMSV]    Script Date: 08/30/2020 4:46:42 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_TIMSVDANGHIHOC]    Script Date: 08/30/2020 4:46:42 PM ******/
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
