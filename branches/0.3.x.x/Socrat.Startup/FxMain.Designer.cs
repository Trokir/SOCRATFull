using DevExpress.XtraBars.InternalItems;

namespace Socrat.Startup
{
    partial class FxMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxMain));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.biFile = new DevExpress.XtraBars.BarSubItem();
            this.biClose = new DevExpress.XtraBars.BarButtonItem();
            this.biSettings = new DevExpress.XtraBars.BarSubItem();
            this.biViewType = new DevExpress.XtraBars.BarSubItem();
            this.biCnnInfo = new DevExpress.XtraBars.BarSubItem();
            this.bciMDI = new DevExpress.XtraBars.BarCheckItem();
            this.bciTabs = new DevExpress.XtraBars.BarCheckItem();
            this.bciUseStyles = new DevExpress.XtraBars.BarCheckItem();
            this.barDockingMenuItem2 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barBottom = new DevExpress.XtraBars.Bar();
            this.siThemes = new DevExpress.XtraBars.SkinBarSubItem();
            this.biSetup = new DevExpress.XtraBars.BarButtonItem();
            this.barMdiChildrenListItem = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barDocuments = new DevExpress.XtraBars.Bar();
            this.barAndDockingController = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.biAddTab = new DevExpress.XtraBars.BarStaticItem();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.windowsUIView = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowItemAnimatedHighlighting = false;
            this.barManager.AllowMoveBarOnToolbar = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop,
            this.barBottom,
            this.barDocuments});
            this.barManager.Controller = this.barAndDockingController;
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockManager = this.dockManager;
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.siThemes,
            //this.bsiHelp,
            this.biAddTab,
            this.barMdiChildrenListItem,
            this.biSettings,
            this.biSetup,
            this.biViewType,
            this.biCnnInfo,
            this.bciMDI,
            this.bciTabs,
            this.bciUseStyles,
            this.barDockingMenuItem1,
            this.barDockingMenuItem2,
            this.biFile,
            this.biClose
            });
            this.barManager.MainMenu = this.barTop;
            this.barManager.MaxItemId = 32;
            this.barManager.MdiMenuMergeStyle = DevExpress.XtraBars.BarMdiMenuMergeStyle.Never;
            this.barManager.PopupShowMode = DevExpress.XtraBars.PopupShowMode.Classic;
            this.barManager.StatusBar = this.barBottom;
            // 
            // barTop
            // 
            this.barTop.BarAppearance.Hovered.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.barTop.BarAppearance.Hovered.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.barTop.BarAppearance.Hovered.Options.UseBackColor = true;
            this.barTop.BarAppearance.Pressed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.barTop.BarAppearance.Pressed.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.barTop.BarAppearance.Pressed.Options.UseBackColor = true;
            this.barTop.BarName = "Главное меню";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            //this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            //new DevExpress.XtraBars.LinkPersistInfo(this.biFile),
            //new DevExpress.XtraBars.LinkPersistInfo(this.barDockingMenuItem2)
            //});
            this.barTop.OptionsBar.AllowCollapse = true;
            this.barTop.OptionsBar.AllowQuickCustomization = false;
            this.barTop.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.All;
            this.barTop.OptionsBar.DrawDragBorder = false;
            this.barTop.OptionsBar.MultiLine = true;
            this.barTop.OptionsBar.UseWholeRow = true;
            this.barTop.Text = "Главное меню";
            // 
            // biFile
            // 
            this.biFile.Caption = "Файл";
            this.biFile.Id = 25;
            this.biFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biClose)});
            this.biFile.Name = "biFile";
            // 
            // biClose
            // 
            this.biClose.Caption = "Выход";
            this.biClose.Id = 27;
            this.biClose.Name = "biClose";
            this.biClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biClose_ItemClick);
            // 
            // biSettings
            // 
            this.biSettings.Caption = "Настройки";
            this.biSettings.Id = 7;
            this.biSettings.ItemAppearance.Hovered.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.biSettings.ItemAppearance.Hovered.Options.UseBackColor = true;
            this.biSettings.ItemClickFireMode = DevExpress.XtraBars.BarItemEventFireMode.Immediate;
            this.biSettings.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biViewType),
            new DevExpress.XtraBars.LinkPersistInfo(this.biCnnInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciUseStyles)
            });
            this.biSettings.MenuAppearance.AppearanceMenu.Hovered.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.biSettings.MenuAppearance.AppearanceMenu.Hovered.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.biSettings.MenuAppearance.AppearanceMenu.Hovered.Options.UseBackColor = true;
            this.biSettings.MenuAppearance.AppearanceMenu.Pressed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.biSettings.MenuAppearance.AppearanceMenu.Pressed.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.biSettings.MenuAppearance.AppearanceMenu.Pressed.Options.UseBackColor = true;
            this.biSettings.MenuAppearance.HeaderItemAppearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.biSettings.MenuAppearance.HeaderItemAppearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.biSettings.MenuAppearance.HeaderItemAppearance.Options.UseBackColor = true;
            this.biSettings.Name = "biSettings";
            // 
            // biViewType
            // 
            this.biViewType.Caption = "Вид";
            this.biViewType.Id = 10;
            this.biViewType.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bciMDI),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciTabs)
            });
            this.biViewType.Name = "biViewType";
            // 
            // biCnnInfo
            // 
            this.biCnnInfo.Caption = "Соединение";
            this.biCnnInfo.Id = 11;
            this.biCnnInfo.Name = "biCnnInfo";
            this.biCnnInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biCnnInfo_ItemClick);
            // 
            // bciMDI
            // 
            this.bciMDI.Caption = "Класический MDI";
            this.bciMDI.Id = 16;
            this.bciMDI.Name = "bciMDI";
            this.bciMDI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bciMDI_ItemClick);
            // 
            // bciTabs
            // 
            this.bciTabs.Caption = "Вкладки";
            this.bciTabs.Id = 17;
            this.bciTabs.Name = "bciTabs";
            this.bciTabs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bciTabs_ItemClick);
            // 
            // bciUseStyles
            // 
            this.bciUseStyles.Caption = "Использовать стили оформления";
            this.bciUseStyles.Id = 17;
            this.bciUseStyles.Name = "bciUseStyles";
            this.bciUseStyles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bciUseStyles_ItemClick);
            // 
            // barDockingMenuItem2
            // 
            this.barDockingMenuItem2.Caption = "Окна";
            this.barDockingMenuItem2.Id = 22;
            this.barDockingMenuItem2.Name = "barDockingMenuItem2";
            // 
            // barBottom
            // 
            this.barBottom.BarName = "Строка состояния";
            this.barBottom.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barBottom.DockCol = 0;
            this.barBottom.DockRow = 0;
            this.barBottom.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barBottom.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.siThemes),
            new DevExpress.XtraBars.LinkPersistInfo(this.biSetup),
            new DevExpress.XtraBars.LinkPersistInfo(this.barMdiChildrenListItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDockingMenuItem1)});
            this.barBottom.OptionsBar.AllowQuickCustomization = false;
            this.barBottom.OptionsBar.DrawDragBorder = false;
            this.barBottom.OptionsBar.UseWholeRow = true;
            this.barBottom.Text = "Строка состояния";
            // 
            // siThemes
            // 
            this.siThemes.Hint = "Выбор темы оформления";
            this.siThemes.Id = 0;
            this.siThemes.ImageOptions.Image = global::Socrat.Startup.Properties.Resources.localcolorscheme_16x16;
            this.siThemes.ImageOptions.LargeImage = global::Socrat.Startup.Properties.Resources.localcolorscheme_32x32;
            this.siThemes.Name = "siThemes";
            this.siThemes.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // biSetup
            // 
            this.biSetup.Id = 9;
            this.biSetup.ImageOptions.Image = global::Socrat.Startup.Properties.Resources.documentproperties_16x16;
            this.biSetup.ImageOptions.LargeImage = global::Socrat.Startup.Properties.Resources.documentproperties_32x32;
            this.biSetup.Name = "biSetup";
            this.biSetup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biSetup_ItemClick);
            // 
            // barMdiChildrenListItem
            // 
            this.barMdiChildrenListItem.Hint = "Открытые вкладки";
            this.barMdiChildrenListItem.Id = 6;
            this.barMdiChildrenListItem.ImageOptions.Image = global::Socrat.Startup.Properties.Resources.window_16x16;
            this.barMdiChildrenListItem.ImageOptions.LargeImage = global::Socrat.Startup.Properties.Resources.window_32x32;
            this.barMdiChildrenListItem.Name = "barMdiChildrenListItem";
            this.barMdiChildrenListItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Id = 21;
            this.barDockingMenuItem1.ImageOptions.Image = global::Socrat.Startup.Properties.Resources.cards_16x16;
            this.barDockingMenuItem1.ImageOptions.LargeImage = global::Socrat.Startup.Properties.Resources.cards_32x32;
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            this.barDockingMenuItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDocuments
            // 
            this.barDocuments.BarName = "Окна";
            this.barDocuments.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barDocuments.DockCol = 0;
            this.barDocuments.DockRow = 1;
            this.barDocuments.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barDocuments.FloatLocation = new System.Drawing.Point(469, 645);
            this.barDocuments.OptionsBar.AllowQuickCustomization = false;
            this.barDocuments.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barDocuments.OptionsBar.DrawDragBorder = false;
            this.barDocuments.Text = "Окна";
            // 
            // barAndDockingController
            // 
            this.barAndDockingController.PropertiesDocking.ViewStyle = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Default;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1105, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 656);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1105, 56);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 634);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1105, 22);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 634);
            // 
            // dockManager
            // 
            this.dockManager.Controller = this.barAndDockingController;
            this.dockManager.Form = this;
            this.dockManager.MenuManager = this.barManager;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // documentManager
            // 
            this.documentManager.BarAndDockingController = this.barAndDockingController;
            this.documentManager.MdiParent = this;
            this.documentManager.MenuManager = this.barManager;
            this.documentManager.ShowToolTips = DevExpress.Utils.DefaultBoolean.True;
            this.documentManager.View = this.windowsUIView;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.windowsUIView});
            // 
            // bar1
            // 
            this.bar1.BarName = "Пользовательская 5";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Пользовательская 5";
            // 
            // FxMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 712);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FxMain";
            this.Text = "Socrat";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.Bar barBottom;
        private DevExpress.XtraBars.SkinBarSubItem siThemes;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem biAddTab;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.BarSubItem biSettings;
        private DevExpress.XtraBars.BarButtonItem biSetup;
        private DevExpress.XtraBars.BarSubItem biViewType;
        private DevExpress.XtraBars.BarSubItem biCnnInfo;
        private DevExpress.XtraBars.BarCheckItem bciMDI;
        private DevExpress.XtraBars.BarCheckItem bciTabs;
        private DevExpress.XtraBars.BarCheckItem bciUseStyles;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.Bar barDocuments;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem2;
        private DevExpress.XtraBars.BarSubItem biFile;
        private DevExpress.XtraBars.BarButtonItem biClose;
        private DevExpress.XtraBars.Bar bar1;
    }
}

