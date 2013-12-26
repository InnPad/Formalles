using System;
using System.IO;
using System.Web.Mvc;
using System.Windows.Media.Imaging;

namespace Formall.Web.Mvc
{
    using Formall.Presentation;

    public class ImageResult : ActionResult
    {
        MediaType _mediaType;
        byte[] _buffer;

        public ImageResult(byte[] buffer, MediaType mediaType)
        {
            _buffer = buffer;
            _mediaType = mediaType;
        }

        /// <summary>
        /// Initializes a new instance of the Empress.Results.ImageResult class.
        /// </summary>
        internal ImageResult(BitmapEncoder encoder)
        {
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }

            _mediaType = encoder.CodecInfo.MimeTypes;

            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                stream.Seek(0, SeekOrigin.Begin);
                _buffer = stream.ToArray();
            }
        }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that
        /// inherits from the System.Web.Mvc.ActionResult class.
        /// </summary>
        /// <param name="context">
        /// The context in which the result is executed. The context information includes
        /// the controller, HTTP content, request context, and route data.
        /// </param>
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = _mediaType;

            context.HttpContext.Response.OutputStream.Write(_buffer, 0, _buffer.Length);
        }
    }
}