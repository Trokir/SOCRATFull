CREATE VIEW dbo.VendorMaterialNomView
AS
SELECT        dbo.VendorMaterialNom.Id, dbo.Vendor.Name AS Vendor, dbo.Brand.Name AS Brand, dbo.TradeMark.Name AS TradeMark, dbo.Material.Name AS Material, dbo.MaterialMarkType.Name AS MaterialMarkType, 
                         dbo.MaterialType.Name AS MaterialType, dbo.VendorMaterialNom.Name AS VendorMaterialNom, dbo.VendorMaterialNom.Mark, dbo.VendorMaterialNom.ColorRAL, dbo.VendorMaterialNom.ColorTransparency
FROM            dbo.MaterialType INNER JOIN
                         dbo.Material ON dbo.MaterialType.Id = dbo.Material.MaterialType_Id RIGHT OUTER JOIN
                         dbo.VendorMaterialNom ON dbo.Material.Id = dbo.VendorMaterialNom.Material_Id LEFT OUTER JOIN
                         dbo.Brand ON dbo.VendorMaterialNom.Brand_Id = dbo.Brand.Id LEFT OUTER JOIN
                         dbo.Vendor ON dbo.VendorMaterialNom.Vendor_Id = dbo.Vendor.Id LEFT OUTER JOIN
                         dbo.TradeMark ON dbo.VendorMaterialNom.TradeMark_Id = dbo.TradeMark.Id LEFT OUTER JOIN
                         dbo.MaterialMarkType ON dbo.VendorMaterialNom.MaterialMarkType_Id = dbo.MaterialMarkType.Id
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VendorMaterialNomView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'          DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 12
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 3000
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VendorMaterialNomView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[28] 4[12] 2[17] 3) )"
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
         Begin Table = "MaterialType"
            Begin Extent = 
               Top = 306
               Left = 955
               Bottom = 419
               Right = 1125
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Material"
            Begin Extent = 
               Top = 246
               Left = 711
               Bottom = 376
               Right = 884
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VendorMaterialNom"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 291
               Right = 238
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Brand"
            Begin Extent = 
               Top = 91
               Left = 850
               Bottom = 221
               Right = 1020
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Vendor"
            Begin Extent = 
               Top = 0
               Left = 501
               Bottom = 113
               Right = 671
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TradeMark"
            Begin Extent = 
               Top = 150
               Left = 1015
               Bottom = 280
               Right = 1185
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "MaterialMarkType"
            Begin Extent = 
               Top = 251
               Left = 445
               Bottom = 381
               Right = 615
            End
  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VendorMaterialNomView';

