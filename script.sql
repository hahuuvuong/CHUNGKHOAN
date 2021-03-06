USE [master]
GO
/****** Object:  Database [CHUNGKHOAN]    Script Date: 4/21/2020 10:30:18 PM ******/
CREATE DATABASE [CHUNGKHOAN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CHUNGKHOAN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CHUNGKHOAN.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CHUNGKHOAN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CHUNGKHOAN_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CHUNGKHOAN] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CHUNGKHOAN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CHUNGKHOAN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET ARITHABORT OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CHUNGKHOAN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CHUNGKHOAN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CHUNGKHOAN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CHUNGKHOAN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET RECOVERY FULL 
GO
ALTER DATABASE [CHUNGKHOAN] SET  MULTI_USER 
GO
ALTER DATABASE [CHUNGKHOAN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CHUNGKHOAN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CHUNGKHOAN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CHUNGKHOAN] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CHUNGKHOAN] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CHUNGKHOAN', N'ON'
GO
USE [CHUNGKHOAN]
GO
/****** Object:  Table [dbo].[BANGGIATRUCTUYEN]    Script Date: 4/21/2020 10:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BANGGIATRUCTUYEN](
	[MACP] [char](7) NULL,
	[MUA_GIA2] [float] NULL,
	[MUA_KL2] [int] NULL,
	[MUA_GIA1] [float] NULL,
	[MUA_KL1] [int] NULL,
	[GIAKHOP] [float] NULL,
	[KLKHOP] [int] NULL,
	[BAN_GIA1] [float] NULL,
	[BAN_KL1] [int] NULL,
	[BAN_GIA2] [float] NULL,
	[BAN_KL2] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LENHDAT]    Script Date: 4/21/2020 10:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LENHDAT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MACP] [char](7) NULL,
	[NGAYDAT] [datetime] NULL,
	[LOAIGD] [nchar](1) NULL,
	[LOAILENH] [nchar](10) NULL,
	[SOLUONG] [int] NULL,
	[GIADAT] [float] NULL,
	[TRANGTHAILENH] [nvarchar](30) NULL,
 CONSTRAINT [PK_LENHDAT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LENHKHOP]    Script Date: 4/21/2020 10:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LENHKHOP](
	[IDKHOP] [int] IDENTITY(1,1) NOT NULL,
	[NGAYKHOP] [datetime] NULL,
	[SOLUONGKHOP] [int] NULL,
	[GIAKHOP] [float] NULL,
	[IDLENHDAT] [int] NOT NULL,
 CONSTRAINT [PK_LENHKHOP] PRIMARY KEY CLUSTERED 
(
	[IDKHOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[BANGGIATRUCTUYEN] ([MACP], [MUA_GIA2], [MUA_KL2], [MUA_GIA1], [MUA_KL1], [GIAKHOP], [KLKHOP], [BAN_GIA1], [BAN_KL1], [BAN_GIA2], [BAN_KL2]) VALUES (N'MBB    ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  StoredProcedure [dbo].[CursorLoaiGD]    Script Date: 4/21/2020 10:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CursorLoaiGD]
	@OutCrsr CURSOR VARYING	OUTPUT,
	@macp NVARCHAR(10), @Ngay NVARCHAR(50), @LoaiGD CHAR(1)
AS
	SET DATEFORMAT DMY
	IF (@LoaiGD = 'M')
		SET @OutCrsr = CURSOR KEYSET FOR 
		SELECT ID, NGAYDAT, SOLUONG, GIADAT FROM LENHDAT 
		WHERE MACP = @macp
			AND DAY(NGAYDAT) = DAY(@Ngay) AND MONTH(NGAYDAT) = MONTH(@Ngay) AND YEAR(NGAYDAT) = YEAR(@Ngay)
			AND LOAIGD = @LoaiGD AND SOLUONG > 0
			ORDER BY GIADAT DESC, NGAYDAT --Sắp xếp giá đặt từ cao xuống, Time tu nhanh den cham
	ELSE 
		SET @OutCrsr = CURSOR KEYSET FOR 
		SELECT ID, NGAYDAT, SOLUONG, GIADAT FROM LENHDAT 
		WHERE MACP = @macp
			AND DAY(NGAYDAT) = DAY(@Ngay) AND MONTH(NGAYDAT) = MONTH(@Ngay) AND YEAR(NGAYDAT) = YEAR(@Ngay)
			AND LOAIGD = @LoaiGD AND SOLUONG > 0
			ORDER BY GIADAT, NGAYDAT
	OPEN @OutCrsr 





GO
/****** Object:  StoredProcedure [dbo].[SP_BangGiaTrucTuyen]    Script Date: 4/21/2020 10:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_BangGiaTrucTuyen]
as
declare @maxkhop datetime, @minmua float, @maxban float, @mua float, @ban float, @MUA_GIA1 float, @MUA_GIA2 float, @BAN_GIA1 float, @BAN_GIA2 float, @GIAKHOP float,
		@MUA_KL1 INT, @MUA_KL2 INT, @BAN_KL1 INT, @BAN_KL2 INT, @KLKHOP INT 

SELECT DISTINCT MACP INTO #TEMP FROM LENHDAT
DECLARE @ID CHAR(7)
WHILE (SELECT COUNT(*) FROM  #TEMP) > 0
BEGIN
	SELECT TOP 1 @ID = MACP FROM #TEMP

	--select @maxkhop = max(ngaykhop) from lenhkhop, LENHDAT where MACP = @ID and IDLENHDAT = ID
	-- khớp mới nhât
	--select @GIAKHOP = GIAKHOP, @KLKHOP = SOLUONGKHOP from dbo.LENHDAT,  DBO.LENHKHOP where dbo.LENHDAT.ID = dbo.LENHKHOP.IDLENHDAT and dbo.LENHKHOP.NGAYKHOP = @maxkhop

	--dư mua rẻ nhất, nhì
	select @minmua = min(GIADAT) FROM LENHDAT WHERE LOAIGD = 'B' AND MACP = @ID AND ( TRANGTHAILENH = N'Chờ khớp' OR TRANGTHAILENH = N'Khớp lệnh 1 phần')
	select @mua = min(GIADAT) FROM LENHDAT WHERE GIADAT > @minmua and LOAIGD = 'B' AND MACP = @ID AND( TRANGTHAILENH = N'Chờ khớp' OR TRANGTHAILENH = N'Khớp lệnh 1 phần')
	select @MUA_GIA1 = @minmua
	select @MUA_KL1 = SUM(SOLUONG) from dbo.LENHDAT where dbo.LENHDAT.GIADAT = @minmua and LOAIGD = 'B' AND MACP = @ID AND ( TRANGTHAILENH = N'Chờ khớp' OR TRANGTHAILENH = N'Khớp lệnh 1 phần')
	select @MUA_GIA2 = @mua
	select @MUA_KL2 = SUM(SOLUONG)  from dbo.LENHDAT where dbo.LENHDAT.GIADAT = @mua and LOAIGD = 'B' AND MACP = @ID AND ( TRANGTHAILENH = N'Chờ khớp' OR TRANGTHAILENH = N'Khớp lệnh 1 phần')

	--dư bán rẻ nhất, nhì
	select @maxban = max(GIADAT) FROM LENHDAT WHERE LOAIGD = 'M' AND MACP = @ID AND ( TRANGTHAILENH = N'Chờ khớp' OR TRANGTHAILENH = N'Khớp lệnh 1 phần')
	select @ban = max(GIADAT) FROM LENHDAT WHERE GIADAT < @maxban and LOAIGD = 'M' AND MACP = @ID AND ( TRANGTHAILENH = N'Chờ khớp' OR TRANGTHAILENH = N'Khớp lệnh 1 phần')
	select @BAN_GIA1 = @maxban
	select @BAN_KL1 = SUM(SOLUONG) from dbo.LENHDAT where dbo.LENHDAT.GIADAT = @maxban and LOAIGD = 'M' AND MACP = @ID AND ( TRANGTHAILENH = N'Chờ khớp' OR TRANGTHAILENH = N'Khớp lệnh 1 phần')
	select @BAN_GIA2 = @ban
	select @BAN_KL2 = SUM(SOLUONG) from dbo.LENHDAT where dbo.LENHDAT.GIADAT = @ban and LOAIGD = 'M' AND MACP = @ID AND ( TRANGTHAILENH = N'Chờ khớp' OR TRANGTHAILENH = N'Khớp lệnh 1 phần')

	UPDATE BANGGIATRUCTUYEN
	SET 
		MUA_GIA2 = @MUA_GIA2,
		MUA_KL2 = @MUA_KL2,
		MUA_GIA1 = @MUA_GIA1,
		MUA_KL1 = @MUA_KL1,
		--GIAKHOP = @GIAKHOP,
		--KLKHOP = @KLKHOP,
		BAN_GIA1 = @BAN_GIA1,
		BAN_KL1 = @BAN_KL1,
		BAN_GIA2 = @BAN_GIA2,
		BAN_KL2 = @BAN_KL2
	WHERE MACP = @ID

	DELETE #TEMP WHERE MACP = @ID
END

drop table #temp

GO
/****** Object:  StoredProcedure [dbo].[SP_KHOPLENH_LO]    Script Date: 4/21/2020 10:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_KHOPLENH_LO]
	@macp NVARCHAR(10), @Ngay NVARCHAR(50), @LoaiGD CHAR(1),
	@soluongMB INT, @giadatMB FLOAT 
AS
	--TRUNCATE TABLE dbo.LENHKHOP --reset table LENHKHOP sau mỗi phiên giao dịch
	SET DATEFORMAT DMY
	DECLARE @CrsrVar CURSOR, @ngaydat NVARCHAR(50), @soluong INT,
	@giadat	FLOAT, @soluongkhop INT, @giakhop FLOAT, @ID INT, @sumsoluongkhop INT
	SET @sumsoluongkhop = 0
	IF(@LoaiGD = 'B')--Nếu bán thì nó sẽ chạy sp và xem thằng mua nào đặt trước với giá cao nhất 
		EXEC CursorLoaiGD @CrsrVar OUTPUT, @macp, @Ngay, 'M'
	ELSE --còn mua thì ngược lại
		EXEC CursorLoaiGD @CrsrVar OUTPUT, @macp, @Ngay, 'B'
	FETCH NEXT FROM @CrsrVar INTO @ID, @ngaydat, @soluong, @giadat
	--select @ID, @ngaydat, @soluong, @giadat cua bang lenhdat tao thanh 1 bang roi dua con tro vao bang do
	WHILE(@@FETCH_STATUS <>-1 AND @soluongMB > 0)
	BEGIN
		IF(@LoaiGD = 'B')--nếu gia dịch là bán
			IF(@giadatMB <= @giadat)--if giá bán <= với giá người mua đặt mua
			BEGIN
				IF (@soluongMB >= @soluong)
				BEGIN 
					SET @soluongkhop = @soluong
					SET @giakhop = @giadat
					SET @soluongMB = @soluongMB - @soluong --LUC NAY DA MUA DC @SOLUONG VA CAN THEM @soluongMB = @soluongMB - @soluong
					UPDATE dbo.LENHDAT
						SET SOLUONG = 0 ,TRANGTHAILENH = N'Khớp hết'
						WHERE CURRENT OF @CrsrVar
				END
				ELSE
				BEGIN
					SET @soluongkhop = @soluongMB
					SET @giakhop = @giadat

					UPDATE dbo.LENHDAT 
						SET SOLUONG = SOLUONG - @soluongMB,TRANGTHAILENH = N'Khớp lệnh 1 phần'
						WHERE CURRENT OF @CrsrVar 
					SET @soluongMB = 0--luc nay da ban het so co phieu
				END
				--SELECT @soluongkhop, @giakhop
				SET @sumsoluongkhop = @sumsoluongkhop + @soluongkhop
				--Cập nhật table lệnh khớp
					INSERT INTO LENHKHOP(NGAYKHOP, SOLUONGKHOP, GIAKHOP, IDLENHDAT)
						VALUES (GETDATE(),@soluongkhop, @giakhop, @ID)
			END
			ELSE
				GOTO THOAT
		-- Còn Trường hợp lệnh gởi vào là lệnh mua
		ELSE
			IF(@giadatMB>=@giadat)
			BEGIN
				IF(@soluongMB >= @soluong)
				BEGIN
					SET @soluongkhop = @soluong
					SET @giakhop = @giadat
					SET @soluongMB = @soluongMB - @soluong
					UPDATE dbo.LENHDAT 
						SET SOLUONG = 0, TRANGTHAILENH = N'Khớp hết'
						WHERE CURRENT OF @CrsrVar
				END
				ELSE
				BEGIN
					SET @soluongkhop = @soluongMB
					SET @giakhop = @giadat
					UPDATE dbo.LENHDAT
						SET SOLUONG = SOLUONG - @soluongMB,
						TRANGTHAILENH = N'Khớp lệnh 1 phần'
						WHERE CURRENT OF @CrsrVar
						SET @soluongMB = 0
				END
				--SELECT @soluongkhop, @giakhop
				SET @sumsoluongkhop = @sumsoluongkhop + @soluongkhop
				--Update table LENHKHOP
				INSERT INTO LENHKHOP(NGAYKHOP, SOLUONGKHOP, GIAKHOP, IDLENHDAT)
						VALUES (GETDATE(),@soluongkhop, @giakhop, @ID)
				
			END
			ELSE
				GOTO THOAT
		FETCH NEXT FROM @CrsrVar INTO @ID, @ngaydat, @soluong, @giadat
	END
	
	THOAT:
	--Cập nhật table LENHDAT nếu số lượng mua bán > 0
	IF(@soluongMB>0)
	BEGIN
		INSERT INTO LENHDAT(MACP, NGAYDAT, LOAIGD, LOAILENH, SOLUONG, GIADAT, TRANGTHAILENH)
			VALUES(@macp, GETDATE(), @LoaiGD, N'LO', @soluongMB, @giadatMB, N'Chờ khớp')
	END
		SELECT @sumsoluongkhop AS "Số lượng khớp"
		CLOSE @CrsrVar 
		DEALLOCATE @CrsrVar
		



GO
USE [master]
GO
ALTER DATABASE [CHUNGKHOAN] SET  READ_WRITE 
GO
