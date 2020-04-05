using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
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

        public void LoadTab(ITabable form)
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
                        btn.Tag = _doc;
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
                this.HideSplashScreen();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            switch (AppMain.ViewType)
            {
                case MainViewType.MDI:
                    //OutputMdiWindow(ta);
                    //break;
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
            //btn.Tag = _doc;
            btn.ItemClick += Btn_ItemClick;
            barDocuments.AddItem(btn);
            barDocuments.Visible = true;
            ((Form)ta.NewTab).Tag = btn;
            ((Form)ta.NewTab).FormClosing += FormOnFormClosing;

            ((Form)ta.NewTab).StartPosition = FormStartPosition.CenterScreen;
            barDocuments.EndUpdate();

            switch (ta.OutputType)
            {
                case DialogOutputType.Tab:
                    ((Form)ta.NewTab).MdiParent = this;
                    ((Form)ta.NewTab).Show();
                    break;
                case DialogOutputType.Dialog:
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
                case DialogOutputType.Dialog:
                case DialogOutputType.Tab:
                    LoadTab(ta.NewTab);
                    break;
                //case DialogOutputType.Dialog:
                //    Form _frm = ta.NewTab as Form;
                //    _frm.StartPosition = FormStartPosition.CenterScreen;
                //    _frm.Show(this);
                //    break;
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
            if (btn != null)
            {
                BaseDocument _doc = btn.Tag as BaseDocument;
                if (btn != null && _doc != null)
                {
                    documentManager.View.ActivateDocument(_doc.Control);
                }
            }
        }

        private void biSetup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AppMain.LoadModuleTab("Socrat.Module.Settings");
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
                    documentManager.View = new NativeMdiView();
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

        //
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
            MainMenuCommands _menu = new MainMenuCommands();
            barManager.BeginUpdate();
            //barManager.MainMenu.AddItems(MenuBuilder.GetItems(barManager, _menu));
            barManager.MainMenu.AddItems(MenuBuilder.BuildFromDb(barManager, AppMain.User.Role));
            barManager.MainMenu.ItemLinks.Insert(0, biFile);
            barManager.MainMenu.ItemLinks.Add(biSettings);
            barManager.MainMenu.ItemLinks.Add(barDockingMenuItem2);
            barManager.EndUpdate();
        }


    }
}
