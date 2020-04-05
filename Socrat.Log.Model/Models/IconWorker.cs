using System.Drawing;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using Socrat.Log.Enums;

namespace Socrat.Log.Model.Models
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
            SvgImage _bmp = ImgCollection["error"];
            switch (logType)
            {
                case LogType.Error:
                    _bmp = ImgCollection["error"];
                    break;
                case LogType.Warning:
                    _bmp = ImgCollection["warning"];
                    break;
                case LogType.ErrorException:
                    _bmp = ImgCollection["error"];
                    break;
                case LogType.Information:
                    _bmp = ImgCollection["information"];
                    break;
                case LogType.FailureAudit:
                    _bmp = ImgCollection["error"];
                    break;
                case LogType.SuccessAudit:
                    _bmp = ImgCollection["error"];
                    break;
                case LogType.Marker:
                    _bmp = ImgCollection["error"];
                    break;
                case LogType.Finisch:
                    _bmp = ImgCollection["finish"];
                    break;
                case LogType.Start:
                    _bmp = ImgCollection["start"];
                    break;
                case LogType.EndException:
                    _bmp = ImgCollection["error"];
                    break;
            }

            return _bmp;
        }
    }
}