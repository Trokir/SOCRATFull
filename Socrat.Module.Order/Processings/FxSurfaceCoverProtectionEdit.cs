using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Lib;
using Socrat.Log;
using Socrat.Module.Order.Processings;
using Socrat.References.Formula;
using Socrat.UI.Core;

namespace Socrat.References.Processings
{
    public partial class FxSurfaceCoverProtectionEdit : FxBaseSimpleDialog
    {
        public SurfaseProcessing SurfaseProcessing { get; set; }

        public CxIdentProcessingsComponents _CxIdentProcessingsComponents;

        public OrderRow OrderRow { get; set; }

        private bool SideButtonClicked = false;

        public FxSurfaceCoverProtectionEdit()
        {
            InitializeComponent();
            Load += FxSurfaceCoverProtectionEdit_Load;
        }

        private void InitItems()
        {
            _CxIdentProcessingsComponents = new CxIdentProcessingsComponents();
            _CxIdentProcessingsComponents.OrderRow = OrderRow;
            _CxIdentProcessingsComponents.FormulaItemProcessing = SurfaseProcessing;
            _CxIdentProcessingsComponents.DependedSaving = true;
            _CxIdentProcessingsComponents.DialogOutput += CxIdentProcessingsComponentsDialogOutput;
            pcItems.Controls.Add(_CxIdentProcessingsComponents);
            _CxIdentProcessingsComponents.Dock = DockStyle.Fill;
        }

        private void CxIdentProcessingsComponentsDialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        private void FxSurfaceCoverProtectionEdit_Load(object sender, EventArgs e)
        {
            InitItems();
            UpdateFig();
        }

        protected override void BindData()
        {
            base.BindData();
            lcSurfaceNum.DataBindings.Add("Text", SurfaseProcessing, "SurfaceTitle", false,
                DataSourceUpdateMode.OnPropertyChanged);
        }

        private void UpdateFig()
        {
            Image img = new Bitmap(peFig.ClientRectangle.Width, peFig.ClientRectangle.Height);
            using (Graphics graph = Graphics.FromImage(img))
            {   try
                {
                    FormulaDrawer.DrawItemSurfaces(SurfaseProcessing, graph, peFig.Location,
                        SurfaseProcessing.FormulaItem.Formula);
                }
                catch (Exception e)
                {
                    Logger.AddErrorEx("UpdateFig", e);
                }
            }
            peFig.Image = img;
        }
        
        protected override IEntity GetEntity()
        {
            return SurfaseProcessing;
        }

        protected override void SetEntity(IEntity value)
        {
            SurfaseProcessing = value as SurfaseProcessing;
        }

        private void peFig_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (SideButtonClicked)
                return;
            Image img = new Bitmap(peFig.ClientRectangle.Width, peFig.ClientRectangle.Height);
            using (Graphics graph = Graphics.FromImage(img))
            {
                try
                {
                    SurfaseProcessing.CheckSurfaceSelectedChanged(e.Location);
                    FormulaDrawer.DrawItemSurfaces(SurfaseProcessing, graph, peFig.Location, SurfaseProcessing.FormulaItem.Formula);
                }
                catch (Exception ex)
                {
                    Logger.AddErrorEx("UpdateFig", ex);
                }
            }
            peFig.Image = img;
        }

        public override bool Validate()
        {
            return true;
        }

        private void peFig_Properties_ContextButtonClick(object sender, ContextItemClickEventArgs e)
        {
            int _tag = -1;
            if (e.Item.Tag != null && int.TryParse(e.Item.Tag.ToString(), out _tag))
            {
                switch (_tag)
                {
                    case 0:
                        EditEdge();
                        break;
                    case 1:
                        SideButtonClicked = true;
                        SurfaseProcessing.SelectedSurface = 1;
                        lcSurfaceNum.Text = SurfaseProcessing.SurfaceTitle;
                        SideButtonClicked = false;
                        break;
                    case 2:
                        SideButtonClicked = true;
                        SurfaseProcessing.SelectedSurface = 2;
                        lcSurfaceNum.Text = SurfaseProcessing.SurfaceTitle;
                        SideButtonClicked = false;
                        break;
                }
            }
        }

        private void EditEdge()
        {
            FxEdgeProcessingEdit _fx = new FxEdgeProcessingEdit();
            _fx.OrderRow = OrderRow;
            _fx.FormulaItemProcessing = SurfaseProcessing;
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }
    }
}