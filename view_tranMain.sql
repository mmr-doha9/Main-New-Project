USE [DataMain]
GO

/****** Object:  View [dbo].[View_TranMain]    Script Date: 3/15/2020 5:15:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_TranMain]
AS
SELECT     view_tran_1.ID, view_tran_1.DocType, view_tran_1.Date, view_tran_1.Shbakat, view_tran_1.SHTogarya, view_tran_1.BranchCode, view_tran_1.PartionCode, 
                      view_tran_1.Name, view_tran_1.Address, view_tran_1.ActivitiesCode, view_tran_1.PlaceCode, view_tran_1.Description, view_tran_1.Mange, view_tran_1.Area, 
                      view_tran_1.Field, view_tran_1.Record, view_tran_1.SubRecord, view_tran_1.BlackaNo, view_tran_1.ArtisticCode, view_tran_1.CounterNo, 
                      view_tran_1.PoliceMenCode, view_tran_1.HasrNo, view_tran_1.MabahsCode, view_tran_1.Date2, view_tran_1.Date3, view_tran_1.Chk1, view_tran_1.Chk2, 
                      view_tran_1.PayState, view_tran_1.PriceCode, view_tran_1.AsthlakVal, view_tran_1.AsthlakVal - view_tran_1.Payed AS AsthlakVal_safy, view_tran_1.UserId, 
                      view_tran_1.DaysCount, view_tran_1.Asthlak, view_tran_1.Payed, view_tran_1.ForfeitVal, view_tran_1.IndustrialHallmark, view_tran_1.RadioFee, 
                      view_tran_1.AsthlakHallmark, view_tran_1.MohafzaHallmark, view_tran_1.CleanVal, view_tran_1.Total, dbo.Tblc_MainBranchCode.Name AS BranchName, 
                      dbo.Tblc_ActivitiesCode.Name AS ActivitiesName, dbo.Tblc_PlaceCode.Name AS PlaceCodeName, dbo.Tblc_ArtisticCode.Name AS ArtisticName, 
                      view_tran_1.ChkTazloom, view_tran_1.ChkNyaba
FROM         dbo.view_tran AS view_tran_1 LEFT OUTER JOIN
                      dbo.Tblc_MainBranchCode ON view_tran_1.BranchCode = dbo.Tblc_MainBranchCode.ID LEFT OUTER JOIN
                      dbo.Tblc_ActivitiesCode ON view_tran_1.ActivitiesCode = dbo.Tblc_ActivitiesCode.ID LEFT OUTER JOIN
                      dbo.Tblc_PlaceCode ON view_tran_1.PlaceCode = dbo.Tblc_PlaceCode.ID LEFT OUTER JOIN
                      dbo.Tblc_ArtisticCode ON view_tran_1.ArtisticCode = dbo.Tblc_ArtisticCode.ID

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[8] 4[46] 2[6] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "view_tran_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 203
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tblc_MainBranchCode"
            Begin Extent = 
               Top = 6
               Left = 241
               Bottom = 114
               Right = 412
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tblc_ActivitiesCode"
            Begin Extent = 
               Top = 114
               Left = 38
               Bottom = 207
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tblc_PlaceCode"
            Begin Extent = 
               Top = 114
               Left = 227
               Bottom = 222
               Right = 378
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tblc_ArtisticCode"
            Begin Extent = 
               Top = 210
               Left = 38
               Bottom = 318
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Col' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TranMain'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'umn = 2235
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TranMain'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TranMain'
GO


