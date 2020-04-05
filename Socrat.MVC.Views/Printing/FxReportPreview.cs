using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Socrat.MVI.Views.Printing
{
    public class FxReportPreview : XtraForm
    {
        public XtraReport Report { get; private set; }
        public object Parameters { get; private set; }

        public FxReportPreview(XtraReport report, object parameters) : this()
        {
            Parameters = parameters;
            Report = report;
            documentViewer.DocumentSource = Report;
        }

        #region Designer code
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraEditors.XtraSaveFileDialog sfdSave;
        private DevExpress.XtraBars.BarManager bmMain;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbiExportXslx;
        private DevExpress.XtraBars.BarButtonItem bbiExportToXls;
        private DevExpress.XtraBars.BarButtonItem bbiExportToPdf;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiExportToDocx;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiPrintByDefault;
        private DevExpress.XtraBars.BarButtonItem bbiDesign;
        private DevExpress.XtraBars.BarButtonItem bbiSendByMail;
        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer;

        public FxReportPreview()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxReportPreview));
            this.documentViewer = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.sfdSave = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            this.bmMain = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbiExportXslx = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToXls = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToPdf = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToDocx = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSendByMail = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrintByDefault = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDesign = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).BeginInit();
            this.SuspendLayout();
            // 
            // documentViewer
            // 
            this.documentViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer.IsMetric = true;
            this.documentViewer.Location = new System.Drawing.Point(0, 51);
            this.documentViewer.Name = "documentViewer";
            this.documentViewer.Size = new System.Drawing.Size(857, 607);
            this.documentViewer.TabIndex = 0;
            // 
            // sfdSave
            // 
            this.sfdSave.FileName = "xtraSaveFileDialog1";
            this.sfdSave.Title = "Сохранить как";
            // 
            // bmMain
            // 
            this.bmMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.bmMain.DockControls.Add(this.barDockControlTop);
            this.bmMain.DockControls.Add(this.barDockControlBottom);
            this.bmMain.DockControls.Add(this.barDockControlLeft);
            this.bmMain.DockControls.Add(this.barDockControlRight);
            this.bmMain.Form = this;
            this.bmMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiExportXslx,
            this.bbiExportToXls,
            this.bbiExportToPdf,
            this.bbiExportToDocx,
            this.bbiPrint,
            this.bbiPrintByDefault,
            this.bbiDesign,
            this.bbiSendByMail});
            this.bmMain.MainMenu = this.bar2;
            this.bmMain.MaxItemId = 8;
            this.bmMain.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(216, 161);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportXslx),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportToXls),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportToPdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportToDocx),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSendByMail, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrintByDefault),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDesign, true)});
            this.bar1.Offset = 1;
            this.bar1.Text = "Tools";
            // 
            // bbiExportXslx
            // 
            this.bbiExportXslx.Caption = "Выгрузить в Excel";
            this.bbiExportXslx.Id = 0;
            this.bbiExportXslx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportXslx.ImageOptions.Image")));
            this.bbiExportXslx.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportXslx.ImageOptions.LargeImage")));
            this.bbiExportXslx.Name = "bbiExportXslx";
            this.bbiExportXslx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportXslx_ItemClick);
            // 
            // bbiExportToXls
            // 
            this.bbiExportToXls.Caption = "Выгрузить в Excel 97-2003";
            this.bbiExportToXls.Id = 1;
            this.bbiExportToXls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportToXls.ImageOptions.Image")));
            this.bbiExportToXls.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportToXls.ImageOptions.LargeImage")));
            this.bbiExportToXls.Name = "bbiExportToXls";
            this.bbiExportToXls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportXls_ItemClick);
            // 
            // bbiExportToPdf
            // 
            this.bbiExportToPdf.Caption = "Экспорт в документ Acrobat Reader";
            this.bbiExportToPdf.Id = 2;
            this.bbiExportToPdf.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportToPdf.ImageOptions.Image")));
            this.bbiExportToPdf.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportToPdf.ImageOptions.LargeImage")));
            this.bbiExportToPdf.Name = "bbiExportToPdf";
            this.bbiExportToPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportPdf_ItemClick);
            // 
            // bbiExportToDocx
            // 
            this.bbiExportToDocx.Caption = "Экспорт в документ Word";
            this.bbiExportToDocx.Id = 3;
            this.bbiExportToDocx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportToDocx.ImageOptions.Image")));
            this.bbiExportToDocx.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportToDocx.ImageOptions.LargeImage")));
            this.bbiExportToDocx.Name = "bbiExportToDocx";
            this.bbiExportToDocx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportToDocx_ItemClick);
            // 
            // bbiSendByMail
            // 
            this.bbiSendByMail.Caption = "Послать по почте";
            this.bbiSendByMail.Id = 7;
            this.bbiSendByMail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSendByMail.ImageOptions.Image")));
            this.bbiSendByMail.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSendByMail.ImageOptions.LargeImage")));
            this.bbiSendByMail.Name = "bbiSendByMail";
            this.bbiSendByMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSendByMail_ItemClick);
            // 
            // bbiPrint
            // 
            this.bbiPrint.Caption = "Печатать...";
            this.bbiPrint.Id = 4;
            this.bbiPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiPrint.ImageOptions.Image")));
            this.bbiPrint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiPrint.ImageOptions.LargeImage")));
            this.bbiPrint.Name = "bbiPrint";
            this.bbiPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrint_ItemClick);
            // 
            // bbiPrintByDefault
            // 
            this.bbiPrintByDefault.Caption = "Печатать";
            this.bbiPrintByDefault.Id = 5;
            this.bbiPrintByDefault.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiPrintByDefault.ImageOptions.Image")));
            this.bbiPrintByDefault.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiPrintByDefault.ImageOptions.LargeImage")));
            this.bbiPrintByDefault.Name = "bbiPrintByDefault";
            this.bbiPrintByDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintByDefault_ItemClick);
            // 
            // bbiDesign
            // 
            this.bbiDesign.Caption = "Открыть в дизайнере";
            this.bbiDesign.Id = 6;
            this.bbiDesign.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDesign.ImageOptions.Image")));
            this.bbiDesign.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDesign.ImageOptions.LargeImage")));
            this.bbiDesign.Name = "bbiDesign";
            this.bbiDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDesign_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 1;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bmMain;
            this.barDockControlTop.Size = new System.Drawing.Size(857, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 658);
            this.barDockControlBottom.Manager = this.bmMain;
            this.barDockControlBottom.Size = new System.Drawing.Size(857, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = this.bmMain;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 607);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(857, 51);
            this.barDockControlRight.Manager = this.bmMain;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 607);
            // 
            // FxReportPreview
            // 
            this.ClientSize = new System.Drawing.Size(857, 681);
            this.Controls.Add(this.documentViewer);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxReportPreview";
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void exportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string fileName = SelectFileName("Документ Acrobat Reader", "pdf", Report.DisplayName);
                if (!string.IsNullOrEmpty(fileName))
                {
                    PdfExportOptions pdfOptions = Report.ExportOptions.Pdf;
                    pdfOptions.ConvertImagesToJpeg = false;
                    pdfOptions.ImageQuality = PdfJpegImageQuality.Medium;
                    pdfOptions.PdfACompatibility = PdfACompatibility.PdfA3b;
                    pdfOptions.DocumentOptions.Application = "RGC Info System";
                    pdfOptions.DocumentOptions.Author = "Socrat Development Team";
                    pdfOptions.DocumentOptions.Keywords = "RGC, Socrat";
                    pdfOptions.DocumentOptions.Producer = Environment.UserName.ToString();
                    pdfOptions.DocumentOptions.Subject = Report.DisplayName;
                    pdfOptions.DocumentOptions.Title = Report.DisplayName;

                    IList<string> result = pdfOptions.Validate();
                    if (result.Count > 0)
                        throw new Exception("Ошибка экспорта отчета в документ Adobe Reader", new Exception(string.Join(Environment.NewLine, result)));
                    else
                        Report.ExportToPdf(fileName, pdfOptions);
                }
                if (XtraMessageBox.Show("Отчет успешно экспортирован. Открыть его в приложении?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Ошибка: {ex.Message}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void exportXslx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string fileName = SelectFileName("Книга Excel","xlsx", Report.DisplayName);
                if (!string.IsNullOrEmpty(fileName))
                Report.ExportToXlsx( fileName);
                if (XtraMessageBox.Show("Отчет успешно экспортирован. Открыть его в приложении?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Ошибка: {ex.Message}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void exportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string fileName = SelectFileName("Книга Excel 97-2003", "xls", Report.DisplayName);
                if (!string.IsNullOrEmpty(fileName))
                    Report.ExportToXlsx(fileName);
                if (XtraMessageBox.Show("Отчет успешно экспортирован. Открыть его в приложении?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Ошибка: {ex.Message}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrintTool printTool = new ReportPrintTool(Report);
            printTool.PrintDialog();
        }

        private string SelectFileName(string appFilter, string defaultExtention, string fileName)
        {
            sfdSave.Filter = $"{appFilter}|*.{defaultExtention}|Все файлы|*.*";
            sfdSave.FileName = fileName;
            sfdSave.AddExtension = true;
            sfdSave.OverwritePrompt = true;
            if (sfdSave.ShowDialog(this) == DialogResult.OK)
                return sfdSave.FileName;
            else
                return string.Empty;
        }

        private void bbiExportToDocx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string fileName = SelectFileName("Документ Word", "docx", Report.DisplayName);
                if (!string.IsNullOrEmpty(fileName))
                    Report.ExportToDocx(fileName);
                if (XtraMessageBox.Show("Отчет успешно экспортирован. Открыть его в приложении?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Ошибка: {ex.Message}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bbiPrintByDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrintTool printTool = new ReportPrintTool(Report);
            printTool.Print();
        }

        private void bbiDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportDesignTool designTool = new ReportDesignTool(Report);
            designTool.ShowDesigner();            
        }

        private void bbiSendByMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.ExportToMail("a@a.b", "b@b.c", Report.DisplayName);
        }
    }
}
