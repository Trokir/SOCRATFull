using System.Drawing;
using System.IO;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using Socrat.Log.Enums;

namespace Socrat.Log.Viewer
{
    public static class IconWorker
    {
        readonly static ImageConverter _converter = new ImageConverter();

        private static SvgImageCollection _imageCollection;
        public static SvgImageCollection ImgCollection
        {
            get { return GetImageCollection(); }
        }

        private static SvgImageCollection GetImageCollection()
        {
            if (_imageCollection == null)
                _imageCollection = new SvgImageCollection();
            return _imageCollection;
        }
        //private static Icon GetAppIcon()
        //{
        //    SvgBitmap _logo = SvgBitmap.FromStream(new MemoryStream(Properties.Resources.logo));
        //    Bitmap _bmp = new Bitmap(_logo.Render(new Size() { Height = 128, Width = 128 }, null));
        //    return Icon.FromHandle(_bmp.GetHicon());
        //}

        public static SvgImage GetIcon(LogType logType)
        {
            SvgImage _bmp = _imageCollection["error"];
            switch (logType)
            {
                case LogType.Error:
                    _bmp = _imageCollection["error"];
                    break;
                case LogType.Warning:
                    _bmp = _imageCollection["warning"];
                    break;
                case LogType.ErrorException:
                    _bmp = _imageCollection["error"];
                    break;
                case LogType.Information:
                    _bmp = _imageCollection["Information"];
                    break;
                case LogType.FailureAudit:
                    _bmp = _imageCollection["error"];
                    break;
                case LogType.SuccessAudit:
                    _bmp = _imageCollection["error"];
                    break;
                case LogType.Marker:
                    _bmp = _imageCollection["error"];
                    break;
                case LogType.Finisch:
                    _bmp = _imageCollection["Finish"];
                    break;
                case LogType.Start:
                    _bmp = _imageCollection["Start"];
                    break;
                case LogType.EndException:
                    _bmp = _imageCollection["Error"];
                    break;
            }

            return _bmp;
        }
    }
}