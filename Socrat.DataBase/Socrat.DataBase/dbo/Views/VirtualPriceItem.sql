CREATE VIEW dbo.VirtualPriceItem
AS
SELECT        TOP (100) PERCENT dbo.PriceValue.Id, dbo.PriceValue.Id AS PriceValue_Id, dbo.MaterialNom.Id AS MaterialNom_Id, ISNULL(dbo.PriceValue.PriceVal, 0) AS Price, dbo.PriceValue.PricePeriod_Id, dbo.MaterialNom.Code1C, 
                         dbo.PriceValue.RowVersion, dbo.PriceValue.FlaggedProductionType, dbo.PriceValue.Measure_Id, dbo.PriceValue.PriceTopic
FROM            dbo.MaterialNom LEFT OUTER JOIN
                         dbo.PriceValue ON dbo.MaterialNom.Id = dbo.PriceValue.MaterialNom_Id
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[VirtualPriceItem_InsteadInsertUpdateDelete] 
   ON  [dbo].[VirtualPriceItem]
   INSTEAD OF INSERT,DELETE, UPDATE
AS 
BEGIN
	create table
		#t
		(a int)
	-- Если не делать ничего, то EF ругается, что фигли ничего не делать
	-- Поэтому надо что-то сделать 
	insert into #t values (1)
	RETURN
END
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VirtualPriceItem';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[35] 4[7] 2[14] 3) )"
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
         Begin Table = "MaterialNom"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 212
               Right = 250
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PriceValue"
            Begin Extent = 
               Top = 22
               Left = 469
               Bottom = 262
               Right = 698
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
         Width = 3510
         Width = 3870
         Width = 3420
         Width = 780
         Width = 2670
         Width = 3405
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3600
         Alias = 3615
         Table = 1755
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1395
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VirtualPriceItem';







