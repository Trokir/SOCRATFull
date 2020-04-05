using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Lib;
using Socrat.Log;
using Socrat.References.Formula;
using Socrat.UI.Core;

namespace Socrat.References.Processings
{
    public partial class FxSurfaceCoverProtectionEdit : FxBaseSimpleDialog
    {
        public SurfaseProcessing SurfaseProcessing { get; set; }
        public CxProcessingComponents _CxProcessingComponents;

        public FxSurfaceCoverProtectionEdit()
        {
            InitializeComponent();
            Load += FxSurfaceCoverProtectionEdit_Load;
        }

        private void InitItems()
        {
            _CxProcessingComponents = new CxProcessingComponents();
            _CxProcessingComponents.FormulaItemProcessing = SurfaseProcessing;
            _CxProcessingComponents.DependedSaving = true;
            _CxProcessingComponents.DialogOutput += _CxProcessingComponents_DialogOutput;
            pcItems.Controls.Add(_CxProcessingComponents);
            _CxProcessingComponents.Dock = DockStyle.Fill;
        }

        private void _CxProcessingComponents_DialogOutput(object sender, WindowOutputEventArgs e)
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
    }
}