using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.UI.Core;
using DevExpress.XtraEditors.Controls;
using Socrat.Shape.Shproses;

namespace Socrat.Shape
{
    public partial class FxShprosEditor : FxBaseSimpleDialog
    {
        public Guid? Id_ForOrder { get; set; }
        public BaseShape BShape { get; set; }
        Graphics graphics;

        public FxShprosEditor()
        {
            InitializeComponent();
            graphics = pkbEdit.CreateGraphics();
            pkbEdit.Properties.SizeMode = PictureSizeMode.Squeeze;
            pkbEdit.Properties.ContextMenuStrip = new ContextMenuStrip();
            Load += FxShprosEditor_Load;
            Paint += FxShprosEditor_Paint;
        }

        private void FxShprosEditor_Paint(object sender, PaintEventArgs e)
        {
            graphics.Clear(Color.White);
            Shpros<BaseShape>.DrawShape(pkbEdit);
            Refresh();
        }

        private void FxShprosEditor_Load(object sender, EventArgs e)
        {
            if (BShape!=null)
            {
                //labelControl1.Text = BShape.ToString();
                //labelControl2.Text = Shpros<BaseShape>.A_Point.ToString();
            }
        }

        public void SavePicture(PictureEdit edit)
        {
            Image image = pkbEdit.Image.Clone() as Image;
            edit.Properties.SizeMode = PictureSizeMode.Squeeze;
            edit.Image.Dispose();
            edit.Image = image;
        }
    }
}