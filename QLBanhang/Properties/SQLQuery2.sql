/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [MaHD]
      ,[MaHH]
      ,[SoLuong]
      ,[DonGia]
      ,[ThanhTien] = [SoLuong] * [DonGia]
  FROM [QL_BanHang].[dbo].[tb_CTHD]