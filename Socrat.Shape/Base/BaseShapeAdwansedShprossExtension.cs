using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Shape.Base;
using Socrat.Shape.Shproses;

namespace Socrat.Shape
{

    public abstract partial class BaseShape : PropertyChangedBase
    {

        #region Variables
        public int XPersent { get; set; }
        public int YPersent { get; set; }
        private double XProp { get; set; }
        private double YProp { get; set; }
        #endregion
        #region Shpros Variables
        private Color _TempColor;
        public Color TempColor
        {
            get { return _TempColor; }
            set { SetField(ref _TempColor, value, () => TempColor); }
        }
        public string TempSideVector
        {
            get { return _TempSideVector; }
            set { SetField(ref _TempSideVector, value, () => TempSideVector); }
        }
        public string Type
        {
            get { return _Type; }
            set { SetField(ref _Type, value, () => Type); }
        }
        public string Direction
        {
            get { return _Direction; }
            set { SetField(ref _Direction, value, () => Direction); }
        }
        public float Factor
        {
            get { return _Factor; }
            set { SetField(ref _Factor, value, () => Factor); }
        }
        public string Orientation
        {
            get { return _Orientation; }
            set { SetField(ref _Orientation, value, () => Orientation); }
        }
        public double TotalShprosLength
        {
            get { return _TotalShprosLength; }
            set { SetField(ref _TotalShprosLength, value, () => TotalShprosLength); }
        }
        public int RetainerCounter
        {
            get { return _RetainerCounter; }
            set { SetField(ref _RetainerCounter, value, () => RetainerCounter); }
        }
        public int TobrazRetainer
        {
            get { return _TobrazRetainer; }
            set { SetField(ref _TobrazRetainer, value, () => TobrazRetainer); }
        }
        public int VerticalShprosCounter
        {
            get { return _VerticalShprosCounter; }
            set { SetField(ref _VerticalShprosCounter, value, () => VerticalShprosCounter); }
        }
        public int HorisontalShprosCounter
        {
            get { return _HorisontalShprosCounter; }
            set { SetField(ref _HorisontalShprosCounter, value, () => HorisontalShprosCounter); }
        }
        private List<Line> _ShprossLineCollection;
        public List<Line> ShprossLineCollection
        {
            get { return _ShprossLineCollection; }
            set { SetField(ref _ShprossLineCollection, value, () => ShprossLineCollection); }
        }

        private List<System.Drawing.Point[]> _ShprossArcCollection;
        private List<System.Drawing.Point[]> ShprossArcCollection
        {
            get { return _ShprossArcCollection; }
            set { SetField(ref _ShprossArcCollection, value, () => ShprossArcCollection); }
        }
        private List<Tuple<Guid, System.Drawing.Point[]>> ShprossArcWithKeyCollection { get; set; }


        public double ShprosChordHeight
        {
            get { return _ShprosChordHeight; }
            set { SetField(ref _ShprosChordHeight, value, () => ShprosChordHeight); }
        }
        private bool _ShprosFlag;
        public bool ShprosFlag
        {
            get { return _ShprosFlag; }
            set { SetField(ref _ShprosFlag, value, () => ShprosFlag); }
        }
        public double LeftMargin
        {
            get { return _LeftMargin; }
            set { SetField(ref _LeftMargin, value, () => LeftMargin); }
        }
        public double RightMargin
        {
            get { return _RightMargin; }
            set { SetField(ref _RightMargin, value, () => RightMargin); }
        }
        public int Count
        {
            get { return _Count; }
            set { SetField(ref _Count, value, () => Count); }
        }
        public int SelectorFlag
        {
            get { return _SelectorFlag; }
            set { SetField(ref _SelectorFlag, value, () => SelectorFlag); }
        }
        public double AxisMargin
        {
            get { return _AxisMargin; }
            set { SetField(ref _AxisMargin, value, () => AxisMargin); }
        }
        public RectangleF SelectedRect
        {
            get { return _SelectedRect; }
            set { SetField(ref _SelectedRect, value, () => SelectedRect); }
        }
        public bool IsDrawPictureEditButtons
        {
            get { return _IsDrawPictureEditButtons; }
            set { SetField(ref _IsDrawPictureEditButtons, value, () => IsDrawPictureEditButtons); }
        }
        private Rectangle _sourceRectangle;
        public Rectangle sourceRectangle
        {
            get { return _sourceRectangle; }
            set { SetField(ref _sourceRectangle, value, () => sourceRectangle); }
        }
        private double _Current;
        public double Current
        {
            get { return _Current; }
            set { SetField(ref _Current, value, () => Current); }
        }
        private bool _IsDrawPictureToAnotherWindows;
        public bool IsDrawPictureToAnotherWindows
        {
            get { return _IsDrawPictureToAnotherWindows; }
            set { SetField(ref _IsDrawPictureToAnotherWindows, value, () => IsDrawPictureToAnotherWindows); }
        }
        private List<ShprosElement> _GetAllShproses;
        public List<ShprosElement> GetAllShprosses
        {
            get { return _GetAllShproses; }
            set { SetField(ref _GetAllShproses, value, () => GetAllShprosses); }
        }
        private bool _IsLoadDefaultShpros;
        public bool IsLoadDefaultShpros
        {
            get { return _IsLoadDefaultShpros; }
            set { SetField(ref _IsLoadDefaultShpros, value, () => IsLoadDefaultShpros); }
        }
        private bool _IsCenter;
        public bool IsCenter
        {
            get { return _IsCenter; }
            set { SetField(ref _IsCenter, value, () => IsCenter); }
        }

        private bool _IsMarginType;
        public bool IsRelativeMargin
        {
            get { return _IsMarginType; }
            set { SetField(ref _IsMarginType, value, () => IsRelativeMargin); }
        }

        #endregion
        #region SetLineColor
        protected Color SelectMainLineColor1()
        {
            Color MainColor = new Color();
            if (ColorMarker == "rowCheckCut1" || ColorMarker1 == "rowCheckCut1") { MainColor = Color.Black; }
            else { MainColor = Color.Red; }
            return MainColor;
        }
        protected Color SelectMainLineColor2()
        {
            Color MainColor = new Color();
            if (ColorMarker == "rowCheckCut2" || ColorMarker2 == "rowCheckCut2") { MainColor = Color.Black; }
            else { MainColor = Color.Red; }
            return MainColor;
        }
        protected Color SelectMainLineColor3()
        {
            Color MainColor = new Color();
            if (ColorMarker == "rowCheckCut3" || ColorMarker3 == "rowCheckCut3") { MainColor = Color.Black; }
            else { MainColor = Color.Red; }
            return MainColor;
        }
        protected Color SelectMainLineColor4()
        {
            Color MainColor = new Color();
            if (ColorMarker == "rowCheckCut4" || ColorMarker4 == "rowCheckCut4") { MainColor = Color.Black; }
            else { MainColor = Color.Red; }
            return MainColor;
        }
        protected Color SelectMainLineColor5()
        {
            Color MainColor = new Color();
            if (ColorMarker == "rowCheckCut5" || ColorMarker5 == "rowCheckCut5") { MainColor = Color.Black; }
            else { MainColor = Color.Red; }
            return MainColor;
        }
        protected Color SelectMainLineColor6()
        {
            Color MainColor = new Color();
            if (ColorMarker == "rowCheckCut6" || ColorMarker6 == "rowCheckCut6") { MainColor = Color.Black; }
            else { MainColor = Color.Red; }
            return MainColor;
        }
        protected Color SelectMainLineColor7()
        {
            Color MainColor = new Color();
            if (ColorMarker == "rowCheckCut7" || ColorMarker7 == "rowCheckCut7") { MainColor = Color.Black; }
            else { MainColor = Color.Red; }
            return MainColor;
        }
        protected Color SelectMainLineColor8()
        {
            Color MainColor = new Color();
            if (ColorMarker == "rowCheckCut8" || ColorMarker8 == "rowCheckCut8") { MainColor = Color.Black; }
            else { MainColor = Color.Red; }
            return MainColor;
        }

        protected int[] SelectedSides { get; set; }
        public int ClickedSelectSide { get; set; }
        private void CalculateSidesCount()
        {

            List<int> tempList = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var item in TempSidesCountArray)
            {
                tempList.RemoveAt(item - 1);
                tempList.Insert(item - 1, item);
            }
            SelectedSides = tempList.ToArray();
        }

        private double _SelectedSidesLength;
        public double SelectedSidesLength
        {
            get { return (_SelectedSidesLength < 0) ? 0 : _SelectedSidesLength; }
            set { SetField(ref _SelectedSidesLength, value, () => SelectedSidesLength); }
        }

        public int[] GetSelectedSides()
        {
            int[] arr = SelectedSides;
            arr = arr.Where(x => x != 0).ToArray();
            return arr;
        }
        private List<int> TempSidesCountArray { get; set; }
        public void SelectColorMarkerSide(int sideNum)
        {
            ClickedSelectSide = sideNum;
            ColorMarker1 = String.Empty;
            ColorMarker2 = String.Empty;
            ColorMarker3 = String.Empty;
            ColorMarker4 = String.Empty;
            ColorMarker5 = String.Empty;
            ColorMarker6 = String.Empty;
            ColorMarker7 = String.Empty;
            ColorMarker8 = String.Empty;

            if (sideNum == 1) { ColorMarker1 = "rowCheckCut1"; }
            else if (sideNum == 2) { ColorMarker2 = "rowCheckCut2"; }
            else if (sideNum == 3) { ColorMarker3 = "rowCheckCut3"; }
            else if (sideNum == 4) { ColorMarker4 = "rowCheckCut4"; }
            else if (sideNum == 5) { ColorMarker5 = "rowCheckCut5"; }
            else if (sideNum == 6) { ColorMarker6 = "rowCheckCut6"; }
            else if (sideNum == 7) { ColorMarker7 = "rowCheckCut7"; }
            else if (sideNum == 8) { ColorMarker8 = "rowCheckCut8"; }
            else if (sideNum == 0)
            {
                ColorMarker1 = "";
                ColorMarker2 = "";
                ColorMarker3 = "";
                ColorMarker4 = "";
                ColorMarker5 = "";
                ColorMarker6 = "";
                ColorMarker7 = "";
                ColorMarker8 = "";
            }
        }

        public virtual void CalculateSelectedSideLength(List<int> sideNums) { }

        public void SelectColorMarker(int[] sideNums)
        {
            TempSidesCountArray = sideNums.ToList();
            CalculateSidesCount();
            ColorMarker1 = String.Empty;
            ColorMarker2 = String.Empty;
            ColorMarker3 = String.Empty;
            ColorMarker4 = String.Empty;
            ColorMarker5 = String.Empty;
            ColorMarker6 = String.Empty;
            ColorMarker7 = String.Empty;
            ColorMarker8 = String.Empty;
            foreach (int sideNum in sideNums)
            {
                if (sideNum == 1) { ColorMarker1 = "rowCheckCut1"; }
                else if (sideNum == 2) { ColorMarker2 = "rowCheckCut2"; }
                else if (sideNum == 3) { ColorMarker3 = "rowCheckCut3"; }
                else if (sideNum == 4) { ColorMarker4 = "rowCheckCut4"; }
                else if (sideNum == 5) { ColorMarker5 = "rowCheckCut5"; }
                else if (sideNum == 6) { ColorMarker6 = "rowCheckCut6"; }
                else if (sideNum == 7) { ColorMarker7 = "rowCheckCut7"; }
                else if (sideNum == 8) { ColorMarker8 = "rowCheckCut8"; }
            }
        }

        #endregion
        public virtual void DrawSideNumbers() { }
        public void DepthOfHermetic(double? val)
        {
            IsToothVector = true;
            IsSelectSameAllowance = true;
            CheckCut1 = val ?? 0.0;
        }
        private void ParseCurrentCoordinates()
        {
            var x = ShapeHeightValue;
            var y = ShapeWidthValue;
            YProp = ShapeHeightValue;
            XProp = ShapeWidthValue;
            var pkbDrawW = 10000;
            var pkbDrawH = 10000;

            var pkbDrawWs = pictureBox.ClientSize.Width;
            var pkbDrawHs = pictureBox.ClientSize.Height;

            float pic_aspect = (pkbDrawWs) / (float)(pkbDrawHs);
            float img_aspect = pkbDrawW / (float)pkbDrawH;
            if (pic_aspect > img_aspect)
            {
                YProp = (int)((float)pkbDrawH * y / (float)pkbDrawHs);
                float scaled_width = pkbDrawW * pkbDrawHs / pkbDrawH;
                float dx = (pkbDrawWs - scaled_width) / 2;
                XProp = (int)((x - dx) * pkbDrawH / (float)pkbDrawHs);
            }
            else
            {
                XProp = (int)(pkbDrawW * x / (float)pkbDrawWs);
                float scaled_height = pkbDrawH * pkbDrawWs / pkbDrawW;
                float dy = (pkbDrawHs - scaled_height) / 2;
                YProp = (int)((y - dy) * pkbDrawW / pkbDrawWs);
            }
        }
        public virtual void SelectClickedSide(int xCoord, int yCoord, bool flag) { }
        /// <summary>
        /// Для выделения мышью
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        protected GraphicsPath ThicknessPath(ShapePoint a, ShapePoint b)
        {
            var path = new GraphicsPath();
            var fPoint = GetNewCustomPoint(a.PointX, a.PointY);
            var sPoint = GetNewCustomPoint(b.PointX, b.PointY);
            for (int i = -10; i < 21; i++)
            {
                fPoint.PointX += i;
                fPoint.PointY += i;
                sPoint.PointX += i;
                sPoint.PointY += i;
                path.AddLine(fPoint, sPoint);
            }

            return path;
        }
        protected GraphicsPath CurvePath(System.Drawing.Point[] points)
        {
            var path = new GraphicsPath();
            path.AddCurve(points);
            return path;
        }
        #region Shpros Methods     
        public void RefreshPictureEdit()
        {
            ShprosCollection.Clear();
            LoadDefaultShprosComponents();
            IsRefreshColorShprosElement = false;
        }
        private bool _IsCanDeleteShprosItem;
        public bool IsCanDeleteShprosItem
        {
            get { return _IsCanDeleteShprosItem; }
            set { SetField(ref _IsCanDeleteShprosItem, value, () => IsCanDeleteShprosItem); }
        }
        private Guid _OnDeleteItemId;
        public Guid OnDeleteItemId
        {
            get { return _OnDeleteItemId; }
            set { SetField(ref _OnDeleteItemId, value, () => OnDeleteItemId); }
        }


        private void LoadDefaultShprosComponents()
        {
            if (GetAllShprosses.Count == 0) { return; }
            ClearAllVariables();
            var value = GetAllShprosses;
            foreach (var item in GetAllShprosses.ToList())
            {
                IsCenter = item.IsCenter;
                TempColor = (item.IsSelectedColor == true) ? Color.Blue : Color.Black;
                IsRelativeMargin = (item.IsRelativeMargin is true) ? true : false;
                switch (item.SelectorFlag ?? 0)
                {
                    case 1:
                        if (item != null)
                        {
                            switch (item.TypeElement)
                            {
                                case "Прямая":
                                    switch (item.OrientationType)
                                    {
                                        case "Вертикаль":
                                            using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                            {
                                                PenC.DashStyle = DashStyle.DashDot;
                                                var vert = CreateVerticalElement(item.SideVector, (float)item.LeftMargin.Value, item.Id);
                                                graphicsShape.DrawPath(PenC, vert);
                                                if (item.IsRelativeMargin == false)
                                                {
                                                    AxVerMargin += 15;
                                                }
                                                MarginValue = (float)item.LeftMargin.Value;
                                                MarginRelativeValue = (float)item.LeftMargin.Value;
                                                if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.Remove(vert); }
                                                else { ShprosCollection.Add(vert); }
                                            }
                                            break;

                                        case "Горизонталь":
                                            using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                            {
                                                PenC.DashStyle = DashStyle.DashDot;
                                                var hor = CreateHorisontalElement(item.SideVector, (float)item.LeftMargin.Value, item.Id);
                                                graphicsShape.DrawPath(PenC, hor);
                                                if (item.IsRelativeMargin == false)
                                                {
                                                    AxHorMargin += 15;
                                                }
                                                MarginValue = (float)item.LeftMargin.Value;
                                                MarginRelativeValue = (float)item.LeftMargin.Value;
                                                if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.Remove(hor); }
                                                else { ShprosCollection.Add(hor); }
                                            }
                                            break;
                                    }
                                    break;
                                case "Дуга":
                                    switch (item.SideDirectionForAxisPack)
                                    {
                                        case "Сверху":
                                            using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                            {
                                                PenC.DashStyle = DashStyle.DashDot;
                                                var up_arc = CreateUpArcElement(item.SideVector, item.LeftMargin, item.Margin, item.Id);
                                                graphicsShape.DrawPath(PenC, up_arc);
                                                // if (IsInside) { ClicklElement = item; }
                                                if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.Remove(up_arc); }
                                                else { ShprosCollection.Add(up_arc); }
                                            }
                                            break;
                                        case "Снизу":
                                            using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                            {
                                                PenC.DashStyle = DashStyle.DashDot;
                                                var bottom_arc = CreateBottomArcElement(item.SideVector, item.LeftMargin, item.Margin, item.Id);
                                                graphicsShape.DrawPath(PenC, bottom_arc);
                                                // if (IsInside) { ClicklElement = item; }
                                                if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.Remove(bottom_arc); }
                                                else { ShprosCollection.Add(bottom_arc); }
                                            }
                                            break;
                                        case "Слева":
                                            using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                            {
                                                PenC.DashStyle = DashStyle.DashDot;
                                                var left_arc = CreateLeftArcElement(item.SideVector, item.LeftMargin, item.Margin, item.Id);
                                                graphicsShape.DrawPath(PenC, left_arc);
                                                if (IsInside) { ClicklElement = item; }
                                                if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.Remove(left_arc); }
                                                else { ShprosCollection.Add(left_arc); }
                                            }
                                            break;
                                        case "Справа":
                                            using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                            {
                                                PenC.DashStyle = DashStyle.DashDot;
                                                var right_arc = CreateRightArcElement(item.SideVector, item.LeftMargin, item.Margin, item.Id);
                                                graphicsShape.DrawPath(PenC, right_arc);
                                                // if (IsInside) { ClicklElement = item; }
                                                if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.Remove(right_arc); }
                                                else { ShprosCollection.Add(right_arc); }
                                            }
                                            break;
                                    }
                                    break;
                            }
                        }
                        break;

                    case 2:
                        switch (item.TypeElement)
                        {
                            case "Прямая":
                                switch (item.OrientationType)
                                {
                                    case "Горизонталь":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            var horAxis = CreateHorisontalElementsPack(item.OrientationType, item.LeftMargin.Value, item.RightMargin.Value, item.Count.Value, item.Id);
                                            TempList.AddRange(horAxis);
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);

                                            }

                                            if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.RemoveRange((ShprosCollection.Count - 1 - horAxis.Count), horAxis.Count); TempList.Clear(); }
                                            else { ShprosCollection.AddRange(TempList); }
                                        }
                                        break;
                                    case "Вертикаль":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            var verAxis = CreateVerticalElementsPack(item.OrientationType, item.LeftMargin.Value, item.RightMargin.Value, item.Count.Value, item.Id);
                                            TempList.AddRange(verAxis);
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);

                                            }

                                            if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.RemoveRange((ShprosCollection.Count - 1 - verAxis.Count), verAxis.Count); TempList.Clear(); }
                                            else { ShprosCollection.AddRange(TempList); }
                                        }
                                        break;
                                }
                                break;

                            case "Дуга":
                                switch (item.SideDirectionForAxisPack)
                                {
                                    case "Сверху":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            TempList.AddRange(CreateUpArcElementPack(item.SideVector, item.LeftMargin.Value, item.RightMargin.Value, item.Margin.Value, item.Count.Value, item.Id));
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);
                                            }
                                        }
                                        var verUpAxis = CreateUpArcElementPack(item.SideVector, item.LeftMargin.Value, item.RightMargin.Value, item.Margin.Value, item.Count.Value, item.Id);
                                        if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.RemoveRange((ShprosCollection.Count - 1 - verUpAxis.Count), verUpAxis.Count); TempList.Clear(); }
                                        else { ShprosCollection.AddRange(TempList); }
                                        break;


                                    case "Снизу":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            TempList.AddRange(CreateBottomArcElementPack(item.SideVector, item.LeftMargin.Value, item.RightMargin.Value, item.Margin.Value, item.Count.Value, item.Id));
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);
                                            }
                                        }
                                        var verBottomAxis = CreateBottomArcElementPack(item.SideVector, item.LeftMargin.Value, item.RightMargin.Value, item.Margin.Value, item.Count.Value, item.Id);
                                        if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.RemoveRange((ShprosCollection.Count - 1 - verBottomAxis.Count), verBottomAxis.Count); TempList.Clear(); }
                                        else { ShprosCollection.AddRange(TempList); }
                                        break;

                                    case "Слева":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            TempList.AddRange(CreateLeftArcElementPack(item.SideVector, item.LeftMargin.Value, item.RightMargin.Value, item.Margin.Value, item.Count.Value, item.Id));
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);
                                            }
                                        }
                                        var verLeftAxis = CreateLeftArcElementPack(item.SideVector, item.LeftMargin.Value, item.RightMargin.Value, item.Margin.Value, item.Count.Value, item.Id);
                                        if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.RemoveRange((ShprosCollection.Count - 1 - verLeftAxis.Count), verLeftAxis.Count); TempList.Clear(); }
                                        else { ShprosCollection.AddRange(TempList); }
                                        break;

                                    case "Справа":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            TempList.AddRange(CreateRightArcElementPack(item.SideVector, item.LeftMargin.Value, item.RightMargin.Value, item.Margin.Value, item.Count.Value, item.Id));
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);
                                            }
                                        }
                                        var verRightAxis = CreateRightArcElementPack(item.SideVector, item.LeftMargin.Value, item.RightMargin.Value, item.Margin.Value, item.Count.Value, item.Id);
                                        if (IsCanDeleteShprosItem && ShprosCollection.Count > 0) { ShprosCollection.RemoveRange((ShprosCollection.Count - 1 - verRightAxis.Count), verRightAxis.Count); TempList.Clear(); }
                                        else { ShprosCollection.AddRange(TempList); }
                                        break;
                                }
                                break;
                            case "Луч":
                                switch (item.SideDirectionForAxisPack)
                                {
                                    case "Сверху":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            TempList.AddRange(CreateVerticalUpAxisElementsPack(item.SideVector, item.Margin.Value, item.LeftMargin.Value, item.RightMargin.Value, item.Count.Value, item.Id));
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);
                                            }
                                        }
                                        //  if (IsInside) { ClicklElement = item; }
                                        ShprosCollection.AddRange(TempList);
                                        break;

                                    case "Снизу":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            TempList.AddRange(CreateVerticalBottomAxisElementsPack(item.SideVector, item.Margin.Value, item.LeftMargin.Value, item.RightMargin.Value, item.Count.Value, item.Id));
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);
                                            }
                                        }
                                        //  if (IsInside) { ClicklElement = item; }
                                        ShprosCollection.AddRange(TempList);
                                        break;
                                    case "Слева":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            TempList.AddRange(CreateHorizontalLeftAxisElementsPack(item.SideVector, item.Margin.Value, item.LeftMargin.Value, item.RightMargin.Value, item.Count.Value, item.Id));
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);
                                            }
                                        }
                                        //  if (IsInside) { ClicklElement = item; }
                                        ShprosCollection.AddRange(TempList);
                                        break;
                                    case "Справа":
                                        TempList.Clear();
                                        using (var PenC = new Pen(TempColor, ThiсknessArgument / 4))
                                        {
                                            PenC.DashStyle = DashStyle.DashDot;
                                            TempList.AddRange(CreateHorizontalRightAxisElementsPack(item.SideVector, item.Margin.Value, item.LeftMargin.Value, item.RightMargin.Value, item.Count.Value, item.Id));
                                            foreach (var iDown in TempList)
                                            {
                                                graphicsShape.DrawPath(PenC, iDown);
                                            }
                                        }
                                        //   if (IsInside) { ClicklElement = item; }
                                        ShprosCollection.AddRange(TempList);
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
        }


        private void ClearAllVariables()
        {
           // TempShprossesListElements.Clear();
            TotalShprosLength = 0.0;
            VerticalShprosCounter = 0;
            HorisontalShprosCounter = 0;
            ShprossLineCollection.Clear();
            ShprossArcCollection.Clear();
            ShprossArcWithKeyCollection.Clear();
            RetainerCounter = 0;
            IsInside = false;
            MarginValue = 0;
            MarginRelativeValue = 0;
            AxHorMargin = 30;
            AxVerMargin = 30;
        }

        /// <summary>
        /// Draws the temporary shpros element.
        /// </summary>
        public void DrawTempShprosElement()
        {
            if (GetAllShprosses != null)
            {
                switch (SelectorFlag)
                {
                    case 1:
                        var elem = new ShprosElement
                        {
                            Name = "Element",
                            ChildShprosId = Guid.NewGuid(),
                            OrientationType = this.Orientation,
                            Location = "Here",
                            IsCenter = this.IsCenter,
                            SelectorFlag = this.SelectorFlag,
                            SideDirectionForAxisPack = this.TempSideVector,
                            Margin = this.AxisMargin,
                            SideVector = this.Direction,
                            TypeElement = this.Type,
                            LeftMargin = this.LeftMargin,
                            ChordHeight = this.ShprosChordHeight,
                            IsRelativeMargin = this.IsRelativeMargin,
                            RelativeMargin = this.RelativeValue
                        };
                        GetAllShprosses.Add(elem);

                        break;
                    case 2:
                        GetAllShprosses.Add(new ShprosElement
                        {
                            Name = "Pack",
                            OrientationType = this.Orientation,
                            Location = "Here",
                            IsCenter = this.IsCenter,
                            SelectorFlag = this.SelectorFlag,
                            SideDirectionForAxisPack = this.TempSideVector,
                            Margin = this.AxisMargin,
                            SideVector = Direction,
                            TypeElement = this.Type,
                            LeftMargin = this.LeftMargin,
                            RightMargin = this.RightMargin,
                            Count = this.Count,

                        });
                        break;
                }
            }
            GetAllShprosses = SortedCollection(GetAllShprosses);
        }

        public List<ShprosElement> TempShprossesListElements { get; set; } = new List<ShprosElement>();
        
        /// <summary>
        /// Id для динамического заполнения
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid IsId { get; set; }
        public ShprosElement ClickedElement { get; set; } = new ShprosElement();
       
        internal void DrawTempShprossesListElements()
        {
            ShprosElement _element = new ShprosElement
            {
                Name = "Элемент",
                ChildShprosId = Guid.NewGuid(),
                OrientationType = this.Orientation,
                IsCenter = this.IsCenter,
                SelectorFlag = this.SelectorFlag,
                SideDirectionForAxisPack = this.TempSideVector,
                Margin = this.AxisMargin,
                SideVector = this.Direction,
                TypeElement = this.Type,
                ChordHeight = this.ShprosChordHeight,
                IsRelativeMargin = this.IsRelativeMargin,
                ShapeId = IsId
            };
            _element.RelativeMargin = this.RelativeValue;
            GetCurrentLeftMarginAndShprosId(_element, TempShprossesListElements);
            _element.Location = BuildLocationChangedString(_element, IsRelativeMargin, _element.LeftMargin.Value, RelativeValue);
            TempShprossesListElements.Add(_element);
            GetAllShprosses.AddRange(TempShprossesListElements);
            GetAllShprosses = SortedCollection(GetAllShprosses);
        }

        private void GetCurrentLeftMarginAndShprosId(ShprosElement _element, List<ShprosElement> _items)
        {
            if (IsRelativeMargin == true && (!(ClickedElement is null)))
            {
                if (TempShprossesListElements.Count == 0)
                {
                    _element.ShprosId = ClickedElement.ChildShprosId;
                    _element.LeftMargin = ClickedElement.LeftMargin + RelativeValue;
                }
                else
                {
                    var elem = TempShprossesListElements.Skip(TempShprossesListElements.Count - 1).FirstOrDefault();
                    _element.ShprosId = elem.ChildShprosId;
                    _element.LeftMargin = elem.LeftMargin + RelativeValue;
                }
            }
            else
            {
                _element.ShprosId = Guid.Empty;
                _element.LeftMargin = this.LeftMargin;
            }
        }

        private string BuildLocationChangedString(ShprosElement element, bool? flag, double margValue, double relativeValue)
        {
           
            StringBuilder stringBuilder = new StringBuilder();

            if (element.TypeElement == "Прямая")
            {
                switch (element.SideVector)
                {
                    case "Слева":
                        stringBuilder.Append("Л- ");
                        break;
                    case "Справа":
                        stringBuilder.Append("П- ");
                        break;
                    case "Сверху":
                        stringBuilder.Append("В- ");
                        break;
                    case "Снизу":
                        stringBuilder.Append("Н- ");
                        break;
                    case "Центр":
                        stringBuilder.Append("Ц- ");
                        break;
                }
                if (element.IsCenter == true)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append("Центр ");
                }
                else
                {

                    if (flag == false)
                    {
                        stringBuilder.Append(margValue);
                        stringBuilder.Append("(Абс)");
                    }
                    else
                    {
                        stringBuilder.Append(margValue);
                        stringBuilder.Append("(Абс) , ");
                        stringBuilder.Append(relativeValue);
                        stringBuilder.Append("(Отн)");
                    }
                    stringBuilder.Append("    мм");
                }
            }
            else if (element.TypeElement == "Дуга")
            {
                stringBuilder.Append("Ц- ");
                stringBuilder.Append(margValue);
                stringBuilder.Append($"  / {element.SideDirectionForAxisPack} ");
                stringBuilder.Append("    мм");
            }
            return stringBuilder.ToString();
        }

      

        private List<ShprosElement> SortedCollection(List<ShprosElement> inputItem)
        {
            var list = new List<ShprosElement>();
            foreach (var item in inputItem)
            {
                list.Add(item);
            }
            var shprosesList = list.OrderBy(x => x.LeftMargin)
                .OrderBy(x => x.OrientationType).OrderBy(x => x.SideVector);
            list = list.Distinct().ToList();
            return list;
        }

        /// <summary>
        /// Removes the last item from observable coolection.
        /// </summary>
        public void RemoveLastItemFromObservableCollection()
        {
            GetAllShprosses.RemoveAt(GetAllShprosses.Count - 1);
        }

        #region Elements
        private float MarginValue { get; set; }
        private float MarginRelativeValue { get; set; }
        private int AxHorMargin { get; set; }
        private int AxVerMargin { get; set; }
        public double RelativeValue { get; set; }
        /// <summary>
        /// Creates the vertical element.
        /// </summary>
        /// <param name="dir">The dir.</param>
        /// <param name="factor">The factor.</param>
        private GraphicsPath CreateVerticalElement(string dir = "", float factor = 0F, Guid? id = null)
        {
            ShapePoint StartPoint = null;
            ShapePoint EndPoint = null;
            GraphicsPath path = new GraphicsPath();
            factor = (IsCenter == true) ? SelectedRect.Width / 2 : factor;
            if (factor >= 0 && factor < SelectedRect.Height)
            {
                if (dir == "Слева")
                {
                    StartPoint = GetNewCustomPoint(SelectedRect.X + factor, SelectedRect.Y);
                    EndPoint = GetNewCustomPoint(SelectedRect.X + factor, SelectedRect.Y + SelectedRect.Height);
                    while (!GetShapeShprosBorders().IsVisible(StartPoint))
                    {
                        StartPoint.PointY += 0.5;
                        if (GetShapeShprosBorders().IsVisible(StartPoint))
                            break;
                    }
                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint.PointY -= 0.5;
                        if (GetShapeShprosBorders().IsVisible(EndPoint))
                            break;
                    }
                    path.AddLine(StartPoint, EndPoint);
                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    VerticalShprosCounter += 1;
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(StartPoint, EndPoint, $"В{VerticalShprosCounter}", true, false, id: id));
                    RetainerCounter += 2;
                }
                if (dir == "Справа")
                {
                    StartPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - factor, SelectedRect.Y);
                    EndPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - factor, SelectedRect.Y + SelectedRect.Height);
                    while (!GetShapeShprosBorders().IsVisible(StartPoint))
                    {
                        StartPoint.PointY++;
                        if (GetShapeShprosBorders().IsVisible(StartPoint))
                            break;
                    }
                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint.PointY--;
                        if (GetShapeShprosBorders().IsVisible(EndPoint))
                            break;
                    }

                    path.AddLine(StartPoint, EndPoint);
                    var l = GetNewLine(StartPoint, EndPoint).Length;

                    TotalShprosLength += l;
                    VerticalShprosCounter += 1;
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(GetRoundPoint(StartPoint), GetRoundPoint(EndPoint), $"В{VerticalShprosCounter}", true, false, id: id));
                    ShprossLineCollection = ShprossLineCollection.Distinct().ToList();

                    ClickedLine = new Line(StartPoint, EndPoint);
                    RetainerCounter += 2;
                }
                switch (IsRelativeMargin)
                {
                    case true:
                        MarginRelativeValue = factor - MarginRelativeValue;
                        CreateVertikalRelativeSizeComponents(dir, StartPoint, EndPoint);
                        break;
                    case false:
                        MarginValue = factor;
                        CreateVertikalSizeComponents(dir, StartPoint, EndPoint);
                        break;
                }
            }
            else
            {
                XtraMessageBox.Show("Проверьте значение отступа", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (TempShprossesListElements.Count > 0)
                {
                    TempShprossesListElements.RemoveAt(TempShprossesListElements.Count - 1);
                }
                RemoveLastItemFromObservableCollection();
            }
            ShprosFlag = false;

            return path;
        }
        /// <summary>
        /// Creates the horisontal element.
        /// </summary>
        /// <param name="dir">The dir.</param>
        /// <param name="factor">The factor.</param>
        private GraphicsPath CreateHorisontalElement(string dir = "", float factor = 0F, Guid? id = null)
        {
            ShapePoint StartPoint = null;
            ShapePoint EndPoint = null;
            GraphicsPath path = new GraphicsPath();
            factor = (IsCenter == true) ? SelectedRect.Height / 2 : factor;
            if (factor >= 0 && factor < SelectedRect.Width)
            {
                if (dir == "Сверху")
                {
                    StartPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + factor);
                    EndPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + factor);

                    while (!GetShapeShprosBorders().IsVisible(StartPoint))
                    {
                        StartPoint.PointX += 0.5;
                        if (GetShapeShprosBorders().IsVisible(StartPoint))
                            break;
                    }
                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint.PointX -= 0.5;
                        if (GetShapeShprosBorders().IsVisible(EndPoint))
                            break;
                    }
                    path.AddLine(StartPoint, EndPoint);
                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    HorisontalShprosCounter += 1;
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(StartPoint, EndPoint, $"В{HorisontalShprosCounter}", false, true, id: id));
                    RetainerCounter += 2;
                }
                if (dir == "Снизу")
                {
                    StartPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height - factor);
                    EndPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height - factor);

                    while (!GetShapeShprosBorders().IsVisible(StartPoint))
                    {
                        StartPoint.PointX++;
                        if (GetShapeShprosBorders().IsVisible(StartPoint))
                            break;
                    }
                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint.PointX--;
                        if (GetShapeShprosBorders().IsVisible(EndPoint))
                            break;
                    }
                    path.AddLine(StartPoint, EndPoint);
                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    HorisontalShprosCounter += 1;
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(GetRoundPoint(StartPoint), GetRoundPoint(EndPoint), $"В{HorisontalShprosCounter}", false, true, id: id));
                    ShprossLineCollection = ShprossLineCollection.Distinct().ToList();
                    ClickedLine = new Line(StartPoint, EndPoint);
                    RetainerCounter += 2;
                }
                switch (IsRelativeMargin)
                {
                    case true:
                        MarginRelativeValue = factor - MarginRelativeValue;
                        CreateHorisontalRelativeSizeComponents(dir, StartPoint, EndPoint);
                        break;
                    case false:
                        MarginValue = factor;
                        CreateHorisontalSizeComponents(dir, StartPoint, EndPoint);
                        break;
                }
            }
            else
            {
                XtraMessageBox.Show("Проверьте значение отступа", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (TempShprossesListElements.Count > 0)
                {
                    TempShprossesListElements.RemoveAt(TempShprossesListElements.Count - 1);
                }
                RemoveLastItemFromObservableCollection();
            }
            ShprosFlag = false;
            return path;
        }

        private void CreateHorisontalSizeComponents(string dir, ShapePoint startPoint, ShapePoint endPoint)
        {
            using (var pen = new Pen(Color.Green, 3))
            {
                Font drawFontBold = new Font("Tahoma", emSize: GetCurrentFontSize() / 1.3F);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint st = null;
                ShapePoint fin = null;
                Line ln = null;
                ShapePoint pCenter = null;
                switch (dir)
                {
                    case "Сверху":
                        st = GetNewCustomPoint(SelectedRect.X - AxHorMargin, SelectedRect.Y);
                        fin = GetNewCustomPoint(SelectedRect.X - AxHorMargin, SelectedRect.Y + MarginValue);
                        ln = GetNewLine(st, fin);
                        pCenter = GetNewCustomPoint(SelectedRect.X - AxHorMargin - 5, SelectedRect.Y + MarginValue / 2);
                        graphicsShape.DrawLine(pen, st, fin);
                        graphicsShape.DrawLine(Pens.YellowGreen, startPoint, fin);
                        graphicsShape.DrawLine(Pens.YellowGreen, GetNewCustomPoint(startPoint.PointX, SelectedRect.Y),
                         GetNewCustomPoint(fin.PointX, SelectedRect.Y));
                        break;
                    case "Снизу":
                        st = GetNewCustomPoint(SelectedRect.X - AxHorMargin, SelectedRect.Y + SelectedRect.Height);
                        fin = GetNewCustomPoint(SelectedRect.X - AxHorMargin, SelectedRect.Y + SelectedRect.Height - MarginValue);
                        ln = GetNewLine(st, fin);
                        pCenter = GetNewCustomPoint(SelectedRect.X - AxHorMargin - 5, SelectedRect.Y + SelectedRect.Height - MarginValue / 2);
                        graphicsShape.DrawLine(pen, st, fin);
                        graphicsShape.DrawLine(Pens.YellowGreen, startPoint, fin);
                        graphicsShape.DrawLine(Pens.YellowGreen, GetNewCustomPoint(startPoint.PointX, SelectedRect.Y + SelectedRect.Height),
                         GetNewCustomPoint(fin.PointX, SelectedRect.Y + SelectedRect.Height));
                        break;
                }
                graphicsShape.DrawString(MarginValue.ToString(), drawFontBold, Brushes.Black, pCenter, sf);

            }
        }
        private void CreateVertikalSizeComponents(string dir, ShapePoint startPoint, ShapePoint endPoint)
        {
            using (var pen = new Pen(Color.Green, 3))
            {
                Font drawFontBold = new Font("Tahoma", emSize: GetCurrentFontSize() / 1.3F);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint st = null;
                ShapePoint fin = null;
                Line ln = null;
                ShapePoint pCenter = null;
                switch (dir)
                {
                    case "Слева":
                        st = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - AxVerMargin);
                        fin = GetNewCustomPoint(SelectedRect.X + MarginValue, SelectedRect.Y - AxVerMargin);
                        ln = GetNewLine(st, fin);
                        pCenter = GetNewCustomPoint(SelectedRect.X + MarginValue / 2, SelectedRect.Y - AxVerMargin - 5);
                        graphicsShape.DrawLine(pen, st, fin);
                        graphicsShape.DrawLine(Pens.Black, startPoint, fin);
                        graphicsShape.DrawLine(Pens.Black, st,
                         GetNewCustomPoint(SelectedRect.X, SelectedRect.Y));
                        break;
                    case "Справа":
                        st = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - AxVerMargin);
                        fin = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - MarginValue, SelectedRect.Y - AxVerMargin);
                        ln = GetNewLine(st, fin);
                        pCenter = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - MarginValue / 2, SelectedRect.Y - AxVerMargin - 5);
                        graphicsShape.DrawLine(pen, st, fin);
                        graphicsShape.DrawLine(Pens.Black, startPoint, fin);
                        graphicsShape.DrawLine(Pens.Black, st,
                         GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y));
                        break;
                }
                graphicsShape.DrawString(MarginValue.ToString(), drawFontBold, Brushes.Black, pCenter, sf);
            }
        }
        private void CreateHorisontalRelativeSizeComponents(string dir, ShapePoint startPoint, ShapePoint endPoint)
        {
            using (var pen = new Pen(Color.Green, 3))
            {
                Font drawFontBold = new Font("Tahoma", emSize: GetCurrentFontSize() / 1.3F);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint st = null;
                ShapePoint fin = null;
                Line ln = null;
                ShapePoint pCenter = null;
                switch (dir)
                {
                    case "Сверху":
                        st = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 25, endPoint.PointY - MarginRelativeValue);
                        fin = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 25, endPoint.PointY);
                        ln = GetNewLine(st, fin);
                        pCenter = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 35, endPoint.PointY - ln.Length / 2);
                        graphicsShape.DrawLine(pen, st, fin);
                        graphicsShape.DrawLine(Pens.YellowGreen, endPoint, fin);
                        graphicsShape.DrawLine(Pens.YellowGreen, GetNewCustomPoint(endPoint.PointX, endPoint.PointY -
                            MarginRelativeValue), GetNewCustomPoint(fin.PointX, fin.PointY - MarginRelativeValue));
                        break;

                    case "Снизу":
                        st = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 25, endPoint.PointY + MarginRelativeValue);
                        fin = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 25, endPoint.PointY);
                        ln = GetNewLine(st, fin);
                        pCenter = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 35, endPoint.PointY + ln.Length / 2);
                        graphicsShape.DrawLine(pen, st, fin);
                        graphicsShape.DrawLine(Pens.YellowGreen, endPoint, fin);
                        graphicsShape.DrawLine(Pens.YellowGreen, GetNewCustomPoint(endPoint.PointX, endPoint.PointY +
                            MarginRelativeValue), GetNewCustomPoint(fin.PointX, fin.PointY + MarginRelativeValue));
                        break;
                }
                graphicsShape.DrawString(MarginRelativeValue.ToString(), drawFontBold, Brushes.Black, pCenter, sf);
            }
        }
        private void CreateVertikalRelativeSizeComponents(string dir, ShapePoint startPoint, ShapePoint endPoint)
        {
            using (var pen = new Pen(Color.Green, 3))
            {
                Font drawFontBold = new Font("Tahoma", emSize: GetCurrentFontSize() / 1.3F);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint st = null;
                ShapePoint fin = null;
                Line ln = null;
                ShapePoint pCenter = null;
                switch (dir)
                {
                    case "Слева":
                        st = GetNewCustomPoint(startPoint.PointX - MarginRelativeValue, SelectedRect.Y + SelectedRect.Height + 30);
                        fin = GetNewCustomPoint(startPoint.PointX, SelectedRect.Y + SelectedRect.Height + 30);
                        ln = GetNewLine(st, fin);
                        pCenter = GetNewCustomPoint(startPoint.PointX - MarginRelativeValue / 2, SelectedRect.Y + SelectedRect.Height + 45);
                        graphicsShape.DrawLine(pen, st, fin);
                        graphicsShape.DrawLine(Pens.Black, endPoint, fin);
                        graphicsShape.DrawLine(Pens.Black, st,
                         GetNewCustomPoint(fin.PointX - MarginRelativeValue, SelectedRect.Y + SelectedRect.Height));
                        break;
                    case "Справа":
                        st = GetNewCustomPoint(startPoint.PointX + MarginRelativeValue, SelectedRect.Y + SelectedRect.Height + 30);
                        fin = GetNewCustomPoint(startPoint.PointX, SelectedRect.Y + SelectedRect.Height + 30);
                        ln = GetNewLine(st, fin);
                        pCenter = GetNewCustomPoint(startPoint.PointX + MarginRelativeValue / 2, SelectedRect.Y + SelectedRect.Height + 45);
                        graphicsShape.DrawLine(pen, st, fin);
                        graphicsShape.DrawLine(Pens.Black, endPoint, fin);
                        graphicsShape.DrawLine(Pens.Black, st,
                         GetNewCustomPoint(fin.PointX + MarginRelativeValue, SelectedRect.Y + SelectedRect.Height));
                        break;
                }
                graphicsShape.DrawString(MarginRelativeValue.ToString(), drawFontBold, Brushes.Black, pCenter, sf);
            }
        }


        #endregion
        #region ArcElements
        /// <summary>
        /// Creates up arc element.
        /// </summary>
        /// <param name="heigth">The heigth.</param>
        /// <param name="factor">The factor.</param>
        /// <returns></returns>
        private GraphicsPath CreateUpArcElement(string dir = "", double? margin = 0.0, double? axisFactor = 0.0, Guid? id = null)
        {
            // var factor = axisFactor;
            GraphicsPath path = null;
            if ((margin <= SelectedRect.Height && SelectedRect.Height <= SelectedRect.Width) ||
                                 (margin <= SelectedRect.Width && SelectedRect.Width <= SelectedRect.Height))
            {
                path = new GraphicsPath();
                ShapePoint LeftPoint = GetNewPoint();
                ShapePoint RightPoint = GetNewPoint();
                ShapePoint CenterPoint = GetNewPoint();
                switch (dir)
                {
                    case "Слева":
                        if (axisFactor != 0)
                        {
                            if (axisFactor > 0)
                            {
                                RightPoint = GetNewCustomPoint(SelectedRect.X - 1 + axisFactor ?? 0.0, SelectedRect.Y);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + axisFactor ?? 0.0, SelectedRect.Y);
                                LeftPoint = GetNewCustomPoint(SelectedRect.X + 1 + axisFactor ?? 0.0, SelectedRect.Y);
                            }
                            else
                            {
                                LeftPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                                RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            }
                        }
                        else
                        {
                            RightPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                            LeftPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                        }
                        break;
                    case "Центр":

                        RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 - 1 + axisFactor ?? 0.0, SelectedRect.Y);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + axisFactor ?? 0.0, SelectedRect.Y);
                        LeftPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + 1 + axisFactor ?? 0.0, SelectedRect.Y);
                        break;
                    case "Справа":
                        if (axisFactor != 0)
                        {
                            if (axisFactor > 0)
                            {
                                RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - 1 - axisFactor ?? 0.0, SelectedRect.Y);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - axisFactor ?? 0.0, SelectedRect.Y);
                                LeftPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 1 - axisFactor ?? 0.0, SelectedRect.Y);
                            }
                            else
                            {
                                LeftPoint = GetNewCustomPoint(SelectedRect.X + axisFactor ?? 0.0, SelectedRect.Y);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + axisFactor ?? 0.0, SelectedRect.Y);
                                RightPoint = GetNewCustomPoint(SelectedRect.X + axisFactor ?? 0.0, SelectedRect.Y);
                            }
                        }
                        else
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - axisFactor - 1 ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + axisFactor ?? 0.0, SelectedRect.Y);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - axisFactor ?? 0.0, SelectedRect.Y + 1);
                        }
                        break;

                    default:
                        break;
                }

                LeftPoint = SetCurrentLineLength(CenterPoint, LeftPoint, margin ?? 0);
                RightPoint = SetCurrentLineLength(CenterPoint, RightPoint, margin ?? 0);

                CurvePoint.PointX = (RightPoint.PointX - CenterPoint.PointX) * Math.Cos(-LeftBottomAngle * Math.PI / 180) -
                                    (RightPoint.PointY - CenterPoint.PointY) * Math.Sin(-LeftBottomAngle * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (RightPoint.PointX - CenterPoint.PointX) * Math.Sin(-LeftBottomAngle * Math.PI / 180) +
                                    (RightPoint.PointY - CenterPoint.PointY) * Math.Cos(-LeftBottomAngle * Math.PI / 180) + CenterPoint.PointY;
                RightPoint.PointX = CurvePoint.PointX;
                RightPoint.PointY = CurvePoint.PointY;

                CurvePoint.PointX = (LeftPoint.PointX - CenterPoint.PointX) * Math.Cos(RightBottomAngle * Math.PI / 180) -
                                    (LeftPoint.PointY - CenterPoint.PointY) * Math.Sin(RightBottomAngle * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (LeftPoint.PointX - CenterPoint.PointX) * Math.Sin(RightBottomAngle * Math.PI / 180) +
                                    (LeftPoint.PointY - CenterPoint.PointY) * Math.Cos(RightBottomAngle * Math.PI / 180) + CenterPoint.PointY;
                LeftPoint.PointX = CurvePoint.PointX;
                LeftPoint.PointY = CurvePoint.PointY;



                while (!GetShapeShprosBorders().IsVisible(CurvePoint))
                {
                    CurvePoint.PointX = (CurvePoint.PointX - CenterPoint.PointX) * Math.Cos(0.1 * Math.PI / 180) -
                       (CurvePoint.PointY - CenterPoint.PointY) * Math.Sin(0.1 * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (CurvePoint.PointX - CenterPoint.PointX) * Math.Sin(0.1 * Math.PI / 180) +
                        (CurvePoint.PointY - CenterPoint.PointY) * Math.Cos(0.1 * Math.PI / 180) + CenterPoint.PointY;
                    if (GetShapeShprosBorders().IsVisible(CurvePoint))
                    {
                        LeftPoint.PointX = CurvePoint.PointX;
                        LeftPoint.PointY = CurvePoint.PointY;
                        break;
                    }
                }
                CurvePoint.PointX = RightPoint.PointX;
                CurvePoint.PointY = RightPoint.PointY;
                while (!GetShapeShprosBorders().IsVisible(CurvePoint))
                {
                    CurvePoint.PointX = (CurvePoint.PointX - CenterPoint.PointX) * Math.Cos(-0.1 * Math.PI / 180) -
                       (CurvePoint.PointY - CenterPoint.PointY) * Math.Sin(-0.1 * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (CurvePoint.PointX - CenterPoint.PointX) * Math.Sin(-0.1 * Math.PI / 180) +
                        (CurvePoint.PointY - CenterPoint.PointY) * Math.Cos(-0.1 * Math.PI / 180) + CenterPoint.PointY;

                    if (GetShapeShprosBorders().IsVisible(CurvePoint))
                    {
                        RightPoint.PointX = CurvePoint.PointX;
                        RightPoint.PointY = CurvePoint.PointY;
                        break;
                    }
                }
                var arc = GetShprosFigurePointsForArc(LeftPoint, RightPoint, CenterPoint, id: id);
                ShprossArcCollection.Add(arc);
                ShprossArcCollection = ShprossArcCollection.Distinct().ToList();
                ShprossArcWithKeyCollection.Add(Tuple.Create(id.Value, arc));
                ShprossArcWithKeyCollection = ShprossArcWithKeyCollection.GroupBy(x => new { x.Item1, x.Item2 })
                             .Select(x => x.First())
                                            .ToList();
                path.AddCurve(arc);
                var arcLength = (Math.PI * margin * CalculateAngle(RightPoint, CenterPoint, LeftPoint)) / 180;
                TotalShprosLength += arcLength ?? 0;
                RetainerCounter += 2;
            }
            else { ValidateSetSizeMessage(Text: "Проверьте значение отступа"); ValidValue = false; }
            return path;
        }
        /// <summary>
        /// Creates the bottom arc element.
        /// </summary>
        /// <param name="heigth">The heigth.</param>
        /// <param name="factor">The factor.</param>
        /// <returns></returns>
        private GraphicsPath CreateBottomArcElement(string dir = "", double? margin = 0.0, double? axisFactor = 0.0, Guid? id = null)
        {
            GraphicsPath path = null;
            if ((margin <= SelectedRect.Height && SelectedRect.Height <= SelectedRect.Width) ||
                                 (margin <= SelectedRect.Width && SelectedRect.Width <= SelectedRect.Height))
            {
                path = new GraphicsPath();
                ShapePoint LeftPoint = GetNewPoint();
                ShapePoint RightPoint = GetNewPoint();
                ShapePoint CenterPoint = GetNewPoint();
                switch (dir)
                {
                    case "Слева":
                        if (axisFactor != 0)
                        {
                            if (axisFactor > 0)
                            {
                                LeftPoint = GetNewCustomPoint(SelectedRect.X - 1 + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                                RightPoint = GetNewCustomPoint(SelectedRect.X + 1 + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                            }
                            else
                            {
                                LeftPoint = GetNewCustomPoint(SelectedRect.X + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                                RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                            }
                        }
                        else
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                        }

                        break;
                    case "Центр":
                        LeftPoint = GetNewCustomPoint(SelectedRect.X + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                        RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                        break;
                    case "Справа":
                        if (axisFactor != 0)
                        {
                            if (axisFactor > 0)
                            {
                                LeftPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - 1 + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                                RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 1 - axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                            }
                            else
                            {
                                LeftPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - 1, SelectedRect.Y + SelectedRect.Height);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                                RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 1, SelectedRect.Y + SelectedRect.Height);
                            }
                        }
                        else
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - axisFactor - 1 ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - axisFactor ?? 0.0, SelectedRect.Y + SelectedRect.Height - 1);
                        }
                        break;

                    default:
                        break;
                }
                LeftPoint = SetCurrentLineLength(CenterPoint, LeftPoint, margin ?? 0);
                RightPoint = SetCurrentLineLength(CenterPoint, RightPoint, margin ?? 0);
                CurvePoint.PointX = LeftPoint.PointX;
                CurvePoint.PointY = LeftPoint.PointY;


                // LeftBottomAngle
                // RightBottomAngle

                CurvePoint.PointX = (RightPoint.PointX - CenterPoint.PointX) * Math.Cos(-RightBottomAngle * Math.PI / 180) -
                                     (RightPoint.PointY - CenterPoint.PointY) * Math.Sin(-RightBottomAngle * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (RightPoint.PointX - CenterPoint.PointX) * Math.Sin(-RightBottomAngle * Math.PI / 180) +
                                    (RightPoint.PointY - CenterPoint.PointY) * Math.Cos(-RightBottomAngle * Math.PI / 180) + CenterPoint.PointY;
                RightPoint.PointX = CurvePoint.PointX;
                RightPoint.PointY = CurvePoint.PointY;

                CurvePoint.PointX = (LeftPoint.PointX - CenterPoint.PointX) * Math.Cos(LeftBottomAngle * Math.PI / 180) -
                                       (LeftPoint.PointY - CenterPoint.PointY) * Math.Sin(LeftBottomAngle * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (LeftPoint.PointX - CenterPoint.PointX) * Math.Sin(LeftBottomAngle * Math.PI / 180) +
                                    (LeftPoint.PointY - CenterPoint.PointY) * Math.Cos(LeftBottomAngle * Math.PI / 180) + CenterPoint.PointY;
                LeftPoint.PointX = CurvePoint.PointX;
                LeftPoint.PointY = CurvePoint.PointY;



                while (!GetShapeShprosBorders().IsVisible(CurvePoint))
                {
                    CurvePoint.PointX = (CurvePoint.PointX - CenterPoint.PointX) * Math.Cos(0.1 * Math.PI / 180) -
                       (CurvePoint.PointY - CenterPoint.PointY) * Math.Sin(0.1 * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (CurvePoint.PointX - CenterPoint.PointX) * Math.Sin(0.1 * Math.PI / 180) +
                        (CurvePoint.PointY - CenterPoint.PointY) * Math.Cos(0.1 * Math.PI / 180) + CenterPoint.PointY;
                    if (GetShapeShprosBorders().IsVisible(CurvePoint))
                    {
                        LeftPoint.PointX = CurvePoint.PointX;
                        LeftPoint.PointY = CurvePoint.PointY;
                        break;
                    }
                }
                CurvePoint.PointX = RightPoint.PointX;
                CurvePoint.PointY = RightPoint.PointY;
                while (!GetShapeShprosBorders().IsVisible(CurvePoint))
                {
                    CurvePoint.PointX = (CurvePoint.PointX - CenterPoint.PointX) * Math.Cos(-0.1 * Math.PI / 180) -
                       (CurvePoint.PointY - CenterPoint.PointY) * Math.Sin(-0.1 * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (CurvePoint.PointX - CenterPoint.PointX) * Math.Sin(-0.1 * Math.PI / 180) +
                        (CurvePoint.PointY - CenterPoint.PointY) * Math.Cos(-0.1 * Math.PI / 180) + CenterPoint.PointY;

                    if (GetShapeShprosBorders().IsVisible(CurvePoint))
                    {
                        RightPoint.PointX = CurvePoint.PointX;
                        RightPoint.PointY = CurvePoint.PointY;
                        break;
                    }
                }

                var arc = GetShprosFigurePointsForArc(LeftPoint, RightPoint, CenterPoint, id: id);
                ShprossArcCollection.Add(arc);
                ShprossArcCollection = ShprossArcCollection.Distinct().ToList();
                ShprossArcWithKeyCollection.Add(Tuple.Create(id.Value, arc));
                ShprossArcWithKeyCollection = ShprossArcWithKeyCollection.GroupBy(x => new { x.Item1, x.Item2 })
                             .Select(x => x.First())
                                            .ToList();
                path.AddCurve(arc);
                var arcLength = (Math.PI * margin * CalculateAngle(RightPoint, CenterPoint, LeftPoint)) / 180;
                TotalShprosLength += arcLength ?? 0;
                RetainerCounter += 2;
            }
            else { ValidateSetSizeMessage(Text: "Проверьте значение отступа"); ValidValue = false; }

            return path;
        }
        /// <summary>
        /// Creates the left arc element.
        /// </summary>
        /// <param name="heigth">The heigth.</param>
        /// <param name="factor">The factor.</param>
        /// <returns></returns>
        private GraphicsPath CreateLeftArcElement(string dir = "", double? margin = 0.0, double? axisFactor = 0.0, Guid? id = null)
        {
            GraphicsPath path = null;
            if ((margin <= SelectedRect.Height && SelectedRect.Height <= SelectedRect.Width) ||
                                 (margin <= SelectedRect.Width && SelectedRect.Width <= SelectedRect.Height))
            {
                path = new GraphicsPath();
                ShapePoint UpPoint = GetNewPoint();
                ShapePoint BottomPoint = GetNewPoint();
                ShapePoint CenterPoint = GetNewPoint();
                switch (dir)
                {
                    case "Сверху":
                        if (axisFactor != 0)
                        {
                            if (axisFactor > 0)
                            {
                                BottomPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - 1 + axisFactor ?? 0.0);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + axisFactor ?? 0.0);
                                UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + 1 + axisFactor ?? 0.0);
                            }
                            else
                            {
                                BottomPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - 1);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                                UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + 1);
                            }
                        }
                        else
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X + 1, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                            BottomPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + 1);
                        }
                        break;
                    case "Центр":
                        BottomPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height / 2 + 1 + axisFactor ?? 0.0);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height / 2 + axisFactor ?? 0.0);
                        UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height / 2 - 1 + axisFactor ?? 0.0);
                        break;
                    case "Снизу":
                        if (axisFactor != 0)
                        {
                            if (axisFactor > 0)
                            {
                                BottomPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height - 1 - axisFactor ?? 0.0);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height - axisFactor ?? 0.0);
                                UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height + 1 - axisFactor ?? 0.0);
                            }
                            else
                            {
                                BottomPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height - 1);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                                UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height + 1);
                            }
                        }
                        else
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height - 1);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            BottomPoint = GetNewCustomPoint(SelectedRect.X + 1, SelectedRect.Y + SelectedRect.Height);
                        }
                        break;

                    default:
                        break;
                }
                UpPoint = SetCurrentLineLength(CenterPoint, UpPoint, margin ?? 0);
                BottomPoint = SetCurrentLineLength(CenterPoint, BottomPoint, margin ?? 0);
                //CurvePoint.PointX = UpPoint.PointX;
                //CurvePoint.PointY = UpPoint.PointY;

                CurvePoint.PointX = (UpPoint.PointX - CenterPoint.PointX) * Math.Cos(LeftBottomAngle * Math.PI / 180) -
                                    (UpPoint.PointY - CenterPoint.PointY) * Math.Sin(LeftBottomAngle * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (UpPoint.PointX - CenterPoint.PointX) * Math.Sin(LeftBottomAngle * Math.PI / 180) +
                                    (UpPoint.PointY - CenterPoint.PointY) * Math.Cos(LeftBottomAngle * Math.PI / 180) + CenterPoint.PointY;
                UpPoint.PointX = CurvePoint.PointX;
                UpPoint.PointY = CurvePoint.PointY;

                CurvePoint.PointX = (BottomPoint.PointX - CenterPoint.PointX) * Math.Cos(-RightBottomAngle * Math.PI / 180) -
                                    (BottomPoint.PointY - CenterPoint.PointY) * Math.Sin(-RightBottomAngle * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (BottomPoint.PointX - CenterPoint.PointX) * Math.Sin(-RightBottomAngle * Math.PI / 180) +
                                    (BottomPoint.PointY - CenterPoint.PointY) * Math.Cos(-RightBottomAngle * Math.PI / 180) + CenterPoint.PointY;
                BottomPoint.PointX = CurvePoint.PointX;
                BottomPoint.PointY = CurvePoint.PointY;

                while (!GetShapeShprosBorders().IsVisible(CurvePoint))
                {
                    CurvePoint.PointX = (CurvePoint.PointX - CenterPoint.PointX) * Math.Cos(0.1 * Math.PI / 180) -
                       (CurvePoint.PointY - CenterPoint.PointY) * Math.Sin(0.1 * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (CurvePoint.PointX - CenterPoint.PointX) * Math.Sin(0.1 * Math.PI / 180) +
                        (CurvePoint.PointY - CenterPoint.PointY) * Math.Cos(0.1 * Math.PI / 180) + CenterPoint.PointY;
                    if (GetShapeShprosBorders().IsVisible(CurvePoint))
                    {
                        UpPoint.PointX = CurvePoint.PointX;
                        UpPoint.PointY = CurvePoint.PointY;
                        break;
                    }
                }
                CurvePoint.PointX = BottomPoint.PointX;
                CurvePoint.PointY = BottomPoint.PointY;
                while (!GetShapeShprosBorders().IsVisible(CurvePoint))
                {
                    CurvePoint.PointX = (CurvePoint.PointX - CenterPoint.PointX) * Math.Cos(-0.1 * Math.PI / 180) -
                       (CurvePoint.PointY - CenterPoint.PointY) * Math.Sin(-0.1 * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (CurvePoint.PointX - CenterPoint.PointX) * Math.Sin(-0.1 * Math.PI / 180) +
                        (CurvePoint.PointY - CenterPoint.PointY) * Math.Cos(-0.1 * Math.PI / 180) + CenterPoint.PointY;

                    if (GetShapeShprosBorders().IsVisible(CurvePoint))
                    {
                        BottomPoint.PointX = CurvePoint.PointX;
                        BottomPoint.PointY = CurvePoint.PointY;
                        break;
                    }
                }
                var arc = GetShprosFigurePointsForArc(UpPoint, BottomPoint, CenterPoint, id: id);
                ShprossArcCollection.Add(arc);
                ShprossArcCollection = ShprossArcCollection.Distinct().ToList();
                ShprossArcWithKeyCollection.Add(Tuple.Create(id.Value, arc));
                ShprossArcWithKeyCollection = ShprossArcWithKeyCollection.GroupBy(x => new { x.Item1, x.Item2 })
                             .Select(x => x.First())
                                            .ToList();
                path.AddCurve(arc);
                var arcLength = (Math.PI * margin * CalculateAngle(BottomPoint, CenterPoint, UpPoint)) / 180;
                TotalShprosLength += arcLength ?? 0;
                RetainerCounter += 2;
            }
            else { ValidateSetSizeMessage(Text: "Проверьте значение отступа"); ValidValue = false; }
            return path;
        }
        /// <summary>
        /// Creates the right arc element.
        /// </summary>
        /// <param name="heigth">The heigth.</param>
        /// <param name="factor">The factor.</param>
        /// <returns></returns>
        private GraphicsPath CreateRightArcElement(string dir = "", double? margin = 0.0, double? axisFactor = 0.0, Guid? id = null)
        {
            GraphicsPath path = null;
            if ((margin <= SelectedRect.Height && SelectedRect.Height <= SelectedRect.Width) ||
                                 (margin <= SelectedRect.Width && SelectedRect.Width <= SelectedRect.Height))
            {
                path = new GraphicsPath();
                ShapePoint UpPoint = GetNewPoint();
                ShapePoint BottomPoint = GetNewPoint();
                ShapePoint CenterPoint = GetNewPoint();
                switch (dir)
                {
                    case "Сверху":
                        if (axisFactor != 0)
                        {
                            if (axisFactor > 0)
                            {
                                BottomPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 1 + axisFactor ?? 0.0);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + axisFactor ?? 0.0);
                                UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + 1 + axisFactor ?? 0.0);
                            }
                            else
                            {
                                BottomPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 1);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                                UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + 1);
                            }
                        }
                        else
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X + +SelectedRect.Width - 1, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            BottomPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + 1);
                        }
                        break;
                    case "Центр":
                        UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height / 2 + 1 + axisFactor ?? 0.0);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height / 2 + axisFactor ?? 0.0);
                        BottomPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height / 2 - 1 + axisFactor ?? 0.0);
                        break;
                    case "Снизу":
                        if (axisFactor != 0)
                        {
                            if (axisFactor > 0)
                            {
                                BottomPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height - 1 - axisFactor ?? 0.0);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height - axisFactor ?? 0.0);
                                UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height + 1 - axisFactor ?? 0.0);
                            }
                            else
                            {
                                BottomPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height - 1);
                                CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                                UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height + 1);
                            }
                        }
                        else
                        {
                            BottomPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height - 1);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - 1, SelectedRect.Y + SelectedRect.Height);
                        }
                        break;

                    default:
                        break;
                }
                UpPoint = SetCurrentLineLength(CenterPoint, UpPoint, margin ?? 0);
                BottomPoint = SetCurrentLineLength(CenterPoint, BottomPoint, margin ?? 0);
                CurvePoint.PointX = UpPoint.PointX;
                CurvePoint.PointY = UpPoint.PointY;

                CurvePoint.PointX = (UpPoint.PointX - CenterPoint.PointX) * Math.Cos(LeftBottomAngle * Math.PI / 180) -
                                   (UpPoint.PointY - CenterPoint.PointY) * Math.Sin(LeftBottomAngle * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (UpPoint.PointX - CenterPoint.PointX) * Math.Sin(LeftBottomAngle * Math.PI / 180) +
                                    (UpPoint.PointY - CenterPoint.PointY) * Math.Cos(LeftBottomAngle * Math.PI / 180) + CenterPoint.PointY;
                UpPoint.PointX = CurvePoint.PointX;
                UpPoint.PointY = CurvePoint.PointY;

                CurvePoint.PointX = (BottomPoint.PointX - CenterPoint.PointX) * Math.Cos(-RightBottomAngle * Math.PI / 180) -
                                    (BottomPoint.PointY - CenterPoint.PointY) * Math.Sin(-RightBottomAngle * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (BottomPoint.PointX - CenterPoint.PointX) * Math.Sin(-RightBottomAngle * Math.PI / 180) +
                                    (BottomPoint.PointY - CenterPoint.PointY) * Math.Cos(-RightBottomAngle * Math.PI / 180) + CenterPoint.PointY;
                BottomPoint.PointX = CurvePoint.PointX;
                BottomPoint.PointY = CurvePoint.PointY;
                while (!GetShapeShprosBorders().IsVisible(CurvePoint))
                {
                    CurvePoint.PointX = (CurvePoint.PointX - CenterPoint.PointX) * Math.Cos(0.1 * Math.PI / 180) -
                       (CurvePoint.PointY - CenterPoint.PointY) * Math.Sin(0.1 * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (CurvePoint.PointX - CenterPoint.PointX) * Math.Sin(0.1 * Math.PI / 180) +
                        (CurvePoint.PointY - CenterPoint.PointY) * Math.Cos(0.1 * Math.PI / 180) + CenterPoint.PointY;
                    if (GetShapeShprosBorders().IsVisible(CurvePoint))
                    {
                        UpPoint.PointX = CurvePoint.PointX;
                        UpPoint.PointY = CurvePoint.PointY;
                        break;
                    }
                }
                CurvePoint.PointX = BottomPoint.PointX;
                CurvePoint.PointY = BottomPoint.PointY;
                while (!GetShapeShprosBorders().IsVisible(CurvePoint))
                {
                    CurvePoint.PointX = (CurvePoint.PointX - CenterPoint.PointX) * Math.Cos(-0.1 * Math.PI / 180) -
                       (CurvePoint.PointY - CenterPoint.PointY) * Math.Sin(-0.1 * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (CurvePoint.PointX - CenterPoint.PointX) * Math.Sin(-0.1 * Math.PI / 180) +
                        (CurvePoint.PointY - CenterPoint.PointY) * Math.Cos(-0.1 * Math.PI / 180) + CenterPoint.PointY;

                    if (GetShapeShprosBorders().IsVisible(CurvePoint))
                    {
                        BottomPoint.PointX = CurvePoint.PointX;
                        BottomPoint.PointY = CurvePoint.PointY;
                        break;
                    }
                }
                var arc = GetShprosFigurePointsForArc(UpPoint, BottomPoint, CenterPoint, id: id);
                ShprossArcCollection.Add(arc);
                ShprossArcCollection = ShprossArcCollection.Distinct().ToList();
                ShprossArcWithKeyCollection.Add(Tuple.Create(id.Value, arc));
                ShprossArcWithKeyCollection = ShprossArcWithKeyCollection.GroupBy(x => new { x.Item1, x.Item2 })
                              .Select(x => x.First())
                                             .ToList();
                path.AddCurve(arc);
                var arcLength = (Math.PI * margin * CalculateAngle(BottomPoint, CenterPoint, UpPoint)) / 180;
                TotalShprosLength += arcLength ?? 0;
                RetainerCounter += 2;
            }
            else { ValidateSetSizeMessage(Text: "Проверьте значение отступа"); ValidValue = false; }
            return path;
        }
        #endregion
        #region Element Packs
        /// <summary>
        /// Creates the vertical elements pack.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="leftFactor">The left factor.</param>
        /// <param name="rightFactor">The right factor.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private List<GraphicsPath> CreateVerticalElementsPack(string orientation = "", double leftFactor = 0.0, double rightFactor = 0.0, int count = 0, Guid? id = null)
        {
            var list = new List<GraphicsPath>();
            var width = SelectedRect.Width - leftFactor - rightFactor;
            var OneSide = Math.Round(width / (count + 1), 0);
            var startXcoord = SelectedRect.X + leftFactor + OneSide;
            var apogeusXcoord = startXcoord + width;
            ShapePoint StartPoint;
            ShapePoint EndPoint;
            if (count > 0 && leftFactor + rightFactor < SelectedRect.Width)
            {
                int counter = 0;
                while (counter < count)
                {
                    StartPoint = GetNewCustomPoint(startXcoord, SelectedRect.Y);
                    EndPoint = GetNewCustomPoint(startXcoord, SelectedRect.Y + SelectedRect.Height);
                    while (!GetShapeShprosBorders().IsVisible(StartPoint))
                    {
                        StartPoint.PointY += 0.5;
                        if (GetShapeShprosBorders().IsVisible(StartPoint))
                            break;
                    }
                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint.PointY -= 0.5;
                        if (GetShapeShprosBorders().IsVisible(EndPoint))
                            break;
                    }
                    var item = new GraphicsPath();
                    item.AddLine(StartPoint, EndPoint);
                    VerticalShprosCounter += 1;
                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    list.Add(item);
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(GetRoundPoint(StartPoint), GetRoundPoint(EndPoint), $"В{VerticalShprosCounter}", true, false, id: id));
                    ShprossLineCollection = ShprossLineCollection.Distinct().ToList();
                    startXcoord += OneSide;
                    counter++;
                }
                var l = TotalShprosLength;
                var text = $"Набор: Л- {leftFactor} П- {rightFactor} Кол - {count} шт. ";
                CreateVertikalSizeComponentsForPack(leftFactor + OneSide,leftFactor + (OneSide * count), text);
            }
            else
            {

                if (TempShprossesListElements.Count > 0)
                {
                    TempShprossesListElements.RemoveAt(TempShprossesListElements.Count - 1);
                }
                RemoveLastItemFromObservableCollection();
                XtraMessageBox.Show("Проверьте значение отступов", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        /// <summary>
        /// Creates the horisontal elements pack.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="leftFactor">The left factor.</param>
        /// <param name="rightFactor">The right factor.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private List<GraphicsPath> CreateHorisontalElementsPack(string orientation = "", double leftFactor = 0.0, double rightFactor = 0.0, int count = 0, Guid? id = null)
        {
            var list = new List<GraphicsPath>();
            var height = SelectedRect.Height - leftFactor - rightFactor;
            var OneSide = Math.Round(height / (count + 1), 0);
            var startYcoord = SelectedRect.Y + leftFactor + OneSide;
            var apogeusXcoord = startYcoord + height;
            ShapePoint StartPoint;
            ShapePoint EndPoint;
            int counter = 0;
            if (count > 0 && leftFactor + rightFactor < SelectedRect.Height)
            {
                while (counter < count)
                {
                    StartPoint = GetNewCustomPoint(SelectedRect.X, startYcoord);
                    EndPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, startYcoord);
                    while (!GetShapeShprosBorders().IsVisible(StartPoint))
                    {
                        StartPoint.PointX += 0.5;
                        if (GetShapeShprosBorders().IsVisible(StartPoint))
                            break;
                    }
                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint.PointX -= 0.5;
                        if (GetShapeShprosBorders().IsVisible(EndPoint))
                            break;
                    }
                    var item = new GraphicsPath();
                    item.AddLine(StartPoint, EndPoint);
                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    HorisontalShprosCounter += 1;
                    RetainerCounter += 2;
                    list.Add(item);
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(GetRoundPoint(StartPoint), GetRoundPoint(EndPoint), $"В{HorisontalShprosCounter}", false, true, id: id));
                    ShprossLineCollection = ShprossLineCollection.Distinct().ToList();
                    startYcoord += OneSide;
                    counter++;
                }
                var l = TotalShprosLength;
                var text = $"Набор: В- {leftFactor} Н- {rightFactor} Кол - {count} шт. ";
                CreateHorisontalSizeComponentsForPack(leftFactor+OneSide, leftFactor+(OneSide * count), text);
            }
            else
            {

                if (TempShprossesListElements.Count > 0)
                {
                    TempShprossesListElements.RemoveAt(TempShprossesListElements.Count - 1);
                }
                RemoveLastItemFromObservableCollection();
                XtraMessageBox.Show("Проверьте значение отступов", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list;
        }

        private void CreateHorisontalSizeComponentsForPack(double startCount,double finishCount,string text)
        {
            using (var pen = new Pen(Color.Green, 3))
            {
                Font drawFontBold = new Font("Tahoma", emSize: GetCurrentFontSize() / 1.3F);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.DirectionVertical;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint st = null;
                ShapePoint fin = null;
                Line ln = null;
                ShapePoint pCenter = null;
                st = GetNewCustomPoint(SelectedRect.X +SelectedRect.Width+50, SelectedRect.Y + startCount);
                fin = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 50, SelectedRect.Y + finishCount);
                ln = GetNewLine(st, fin);
                pCenter = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 60, st.PointY+ln.Length/2);
                graphicsShape.DrawLine(pen, st, fin);
                graphicsShape.DrawLine(Pens.Black, st, GetNewCustomPoint(st.PointX - 50, st.PointY));
                graphicsShape.DrawLine(Pens.Black, fin, GetNewCustomPoint(fin.PointX - 50, fin.PointY));
                graphicsShape.DrawString(text, drawFontBold, Brushes.Red, pCenter, sf);
                sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            }
        }
        private void CreateVertikalSizeComponentsForPack(double startCount, double finishCount, string text)
        {
            using (var pen = new Pen(Color.Green, 3))
            {
                Font drawFontBold = new Font("Tahoma", emSize: GetCurrentFontSize() / 1.3F);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint st = null;
                ShapePoint fin = null;
                Line ln = null;
                ShapePoint pCenter = null;
                st = GetNewCustomPoint(SelectedRect.X+ startCount,  SelectedRect.Y+SelectedRect.Height+60 );
                fin = GetNewCustomPoint(SelectedRect.X+ finishCount, SelectedRect.Y + SelectedRect.Height +60 );
                ln = GetNewLine(st, fin);
                pCenter = GetNewCustomPoint(SelectedRect.X + startCount+ln.Length/2, SelectedRect.Y + SelectedRect.Height+ 70);
                graphicsShape.DrawLine(pen, st, fin);
                graphicsShape.DrawLine(Pens.Black, st, GetNewCustomPoint(st.PointX , st.PointY- 60));
                graphicsShape.DrawLine(Pens.Black, fin, GetNewCustomPoint(fin.PointX , fin.PointY- 60));
                graphicsShape.DrawString(text, drawFontBold, Brushes.Red, pCenter, sf);
            }
        }
        #endregion
        #region AxisPacks       
        /// <summary>
        /// Creates the vertical bottom axis elements pack.
        /// </summary>
        /// <param name="dir">The dir.</param>
        /// <param name="factor">The factor.</param>
        /// <param name="leftFactor">The left factor.</param>
        /// <param name="rightFactor">The right factor.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private List<GraphicsPath> CreateVerticalBottomAxisElementsPack(string dir = "", double factor = 0, double leftFactor = 0.0, double rightFactor = 0.0, int count = 0, Guid? id = null)
        {
            Current = 6000;
            var list = new List<GraphicsPath>();
            var OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
            ShapePoint StartPoint;
            ShapePoint EndPoint;
            ShapePoint LeftTempPoint = null;
            ShapePoint RightTempPoint = null;
            ShapePoint CenterTempPoint = null;
            int counter = 0;
            if (leftFactor + rightFactor < 180)
            {
                switch (dir)
                {
                    case "Центр":
                        CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + factor, SelectedRect.Y + SelectedRect.Height);
                        LeftTempPoint = GetNewCustomPoint(SelectedRect.X - 3000, SelectedRect.Y + SelectedRect.Height);
                        RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 3000, SelectedRect.Y + SelectedRect.Height);
                        break;
                    case "Слева":
                        if (factor <= 0)
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            LeftTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - 2000);
                            RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 2000, SelectedRect.Y + SelectedRect.Height);
                            OneSector = Math.Round((CalculateAngle(LeftTempPoint, CenterTempPoint, RightTempPoint) - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        else
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + factor, SelectedRect.Y + SelectedRect.Height);
                            LeftTempPoint = GetNewCustomPoint(SelectedRect.X - 3000, SelectedRect.Y + SelectedRect.Height);
                            RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 3000, SelectedRect.Y + SelectedRect.Height);
                            OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        break;
                    case "Справа":
                        if (factor <= 0)
                        {

                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            LeftTempPoint = GetNewCustomPoint(SelectedRect.X - 2000, SelectedRect.Y + SelectedRect.Height);
                            RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 1000);
                            OneSector = Math.Round((CalculateAngle(LeftTempPoint, CenterTempPoint, RightTempPoint) - leftFactor - rightFactor) / (count + 1), 0);

                        }
                        else
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - factor, SelectedRect.Y + SelectedRect.Height);
                            LeftTempPoint = GetNewCustomPoint(SelectedRect.X - 1000, SelectedRect.Y + SelectedRect.Height);
                            RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        break;
                }

                #region DrawleftMainLine
                if (leftFactor > 0)
                {
                    CurvePoint.PointX = (LeftTempPoint.PointX - CenterTempPoint.PointX) * Math.Cos(leftFactor * Math.PI / 180) -
                                       (LeftTempPoint.PointY - CenterTempPoint.PointY) * Math.Sin(leftFactor * Math.PI / 180) + CenterTempPoint.PointX;
                    CurvePoint.PointY = (LeftTempPoint.PointX - CenterTempPoint.PointX) * Math.Sin(leftFactor * Math.PI / 180) +
                                        (LeftTempPoint.PointY - CenterTempPoint.PointY) * Math.Cos(leftFactor * Math.PI / 180) + CenterTempPoint.PointY;
                    LeftTempPoint.PointX = CurvePoint.PointX;
                    LeftTempPoint.PointY = CurvePoint.PointY;
                    graphicsShape.DrawLine(new Pen(Color.Green, 6) { DashStyle = DashStyle.DashDotDot }, LeftTempPoint, CenterTempPoint);
                }
                #endregion

                #region DrawRightMainLine
                if (rightFactor > 0)
                {
                    CurvePoint.PointX = (RightTempPoint.PointX - CenterTempPoint.PointX) * Math.Cos(-rightFactor * Math.PI / 180) -
                                       (RightTempPoint.PointY - CenterTempPoint.PointY) * Math.Sin(-rightFactor * Math.PI / 180) + CenterTempPoint.PointX;
                    CurvePoint.PointY = (RightTempPoint.PointX - CenterTempPoint.PointX) * Math.Sin(-rightFactor * Math.PI / 180) +
                                        (RightTempPoint.PointY - CenterTempPoint.PointY) * Math.Cos(-rightFactor * Math.PI / 180) + CenterTempPoint.PointY;
                    RightTempPoint.PointX = CurvePoint.PointX;
                    RightTempPoint.PointY = CurvePoint.PointY;
                    graphicsShape.DrawLine(new Pen(Color.Green, 6) { DashStyle = DashStyle.DashDotDot }, RightTempPoint, CenterTempPoint);
                }

                #endregion

                var path = GetShapeShprosBorders();
                int counter1 = 0;

                if (dir == "Слева")
                {
                    CenterTempPoint.PointY -= 1;
                    LeftTempPoint.PointY -= 1;
                    while (!path.IsVisible(CenterTempPoint))
                    {
                        CenterTempPoint.PointX += 1;
                        counter1 += 1;
                        if (path.IsVisible(CenterTempPoint)) { break; }
                    }
                    if (factor <= 0)
                    {
                        LeftTempPoint.PointX += counter1;
                        RightTempPoint.PointX += counter1;
                    }
                    else
                    {
                        CenterTempPoint.PointX += factor;
                        LeftTempPoint.PointX += counter1 + factor;
                        RightTempPoint.PointX += counter1 + factor;
                    }
                }


                else if (dir == "Справа")
                {
                    CenterTempPoint.PointY -= 1;
                    LeftTempPoint.PointY -= 1;
                    while (!path.IsVisible(CenterTempPoint))
                    {
                        CenterTempPoint.PointX -= 1;
                        counter1 -= 1;
                        if (path.IsVisible(CenterTempPoint)) { break; }
                    }
                    if (factor <= 0)
                    {
                        LeftTempPoint.PointX -= counter1;
                        RightTempPoint.PointX -= counter1;
                    }
                    else
                    {
                        CenterTempPoint.PointX -= factor;
                        LeftTempPoint.PointX -= counter1 - factor;
                        RightTempPoint.PointX -= counter1 - factor;
                    }
                }
                StartPoint = GetNewCustomPoint(CenterTempPoint.PointX, CenterTempPoint.PointY);
                EndPoint = GetNewCustomPoint(LeftTempPoint.PointX, LeftTempPoint.PointY);
                while (counter < count)
                {
                    CurvePoint.PointX = (EndPoint.PointX - StartPoint.PointX) * Math.Cos(OneSector * Math.PI / 180) -
                                        (EndPoint.PointY - StartPoint.PointY) * Math.Sin(OneSector * Math.PI / 180) +
                                        StartPoint.PointX;
                    CurvePoint.PointY = (EndPoint.PointX - StartPoint.PointX) * Math.Sin(OneSector * Math.PI / 180) +
                                        (EndPoint.PointY - StartPoint.PointY) * Math.Cos(OneSector * Math.PI / 180) +
                                        StartPoint.PointY;
                    EndPoint.PointX = CurvePoint.PointX;
                    EndPoint.PointY = CurvePoint.PointY;
                    EndPoint = SetCurrentLineLength(StartPoint, EndPoint, Current);

                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint = SetCurrentLineLength(StartPoint, EndPoint, Current);
                        Current -= 5;
                        if (GetShapeShprosBorders().IsVisible(EndPoint)) { Current = 6000; break; }
                    }
                    var item = new GraphicsPath();
                    item.AddLine(StartPoint, EndPoint);
                    VerticalShprosCounter += 1;

                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    RetainerCounter += 2;
                    list.Add(item);
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(GetRoundPoint(StartPoint), GetRoundPoint(EndPoint), $"В{VerticalShprosCounter}", true, false, true, id: id));
                    ShprossLineCollection = ShprossLineCollection.Distinct().ToList();
                    counter++;
                }
                var l = TotalShprosLength;
            }
            else
            {
                XtraMessageBox.Show("Проверьте значение отступов", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (TempShprossesListElements.Count > 0)
                {
                    TempShprossesListElements.RemoveAt(TempShprossesListElements.Count - 1);
                }
                RemoveLastItemFromObservableCollection();
            }
            return list;
        }
        /// <summary>
        /// Creates the vertical up axis elements pack.
        /// </summary>
        /// <param name="dir">The dir.</param>
        /// <param name="factor">The factor.</param>
        /// <param name="leftFactor">The left factor.</param>
        /// <param name="rightFactor">The right factor.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private List<GraphicsPath> CreateVerticalUpAxisElementsPack(string dir = "", double factor = 0, double leftFactor = 0.0, double rightFactor = 0.0, int count = 0, Guid? id = null)
        {
            Current = 6000;
            var list = new List<GraphicsPath>();
            var OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
            ShapePoint StartPoint;
            ShapePoint EndPoint;
            ShapePoint LeftTempPoint = null;
            ShapePoint RightTempPoint = null;
            ShapePoint CenterTempPoint = null;
            int counter = 0;
            if (leftFactor + rightFactor < 180)
            {
                switch (dir)
                {
                    case "Центр":
                        CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + factor, SelectedRect.Y);
                        LeftTempPoint = GetNewCustomPoint(SelectedRect.X - 3000, SelectedRect.Y);
                        RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 3000, SelectedRect.Y);
                        break;
                    case "Слева":
                        if (factor <= 0)
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                            LeftTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height + 2000);
                            RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 2000, SelectedRect.Y);
                            OneSector = Math.Round((CalculateAngle(LeftTempPoint, CenterTempPoint, RightTempPoint) - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        else
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + factor, SelectedRect.Y);
                            LeftTempPoint = GetNewCustomPoint(SelectedRect.X - 2000, SelectedRect.Y);
                            RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 2000, SelectedRect.Y);
                            OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        break;
                    case "Справа":
                        if (factor <= 0)
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            LeftTempPoint = GetNewCustomPoint(SelectedRect.X - 2000, SelectedRect.Y);
                            RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height + 2000);
                            OneSector = Math.Round((CalculateAngle(LeftTempPoint, CenterTempPoint, RightTempPoint) - leftFactor - rightFactor) / (count + 1), 0);

                        }
                        else
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - factor, SelectedRect.Y);
                            LeftTempPoint = GetNewCustomPoint(SelectedRect.X - 1000, SelectedRect.Y);
                            RightTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        break;
                }

                #region DrawleftMainLine
                if (leftFactor > 0)
                {
                    CurvePoint.PointX = (LeftTempPoint.PointX - CenterTempPoint.PointX) * Math.Cos(-leftFactor * Math.PI / 180) -
                                        (LeftTempPoint.PointY - CenterTempPoint.PointY) * Math.Sin(-leftFactor * Math.PI / 180) + CenterTempPoint.PointX;
                    CurvePoint.PointY = (LeftTempPoint.PointX - CenterTempPoint.PointX) * Math.Sin(-leftFactor * Math.PI / 180) +
                                        (LeftTempPoint.PointY - CenterTempPoint.PointY) * Math.Cos(-leftFactor * Math.PI / 180) + CenterTempPoint.PointY;
                    LeftTempPoint.PointX = CurvePoint.PointX;
                    LeftTempPoint.PointY = CurvePoint.PointY;
                    graphicsShape.DrawLine(new Pen(Color.Green, 6) { DashStyle = DashStyle.DashDotDot }, LeftTempPoint, CenterTempPoint);
                }
                #endregion
                #region DrawRightMainLine
                if (rightFactor > 0)
                {
                    CurvePoint.PointX = (RightTempPoint.PointX - CenterTempPoint.PointX) * Math.Cos(rightFactor * Math.PI / 180) -
                                       (RightTempPoint.PointY - CenterTempPoint.PointY) * Math.Sin(rightFactor * Math.PI / 180) + CenterTempPoint.PointX;
                    CurvePoint.PointY = (RightTempPoint.PointX - CenterTempPoint.PointX) * Math.Sin(rightFactor * Math.PI / 180) +
                                        (RightTempPoint.PointY - CenterTempPoint.PointY) * Math.Cos(rightFactor * Math.PI / 180) + CenterTempPoint.PointY;
                    RightTempPoint.PointX = CurvePoint.PointX;
                    RightTempPoint.PointY = CurvePoint.PointY;
                    graphicsShape.DrawLine(new Pen(Color.Green, 6) { DashStyle = DashStyle.DashDotDot }, RightTempPoint, CenterTempPoint);
                }
                #endregion

                var path = GetShapeShprosBorders();
                int counter1 = 0;
                if (dir == "Слева")
                {
                    CenterTempPoint.PointY += 1;
                    LeftTempPoint.PointY += 1;
                    while (!path.IsVisible(CenterTempPoint))
                    {
                        CenterTempPoint.PointX += 1;
                        counter1 += 1;
                        if (path.IsVisible(CenterTempPoint)) { break; }
                    }
                    if (factor <= 0)
                    {
                        LeftTempPoint.PointX += counter1;
                        RightTempPoint.PointX += counter1;
                    }
                    else
                    {
                        CenterTempPoint.PointX += factor;
                        LeftTempPoint.PointX += counter1 + factor;
                        RightTempPoint.PointX += counter1 + factor;
                    }
                }
                else if (dir == "Справа")
                {
                    CenterTempPoint.PointY += 1;
                    LeftTempPoint.PointY += 1;
                    while (!path.IsVisible(CenterTempPoint))
                    {
                        CenterTempPoint.PointX -= 1;
                        counter1 -= 1;
                        if (path.IsVisible(CenterTempPoint)) { break; }
                    }
                    if (factor <= 0)
                    {
                        LeftTempPoint.PointX -= counter1;
                        RightTempPoint.PointX -= counter1;
                    }
                    else
                    {
                        CenterTempPoint.PointX -= factor;
                        LeftTempPoint.PointX -= counter1 - factor;
                        RightTempPoint.PointX -= counter1 - factor;
                    }
                }
                StartPoint = GetNewCustomPoint(CenterTempPoint.PointX, CenterTempPoint.PointY);
                EndPoint = GetNewCustomPoint(LeftTempPoint.PointX, LeftTempPoint.PointY);
                while (counter < count)
                {
                    CurvePoint.PointX = (EndPoint.PointX - StartPoint.PointX) * Math.Cos(-OneSector * Math.PI / 180) -
                                        (EndPoint.PointY - StartPoint.PointY) * Math.Sin(-OneSector * Math.PI / 180) +
                                        StartPoint.PointX;
                    CurvePoint.PointY = (EndPoint.PointX - StartPoint.PointX) * Math.Sin(-OneSector * Math.PI / 180) +
                                        (EndPoint.PointY - StartPoint.PointY) * Math.Cos(-OneSector * Math.PI / 180) +
                                        StartPoint.PointY;
                    EndPoint.PointX = CurvePoint.PointX;
                    EndPoint.PointY = CurvePoint.PointY;
                    EndPoint = SetCurrentLineLength(StartPoint, EndPoint, Current);

                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint = SetCurrentLineLength(StartPoint, EndPoint, Current);
                        Current -= 5;
                        if (GetShapeShprosBorders().IsVisible(EndPoint)) { Current = 6000; break; }
                    }
                    var item = new GraphicsPath();
                    VerticalShprosCounter += 1;
                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    item.AddLine(StartPoint, EndPoint);
                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    RetainerCounter += 2;
                    list.Add(item);
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(GetRoundPoint(StartPoint), GetRoundPoint(EndPoint), $"В{VerticalShprosCounter}", true, false, true, id: id));
                    ShprossLineCollection = ShprossLineCollection.Distinct().ToList();
                    counter++;
                }
                var l = TotalShprosLength;
            }
            else
            {
                XtraMessageBox.Show("Проверьте значение отступов", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (TempShprossesListElements.Count > 0)
                {
                    TempShprossesListElements.RemoveAt(TempShprossesListElements.Count - 1);
                }
                RemoveLastItemFromObservableCollection();
            }
            return list;
        }
        /// <summary>
        /// Creates the horizontal left axis elements pack.
        /// </summary>
        /// <param name="dir">The dir.</param>
        /// <param name="factor">The factor.</param>
        /// <param name="leftFactor">The left factor.</param>
        /// <param name="rightFactor">The right factor.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private List<GraphicsPath> CreateHorizontalLeftAxisElementsPack(string dir = "", double factor = 0, double leftFactor = 0.0, double rightFactor = 0.0, int count = 0, Guid? id = null)
        {
            Current = 6000;
            var list = new List<GraphicsPath>();
            var OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
            ShapePoint StartPoint;
            ShapePoint EndPoint;
            ShapePoint UpTempPoint = null;
            ShapePoint BottomTempPoint = null;
            ShapePoint CenterTempPoint = null;
            int counter = 0;
            if (leftFactor + rightFactor < 180)
            {
                switch (dir)
                {
                    case "Центр":
                        CenterTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height / 2 + factor);
                        UpTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - 2000);
                        BottomTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height + 2000);
                        break;
                    case "Сверху":
                        if (factor <= 0)
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                            UpTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 2000, SelectedRect.Y);
                            BottomTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height + 2000);
                            OneSector = Math.Round((CalculateAngle(UpTempPoint, CenterTempPoint, BottomTempPoint) - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        else
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + factor);
                            UpTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - 2000);
                            BottomTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height + 2000);
                            OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        break;
                    case "Снизу":
                        if (factor <= 0)
                        {

                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            UpTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - 2000);
                            BottomTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 2000, SelectedRect.Y + SelectedRect.Height);
                            OneSector = Math.Round((CalculateAngle(UpTempPoint, CenterTempPoint, BottomTempPoint) - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        else
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height - factor);
                            UpTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - 2000);
                            BottomTempPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height + 2000);
                            OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        break;
                }

                #region DrawleftMainLine
                if (leftFactor > 0)
                {
                    CurvePoint.PointX = (UpTempPoint.PointX - CenterTempPoint.PointX) * Math.Cos(leftFactor * Math.PI / 180) -
                                       (UpTempPoint.PointY - CenterTempPoint.PointY) * Math.Sin(leftFactor * Math.PI / 180) + CenterTempPoint.PointX;
                    CurvePoint.PointY = (UpTempPoint.PointX - CenterTempPoint.PointX) * Math.Sin(leftFactor * Math.PI / 180) +
                                        (UpTempPoint.PointY - CenterTempPoint.PointY) * Math.Cos(leftFactor * Math.PI / 180) + CenterTempPoint.PointY;
                    UpTempPoint.PointX = CurvePoint.PointX;
                    UpTempPoint.PointY = CurvePoint.PointY;
                    graphicsShape.DrawLine(new Pen(Color.Green, 6) { DashStyle = DashStyle.DashDotDot }, UpTempPoint, CenterTempPoint);
                }
                #endregion
                #region DrawRightMainLine
                if (rightFactor > 0)
                {
                    CurvePoint.PointX = (BottomTempPoint.PointX - CenterTempPoint.PointX) * Math.Cos(-rightFactor * Math.PI / 180) -
                                        (BottomTempPoint.PointY - CenterTempPoint.PointY) * Math.Sin(-rightFactor * Math.PI / 180) + CenterTempPoint.PointX;
                    CurvePoint.PointY = (BottomTempPoint.PointX - CenterTempPoint.PointX) * Math.Sin(-rightFactor * Math.PI / 180) +
                                        (BottomTempPoint.PointY - CenterTempPoint.PointY) * Math.Cos(-rightFactor * Math.PI / 180) + CenterTempPoint.PointY;
                    BottomTempPoint.PointX = CurvePoint.PointX;
                    BottomTempPoint.PointY = CurvePoint.PointY;
                    graphicsShape.DrawLine(new Pen(Color.Green, 6) { DashStyle = DashStyle.DashDotDot }, BottomTempPoint, CenterTempPoint);
                }

                #endregion

                var path = GetShapeShprosBorders();
                int counter1 = 0;

                if (dir == "Сверху")
                {
                    CenterTempPoint.PointX += 1;
                    UpTempPoint.PointX += 1;
                    while (!path.IsVisible(CenterTempPoint))
                    {
                        CenterTempPoint.PointY += 1;
                        counter1 += 1;
                        if (path.IsVisible(CenterTempPoint)) { break; }
                    }
                    if (factor <= 0)
                    {
                        UpTempPoint.PointY += counter1;
                        BottomTempPoint.PointY += counter1;
                    }
                    else
                    {
                        CenterTempPoint.PointY += factor;
                        UpTempPoint.PointY += counter1 + factor;
                        BottomTempPoint.PointY += counter1 + factor;
                    }
                }
                else if (dir == "Снизу")
                {
                    CenterTempPoint.PointX += 1;
                    UpTempPoint.PointX += 1;
                    while (!path.IsVisible(CenterTempPoint))
                    {
                        CenterTempPoint.PointY -= 1;
                        counter1 -= 1;
                        if (path.IsVisible(CenterTempPoint)) { break; }
                    }
                    if (factor <= 0)
                    {
                        UpTempPoint.PointY -= counter1;
                        BottomTempPoint.PointY -= counter1;
                    }
                    else
                    {
                        CenterTempPoint.PointY -= factor;
                        UpTempPoint.PointY -= counter1 + factor;
                        BottomTempPoint.PointY -= counter1 + factor;
                    }
                }
                StartPoint = GetNewCustomPoint(CenterTempPoint.PointX, CenterTempPoint.PointY);
                EndPoint = GetNewCustomPoint(UpTempPoint.PointX, UpTempPoint.PointY);
                while (counter < count)
                {
                    CurvePoint.PointX = (EndPoint.PointX - StartPoint.PointX) * Math.Cos(OneSector * Math.PI / 180) -
                                        (EndPoint.PointY - StartPoint.PointY) * Math.Sin(OneSector * Math.PI / 180) +
                                        StartPoint.PointX;
                    CurvePoint.PointY = (EndPoint.PointX - StartPoint.PointX) * Math.Sin(OneSector * Math.PI / 180) +
                                        (EndPoint.PointY - StartPoint.PointY) * Math.Cos(OneSector * Math.PI / 180) +
                                        StartPoint.PointY;
                    EndPoint.PointX = CurvePoint.PointX;
                    EndPoint.PointY = CurvePoint.PointY;
                    EndPoint = SetCurrentLineLength(StartPoint, EndPoint, Current);

                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint = SetCurrentLineLength(StartPoint, EndPoint, Current);
                        Current -= 5;
                        if (GetShapeShprosBorders().IsVisible(EndPoint)) { Current = 6000; break; }
                    }
                    var item = new GraphicsPath();
                    item.AddLine(StartPoint, EndPoint);
                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    HorisontalShprosCounter += 1;
                    RetainerCounter += 2;
                    list.Add(item);
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(GetRoundPoint(StartPoint), GetRoundPoint(EndPoint), $"В{HorisontalShprosCounter}", false, true, true, id: id));
                    ShprossLineCollection = ShprossLineCollection.Distinct().ToList();
                    counter++;
                }
                var l = TotalShprosLength;
            }
            else
            {
                XtraMessageBox.Show("Проверьте значение отступов", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (TempShprossesListElements.Count > 0)
                {
                    TempShprossesListElements.RemoveAt(TempShprossesListElements.Count - 1);
                }
                RemoveLastItemFromObservableCollection();
            }
            return list;
        }
        /// <summary>
        /// Creates the horizontal right axis elements pack.
        /// </summary>
        /// <param name="dir">The dir.</param>
        /// <param name="factor">The factor.</param>
        /// <param name="leftFactor">The left factor.</param>
        /// <param name="rightFactor">The right factor.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private List<GraphicsPath> CreateHorizontalRightAxisElementsPack(string dir = "", double factor = 0, double leftFactor = 0.0, double rightFactor = 0.0, int count = 0, Guid? id = null)
        {
            Current = 6000;
            var list = new List<GraphicsPath>();
            var OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
            ShapePoint StartPoint;
            ShapePoint EndPoint;
            ShapePoint UpTempPoint = null;
            ShapePoint BottomTempPoint = null;
            ShapePoint CenterTempPoint = null;
            if (leftFactor + rightFactor < 180)
            {
                int counter = 0;
                switch (dir)
                {
                    case "Центр":
                        CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height / 2 + factor);
                        UpTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 2000);
                        BottomTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height + 2000);
                        break;
                    case "Сверху":
                        if (factor <= 0)
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            UpTempPoint = GetNewCustomPoint(SelectedRect.X - 2000, SelectedRect.Y);
                            BottomTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height + 2000);
                            OneSector = Math.Round((CalculateAngle(UpTempPoint, CenterTempPoint, BottomTempPoint) - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        else
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + factor);
                            UpTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 2000);
                            BottomTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height + 2000);
                            OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        break;
                    case "Снизу":
                        if (factor <= 0)
                        {

                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            UpTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 2000);
                            BottomTempPoint = GetNewCustomPoint(SelectedRect.X - 2000, SelectedRect.Y + SelectedRect.Height);
                            OneSector = Math.Round((CalculateAngle(UpTempPoint, CenterTempPoint, BottomTempPoint) - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        else
                        {
                            CenterTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height - factor);
                            UpTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 2000);
                            BottomTempPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height + 2000);
                            OneSector = Math.Round((180.0 - leftFactor - rightFactor) / (count + 1), 0);
                        }
                        break;
                }

                #region DrawleftMainLine
                if (leftFactor > 0)
                {
                    CurvePoint.PointX = (UpTempPoint.PointX - CenterTempPoint.PointX) * Math.Cos(-leftFactor * Math.PI / 180) -
                                        (UpTempPoint.PointY - CenterTempPoint.PointY) * Math.Sin(-leftFactor * Math.PI / 180) + CenterTempPoint.PointX;
                    CurvePoint.PointY = (UpTempPoint.PointX - CenterTempPoint.PointX) * Math.Sin(-leftFactor * Math.PI / 180) +
                                        (UpTempPoint.PointY - CenterTempPoint.PointY) * Math.Cos(-leftFactor * Math.PI / 180) + CenterTempPoint.PointY;
                    UpTempPoint.PointX = CurvePoint.PointX;
                    UpTempPoint.PointY = CurvePoint.PointY;
                    graphicsShape.DrawLine(new Pen(Color.Green, 6) { DashStyle = DashStyle.DashDotDot }, UpTempPoint, CenterTempPoint);
                }
                #endregion
                #region DrawRightMainLine
                if (rightFactor > 0)
                {
                    CurvePoint.PointX = (BottomTempPoint.PointX - CenterTempPoint.PointX) * Math.Cos(rightFactor * Math.PI / 180) -
                                        (BottomTempPoint.PointY - CenterTempPoint.PointY) * Math.Sin(rightFactor * Math.PI / 180) + CenterTempPoint.PointX;
                    CurvePoint.PointY = (BottomTempPoint.PointX - CenterTempPoint.PointX) * Math.Sin(rightFactor * Math.PI / 180) +
                                        (BottomTempPoint.PointY - CenterTempPoint.PointY) * Math.Cos(rightFactor * Math.PI / 180) + CenterTempPoint.PointY;
                    BottomTempPoint.PointX = CurvePoint.PointX;
                    BottomTempPoint.PointY = CurvePoint.PointY;
                    graphicsShape.DrawLine(new Pen(Color.Green, 6) { DashStyle = DashStyle.DashDotDot }, BottomTempPoint, CenterTempPoint);
                }

                #endregion

                var path = GetShapeShprosBorders();
                int counter1 = 0;

                if (dir == "Сверху")
                {
                    CenterTempPoint.PointX -= 1;
                    UpTempPoint.PointX -= 1;
                    while (!path.IsVisible(CenterTempPoint))
                    {
                        CenterTempPoint.PointY += 1;
                        counter1 += 1;
                        if (path.IsVisible(CenterTempPoint)) { break; }
                    }
                    if (factor <= 0)
                    {
                        UpTempPoint.PointY += counter1;
                        BottomTempPoint.PointY += counter1;
                    }
                    else
                    {
                        CenterTempPoint.PointY += factor;
                        UpTempPoint.PointY += counter1 + factor;
                        BottomTempPoint.PointY += counter1 + factor;
                    }
                }
                else if (dir == "Снизу")
                {
                    CenterTempPoint.PointX -= 1;
                    UpTempPoint.PointX -= 1;
                    while (!path.IsVisible(CenterTempPoint))
                    {
                        CenterTempPoint.PointY -= 1;
                        counter1 -= 1;
                        if (path.IsVisible(CenterTempPoint)) { break; }
                    }
                    if (factor <= 0)
                    {
                        UpTempPoint.PointY -= counter1;
                        BottomTempPoint.PointY -= counter1;
                    }
                    else
                    {
                        CenterTempPoint.PointY -= factor;
                        UpTempPoint.PointY -= counter1 + factor;
                        BottomTempPoint.PointY -= counter1 + factor;
                    }
                }
                StartPoint = GetNewCustomPoint(CenterTempPoint.PointX, CenterTempPoint.PointY);
                EndPoint = GetNewCustomPoint(UpTempPoint.PointX, UpTempPoint.PointY);
                while (counter < count)
                {
                    CurvePoint.PointX = (EndPoint.PointX - StartPoint.PointX) * Math.Cos(-OneSector * Math.PI / 180) -
                                        (EndPoint.PointY - StartPoint.PointY) * Math.Sin(-OneSector * Math.PI / 180) +
                                        StartPoint.PointX;
                    CurvePoint.PointY = (EndPoint.PointX - StartPoint.PointX) * Math.Sin(-OneSector * Math.PI / 180) +
                                        (EndPoint.PointY - StartPoint.PointY) * Math.Cos(-OneSector * Math.PI / 180) +
                                        StartPoint.PointY;
                    EndPoint.PointX = CurvePoint.PointX;
                    EndPoint.PointY = CurvePoint.PointY;
                    EndPoint = SetCurrentLineLength(StartPoint, EndPoint, Current);

                    while (!GetShapeShprosBorders().IsVisible(EndPoint))
                    {
                        EndPoint = SetCurrentLineLength(StartPoint, EndPoint, Current);
                        Current -= 5;
                        if (GetShapeShprosBorders().IsVisible(EndPoint)) { Current = 6000; break; }
                    }
                    var item = new GraphicsPath();
                    item.AddLine(StartPoint, EndPoint);
                    TotalShprosLength += GetNewLine(StartPoint, EndPoint).Length;
                    HorisontalShprosCounter += 1;
                    RetainerCounter += 2;
                    list.Add(item);
                    ShprossLineCollection.Add(GetNewLineWithFullParameters(GetRoundPoint(StartPoint), GetRoundPoint(EndPoint), $"В{HorisontalShprosCounter}", false, true, true, id: id));
                    ShprossLineCollection = ShprossLineCollection.Distinct().ToList();
                    counter++;
                }
                var l = TotalShprosLength;
            }
            else
            {
                XtraMessageBox.Show("Проверьте значение отступов", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (TempShprossesListElements.Count > 0)
                {
                    TempShprossesListElements.RemoveAt(TempShprossesListElements.Count - 1);
                }
                RemoveLastItemFromObservableCollection();
            }
            return list;
        }
        #endregion

        #region AxisArcPacks
        private double LeftBottomAngle { get; set; }
        private double RightBottomAngle { get; set; }
        private List<GraphicsPath> CreateBottomArcElementPack(string dir = "", double leftFactor = 0.0, double rightFactor = 0.0, double axisFactor = 0.0, int count = 0, Guid? id = null)
        {
            LeftBottomAngle = leftFactor;
            RightBottomAngle = rightFactor;
            var list = new List<GraphicsPath>();
            ShapePoint LeftPoint = null;
            ShapePoint RightPoint = null;
            ShapePoint CenterPoint = null;
            var tempLength = 0.0;
            var TotalLength = 0.0;

            int counter = 0;
            switch (dir)
            {
                case "Слева":
                    if (axisFactor != 0)
                    {
                        if (axisFactor > 0)
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X - 1 + axisFactor, SelectedRect.Y + SelectedRect.Height);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + axisFactor, SelectedRect.Y + SelectedRect.Height);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + 1 + axisFactor, SelectedRect.Y + SelectedRect.Height);
                            tempLength = 0.0;
                            TotalLength = 0.0;
                            tempLength = SelectedRect.Width - axisFactor;
                            TotalLength = (axisFactor <= SelectedRect.Width / 2) ? tempLength : axisFactor;
                        }
                        else
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X + axisFactor, SelectedRect.Y + SelectedRect.Height);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + axisFactor, SelectedRect.Y + SelectedRect.Height);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + axisFactor, SelectedRect.Y + SelectedRect.Height);
                            TotalLength = SelectedRect.Width;
                        }
                    }
                    else
                    {
                        LeftPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                        RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                        TotalLength = SelectedRect.Width;
                    }

                    break;
                case "Центр":
                    LeftPoint = GetNewCustomPoint(SelectedRect.X + axisFactor, SelectedRect.Y + SelectedRect.Height);
                    CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + axisFactor, SelectedRect.Y + SelectedRect.Height);
                    RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + axisFactor, SelectedRect.Y + SelectedRect.Height);
                    if (axisFactor != 0)
                    {
                        tempLength = 0.0;
                        TotalLength = 0.0;
                        tempLength = SelectedRect.Width / 2 + axisFactor;
                        TotalLength = (axisFactor >= SelectedRect.Width / 2) ? SelectedRect.Width / 2 : tempLength;
                    }
                    else { TotalLength = SelectedRect.Width / 2; }

                    break;
                case "Справа":
                    if (axisFactor != 0)
                    {
                        if (axisFactor > 0)
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X - 500, SelectedRect.Y + SelectedRect.Height);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - axisFactor, SelectedRect.Y + SelectedRect.Height);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 500, SelectedRect.Y + SelectedRect.Height);
                            tempLength = 0.0;
                            TotalLength = 0.0;
                            tempLength = SelectedRect.Width - axisFactor;
                            TotalLength = (axisFactor <= SelectedRect.Width / 2) ? tempLength : axisFactor;
                        }
                        else
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X - 500, SelectedRect.Y + SelectedRect.Height);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 500);
                        }
                    }
                    else
                    {
                        LeftPoint = GetNewCustomPoint(SelectedRect.X - 500, SelectedRect.Y + SelectedRect.Height);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                        RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 500);
                        TotalLength = SelectedRect.Width;
                    }
                    break;

                default:
                    break;
            }

            if (leftFactor + rightFactor < 180)
            {


                #region DrawleftMainLine
                if (leftFactor >= 0)
                {
                    Current = 6000;
                    CurvePoint.PointX = (LeftPoint.PointX - CenterPoint.PointX) * Math.Cos(leftFactor * Math.PI / 180) -
                                        (LeftPoint.PointY - CenterPoint.PointY) * Math.Sin(leftFactor * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (LeftPoint.PointX - CenterPoint.PointX) * Math.Sin(leftFactor * Math.PI / 180) +
                                        (LeftPoint.PointY - CenterPoint.PointY) * Math.Cos(leftFactor * Math.PI / 180) + CenterPoint.PointY;
                    LeftPoint.PointX = CurvePoint.PointX;
                    LeftPoint.PointY = CurvePoint.PointY;
                }
                graphicsShape.DrawLine(new Pen(Color.Green, 1) { DashStyle = DashStyle.DashDotDot }, LeftPoint, CenterPoint);
                #endregion
                #region DrawRightMainLine
                if (rightFactor >= 0)
                {
                    Current = 6000;
                    CurvePoint.PointX = (RightPoint.PointX - CenterPoint.PointX) * Math.Cos(-rightFactor * Math.PI / 180) -
                                       (RightPoint.PointY - CenterPoint.PointY) * Math.Sin(-rightFactor * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (RightPoint.PointX - CenterPoint.PointX) * Math.Sin(-rightFactor * Math.PI / 180) +
                                        (RightPoint.PointY - CenterPoint.PointY) * Math.Cos(-rightFactor * Math.PI / 180) + CenterPoint.PointY;
                    RightPoint.PointX = CurvePoint.PointX;
                    RightPoint.PointY = CurvePoint.PointY;
                }
                graphicsShape.DrawLine(new Pen(Color.Green, 1) { DashStyle = DashStyle.DashDotDot }, RightPoint, CenterPoint);
                #endregion
            }
            else
            {
                XtraMessageBox.Show("Значения отступов за пределами допустимых значений",
             "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var LeftLengthValue = GetNewLine(LeftPoint, CenterPoint).Length;
            var RightLengthValue = GetNewLine(RightPoint, CenterPoint).Length;
            var mainLength = (RightLengthValue >= LeftLengthValue) ? RightLengthValue : LeftLengthValue;
            var OneSide = (TotalLength) / (count + 1);
            var part = OneSide;
            while (counter < count)
            {
                var path = CreateBottomArcElement(dir, OneSide, axisFactor, id: id.Value);
                list.Add(path);
                OneSide += part;
                counter++;
            }

            return list;
        }
        private List<GraphicsPath> CreateUpArcElementPack(string dir = "", double leftFactor = 0.0, double rightFactor = 0.0, double axisFactor = 0.0, int count = 0, Guid? id = null)
        {
            LeftBottomAngle = leftFactor;
            RightBottomAngle = rightFactor;
            var list = new List<GraphicsPath>();
            ShapePoint LeftPoint = null;
            ShapePoint RightPoint = null;
            ShapePoint CenterPoint = null;
            var tempLength = 0.0;
            var TotalLength = 0.0;

            int counter = 0;
            switch (dir)
            {
                case "Слева":
                    if (axisFactor != 0)
                    {
                        if (axisFactor > 0)
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X - SelectedRect.Width / 2, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + axisFactor, SelectedRect.Y);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + axisFactor, SelectedRect.Y);
                            tempLength = 0.0;
                            TotalLength = 0.0;
                            tempLength = SelectedRect.Width - axisFactor;
                            TotalLength = (axisFactor <= SelectedRect.Width / 2) ? tempLength : axisFactor;
                        }
                        else
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X + axisFactor, SelectedRect.Y + SelectedRect.Height);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + axisFactor, SelectedRect.Y + SelectedRect.Height);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + axisFactor, SelectedRect.Y + SelectedRect.Height);
                            TotalLength = SelectedRect.Width;
                        }
                    }
                    else
                    {
                        LeftPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height + 500);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                        RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 500, SelectedRect.Y);
                        TotalLength = SelectedRect.Width;
                    }

                    break;
                case "Центр":
                    LeftPoint = GetNewCustomPoint(SelectedRect.X + axisFactor, SelectedRect.Y);
                    CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width / 2 + axisFactor, SelectedRect.Y);
                    RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + axisFactor, SelectedRect.Y);
                    if (axisFactor != 0)
                    {
                        tempLength = 0.0;
                        TotalLength = 0.0;
                        tempLength = SelectedRect.Width / 2 + axisFactor;
                        TotalLength = (axisFactor >= SelectedRect.Width / 2) ? SelectedRect.Width / 2 : tempLength;
                    }
                    else { TotalLength = SelectedRect.Width / 2; }

                    break;
                case "Справа":
                    if (axisFactor != 0)
                    {
                        if (axisFactor > 0)
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X - axisFactor, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width - axisFactor, SelectedRect.Y);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width + 3000, SelectedRect.Y);
                            tempLength = 0.0;
                            TotalLength = 0.0;
                            tempLength = SelectedRect.Width - axisFactor;
                            TotalLength = (axisFactor <= SelectedRect.Width / 2) ? tempLength : axisFactor;
                        }
                        else
                        {
                            LeftPoint = GetNewCustomPoint(SelectedRect.X - 500, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height + 500);
                            TotalLength = SelectedRect.Width;
                        }
                    }
                    else
                    {
                        LeftPoint = GetNewCustomPoint(SelectedRect.X - 500, SelectedRect.Y);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                        RightPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height + 500);
                        TotalLength = SelectedRect.Width;
                    }
                    break;

                default:
                    break;
            }

            if (leftFactor + rightFactor < 180)
            {


                #region DrawleftMainLine
                if (leftFactor >= 0)
                {
                    Current = 6000;
                    CurvePoint.PointX = (LeftPoint.PointX - CenterPoint.PointX) * Math.Cos(-leftFactor * Math.PI / 180) -
                                        (LeftPoint.PointY - CenterPoint.PointY) * Math.Sin(-leftFactor * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (LeftPoint.PointX - CenterPoint.PointX) * Math.Sin(-leftFactor * Math.PI / 180) +
                                        (LeftPoint.PointY - CenterPoint.PointY) * Math.Cos(-leftFactor * Math.PI / 180) + CenterPoint.PointY;
                    LeftPoint.PointX = CurvePoint.PointX;
                    LeftPoint.PointY = CurvePoint.PointY;
                }
                graphicsShape.DrawLine(new Pen(Color.Green, 1) { DashStyle = DashStyle.DashDotDot }, LeftPoint, CenterPoint);
                #endregion
                #region DrawRightMainLine
                if (rightFactor >= 0)
                {
                    Current = 6000;
                    CurvePoint.PointX = (RightPoint.PointX - CenterPoint.PointX) * Math.Cos(rightFactor * Math.PI / 180) -
                                        (RightPoint.PointY - CenterPoint.PointY) * Math.Sin(rightFactor * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (RightPoint.PointX - CenterPoint.PointX) * Math.Sin(rightFactor * Math.PI / 180) +
                                        (RightPoint.PointY - CenterPoint.PointY) * Math.Cos(rightFactor * Math.PI / 180) + CenterPoint.PointY;
                    RightPoint.PointX = CurvePoint.PointX;
                    RightPoint.PointY = CurvePoint.PointY;
                }
                graphicsShape.DrawLine(new Pen(Color.Green, 1) { DashStyle = DashStyle.DashDotDot }, RightPoint, CenterPoint);
                #endregion
            }
            else
            {
                XtraMessageBox.Show("Значения отступов за пределами допустимых значений",
             "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var LeftLengthValue = GetNewLine(LeftPoint, CenterPoint).Length;
            var RightLengthValue = GetNewLine(RightPoint, CenterPoint).Length;
            var mainLength = (RightLengthValue >= LeftLengthValue) ? RightLengthValue : LeftLengthValue;
            var OneSide = (TotalLength) / (count + 1);
            var part = OneSide;
            while (counter < count)
            {
                var path = CreateUpArcElement(dir, OneSide, axisFactor, id: id.Value);
                list.Add(path);
                OneSide += part;
                counter++;
            }

            return list;
        }
        private List<GraphicsPath> CreateLeftArcElementPack(string dir = "", double leftFactor = 0.0, double rightFactor = 0.0, double axisFactor = 0.0, int count = 0, Guid? id = null)
        {
            LeftBottomAngle = leftFactor;
            RightBottomAngle = rightFactor;
            var list = new List<GraphicsPath>();
            ShapePoint UpPoint = null;
            ShapePoint DowntPoint = null;
            ShapePoint CenterPoint = null;
            var tempLength = 0.0;
            var TotalLength = 0.0;

            int counter = 0;
            switch (dir)
            {
                case "Сверху":
                    if (axisFactor != 0)
                    {
                        if (axisFactor > 0)
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - 1);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + axisFactor);
                            DowntPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            tempLength = 0.0;
                            TotalLength = 0.0;
                            tempLength = SelectedRect.Width - axisFactor;
                            TotalLength = (axisFactor <= SelectedRect.Width / 2) ? tempLength : axisFactor;
                        }
                        else
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                            DowntPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            TotalLength = SelectedRect.Height;
                        }
                    }
                    else
                    {
                        UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                        DowntPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                        TotalLength = SelectedRect.Height;
                    }

                    break;
                case "Центр":
                    UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y - axisFactor);
                    CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height / 2 + axisFactor);
                    DowntPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height + 500);
                    if (axisFactor != 0)
                    {
                        tempLength = 0.0;
                        TotalLength = 0.0;
                        tempLength = SelectedRect.Height / 2 + axisFactor;
                        TotalLength = (axisFactor >= SelectedRect.Height / 2) ? SelectedRect.Height / 2 : tempLength;
                    }
                    else { TotalLength = SelectedRect.Height / 2; }

                    break;
                case "Снизу":
                    if (axisFactor != 0)
                    {
                        if (axisFactor > 0)
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height - axisFactor);
                            DowntPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            tempLength = 0.0;
                            TotalLength = 0.0;
                            tempLength = SelectedRect.Height - axisFactor;
                            TotalLength = (axisFactor <= SelectedRect.Width / 2) ? tempLength : axisFactor;
                        }
                        else
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            DowntPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            TotalLength = SelectedRect.Height;
                        }
                    }
                    else
                    {
                        UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                        DowntPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                        TotalLength = SelectedRect.Height;
                    }
                    break;

                default:
                    break;
            }

            if (leftFactor + rightFactor < 180)
            {
                #region DrawleftMainLine
                if (leftFactor >= 0)
                {
                    Current = 6000;
                    CurvePoint.PointX = (UpPoint.PointX - CenterPoint.PointX) * Math.Cos(leftFactor * Math.PI / 180) -
                                        (UpPoint.PointY - CenterPoint.PointY) * Math.Sin(leftFactor * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (UpPoint.PointX - CenterPoint.PointX) * Math.Sin(leftFactor * Math.PI / 180) +
                                        (UpPoint.PointY - CenterPoint.PointY) * Math.Cos(leftFactor * Math.PI / 180) + CenterPoint.PointY;
                    UpPoint.PointX = CurvePoint.PointX;
                    UpPoint.PointY = CurvePoint.PointY;
                }
                graphicsShape.DrawLine(new Pen(Color.Green, 1) { DashStyle = DashStyle.DashDotDot }, UpPoint, CenterPoint);
                #endregion
                #region DrawRightMainLine
                if (rightFactor >= 0)
                {
                    Current = 6000;
                    CurvePoint.PointX = (DowntPoint.PointX - CenterPoint.PointX) * Math.Cos(-rightFactor * Math.PI / 180) -
                                       (DowntPoint.PointY - CenterPoint.PointY) * Math.Sin(-rightFactor * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (DowntPoint.PointX - CenterPoint.PointX) * Math.Sin(-rightFactor * Math.PI / 180) +
                                        (DowntPoint.PointY - CenterPoint.PointY) * Math.Cos(-rightFactor * Math.PI / 180) + CenterPoint.PointY;
                    DowntPoint.PointX = CurvePoint.PointX;
                    DowntPoint.PointY = CurvePoint.PointY;
                }
                graphicsShape.DrawLine(new Pen(Color.Green, 1) { DashStyle = DashStyle.DashDotDot }, DowntPoint, CenterPoint);
                #endregion
            }
            else
            {
                XtraMessageBox.Show("Значения отступов за пределами допустимых значений",
             "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var LeftLengthValue = GetNewLine(UpPoint, CenterPoint).Length;
            var RightLengthValue = GetNewLine(DowntPoint, CenterPoint).Length;
            var mainLength = (RightLengthValue >= LeftLengthValue) ? RightLengthValue : LeftLengthValue;
            var OneSide = (TotalLength) / (count + 1);
            var part = OneSide;
            while (counter < count)
            {
                var path = CreateLeftArcElement(dir, OneSide, axisFactor, id: id);
                list.Add(path);
                OneSide += part;
                counter++;
            }

            return list;
        }
        private List<GraphicsPath> CreateRightArcElementPack(string dir = "", double leftFactor = 0.0, double rightFactor = 0.0, double axisFactor = 0.0, int count = 0, Guid? id = null)
        {
            LeftBottomAngle = leftFactor;
            RightBottomAngle = rightFactor;
            var list = new List<GraphicsPath>();
            ShapePoint UpPoint = null;
            ShapePoint DowntPoint = null;
            ShapePoint CenterPoint = null;
            var tempLength = 0.0;
            var TotalLength = 0.0;

            int counter = 0;
            switch (dir)
            {
                case "Сверху":
                    if (axisFactor != 0)
                    {
                        if (axisFactor > 0)
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y - 1);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + axisFactor);
                            DowntPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            tempLength = 0.0;
                            TotalLength = 0.0;
                            tempLength = SelectedRect.Width - axisFactor;
                            TotalLength = (axisFactor <= SelectedRect.Width / 2) ? tempLength : axisFactor;
                        }
                        else
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            DowntPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            TotalLength = SelectedRect.Height;
                        }
                    }
                    else
                    {
                        UpPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                        DowntPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                        TotalLength = SelectedRect.Height;
                    }

                    break;
                case "Центр":
                    UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                    CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height / 2 + axisFactor);
                    DowntPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                    if (axisFactor != 0)
                    {
                        tempLength = 0.0;
                        TotalLength = 0.0;
                        tempLength = SelectedRect.Height / 2 + axisFactor;
                        TotalLength = (axisFactor >= SelectedRect.Height / 2) ? SelectedRect.Height / 2 : tempLength;
                    }
                    else { TotalLength = SelectedRect.Height / 2; }

                    break;
                case "Снизу":
                    if (axisFactor != 0)
                    {
                        if (axisFactor > 0)
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height - axisFactor);
                            DowntPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            tempLength = 0.0;
                            TotalLength = 0.0;
                            tempLength = SelectedRect.Height - axisFactor;
                            TotalLength = (axisFactor <= SelectedRect.Width / 2) ? tempLength : axisFactor;
                        }
                        else
                        {
                            UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                            CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                            DowntPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                            TotalLength = SelectedRect.Height;
                        }
                    }
                    else
                    {
                        UpPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y);
                        CenterPoint = GetNewCustomPoint(SelectedRect.X + SelectedRect.Width, SelectedRect.Y + SelectedRect.Height);
                        DowntPoint = GetNewCustomPoint(SelectedRect.X, SelectedRect.Y + SelectedRect.Height);
                        TotalLength = SelectedRect.Height;
                    }
                    break;

                default:
                    break;
            }

            if (leftFactor + rightFactor < 180)
            {
                #region DrawleftMainLine
                if (leftFactor >= 0)
                {
                    Current = 6000;
                    CurvePoint.PointX = (UpPoint.PointX - CenterPoint.PointX) * Math.Cos(-rightFactor * Math.PI / 180) -
                                        (UpPoint.PointY - CenterPoint.PointY) * Math.Sin(-rightFactor * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (UpPoint.PointX - CenterPoint.PointX) * Math.Sin(-rightFactor * Math.PI / 180) +
                                        (UpPoint.PointY - CenterPoint.PointY) * Math.Cos(-rightFactor * Math.PI / 180) + CenterPoint.PointY;
                    UpPoint.PointX = CurvePoint.PointX;
                    UpPoint.PointY = CurvePoint.PointY;
                }
                graphicsShape.DrawLine(new Pen(Color.Green, 1) { DashStyle = DashStyle.DashDotDot }, UpPoint, CenterPoint);
                #endregion
                #region DrawRightMainLine
                if (rightFactor >= 0)
                {
                    Current = 6000;
                    CurvePoint.PointX = (DowntPoint.PointX - CenterPoint.PointX) * Math.Cos(leftFactor * Math.PI / 180) -
                                       (DowntPoint.PointY - CenterPoint.PointY) * Math.Sin(leftFactor * Math.PI / 180) + CenterPoint.PointX;
                    CurvePoint.PointY = (DowntPoint.PointX - CenterPoint.PointX) * Math.Sin(leftFactor * Math.PI / 180) +
                                        (DowntPoint.PointY - CenterPoint.PointY) * Math.Cos(leftFactor * Math.PI / 180) + CenterPoint.PointY;
                    DowntPoint.PointX = CurvePoint.PointX;
                    DowntPoint.PointY = CurvePoint.PointY;
                }
                graphicsShape.DrawLine(new Pen(Color.Green, 1) { DashStyle = DashStyle.DashDotDot }, DowntPoint, CenterPoint);
                #endregion
            }
            else
            {
                XtraMessageBox.Show("Значения отступов за пределами допустимых значений",
             "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var LeftLengthValue = GetNewLine(UpPoint, CenterPoint).Length;
            var RightLengthValue = GetNewLine(DowntPoint, CenterPoint).Length;
            var mainLength = (RightLengthValue >= LeftLengthValue) ? RightLengthValue : LeftLengthValue;
            var OneSide = (TotalLength) / (count + 1);
            var part = OneSide;
            while (counter < count)
            {
                var path = CreateRightArcElement(dir, OneSide, axisFactor, id: id);
                list.Add(path);
                OneSide += part;
                counter++;
            }

            return list;
        }
        #endregion
        #endregion

        #region Other
        private System.Drawing.Point[] GetShprosFigurePointsForArc(ShapePoint start, ShapePoint end, ShapePoint center, Guid? id = null)
        {
            //(Direction == "Сверху" && TempSideVector == "Сверху")
            double angleBetween = CalculateAngle(start, center, end);
            List<System.Drawing.Point> pointsList = new List<System.Drawing.Point> { start };
            double degree = 0;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (start.PointX - center.PointX) * Math.Cos(degree * Math.PI / 180) -
                    (start.PointY - center.PointY) * Math.Sin(degree * Math.PI / 180) + center.PointX;
                CurvePoint.PointY = (start.PointX - center.PointX) * Math.Sin(degree * Math.PI / 180) +
                    (start.PointY - center.PointY) * Math.Cos(degree * Math.PI / 180) + center.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(end);
            System.Drawing.Point[] points = new System.Drawing.Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            return points;
        }
        /// <summary>
        /// Gets the shpros figure points.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="h">The h.</param>
        /// <returns></returns>
        private System.Drawing.Point[] GetShprosFigurePoints(ShapePoint start, ShapePoint end, double h = 0.0)
        {
            Line l = GetNewLine(start, end);
            TempPoint.PointX = SetCurrentLineLength(start, end, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(start, end, l.Length / 2).PointY;
            double alpha = 2 * Math.Atan((2 * h) / l.Length);
            double payLength = l.Length * (alpha / Math.Sin(alpha));
            double radius = payLength / alpha / 2;
            radius = (radius == 0) ? 1 : radius;
            double r = radius - h;


            CenterPoint.PointX = TempPoint.PointX + 1;
            CenterPoint.PointY = (h > l.Length / 2) ? TempPoint.PointY - r : TempPoint.PointY + r;
            CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, radius - h);
            CenterPoint.PointX -= 1;
            double angleBetween = CalculateAngle(start, CenterPoint, end);


            List<System.Drawing.Point> pointsList = new List<System.Drawing.Point> { start };
            double degree = 0;
            angleBetween = (h > l.Length / 2) ? 360 - angleBetween : angleBetween;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (start.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180) -
                    (start.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (start.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180) +
                    (start.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(end);
            System.Drawing.Point[] points = new System.Drawing.Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            return points;
        }
        /// <summary>
        /// Gets the shape shpros borders.
        /// </summary>
        /// <returns></returns>
        protected virtual GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddPolygon(GetBasePoints());
            return myPath;
        }
        /// <summary>
        /// Gets the shape borders.
        /// </summary>
        /// <returns></returns>
        public virtual RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddPolygon(GetBasePoints());
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
                // graphicsShape.SetClip(myRegion, CombineMode.Replace);
                graphicsShape.DrawRectangle(Pens.Blue, new Rectangle((int)boundsRect.X,
                    (int)boundsRect.Y, (int)boundsRect.Width, (int)boundsRect.Height));
                return boundsRect;
            }
        }
        #endregion

        #region ClientElemens
        public bool IsDeleteAllMarkers { get; set; }
        public bool IsDeleteLastMarker { get; set; }
        public bool IsDrawSideMarkers { get; set; }
        public bool IsMarkerInsideAxis { get; set; }
        public ShprosElement ClicklElement { get; set; }
        private bool IsInside { get; set; }
        private ShapePoint _CursorPoint;
        public ShapePoint CursorPoint
        {
            get { return _CursorPoint; }
            set { SetField(ref _CursorPoint, value, () => CursorPoint); }
        }

        private List<Rectangle> _MarkersList;
        public Line ClickedLine { get; set; }
        public List<Rectangle> MarkersList
        {
            get { return _MarkersList; }
            set { SetField(ref _MarkersList, value, () => MarkersList); }
        }
        public ShapePoint GetCursorPoint(ShapePoint point)
        {
            point = CursorPoint;
            return CursorPoint;
        }
        private void GetClickedPointIntersection(ShapePoint cursor)
        {
            ShapePoint betweenTwoLinesPoint;
            ShapePoint betweenLineAndArcPoint;
            ShapePoint betweenTwoArcsPoint;
            List<Line> tempList = new List<Line>();
            if (ShprossLineCollection.Count>2)
            {
                betweenTwoLinesPoint = CompareTwoLines(cursor);
            }
           // CompareEndsOfLine(cursor);
            if (ShprossArcCollection.Count > 0)
            {
                betweenLineAndArcPoint = CompareArcsAndLines(cursor);
                    betweenTwoArcsPoint = CompareTwoArcs(cursor);
            }
        }
        private ShprosElement SelectClickedElement(ShapePoint cursor)
        {
            var _element = new ShprosElement();
            if (!(ShprossLineCollection is null))
            {
                foreach (var item in ShprossLineCollection)
                {
                    if (LineIntersection.IsLinePointReg(item, cursor) is true)
                    {
                        ClicklElement = GetAllShprosses.Where(x => x.Id == item.Id).FirstOrDefault();
                        return ClicklElement;
                    }
                }
            }
            if (!(ShprossArcCollection is null))
            {
                foreach (var item in ShprossArcWithKeyCollection)
                {
                    if (LineIntersection.IsArcPointReg(item.Item2, cursor) is true)
                    {
                        ClicklElement = GetAllShprosses.Where(x => x.Id == item.Item1).FirstOrDefault();
                        return ClicklElement;
                    }
                }
            }

            return default(ShprosElement);
        }
        private ShapePoint CompareTwoLines(ShapePoint cursor)
        {
            ShapePoint betweenTwoLinesPoint = new ShapePoint();
            for (int i = 0; i < ShprossLineCollection.Count; i++)
            {
                for (int j = 0; j < ShprossLineCollection.Count; j++)
                {
                    betweenTwoLinesPoint = LineIntersection.CheckIntersectionOfTwoLineSegments(ShprossLineCollection[i], ShprossLineCollection[j]);
                    if (!(betweenTwoLinesPoint is null) && betweenTwoLinesPoint.PointX != 0 && betweenTwoLinesPoint.PointY != 0)
                    {
                        var rect = new Rectangle((int)betweenTwoLinesPoint.PointX - 10, (int)betweenTwoLinesPoint.PointY - 10, 20, 20);
                        if (IsCursorInsideRectangle(rect, cursor))
                        {
                            GetMarkerPointsList(cursor);
                        }
                        else { DrawMarker(); }
                    }
                }

            }

            return betweenTwoLinesPoint;
        }

        private void CompareEndsOfLine(ShapePoint cursor)
        {
            if (ShprossLineCollection.Count > 0)
            {
                for (int i = 0; i < ShprosCollection.Count; i++)
                {
                    bool isInside = LineIntersection.IsPointEndOfLine(ShprossLineCollection[i], cursor);
                    if (isInside && cursor.PointX != 0 && cursor.PointY != 0)
                    {
                        var rect = new Rectangle((int)cursor.PointX - 10, (int)cursor.PointY - 10, 20, 20);
                        if (IsCursorInsideRectangle(rect, cursor) && !(LineIntersection.EndOrStartPoint is null) && LineIntersection.EndOrStartPoint.PointX != 0 && LineIntersection.EndOrStartPoint.PointY != 0)
                        {
                            GetMarkerPointsList(LineIntersection.EndOrStartPoint);
                        }
                    }
                    else { DrawMarker(); }
                }
            }
            if (ShprossArcCollection.Count > 0)
            {
                for (int k = 0; k < ShprossArcCollection.Count; k++)
                {
                    bool isInside = LineIntersection.IsPointEndOfArc(ShprossArcCollection[k], cursor);
                    if (isInside && cursor.PointX != 0 && cursor.PointY != 0)
                    {
                        var rect = new Rectangle((int)cursor.PointX - 10, (int)cursor.PointY - 10, 20, 20);
                        if (IsCursorInsideRectangle(rect, cursor) && !(LineIntersection.EndOrStartPoint is null) && LineIntersection.EndOrStartPoint.PointX != 0 && LineIntersection.EndOrStartPoint.PointY != 0)
                        {
                            GetMarkerPointsList(LineIntersection.EndOrStartPoint);
                        }
                    }
                    else { DrawMarker(); }

                }
            }
        }

        private ShapePoint CompareArcsAndLines(ShapePoint cursor)
        {
            ShapePoint betweenLineAndArcPoint = new ShapePoint();
            for (int i = 0; i < ShprossLineCollection.Count; i++)
            {
                for (int k = 0; k < ShprossArcCollection.Count; k++)
                {
                    var intersectionPointsList = LineIntersection.CheckInterseptionPointsListOfArcAndLine(ShprossLineCollection[i], ShprossArcCollection[k]);
                    foreach (var item in intersectionPointsList)
                    {
                        betweenLineAndArcPoint = item;
                        if (!(betweenLineAndArcPoint is null) && betweenLineAndArcPoint.PointX != 0 && betweenLineAndArcPoint.PointY != 0)
                        {
                            var rect = new Rectangle((int)betweenLineAndArcPoint.PointX - 10, (int)betweenLineAndArcPoint.PointY - 10, 20, 20);
                            if (IsCursorInsideRectangle(rect, cursor))
                            {
                                GetMarkerPointsList(cursor);
                            }
                            else { DrawMarker(); }
                        }
                    }
                }
            }
            return betweenLineAndArcPoint;
        }
        private ShapePoint CompareTwoArcs(ShapePoint cursor)
        {
            ShapePoint betweenTwoArcs = new ShapePoint();

            for (int i = 0; i < ShprossArcCollection.Count; i++)
            {
                for (int k = 0; k < ShprossArcCollection.Count; k++)
                {
                    var intersectionPointsList = LineIntersection.CheckInterseptionPointsListOfArcAndArc(ShprossArcCollection[i], ShprossArcCollection[k]);
                    foreach (var item in intersectionPointsList)
                    {
                        betweenTwoArcs = item;
                        if (!(betweenTwoArcs is null) && betweenTwoArcs.PointX != 0 && betweenTwoArcs.PointY != 0)
                        {
                            var rect = new Rectangle((int)betweenTwoArcs.PointX - 5, (int)betweenTwoArcs.PointY - 5, 10, 10);
                            if (IsCursorInsideRectangle(rect, cursor))
                            {
                                if (!MarkersList.Contains(rect))
                                {
                                    GetMarkerPointsList(betweenTwoArcs);
                                    break;
                                }
                            }
                            else { DrawMarker(); }
                        }
                    }
                }
            }
            return betweenTwoArcs;
        }



        public static bool IsCursorInsideRectangle(Rectangle rect, ShapePoint point)
        {
            if (point.PointY >= rect.Y && point.PointY <= rect.Y + rect.Height &&
                            point.PointX >= rect.X && point.PointX <= rect.X + rect.Width)
            { return true; }
            else { return false; }
        }
        public void GetMarkerPointsList(ShapePoint point)
        {
            if (IsDeleteLastMarker)
            {
                RemoveLastMarker();
                MarkersList = MarkersList.Distinct().ToList();
                IsDeleteLastMarker = false;
            }
            else
            {
                MarkersList = MarkersList.Distinct().ToList();
                MarkersList.Add(CursorRectangle(point));
            }
            if (IsDeleteAllMarkers)
            {
                RemoveAllMarkers();
                IsDeleteAllMarkers = false;
            }
            DrawMarker();
        }
        private void RemoveAllMarkers() => MarkersList.Clear();
        private void DrawMarker()
        {
            var path = new GraphicsPath();
            var pen = new Pen(Color.Red, 3);
            foreach (var item in MarkersList)
            {
                var leftUpRectPoint = GetNewCustomPoint(item.X, item.Y);
                var rightUpRectPoint = GetNewCustomPoint(item.X + item.Width, item.Y);
                var leftBottomRectPoint = GetNewCustomPoint(item.X, item.Y + item.Height);
                var rightBottomRectPoint = GetNewCustomPoint(item.X + item.Width, item.Y + item.Height);
                var leftStar = GetNewCustomPoint(item.X - item.Width, item.Y + item.Height / 2);
                var rightStar = GetNewCustomPoint(item.X + item.Width * 2, item.Y + item.Height / 2);
                var upStar = GetNewCustomPoint(item.X + item.Width / 2, item.Y - item.Height);
                var bottomStar = GetNewCustomPoint(item.X + item.Width / 2, item.Y + item.Height * 2);
                path.AddPolygon(new PointF[] { leftUpRectPoint, leftStar, leftBottomRectPoint });
                path.AddPolygon(new PointF[] { rightUpRectPoint, rightStar, rightBottomRectPoint });
                path.AddPolygon(new PointF[] { upStar, leftUpRectPoint, rightUpRectPoint });
                path.AddPolygon(new PointF[] { leftBottomRectPoint, bottomStar, rightBottomRectPoint });
                graphicsShape.DrawPath(pen, path);
                graphicsShape.FillPath(new SolidBrush(Color.Red), path);
                graphicsShape.DrawEllipse(pen, item);
                graphicsShape.FillEllipse(new SolidBrush(Color.Black), item);
            }
        }
        private void RemoveLastMarker()
        {
            if (MarkersList.Count > 0)
            {
                MarkersList.Remove(MarkersList.Last());
            }
            else return;
        }
        private Rectangle CursorRectangle(ShapePoint point)
        {
            var rect = new Rectangle((int)point.PointX - 5, (int)point.PointY - 5, 10, 10);
            return rect;
        }
        #endregion

    }
}
