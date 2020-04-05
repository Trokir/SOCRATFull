using System;
using System.Drawing;
using Socrat.Core.Entities;
using Socrat.Module.Order.Processings;
using Socrat.Shape.Factory;
using Socrat.UI.Core;
using System.Windows.Forms;

namespace Socrat.Module.Order
{
    public partial class FxBaseSideEdit : FxBaseSimpleDialog
    {
        public OrderRow OrderRow { get; set; }
        private CurrentUserShape shape = new CurrentUserShape();
        private Point cursor = new Point();
        private float XProp { get; set; }
        private float YProp { get; set; }
       
        SingleSideChoiser _singleSideChoiser;

        public FxBaseSideEdit()
        {
            InitializeComponent();
            InitializeComponent();
            Load += FxBaseSideEdit_Load;
           // graphics = peShape.CreateGraphics();
            _singleSideChoiser = new SingleSideChoiser();
            _singleSideChoiser.SideChoiseChanged += SingleSideChoiseChanged;
            peShape.MouseClick += PeShape_MouseClick;
            peShape.MouseMove += PeShape_MouseMove;
        }

        private void PeShape_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ParseCurrentCoordinates(e);
        }

        private void PeShape_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
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
           // graphics.Clear(Color.White);
            shape.SelectedShape.InitShape(peShape);
            int _selectedSides = shape.SelectedShape.ClickedSelectSide;
            _singleSideChoiser.SetChosenSide(_selectedSides);
            gvSides.RefreshData();
        }

        private void SingleSideChoiseChanged(int[] sideNums)
        {
            peShape.SuspendLayout();
            if (sideNums[0]!= 0)
            {
                shape.SelectedShape.SelectColorMarker(sideNums);
            }

           // graphics.Clear(Color.White);
            shape.SelectedShape.InitShape(peShape);
            peShape.ResumeLayout();
            gvSides.RefreshData();
        }


        private void FxBaseSideEdit_Load(object sender, EventArgs e)
        {
            peShape.SuspendLayout();
            DrawNewShape(OrderRow.ShapeId ?? Guid.Empty);
            _singleSideChoiser.SelectedSide = OrderRow.BaseSide ?? shape.Selector;
            gcSides.DataSource = _singleSideChoiser.GetSidesDataSource(shape.Selector);
            SingleSideChoiseChanged(new int[] { _singleSideChoiser.SelectedSide });
            peShape.ResumeLayout();
        }
        private void InitShape()
        {
            shape.SelectedShape.IsDrawSideNumbers = true;
            shape.SelectedShape.InitShape(peShape);
            shape.SelectedShape.IsDrawSideNumbers = true;
        }
        private void DrawNewShape(Guid number)
        {
           // graphics.Dispose();
           // graphics = peShape.CreateGraphics();
            peShape.Refresh();
            shape.Selector_Id = number;
            shape.IsCanDrawSizeLines = true;
            shape.GetShape.IsDrawSideNumbers = true;
            shape.GetShape.InitShape(peShape);
            shape.GetShape.IsDrawSideNumbers = true;
            //pgSides.SelectedObject = null;
            //pgSides.SelectedObject = shape.GetShape;
           // graphics.Clear(Color.White);
            InitShape();
            peShape.Focus();
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
        private void repositoryItemCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            gvSides.PostEditor();
        }

        public override bool Validate()
        {
            return true;
        }

        protected override void SaveButtonClicked()
        {
            OrderRow.BaseSide = (byte)_singleSideChoiser.SelectedSide;
            base.SaveButtonClicked();
        }
    }
}