using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Socrat.Core;
using Socrat.Log;
using System;
using System.Linq.Expressions;

namespace Socrat.UI.Core
{
    public static class CxGenericListTableExtentions
    {
        public static GridColumn AddColumn(this GridView gv, string caption, string fieldName, int width, int visibleIndex, string toolTip = null, bool allowEdit = false)
        {
            return AddColumn(gv, "col" + fieldName, caption, fieldName, FormatType.None, null, width, visibleIndex, toolTip, allowEdit);
        }

        public static GridColumn AddColumn(this GridView gv, string name, string caption, string fieldName, FormatType formatType,
            string formatString, int width, int visibleIndex, string toolTip = null, bool allowEdit = false)
        {
            GridColumn column = new GridColumn();
            column.Caption = caption;
            column.DisplayFormat.FormatString = formatString;
            column.DisplayFormat.FormatType = formatType;
            column.FieldName = fieldName;
            column.Name = name;
            column.Visible = true;
            column.VisibleIndex = visibleIndex;
            column.Width = width;
            column.ToolTip = toolTip;
            column.OptionsColumn.AllowEdit = allowEdit;
            gv.Columns.Add(column);
            return column;
        }

        public static RepositoryItemCheckEdit AddCheckBoxColumnRepositoryItem(this GridView gv, string caption,
            string fieldName, int width, int visibleIndex, string toolTip = null)
        {
            RepositoryItemCheckEdit repositoryItemCheckEdit = new RepositoryItemCheckEdit();
            GridColumn _column = new GridColumn();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemCheckEdit)).BeginInit();
            _column.Caption = caption;
            _column.DisplayFormat.FormatType = FormatType.Custom;
            _column.FieldName = fieldName;
            _column.Name = "col" + fieldName;
            _column.Visible = true;
            _column.VisibleIndex = visibleIndex;
            _column.Width = width;
            _column.ToolTip = toolTip;
            _column.UnboundType = UnboundColumnType.Boolean;
            _column.ColumnEdit = repositoryItemCheckEdit;
            _column.OptionsColumn.AllowEdit = true;
            _column.OptionsColumn.AllowFocus = true;
            gv.Columns.Add(_column);
            ((System.ComponentModel.ISupportInitialize)(repositoryItemCheckEdit)).EndInit();
            return repositoryItemCheckEdit;
        }

        public static GridColumn AddObjectColumn(this GridView gv, string caption, string fieldName, int width, int visibleIndex, string toolTip = null)
        {
            GridColumn _column = new GridColumn();
            _column.Caption = caption;
            _column.FieldName = fieldName;
            _column.Name = "col" + fieldName + visibleIndex.ToString();
            _column.Visible = true;
            _column.VisibleIndex = visibleIndex;
            _column.Width = width;
            _column.FieldNameSortGroup = fieldName + "Id";
            _column.FilterMode = ColumnFilterMode.DisplayText;
            _column.OptionsColumn.AllowEdit = false;
            _column.ToolTip = toolTip;
            gv.Columns.Add(_column);
            return _column;

        }

        public static GridColumn AddColumn(this GridView gv, PropertyVisualisationAttribute columnProperty)
        {
            GridColumn gridColumn = null;
            if (columnProperty.IsObject)
            {
                gridColumn = AddObjectColumn(
                    gv,
                    columnProperty.Title,
                    columnProperty.FieldName,
                    columnProperty.Width,
                    columnProperty.VisibleIndex);
            }
            else
            {
                gridColumn = AddColumn(
                    gv,
                    columnProperty.Title,
                    columnProperty.FieldName,
                    columnProperty.Width,
                    columnProperty.VisibleIndex);
            }

            gridColumn.AppearanceHeader.TextOptions.HAlignment = columnProperty.HAlignment;
            gridColumn.AppearanceCell.TextOptions.HAlignment = columnProperty.HAlignment;
            gridColumn.Tag = columnProperty;
            return gridColumn;
        }

        public static GridColumn AddColumn(string name, string caption, string fieldName, FormatType formatType,
            string formatString, int width, int visibleIndex, string toolTip = null, bool allowEdit = false)
        {
            return AddColumn(name, caption, fieldName, formatType, formatString, width, visibleIndex, toolTip, allowEdit);
        }

        public static GridColumn AddObjectColumn(string caption, string fieldName, int width, int visibleIndex, string toolTip = null)
        {
            return AddObjectColumn(caption, fieldName, width, visibleIndex, toolTip);
        }

        public static GridColumn AddColumn(string caption, string fieldName, int width, int visibleIndex, string toolTip = null)
        {
            if (string.IsNullOrEmpty(fieldName))
                throw new Exception("Поле fieldName должно быть заполнено.");
            return AddColumn("col" + fieldName, caption, fieldName, FormatType.None, null, width, visibleIndex, toolTip);
        }
    }
}
