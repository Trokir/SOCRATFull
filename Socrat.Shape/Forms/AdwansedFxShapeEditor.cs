using Socrat.UI.Core;
using System.Drawing;

namespace Socrat.Shape.Forms
{
    public partial class FxShapeEditor 
    {
        private void PrpGrid_CustomDrawRowHeaderCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowHeaderCellEventArgs e)
        {
            switch (e.Row.Name)
            {
                case "rowPerimeter":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Black;
                    break;
                case "rowPerimeter_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Black;
                    break;
                case "rowBaseArea":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Black;
                    break;
                case "rowArea":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Black;
                    break;
                case "rowTrueArea":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Black;
                    break;
                case "rowShapeKisPersent":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Black;
                    break;
                case "rowShapeKis":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Black;
                    break;

                case "row IsSelectSameAllowance":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowCheckCut1":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowCheckCut2":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowCheckCut3":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowCheckCut4":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowCheckCut5":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowCheckCut6":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowCheckCut7":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowCheckCut8":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;

                case "rowSetH":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetH1":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetH2":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetL":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;


                case "rowSetH_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;

                case "rowSetH1_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetH2_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetL_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetL1_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetL2_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;



                case "rowSetL1":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetL2":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius1_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius2_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius3_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius4_t":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius1":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius2":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius3":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetRadius4":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;
                case "rowSetChord":
                    e.Appearance.BackColor = Color.Silver;
                    e.Appearance.ForeColor = Color.Red;
                    break;


                //default:
                //    e.Appearance.BackColor = Color.Silver;
                //    e.Appearance.ForeColor = Color.Black;
                //    break;
            }
        }

        private void PrpGrid_CustomPropertyDescriptors(object sender, DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventArgs e)
        {
            shape.SelectedShape.AddCustomProperties(sender, e);
        }
    }
}