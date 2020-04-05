using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Socrat.Lib;
using Socrat.Lib.Order;
using Socrat.Model;

namespace Socrat.Module.Order
{
    /// <summary>
    /// Класс отрисовки формулы изделия
    /// </summary>
    public static class FormulaDrawer
    {
        private static Color _colorGlass = Color.LightSkyBlue;
        private static Color _bkColor = Color.GhostWhite;
        private static Color _germColor = Color.DimGray;
        private static int _counturThin = 6;
        private static Color _colorCountor = Color.DimGray;
        private static Color _selectedCountor = Color.Red;
        private static Color _colorFilm = Color.LightGray;

        //Коэфициент масштабирования
        public static double _mKoef = 1;

        public static void Draw(Model.Formula formula, Graphics g)
        {
            if (!formula.Valid)
            {
                g.Clear(_bkColor);
                return;
            }

            double _borderOffsetPercent = 0.2;
            double _borderOffset = 0.01 * 2;
            double _itemOffset = 0.1;
            double _itemMaxSizePercent = 0.7;
            
            RectangleF _rectangle = g.VisibleClipBounds;

            //высота облати рисования
            int _drawHeght = (int) (_rectangle.Height * (1 -_borderOffset)) ;
            //ширина облати рисования
            int _drawWidth = (int)(_rectangle.Width * (1-_borderOffset));
            
            //стартовая точка облати рисовани (верхняя левая)
            Point _startPoint = new Point((int)((_rectangle.Width - _drawWidth) / 2), (int)((_rectangle.Height - _drawHeght)/2));
            //центр
            Point _centerPoint = new Point(_startPoint.X + (int)(_drawWidth/2), _startPoint.Y + (int)(_drawHeght/2));

            Image _img = new Bitmap(_drawWidth, _drawHeght);
            Graphics gd = Graphics.FromImage(_img);
            gd.Clear(Color.GhostWhite);
            //gd.DrawPie(new Pen(new SolidBrush(Color.Chartreuse), 3), _startPoint.X, _startPoint.Y, 3, 3, 0, 360);

            //высота изделия для отображения
            int _itemHight = (int) (_drawHeght * (1 - 2 * _itemOffset));
            if (formula.DentExists)
                _itemHight = (int) (_itemHight * 0.7);

            if (formula.DrawThickness < _drawWidth / 2)
            {
                _mKoef = _drawWidth/ formula.DrawThickness * _itemMaxSizePercent;
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

            int _itemWidth = (int) (formula.DrawThickness * _mKoef);

            //граф изделия
            Image _imageItem = new Bitmap(_itemWidth, _itemHight);
            Point _itemPoint = new Point(
                _centerPoint.X - (_itemWidth/2),
                _startPoint.Y + (_drawHeght - _itemHight)/2);

            //gd.DrawPie(new Pen(new SolidBrush(Color.Blue), 3), _itemPoint.X, _itemPoint.Y, 3, 3, 0, 360);
            gd.DrawString($"Масштаб {_mKoef}",  new Font(System.Drawing.SystemFonts.DefaultFont.FontFamily, 12), 
                new SolidBrush(Color.Black), _startPoint);

            //рисуем элементы изделия
            //граф элемента
            Image _element;
            Graphics _ge;
            //точка элемента
            Point _elementPoint = new Point(_itemPoint.X, _itemPoint.Y);
            int _elementHight = _itemHight;
            IDentableItem _dentableItem = null;
            for (int i = 0; i < formula.Items.Count; i++)
            {
                //зубная логика
                _dentableItem = formula.Items[i] as IDentableItem;
                if (null != _dentableItem && _dentableItem.DentExists)
                    _elementHight = (int) (_elementHight * 1.3);
                else
                    _elementHight = _itemHight;

                    _element = new Bitmap((int)(formula.Items[i].DrawThickness * _mKoef), _elementHight);
                _ge = Graphics.FromImage(_element);
                DrawElement(_ge, formula.Items[i]);
                gd.DrawImage(_element, _elementPoint);
                _elementPoint = new Point(_elementPoint.X + (int)(formula.Items[i].DrawThickness * _mKoef), _elementPoint.Y);
            }

            gd.DrawImage(_imageItem, _itemPoint);
            g.DrawImage(_img, _startPoint);

            //координатные линии
            //g.DrawLine(new Pen(new SolidBrush(Color.Red), 1), _startPoint.X, _centerPoint.Y, _startPoint.X + _drawWidth, _centerPoint.Y);
            //g.DrawLine(new Pen(new SolidBrush(Color.Red), 1), _centerPoint.X, _startPoint.Y, _centerPoint.X, _startPoint.Y + _drawHeght);
            g.FillRectangle(new SolidBrush(_bkColor), _itemPoint.X, _itemPoint.Y, _itemWidth + 6, 6);
        }

        private static void DrawElement(Graphics ge, FormulaItem formulaItem)
        {
            switch (formulaItem.Material.MaterialEnum)
            {
                case MaterialEnum.Glass:
                    DrawGlass(ge, formulaItem as GlassItem);
                    break;
                case MaterialEnum.Frame:
                    DrawFrame(ge, formulaItem as FrameItem);
                    break;
                case MaterialEnum.Triplex:
                    DrawTriplex(ge, formulaItem as TriplexItem);
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
            //ge.DrawString(item.Thickness.ToString("N2"),
            //    new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold),
            //    new SolidBrush(Color.Black), new PointF(2, 2));
        }
        private static void DrawTriplex(Graphics gd, TriplexItem item)
        {
            gd.Clear(_bkColor);
            //рисуем элементы изделия
            //граф элемента
            Image _element;
            Graphics _ge;
            //точка элемента
            Point _elementPoint = new Point(0, 0);
            for (int i = 0; i < item.Items.Count; i++)
            {
                _element = new Bitmap((int)(item.Items[i].DrawThickness * _mKoef), (int)gd.VisibleClipBounds.Height);
                _ge = Graphics.FromImage(_element);
                DrawElement(_ge, item.Items[i]);
                gd.DrawImage(_element, _elementPoint);
                _elementPoint = new Point(_elementPoint.X + (int)(item.Items[i].DrawThickness * _mKoef), _elementPoint.Y);
            }

            gd.DrawString(item.Thickness.ToString("N0"),
                new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold),
                new SolidBrush(Color.Black), new PointF(2, 2));
        }

        private static Color GetItemCoutorColor(FormulaItem item)
        {
            if (item.Selected)
                return _selectedCountor;
            return _colorCountor;
        }

        private static void DrawGlass(Graphics ge, GlassItem item)
        {
            ge.Clear(_colorGlass);
            RectangleF _rectangleF = ge.VisibleClipBounds;
            Rectangle _rectangle = new Rectangle(0, 0, (int)_rectangleF.Width - 1, (int)_rectangleF.Height - 1);
            ge.DrawRectangle(new Pen(new SolidBrush(GetItemCoutorColor(item)), _counturThin), _rectangle);
            ge.DrawString(item.Thickness.ToString("N0"), 
                new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold),
                new SolidBrush(Color.Black), new PointF(2, 2));
        }

        private static void DrawFrame(Graphics ge, FrameItem item)
        {
            ge.Clear(_bkColor);
            RectangleF _rectangleF = ge.VisibleClipBounds;
            if (item.Gaz)
                ge.FillRectangle(new HatchBrush(HatchStyle.Percent20, Color.DodgerBlue, _bkColor) , _rectangleF);
                
            
            Rectangle _rectangle = new Rectangle(0, 0, (int)_rectangleF.Width - 1, (int)_rectangleF.Height - 1);
            ge.DrawRectangle(new Pen(new SolidBrush(Color.Gray)), _rectangle);
            //заполнение герметиком
            Point _germPoint = new Point(0, (int)(_rectangleF.Height - item.GermDepth * _mKoef));
            Rectangle _germ = new Rectangle(_germPoint.X, _germPoint.Y, 
                (int)_rectangleF.Width - 1, (int)(item.GermDepth * _mKoef));
            ge.FillRectangle(new HatchBrush(HatchStyle.LargeCheckerBoard, _germColor, _bkColor), _germ);

            //рамка
            Point _framePoint = new Point(_germPoint.X + _counturThin, (int)(_germPoint.Y - item.FrameHight*_mKoef));
            PointF _framePointF = new PointF(_germPoint.X + _counturThin, (int)(_germPoint.Y - item.FrameHight*_mKoef));
            Rectangle _frame = new Rectangle(_framePoint.X, _framePoint.Y, (int)(_germ.Width -2*_counturThin), (int)(item.FrameHight*_mKoef));

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
            ge.DrawPolygon(new Pen(new SolidBrush(_colorCountor), 4), _framePoints);


            ge.DrawString(item.Thickness.ToString("N0"),
                new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold),
                new SolidBrush(Color.Black), new PointF(2, 2));

            if (item.Selected)
                ge.DrawRectangle(new Pen(new SolidBrush(_selectedCountor), _counturThin), _rectangleF.X, _rectangleF.Y,
                    _rectangleF.Width, _rectangleF.Height);
        }
    }
}