using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Lib;
using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxModuleEdit : FxBaseSimpleDialog
    {
        private Core.Entities.Module _module;

        public FxModuleEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return _module;
        }

        protected override void SetEntity(IEntity value)
        {
            _module = value as Core.Entities.Module;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(beModule, _module, x => x.Name);
            BindEditor(teTitle, _module, x => x.ModuleName);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beModule, teTitle };
        }

        private void beModule_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int _tag = 0;
            if (e.Button.Tag != null)
                int.TryParse(e.Button.Tag.ToString(), out _tag);

            switch (_tag)
            {
                case 0:
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = Application.StartupPath;
                        DialogResult dlgRes = openFileDialog.ShowDialog(this);
                        if (dlgRes != DialogResult.Cancel)
                        {
                            FileInfo _fi = new FileInfo(openFileDialog.FileName);
                            string _name = _fi.Name.Replace(_fi.Extension, string.Empty);
                            beModule.EditValue = _name;
                        }
                    }
                    break;
                case 1:
                    break;
            }
        }
    }
}