using System;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Shape.Factory;
using Socrat.UI.Core;
using System.Windows.Forms;
using System.Linq;

namespace Socrat.Module.Order.Processings
{
    public partial class FxSideProcessing : FxBaseSimpleDialog
    {
        MultipleSideChoiser _multipleSideChoiser;
        private Point cursor = new Point();
        private float XProp { get; set; }
        private float YProp { get; set; }
        public FxSideProcessing()
        {
            InitializeComponent();
            Load += FxSideProcessing_Load;
            _multipleSideChoiser = new MultipleSideChoiser();
            peShape.Properties.SizeMode = PictureSizeMode.Zoom;
            _multipleSideChoiser.SideChoiseChanged += MultipleSideChoiserMultipleSideChoiseChanged;
            peShape.MouseClick += PeShape_MouseClick;
            peShape.Properties.ContextMenuStrip = new ContextMenuStrip();
            peShape.MouseMove += PeShape_MouseMove;
        }

        private void PeShape_MouseMove(object sender, MouseEventArgs e)
        {
            ParseCurrentCoordinates(e);
        }

        private void ParseCurrentCoordinates(MouseEventArgs e)
        {
            var x = e.X;
            var y = e.Y;
            YProp = e.Y;
            XProp = e.X;
            var pkbDrawW = peShape.Image.Width;
            var pkbDrawH = peShape.Image.Height;

            var pkbDrawWs = peShape.ClientSize.Width;
            var pkbDrawHs = peShape.ClientSize.Height;

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
            cursor.X = (int)XProp;
            cursor.Y = (int)YProp;
        }
        public double SelectedSideLength { get; set; }
        private void PeShape_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedSideLength = 0;
            bool flag = false;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    flag = true;
                    break;

                case MouseButtons.Right:
                    flag = false;
                    break;
                default:
                    break;
            }
            shape.SelectedShape.SelectClickedSide((int)XProp, (int)YProp, flag);
            flag = false;
            shape.SelectedShape.InitShape(peShape);
            int[] _selectedSides = shape.SelectedShape.GetSelectedSides();
            SelectedSideLength = shape.SelectedShape.SelectedSidesLength / 1000;
            _multipleSideChoiser.SetChosenSides(_selectedSides);
            labelControl3.Text = $"  Выбраны стороны: {string.Join(",", _selectedSides)} длина: {SelectedSideLength} м.";
            gvSides.RefreshData();
        }




        private void MultipleSideChoiserMultipleSideChoiseChanged(int[] sideNums)
        {
            shape.SelectedShape.SelectColorMarker(sideNums);
            shape.SelectedShape.CalculateSelectedSideLength(sideNums.ToList());
            //foreach (int sideNum in sideNums)
            //    shape.SelectedShape.SelectColorMarker(sideNum);
            //  shape.SelectedShape.ColorMarker = $"rowCheckCut{SelectColorMarker(int i)}";
            shape.SelectedShape.InitShape(peShape);
            labelControl3.Text = $"  Выбраны стороны: {string.Join(",", sideNums)} длина: {shape.SelectedShape.SelectedSidesLength / 1000} м.";
        }

        public SideProcessing SideProcessing { get; set; }
        public OrderRow OrderRow { get; set; }
        private CurrentUserShape shape = new CurrentUserShape();

        private void FxSideProcessing_Load(object sender, EventArgs e)
        {
            peShape.SuspendLayout();
            DrawNewShape(OrderRow.ShapeId ?? Guid.Empty);
            _multipleSideChoiser.SideProcessing = SideProcessing;
            var num = shape.GetCatalogNumberById(OrderRow.ShapeId ?? Guid.Empty);
            var selector = (num == 62) ? shape.Selector + 1 : shape.Selector;
            gcSides.DataSource = _multipleSideChoiser.GetSidesDataSource(selector);
            MultipleSideChoiserMultipleSideChoiseChanged(_multipleSideChoiser.GetChosenSides());
            peShape.ResumeLayout();
        }

        protected override IEntity GetEntity()
        {
            return SideProcessing;
        }

        protected override void SetEntity(IEntity value)
        {
            SideProcessing = value as SideProcessing;
        }
        private void InitShape()
        {
            shape.SelectedShape.InitShape(peShape);
            shape.SelectedShape.IsDrawSideNumbers = true;
        }
        private void DrawNewShape(Guid number)
        {
            peShape.Refresh();
            shape.Selector_Id = number;
            shape.IsCanDrawSizeLines = true;
            shape.GetShape.IsDrawSideNumbers = true;
            shape.GetShape.InitShape(peShape);
            shape.GetShape.IsDrawSideNumbers = true;
            InitShape();
            peShape.Focus();
        }

        private void repositoryItemCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            gvSides.PostEditor();
        }

        public override bool Validate()
        {
            return true;
        }
    }
}