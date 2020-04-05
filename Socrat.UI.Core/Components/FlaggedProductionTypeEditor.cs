using DevExpress.XtraEditors;
using Socrat.Common.Enums;
using System.ComponentModel;

namespace Socrat.UI.Core
{
    public class FlaggedProductionTypeEditor : XtraUserControl
    {
        [Bindable(true)]
        public FlaggedProductionTypeEditor()
        {
            InitializeComponent();
            cheSpo.Tag = FlaggedProductionTypes.SPO;
            cheSpd.Tag = FlaggedProductionTypes.SPD;
            chePackage.Tag = FlaggedProductionTypes.Package;
            cheTriplex.Tag = FlaggedProductionTypes.Triplex;
            cheGlass.Tag = FlaggedProductionTypes.Glass;
        }

        [Bindable(true)]
        public FlaggedProductionTypes FlaggedProductionType 
        {
            get
            {
                return
                    (cheSpo.Checked 
                        ?(cheSpo.Tag is FlaggedProductionTypes flagSpo 
                            ? flagSpo 
                            : FlaggedProductionTypes.Unknown)
                        : FlaggedProductionTypes.Unknown)
                    |
                    (cheSpd.Checked 
                        ? (cheSpd.Tag is FlaggedProductionTypes flagSpd 
                            ? flagSpd 
                            : FlaggedProductionTypes.Unknown)
                        : FlaggedProductionTypes.Unknown)
                        |
                    (chePackage.Checked
                        ? (chePackage.Tag is FlaggedProductionTypes flagPackage
                            ? flagPackage
                            : FlaggedProductionTypes.Unknown)
                        : FlaggedProductionTypes.Unknown)
                    |
                    (cheTriplex.Checked 
                        ? (cheTriplex.Tag is FlaggedProductionTypes flagTriplex 
                            ? flagTriplex 
                            : FlaggedProductionTypes.Unknown)
                        : FlaggedProductionTypes.Unknown)
                    |
                    (cheGlass.Checked 
                        ? (cheGlass.Tag is FlaggedProductionTypes flagGlass 
                            ? flagGlass 
                            : FlaggedProductionTypes.Unknown)
                        : FlaggedProductionTypes.Unknown);
            }
            set
            {
                cheSpo.Checked = (value & FlaggedProductionTypes.SPO) == FlaggedProductionTypes.SPO;
                cheSpd.Checked = (value & FlaggedProductionTypes.SPD) == FlaggedProductionTypes.SPD;
                chePackage.Checked = (value & FlaggedProductionTypes.Package) == FlaggedProductionTypes.Package;
                cheGlass.Checked = (value & FlaggedProductionTypes.Glass) == FlaggedProductionTypes.Glass;
                cheTriplex.Checked = (value & FlaggedProductionTypes.Triplex) == FlaggedProductionTypes.Triplex;
            } 
        }

        #region Designer        

        private GroupControl gcMain;
        private CheckEdit cheTriplex;
        private CheckEdit cheGlass;
        private CheckEdit cheSpd;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private CheckEdit chePackage;
        private CheckEdit cheSpo;

        private void InitializeComponent()
        {
            this.gcMain = new DevExpress.XtraEditors.GroupControl();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.cheSpo = new DevExpress.XtraEditors.CheckEdit();
            this.cheSpd = new DevExpress.XtraEditors.CheckEdit();
            this.cheGlass = new DevExpress.XtraEditors.CheckEdit();
            this.cheTriplex = new DevExpress.XtraEditors.CheckEdit();
            this.chePackage = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            this.gcMain.SuspendLayout();
            this.flpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cheSpo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheSpd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheGlass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheTriplex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chePackage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMain
            // 
            this.gcMain.Controls.Add(this.flpMain);
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(2, 2);
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(178, 184);
            this.gcMain.TabIndex = 6;
            this.gcMain.Text = "Применимость к изделиям";
            // 
            // flpMain
            // 
            this.flpMain.AutoSize = true;
            this.flpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpMain.Controls.Add(this.cheSpo);
            this.flpMain.Controls.Add(this.cheSpd);
            this.flpMain.Controls.Add(this.chePackage);
            this.flpMain.Controls.Add(this.cheGlass);
            this.flpMain.Controls.Add(this.cheTriplex);
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMain.Location = new System.Drawing.Point(2, 20);
            this.flpMain.Name = "flpMain";
            this.flpMain.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.flpMain.Size = new System.Drawing.Size(174, 162);
            this.flpMain.TabIndex = 5;
            // 
            // cheSpo
            // 
            this.cheSpo.Location = new System.Drawing.Point(6, 6);
            this.cheSpo.Name = "cheSpo";
            this.cheSpo.Properties.Caption = "Однокамерный стеклопакет";
            this.cheSpo.Size = new System.Drawing.Size(174, 19);
            this.cheSpo.TabIndex = 1;
            this.cheSpo.Tag = "";
            // 
            // cheSpd
            // 
            this.cheSpd.Location = new System.Drawing.Point(6, 31);
            this.cheSpd.Name = "cheSpd";
            this.cheSpd.Properties.Caption = "Двухкамерный стеклопакет";
            this.cheSpd.Size = new System.Drawing.Size(174, 19);
            this.cheSpd.TabIndex = 2;
            // 
            // cheGlass
            // 
            this.cheGlass.Location = new System.Drawing.Point(6, 81);
            this.cheGlass.Name = "cheGlass";
            this.cheGlass.Properties.Caption = "Нарезка стекла";
            this.cheGlass.Size = new System.Drawing.Size(136, 19);
            this.cheGlass.TabIndex = 3;
            // 
            // cheTriplex
            // 
            this.cheTriplex.Location = new System.Drawing.Point(6, 106);
            this.cheTriplex.Name = "cheTriplex";
            this.cheTriplex.Properties.Caption = "Изготовление триплекса";
            this.cheTriplex.Size = new System.Drawing.Size(166, 19);
            this.cheTriplex.TabIndex = 4;
            // 
            // chePackage
            // 
            this.chePackage.Location = new System.Drawing.Point(6, 56);
            this.chePackage.Name = "chePackage";
            this.chePackage.Properties.Caption = "Любой стеклопакет";
            this.chePackage.Size = new System.Drawing.Size(174, 19);
            this.chePackage.TabIndex = 5;
            // 
            // FlaggedProductionTypeEditor
            // 
            this.Controls.Add(this.gcMain);
            this.Name = "FlaggedProductionTypeEditor";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(182, 188);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            this.gcMain.ResumeLayout(false);
            this.gcMain.PerformLayout();
            this.flpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cheSpo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheSpd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheGlass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheTriplex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chePackage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
