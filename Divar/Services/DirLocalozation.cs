using Divar.Interfaces;
using System.Globalization;

namespace Divar.Services
{
    public class DirLocalozation : IDirLocalozation
    {
        public string ReadLocalizedDir()
        {
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                return "rtl";
            }
            else
            {
                return "ltr";
            }
        }
        public string ReadlocalizedBootstrapLink()
        {
            if (CultureInfo.CurrentCulture.ToString() == "fa-IR")
            {
                return "/lib/bootstrap/dist/css/bootstrap.rtl.min.css";
            }
            else
            {
                return "/lib/bootstrap/dist/css/bootstrap.min.css";
            }
        }
    }
}
