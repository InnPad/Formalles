using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using System.Windows.Media;

namespace Formall.Web.Mvc.Controllers
{
    using Formall.Imaging;
    using Formall.Imaging.QrCode.Encoding;

    public class QrCodeController : RenderController
    {
        public QrCodeController()
        {
            DPI = new Point(96, 96);
            PixelFormat = PixelFormats.Gray8;
        }

        //
        // GET: /Present/QrCode/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Text(string id, byte? moduleSize)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode = qrEncoder.Encode(id);
            return Render(qrCode.Matrix, new FixedModuleSize(moduleSize ?? 4, QuietZoneModules.Four));
        }
    }
}
