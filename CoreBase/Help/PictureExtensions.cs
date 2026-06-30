using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CoreBase.Help
{
    public static class PictureExtensions
    {
        /// <summary>
        /// 重新繪製圖片以符合新寬高
        /// </summary>
        /// <param name="image">須變尺吋之圖片</param>
        /// <param name="width">新圖寬度</param>
        /// <param name="height">新圖高度</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(this Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// 重新繪製圖片以符合元件
        /// </summary>
        /// <param name="image">圖片</param>
        /// <param name="control">控制項</param>
        /// <returns></returns>
        public static Bitmap ResizeImage(this Image image, Control control)
        {
            if (control is null || image is null)
            {
                return new Bitmap(0, 0);
            }
            else
            {
                var newPicHeight = image.Height;

                if (control is Button )
                {
                    newPicHeight = (control as Button).Font.Height;
                }
                //else if (control is DataGridViewButtonColumn)
                //{
                //    newPicHeight = (control is DataGridViewButtonColumn).Style.Font.Height;
                //}
                else
                {
                    newPicHeight = control.Height - 4;
                }

                return image.ResizeImage(newPicHeight, newPicHeight);
            }
        }

        /// <summary>
        /// 將 ICON 調整大小
        /// 目前，僅 Button 及 Label正常
        /// </summary>
        /// <param name="control"></param>
        public static void ResizeImage(this Control control)
        {
            if (control is Button)
            {
                if ((control as Button).Image != null)
                {
                    (control as Button).Image = (control as Button).Image.ResizeImage(control);
                }
            }
            else if (control is Label)
            {
                if ((control as Label).Image != null)
                {
                    (control as Label).Image = (control as Label).Image.ResizeImage(control);
                }
            }
            //else if (control is DataGridViewButtonColumn)
            //{
            //    (control as DataGridViewButtonColumn).Image = (control is DataGridViewButtonColumn).Image.ResizeImage(control);
            //}
        }

        public static Icon ConvertToIcon(this Image img, int size)
        {
            //var bmp = Bitmap.FromFile(fname);
            var thumb = (Bitmap)img.GetThumbnailImage(size, size, null, IntPtr.Zero);
            thumb.MakeTransparent();
            var icon = Icon.FromHandle(thumb.GetHicon());
            return icon;
        }
    }
}
