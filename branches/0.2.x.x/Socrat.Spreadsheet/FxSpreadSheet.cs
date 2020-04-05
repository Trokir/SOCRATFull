using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Socrat.Lib;


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

        public event WindowOutputHandler DialogOutput;

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType});
        }

        public string Title
        {
            get { return "Форма ожидания завершения процесса"; }
        }

        public bool ReadOnly { get; set; }
    }
}