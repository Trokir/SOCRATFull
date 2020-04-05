using System;
using System.Drawing;
using System.IO;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using Socrat.Core;

namespace Socrat.Spreadsheet
{
    public partial class FxSpreadSheet : RibbonForm, ITabable
    {
        public FxSpreadSheet()
        {
            InitializeComponent();
            InitSkinGallery();
            Icon = GetAppIcon();
        }

        public FxSpreadSheet(Stream stream)
        {
            InitializeComponent();
            InitSkinGallery();
            Icon = GetAppIcon();
            spreadsheetControl.LoadDocument(stream);
        }

        public void SetInfo(string status, string info)
        {
            siStatus.Caption = status;
            siInfo.Caption = info;
        }

        public void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private Icon GetAppIcon()
        {
            SvgBitmap _logo = SvgBitmap.FromStream(new MemoryStream(Properties.Resources.logo));
            Bitmap _bmp = new Bitmap(_logo.Render(new Size() { Height = 128, Width = 128 }, null));
            return Icon.FromHandle(_bmp.GetHicon());
        }

        public event EventHandler<WindowOutputEventArgs> DialogOutput;

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType});
        }

        public void OnDialogOutput(WindowOutputEventArgs ta)
        {
            DialogOutput?.Invoke(this, ta);
        }

        public string Title
        {
            get { return "Форма ожидания завершения процесса"; }
        }

        public bool ReadOnly { get; set; }

        private Guid _ModuleId;
        public Guid ModuleId
        {
            get => _ModuleId;
            set => _ModuleId = value;
        }
    }
}