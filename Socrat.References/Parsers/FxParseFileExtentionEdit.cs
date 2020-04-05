using Socrat.Core;
using Socrat.Core.Entities.Parsers;
using Socrat.UI.Core;

namespace Socrat.References.Parsers
{
    public partial class FxParseFileExtentionEdit : FxBaseSimpleDialog
    {
        public ParseFileExtention Extention { get; set; }

        public FxParseFileExtentionEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return Extention;
        }

        protected override void SetEntity(IEntity value)
        {
            Extention = value as ParseFileExtention;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teExt, Extention, x => x.Name);
            BindEditor(teComment, Extention, x => x.Comment);
        }
    }
}