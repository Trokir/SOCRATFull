using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using DevExpress.Office.Drawing;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using IDentableItem = Socrat.Lib.Order.IDentableItem;

namespace Socrat.References.Formula
{
    /// <summary>
    /// Класс отрисовки формулы изделия
    /// </summary>
    public static class FormulaDrawer
    {
        private static Color _colorGlass = Color.LightSkyBlue;
        private static Color _bkColor = SystemColors.Window;
        private static Color _germColor = Color.DimGray;
        private static int _counturThin = 6;
        private static Color _colorCountor = Color.DimGray;
        private static Color _selectedCountor = Color.Red;
        private static Color _colorFilm = Color.LightGray;

        //Коэфициент масштабирования
        public static double _mKoef = 1;

        public static void Draw(Core.Entities.Formula formula, Graphics g)
        {
            //if (!formula.Valid)
            //{
            //    g.Clear(_bkColor);
            //    return;
            //}

            double _borderOffsetPercent = 0.2;
            double _borderOffset = 0.01 * 2;
            double _itemOffset = 0.1;
            double _itemMaxSizePercent = 0.7;

            RectangleF _rectangle = g.VisibleClipBounds;

            //высота облати рисования
            int _drawHeght = (int)(_rectangle.Height * (1 - _borderOffset));
            //ширина облати рисования
            int _drawWidth = (int)(_rectangle.Width * (1 - _borderOffset));

            //стартовая точка облати рисовани (верхняя левая)
            Point _startPoint = new Point((int)((_rectangle.Width - _drawWidth) / 2), (int)((_rectangle.Height - _drawHeght) / 2));
            //центр
            Point _centerPoint = new Point(_startPoint.X + (int)(_drawWidth / 2), _startPoint.Y + (int)(_drawHeght / 2));

            Image _img = new Bitmap(_drawWidth, _drawHeght);
            Graphics gd = Graphics.FromImage(_img);
            gd.Clear(_bkColor);
            //gd.DrawPie(new Pen(new SolidBrush(Color.Chartreuse), 3), _startPoint.X, _startPoint.Y, 3, 3, 0, 360);

            //высота изделия для отображения
            int _itemHight = (int)(_drawHeght * (1 - 2 * _itemOffset));
            if (formula.DentExists)
                _itemHight = (int)(_itemHight * 0.7);

            if (formula.DrawThickness < _drawWidth / 2)
            {
                _mKoef = _drawWidth / formula.DrawThickness * _itemMaxSizePercent;
            }
            else if (formula.DrawThickness < _drawWidth)
            {
                _mKoef = 1;
            }
            else if (formula.DrawThickness > _drawWidth)
            {
                _mKoef = _drawWidth / formula.DrawThickness;
            }

            _mKoef = Math.Round(_mKoef);
            _mKoef = Math.Min(_mKoef, 10);

            int _itemWidth = (int)(formula.DrawThickness * _mKoef);


            Point _itemPoint = new Point(
                _centerPoint.X - (_itemWidth / 2),
                _startPoint.Y + (_drawHeght - _itemHight) / 2);

            //gd.DrawPie(new Pen(new SolidBrush(Color.Blue), 3), _itemPoint.X, _itemPoint.Y, 3, 3, 0, 360);
            //gd.DrawString($"Масштаб {_mKoef}",  new Font(System.Drawing.SystemFonts.DefaultFont.FontFamily, 12), 
            //    new SolidBrush(Color.Black), _startPoint);

            if (formula.RootItem.Items.Count > 0)
            {
                //рисуем элементы изделие
                DrawUnit(gd, _itemPoint, _itemHight, _itemWidth, formula);
            }
            else
            {
                //точка элемента
                Point _elementPoint = new Point(_itemPoint.X, _itemPoint.Y);
                Image _element = new Bitmap((int)(formula.RootItem.DrawThickness * _mKoef), _itemHight);
                Graphics _ge = Graphics.FromImage(_element);
                DrawElement(_ge, formula.RootItem, formula, false);
                gd.DrawImage(_element, _elementPoint);
            }

            g.DrawImage(_img, _startPoint);

            g.FillRectangle(new SolidBrush(_bkColor), _itemPoint.X, _itemPoint.Y, _itemWidth + 6, 6);
        }

        public static void DrawUnit(Graphics gd, Point itemPoint, int itemHight, int itemWidth, Core.Entities.Formula formula)
        {
            //граф изделия
            Image _imageItem = new Bitmap(itemWidth, itemHight);
            //граф элемента
            Image _element;
            Graphics _ge;
            //точка элемента
            Point _elementPoint = new Point(itemPoint.X, itemPoint.Y);
            int _elementHight = itemHight;
            IDentableItem _dentableItem = null;
            foreach (FormulaItem formulaItem in formula.RootItem.Items)
            {
                //зубная логика
                PropertyInfo _prop = formulaItem.GetType().GetProperty("DentExists");
                if (_prop != null)
                {
                    bool _dentExists = false;
                    ;
                    if (bool.TryParse(_prop.GetValue(formulaItem).ToString(), out _dentExists) && _dentExists)
                        _elementHight = (int)(_elementHight * 1.3);
                    else
                        _elementHight = itemHight;
                }
                else
                {
                    _elementHight = itemHight;
                }

                _element = new Bitmap((int)(formulaItem.DrawThickness * _mKoef), _elementHight);
                _ge = Graphics.FromImage(_element);
                DrawElement(_ge, formulaItem, formula, false);
                gd.DrawImage(_element, _elementPoint);
                _elementPoint = new Point(_elementPoint.X + (int)(formulaItem.DrawThickness * _mKoef), _elementPoint.Y);
            }

            gd.DrawImage(_imageItem, itemPoint);
        }

        private static void DrawElement(Graphics ge, FormulaItem formulaItem, Core.Entities.Formula formula, bool hideSelection)
        {
            switch (formulaItem.MaterialEnum)
            {
                case MaterialEnum.Glass:
                    DrawGlass(ge, formulaItem as GlassItem, formula, hideSelection);
                    break;
                case MaterialEnum.Frame:
                    DrawFrame(ge, formulaItem as FrameItem);
                    break;
                case MaterialEnum.Triplex:
                    DrawTriplex(ge, formulaItem as TriplexItem, formula, hideSelection);
                    break;
                case MaterialEnum.TriplexFilm:
                case MaterialEnum.Film:
                    DrawFilm(ge, formulaItem);
                    break;
            }
        }


        private static Color GetFilmCoutorColor(FormulaItem item)
        {
            if (item.Selected)
                return _selectedCountor;
            return _bkColor;
        }

        private static void DrawFilm(Graphics ge, FormulaItem item)
        {
            ge.Clear(_bkColor);
            RectangleF _rectangleF = ge.VisibleClipBounds;
            Rectangle _rectangle = new Rectangle(0, 0, (int)(_rectangleF.Width), (int)_rectangleF.Height);
            ge.FillRectangle(new SolidBrush(_colorFilm), _rectangle);
            ge.DrawRectangle(new Pen(new SolidBrush(GetFilmCoutorColor(item)), _counturThin), _rectangle);
        }

        private static void DrawTriplex(Graphics gd, TriplexItem item, Core.Entities.Formula formula, bool hideSelection)
        {
            gd.Clear(_bkColor);
            //рисуем элементы изделия
            //граф элемента
            Image _element;
            Graphics _ge;
            //точка элемента
            Point _elementPoint = new Point(0, 0);

            foreach (var _formulaItem in item.FormulaItems.OrderBy(x => x.Position))
            {
                _element = new Bitmap((int)(_formulaItem.DrawThickness * _mKoef), (int)gd.VisibleClipBounds.Height);
                _ge = Graphics.FromImage(_element);
                DrawElement(_ge, _formulaItem, formula, hideSelection);
                gd.DrawImage(_element, _elementPoint);
                _elementPoint = new Point(_elementPoint.X + (int)(_formulaItem.DrawThickness * _mKoef), _elementPoint.Y);
            }
        }

        private static Color GetItemCoutorColor(FormulaItem item, bool hideSelection)
        {
            if (!hideSelection && item.Selected)
                return _selectedCountor;
            return _colorCountor;
        }

        private static void DrawGlass(Graphics ge, GlassItem item, Core.Entities.Formula formula, bool hideSelection)
        {
            ge.Clear(_colorGlass);
            RectangleF _rectangleF = ge.VisibleClipBounds;
            Rectangle _rectangle = new Rectangle(0, 0, (int)_rectangleF.Width - 1, (int)_rectangleF.Height - 1);
            ge.DrawRectangle(new Pen(new SolidBrush(GetItemCoutorColor(item, hideSelection)), _counturThin), _rectangle);

            if (!hideSelection && formula != null && formula.ShowPositionsNumbers)
            {
                int[] _nums = formula.GetGlassPositionsNumbers(item);
                ////if (_nums.Length == 2)
                {
                    ge.DrawString(_nums[0].ToString("N0"),
                        new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold),
                        new SolidBrush(Color.Black), new PointF((int)(_counturThin * 0.2), _rectangle.Height - _counturThin * 3));
                    ge.DrawString(_nums[1].ToString("N0"),
                        new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold),
                        new SolidBrush(Color.Black), new PointF((int)(_rectangle.Width - _counturThin * 2), _rectangle.Height - _counturThin * 3));
                }
            }
        }

        private static void DrawFrame(Graphics ge, FrameItem item)
        {
            ge.Clear(_bkColor);
            RectangleF _rectangleF = ge.VisibleClipBounds;
            if (item.Gaz ?? false)
                ge.FillRectangle(new HatchBrush(HatchStyle.Percent20, Color.DodgerBlue, _bkColor), _rectangleF);

            Rectangle _rectangle = new Rectangle(0, 0, (int)_rectangleF.Width - 1, (int)_rectangleF.Height - 1);
            ge.DrawRectangle(new Pen(new SolidBrush(Color.Gray)), _rectangle);

            //заполнение герметиком
            Point _germPoint = new Point(0, (int)(_rectangleF.Height - item.GermDepth * _mKoef));
            Rectangle _germ = new Rectangle(_germPoint.X, _germPoint.Y,
                (int)_rectangleF.Width - 1, (int)(item.GermDepth * _mKoef));
            ge.FillRectangle(new HatchBrush(HatchStyle.LargeCheckerBoard, _germColor, _bkColor), _germ);

            //рамка
            Point _framePoint = new Point(_germPoint.X + _counturThin, (int)(_germPoint.Y - item.FrameHight * _mKoef));
            PointF _framePointF = new PointF(_germPoint.X + _counturThin, (int)(_germPoint.Y - item.FrameHight * _mKoef));
            Rectangle _frame = new Rectangle(_framePoint.X, _framePoint.Y, (int)(_germ.Width - 2 * _counturThin), (int)(item.FrameHight * _mKoef));

            PointF[] _framePoints = new PointF[]
            {
                    new PointF(_framePointF.X, _framePointF.Y),
                    new PointF(_framePointF.X + _frame.Width, _framePointF.Y),
                    new PointF(_framePointF.X + _frame.Width, (int)(_framePointF.Y + _frame.Height*0.65)),
                    new PointF((int)(_framePointF.X + _frame.Width*0.75), (int)(_framePointF.Y + _frame.Height)),
                    new PointF((int)(_framePointF.X + _frame.Width*0.25), (int)(_framePointF.Y + _frame.Height)),
                    new PointF(_framePointF.X, (int)(_framePointF.Y + _frame.Height*0.65))
            };

            //заливка фасок герметиком
            ge.FillRectangle(new HatchBrush(HatchStyle.LargeCheckerBoard, _germColor, _bkColor),
                new Rectangle(_germPoint.X, _framePoint.Y + (int)(_frame.Height * 0.65),
                    _germ.Width, _frame.Height - (int)(_frame.Height * 0.65)));

            ge.FillPolygon(new SolidBrush(_bkColor), _framePoints);
            Color frameColor = item.Selected ? _selectedCountor : _colorCountor;
            ge.DrawPolygon(new Pen(new SolidBrush(frameColor), 4), _framePoints);

            //вставки 
            if (item.BaseSideInset)
            {
                PointF[] _insetPoints = new[]
                {
                    new PointF((int) (_framePointF.X + _frame.Width * 0.25), (int)(_framePointF.Y + _frame.Height + _counturThin *1.5)),
                    new PointF((int) (_framePointF.X + _frame.Width * 0.75), (int)(_framePointF.Y + _frame.Height + _counturThin*1.5)),
                    new PointF((int) (_framePointF.X + _frame.Width * 0.75), (int)(_rectangleF.Height - _counturThin*0.5)),
                    new PointF((int) (_framePointF.X + _frame.Width * 0.25), (int)(_rectangleF.Height - _counturThin*0.5))
                };
                ge.FillPolygon(new SolidBrush(_bkColor), _insetPoints);
                Color _InsetColor = item.InsetSelected ? _selectedCountor : _colorCountor;
                ge.DrawPolygon(new Pen(new SolidBrush(_InsetColor), _counturThin), _insetPoints);
                ge.DrawPolygon(new Pen(new SolidBrush(_bkColor), _counturThin * 2),
                    new[]
                    {
                        new PointF((int)(_framePointF.X + _frame.Width * 0.25 + _counturThin*0.5), _rectangleF.Height - _counturThin + 1),
                        new PointF((int) (_framePointF.X + _frame.Width * 0.75 - _counturThin*0.5), _rectangleF.Height - _counturThin + 1)
                    });
            }

            if (item.VerticalSideInset)
            {
                PointF[] _vinsetPoints = new[]
                {
                    new PointF((int) (_framePointF.X + _frame.Width * 0.25), (int)(0 + _framePointF.Y *0.1)),
                    new PointF((int) (_framePointF.X + _frame.Width * 0.75), (int)(0 + _framePointF.Y *0.1)),
                    new PointF((int) (_framePointF.X + _frame.Width * 0.75), (int)(_framePointF.Y*0.9)),
                    new PointF((int) (_framePointF.X + _frame.Width * 0.25), (int)(_framePointF.Y*0.9))
                };
                ge.FillPolygon(new SolidBrush(_bkColor), _vinsetPoints);
                Color _InsetColor = item.InsetSelected ? _selectedCountor : _colorCountor;
                ge.DrawPolygon(new Pen(new SolidBrush(_InsetColor), _counturThin), _vinsetPoints);
            }
            //ge.DrawString(item.Thickness.ToString("N0"),
            //    new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold),
            //    new SolidBrush(Color.Black), new PointF(2, 2));

            //if (item.Selected)
            //    ge.DrawRectangle(new Pen(new SolidBrush(_selectedCountor), _counturThin), _rectangleF.X, _rectangleF.Y,
            //        _rectangleF.Width, _rectangleF.Height);
        }

        public static void DrawItemSurfaces(SurfaseProcessing surfaceItem, Graphics g, Point GraphLocation, Core.Entities.Formula formula)
        {
            RectangleF _rectangle = g.VisibleClipBounds;
            double _borderOffsetPercent = 0.2;
            double _borderOffset = 0.01 * 2;
            double _itemOffset = 0.1;
            double _itemMaxSizePercent = 0.9;
            double _surfacePart = 0.15;
            int _maxSurfaceWidth = 12;
            int _minSurfaceidth = 9;

            //высота облати рисования
            int _drawHeght = (int)(_rectangle.Height * (1 - _borderOffset));
            //ширина облати рисования
            int _drawWidth = (int)(_rectangle.Width * (1 - _borderOffset));

            //стартовая точка облати рисовани (верхняя левая)
            Point _startPoint = new Point((int)((_rectangle.Width - _drawWidth) / 2), (int)((_rectangle.Height - _drawHeght) / 2));
            //центр
            Point _centerPoint = new Point(_startPoint.X + (int)(_drawWidth / 2), _startPoint.Y + (int)(_drawHeght / 2));

            Image _img = new Bitmap(_drawWidth, _drawHeght);
            Graphics gd = Graphics.FromImage(_img);
            gd.Clear(_bkColor);

            //высота изделия для отображения
            int _itemHight = (int)(_drawHeght * (1 - 2 * _itemOffset));

            if (surfaceItem.FormulaItem.DrawThickness < _drawWidth / 2)
            {
                _mKoef = _drawWidth / surfaceItem.FormulaItem.DrawThickness * _itemMaxSizePercent;
            }
            else if (surfaceItem.FormulaItem.DrawThickness < _drawWidth)
            {
                _mKoef = 1;
            }
            else if (surfaceItem.FormulaItem.DrawThickness > _drawWidth)
            {
                _mKoef = _drawWidth / surfaceItem.FormulaItem.DrawThickness;
            }

            _mKoef = Math.Round(_mKoef);
            _mKoef = Math.Min(_mKoef, 10);

            int _itemWidth = (int)(surfaceItem.FormulaItem.DrawThickness * _mKoef);

            //граф изделия
            Image _imageItem = new Bitmap(_itemWidth, _itemHight);
            Point _itemPoint = new Point(
                _centerPoint.X - (_itemWidth / 2),
                _startPoint.Y + (_drawHeght - _itemHight) / 2);

            Graphics ge = Graphics.FromImage(_imageItem);
            ge.Clear(_colorGlass);
            RectangleF _rectangleF = ge.VisibleClipBounds;

            if (surfaceItem.FormulaItem is GlassUnitItem)
            {
                Point _p = new Point(_startPoint.X - _counturThin/2, _startPoint.Y - _counturThin/2);
                DrawUnit(ge, _p, _itemHight, _itemWidth, formula);
            }
            else 
            {
                DrawElement(ge, surfaceItem.FormulaItem, formula, true);
            }

            int _surfaceWidth = (int)(_rectangleF.Width * _surfacePart);
            _surfaceWidth = Math.Min(_surfaceWidth, _maxSurfaceWidth);
            _surfaceWidth = Math.Max(_surfaceWidth, _minSurfaceidth);
            _surfacePart = _surfaceWidth / _rectangleF.Width;
            
            //рисуем поверхности
            Point _surfaceStartPoint1 = new Point(_startPoint.X - _surfaceWidth, _startPoint.Y);
            Point _surfaceStartPoint2 = new Point(_startPoint.X + _itemWidth, _startPoint.Y);
            Rectangle _firstSurface =
                new Rectangle(_surfaceStartPoint1.X, _surfaceStartPoint1.Y, _surfaceWidth, _itemHight);
            Rectangle _secondSurface = 
                new Rectangle(_surfaceStartPoint2.X, _surfaceStartPoint2.Y, _surfaceWidth, _itemHight);

            surfaceItem.FirstSurface = new Rectangle((int)_itemPoint.X - _surfaceWidth, (int)_itemPoint.Y + _startPoint.Y,
                _firstSurface.Width, _firstSurface.Height);
            surfaceItem.SecondSurface = new Rectangle((int)_itemPoint.X + _itemWidth /*_secondSurface.X*/,
                (int)_itemPoint.Y + _startPoint.Y,
                _secondSurface.Width, _secondSurface.Height);

            gd.FillRectangle(new SolidBrush(surfaceItem.SelectedSurface == 1 ? Color.Red : Color.LimeGreen), surfaceItem.FirstSurface);
            gd.FillRectangle(new SolidBrush(surfaceItem.SelectedSurface == 2 ? Color.Red : Color.LimeGreen), surfaceItem.SecondSurface);

            //Image _itemImg = new Bitmap((int)(_rectangleF.Width * (1 - _surfacePart * 2)), (int)_rectangleF.Height - 1);
            //Graphics _itemGr = Graphics.FromImage(_itemImg);
            //_mKoef = _itemImg.Width / surfaceItem.FormulaItem.DrawThickness;
            //DrawElement(_itemGr, surfaceItem.FormulaItem, formula, true);
            //ge.DrawImage(_itemImg, new Point((int)(_rectangleF.Width * _surfacePart), 0));
            
            //стираем верхний край
            ge.FillRectangle(new SolidBrush(_bkColor), 0, 0, (int)(_rectangleF.Width), 6);

            gd.DrawImage(_imageItem, _itemPoint);
            g.DrawImage(_img, _startPoint);
        }

        public static void DrowCoordinates(Graphics ge, Point coords, float X, float Y)
        {
            ge.DrawString($"X:{coords.X} Y:{coords.Y}",
                new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold),
                new SolidBrush(Color.Black), X, Y);
        }
    }
}