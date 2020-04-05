using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using Socrat.Core;
using Socrat.UI.Core;

namespace Socrat.Startup
{
    public class TabManager: List<TabForm>
    {

        public void AppendTab(BaseDocument document)
        {
            FxBaseForm _fx = document.Form as FxBaseForm;
            Add(new TabForm { Form = _fx, Document =  document});
        }

        public void SetChildDialog(BaseDocument document)
        {
            FxBaseForm _fx = document.Form as FxBaseForm;
            Add(new TabForm { Form = _fx, Document = document });

            FxBaseForm _owner = _fx.TabParent;
            Guid _id = _owner.ModuleId;
            TabForm _tabItem = this.FirstOrDefault(x => x.Id == _id);
            
            if (_tabItem != null)
            {
                _tabItem.ChaildModalForm = ((FxBaseForm)document.Form);
                _tabItem.ChaildDocument = document;
            }
        }

        private void SetChildDialogModal(BaseDocument doc)
        {
            FxBaseForm _fx = doc.Form as FxBaseForm;
            Add(new TabForm { Form = _fx, Document = doc });

            FxBaseForm _owner = _fx.TabParent;
            Guid _id = _owner.ModuleId;
            TabForm _tabItem = this.FirstOrDefault(x => x.Id == _id);

            if (_tabItem != null)
            {
                _tabItem.ChaildModalForm = ((FxBaseForm)doc.Form);
                _tabItem.ChaildDocument = doc;
                _tabItem.IsModal = true;
                _tabItem.Form.LockFockus = true;
                //_tabItem.Form.Enabled = false;
                //_tabItem.Form.SetLocked(true);
            }
        }

        public BaseDocument RemoveDocument(BaseDocument document)
        {
            BaseDocument _doc = null;
            FxBaseForm _fx = document.Form as FxBaseForm;
            switch (_fx.WindowOutputType)
            {
                case DialogOutputType.Tab:
                    RemoveAll(x => x.Id == _fx.ModuleId);
                    break;
                case DialogOutputType.Dialog:
                    _doc = ResetChaidDialog(document);
                    break;
                case DialogOutputType.Modal:
                    _doc = ResetChaidDialog(document);
                    break;
            }

            return _doc;
        }

        public BaseDocument ResetChaidDialog(BaseDocument document)
        {
            FxBaseForm _owner = ((FxBaseForm)document.Form).TabParent as FxBaseForm;
            Guid _id = _owner.ModuleId;
            TabForm _tabItem = this.FirstOrDefault(x => x.Id == _id);
            if (_tabItem != null)
            {
                _tabItem.ChaildModalForm = null;
                if (_tabItem.IsModal)
                {
                    _tabItem.IsModal = false;
                    _tabItem.Form.LockFockus = false;
                    //_tabItem.Form.Enabled = true;
                    //_tabItem.Form.SetLocked(true);
                }
            }
            FxBaseForm _fx = document.Form as FxBaseForm;
            if (_fx != null)
                RemoveAll(x => x.Id == _fx.ModuleId);

            return _tabItem?.Document;
        }


        public BaseDocument[] GetChildDocs(BaseDocument doc)
        {
            List<BaseDocument> _childs = new List<BaseDocument>();
            FxBaseForm _fx = doc.Form as FxBaseForm;
            if (_fx == null)
                return _childs.ToArray();
            TabForm _tab = this.FirstOrDefault(x => x.Id == _fx.ModuleId);
            if (_tab != null && _tab.ChaildDocument != null)
            {
                _childs.Add(_tab.ChaildDocument);
                _childs.AddRange(GetChildDocs(_tab.ChaildDocument));
            }
            return _childs.ToArray();
        }

        public void TabClose(FxBaseForm tab)
        {
            FxBaseForm _fx = tab as FxBaseForm;
            this.RemoveAll(x => x.Id == tab.ModuleId);
        }

        public bool IsLocked(FxBaseForm tab)
        {
            bool res = false;
            FxBaseForm _fx = tab as FxBaseForm;
            TabForm _tab = this.FirstOrDefault(x => x.Id == _fx.ModuleId);
            res = _tab != null && _tab.ChaildModalForm != null;
            return res;
        }

        public BaseDocument GetChaildDocument(BaseDocument document)
        {
            BaseDocument _doc = null;
            FxBaseForm _tab = ((FxBaseForm) document.Form);
            TabForm _tabItem = this.FirstOrDefault(x => x.Id == _tab.ModuleId);
            _doc = _tabItem.ChaildDocument;
            return _doc;
        }

        public BaseDocument GetDocumentById(Guid id)
        {
            return this.FirstOrDefault(x => x.Id == id)?.Document;
        }

        public void AppendForm(BaseDocument doc)
        {
            FxBaseForm _fx = doc.Form as FxBaseForm;
            if (_fx != null)
                switch (_fx.WindowOutputType)
                {
                    case DialogOutputType.Tab:
                        AppendTab(doc);
                        break;
                    case DialogOutputType.Dialog:
                        SetChildDialogModal(doc);
                        break;
                    case DialogOutputType.Modal:
                        SetChildDialogModal(doc);
                        break;
                }
        }
    }

    public class TabForm
    {
        public Guid Id
        {
            get { return Form?.ModuleId ?? Guid.Empty; }
        }
        public FxBaseForm Form { get; set; }    
        public FxBaseForm ChaildModalForm { get; set; }
        public BaseDocument Document { get; set; }
        public BaseDocument ChaildDocument { get; set; }
        public bool IsModal { get; set; }
    }
}