using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Lib.UI;
using Socrat.Log;
using Socrat.LookAndFeel;
using Socrat.Startup.Commands;
using Socrat.UI.Core;

namespace Socrat.Startup
{
    public partial class FxMain : FxBaseForm
    {
        /// <summary>
        /// Работа с оформлением (темы)
        /// </summary>
        private static LookAndFeelSettingsHelper _lookAndFeelSettingsHelper = null;

        private TabManager TabManager = new TabManager();

        Dictionary<Guid, ITabable> LoadedModules = new Dictionary<Guid, ITabable>();

        public void AppendModuleInfo(Guid id, ITabable form)
        {
            if (!LoadedModules.ContainsKey(id))
                LoadedModules.Add(id, form);
        }

        public FxMain()
        {
            InitializeComponent();
            
            if (Site != null && Site.DesignMode)
                return;

            BuildMenu();

            _lookAndFeelSettingsHelper = new LookAndFeelSettingsHelper();

            Load += OnLoad;
            this.Closing += FxMain_Closing;

            barDocuments.Visible = false;

            WindowState = FormWindowState.Maximized;

            FileVersionInfo _fileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            Text += $" {_fileVersionInfo.FileVersion} [{AppMain.User}]";
        }

        private void FxMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = XtraMessageBox.Show("Закрыть программу?", "Выход", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) != DialogResult.Yes;
        }

        List<ITabable> _Forms = new List<ITabable>();


        private void OnLoad(object sender, EventArgs e)
        {
            UpdateTypeViewCheckboxMenuItems();
            UpdateView();
        }

        public void LoadTab(ITabable form, Guid moduleId)
        {
            try
            {
                this.ShowSplashScreen();
                if (form != null)
                {
                    if (_Forms.Exists(x => x.Handle == form.Handle))
                        return;
                    _Forms.Add(form);

                    BaseDocument _doc = null;
                    documentManager.View.BeginUpdate();
                    _doc = documentManager.View.AddDocument((Form)form);
                    documentManager.View.EndUpdate();
                    documentManager.View.Controller.Activate(_doc);

                    if (AppMain.ViewType == MainViewType.MDI)
                    {
                        barDocuments.BeginUpdate();
                        BarButtonItem btn = new BarButtonItem();
                        btn.DataBindings.Add("Caption", form, "Title", false, DataSourceUpdateMode.OnPropertyChanged);
                        btn.Glyph = new Bitmap(((Form)form).Icon.ToBitmap(), 16, 16);
                        btn.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                        btn.Tag = moduleId;
                        btn.ItemClick += Btn_ItemClick;
                        barDocuments.AddItem(btn);
                        barDocuments.Visible = true;
                        ((Form)form).Tag = btn;
                        ((Form)form).FormClosing += FormOnFormClosing;
                        ((Form)form).MdiParent = this;
                        ((Form)form).StartPosition = FormStartPosition.CenterScreen;
                        barDocuments.EndUpdate();
                        this.Refresh();
                    }

                    form.DialogOutput += Form_DialogOutput;
                }
                AppendModuleInfo(moduleId, form);
                this.HideSplashScreen();
            }
            catch (Exception ex)
            {
                this.HideSplashScreen();
                XtraMessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            switch (AppMain.ViewType)
            {
                case MainViewType.MDI:
                    OutputMdiWindow(ta);
                    break;
                case MainViewType.Tabs:
                    OutputTab(ta);
                    break;
            }
        }

        private void OutputMdiWindow(WindowOutputEventArgs ta)
        {
            barDocuments.BeginUpdate();
            BarButtonItem btn = new BarButtonItem();
            //btn.Caption = ta.NewTab.ModuleName;
            btn.DataBindings.Add("Caption", ta.NewTab, "Title", false, DataSourceUpdateMode.OnPropertyChanged);
            btn.Glyph = new Bitmap(((Form)ta.NewTab).Icon.ToBitmap(), 16, 16);
            btn.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            btn.Tag = ((FxBaseForm)ta.NewTab).ModuleId;
            btn.ItemClick += Btn_ItemClick;
            barDocuments.AddItem(btn);
            barDocuments.Visible = true;
            ((Form)ta.NewTab).Tag = btn;
            ((Form)ta.NewTab).FormClosing += FormOnFormClosing;
            ((Form)ta.NewTab).StartPosition = FormStartPosition.CenterScreen;
            barDocuments.EndUpdate();

            switch (ta.OutputType)
            {
                case DialogOutputType.Dialog:
                    ((FxBaseForm)ta.NewTab).WindowOutputType = DialogOutputType.Dialog;
                    ((FxBaseForm)ta.NewTab).TabParent = (FxBaseForm)ta.Owner;
                    ((Form)ta.NewTab).MdiParent = this;
                    ((Form)ta.NewTab).Show();
                    break;
                case DialogOutputType.Tab:
                    ((FxBaseForm) ta.NewTab).WindowOutputType = DialogOutputType.Tab;
                    ((Form)ta.NewTab).MdiParent = this;
                    ((Form)ta.NewTab).Show();
                    break;
                case DialogOutputType.Modal:
                    ((FxBaseForm) ta.NewTab).WindowOutputType = DialogOutputType.Modal;
                    ((FxBaseForm)ta.NewTab).TabParent = (FxBaseForm)ta.Owner;
                    ((Form)ta.NewTab).MdiParent = this;
                    ((Form)ta.NewTab).Show();
                    break;
            }

            this.Refresh();
        }

        private void OutputTab(WindowOutputEventArgs ta)
        {
            switch (ta.OutputType)
            {
                case DialogOutputType.Tab:
                    //LoadTab(ta.NewTab);
                    break;
                case DialogOutputType.Dialog:
                    Form _frm = ta.NewTab as Form;
                    //_frm.StartPosition = FormStartPosition.CenterScreen;
                    //_frm.ShowDialog(ta.Owner);
                    BaseDocument _doc = null;
                    documentManager.View.BeginUpdate();
                    _doc = documentManager.View.AddDocument(_frm);
                    documentManager.View.EndUpdate();
                    documentManager.View.Controller.Activate(_doc);
                    break;
            }
        }

        private void FormOnFormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = sender as Form;
            if (form != null)
            {
                BarButtonItem btn = form.Tag as BarButtonItem;
                _Forms.Remove((ITabable)form);
                if (btn != null)
                    btn.Dispose();
                barDocuments.Visible = documentManager.View.Documents.Count > 0;
                this.Refresh();
            }
        }

        private void Btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem btn = e.Item as BarButtonItem;
            if (btn != null && btn.Tag != null)
            {
                Guid _id;
                Guid.TryParse(btn.Tag.ToString(), out _id);
                BaseDocument _doc = TabManager.GetDocumentById(_id);
                if (btn != null && _doc != null)
                {
                    documentManager.View.Controller.Activate(_doc);
                }
                
            }
        }

        private void biSetup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AppMain.LoadModuleTab("Socrat.Module.Settings", Guid.NewGuid());
        }

        private void UpdateTypeViewCheckboxMenuItems()
        {
            bciMDI.Checked = AppMain.ViewType == MainViewType.MDI;
            bciTabs.Checked = AppMain.ViewType == MainViewType.Tabs;
            bciUseStyles.Checked = AppMain.ViewType == MainViewType.MDI;
            bciUseStyles.Checked = AppMain.UseStyles;
        }

        private void UpdateView()
        {
            documentManager.ViewCollection.Clear();
            switch (AppMain.ViewType)
            {
                case MainViewType.MDI:
                    documentManager.View.Documents.Clear();
                    try
                    {
                        for (int i = 0; i < _Forms.Count; i++)
                            if (!((Form)_Forms[i]).IsDisposed)
                                ((Form)_Forms[i]).Close();
                    }
                    catch (Exception e)
                    {
                        Logger.AddErrorMsg(e.Message);
                    }
                    NativeMdiView _nmw = new NativeMdiView();
                    _nmw.DocumentAdded += NmwOnDocumentAdded;
                    _nmw.DocumentRemoved += NmwOnDocumentRemoved;
                    _nmw.DocumentActivated += _nmw_DocumentActivated;
                    _nmw.DocumentClosing += _nmw_DocumentClosing;
                    _nmw.UseDocumentSelector = DefaultBoolean.True;
                    documentManager.View = _nmw;
                    break;
                case MainViewType.Tabs:
                    barDocuments.Visible = false;
                    documentManager.View = new TabbedView();
                    break;
                case MainViewType.Tablet:
                    barDocuments.Visible = false;
                    WidgetView _view = new WidgetView();
                    documentManager.View = _view;
                    break;
            }
        }

        private void _nmw_DocumentClosing(object sender, DocumentCancelEventArgs e)
        {
            BaseDocument[] _docs = TabManager.GetChildDocs(e.Document);
            for (var i = _docs.Length - 1; i >= 0; i--)
            {
                documentManager.View.Controller.Close(_docs[i]);
            }
        }

        private bool _onActivation = false;
        private void _nmw_DocumentActivated(object sender, DocumentEventArgs e)
        {
            if (_onActivation)
                return;
            FxBaseForm _fx = e.Document.Form as FxBaseForm;
            if (_fx != null)
            {
                if (TabManager.IsLocked(_fx))
                {
                    BaseDocument _doc = TabManager.GetChaildDocument(e.Document);
                    if (_doc != null)
                    {
                        _onActivation = true;
                        documentManager.View.Controller.Activate(_doc);
                        _doc.Control.Select();
                        //while (!_doc.Form.IsActiveMdiChild())
                        //{
                        //    documentManager.View.Controller.Activate(_doc);
                        //}
                        //_doc.Form.Activate();
                        _onActivation = false;
                    }
                }
            }
        }

        private void NmwOnDocumentRemoved(object sender, DocumentEventArgs e)
        {
            FxBaseForm _fx = e.Document.Form as FxBaseForm;
            if (_fx != null)
            {
                BaseDocument _doc = TabManager.RemoveDocument(e.Document);
                if (_doc != null)
                    documentManager.View.Controller.Activate(_doc);
            }
        }

        private void NmwOnDocumentAdded(object sender, DocumentEventArgs e)
        {
            TabManager.AppendForm(e.Document);
        }

        private void biCnnInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FxAbout _fx = new FxAbout();
            _fx.ShowDialog();
        }

        private void bciMDI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AppMain.ViewType = MainViewType.MDI;
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            UpdateTypeViewCheckboxMenuItems();
            UpdateView();
        }

        private void bciTabs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AppMain.ViewType = MainViewType.Tabs;
            UpdateTypeViewCheckboxMenuItems();
            UpdateView();
        }

        private void bciUseStyles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AppMain.UseStyles = !AppMain.UseStyles;
            bciUseStyles.Checked = AppMain.UseStyles;
        }

        private void biClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        public void ShowErrorLogMessage(string msg)
        {
            XtraMessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BuildMenu()
        {
            barManager.BeginUpdate();
            barManager.MainMenu.AddItems(MenuBuilder.BuildFromDb(barManager, AppMain.User.Role));
            barManager.MainMenu.ItemLinks.Insert(0, biFile);
            barManager.MainMenu.ItemLinks.Add(biSettings);
            barManager.MainMenu.ItemLinks.Add(barDockingMenuItem2);
            barManager.EndUpdate();
        }
    }
}
