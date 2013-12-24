using System;
using System.Windows.Media.Imaging;

namespace Formall.Imaging
{
    public static class ImageFormatExtensions
    {
        public static BitmapEncoder ChooseEncoder(this ImageFormat imageFormat)
        {
            switch (imageFormat)
            {
                case ImageFormat.Bmp:
                    return new BmpBitmapEncoder();
                case ImageFormat.Gif:
                    return new GifBitmapEncoder();
                case ImageFormat.Jpeg:
                    return new JpegBitmapEncoder();
                case ImageFormat.Png:
                    return new PngBitmapEncoder();
                case ImageFormat.Tiff:
                    return new TiffBitmapEncoder();
                case ImageFormat.Wmp:
                    return new WmpBitmapEncoder();
                default:
                    return new PngBitmapEncoder();
                    //throw new ArgumentOutOfRangeException("imageFormat", imageFormat, "No such encoder support for this imageFormat");
            }
        }
    }
}
