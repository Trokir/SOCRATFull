using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sorat.Test
{
    public partial class PackageVisualEditor : Form
    {
        public PackageVisualEditor()
        {
            InitializeComponent();

            nudF1.ValueChanged += comboBox1_SelectedIndexChanged;
            nudF2.ValueChanged += comboBox1_SelectedIndexChanged;
            nudG1.ValueChanged += comboBox1_SelectedIndexChanged;
            nudG2.ValueChanged += comboBox1_SelectedIndexChanged;
            nudG3.ValueChanged += comboBox1_SelectedIndexChanged;

            EnabledCheck();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            int _butilTh = 2;
            int _firstGlassW =  Convert.ToInt16(nudG1.Value);
            int _firstFrameW = Convert.ToInt16(nudF1.Value);
            int _secondGalssW = Convert.ToInt16(nudG2.Value);
            int _secondFrameW = Convert.ToInt16(nudF2.Value);
            int _thirdGlassW = Convert.ToInt16(nudG3.Value);

            if (cbCamNums.SelectedIndex<0)
                return;

            Point _point1 = new Point(120, 80);
            Point _point2 = new Point(_point1.X + _firstGlassW * 5 + _firstFrameW * 5 + _butilTh * 2, _point1.Y);
            Point _point3 = new Point(_point2.X + +(_secondGalssW * 5 + _secondFrameW * 5 + _butilTh * 2), _point2.Y);

            if (cbCamNums.SelectedIndex>=0)
            {
                DrowGlass(e.Graphics, _point1, 180, Color.RoyalBlue, Color.DodgerBlue, Color.White, _firstGlassW);
                DrowGlassWithFrame(e.Graphics, _point2, 180,
                        Color.RoyalBlue, Color.DodgerBlue, Color.White, _secondGalssW, _firstFrameW);
            }

            if (cbCamNums.SelectedIndex >=1)
                DrowGlassWithFrame(e.Graphics, _point3, 180, 
                    Color.RoyalBlue, Color.DodgerBlue, Color.White, _thirdGlassW, _secondFrameW);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer.Panel2.Refresh();
            EnabledCheck();
        }

        private void EnabledCheck()
        {
            nudF2.Enabled = (cbCamNums.SelectedIndex >= 1);
            nudG3.Enabled = (cbCamNums.SelectedIndex >= 1);
            label9.Enabled = (cbCamNums.SelectedIndex >= 1);
            label10.Enabled = (cbCamNums.SelectedIndex >= 1);
            label6.Enabled = (cbCamNums.SelectedIndex >= 1);
            label4.Enabled = (cbCamNums.SelectedIndex >= 1);
        }

        private void DrowGlass(Graphics graph, Point leftTop, int height, Color contur, Color firstColor, Color secondColor, int glassWidth)
        {
            int PadX = leftTop.X;
            int PadY = leftTop.Y;

            int glassH = height;
            int glassW = glassWidth * 5;

            Pen _pen = new Pen(contur);


            Point _point1 = new Point(PadX, PadY);
            Point _point2 = new Point(_point1.X + glassW, PadY);
            Point _point3 = new Point(PadX, _point1.Y + glassH);
            Point _point4 = new Point(_point2.X, _point2.Y + glassH);
            Point _point5 = new Point(_point3.X - glassH / 2, _point3.Y + glassH / 3);
            Point _point6 = new Point(_point5.X + glassW, _point5.Y);
            Point _point7 = new Point(_point5.X, _point5.Y - glassH / 2);
            Point _point8 = new Point(_point7.X + glassW, _point7.Y);
            Point _point9 = new Point(_point1.X - glassH / 5, _point1.Y + glassH / 6);
            Point _point10 = new Point(_point9.X + glassW, _point9.Y);

            Point[] _backSidePoligon = new Point[] 
            {
                _point1, _point2, _point4, _point3
            };

            Point[] _bottomPoligon = new Point[] 
            { 
                _point3, _point4, _point6, _point5
            };

            Point[] _frontPoligon = new Point[]
            {
                _point7, _point8, _point6, _point5
            };

            Point[] _topPoligone = new Point[]
            {
                _point1, _point2, _point10, _point9
            };

            Point[] _faskPoligon = new Point[]
            {
                _point9, _point10, _point8, _point7
            };

            Point[] _outSide = new Point[]
            {
                _point1, _point3, _point5, _point7, _point9
            };


            LinearGradientBrush _outSideBrush = new LinearGradientBrush(_point1, _point5, firstColor, secondColor);
            LinearGradientBrush _frontBrush = new LinearGradientBrush(_point7, _point5, firstColor, secondColor);
            LinearGradientBrush _faskBrush = new LinearGradientBrush(_point10, _point7, firstColor, secondColor);
            LinearGradientBrush _tpoBrush = new LinearGradientBrush(_point2, _point9, firstColor, secondColor);

            Brush _soludGlass = new SolidBrush(firstColor);

            //graph.DrawRectangle(_pen, _backGlassSide.X, _backGlassSide.Y, _backGlassSide.Width, _backGlassSide.Height);
            //graph.FillRectangle(_soludGlass, _backGlassSide.X, _backGlassSide.Y, _backGlassSide.Width, _backGlassSide.Height);

            graph.FillPolygon(_outSideBrush, _outSide);
            graph.FillPolygon(_faskBrush, _faskPoligon);
            graph.FillPolygon(_tpoBrush, _topPoligone);

            graph.FillPolygon(_soludGlass, _backSidePoligon);
            graph.FillPolygon(_soludGlass, _bottomPoligon);


            graph.DrawPolygon(_pen, _backSidePoligon);
            graph.DrawPolygon(_pen, _bottomPoligon);
            graph.DrawPolygon(_pen, _topPoligone);
            graph.DrawPolygon(_pen, _faskPoligon);

            graph.FillPolygon(_frontBrush, _frontPoligon);
            graph.DrawPolygon(_pen, _frontPoligon);


        }

        private void DrowGlassWithFrame(Graphics graph, Point leftTop, int height, Color contur, Color firstColor, Color secondColor, int glassWidth,
            int frameWidth)
        {
            int PadX = leftTop.X;
            int PadY = leftTop.Y;

            int frameTh = 3;//толщина стенки рамки
            int butilTh = 2;//толщина бутилового шнура

            int glassH = height;
            int glassW = glassWidth*5;
            int frameW = frameWidth*5;
            int frameWithButilW = frameWidth*5 + 2 * butilTh;


            Pen _pen = new Pen(contur);
                      

            Point _point1 = new Point(PadX, PadY);
            Point _point2 = new Point(_point1.X + glassW, PadY);
            Point _point3 = new Point(PadX, _point1.Y + glassH);
            Point _point4 = new Point(_point2.X, _point2.Y + glassH);
            Point _point5 = new Point(_point3.X - glassH/2, _point3.Y + glassH/3);
            Point _point6 = new Point(_point5.X + glassW, _point5.Y);
            Point _point7 = new Point(_point5.X, _point5.Y - glassH/2);
            Point _point8 = new Point(_point7.X + glassW, _point7.Y);
            Point _point9 = new Point(_point1.X - glassH/5, _point1.Y + glassH/6 );
            Point _point10 = new Point(_point9.X + glassW, _point9.Y);
            Point _point11 = new Point(_point3.X, _point3.Y - glassW/3);
            Point _point12 = new Point(_point5.X, _point5.Y - glassW/3);
            Point _point13 = new Point(_point3.X, _point3.Y - frameWithButilW*2/3);
            Point _point14 = new Point(_point5.X, _point5.Y - frameWithButilW*2/3);
            Point _point15 = new Point(_point13.X - frameWithButilW, _point13.Y);
            Point _point16 = new Point(_point14.X - frameWithButilW, _point14.Y);
            Point _point17= new Point(_point5.X - frameWithButilW, _point5.Y);

            Point[] _backSidePoligon = new Point[] 
            {
                _point1, _point2, _point4, _point3
            };

            Point[] _bottomPoligon = new Point[] 
            { 
                _point3, _point4, _point6, _point5
            };

            Point[] _frontPoligon = new Point[]
            {
                _point7, _point8, _point6, _point5
            };

            Point[] _topPoligone = new Point[]
            {
                _point1, _point2, _point10, _point9
            };

            Point[] _faskPoligon = new Point[]
            {
                _point9, _point10, _point8, _point7
            };

            Point[] _outSide = new Point[]
            {
                _point1, _point3, _point5, _point7, _point9
            };

            Point[] _butilBorderOutSide = new Point[]
            {
                _point3, _point5, _point12, _point11
            };

            Point[] _glassFrameContact = new Point[]
            {
                _point11, _point12, _point14, _point13
            };

            Point[] _frameTop = new Point[]
            {
                _point13, _point14, _point16, _point15
            };

            Point[] _frameFronntSulfat = new Point[]
            {
                _point14, _point16, _point17, _point5
            };

            LinearGradientBrush _outSideBrush = new LinearGradientBrush(_point1, _point5, firstColor, secondColor);
            LinearGradientBrush _frontBrush = new LinearGradientBrush(_point7, _point5, firstColor, secondColor);
            LinearGradientBrush _faskBrush = new LinearGradientBrush(_point10, _point7, firstColor, secondColor);
            LinearGradientBrush _tpoBrush = new LinearGradientBrush(_point2, _point9, firstColor, secondColor);

            Brush _soludGlass = new SolidBrush(firstColor);
            Brush _butilBorderBrush = new SolidBrush(Color.DarkGray);
            Brush _butilBrush = new SolidBrush(Color.Black);
            Brush _frameBrush = new SolidBrush(Color.LightGray);
            Pen _blackPen = new Pen(_butilBrush);

            //graph.DrawRectangle(_pen, _backGlassSide.X, _backGlassSide.Y, _backGlassSide.Width, _backGlassSide.Height);
            //graph.FillRectangle(_soludGlass, _backGlassSide.X, _backGlassSide.Y, _backGlassSide.Width, _backGlassSide.Height);

            graph.FillPolygon(_outSideBrush, _outSide);
            graph.FillPolygon(_butilBorderBrush, _butilBorderOutSide);
            graph.FillPolygon(_butilBrush, _glassFrameContact);
            graph.FillPolygon(_frameBrush, _frameTop);
            graph.DrawPolygon(_blackPen, _frameTop);

            //рисуем перфорацию
            graph.DrawLine(_blackPen, 
                new Point(_point15.X + frameWithButilW / 2 - 2, _point15.Y), 
                new Point(_point16.X + frameWithButilW/2 -2, _point16.Y));
            graph.DrawLine(_blackPen,
                new Point(_point15.X + frameWithButilW / 2 + 2, _point15.Y),
                new Point(_point16.X + frameWithButilW / 2 + 2, _point16.Y));

            graph.FillPolygon( _butilBrush, _frameFronntSulfat);

            graph.FillPolygon(_faskBrush, _faskPoligon);
            graph.FillPolygon(_tpoBrush, _topPoligone);
            
            graph.FillPolygon(_soludGlass, _backSidePoligon);
            graph.FillPolygon(_soludGlass, _bottomPoligon);


            graph.DrawPolygon(_pen, _backSidePoligon);
            graph.DrawPolygon(_pen, _bottomPoligon);
            graph.DrawPolygon(_pen, _topPoligone);
            graph.DrawPolygon(_pen, _faskPoligon);

            graph.FillPolygon(_frontBrush, _frontPoligon);
            graph.DrawPolygon(_pen, _frontPoligon);



            //рисуем срез рамки
            Point _point18 = new Point(_point14.X - butilTh, _point14.Y);
            Point _point19 = new Point(_point16.X + butilTh, _point16.Y);
            Point _point20 = new Point(_point19.X, _point19.Y + frameW*2/5);
            Point _point21 = new Point(_point17.X + butilTh + frameW / 4, _point17.Y- butilTh*2);
            Point _point22 = new Point(_point21.X + frameW/2, _point21.Y);
            Point _point23 = new Point(_point18.X, _point18.Y + frameW*2/5);

            Point _point24 = new Point(_point18.X - frameTh, _point18.Y + frameTh);
            Point _point25 = new Point(_point19.X + frameTh, _point19.Y + frameTh);
            Point _point26 = new Point(_point20.X + frameTh, _point20.Y - frameTh);
            Point _point27 = new Point(_point21.X + frameTh, _point21.Y - frameTh);
            Point _point28 = new Point(_point22.X - frameTh, _point21.Y - frameTh);
            Point _point29 = new Point(_point23.X - frameTh, _point23.Y - frameTh);

            Point[] _frame = new Point[]
            {
                _point18, _point19, _point20, _point21, _point22, _point23
            };

            Point[] _frameInsie = new Point[]
            {
                _point24, _point25, _point26, _point27, _point28, _point29
            };

            graph.FillPolygon(_frameBrush, _frame);
            graph.DrawPolygon(_blackPen , _frame);

            Brush _insideFrameBrush = new SolidBrush(Color.SeaShell);
            graph.FillPolygon(_insideFrameBrush, _frameInsie);
            graph.DrawPolygon(_blackPen, _frameInsie);
        }
    }
}
