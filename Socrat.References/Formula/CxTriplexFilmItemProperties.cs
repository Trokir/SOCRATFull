using DevExpress.Utils.Extensions;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;

namespace Socrat.References.Formula
{
    public partial class CxTriplexFilmItemProperties : CxFormulaItemProperties
    {
        public CxTriplexFilmItemProperties()
        {
            InitializeComponent();
        }

        private TriplexFilmItem _triplexFilmItem;
        public TriplexFilmItem TriplexFilmItem
        {
            get => _triplexFilmItem;
            set => SetTriplexFilmItem(value);
        }

        private void SetTriplexFilmItem(TriplexFilmItem value)
        {
            _triplexFilmItem = value;
            if (_triplexFilmItem.ParentItem?.MaterialNom?.IsReferenceTriplex() ?? false)
                SetReadOnlyView();
        }

        private void SetReadOnlyView()
        {
            beMaterialNom.Properties.UseReadOnlyAppearance = false;
            beMaterialNom.ReadOnly = true;
            beMaterialNom.Properties.Buttons.ForEach(x => x.Enabled = false);
        }

        public MaterialNom MaterialNom
        {
            get { return TriplexFilmItem?.MaterialNom; }
        }

        public override void BindData()
        {
            beMaterialNom.EditValue = MaterialNom.Code;
        }

        private void SelectMaterialNom()
        {
            SetupMaterial(MaterialEnum.TriplexFilm, TriplexFilmItem);
        }

        protected override void UpdateComponent()
        {
            beMaterialNom.EditValue = TriplexFilmItem.MaterialNom.Code;
            OnNeedUpdateParentView(TriplexFilmItem);
        }

        private void beMaterialNom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectMaterialNom();
        }
    }
}
